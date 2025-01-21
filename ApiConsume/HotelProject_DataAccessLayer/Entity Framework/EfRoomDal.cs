using HotelProject_DataAccessLayer.Abstract;
using HotelProject_DataAccessLayer.Concrete;
using HotelProject_DataAccessLayer.Repository;
using HotelProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject_DataAccessLayer.Entity_Framework
{
    public class EfRoomDal:GenericRepository<Room>,IRoomDal
    {
        public EfRoomDal(Context context):base(context) // base context olması= ctor çağırmak
        {
                
        }
    }
}
