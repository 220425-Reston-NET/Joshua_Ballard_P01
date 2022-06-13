using CustomerModel;

namespace CustomerBL{
    public interface IOrderBL
    {
        /// <summary>
        /// Get all orders from db
        /// </summary>
        /// <returns>Returns list of orders</returns>
        List<Order> GetAllOrders();

        /// <summary>
        /// Find in db based on location
        /// </summary>
        /// <param name="c_orderLocation">searches for order</param>
        /// <returns>returns order object</returns>
        Order SearchOrderByLocation(string c_orderLocation);
    }
}