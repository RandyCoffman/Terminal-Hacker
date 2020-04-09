using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game configureation data
    const string menuHint = "You may type menu at any time.";
    String[] level1Passwords = { "books", "kids", "class", "desks", "teacher"};
    String[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    String[] level3Passwords = { "astronaut", "pathfinder", "wavelength", "zenith", "velocity",  };

    //Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    String password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // ShowStartMenu is called to start the game's main menu
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What Would you Like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local school");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        print(input);
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If you're on the web, please close the tab");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }


    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level error");
                break;
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2" || input == "3");

        if (isValidNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please select a valid level");
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book..");
                Terminal.WriteLine(@"
    ________
   /      //
  /      //
 /______//
(______(/
"               );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/@ \_______
\__/-=' = '
"               );
                break;
            case 3:
                Terminal.WriteLine("Let's take a ride!");
                Terminal.WriteLine(@"
   _
  / \
  | |
  |o|
 /| |\
 -|_|-
"               );
                break;
            default:
                Debug.LogError("Invalid win error");
                break;
        }
    }
}
