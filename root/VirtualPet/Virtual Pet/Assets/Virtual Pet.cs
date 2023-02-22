using UnityEngine;
using System;

public class VirtualPet
{
    // Start is called before the first frame update
    private string name;
    private int hunger;
    private int happiness;
    private int energy;


    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Hunger
    {
        get { return hunger; }
        set { hunger = value; }
    }
    public int Happiness
    {
        get { return happiness; }
        set { happiness = value; }
    }
    public int Energy
    {
        get { return energy; }
        set { energy = value; }
    }



    public void Eat()
    {
        if (hunger < 10)
        {
            //give the pet some food
            hunger += UnityEngine.Random.Range(2, 5);
        }
    }

    public void Rest()
    {
        //burn some time, then give the pet more enegry, and spend a little food
        //turn off the buttons for a period of time
        hunger -= UnityEngine.Random.Range(0, 3);
        energy += UnityEngine.Random.Range(2, 5);
    }

    public void Play()
    {
        if (hunger > 0 && energy < 10)
        {
            //require food a minimum food amount, and then check if the energy is high enough. 
            //play should handle only the mathmatical computations, and should call
            happiness += UnityEngine.Random.Range(2, 5);
            energy -= UnityEngine.Random.Range(2, 5);
            hunger -= UnityEngine.Random.Range(1, 3);
        }
        
        
    }

    public int CalculateHappiness(int hunger, int energy, int bonusHappiness)
    {
        int maxHappiness = 10;

        int totalNumbers = ((energy + hunger) / 2) + bonusHappiness;
        if (totalNumbers > maxHappiness) { totalNumbers = maxHappiness; }
        return totalNumbers;
    }
}
//The Pet class cannot inherit from MonoBehaviour and must include at least one constructor,
//4 public properties (name, hunger or fullness, boredom or happiness, tiredness or energy level),
//and 3 methods(eat, rest, and play).You can add other characteristics as needed.

//The game should include a title and detailed instructions on how to play the game. 
//At the start, the player should be asked to give a name for their pet.
//The button to submit the name of the pet should only become enabled when something has been entered in the input field. 

//When the submit button is clicked, a Pet should be instantiated.

//The interface to interact with the pet should include a way for the player to visualize the level of boredom
//(or happiness), hunger(or fullness), and tiredness(or energy level) of the pet. It should allow the player to feed, give rest to, or play with the pet.

//As time goes by, the pet should get hungrier, become bored and tired in a way that makes the game challenging but not impossible.

//If the levels of boredom, hunger and tiredness become too high
//(you should determine that threshold and display it for the player),
//animal services would intervene and take the pet away. The player would lose the game (and the pet).
//You can also use levels of fullness, energy, and happiness being too low to establish the loss condition.

//The game does not have any winning conditions but you may add some if you would like.
//If the pet is taken away, the player should be able to adopt a new pet(since the pets are virtual).

//All UI elements must be properly anchored to ensure the interface adapts well to different resolutions.

//All UI elements, variables, and methods must be named meaningfully and follow naming conventions discussed during the lecture.

//The project must be organized and named as dictated in the submission guidelines of the course
