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

public class JMCustomNatures : JMParentNatures
{
    public JMCustomNatures()
    {
        
    }

    public override string JMRandomNature()
    {
         string[] JMNaturesList = {"cuddly","distracted","proud","decisive","patient","desperate","lonely","adamant","naughty","brave",
        "stark","bold","impish","lax","relaxed","curious","modest","mild","rash","quiet","dreamy","calm","gentle","careful","sassy","skittish",
        "timid","hasty","jolly","naive","composed","hardy","docile","bashful","quirky","serious"};
        List<string> JMNumericalChoices = new List<string>();
        
        // writes out the list of natures and adds their numbers to a list
        Console.WriteLine("Here are the natures you can pick from");
        int i = 1;
        foreach(string JMNature in JMNaturesList)
        {
            Console.WriteLine($"({i}) {JMNature}");
            JMNumericalChoices.Add(i.ToString());
            i++;
        }
        Console.WriteLine("Please enter the numerical of your choice");
        string JMPickedNumber = Console.ReadLine();
        
        // checks to make sure it is a valid option
        bool JMValidChoice = true;
        while(JMValidChoice)
        {
            foreach(string JMNumerical in JMNumericalChoices)
            {
                if (JMNumerical == JMPickedNumber)
                {
                    JMValidChoice = false;
                }
            }
            if(JMValidChoice)
            {
                Console.WriteLine("Please enter a valid numerical between 1 and 36");
                JMPickedNumber = Console.ReadLine();
            }
        }

        // if the while loop finishes it will return the nature
        return JMNaturesList[Int32.Parse(JMPickedNumber)-1];
        
    }
}