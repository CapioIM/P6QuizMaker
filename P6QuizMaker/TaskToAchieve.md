Design a program which asks the user for a list of questions,
multiple choice answers for each question and the ability to specify which answer(s) are right.
The program will then add those questions and answers to a list that gets stored on your harddisk using serialisation.
The program can then read that file, randomly pick a question and load up its answers for the user to choose from. 
When the user chooses an answer the program will determine if the answer chosen is correct. 
It should also keep score for the end.

Tips: First we need to create our repository of questions and answers. 
A simple way to do this is to have your program open up and ask the user to enter questions and their answers.
Each question and the answers they add will be stored in a file (serialisation is your friend).

An example might be “What color is the sky?” and list “red, blue, green” as the answers. 
The answer “Blue” is marked as the right answer (which you obviously don’t show the user taking the quiz). 
When the user selects the answer it gets compared it to the correct one stored. 
Each successful answer can be added to a counter variable.
At the end of the quiz their score is this counter variable over the number of questions asked.

Added Difficulty: Support multiple answers as correct.