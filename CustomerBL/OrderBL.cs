using CustomerDL;
using CustomerModel;

namespace CustomerBL{
    public class  OrderBL : IOrderBL
    {
        //======Dependency Injection==========
        private IRepository<Order> _orderRepo;

        public OrderBL(IRepository<Order> c_orderRepo)
        {
            _orderRepo = c_orderRepo;
        }

        //====================================
        public List<Order> GetAllOrders(){
            
            return _orderRepo.GetAll();
        }

        public Order SearchOrderbyLocation(string p_orderLocation)
        {
            List<Order> currentOrderList = _orderRepo.GetAll();

            foreach(Order orderobj in currentOrderList)
            {
                if(orderobj.Location == p_orderLocation)
                {
                    return orderobj;
                }

            }
            
            //returns nothing/no value
            return null;
        }
    }
}