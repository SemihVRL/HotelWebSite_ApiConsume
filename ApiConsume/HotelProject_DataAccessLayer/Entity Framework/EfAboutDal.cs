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
    public class EfAboutDal:GenericRepository<About>,IAboutDal
    {
        public EfAboutDal(Context context) : base(context)
        {

        }
    }
}
