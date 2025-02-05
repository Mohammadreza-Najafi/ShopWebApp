﻿using _0_Framwork.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var Operation = new OperationResult();
            if(_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);

            _colleagueDiscountRepository.Create(colleagueDiscount);
            _colleagueDiscountRepository.SaveChanges();

            return Operation.Succedded();

        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var Operation = new OperationResult();

            var colleagueDiscount = _colleagueDiscountRepository.Get(command.Id);

            if(colleagueDiscount == null)
            {
                return Operation.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
            {
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            colleagueDiscount.Edit(command.ProductId,command.DiscountRate);

            _colleagueDiscountRepository.SaveChanges();

            return Operation.Succedded();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var Operation = new OperationResult();

            var colleagueDiscount = _colleagueDiscountRepository.Get(id);

            if (colleagueDiscount == null)
            {
                return Operation.Failed(ApplicationMessages.RecordNotFound);
            }
           
            colleagueDiscount.Remove(); 

            _colleagueDiscountRepository.SaveChanges();

            return Operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var Operation = new OperationResult();

            var colleagueDiscount = _colleagueDiscountRepository.Get(id);

            if (colleagueDiscount == null)
            {
                return Operation.Failed(ApplicationMessages.RecordNotFound);
            }

            colleagueDiscount.Restore();

            _colleagueDiscountRepository.SaveChanges();

            return Operation.Succedded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}
