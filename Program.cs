/*
Authors: 
  Jeffrey Meldrum

Date:

Description:
Responsibilities:


Attributes:


Behaviors:

*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        JMMenu jmMenu = new JMMenu();
        jmMenu.JMmainMenuSelector();
        String JMMenuSelection = jmMenu.JMmainSelection();
        
        // reads the text file once
        JMFileReader jmFileReader = new JMFileReader();
        // reads the raw data into a list
        List<string> JMUnformattedReader = new List<string>();
        JMUnformattedReader = jmFileReader.JMPokemonLoader();
        // formats raw data into usable data
        List<List<List<string>>> JMFormattedReader = new List<List<List<string>>>();
        JMFormattedReader = jmFileReader.JMPokemonFormatter(JMUnformattedReader);

        // Console.WriteLine($"{JMFormattedReader[1][0][0]}");
        // return;

        // program will run as long as quit isnt selected
        while(JMMenuSelection != "5")
        {
          List<string> JMSelectedParameters = new List<string>();
          int JMSelectedHabitatIndex = 0;
          int JMSelectedNameIndex = 0;
          int JMSelectedLevelIndex = 1;
          int JMNameIndex = 0;
          int JMAbilitiesIndex = 1;
          int JMEvolutionsIndex = 2;
          int JMHabitatIndex = 3;
          int JMMovesIndex = 4;

          switch(JMMenuSelection)
          {
            case "1":
            // creates random pokemon based on habitat
            JMSelectedParameters = jmMenu.JMhabitatLevelSelection();
            JMPokemonSelector jmPokemonSelectorFromHabitat = new JMPokemonSelector();

            // finds a random pokemon
            List<List<string>> JMSelectedPokemonData = new List<List<string>>();
            JMSelectedPokemonData = jmPokemonSelectorFromHabitat.JMSelectedPokemon(JMFormattedReader, JMSelectedParameters[JMSelectedHabitatIndex]);
            
            // picks what evolution it should be
            JMPokemonEvolution jmEvolution = new JMPokemonEvolution();
            string JMSelectedName = jmEvolution.JMRandomEvolution(JMSelectedPokemonData[JMEvolutionsIndex], JMSelectedParameters[JMSelectedLevelIndex]);
            JMPokemonSelector jmPokemonSelectorFromEvolution = new JMPokemonSelector();
            JMSelectedPokemonData = jmPokemonSelectorFromEvolution.JMSelectedPokemon(JMFormattedReader, JMSelectedName);
            Console.WriteLine($"The Selected evolution is {JMSelectedName}");
            break;

            case "2":
            // creates custom pokemon based on habitat
            JMSelectedParameters = jmMenu.JMhabitatLevelSelection();
            JMPokemonSelector jmPokemonSelectorHabitat = new JMPokemonSelector();

            break;

            case "3":
            // creates random pokemon based on name
            break;

            case "4":
            // creates custom pokemon based on name
            break;

            case "5":
            // ends the program
            Console.WriteLine("Done");
            JMMenuSelection = "5";
            break;
          }
        }
    }

}