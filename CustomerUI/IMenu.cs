/// <summary>
/// This is an IMenu interface
/// </summary>
public interface IMenu
{
    //Display method will write to the terminal the answer choices the user can pick
    //It will also show what menu they are currently in:
    void Display();

    //YourChoice method will display menu user inputs located in MainMenu:
    string YourChoice();

}