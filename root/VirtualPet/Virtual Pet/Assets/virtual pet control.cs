using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class virtualpetcontrol : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private TextMeshProUGUI timerText;
    private float timer;
    [SerializeField] private TextMeshProUGUI replyText;
    [SerializeField] private TMP_InputField nameField;

    [SerializeField] private GameObject feedButton;
    [SerializeField] private GameObject restButton;
    [SerializeField] private GameObject playButton;
    private int bonusHappiness = 0;
    private bool bonusAllowed = true;

    VirtualPet vPet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayStatus();
    }


    void DisplayStatus()
    {
        //displays the current statuses of the pet in 1 single text box
        //hunger, energy, happiness
        displayText.text = $"{vPet.Hunger}/10 \n {vPet.Energy}/10 \n {vPet.CalculateHappiness(vPet.Energy, vPet.Hunger, bonusHappiness)}/10";
        timerText.text = $"Time spent together \n {(int)(timer += Time.deltaTime)} seconds";
    }

    void DisplayReply(int replyControl)
    {
        //gives a reply based on the action provided
        switch (replyControl)
        {
            case 1:
                // basic response
                replyText.text = $" {vPet.Name} waits patiently";
                break;
            case 2:
                // accepting food
                replyText.text = $" {vPet.Name} is happily eating";
                break;
            case 3:
                // denying food
                replyText.text = $" {vPet.Name} is no longer hungry";
                break;
            case 4:
                // is playing
                replyText.text = $" {vPet.Name} is playing!";
                break;
            case 5:
                // too tired to play
                replyText.text = $"{vPet.Name} is too tired to play";
                break;
            case 6:
                // too hungry to play
                replyText.text = $"{vPet.Name} is too hungey to play";
                break;
            case 7:
                // goes to sleep
                replyText.text = $"{vPet.Name} went to sleep";
                break;
            case 8:
                // is too energetic to sleep
                replyText.text = $"{vPet.Name} has too much energy to sleep";
                break;
            default:
                // code to execute when replyControl is not any of the above values
                replyText.text = $" {vPet.Name} waits for your command";
                break;
        }
    }

    void GiveName()
    {
        //only called at the beginning when the submit button is clicked
        vPet.Name = nameField.text;
    }

    void AssignStartingValues()
    {
        // give atm least some starting numbers that allow time to
        int min = 3;
        int max = 7;

        vPet.Energy = Random.Range(min, max);
        vPet.Hunger = Random.Range(min, max);
        vPet.Happiness = Random.Range(min, max);
    }

    private IEnumerator TurnOffButtons()
    {
        //turns the buttons off, waits a bit, then turns them on again.
        feedButton.SetActive(false);
        playButton.SetActive(false);
        restButton.SetActive(false);
        yield return new WaitForSeconds(Random.Range(5, 10));
        feedButton.SetActive(true);
        playButton.SetActive(true);
        restButton.SetActive(true);
    }

    private IEnumerator GiveBonusHappiness()
    {
        //allow the petting bonus to be applied every so often, but disallow it until its available again
        if (bonusAllowed)
        {
            bonusHappiness = Random.Range(1, 4);
            yield return new WaitForSeconds(Random.Range(5, 10));
            bonusHappiness = 0;
            bonusAllowed = false;
            RunTimer(10f, "EndBonusHappiness");
        }
        
    }
    //is only here because i didnt know how i could call it without adding in some clause in the runtimer script
    void EndBonusHappiness()
    {
        bonusAllowed = true;
    }

    //lose condition
    void CheckLose()
    {
        if (vPet.Happiness <= 0 || vPet.Hunger <= 0 || vPet.Energy <= 0)
        {
            //do some code here to describe the win condition
        }
    }



    //dedicated timer to be used for other stuff
    public void RunTimer(float seconds, string methodName)
    {
        StartCoroutine(StartTimer(seconds, methodName));
    }

    private IEnumerator StartTimer(float seconds, string methodName)
    {
        Debug.Log($"Starting timer for {seconds} seconds");
        yield return new WaitForSeconds(seconds);
        Invoke(methodName, 5f);
        Debug.Log("Timer complete!");
    }



    #region Button Control

    public void StartButton()
    {
        //creates a new pet as instructed
        vPet = new VirtualPet();
    }

    public void QuitButton()
    {
        //allows the player to quit the game
    }

    public void PetButton()
    {
        if(vPet.Happiness < 10)
        {
            StartCoroutine(GiveBonusHappiness());
        }
    }

    public void FeedButton()
    {
        int maxFoodAmount = 10;
        if (vPet.Hunger < maxFoodAmount)
        {
            vPet.Eat();
            //DisplayReply(7);
        }
        else
        {

        }
    }

    public void RestButton()
    {
        int maxEnergy = 10;
        if (vPet.Hunger < maxEnergy)
        {
            vPet.Rest();
            DisplayReply(7);
        }
        else
        {
            DisplayReply(8);
        }
    }

    public void PlayWithPetButton()
    {
        int energyMinimum = 10;
        if (vPet.Energy > energyMinimum)
        {
            vPet.Play();
            //DisplayReply(7);
        }
        else
        {
            DisplayReply(5);
        }
    }

    #endregion
}
