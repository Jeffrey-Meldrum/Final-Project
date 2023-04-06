/*
Author: Jeffrey Meldrum

Date: 03/23/2023

Description: This classes job is to filter out what abilitie the pokemon can have at a given level then randomly selected a number of them
based on that level.
Responsibilities: Takes in the unfiltered abilities list from the pokemon data and what level it is. Then it filters out te ones that
can be known at that level, then it sends those to be randomly picked and returns that as a list.


*/

using System;
using System.IO;
using System.Collections.Generic;

public class JMParentAbilities
{
    private int _JMPokemonLevelInteger;
    private List<string> _JMFilteredAbilitites = new List<string>();

    private int _JMFilteredListLength;
    private List<int> _JMRandomAbilityIndexes = new List<int>();
    private List<string> _JMRandomAbilities = new List<string>();
    private int _JMRandomAbilitiesListLength;
    private  Random _JMRandmoizer = new Random();
    private bool _JMAddAbilityLogic;
    private int _JMRandomIndex;

    public JMParentAbilities()
    {

    }

    public List<string> JMAbiltiesFilter(List<string> JMUnfilteredAbilities, string JMPokemonLevel)
    {
        // filters pokemon out by level
        _JMPokemonLevelInteger = Int32.Parse(JMPokemonLevel);
        
        foreach(string JMUnfilteredAbility in JMUnfilteredAbilities)
        {
            string[] JMSplitAbility = JMUnfilteredAbility.Split(" ");
            // if the level is less then 20 only allows basic abilities to be added
            if (_JMPokemonLevelInteger < 20)
            {
                if(JMSplitAbility[0] == "basic")
                {
                    _JMFilteredAbilitites.Add(JMUnfilteredAbility);
                }
            }
            // if the level is less then 40 only allows basic and adv abilities
            else if (_JMPokemonLevelInteger < 40)
            {
                if(JMSplitAbility[0] == "basic" || JMSplitAbility[0] == "adv")
                {
                    _JMFilteredAbilitites.Add(JMUnfilteredAbility);
                }
            }
            // if the level is higher then 40 it adds all abilites
            else
            {
                _JMFilteredAbilitites.Add(JMUnfilteredAbility);
            }
        }

        return _JMFilteredAbilitites;
    }

    public virtual List<string> JMRandomAbilties(List<string> JMFilteredAbilitites, string JMPokemonLevel)
    {
        _JMPokemonLevelInteger = Int32.Parse(JMPokemonLevel);
        _JMFilteredListLength = JMFilteredAbilitites.Count();
        _JMRandomAbilitiesListLength = _JMRandomAbilities.Count();
        // Console.WriteLine($"{JMFilteredListLength}");

        // if pokemon is less then level 20 it will only have one ability
        if(_JMPokemonLevelInteger < 20)
        {
            if(_JMFilteredListLength > 1)
            {         
                _JMRandomAbilities.Add(JMFilteredAbilitites[_JMRandmoizer.Next(0,_JMFilteredListLength-1)]);
            }
            else
            {
                _JMRandomAbilities.Add(JMFilteredAbilitites[0]);
            }
        }

        // if pokemon is less the level 40 it only picks two abilities
        else if(_JMPokemonLevelInteger < 40)
        {
            while(_JMRandomAbilitiesListLength < 2)
            {
                _JMAddAbilityLogic = true;
                _JMRandomIndex = _JMRandmoizer.Next(0,_JMFilteredListLength-1);
                foreach(int JMRandomAbilityIndex in _JMRandomAbilityIndexes)
                {
                    if(JMRandomAbilityIndex == _JMRandomIndex)
                    {
                        _JMAddAbilityLogic = false;
                    }
                }
                // if the index isn't alread in the list it is added to the random ability index list
                if(_JMAddAbilityLogic)
                {
                    _JMRandomAbilityIndexes.Add(_JMRandomIndex);
                }
                _JMRandomAbilitiesListLength = _JMRandomAbilityIndexes.Count();
            }

            // using the saved indexes saves the abilites to the random ability list
            foreach(int JMIndex in _JMRandomAbilityIndexes)
            {
                _JMRandomAbilities.Add(JMFilteredAbilitites[JMIndex]);
            }
        }

        // if pokemon is less then level 60 it only picks three abilities
        else if(_JMPokemonLevelInteger < 60)
        {
            while(_JMRandomAbilitiesListLength < 3)
            {
                _JMAddAbilityLogic = true;
                _JMRandomIndex = _JMRandmoizer.Next(0,_JMFilteredListLength-1);
                foreach(int JMRandomAbilityIndex in _JMRandomAbilityIndexes)
                {
                    if(JMRandomAbilityIndex == _JMRandomIndex)
                    {
                        _JMAddAbilityLogic = false;
                    }
                }
                // if the index isn't alread in the list it is added to the random ability index list
                if(_JMAddAbilityLogic)
                {
                    _JMRandomAbilityIndexes.Add(_JMRandomIndex);
                }
                _JMRandomAbilitiesListLength = _JMRandomAbilityIndexes.Count();
            }

            // using the saved indexes saves the abilites to the random ability list
            foreach(int JMIndex in _JMRandomAbilityIndexes)
            {
                _JMRandomAbilities.Add(JMFilteredAbilitites[JMIndex]);
            }
        }

        // if pokemon is less then level 80 it only picks four abilities
        else if(_JMPokemonLevelInteger < 80)
        {
            while(_JMRandomAbilitiesListLength < 4)
            {
                _JMAddAbilityLogic = true;
                _JMRandomIndex = _JMRandmoizer.Next(0,_JMFilteredListLength-1);
                foreach(int JMRandomAbilityIndex in _JMRandomAbilityIndexes)
                {
                    if(JMRandomAbilityIndex == _JMRandomIndex)
                    {
                        _JMAddAbilityLogic = false;
                    }
                }
                // if the index isn't alread in the list it is added to the random ability index list
                if(_JMAddAbilityLogic)
                {
                    _JMRandomAbilityIndexes.Add(_JMRandomIndex);
                }
                _JMRandomAbilitiesListLength = _JMRandomAbilityIndexes.Count();
            }

            // using the saved indexes saves the abilites to the random ability list
            foreach(int JMIndex in _JMRandomAbilityIndexes)
            {
                _JMRandomAbilities.Add(JMFilteredAbilitites[JMIndex]);
            }
        }

        // if pokemon is level 100 it will have all available abilities
        else
        {
                foreach(string JMAbility in JMFilteredAbilitites)
                {
                    _JMRandomAbilities.Add(JMAbility);
                }
        }

        return _JMRandomAbilities;
    }
}