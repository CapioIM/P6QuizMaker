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
                        QuizmakerList = FileOperations.Deserialize();
                        UIMethods.ShowListOfQuestion(QuizmakerList);
                        Console.WriteLine("Which question or answers for which question you would like to amend ?");
                        int questionToAmend = UIMethods.GetUserInputNum() - 1;                          //choice which question to amend
                        Console.WriteLine($"{QuizmakerList[questionToAmend].QuestionText}");
                        UIMethods.ShowListOfQuestion(QuizmakerList);                              // show list of questions

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

                                Options.Option(Options.ListForOptions.QuestionsText,QuizmakerList,questionToAmend);

                                /*
                                Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
                                QuizmakerList[questionToAmend].QuestionText = UIMethods.DisplayAskToTypeQuestionText();
                                Console.WriteLine("Do you want to keep changing Question text, answers or correct answers ?");
                                */
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

                                    UIMethods.ShowListOfAnswers(QuizmakerList, questionToAmend, amendChoice);
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
                                bool amendOrRemoveAnswer = true;
                                while (amendOrRemoveAnswer)
                                {
                                    Console.WriteLine(
                                        "Press 1 to amend answer \n" +
                                        "Press 2 to remove answer" +
                                        "Press 3 to add answer");

                                    UIMethods.ShowListOfAnswers(QuizmakerList, questionToAmend, amendChoice);
                                    Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");

                                    int choiceAmendRemoveOrAddAnswer = UIMethods.GetUserInputNum();
                                    if (choiceAmendRemoveOrAddAnswer == 1)                                                         // amend answer
                                    {
                                        int answerToAmend = UIMethods.GetUserInputNum() - 1;
                                        Console.WriteLine("What this answer would you like to change to ?");
                                        QuizmakerList[questionToAmend].CorrectAnswersList[answerToAmend] = UIMethods.GetUserInput();
                                    }

                                    if (choiceAmendRemoveOrAddAnswer == 2)                                                             //remove answer
                                    {
                                        int answerToRemove = UIMethods.GetUserInputNum() - 1;
                                        QuizmakerList[questionToAmend].CorrectAnswersList.RemoveAt(answerToRemove);
                                    }
                                    if (choiceAmendRemoveOrAddAnswer == 3)                                                         // add answer
                                    {
                                        UIMethods.ShowListOfAnswers(QuizmakerList, questionToAmend, amendChoice);
                                        ManageQuestions.AddAnswersToQuestion(QuizmakerList[questionToAmend]);
                                    }
                                    Console.WriteLine("Would you like to amend another answer ?");
                                    amendOrRemoveAnswer = UIMethods.MakeDecisionYorN();
                                }
                            }
                            Console.WriteLine("Do you want to keep changing Question text, answers or correct answers ?");
                            amending = UIMethods.MakeDecisionYorN();

                        }
                        Console.WriteLine("end of manage while loop to test programm");
                        FileOperations.CreateXMLSerializeFile(QuizmakerList);  // create xml
                        amendQuestionsAndAnswers = UIMethods.MakeDecisionYorN();
                    }

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


