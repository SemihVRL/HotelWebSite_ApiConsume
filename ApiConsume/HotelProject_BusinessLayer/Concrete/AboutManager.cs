using HotelProject_BusinessLayer.Abstract;
using HotelProject_DataAccessLayer.Abstract;
using HotelProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject_BusinessLayer.Concrete
{
    public class AboutManager:IAboutService
    {
        private readonly IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void TAdd(About t)
        {
            _aboutdal.Add(t);
        }

        public void TDelete(About t)
        {
            _aboutdal.Delete(t);
        }

        public About TGetByID(int id)
        {
            return _aboutdal.GetByID(id);
        }

        public List<About> TGetList()
        {
            return _aboutdal.GetList(); 
        }

        public void TUpdate(About t)
        {
            _aboutdal.Update(t);
        }
    }
}
