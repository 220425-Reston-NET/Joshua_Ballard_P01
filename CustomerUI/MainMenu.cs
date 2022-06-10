using CustomerModel;

//Create MainMenu:
namespace CustomerUI{
    //References IMenu interface:
    public class MainMenu : IMenu{
        public void Display(){
            Console.WriteLine("**Welcome to the Main Store Hub Window**");
            Console.WriteLine("[1] - Add Customer");
            Console.WriteLine("[2] - Search for Customer");
            Console.WriteLine("[3] - Select Order");
            Console.WriteLine("[4] - View Customer Order");
            Console.WriteLine("[5] - Exit Program");
        }

        //Method asks for user's choice input:
        public string YourChoice(){
            string userInput = Console.ReadLine();

            //userInput Choices:
            if(userInput=="1"){//add customer
                //Create customer object:
                return "AddCustomer";
            }
            else if(userInput=="2"){
                return "SearchCustomer";
            }
            else if(userInput=="3"){
                return "SelectOrder";
            }
            else if(userInput=="4"){
                return "ViewCustomerOrder";
            }
            else if(userInput=="5"){
                return "Exit";
            }
            else {
                Console.Clear();
                Console.WriteLine("Please input a valid response.");
                Console.ReadLine();
                return "MainMenu"; 
            }           
        }//end of YourChoice()

    }//end of MainMenu()
}//end of namespace