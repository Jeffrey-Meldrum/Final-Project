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
    public JMParentMoves()
    {

    }

    // Picks a random set of six moves based on level
    public List<string> JMRFilteredMoves(List<string> JMPokemonMoves, string JMPokemonLevel)
    {
        // creates a reference list of the move levels
        List<string> JMPokemonMoveLevels = new List<string>();
        char[] JMTrimCharacters = {' ', '\t'};
        foreach(string JMPokemonMove in JMPokemonMoves)
        {
            string[] JMMoveSplit = JMPokemonMove.Split(" ");
            JMPokemonMoveLevels.Add(JMMoveSplit[0].Trim(JMTrimCharacters));
        }

        // filters out the moves that are to high level
        List<string> JMPokemonMoveLevelsFiltered = new List<string>();
        int JMPokemonLevelInteger = Int32.Parse(JMPokemonLevel);
        foreach(string JMPokemonMoveLevel in JMPokemonMoveLevels)
        {
            int JMMoveLevelInteger = Int32.Parse(JMPokemonMoveLevel);
            if (JMMoveLevelInteger <= JMPokemonLevelInteger)
            {
                JMPokemonMoveLevelsFiltered.Add(JMPokemonMoveLevel);
            }
        }

        // gets the filtered version of the actual move list
        List<string> JMPokemonMovesFiltered = new List<string>();
        int i = 0;
        foreach (string JMMoveLevelFiltered in JMPokemonMoveLevelsFiltered)
        {
            JMPokemonMovesFiltered.Add(JMPokemonMoves[i]);
            i++;
        }

        // returns the filtered moves
        return JMPokemonMovesFiltered;
    }

    public virtual List<string> JMRandomMoves(List<string> JMPokemonMovesFiltered)
    {
        // counts how long the list is, is it is longer then 6 it will randomize what moves to add otherwise they are all added.
        int JMPokemonMoveListLength = JMPokemonMovesFiltered.Count();
        List<string> JMChosenMoves = new List<string>();
        if (JMPokemonMoveListLength < 6)
        {
            foreach (string JMPokemonMove in JMPokemonMovesFiltered)
            {
                JMChosenMoves.Add(JMPokemonMove);
            }
        }
        
        // if the lsit is longer then 6 it will randomize what moves will be added
        else
        {
            Random JMRandmoizer = new Random();
            
            // adds the first index to a list so there is something in it at the start of the while loop
            List<int> JMChosenMovesIndex = new List<int>();
            int JMRandomFirstMoveIndex = JMRandmoizer.Next(0,JMPokemonMoveListLength-1);
            JMChosenMovesIndex.Add(JMRandomFirstMoveIndex);
            int JMLoopBreaker = JMChosenMovesIndex.Count();

            while (JMLoopBreaker < 6)
            {
                // checks to make sure the next random index isnt already in the list
                bool JMAddMoveLogic = true;
                int JMRandomMoveIndex = JMRandmoizer.Next(0,JMPokemonMoveListLength-1);

                // Console.WriteLine($"{JMPokemonMovesFiltered[JMRandomMoveIndex]}");

                foreach (int JMChosenMoveIndex in JMChosenMovesIndex)
                {
                    // if the move index matches it is set to false
                    if (JMChosenMoveIndex == JMRandomMoveIndex)
                    {
                        JMAddMoveLogic = false;
                    }
                }

                // if JMAddMoveLogic stays true then it adds the random move index to the list
                if (JMAddMoveLogic)
                {
                    JMChosenMovesIndex.Add(JMRandomMoveIndex);
                }
                JMLoopBreaker = JMChosenMovesIndex.Count();
            }

            // adds the moves based on the index values
            foreach(int JMChosenMoveIndex in JMChosenMovesIndex)
            {
                JMChosenMoves.Add(JMPokemonMovesFiltered[JMChosenMoveIndex]);
            }
        }

        return JMChosenMoves;
    }
}