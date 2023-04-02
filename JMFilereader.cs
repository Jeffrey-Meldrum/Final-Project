/*
Author: Jeffrey Meldrum

Date:03/23/2023

Description: 
Responsibilities: 


Attributes:


Behaviors:

*/

using System;
using System.IO;

public class JMFileReader
{
    public JMFileReader()
    {

    }

    // reads through the file
    public List<string> JMPokemonLoader()
    {
        List<string> JMPokemonRawData = new List<string>();
        string JMFileName = "pokedex_data_txt.txt";
        // reads the file and saves it into an array
        string[] JMPokemonArray = System.IO.File.ReadAllLines(JMFileName);

        // changes array into a list
        foreach(string JMPokemon in JMPokemonArray)
        {
            JMPokemonRawData.Add(JMPokemon);
        }

        return JMPokemonRawData;
    }

    // formats the raw data into a useable state for the code
    public List<List<List<string>>> JMPokemonFormatter(List<string> JMPokemonRawData)
    {
        // list of all pokemon and their individual parts(name, abilities, evolutions, habitats, and move list)
        List<List<List<string>>> JMPokemonProcessedDataList = new List<List<List<string>>>();

        foreach (string JMPokemonRaw in JMPokemonRawData)
        {
            // list of each individual pokemons parts (name, abilities, evolutions, habitats, and move list)
            List<List<string>> JMPokemonProcessedData = new List<List<string>>();
            // splits pokemon into name, abilities, evolutions, habitats, and move list
            string[] JMPokemonSplitDataArray = JMPokemonRaw.Split("|");
            
            // formats the string by getting rid of [] and ' and turns array into a list
            foreach(string JMPokemonPart in JMPokemonSplitDataArray)
            {
                // list of each individual part of pokemons name, abilities, evolutions, habitats, and move list
                List<string> JMPokemonFormattedData = new List<string>();
                char[] JMTrimCharacters = {'\t','"',' ', '[', ']','\''};
                string JMPokemonFormattedPart = JMPokemonPart.Trim(JMTrimCharacters);
                // splits each part into individual names, abilities, evolutions, habitats, and moves
                string[] JMPokemonUnformattedParts = JMPokemonFormattedPart.Split(",");
                
                // trims the individual parts of ' and saves it to a list
                foreach (string JMPokemonUnformattedPart in JMPokemonUnformattedParts)
                {
                    string JMPokemonTrimmedPart = JMPokemonUnformattedPart.Trim(JMTrimCharacters);
                    // adds the formtted data to that individual section(name, abilities, evolutions, habitats, and move list)
                    JMPokemonFormattedData.Add(JMPokemonTrimmedPart);
                }
                // saves a whole pokemon comprised of a list of lsit of strings that are it's individual parts
                JMPokemonProcessedData.Add(JMPokemonFormattedData);
            }
            // saves all pokemon to a single master list
            JMPokemonProcessedDataList.Add(JMPokemonProcessedData);
        }

        return JMPokemonProcessedDataList;
    }
}