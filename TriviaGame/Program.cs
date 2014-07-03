using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Getting the name from the user
            Console.WriteLine("Hello there! What's you name?");
            string name = Console.ReadLine(); 
            //Greeting the user and giving the user the rules 
            Console.WriteLine("Welcome, " + name +"! I would like to play a game of trivia with you. I will show you a question and then you will type in an answer. I will then tell you if your guess was correct or not. After 10 questions the game will end and I will show you your score.");
            //Setting up some variables to use 
            // during the game 
            int time = 10;
            int score = 0;
            int correct = 0;
            int incorrect = 0;
            //Setting up a while loop to randomly
            // generate a question from the .txt list
            // and to then get the users answers and 
            // generate a new question. 
            while (time > 0)
            {
                //Random generator for the questions
                Random random = new Random();
                int randomNum = random.Next(1,5000);
                var Trivia = GetTriviaList()[randomNum];
                //Giving the user the question
                Console.WriteLine(Trivia.Question);
                //Getting the answer from the user
                Console.WriteLine("Answer: ");
                //Setting the user's answer to lowercase
                string input = Console.ReadLine().ToLower();
                //Setting up a comparison with the user's answer 
                // to the actual answer of the question
                if (input == Trivia.Answer.ToLower())
                {
                    //Adds 1 to the user's correct answer count
                    correct++;
                    //Adds 100 points to the user's score
                    score += 100;
                    //Subtracts 1 from the number of questions 
                    // the user has til the end of the game
                    time--;
                    //Printing to the user that their anwser
                    // was correct
                    Console.WriteLine("Your answer was correct! Great job!");
                }
                else
                {
                    //Adds 1 to the user's incorrect answer count
                    incorrect++;
                    //Subtracts 100 points from the user's score
                    score += -100;
                    //Subtracts 1 from the number of questions
                    // the user has til the end of the game
                    time--;
                    //Prints to the user that their answer was incorrect 
                    // and prints the correct answer
                    Console.WriteLine("Your answer was incorrect. The correct answer was: " + Trivia.Answer.ToUpper());
                }
            }
            //Prints to the user their score, how many 
            // correct anwsers that they had and the 
            // number of incorrect answers that they had
            Console.WriteLine();
            Console.WriteLine("You had " + score + " points. Good job! You had " + correct + " correct answers and " + incorrect + " incorrect answers. Better luck next time!");
            Console.WriteLine();
      
            //Keeps the console open 
            Console.ReadKey();
        }
        //This function gets the full list of trivia questions from the Trivia.txt document
        static List<Trivia> GetTriviaList()
        {
            //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
            List<string> contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();

            //Each item in list "contents" is now one line of the Trivia.txt document.

            //make a new list to return all trivia questions
            List<Trivia> returnList = new List<Trivia>();
            // TODO: go through each line in contents of the trivia file and make a trivia object.
            //       add it to our return list.
            foreach (string question in contents)
            {
                Trivia a = new Trivia(question);
                returnList.Add(a);
            }

            //Return the full list of trivia questions
            return returnList;

        }
    }
}
