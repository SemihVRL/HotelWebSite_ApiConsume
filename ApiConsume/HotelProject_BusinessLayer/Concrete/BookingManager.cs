using HotelProject_BusinessLayer.Abstract;
using HotelProject_DataAccessLayer.Abstract;
using HotelProject_DataAccessLayer.Migrations;
using HotelProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject_BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
           _bookingDal = bookingDal;
        }

        public void TAdd(Booking t)
        {
            _bookingDal.Add(t);
        }

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);
        }

        public Booking TGetByID(int id)
        {
            return _bookingDal.GetByID(id);
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public void TUpdate(Booking t)
        {
           _bookingDal.Update(t);
        }
    }
}
