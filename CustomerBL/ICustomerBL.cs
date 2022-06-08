using CustomerModel;

namespace CustomerBL{
    /// <summary>
    /// Validates fata obtained from database and user
    /// </summary>
    public interface ICustomerBL
    {
        /// <summary>
        /// Add customer to the database
        /// </summary>
        /// <param name="c_customer"></param>
        /// <returns></returns>
        void AddCustomer(Customer c_customer);

        /// <summary>
        /// Search for a customer in the database
        /// </summary>
        /// <param name="c_customerName"></param>
        /// <returns></returns>
        Customer SearchCustomerByName(string c_customerName);

        /// <summary>
        /// Returns current customer roster
        /// </summary>
        /// <returns>List object that holds customers</returns>
        List<Customer> GetAllCustomers();
        
        /// <summary>
        /// Will give all current customers in the DB async.
        /// </summary>
        /// <returns></returns>
        Task<List<Customer>> GetAllCustomersAsync();
    }
}