using CustomerModel;
using CustomerBL;

public class AddCustomer : IMenu{
    private Customer customerObj = new Customer();

    //===== Dependency Injection Pattern =====
    private ICustomerBL _customerBL;
    //Constructor:
    public AddCustomer(ICustomerBL c_customerBL)
    {
        _customerBL = c_customerBL;
    }
    //========================================

        public void Display(){
            Console.WriteLine("Customer's Name: ");
            customerObj.Name = Console.ReadLine();

            Console.WriteLine("Customer's Address: ");
            customerObj.Address = Console.ReadLine();

            Console.WriteLine("Customer's Phone Number: ");
            customerObj.Phone = Console.ReadLine();

            Console.WriteLine("Customer's E-Mail: ");
            customerObj.Email = Console.ReadLine();

            //Repository.AddCustomer(customerObj);
            _customerBL.AddCustomer(customerObj);

        }

    public string YourChoice(){
               return "MainMenu";
    }//end of YourChoice()
}
