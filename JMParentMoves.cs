/*
Author: Jeffrey Meldrum

Date: 03/23/2023

Description: This class is used to chose what moves the pokemon will know and randomly picks 6 of them.
Responsibilities: takes in the level the user input and the list of moves and filterse them based on the level. Then it send them to be
randomized and afterwards will return them as a list for the program.

*/

using System;
using System.IO;
using System.Collections.Generic;

public class JMParentMoves
{
    private List<string> _JMPokemonMoveLevels;
    private char[] _JMTrimCharacters = {' ', '\t'};
    private List<string> _JMPokemonMoveLevelsFiltered = new List<string>();
    private int _i;
    private int _JMPokemonLevelInteger;
    private int _JMMoveLevelInteger;
    private List<string> _JMPokemonMovesFiltered = new List<string>();

    private Random _JMRandmoizer = new Random();
    private int _JMPokemonMoveListLength;
    private List<string> _JMChosenMoves = new List<string>();
    private List<int> _JMChosenMovesIndex = new List<int>();
    private int _JMRandomFirstMoveIndex;
    private int _JMLoopBreaker;
    private bool _JMAddMoveLogic;
    private int _JMRandomMoveIndex;



    public JMParentMoves()
    {

    }

    // Picks a random set of six moves based on level
    public List<string> JMRFilteredMoves(List<string> JMPokemonMoves, string JMPokemonLevel)
    {
        // creates a reference list of the move levels
        _JMPokemonMoveLevels = new List<string>();
        foreach(string JMPokemonMove in JMPokemonMoves)
        {
            string[] JMMoveSplit = JMPokemonMove.Split(" ");
            _JMPokemonMoveLevels.Add(JMMoveSplit[0].Trim(_JMTrimCharacters));
        }

        // filters out the moves that are to high level
        _JMPokemonLevelInteger = Int32.Parse(JMPokemonLevel);
        foreach(string JMPokemonMoveLevel in _JMPokemonMoveLevels)
        {
            _JMMoveLevelInteger = Int32.Parse(JMPokemonMoveLevel);
            if (_JMMoveLevelInteger <= _JMPokemonLevelInteger)
            {
                _JMPokemonMoveLevelsFiltered.Add(JMPokemonMoveLevel);
            }
        }

        // gets the filtered version of the actual move list
        _i = 0;
        foreach (string JMMoveLevelFiltered in _JMPokemonMoveLevelsFiltered)
        {
            _JMPokemonMovesFiltered.Add(JMPokemonMoves[_i]);
            _i++;
        }

        // returns the filtered moves
        return _JMPokemonMovesFiltered;
    }

    public virtual List<string> JMRandomMoves(List<string> JMPokemonMovesFiltered)
    {
        // counts how long the list is, is it is longer then 6 it will randomize what moves to add otherwise they are all added.
        _JMPokemonMoveListLength = JMPokemonMovesFiltered.Count();
        if (_JMPokemonMoveListLength < 6)
        {
            foreach (string JMPokemonMove in JMPokemonMovesFiltered)
            {
                _JMChosenMoves.Add(JMPokemonMove);
            }
        }
        
        // if the lsit is longer then 6 it will randomize what moves will be added
        else
        {
            
            // adds the first index to a list so there is something in it at the start of the while loop
            _JMRandomFirstMoveIndex = _JMRandmoizer.Next(0,_JMPokemonMoveListLength-1);
            _JMChosenMovesIndex.Add(_JMRandomFirstMoveIndex);
            _JMLoopBreaker = _JMChosenMovesIndex.Count();

            while (_JMLoopBreaker < 6)
            {
                // checks to make sure the next random index isnt already in the list
                _JMAddMoveLogic = true;
                _JMRandomMoveIndex = _JMRandmoizer.Next(0,_JMPokemonMoveListLength-1);

                // Console.WriteLine($"{JMPokemonMovesFiltered[JMRandomMoveIndex]}");

                foreach (int JMChosenMoveIndex in _JMChosenMovesIndex)
                {
                    // if the move index matches it is set to false
                    if (JMChosenMoveIndex == _JMRandomMoveIndex)
                    {
                        _JMAddMoveLogic = false;
                    }
                }

                // if JMAddMoveLogic stays true then it adds the random move index to the list
                if (_JMAddMoveLogic)
                {
                    _JMChosenMovesIndex.Add(_JMRandomMoveIndex);
                }
                _JMLoopBreaker = _JMChosenMovesIndex.Count();
            }

            // adds the moves based on the index values
            foreach(int JMChosenMoveIndex in _JMChosenMovesIndex)
            {
                _JMChosenMoves.Add(JMPokemonMovesFiltered[JMChosenMoveIndex]);
            }
        }

        return _JMChosenMoves;
    }
}