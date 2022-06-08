using CustomerModel;

//Create MainMenu:
namespace CustomerUI{
    //References IMenu interface:
    public class MainMenu : IMenu{
        public void Display(){
            Console.WriteLine("Welcome to Main Store Hub Window");
            Console.WriteLine("[1] - Add Customer");
            Console.WriteLine("[2] - Search for Customer");
            Console.WriteLine("[3] - View Store Front Inventory");
            Console.WriteLine("[4] - Place Order");
            Console.WriteLine("[5] - Replenish Inventory");
            Console.WriteLine("[6] - Exit Program");
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
                return "";
            }
            else if(userInput=="4"){
                return "";
            }
            else if(userInput=="5"){
                return "";
            }
            else if(userInput=="6"){
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