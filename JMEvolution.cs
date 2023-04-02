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

public class JMPokemonEvolution
{
    public JMPokemonEvolution()
    {

    }

    public string JMRandomEvolution(List<string> JMPokemonEvolutions, string JMChosenLevel)
    {
        List<List<string>> JMAllEvolutions = new List<List<string>>();
        char[] JMTrimCharacters = {' ','\t'};
        int JMChosenLevelInteger = Int32.Parse(JMChosenLevel);
        
        // makes a list of the evolutions in a more readable formate
        foreach (string JMEvolution in JMPokemonEvolutions)
        {
            List<string> JMEvolutionSplitList = new List<string>();
            string[] JMEvolutionSplit = JMEvolution.Split("-");
            // trims then adds stage
            string JMStageTrim = JMEvolutionSplit[0].Trim(JMTrimCharacters);
            JMEvolutionSplitList.Add(JMStageTrim);
            string[] JMNameAndLevelSplit = JMEvolutionSplit[1].Split("minimum");
            // trims then adds evolution
            string JMEvolutionTrim = JMNameAndLevelSplit[0].Trim(JMTrimCharacters);
            JMEvolutionSplitList.Add(JMEvolutionTrim);
            // trims then adds level if there is a level to add
            if (JMNameAndLevelSplit.Count() == 2)
            {
                string JMLevelTrim = JMNameAndLevelSplit[1].Trim(JMTrimCharacters);
                JMEvolutionSplitList.Add(JMLevelTrim);
            }

            Console.WriteLine($"The Name is {JMEvolutionTrim}");
            // master list of evolutions
            JMAllEvolutions.Add(JMEvolutionSplitList);
        }

        // removes evolutions from the list if they are to high
        List<List<string>> JMFilteredEvolutions = new List<List<string>>();
        foreach (List<string> JMSplitEvolution in JMAllEvolutions)
        {
            if (JMSplitEvolution.Count() == 3)
            {
                int JMLevelInteger = Int32.Parse(JMSplitEvolution[2]);
                // if the level of the stage is higher than the parameter it is deleted from the list
                if (JMLevelInteger < JMChosenLevelInteger)
                {
                    JMFilteredEvolutions.Add(JMSplitEvolution);
                }
            }
            // passes stage 1 into the filtered list
            else
            {
                JMFilteredEvolutions.Add(JMSplitEvolution);
            }
        }

        // a loop to determine what stage the pokemon will be
        string PokemonStage = "1";
        int JMRandomChanceNumber = 0;
        foreach (List<string> JMSplitEvolution in JMFilteredEvolutions)
        {
            // if selection can be stage 2 gives it a high chance of being stage 2
            if (JMSplitEvolution[0] == "2")
            {
                Random JMRandomNumber = new Random();
                JMRandomChanceNumber = JMRandomNumber.Next(0,100);
                if (JMRandomChanceNumber >= 30)
                {
                    PokemonStage = "2";
                }
                else
                {
                    PokemonStage ="1";
                }
            }

            // if pokemon can be stage 3 it has a high chance of being a stage 3
            else if (JMSplitEvolution[0] == "3")
            {
                Random JMRandomNumber = new Random();
                JMRandomChanceNumber = JMRandomNumber.Next(0,100);
                if (JMRandomChanceNumber > 10 && JMRandomChanceNumber < 30)
                {
                    PokemonStage = "2";
                }
                else if (JMRandomChanceNumber >= 30)
                {
                    PokemonStage = "3";
                }
                else
                {
                    PokemonStage ="1";
                }
            }
        }
        Console.WriteLine($"The stage is {PokemonStage}");
        Console.WriteLine($"The Pokemon is {JMFilteredEvolutions[0][1]}");

        // finds all pokemon of the proper stage and adds them to a list
        List<List<string>> JMEvolutionChoicePool = new List<List<string>>();
        if (JMFilteredEvolutions.Count() > 1)
        {
            foreach (List<string> JMSplitEvolution in JMFilteredEvolutions)
            {
                if (JMSplitEvolution[0] == PokemonStage)
                {
                    JMEvolutionChoicePool.Add(JMSplitEvolution);
                }
            }
        }
        else
        {
            JMEvolutionChoicePool.Add(JMFilteredEvolutions[0]);
        }
        Console.WriteLine($"{JMEvolutionChoicePool[0][0]}");

        string JMChosenPokemonName = "";
        if(JMEvolutionChoicePool.Count() > 1)
        {
        Random JMNewRandomNumber = new Random();
        int JMListLength = JMEvolutionChoicePool.Count()-1;
        JMRandomChanceNumber = JMNewRandomNumber.Next(0,JMListLength);
        JMChosenPokemonName = JMEvolutionChoicePool[JMRandomChanceNumber][1];
        }
        else
        {
            JMChosenPokemonName = JMEvolutionChoicePool[0][1];
        }

    return JMChosenPokemonName;
    }
}