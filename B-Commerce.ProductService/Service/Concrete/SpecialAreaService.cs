using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B_Commerce.ProductService.Service.Concrete
{
    public class SpecialAreaService : ISpecialAreaService
    {
        private IRepository<SpacialArea> _repositorySpacial;
        private IUnitOfWork _unitOfWork;

        public SpecialAreaService(IRepository<SpacialArea> repositoryProduct, IRepository<SpacialArea> repositorySpacial, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repositorySpacial = repositorySpacial;
        }

        public SpecialAreaResponse Add(SpacialArea spacialArea)
        {
            SpecialAreaResponse response = new SpecialAreaResponse();
            try
            {
                _repositorySpacial.Add(spacialArea);
                _unitOfWork.SaveChanges();
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }

        public SpecialAreaResponse Delete(int ID)
        {
            SpecialAreaResponse response = new SpecialAreaResponse();
            try
            {
                SpacialArea spacialarea = new SpacialArea { ID = ID };
                _repositorySpacial.Delete(spacialarea);
                _unitOfWork.SaveChanges();
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }

        public SpecialAreaResponse GetSpecialAreas()
        {
            SpecialAreaResponse response = new SpecialAreaResponse();
            try
            {
                response.SpecialAreas = _repositorySpacial.Get().ToList();
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }

        public SpecialAreaResponse Update(SpacialArea specialArea)
        {
            SpecialAreaResponse response = new SpecialAreaResponse();
            try
            {
                _repositorySpacial.Update(specialArea);
                _unitOfWork.SaveChanges();
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }
    }
}
