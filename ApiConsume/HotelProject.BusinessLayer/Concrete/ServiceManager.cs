﻿using HotelProject.BusinessLayer.Abstrack;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concerate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServicesDal _serviceService;

        public ServiceManager(IServicesDal serviceService)
        {
            _serviceService = serviceService;
        }

        public void TDelete(Service t)
        {
            _serviceService.Delete(t);
        }

        public Service TGetByID(int id)
        {
            return _serviceService.GetByID(id);
        }

        public List<Service> TGetList()
        {
            return _serviceService.GetList();
        }

        public void TInsert(Service t)
        {
            _serviceService.Insert(t);
        }

        public void TUpdate(Service t)
        {
            _serviceService.Update(t);
        }
    }
}
