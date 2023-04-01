/*
Author: Jeffrey Meldrum

Date: 03/23/2023

Description: 
Responsibilities: 


Attributes:


Behaviors:

*/

using System;
using System.Collections.Generic;

public class JMPokemonSelectorName : JMPokemonSelectorHabitat
{
    protected override List<List<string>> JMSelectedPokemon(List<List<List<string>>> JMPokemonList, string JMChosenParameter)
    {
        List<List<string>> JMChosenPokemon = new List<List<string>>();
        // searches for a specific pokemon based on name
        foreach(List<List<string>> JMPokemon in JMPokemonList)
        {   
            if (JMChosenParameter == JMPokemon[0][0])
            {
                JMChosenPokemon = JMPokemon;
            }
        }
        return JMChosenPokemon;
    }
}