/*
Author: Jeffrey Meldrum

Date:03/23/2023

Description: 
Responsibilities: 


Attributes:


Behaviors:

*/

using System;
using System.Collections.Generic;

public class JMPokemoneselector
{
    public JMPokemoneselector()
    {

    }

    public List<List<string>> JMChosenPokemon(List<List<List<string>>> JMPokemonList, string JMChosenHabitat)
    {
        // Looks through the entire list of pokemon and saves each one that fits the habitat
        List<List<List<string>>> JMQualifiedPokemon = new List<List<List<string>>>();

        foreach(List<List<string>> JMPokemon in JMPokemonList)
        {   
            // looks through the habitat list of each pokemon and if they 
            foreach(string JMPokemonHabitat in JMPokemon[3])
            {
                // if it meets the habitat specification it saves it to a list
                if (JMChosenHabitat == JMPokemonHabitat)
                {
                    JMQualifiedPokemon.Add(JMPokemon);
                }
            }
        }

        // picks a random pokemon to be the chose one
        int JMQualifiedPokemonListLength = JMQualifiedPokemon.Count();
        Random JMRandomNumber = new Random();
        int JMChosenPokemonNumber = JMRandomNumber.Next(0,JMQualifiedPokemonListLength-1);
        return JMQualifiedPokemon[JMChosenPokemonNumber];
    }
}