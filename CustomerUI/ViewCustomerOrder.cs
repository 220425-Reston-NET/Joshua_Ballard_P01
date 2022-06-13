using CustomerDL;
using CustomerModel;

namespace CustomerUI{
    public class ViewCustomerOrder : IMenu{

        public void Display(){
            Console.WriteLine("==========Customer Orders==========");
            foreach(Order _orderObj in SearchCustomer.foundCustomer.Orders){
                Console.WriteLine(_orderObj);
            }
        }

        public string YourChoice(){
            return "MainMenu";
        }
    }
}
