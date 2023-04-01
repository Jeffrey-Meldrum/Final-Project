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

        // program will run as long as quit isnt selected
        while(JMMenuSelection != "5")
        {
          List<string> JMSelectedParameters = new List<string>();
          switch(JMMenuSelection)
          {
            case "1":
            // creates random pokemon based on habitat
            JMSelectedParameters = jmMenu.JMhabitatLevelSelection();
            break;

            case "2":
            // creates custom pokemon based on habitat
            JMSelectedParameters = jmMenu.JMhabitatLevelSelection();
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