/*
Author: Jeffrey Meldrum

Date: 03/23/2023

Description: 
Responsibilities: 


Attributes:


Behaviors:

*/

using System;
using System.IO;
using System.Collections.Generic;

public class JMCustomMoves : JMParentMoves
{
    public override List<string> JMRandomMoves(List<string> JMPokemonMovesFiltered)
    {
        Console.WriteLine("Here is the list of Moves you can select from");
        int i = 1;
        List<string> JMNumericalChoices = new List<string>();
        List<string> JMChosenMoves = new List<string>();

        // write out the moves the user can pick from
        foreach(string JMPokemoneMoveFiltered in JMPokemonMovesFiltered)
        {
            Console.WriteLine($"({1}) {JMPokemoneMoveFiltered}");
            JMNumericalChoices.Add(i.ToString());
            i++;
        }

        // if there are less then or equal to 6 moves it will add them all
        if(JMPokemonMovesFiltered.Count() <= 6)
        {
            Console.WriteLine("Since there are less then 6 avaialble moves all will be added");
            foreach(string JMPokemoneMoveFiltered in JMPokemonMovesFiltered)
            {
                JMChosenMoves.Add(JMPokemoneMoveFiltered);
            }
        }
        // if there are more than 6 moves the player will get to chose 
        else
        {
            string JMPickedNumerical = "";
            int JMChosenMovesListLength = 0;
            List<string> JMPickedNumericals = new List<string>();

            Console.WriteLine("You may make 6 selections");
            // loop will keep going if there are not 6 selections
            while(JMChosenMovesListLength < 6)
            {
                bool JMValidChoice = true;
                while(JMValidChoice)
                {
                    Console.WriteLine("Please enter the numerical of your selection");
                    JMPickedNumerical = Console.ReadLine();
                    // makes sure the number is in thbe list of options
                    foreach (string JMNumericalChoice in JMNumericalChoices)
                    {
                        if (JMNumericalChoice == JMPickedNumerical)
                        {
                            JMValidChoice = false;
                        }
                    }
                        
                    // makes sure the option hasn't already been picked
                    foreach (string JMPreviousPickedNumerical in JMPickedNumericals)
                    {
                        if(JMPreviousPickedNumerical == JMPickedNumerical)
                        {
                            JMValidChoice = true;
                        }
                    }

                    // if valid choice is still true that means they put in an invalid selection
                    if(JMValidChoice)
                    {
                        Console.WriteLine("Please enter a valid numerical");
                        JMPickedNumerical = Console.ReadLine();
                    }
                    else
                    {
                        JMPickedNumericals.Add(JMPickedNumerical);
                        JMChosenMoves.Add(JMPokemonMovesFiltered[Int32.Parse(JMPickedNumerical)-1]);
                    }
                }
                JMChosenMovesListLength = JMChosenMoves.Count();
            }
            
        }
        return JMChosenMoves;
    }
}