using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class virtualpetcontrol : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private TextMeshProUGUI replyText;

    [SerializeField] private TextMeshProUGUI feedButton;
    [SerializeField] private TextMeshProUGUI restButton;
    [SerializeField] private TextMeshProUGUI playButton;

    VirtualPet vPet;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void DisplayStatus()
    {
        //displays the current statuses of the pet in 1 single text box

    }

    void DisplayReply(int replyControl)
    {
        //gives a reply based on the action provided
        switch (replyControl)
        {
            case 1:
                // basic response
                break;
            case 2:
                // accepting food
                break;
            case 3:
                // denying food
                break;
            case 4:
                // is playing
                break;
            case 5:
                // too tired to play
                break;
            case 6:
                // too hungry to play
                break;
            case 7:
                // goes to sleep
                break;
            case 8:
                // is too energetic to sleep
                break;
            default:
                // code to execute when replyControl is not any of the above values
                break;
        }
    }






    //lose condition



    //dedicated timer to be used for other stuff
    public void RunTimer(float seconds)
    {
        StartCoroutine(StartTimer(seconds));
    }

    private IEnumerator StartTimer(float seconds)
    {
        Debug.Log($"Starting timer for {seconds} seconds");

        yield return new WaitForSeconds(seconds);

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

    public void FeedButton()
    {
        int maxFoodAmount = 10;
        if (vPet.Hunger < maxFoodAmount)
        {

        }
    }

    public void RestButton()
    {

    }

    public void PlayWithPetButton()
    {

    }

    #endregion
}
