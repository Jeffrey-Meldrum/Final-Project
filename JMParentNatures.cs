/*
Author: Jeffrey Meldrum

Date: 03/23/2023

Description: this class is used to randomly pick a nature from the list of 36 natures
Responsibilities: does require any input but will look through the list of natures and randomly select 1 and return it as a string

*/

using System;
using System.IO;
using System.Collections.Generic;

public class JMParentNatures
{
private Random _JMRandmoizer = new Random();
private int _JMRandomNatureIndex;

    public JMParentNatures()
    {
        
    }

    public virtual string JMRandomNature()
    {
        string[] JMNaturesList = {"cuddly","distracted","proud","decisive","patient","desperate","lonely","adamant","naughty","brave",
        "stark","bold","impish","lax","relaxed","curious","modest","mild","rash","quiet","dreamy","calm","gentle","careful","sassy","skittish",
        "timid","hasty","jolly","naive","composed","hardy","docile","bashful","quirky","serious"};
        
        _JMRandomNatureIndex = _JMRandmoizer.Next(0,35);
        string JMChosenNature = JMNaturesList[_JMRandomNatureIndex];
        return JMChosenNature;
    }
}