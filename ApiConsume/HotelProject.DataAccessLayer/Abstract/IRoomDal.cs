using HotelProject.EntityLayer.Concerate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    // Room Entiti burada IGenericDal varlığından haberdar oluyor ve Entitiy özelinde olan methodlar yazabiliriz.
    public interface IRoomDal:IGenericDal<Room>
    {
    }
}
