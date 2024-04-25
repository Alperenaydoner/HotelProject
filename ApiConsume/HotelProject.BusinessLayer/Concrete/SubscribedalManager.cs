using HotelProject.BusinessLayer.Abstrack;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concerate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SubscribedalManager : ISubscribeService
    {
        private readonly ISubscribesDal __subscribeDal;

        public SubscribedalManager(ISubscribesDal _subscribeDal)
        {
            __subscribeDal = _subscribeDal;
        }

        public void TDelete(Subscribe t)
        {
            __subscribeDal.Delete(t);
        }

        public Subscribe TGetByID(int id)
        {
            return __subscribeDal.GetByID(id);
        }

        public List<Subscribe> TGetList()
        {
            return __subscribeDal.GetList();
        }

        public void TInsert(Subscribe t)
        {
            __subscribeDal.Insert(t);
        }

        public void TUpdate(Subscribe t)
        {
            __subscribeDal.Update(t);
        }
    }
}
