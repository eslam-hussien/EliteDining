using EliteDining.BL.IServices;
using EliteDining.DAL.IRepo;
using EliteDining.DAL.Models;
using EliteDining.DAL.Repo;
using System;
using System.Transactions;

namespace EliteDining.BL.Services
{
    public class BookingService : IBookingService
    {

        private readonly IGenericRepo<Booking> _bookingRepo;
        private readonly IGenericRepo<Customer> customerRepo;
        private readonly TableRepo tableRepo;

        public BookingService(IGenericRepo<Booking> bookingRepo, IGenericRepo<Customer> customerRepo, TableRepo tableRepo)
        {
            _bookingRepo = bookingRepo;
            this.customerRepo = customerRepo;
            this.tableRepo = tableRepo;
        }

        public async Task<int> AddBooking(string phone, int? persons, DateTime? date)
        {

            try
            {
                var customer = await customerRepo.GetOne(x => x.Phone == phone);
                if (customer == null)
                {
                    return -1;
                }
                var tables = await tableRepo.GetAllTables(c => c.AvailableSeats >= persons);
                if (tables.Count()==0)
                {
                    return -2;
                }
                foreach (var table in tables)
                {
                    var reservation= await _bookingRepo.GetOne(x=>(x.TableNo==table.TableNo && (date >= x.FromDate.AddHours(-2) && date <= x.ToDate)));

                    if (reservation!=null)
                        continue;

                    var booking = new Booking
                    {
                        CustId = customer.CustId,
                        TableNo = table.TableNo,
                        FromDate = date.Value,
                        ToDate = date.Value.AddHours(2),
                    };
                    var result = await _bookingRepo.Add(booking);
                    return result;
                }
                
            }
            catch (Exception ex)
            {
                return 0;  
            }
            return -3;
        }

      
    }


}

