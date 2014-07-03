using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Trivia
    {
        //Setting properties for the object 
        public string Question { get; set; }
        public string Answer { get; set; }
        //Setting up the constructor for 
        // the object
        public Trivia(string splitString)
        {
            //Creating a container for the 
            // trivia questions
            List<string> QandA = new List<string>();
            //Spliting the trivia questions into
            // questions and answers at the *
            QandA = splitString.Split('*').ToList();
            //Setting up for the game to recognize
            // that the questions are everything before the *
            // and the answers are everything after the *
            this.Question = QandA[0];
            this.Answer = QandA[1];
        }
    }
}
