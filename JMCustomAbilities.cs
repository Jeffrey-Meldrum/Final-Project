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
    private int _i;
    private int _JMPokemonLevelInteger;
    private List<string> _JMNumericalChoices = new List<string>();
    private List<string> _JMChosenAbilities = new List<string>();
    List<string> _JMPickedNumbers = new List<string>();
    private string _JMPickedNumber;
    private bool _JMValidChoice = true;
    private int _JMChosenAbilitiesListLength = 0;


    public JMCustomAbilities()
    {

    }
    
    public override List<string> JMRandomAbilties(List<string> JMFilteredAbilities, string JMPokemonLevel)
    {
        _i = 1;
        _JMPokemonLevelInteger = Int32.Parse(JMPokemonLevel);
        Console.WriteLine("Abilities you may select from:");
        foreach(string JMFilteredAbility in JMFilteredAbilities)
        {
            Console.WriteLine($"({_i}) {JMFilteredAbility}");
            _JMNumericalChoices.Add(_i.ToString());
            _i++;
        }
        
        // determines how many they can pick
        // only allows one ability to be picked
        _JMPickedNumber = "";

        if (_JMPokemonLevelInteger < 20)
        {
            Console.WriteLine("You may pick 1 ability");
            Console.WriteLine("Enter your numerical choice:");
            _JMPickedNumber = Console.ReadLine();
            
            // makes sure they actually put in a number
            while(_JMValidChoice)
            {
                _JMValidChoice = true;
                foreach(string JMNumericalChoice in _JMNumericalChoices)
                {
                    if(JMNumericalChoice == _JMPickedNumber)
                    {
                        _JMValidChoice = false;
                    }
                }
                
                if(_JMValidChoice)
                {
                    Console.WriteLine("Please enter a valid numerical");
                    _JMPickedNumber = Console.ReadLine();
                }
            }

            // adds their choice to the custom ability list
            _JMChosenAbilities.Add(JMFilteredAbilities[Int32.Parse(_JMPickedNumber)-1]);
        }

        // only allows two abilities to be picked
        else if(_JMPokemonLevelInteger < 40)
        {
            Console.WriteLine("You may pick 2 abilities");
            // makes sure they get all the choices into the list
            while(_JMChosenAbilitiesListLength < 2)
            {
                _JMValidChoice = true;
                Console.WriteLine("Please enter your numerical choice");
                _JMPickedNumber = Console.ReadLine();

                while(_JMValidChoice)
                {
                    // makes sure its actually a number being chosen
                    foreach(string JMNumericalChoice in _JMNumericalChoices)
                    {
                        if(JMNumericalChoice == _JMPickedNumber)
                        {
                            _JMValidChoice = false;
                        }
                    }
                    // makes sure the number isn't being picked again
                    foreach(string JMPreviousPickedNumber in _JMPickedNumbers)
                    {
                        if (JMPreviousPickedNumber == _JMPickedNumber)
                        {
                            _JMValidChoice = false;
                        }
                    }
                    
                    // if JMValidChoice is still true then they will be asked to re-enter their choice
                    if(_JMValidChoice)
                    {
                        Console.WriteLine("Please enter a valid numerical");
                        _JMPickedNumber = Console.ReadLine();
                    }
                    // if it is false the ability will be added to the list
                    else
                    {
                        _JMPickedNumbers.Add(_JMPickedNumber);
                        _JMChosenAbilities.Add(JMFilteredAbilities[Int32.Parse(_JMPickedNumber)-1]);
                    }
                    _JMChosenAbilitiesListLength = _JMChosenAbilities.Count();
                }
            }
        }

        // allows three abilities to be picked
        else if(_JMPokemonLevelInteger < 60)
        {
            Console.WriteLine("You may pick 3 abilities");
            // makes sure they get all the choices into the list
            while(_JMChosenAbilitiesListLength < 3)
                {
                    _JMValidChoice = true;
                    Console.WriteLine("Please enter your numerical choice");
                    _JMPickedNumber = Console.ReadLine();

                    while(_JMValidChoice)
                    {
                        // makes sure its actually a number being chosen
                        foreach(string JMNumericalChoice in _JMNumericalChoices)
                        {
                            if(JMNumericalChoice == _JMPickedNumber)
                            {
                                _JMValidChoice = false;
                            }
                        }
                        // makes sure the number isn't being picked again
                        foreach(string JMPreviousPickedNumber in _JMPickedNumbers)
                        {
                            if (JMPreviousPickedNumber == _JMPickedNumber)
                            {
                                _JMValidChoice = false;
                            }
                        }
                        
                        // if JMValidChoice is still true then they will be asked to re-enter their choice
                        if(_JMValidChoice)
                        {
                            Console.WriteLine("Please enter a valid numerical");
                            _JMPickedNumber = Console.ReadLine();
                        }
                        // if it is false the ability will be added to the list
                        else
                        {
                            _JMPickedNumbers.Add(_JMPickedNumber);
                            _JMChosenAbilities.Add(JMFilteredAbilities[Int32.Parse(_JMPickedNumber)-1]);
                        }
                        _JMChosenAbilitiesListLength = _JMChosenAbilities.Count();
                    }
                }
        }

        //  allows 4 abilities to be picked
        else if(_JMPokemonLevelInteger < 80)
        {
            Console.WriteLine("You may pick 4 abilities");
            // makes sure they get all the choices into the list
            while(_JMChosenAbilitiesListLength < 4)
            {
                _JMValidChoice = true;
                Console.WriteLine("Please enter your numerical choice");
                _JMPickedNumber = Console.ReadLine();

                while(_JMValidChoice)
                {
                    // makes sure its actually a number being chosen
                    foreach(string JMNumericalChoice in _JMNumericalChoices)
                    {
                        if(JMNumericalChoice == _JMPickedNumber)
                        {
                            _JMValidChoice = false;
                        }
                    }
                    // makes sure the number isn't being picked again
                    foreach(string JMPreviousPickedNumber in _JMPickedNumbers)
                    {
                        if (JMPreviousPickedNumber == _JMPickedNumber)
                        {
                            _JMValidChoice = false;
                        }
                    }
                    
                    // if JMValidChoice is still true then they will be asked to re-enter their choice
                    if(_JMValidChoice)
                    {
                        Console.WriteLine("Please enter a valid numerical");
                        _JMPickedNumber = Console.ReadLine();
                    }
                    // if it is false the ability will be added to the list
                    else
                    {
                        _JMPickedNumbers.Add(_JMPickedNumber);
                        _JMChosenAbilities.Add(JMFilteredAbilities[Int32.Parse(_JMPickedNumber)-1]);
                    }
                    _JMChosenAbilitiesListLength = _JMChosenAbilities.Count();
                }
            }
        }

        // picks all abilities
        else
        {
            Console.WriteLine("All abilities will be added");
            foreach(string JMFilteredAbility in JMFilteredAbilities)
            {
                _JMChosenAbilities.Add(JMFilteredAbility);
            }
        }

        return _JMChosenAbilities;
    }
}