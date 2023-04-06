/*
Author: Jeffrey Meldrum

Date: 03/23/2023

Description: This program is usd to look through the data extracted from the text document and find pokemon that mtach the users input
Responsibilities: takes in the entire formatte pokemon list and the chosen paramters and finds the correct pokemon. Can find based off
of name or habitat

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
        int JMQualifiedListLength = JMQualifiedPokemon.Count()-1;
        Random JMRandomNumber = new Random();
        int JMRandomPokemonNumber = JMRandomNumber.Next(0,JMQualifiedListLength);


        return JMQualifiedPokemon[JMRandomPokemonNumber];
    }
}