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
        List<List<List<string>>> JMFormattedPokemonList = new List<List<List<string>>>();
        JMFormattedPokemonList = jmFileReader.JMPokemonFormatter(JMUnformattedReader);

        // Console.WriteLine($"{JMFormattedReader[1][0][0]}");
        // return;

        //declaring all the classes that will be used
        JMPokemonSelector jmPokemonSelector = new JMPokemonSelector();
        JMParentNatures jmRandomNature = new JMParentNatures();
        JMParentMoves jmRandomMoves = new JMParentMoves();
        JMParentAbilities jmRandomAbilities = new JMParentAbilities();
        JMEvolution jmEvolution = new JMEvolution();
        JMCustomNatures jmCustomNatures = new JMCustomNatures();
        JMCustomAbilities jmCustomAbilities = new JMCustomAbilities();
        JMCustomMoves jmCustomMoves = new JMCustomMoves();

        // delcares all lists and other variables to be used
        List<string> JMSelectedParameters = new List<string>();
        List<List<string>> JMChosenPokemonData = new List<List<string>>();
        List<string> JMChosenPokemonFilteredMoves = new List<string>();
        List<string> JMChosenPokemonMoves = new List<string>();
        List<string> JMChosenPokemonFilteredAbilities = new List<string>();
        List<string> JMChosenPokemonAbilities = new List<string>();
        string JMChosenPokemonName ="";
        string JMChosenPokemonNature = "";

        // indexes for accessing specific data in previously constructed data and parameters lists

        // program will run as long as quit isnt selected
        while(JMMenuSelection != "5")
        {
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
            // creates a random pokemon based on habitat
            JMSelectedParameters = jmMenu.JMhabitatLevelSelection();
            JMChosenPokemonData = jmPokemonSelector.JMSelectedPokemon(JMFormattedPokemonList, JMSelectedParameters[JMSelectedHabitatIndex]);

            // sees what evolution it should be based on level then runs it through the selector again
            JMChosenPokemonName = jmEvolution.JMRandomEvolution(JMChosenPokemonData[JMEvolutionsIndex], JMSelectedParameters[JMSelectedLevelIndex]);
            JMChosenPokemonData = jmPokemonSelector.JMSelectedPokemon(JMFormattedPokemonList, JMChosenPokemonName);

            // randomizes what moves it has
            JMChosenPokemonFilteredMoves = jmRandomMoves.JMRFilteredMoves(JMChosenPokemonData[JMMovesIndex], JMSelectedParameters[JMSelectedLevelIndex]);
            JMChosenPokemonMoves = jmRandomMoves.JMRandomMoves(JMChosenPokemonFilteredMoves);

            // randomizes what abilities it has
            JMChosenPokemonFilteredAbilities = jmRandomAbilities.JMAbiltiesFilter(JMChosenPokemonData[JMAbilitiesIndex], JMSelectedParameters[JMSelectedLevelIndex]);
            JMChosenPokemonAbilities = jmRandomAbilities.JMRandomAbilties(JMChosenPokemonFilteredAbilities, JMSelectedParameters[JMSelectedLevelIndex]);

            // randomizes what nature it has
            JMChosenPokemonNature = jmRandomNature.JMRandomNature();

            // writes out all the data gathered
            Console.WriteLine($"\nThe chosen pokemon is: {JMChosenPokemonName}\n");
            Console.WriteLine("It's Moves are:");
            foreach(string JMChosenPokemonMove in JMChosenPokemonMoves)
            {
              Console.WriteLine($"{JMChosenPokemonMove}");
            }
            Console.WriteLine("\nIt's abilities are:");
            foreach (string JMChosenPokemonAbility in JMChosenPokemonAbilities)
            {
              Console.WriteLine($"{JMChosenPokemonAbility}");
            }
            Console.WriteLine("\nIt's nature is:");
            Console.WriteLine($"{JMChosenPokemonNature}\n");
            JMMenuSelection = "5";

            break;

            case "2":
            // creates custom pokemon based on habitat
            JMSelectedParameters = jmMenu.JMhabitatLevelSelection();
            JMChosenPokemonData = jmPokemonSelector.JMSelectedPokemon(JMFormattedPokemonList, JMSelectedParameters[JMSelectedHabitatIndex]);

            // sees what evolution it should be based on level then runs it through the selector again
            JMChosenPokemonName = jmEvolution.JMRandomEvolution(JMChosenPokemonData[JMEvolutionsIndex], JMSelectedParameters[JMSelectedLevelIndex]);
            JMChosenPokemonData = jmPokemonSelector.JMSelectedPokemon(JMFormattedPokemonList, JMChosenPokemonName);

            // randomizes what moves it has
            JMChosenPokemonFilteredMoves = jmRandomMoves.JMRFilteredMoves(JMChosenPokemonData[JMMovesIndex], JMSelectedParameters[JMSelectedLevelIndex]);
            JMChosenPokemonMoves = jmCustomMoves.JMRandomMoves(JMChosenPokemonFilteredMoves);

            // randomizes what abilities it has
            JMChosenPokemonFilteredAbilities = jmRandomAbilities.JMAbiltiesFilter(JMChosenPokemonData[JMAbilitiesIndex], JMSelectedParameters[JMSelectedLevelIndex]);
            JMChosenPokemonAbilities = jmCustomAbilities.JMRandomAbilties(JMChosenPokemonFilteredAbilities, JMSelectedParameters[JMSelectedLevelIndex]);

            // randomizes what nature it has
            JMChosenPokemonNature = jmCustomNatures.JMRandomNature();

            // writes out all the data gathered
            Console.WriteLine($"\nThe chosen pokemon is: {JMChosenPokemonName}\n");
            Console.WriteLine("It's Moves are:");
            foreach(string JMChosenPokemonMove in JMChosenPokemonMoves)
            {
              Console.WriteLine($"{JMChosenPokemonMove}");
            }
            Console.WriteLine("\nIt's abilities are:");
            foreach (string JMChosenPokemonAbility in JMChosenPokemonAbilities)
            {
              Console.WriteLine($"{JMChosenPokemonAbility}");
            }
            Console.WriteLine("\nIt's nature is:");
            Console.WriteLine($"{JMChosenPokemonNature}\n");
            JMMenuSelection = "5";
            break;

            case "3":
            // creates random pokemon based on name
            JMSelectedParameters = jmMenu.JMnameLevelSelection(JMFormattedPokemonList);
            JMChosenPokemonData = jmPokemonSelector.JMSelectedPokemon(JMFormattedPokemonList, JMSelectedParameters[JMSelectedNameIndex]);
            Console.WriteLine("Done");

            // randomizes what moves it has
            JMChosenPokemonFilteredMoves = jmRandomMoves.JMRFilteredMoves(JMChosenPokemonData[JMMovesIndex], JMSelectedParameters[JMSelectedLevelIndex]);
            JMChosenPokemonMoves = jmRandomMoves.JMRandomMoves(JMChosenPokemonFilteredMoves);
            Console.WriteLine("Done");

            // randomizes what abilities it has
            JMChosenPokemonFilteredAbilities = jmRandomAbilities.JMAbiltiesFilter(JMChosenPokemonData[JMAbilitiesIndex], JMSelectedParameters[JMSelectedLevelIndex]);
            JMChosenPokemonAbilities = jmRandomAbilities.JMRandomAbilties(JMChosenPokemonFilteredAbilities, JMSelectedParameters[JMSelectedLevelIndex]);
            Console.WriteLine("Done");

            // randomizes what nature it has
            JMChosenPokemonNature = jmRandomNature.JMRandomNature();
            Console.WriteLine("Done");

            // writes out all the data gathered
            Console.WriteLine($"\nThe chosen pokemon is: {JMSelectedParameters[JMSelectedNameIndex]}\n");
            Console.WriteLine("It's Moves are:");
            foreach(string JMChosenPokemonMove in JMChosenPokemonMoves)
            {
              Console.WriteLine($"{JMChosenPokemonMove}");
            }
            Console.WriteLine("\nIt's abilities are:");
            foreach (string JMChosenPokemonAbility in JMChosenPokemonAbilities)
            {
              Console.WriteLine($"{JMChosenPokemonAbility}");
            }
            Console.WriteLine("\nIt's nature is:");
            Console.WriteLine($"{JMChosenPokemonNature}\n");
            JMMenuSelection = "5";
            break;

            case "4":
            // creates custom pokemon based on name
            JMSelectedParameters = jmMenu.JMnameLevelSelection(JMFormattedPokemonList);
            JMChosenPokemonData = jmPokemonSelector.JMSelectedPokemon(JMFormattedPokemonList, JMSelectedParameters[JMSelectedNameIndex]);
            JMChosenPokemonName = JMSelectedParameters[JMSelectedNameIndex];

            // randomizes what moves it has
            JMChosenPokemonFilteredMoves = jmRandomMoves.JMRFilteredMoves(JMChosenPokemonData[JMMovesIndex], JMSelectedParameters[JMSelectedLevelIndex]);
            JMChosenPokemonMoves = jmCustomMoves.JMRandomMoves(JMChosenPokemonFilteredMoves);

            // randomizes what abilities it has
            JMChosenPokemonFilteredAbilities = jmRandomAbilities.JMAbiltiesFilter(JMChosenPokemonData[JMAbilitiesIndex], JMSelectedParameters[JMSelectedLevelIndex]);
            JMChosenPokemonAbilities = jmCustomAbilities.JMRandomAbilties(JMChosenPokemonFilteredAbilities, JMSelectedParameters[JMSelectedLevelIndex]);

            // randomizes what nature it has
            JMChosenPokemonNature = jmCustomNatures.JMRandomNature();

            // writes out all the data gathered
            Console.WriteLine($"\nThe chosen pokemon is: {JMChosenPokemonName}\n");
            Console.WriteLine("It's Moves are:");
            foreach(string JMChosenPokemonMove in JMChosenPokemonMoves)
            {
              Console.WriteLine($"{JMChosenPokemonMove}");
            }
            Console.WriteLine("\nIt's abilities are:");
            foreach (string JMChosenPokemonAbility in JMChosenPokemonAbilities)
            {
              Console.WriteLine($"{JMChosenPokemonAbility}");
            }
            Console.WriteLine("\nIt's nature is:");
            Console.WriteLine($"{JMChosenPokemonNature}\n");
            JMMenuSelection = "5";
            break;

            case "5":
            // ends the program
            JMMenuSelection = "5";
            break;
          }
        }
    }

}