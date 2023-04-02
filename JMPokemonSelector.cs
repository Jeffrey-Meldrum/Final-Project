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

public class JMPokemonSelector
{
    public JMPokemonSelector()
    {

    }

    public List<List<string>> JMSelectedPokemon(List<List<List<string>>> JMPokemonList, string JMChosenParameter)
    {
        // Looks through the entire list of pokemon and saves each one that fits the habitat
        List<List<List<string>>> JMQualifiedPokemon = new List<List<List<string>>>();

        // goes through each pokemon
        foreach (List<List<string>> JMPokemon in JMPokemonList)
        {
            //goes through each part of a pokemon
            foreach (List<string> JMParts in JMPokemon)
            {
                // goes through each part of the part of a pokemon
                foreach(string JMPart in JMParts)
                {
                    if (JMPart == JMChosenParameter)
                    {
                        JMQualifiedPokemon.Add(JMPokemon);
                    }
                }
            }
        }

        // picks a random pokemon to be the chose one
        int JMQualifiedListLength = JMQualifiedPokemon.Count();
        Random JMRandomNumber = new Random();
        int JMRandomPokemonNumber = JMRandomNumber.Next(0,JMQualifiedListLength-1);


        return JMQualifiedPokemon[JMRandomPokemonNumber];
    }
}