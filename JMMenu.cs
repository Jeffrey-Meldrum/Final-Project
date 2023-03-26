/*
Author: 
  Jeffrey Meldrum

Date:03/23/2023

Description: 
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
        Console.WriteLine("(1)  Create Randomized Pokemon");
        Console.WriteLine("(2)  Create Curated Pokemon");
        Console.WriteLine("(3)  Quit");
    }

    // numerical selection of the main menu
    public string JMmainSelection()
    {
        Console.WriteLine("Please enter the numerical of your choice.");
        return Console.ReadLine();
    }

    public List<string> JMhabitatLevelSelction()
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
        bool JMValidSelection = false;
        while (JMValidSelection != false)
        {
            // checks their slection against the list of selections
            foreach (string JMHabitat in JMHabitats)
            {
                if (JMHabitatSelection == JMHabitat)
                {
                    JMValidSelection = true;
                }
            }

            // if still false will ask for them to imput a slection again
            if (JMValidSelection == false)
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
        JMValidSelection = false;
        while (JMValidSelection != false)
        {
            int i = 1;
            int JMLevelSelectionInt = Int32.Parse(JMLevelSelection);
            while (i != 101)
            {
                if (i == JMLevelSelectionInt)
                {
                    JMValidSelection = true;
                }
                i++;
            }

            // if it is still false asks them to enter a valid input
            if (JMValidSelection == false)
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
