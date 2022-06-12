using CustomerDL;
using CustomerModel;

namespace CustomerBL{
    public class OrderBL : IOrderBL{
        //===========Depdency Injection=========
        private IRepository<Order> _orderRepo;
        public OrderBL(IRepository<Order> c_orderRepo){
            _orderRepo = c_orderRepo;
        }
        //======================================

        public List<Order> GetAllOrders(){
            return _orderRepo.GetAll();
        }

        public Order SearchOrderByLocation(string c_orderLocation){
            List<Order> currentOrderList = _orderRepo.GetAll();

            foreach(Order orderobj in currentOrderList){
                if(orderobj.Location == c_orderLocation){
                    return orderobj;
                }
            }
            return null;
        }
    }//end of class 
}//end of namespace