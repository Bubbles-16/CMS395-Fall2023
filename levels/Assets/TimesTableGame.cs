using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimesTableGame : MonoBehaviour
{
    public GameObject landingScreenUI;
    public GameObject timesTableUI;
    public int questionsToUnlockGame = 5; // Number of correct answers required to unlock the game
    public GameObject fireBoy;
    public GameObject waterGirl;
    public GameObject gameBlock;

    private int correctAnswersCount = 0;
    private bool gameUnlocked = false;
    private int chosenNumber = 0;
    private bool randomTimesTables = true;
    private System.Random random = new System.Random();

    void Start()
    {
        // Show the landing screen UI and hide the times table UI initially
        landingScreenUI.SetActive(true);
        timesTableUI.SetActive(false);
    }

    void Update()
    {
        if (!gameUnlocked)
        {
            if (landingScreenUI.activeSelf)
            {
                // Handle the landing screen input
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    int userInput;
                    if (int.TryParse(GetComponentInChildren<UnityEngine.UI.InputField>().text, out userInput))
                    {
                        if (userInput > 0)
                        {
                            randomTimesTables = false;
                            chosenNumber = userInput;
                            ShowTimesTableUI();
                        }
                        else
                        {
                            randomTimesTables = true;
                            ShowTimesTableUI();
                        }
                    }
                    else
                    {
                        DisplayInvalidInputMessage();
                    }
                }
            }
            else if (timesTableUI.activeSelf)
            {
                // Handle the times table questions and answers
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    int answer;
                    if (int.TryParse(GetComponentInChildren<UnityEngine.UI.InputField>().text, out answer))
                    {
                        if (CheckAnswer(answer))
                        {
                            correctAnswersCount++;

                            if (correctAnswersCount >= questionsToUnlockGame)
                            {
                                UnlockGame();
                            }
                            else
                            {
                                AskNextQuestion();
                            }
                        }
                        else
                        {
                            DisplayIncorrectAnswerMessage();
                            AskNextQuestion();
                        }
                    }
                    else
                    {
                        DisplayInvalidInputMessage();
                    }
                }
            }
        }
        else
        {
            // Implement the Fire Boy and Water Girl game logic here
            // Update their movement, handle collisions, etc.
        }
    }

    bool CheckAnswer(int answer)
    {
        int num1, num2;
        
        if (randomTimesTables)
        {
            // Generate random numbers within a certain range
            num1 = random.Next(2, 10); // Example range: 2 to 9
            num2 = random.Next(1, 10);
        }
        else
        {
            // Use the chosen number for the times table
            num1 = chosenNumber;
            num2 = random.Next(1, 10);
        }
        
        int correctAnswer = num1 * num2;
        return answer == correctAnswer;
    }

    void AskNextQuestion()
    {
        int num1, num2;
        
        if (randomTimesTables)
        {
            // Generate random numbers within a certain range
            num1 = random.Next(2, 10); // Example range: 2 to 9
            num2 = random.Next(1, 10);
        }
        else
        {
            // Use the chosen number for the times table
            num1 = chosenNumber;
            num2 = random.Next(1, 10);
        }
        
        string question = num1 + " x " + num2;
        // Display the question in the UI for the user to answer
    }

    void UnlockGame()
    {
        // Activate the Fire Boy and Water Girl game
        fireBoy.SetActive(true);
        waterGirl.SetActive(true);
        gameBlock.SetActive(true);
        gameUnlocked = true;

        // Hide or disable the times table UI elements
        // You can deactivate or hide the UI elements related to the questions
        timesTableUI.SetActive(false);
    }

    void DisplayIncorrectAnswerMessage()
    {
        // Display a message to the user indicating their answer was incorrect
        // You can update a UI element with the message
    }

    void DisplayInvalidInputMessage()
    {
        // Display a message to the user indicating their input was invalid
        // You can update a UI element with the message
    }

    void ShowTimesTableUI()
    {
        // Hide the landing screen UI and show the times table UI
        landingScreenUI.SetActive(false);
        timesTableUI.SetActive(true);

        // Initialize the game state for times table questions
        correctAnswersCount = 0;
        gameUnlocked = false;

        // Clear any previous input in the input field
        GetComponentInChildren<UnityEngine.UI.InputField>().text = "";

        // Start asking the first question
        AskNextQuestion();
    }
}
