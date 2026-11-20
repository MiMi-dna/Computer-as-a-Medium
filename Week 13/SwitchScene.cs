using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string buttonSceneName; //scene name placeholder, will need to specify a name if running multiple scenes in one game
    public string loseScene;
    
    public void LoseScene(bool isGameOver)
    {
        if (isGameOver == true)
        {
            SceneManager.LoadScene(loseScene);
        }
    }
    public void SwitchScenes() //Switchscene versus Switchscenes prevents class overloading issues 
    {
        SceneManager.LoadScene(buttonSceneName); //SceneManager is an existing SceneManager class in Unity's built in system, we're calling that class/interface function LoadScene(); and using our "buttonSceneName", we defined in the variable "Public String"
    }

    // public void SwitchScenes(PlayerHealth player) //an example of an overloarded function in a class w/ a parameter of a code Player Health Object type with name "player"
    // {
        //// this function will only trigger if the parameter for PlayerHealth is fullfilled. Otherwise, the void function w/
        //// no parameters will implement instead
    // }
}

//notes about overloading:
// overloading is when you use a function/method name more than once but it cannot conflict w/ a class/interface name.
//some languages let you name a function/method the same as its class but it's very bad practice and can cause implementation issues.
// This is related to how object oriented languages manage inheritance and polymorphism. Additionally, the term "Function" is a "Method", 
// they are functionally the same (pun intended) for the purposes of lecture and learning about scripting in object oriented languages.

//knowing this will help for file organization (fiuguring out where you want to put everything) and make maintenance easier.
//normally you want one file to hold your defitions, another files to manage a specific takes, then manage the properties from there
//e.g. we will only need one "Attack" file where all "Attack" actions like shooting, stabbing, etc. can inherit the properties of an
//"Attack" like dealing damage. But if "Attack" is one of many "Actions" a player can do, an "Action" script will include a call to "Attack"
//based on set parameters. The "Action" file would contain definitions and calls for all possible player "Actions"
//this is how you get games where "A" can be pressed to interact w/ an NPC you are close w versus using an action action when you are not
//close enough to them
