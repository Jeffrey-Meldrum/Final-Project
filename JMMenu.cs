/*
Author: Jeffrey Meldrum

Date:03/23/2023

Description: the menu class focuses on giving the user and option to do a randomized or custom pokemon based off a habitat or level
Responsibilities: 


Attributes:


Behaviors:

*/

using System;

public class JMMenu
{
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
        string JMMenuSelection = Console.ReadLine();
        // makes sure a proper numerical is input
        while (JMMenuSelection != "1" && JMMenuSelection != "2" && JMMenuSelection != "3" && JMMenuSelection != "4" && JMMenuSelection != "5")
        {
          Console.WriteLine("Please input a proper numerical.");
          JMMenuSelection = Console.ReadLine();
        }
        return JMMenuSelection;
    }

    public List<string> JMhabitatLevelSelection()
    {
        List<string> JMSelections = new List<string>();
        List <string> JMHabitats = new List<string>();
        JMHabitats.Add("forest");
        JMHabitats.Add("mountain");
        JMHabitats.Add("ocean");
        JMHabitats.Add("urban");
        JMHabitats.Add("grassland");
        JMHabitats.Add("tundra");
        JMHabitats.Add("desert");
        JMHabitats.Add("rainforest");
        JMHabitats.Add("marsh");
        JMHabitats.Add("cave");
        JMHabitats.Add("freshwater");
        JMHabitats.Add("beach");
        JMHabitats.Add("taiga");
        JMHabitats.Add("arctic");

        // prints out each of the habitats for selction and reads their selection
        foreach (string JMHabitat in JMHabitats)
        {
            Console.WriteLine($"{JMHabitat}");
        }
        Console.WriteLine("Please make a habitat selection, spelling is important");
        string JMHabitatSelection = Console.ReadLine();

        // checks to make sure it is an actual selection
        bool JMValidSelection = true;
        while (JMValidSelection)
        {
            // checks their slection against the list of selections
            foreach (string JMHabitat in JMHabitats)
            {
                if (JMHabitatSelection == JMHabitat)
                {
                    JMValidSelection = false;
                }
            }

            // if still false will ask for them to imput a slection again
            if (JMValidSelection)
                {
                    Console.WriteLine("Please enter a valid selection");
                    JMHabitatSelection = Console.ReadLine();
                }
        }
        // if selection is valid it adds it to the list
        JMSelections.Add(JMHabitatSelection);

        // user enters a level they want the pokemon to be at
        Console.WriteLine("Please enter a numerical in between 1-100 for the level");
        string JMLevelSelection = Console.ReadLine();

        // checks to make sure it is a valid input
        JMValidSelection = true;
        while (JMValidSelection)
        {
            int i = 1;
            int JMLevelSelectionInt = Int32.Parse(JMLevelSelection);
            while (i != 101)
            {
                if (i == JMLevelSelectionInt)
                {
                    JMValidSelection = false;
                }
                i++;
            }

            // if it is still false asks them to enter a valid input
            if (JMValidSelection)
            {
                Console.WriteLine("Please enter a valid numerical between 1-100");
                JMLevelSelection = Console.ReadLine();
            }
        }

        // if the level slection is valid it is added to the list
        JMSelections.Add(JMLevelSelection);
        return JMSelections; 
    }
}
