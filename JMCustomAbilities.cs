/*
Author: Jeffrey Meldrum

Date: 04/04/2023

Description: A child class of parent abilities, this class allows the user to pick specific abilities limited by the level that was inputted
Responsibilities: take the filtered ability list then give the user options of wich abilities to pick

*/

using System;
using System.IO;
using System.Collections.Generic;

public class JMCustomAbilities : JMParentAbilities
{
    public JMCustomAbilities()
    {

    }
    
    public override List<string> JMRandomAbilties(List<string> JMFilteredAbilities, string JMPokemonLevel)
    {
        int i = 1;
        int JMPokemonLevelInteger = Int32.Parse(JMPokemonLevel);
        Console.WriteLine("Abilities you may select from:");
        List<string> JMNumericalChoices = new List<string>();
        foreach(string JMFilteredAbility in JMFilteredAbilities)
        {
            Console.WriteLine($"({i}) {JMFilteredAbility}");
            JMNumericalChoices.Add(i.ToString());
            i++;
        }
        
        // determines how many they can pick
        // only allows one ability to be picked
        List<string> JMChosenAbilitiesNumbers = new List<string>();
        List<string> JMChosenAbilities = new List<string>();
        string JMPickedNumber = "";
        List<string> JMPickedNumbers = new List<string>();

        if (JMPokemonLevelInteger < 20)
        {
            Console.WriteLine("You may pick 1 ability");
            Console.WriteLine("Enter your numerical choice:");
            JMPickedNumber = Console.ReadLine();
            
            // makes sure they actually put in a number
            bool JMValidChoice = true;
            while(JMValidChoice)
            {
                foreach(string JMNumericalChoice in JMNumericalChoices)
                {
                    if(JMNumericalChoice == JMPickedNumber)
                    {
                        JMValidChoice = false;
                    }
                }
                
                if(JMValidChoice)
                {
                    Console.WriteLine("Please enter a valid numerical");
                    JMPickedNumber = Console.ReadLine();
                }
            }

            // adds their choice to the custom ability list
            JMChosenAbilities.Add(JMFilteredAbilities[Int32.Parse(JMPickedNumber)-1]);
        }

        // only allows two abilities to be picked
        else if(JMPokemonLevelInteger < 40)
        {
            Console.WriteLine("You may pick 2 abilities");
            int JMChosenAbilitiesListLength = 0;
            // makes sure they get all the choices into the list
            while(JMChosenAbilitiesListLength < 2)
            {
                Console.WriteLine("Please enter your numerical choice");
                JMPickedNumber = Console.ReadLine();

                bool JMValidChoice = true;
                while(JMValidChoice)
                {
                    // makes sure its actually a number being chosen
                    foreach(string JMNumericalChoice in JMNumericalChoices)
                    {
                        if(JMNumericalChoice == JMPickedNumber)
                        {
                            JMValidChoice = false;
                        }
                    }
                    // makes sure the number isn't being picked again
                    foreach(string JMPreviousPickedNumber in JMPickedNumbers)
                    {
                        if (JMPreviousPickedNumber == JMPickedNumber)
                        {
                            JMValidChoice = false;
                        }
                    }
                    
                    // if JMValidChoice is still true then they will be asked to re-enter their choice
                    if(JMValidChoice)
                    {
                        Console.WriteLine("Please enter a valid numerical");
                        JMPickedNumber = Console.ReadLine();
                    }
                    // if it is false the ability will be added to the list
                    else
                    {
                        JMPickedNumbers.Add(JMPickedNumber);
                        JMChosenAbilities.Add(JMFilteredAbilities[Int32.Parse(JMPickedNumber)-1]);
                    }
                    JMChosenAbilitiesListLength = JMChosenAbilities.Count();
                }
            }
        }

        // allows three abilities to be picked
        else if(JMPokemonLevelInteger < 60)
        {
            Console.WriteLine("You may pick 3 abilities");
            int JMChosenAbilitiesListLength = 0;
            // makes sure they get all the choices into the list
            while(JMChosenAbilitiesListLength < 3)
                {
                    Console.WriteLine("Please enter your numerical choice");
                    JMPickedNumber = Console.ReadLine();

                    bool JMValidChoice = true;
                    while(JMValidChoice)
                    {
                        // makes sure its actually a number being chosen
                        foreach(string JMNumericalChoice in JMNumericalChoices)
                        {
                            if(JMNumericalChoice == JMPickedNumber)
                            {
                                JMValidChoice = false;
                            }
                        }
                        // makes sure the number isn't being picked again
                        foreach(string JMPreviousPickedNumber in JMPickedNumbers)
                        {
                            if (JMPreviousPickedNumber == JMPickedNumber)
                            {
                                JMValidChoice = false;
                            }
                        }
                        
                        // if JMValidChoice is still true then they will be asked to re-enter their choice
                        if(JMValidChoice)
                        {
                            Console.WriteLine("Please enter a valid numerical");
                            JMPickedNumber = Console.ReadLine();
                        }
                        // if it is false the ability will be added to the list
                        else
                        {
                            JMPickedNumbers.Add(JMPickedNumber);
                            JMChosenAbilities.Add(JMFilteredAbilities[Int32.Parse(JMPickedNumber)-1]);
                        }
                        JMChosenAbilitiesListLength = JMChosenAbilities.Count();
                    }
                }
        }

        //  allows 4 abilities to be picked
        else if(JMPokemonLevelInteger < 99)
        {
            Console.WriteLine("You may pick 4 abilities");
            int JMChosenAbilitiesListLength = 0;
            // makes sure they get all the choices into the list
            while(JMChosenAbilitiesListLength < 4)
            {
                Console.WriteLine("Please enter your numerical choice");
                JMPickedNumber = Console.ReadLine();

                bool JMValidChoice = true;
                while(JMValidChoice)
                {
                    // makes sure its actually a number being chosen
                    foreach(string JMNumericalChoice in JMNumericalChoices)
                    {
                        if(JMNumericalChoice == JMPickedNumber)
                        {
                            JMValidChoice = false;
                        }
                    }
                    // makes sure the number isn't being picked again
                    foreach(string JMPreviousPickedNumber in JMPickedNumbers)
                    {
                        if (JMPreviousPickedNumber == JMPickedNumber)
                        {
                            JMValidChoice = false;
                        }
                    }
                    
                    // if JMValidChoice is still true then they will be asked to re-enter their choice
                    if(JMValidChoice)
                    {
                        Console.WriteLine("Please enter a valid numerical");
                        JMPickedNumber = Console.ReadLine();
                    }
                    // if it is false the ability will be added to the list
                    else
                    {
                        JMPickedNumbers.Add(JMPickedNumber);
                        JMChosenAbilities.Add(JMFilteredAbilities[Int32.Parse(JMPickedNumber)-1]);
                    }
                    JMChosenAbilitiesListLength = JMChosenAbilities.Count();
                }
            }
        }

        // picks all abilities
        else
        {
            Console.WriteLine("All abilities will be added");
            foreach(string JMFilteredAbility in JMFilteredAbilities)
            {
                JMChosenAbilities.Add(JMFilteredAbility);
            }
        }

        return JMChosenAbilities;
    }
}