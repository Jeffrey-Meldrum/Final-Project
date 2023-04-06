/*
Author: Jeffrey Meldrum

Date: 03/23/2023

Description: This class is used with the habitat class. It determines wether or not the pokemon is the apporpriate evolution stage
if it has multiple stages it takes into account what level the pokemon is and uses that to make a decision. The stages re weighted meaning
if a pokemon is level 35 and evolves at 30 it is more likely to be that evolution. However, it has a small chance of not being evolved
Responsibilities: take the evoltuion string from the pokemon data and the input level to determine what evolution the pokemon should be

*/

using System;
using System.IO;
using System.Collections.Generic;

public class JMEvolution
{
    private List<List<string>> _JMAllEvolutions = new List<List<string>>();
    private char[] _JMTrimCharacters = {' ','\t'};
    private int _JMChosenLevelInteger;
    private string _JMStageTrim;
    private List<List<string>> _JMFilteredEvolutions = new List<List<string>>();
    private  string _JMEvolutionTrim;
    private List<string> _JMEvolutionSplitList = new List<string>();
    private string _JMLevelTrim;
    private int _JMLevelInteger;
    private string _PokemonStage;
    private int _JMRandomChanceNumber;
    private Random _JMRandomNumber = new Random();
    private  List<List<string>> _JMEvolutionChoicePool = new List<List<string>>();
    private string _JMChosenPokemonName;
    private int _JMListLength;
    
    public JMEvolution()
    {

    }

    public string JMRandomEvolution(List<string> JMPokemonEvolutions, string JMChosenLevel)
    {
        _JMChosenLevelInteger = Int32.Parse(JMChosenLevel);
        
        // makes a list of the evolutions in a more readable formate
        foreach (string JMPokemonEvolution in JMPokemonEvolutions)
        {
            _JMEvolutionSplitList = new List<string>();
            string[] JMEvolutionSplit = JMPokemonEvolution.Split("-");
            // trims then adds stage
            _JMStageTrim = JMEvolutionSplit[0].Trim(_JMTrimCharacters);
            _JMEvolutionSplitList.Add(_JMStageTrim);
            string[] JMNameAndLevelSplit = JMEvolutionSplit[1].Split("minimum");
            // trims then adds evolution
            _JMEvolutionTrim = JMNameAndLevelSplit[0].Trim(_JMTrimCharacters);
            _JMEvolutionSplitList.Add(_JMEvolutionTrim);
            // trims then adds level if there is a level to add
            if (JMNameAndLevelSplit.Count() == 2)
            {
                _JMLevelTrim = JMNameAndLevelSplit[1].Trim(_JMTrimCharacters);
                _JMEvolutionSplitList.Add(_JMLevelTrim);
            }

            // Console.WriteLine($"The Name is {JMEvolutionTrim}");
            // master list of evolutions
            _JMAllEvolutions.Add(_JMEvolutionSplitList);
        }

        // removes evolutions from the list if they are to high
        foreach (List<string> JMSplitEvolution in _JMAllEvolutions)
        {
            if (JMSplitEvolution.Count() == 3)
            {
                _JMLevelInteger = Int32.Parse(JMSplitEvolution[2]);
                // if the level of the stage is higher than the parameter it is deleted from the list
                if (_JMLevelInteger < _JMChosenLevelInteger)
                {
                    _JMFilteredEvolutions.Add(JMSplitEvolution);
                }
            }
            // passes stage 1 into the filtered list
            else
            {
                _JMFilteredEvolutions.Add(JMSplitEvolution);
            }
        }

        // a loop to determine what stage the pokemon will be
        _PokemonStage = "1";
        _JMRandomChanceNumber = 0;
        foreach (List<string> JMSplitEvolution in _JMFilteredEvolutions)
        {
            // if selection can be stage 2 gives it a high chance of being stage 2
            if (JMSplitEvolution[0] == "2")
            {
                _JMRandomChanceNumber = _JMRandomNumber.Next(0,100);
                if (_JMRandomChanceNumber >= 30)
                {
                    _PokemonStage = "2";
                }
                else
                {
                    _PokemonStage ="1";
                }
            }

            // if pokemon can be stage 3 it has a high chance of being a stage 3
            else if (JMSplitEvolution[0] == "3")
            {
                _JMRandomChanceNumber = _JMRandomNumber.Next(0,100);
                if (_JMRandomChanceNumber > 10 && _JMRandomChanceNumber < 30)
                {
                    _PokemonStage = "2";
                }
                else if (_JMRandomChanceNumber >= 30)
                {
                    _PokemonStage = "3";
                }
                else
                {
                    _PokemonStage ="1";
                }
            }
        }
        // Console.WriteLine($"The stage is {PokemonStage}");
        // Console.WriteLine($"The Pokemon is {JMFilteredEvolutions[0][1]}");

        // finds all pokemon of the proper stage and adds them to a list
        if (_JMFilteredEvolutions.Count() > 1)
        {
            foreach (List<string> JMSplitEvolution in _JMFilteredEvolutions)
            {
                if (JMSplitEvolution[0] == _PokemonStage)
                {
                    _JMEvolutionChoicePool.Add(JMSplitEvolution);
                }
            }
        }
        else
        {
            _JMEvolutionChoicePool.Add(_JMFilteredEvolutions[0]);
        }
        // Console.WriteLine($"{JMEvolutionChoicePool[0][0]}");

        _JMChosenPokemonName = "";
        if(_JMEvolutionChoicePool.Count() > 1)
        {
        _JMListLength = _JMEvolutionChoicePool.Count()-1;
        _JMRandomChanceNumber = _JMRandomNumber.Next(0,_JMListLength);
        _JMChosenPokemonName = _JMEvolutionChoicePool[_JMRandomChanceNumber][1];
        }
        else
        {
            _JMChosenPokemonName = _JMEvolutionChoicePool[0][1];
        }

    return _JMChosenPokemonName;
    }
}