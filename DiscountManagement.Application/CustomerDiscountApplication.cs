using _0_Framwork.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System.Globalization;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;
        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var operation = new OperationResult();

            if (_customerDiscountRepository
                .Exists(x => x.ProductId == command.ProductId &&
                x.DiscountRate == command.DiscountRate))
            {               
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            DateTime startDate;
            DateTime.TryParseExact(command.StartDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);

            DateTime endDate;
            DateTime.TryParseExact(command.EndDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            var customerDiscount = new CustomerDiscount(command.ProductId, command.Name, command.DiscountRate,
                startDate, endDate);

            _customerDiscountRepository.Create(customerDiscount);
            
            _customerDiscountRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operation = new OperationResult();

            var customerDiscount = _customerDiscountRepository.Get(command.Id);

            if(customerDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId
               && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            customerDiscount.Edit(command.ProductId, command.Name, command.DiscountRate,
                          DateTime.Parse(command.StartDate), DateTime.Parse(command.EndDate));

            _customerDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }

       
    }
}
