using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concerate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntitiyFramework
{
    //EntitiyFramework içerisine hem repository hemde Entitiy örneği alıyoruz.
    public class EfRoomDal:GenericRepository<Room>,IRoomDal
    {
        public EfRoomDal(Context context):base(context)
        {
        }
    }
}
