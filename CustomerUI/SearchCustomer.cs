using CustomerBL;
using CustomerModel;
public class SearchCustomer : IMenu {
    public static Customer foundCustomer;
    //======Dependency Injection=====
    private ICustomerBL _customerBL;
    public SearchCustomer(ICustomerBL c_customerBL)
    {
        _customerBL = c_customerBL;
    }
    //===============================

    public void Display()
    {
        Console.WriteLine("Enter customers name: ");       
    }
    public string YourChoice(){
        string customerName = Console.ReadLine();

        Customer foundCustomer = _customerBL.SearchCustomerByName(customerName);

        //Will only display a found customer:
        if(foundCustomer == null){
            Console.WriteLine("Customer not found!");
        }
        else{
            foundCustomer = _customerBL.SearchCustomerByName(customerName);
            Console.WriteLine(foundCustomer.ToString());
        }
        Console.ReadLine();
         return "MainMenu";
    }
}