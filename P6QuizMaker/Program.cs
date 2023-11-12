using System.Xml.Serialization;

namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> QuizmakerList = new List<Question>();
            int score = 0;

            bool interestedToUseProgramm = true;
            while (interestedToUseProgramm)
            {
                UIMethods.WelcomeText();                                                                //welcome text
                UIMethods.DisplayChoiceManagePlay();
                int manageOrPlay = UIMethods.GetUserInputNum();                                         //choice to manage quesitons or play

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Manage))
                {
                    QuizmakerList = FileOperations.Deserialize();
                    bool amendQuestionsAndAnswers = true;
                    while (amendQuestionsAndAnswers)
                    {
                        Console.WriteLine("Do you want to:\n Choice 1 - add new question \n Choice 2 - Amend existing question");
                        int newOrAmend = UIMethods.GetUserInputNum();                                   // choice to add new question or amend existing question

                        if (newOrAmend == 1)                                                            // add new question section
                        {
                            bool addNewQuestions = true;
                            while (addNewQuestions)
                            {
                                Question quizmakerQuestion = ManageQuestions.AddNewQuestion(QuizmakerList);  // new object, add object to list
                                quizmakerQuestion.QuestionText = UIMethods.DisplayAskToTypeQuestionText();  // set question text

                                ManageQuestions.AddAnswersToQuestion(quizmakerQuestion);                    // add answers to list

                                addNewQuestions = UIMethods.GetAdditionalQuestions();                    // ask user if want to add another question
                                Console.Clear();
                            }
                        }

                        if (newOrAmend == 2)
                        {

                            ManageQuestions.ShowListOfQuestion(QuizmakerList);                              // show list of questions
                            Console.WriteLine("Which Question to amend");
                            int questionToAmend = UIMethods.GetUserInputNum();

                            Console.WriteLine("Would you like to amend:\n" +
                           " 1 - Question Text\n" +
                           " 2 - Answers\n" +
                           " 3 - Correct Answers\n");
                            int whatToAmendChoice = UIMethods.GetUserInputNum();
                            Options.DisplayList(QuizmakerList, questionToAmend, whatToAmendChoice);

                            if (whatToAmendChoice == Convert.ToInt32(Options.List.QuestionsText))
                            {
                                Options.AmendQuestionText(QuizmakerList, questionToAmend);
                            }

                            if (whatToAmendChoice == Convert.ToInt32(Options.List.AnswerList) || whatToAmendChoice == Convert.ToInt32(Options.List.CorrectAnswerList))
                            {
                                Console.WriteLine(
                                         "Press 1 to add answer \n" +
                                         "Press 2 to remove answer" +
                                         "Press 3 to amend answer");

                                int addRemoveAmend = UIMethods.GetUserInputNum();
                                if (addRemoveAmend == Convert.ToInt32(Options.OptionChoice.Add))
                                {
                                    Options.AddAnswer(QuizmakerList[questionToAmend], whatToAmendChoice);
                                }
                                if (addRemoveAmend == Convert.ToInt32(Options.OptionChoice.Remove))
                                {

                                }

                            }

                            /*

                            
                            Console.WriteLine("Which question or answers for which question you would like to amend ?");
                            int questionToAmend = UIMethods.GetUserInputNum() - 1;                          //choice which question to amend
                            Console.WriteLine($"{QuizmakerList[questionToAmend].QuestionText}");
                            ManageQuestions.ShowListOfQuestion(QuizmakerList);                              // show list of questions

                            bool amending = true;
                            while (amending)
                            {
                                Console.WriteLine("Would you like to amend:\n" +
                                    " 1 - Question Text\n" +
                                    " 2 - Answers\n" +
                                    " 3 - Correct Answers\n");

                                int amendChoice = UIMethods.GetUserInputNum();
                                if (amendChoice == 1)                                                                                   // amend question text 
                                {
                                    Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
                                    QuizmakerList[questionToAmend].QuestionText = UIMethods.DisplayAskToTypeQuestionText();
                                    Console.WriteLine("Do you want to keep changing Question text, answers or correct answers ?");
                                    amending = UIMethods.MakeDecisionYorN();
                                }
                                if (amendChoice == 2)                                                                               // answers section
                                {
                                    bool amendOrRemoveAnswer = true;
                                    while (amendOrRemoveAnswer)
                                    {
                                        Console.WriteLine(
                                            "Press 1 to amend answer \n" +
                                            "Press 2 to remove answer" +
                                            "Press 3 to add answer");

                                        ManageQuestions.ShowListOfAnswers(QuizmakerList, questionToAmend, amendChoice);
                                        Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");

                                        int choiceAmendRemoveOrAddAnswer = UIMethods.GetUserInputNum();
                                        if (choiceAmendRemoveOrAddAnswer == 1)                                                         // amend answer
                                        {
                                            int answerToAmend = UIMethods.GetUserInputNum() - 1;
                                            Console.WriteLine("What this answer would you like to change to ?");
                                            QuizmakerList[questionToAmend].AnswersList[answerToAmend] = UIMethods.GetUserInput();
                                        }

                                        if (choiceAmendRemoveOrAddAnswer == 2)                                                             //remove answer
                                        {
                                            int answerToRemove = UIMethods.GetUserInputNum() - 1;
                                            QuizmakerList[questionToAmend].AnswersList.RemoveAt(answerToRemove);
                                        }
                                        if (choiceAmendRemoveOrAddAnswer == 3)                                                         // add answer
                                        {
                                            ManageQuestions.AddAnswersToQuestion(QuizmakerList[questionToAmend]);
                                        }
                                        Console.WriteLine("Would you like to amend another answer ?");
                                        amendOrRemoveAnswer = UIMethods.MakeDecisionYorN();
                                    }
                                }
                                if (amendChoice == 3)                                                                  // correct answers
                                {
                                    ManageQuestions.ShowListOfAnswers(QuizmakerList, questionToAmend, amendChoice);



                                    // ohhhhhhhhhh big ffffffffff , time to stop coppy pasta

                                }
                                Console.WriteLine("Do you want to keep changing Question text, answers or correct answers ?");
                               amending = UIMethods.MakeDecisionYorN();

                            }
*/


                        }

                        Console.WriteLine("end to test programm");
                        FileOperations.CreateXMLSerializeFile(QuizmakerList);  // create xml
                        amendQuestionsAndAnswers = UIMethods.MakeDecisionYorN();
                    }
                    continue;
                }

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Play))
                {
                    QuizmakerList = FileOperations.Deserialize();
                }

                bool playingQuizMaker = true;
                while (playingQuizMaker)
                {
                    int randomQuestionIndex = Logic.GetRandomIndex(QuizmakerList);
                    UIMethods.DisplayAddNumberText();
                    UIMethods.DisplayQuestionAndAnswersToPlayer(QuizmakerList, randomQuestionIndex);

                    score = Logic.UserAnswerCheckWithScore(QuizmakerList, score, randomQuestionIndex);

                    playingQuizMaker = UIMethods.MakeDecisionYorN();
                    Console.Clear();
                }
                UIMethods.DisplayPlayAnotherQuestionText();
                interestedToUseProgramm = UIMethods.MakeDecisionYorN();
            }
        }
    }
}
