/*
Author: Jeffrey Meldrum

Date: 04/05/2023

Description: A child class of parent moves that allows the user to pick the pokemons moves
Responsibilities: take the filtered move list and input level and give the user options of what moves they want

*/

using System;
using System.IO;
using System.Collections.Generic;

public class JMCustomMoves : JMParentMoves
{
    private int _i;
    private List<string> _JMNumericalChoices = new List<string>();
    private List<string> _JMChosenMoves = new List<string>();
    private string _JMPickedNumerical;
    private int _JMChosenMovesListLength;
    private List<string> _JMPickedNumericals = new List<string>();
    private bool _JMValidChoice;

    public JMCustomMoves()
    {
        
    }

    public override List<string> JMRandomMoves(List<string> JMPokemonMovesFiltered)
    {
        Console.WriteLine("Here is the list of Moves you can select from");
        _i = 1;

        // write out the moves the user can pick from
        foreach(string JMPokemoneMoveFiltered in JMPokemonMovesFiltered)
        {
            Console.WriteLine($"({_i}) {JMPokemoneMoveFiltered}");
            _JMNumericalChoices.Add(_i.ToString());
            _i++;
        }

        // if there are less then or equal to 6 moves it will add them all
        if(JMPokemonMovesFiltered.Count() < 6)
        {
            Console.WriteLine("Since there are less then 6 avaialble moves all will be added");
            foreach(string JMPokemoneMoveFiltered in JMPokemonMovesFiltered)
            {
                _JMChosenMoves.Add(JMPokemoneMoveFiltered);
            }
        }
        // if there are more than 6 moves the player will get to chose 
        else
        {
            _JMPickedNumerical = "";
            _JMChosenMovesListLength = 0;

            Console.WriteLine("You may make 6 selections");
            // loop will keep going if there are not 6 selections
            while(_JMChosenMovesListLength < 6)
            {
                _JMValidChoice = true;
                while(_JMValidChoice)
                {
                    Console.WriteLine("Please enter the numerical of your selection");
                    _JMPickedNumerical = Console.ReadLine();
                    // makes sure the number is in thbe list of options
                    foreach (string JMNumericalChoice in _JMNumericalChoices)
                    {
                        if (JMNumericalChoice == _JMPickedNumerical)
                        {
                            _JMValidChoice = false;
                        }
                    }
                        
                    // makes sure the option hasn't already been picked
                    foreach (string JMPreviousPickedNumerical in _JMPickedNumericals)
                    {
                        if(JMPreviousPickedNumerical == _JMPickedNumerical)
                        {
                            _JMValidChoice = true;
                        }
                    }

                    // if valid choice is still true that means they put in an invalid selection
                    if(_JMValidChoice)
                    {
                        Console.WriteLine("Please enter a valid numerical");
                        _JMPickedNumerical = Console.ReadLine();
                    }
                    else
                    {
                        _JMPickedNumericals.Add(_JMPickedNumerical);
                        _JMChosenMoves.Add(JMPokemonMovesFiltered[Int32.Parse(_JMPickedNumerical)-1]);
                    }
                }
                _JMChosenMovesListLength = _JMChosenMoves.Count();
            }
            
        }
        return _JMChosenMoves;
    }
}