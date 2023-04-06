/*
Author: Jeffrey Meldrum

Date: 04/05/2023

Description: child of the parent natures class this provides the user with all 36 nature options for their own choosing
Responsibilities: getsuser input on what nature they want an returns it as a string


*/

using System;
using System.IO;
using System.Collections.Generic;

public class JMCustomNatures : JMParentNatures
{
    private List<string> _JMNumericalChoices = new List<string>();
    private int _i;
    private string[] _JMNaturesList = {"cuddly","distracted","proud","decisive","patient","desperate","lonely","adamant","naughty","brave",
        "stark","bold","impish","lax","relaxed","curious","modest","mild","rash","quiet","dreamy","calm","gentle","careful","sassy","skittish",
        "timid","hasty","jolly","naive","composed","hardy","docile","bashful","quirky","serious"};
    private string _JMPickedNumber;
    private bool _JMValidChoice;

    public JMCustomNatures()
    {
        
    }

    public override string JMRandomNature()
    {
        
        // writes out the list of natures and adds their numbers to a list
        Console.WriteLine("Here are the natures you can pick from");
        _i = 1;
        foreach(string JMNature in _JMNaturesList)
        {
            Console.WriteLine($"({_i}) {JMNature}");
            _JMNumericalChoices.Add(_i.ToString());
            _i++;
        }
        Console.WriteLine("Please enter the numerical of your choice");
        _JMPickedNumber = Console.ReadLine();
        
        // checks to make sure it is a valid option
        _JMValidChoice = true;
        while(_JMValidChoice)
        {
            foreach(string JMNumerical in _JMNumericalChoices)
            {
                if (JMNumerical == _JMPickedNumber)
                {
                    _JMValidChoice = false;
                }
            }
            if(_JMValidChoice)
            {
                Console.WriteLine("Please enter a valid numerical between 1 and 36");
                _JMPickedNumber = Console.ReadLine();
            }
        }

        // if the while loop finishes it will return the nature
        return _JMNaturesList[Int32.Parse(_JMPickedNumber)-1];
        
    }
}