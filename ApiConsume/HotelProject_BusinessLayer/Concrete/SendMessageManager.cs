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
    public class SendMessageManager:ISendMessageService
    {
        private readonly ISendMessageDal _messageDal;

        public SendMessageManager(ISendMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(SendMessage t)
        {
            _messageDal.Add(t);
        }

        public void TDelete(SendMessage t)
        {
            _messageDal.Delete(t);
        }

        public SendMessage TGetByID(int id)
        {
            return _messageDal.GetByID(id);
        }

        public List<SendMessage> TGetList()
        {
            return _messageDal.GetList();
        }

        public void TUpdate(SendMessage t)
        {
            _messageDal.Update(t);
        }
    }
}
