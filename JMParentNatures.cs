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

public class JMParentNatures
{

    public JMParentNatures()
    {
        
    }

    public virtual string JMRandomNature()
    {
        string[] JMNaturesList = {"cuddly","distracted","proud","decisive","patient","desperate","lonely","adamant","naughty","brave",
        "stark","bold","impish","lax","relaxed","curious","modest","mild","rash","quiet","dreamy","calm","gentle","careful","sassy","skittish",
        "timid","hasty","jolly","naive","composed","hardy","docile","bashful","quirky","serious"};
        Random JMRandmoizer = new Random();
        int JMRandomNatureIndex = JMRandmoizer.Next(0,35);
        string JMChosenNature = JMNaturesList[JMRandomNatureIndex];
        return JMChosenNature;
    }
}