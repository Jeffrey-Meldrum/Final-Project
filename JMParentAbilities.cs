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

public class JMParentAbilities
{
    public JMParentAbilities()
    {

    }

    public List<string> JMAbiltiesFilter(List<string> JMUnfilteredAbilities, string JMPokemonLevel)
    {
        // filters pokemon out by level
        int JMPokemonLevelInteger = Int32.Parse(JMPokemonLevel);
        List<string> JMFilteredAbilitites = new List<string>();

        foreach(string JMUnfilteredAbility in JMUnfilteredAbilities)
        {
            string[] JMSplitAbility = JMUnfilteredAbility.Split(" ");
            // if the level is less then 20 only allows basic abilities to be added
            if (JMPokemonLevelInteger < 20)
            {
                if(JMSplitAbility[0] == "basic")
                {
                    JMFilteredAbilitites.Add(JMUnfilteredAbility);
                }
            }
            // if the level is less then 40 only allows basic and adv abilities
            else if (JMPokemonLevelInteger < 40)
            {
                if(JMSplitAbility[0] == "basic" || JMSplitAbility[0] == "adv")
                {
                    JMFilteredAbilitites.Add(JMUnfilteredAbility);
                }
            }
            // if the level is higher then 40 it adds all abilites
            else
            {
                JMFilteredAbilitites.Add(JMUnfilteredAbility);
            }
        }

        return JMFilteredAbilitites;
    }

    public virtual List<string> JMRandomAbilties(List<string> JMFilteredAbilitites, string JMPokemonLevel)
    {
        int JMPokemonLevelInteger = Int32.Parse(JMPokemonLevel);
        int JMFilteredListLength = JMFilteredAbilitites.Count();
        List<int> JMRandomAbilityIndexes = new List<int>();
        List<string> JMRandomAbilities = new List<string>();
        int JMRandomAbilitiesListLength = JMRandomAbilities.Count();
        Random JMRandmoizer = new Random();
        int i = 0;
        // Console.WriteLine($"{JMFilteredListLength}");

        // if pokemon is less then level 20 it will only have one ability
        if(JMPokemonLevelInteger < 20)
        {
            if(JMFilteredListLength > 1)
            {         
                JMRandomAbilities.Add(JMFilteredAbilitites[JMRandmoizer.Next(0,JMFilteredListLength-1)]);
            }
            else
            {
                JMRandomAbilities.Add(JMFilteredAbilitites[0]);
            }
        }

        // if pokemon is less the level 40 it only picks two abilities
        else if(JMPokemonLevelInteger < 40)
        {
            while(JMRandomAbilitiesListLength < 2)
            {
                bool JMAddAbilityLogic = true;
                int JMRandomIndex = JMRandmoizer.Next(0,JMFilteredListLength-1);
                foreach(int JMRandomAbilityIndex in JMRandomAbilityIndexes)
                {
                    if(JMRandomAbilityIndex == JMRandomIndex)
                    {
                        JMAddAbilityLogic = false;
                    }
                }
                // if the index isn't alread in the list it is added to the random ability index list
                if(JMAddAbilityLogic)
                {
                    JMRandomAbilityIndexes.Add(JMRandomIndex);
                }
                JMRandomAbilitiesListLength = JMRandomAbilityIndexes.Count();
            }

            // using the saved indexes saves the abilites to the random ability list
            foreach(int JMIndex in JMRandomAbilityIndexes)
            {
                JMRandomAbilities.Add(JMFilteredAbilitites[JMIndex]);
            }
        }

        // if pokemon is less then level 60 it only picks three abilities
        else if(JMPokemonLevelInteger < 60)
        {
            while(JMRandomAbilitiesListLength < 3)
            {
                bool JMAddAbilityLogic = true;
                int JMRandomIndex = JMRandmoizer.Next(0,JMFilteredListLength-1);
                foreach(int JMRandomAbilityIndex in JMRandomAbilityIndexes)
                {
                    if(JMRandomAbilityIndex == JMRandomIndex)
                    {
                        JMAddAbilityLogic = false;
                    }
                }
                // if the index isn't alread in the list it is added to the random ability index list
                if(JMAddAbilityLogic)
                {
                    JMRandomAbilityIndexes.Add(JMRandomIndex);
                }
                JMRandomAbilitiesListLength = JMRandomAbilityIndexes.Count();
            }

            // using the saved indexes saves the abilites to the random ability list
            foreach(int JMIndex in JMRandomAbilityIndexes)
            {
                JMRandomAbilities.Add(JMFilteredAbilitites[JMIndex]);
            }
        }

        // if pokemon is less then level 80 it only picks four abilities
        else if(JMPokemonLevelInteger < 100)
        {
            while(JMRandomAbilitiesListLength < 4)
            {
                bool JMAddAbilityLogic = true;
                int JMRandomIndex = JMRandmoizer.Next(0,JMFilteredListLength-1);
                foreach(int JMRandomAbilityIndex in JMRandomAbilityIndexes)
                {
                    if(JMRandomAbilityIndex == JMRandomIndex)
                    {
                        JMAddAbilityLogic = false;
                    }
                }
                // if the index isn't alread in the list it is added to the random ability index list
                if(JMAddAbilityLogic)
                {
                    JMRandomAbilityIndexes.Add(JMRandomIndex);
                }
                JMRandomAbilitiesListLength = JMRandomAbilityIndexes.Count();
            }

            // using the saved indexes saves the abilites to the random ability list
            foreach(int JMIndex in JMRandomAbilityIndexes)
            {
                JMRandomAbilities.Add(JMFilteredAbilitites[JMIndex]);
            }
        }

        // if pokemon is level 100 it will have all available abilities
        else if(JMPokemonLevelInteger == 100)
        {
            while(JMRandomAbilitiesListLength < 5)
            {
                foreach(string JMAbility in JMFilteredAbilitites)
                {
                    JMRandomAbilities.Add(JMAbility);
                }
                JMRandomAbilitiesListLength = JMRandomAbilities.Count();
            }
        }

        return JMRandomAbilities;
    }
}