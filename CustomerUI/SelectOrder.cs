using CustomerBL;
using CustomerModel;

namespace CustomerUI{
    public class SelectOrder : IMenu{
        //=========Dependency Inkection========
            private IOrderBL _orderBL;
            private ICustomerBL _customerBL;

            public SelectOrder(IOrderBL c_orderBL, ICustomerBL c_customerBL){
                _orderBL = c_orderBL;
                _customerBL = c_customerBL;
            }
        //=====================================
        public void Display(){
            List<Order> listOfOrder = _orderBL.GetAllOrders();
            foreach(Order _orderObj in listOfOrder){
                Console.WriteLine(_orderObj.Location);
            }
        }

        public string YourChoice(){
            Console.WriteLine("Choose a location from the list above to add an order: ");
            string userInput = Console.ReadLine();

            Order foundOrder = _orderBL.SearchOrderByLocation(userInput);

            if (foundOrder != null){
                //Adds order to searched customer using List of orders in CustomerModel:
                SearchCustomer.foundCustomer.Orders.Add(foundOrder);
                _customerBL.AddOrderToCustomer(SearchCustomer.foundCustomer);
            }
            else{
                Console.WriteLine("Invalid order location!");
                Console.ReadLine();
                return "SelectOrder";
            }
            Console.ReadLine();
            return "MainMenu";
        }
    }//end of class SelectOrder : IMenu
}//end of namespace CustomerUI

