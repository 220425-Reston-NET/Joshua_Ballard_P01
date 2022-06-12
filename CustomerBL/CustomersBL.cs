using CustomerDL;
using CustomerModel;

namespace CustomerBL
{
    public class CustomersBL : ICustomerBL
    {
        //************Dependency Injection***********************
            private IRepository<Customer> _customerRepo;
            public CustomersBL(IRepository<Customer> c_customerRepo)
            {
                _customerRepo = c_customerRepo;
            }
        //*******************************************************

        public async void AddCustomer(Customer c_customer){

            //Checks if that customer name already exists
            Customer foundcustomer = SearchCustomerByName(c_customer.Name);
            if (foundcustomer == null)
            {
                //Creates a customer:
                    _customerRepo.Add(c_customer);
                }
                else
                {

                    throw new Exception("Customer already exists.");
                }
        }

        
        public void AddOrderToCustomer(Customer c_customer)
        {
            _customerRepo.Update(c_customer);
        }
        

        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.GetAll();
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepo.GetAllAsync();
        }

        public Customer SearchCustomerByName(string c_customerName){
            //GetAllCustomer method grabs all customer's from json Repository
            //places that inside currentListOfCustomer List
            List<Customer> currentListOfCustomer = _customerRepo.GetAll();

            foreach(Customer customerObj in currentListOfCustomer){
                //Itterate(go thru) every name in the list:
                if(customerObj.Name == c_customerName){
                    return customerObj;
                }
            }
            return null;
        }

    }
}