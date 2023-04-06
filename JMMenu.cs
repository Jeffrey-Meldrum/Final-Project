/*
Author: Jeffrey Meldrum

Date:03/23/2023

Description: the menu class focuses on giving the user and option to do a randomized or custom pokemon based off a habitat or level
Responsibilities: Give the user options of how they would like to proceed, return their input as a string, ask them what habita/name and
level the would like then returns that as a short two part lsit to be used by the rest of the program.

*/

using System;

public class JMMenu
{
    private string _JMMenuSelection;

    private List<string> _JMSelections = new List<string>();
    private List <string> _JMHabitats = new List<string>();
    private string _JMHabitatSelection;
    private string _JMLevelSelection;
    private int _i;
    private int _JMLevelSelectionInt;
    private bool _JMValidSelection;

    private string _JMnameSelection;

    public JMMenu()
    {

    }

    // main menu for randomized or curated creation
    public void JMmainMenuSelector()
    {
        Console.WriteLine("Menu");
        Console.WriteLine("(1)  Create randomized pokemon by habitat");
        Console.WriteLine("(2)  Create custom pokemon by habitat");
        Console.WriteLine("(3)  Create randomized pokemon by name");
        Console.WriteLine("(4)  Create custom pokemon by name");
        Console.WriteLine("(5)  Quit");
    }

    // numerical selection of the main menu
    public string JMmainSelection()
    {
        Console.WriteLine("Please enter the numerical of your choice.");
        _JMMenuSelection = Console.ReadLine();
        // makes sure a proper numerical is input
        while (_JMMenuSelection != "1" && _JMMenuSelection != "2" && _JMMenuSelection != "3" && _JMMenuSelection != "4" && _JMMenuSelection != "5")
        {
          Console.WriteLine("Please input a proper numerical.");
          _JMMenuSelection = Console.ReadLine();
        }
        Console.Clear();
        return _JMMenuSelection;
    }


    public List<string> JMhabitatLevelSelection()
    {
        _JMHabitats.Add("forest");
        _JMHabitats.Add("mountain");
        _JMHabitats.Add("ocean");
        _JMHabitats.Add("urban");
        _JMHabitats.Add("grassland");
        _JMHabitats.Add("tundra");
        _JMHabitats.Add("desert");
        _JMHabitats.Add("rainforest");
        _JMHabitats.Add("marsh");
        _JMHabitats.Add("cave");
        _JMHabitats.Add("freshwater");
        _JMHabitats.Add("beach");
        _JMHabitats.Add("taiga");
        _JMHabitats.Add("arctic");

        // prints out each of the habitats for selction and reads their selection
        foreach (string JMHabitat in _JMHabitats)
        {
            Console.WriteLine($"{JMHabitat}");
        }
        Console.WriteLine("Please make a habitat selection, spelling is important");
        _JMHabitatSelection = Console.ReadLine();

        // checks to make sure it is an actual selection
        _JMValidSelection = true;
        while (_JMValidSelection)
        {
            // checks their slection against the list of selections
            foreach (string JMHabitat in _JMHabitats)
            {
                if (_JMHabitatSelection == JMHabitat)
                {
                    _JMValidSelection = false;
                }
            }

            // if still false will ask for them to imput a slection again
            if (_JMValidSelection)
                {
                    Console.WriteLine("Please enter a valid selection");
                    _JMHabitatSelection = Console.ReadLine();
                }
        }
        // if selection is valid it adds it to the list
        _JMSelections.Add(_JMHabitatSelection);

        // user enters a level they want the pokemon to be at
        Console.WriteLine("Please enter a numerical in between 1-100 for the level");
        _JMLevelSelection = Console.ReadLine();

        // checks to make sure it is a valid input
        _JMValidSelection = true;
        while (_JMValidSelection)
        {
            _i = 1;
            _JMLevelSelectionInt = Int32.Parse(_JMLevelSelection);
            while (_i != 101)
            {
                if (_i == _JMLevelSelectionInt)
                {
                    _JMValidSelection = false;
                }
                _i++;
            }

            // if it is still false asks them to enter a valid input
            if (_JMValidSelection)
            {
                Console.WriteLine("Please enter a valid numerical between 1-100");
                _JMLevelSelection = Console.ReadLine();
            }
        }

        // if the level slection is valid it is added to the list
        _JMSelections.Add(_JMLevelSelection);
        return _JMSelections; 
    }


    public List<string> JMnameLevelSelection(List<List<List<string>>> JMPokemonFormattedData)
    {
        _JMValidSelection = true;
        Console.WriteLine("Please enter a specific pokemon name");
        _JMnameSelection = Console.ReadLine();

        // checks to make sure the put in an existing pokemon
        while(_JMValidSelection)
        {
            foreach(List<List<string>> JMPokemon in JMPokemonFormattedData)
            {
                if(JMPokemon[0][0] == _JMnameSelection)
                {
                    _JMValidSelection = false;
                }
            }
            if(_JMValidSelection)
            {
                Console.WriteLine("Could not find your chosen pokemon, please reenter the name");
                _JMnameSelection = Console.ReadLine();
            }
        }

        _JMSelections.Add(_JMnameSelection);
        
        Console.WriteLine("Please enter a numerical in between 1-100 for the level");
        _JMLevelSelection = Console.ReadLine();

        // checks to make sure it is a valid input
        _JMValidSelection = true;
        while (_JMValidSelection)
        {
            _i = 1;
            _JMLevelSelectionInt = Int32.Parse(_JMLevelSelection);
            while (_i != 101)
            {
                if (_i == _JMLevelSelectionInt)
                {
                    _JMValidSelection = false;
                }
                _i++;
            }

            // if it is still false asks them to enter a valid input
            if (_JMValidSelection)
            {
                Console.WriteLine("Please enter a valid numerical between 1-100");
                _JMLevelSelection = Console.ReadLine();
            }
        }

        // if the level slection is valid it is added to the list
        _JMSelections.Add(_JMLevelSelection);
        return _JMSelections; 
    }
}
