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
                UIMethods.WelcomeText();                                        //welcome text
                UIMethods.DisplayChoiceManagePlay();
                int manageOrPlay = UIMethods.GetUserInputNum();                 //choice to manage quesitons or play

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Manage))
                {
                    QuizmakerList = FileOperations.Deserialize();
                    bool amendQuestionsAndAnswers = true;
                    while (amendQuestionsAndAnswers)
                    {
                        Console.WriteLine("Do you want to:\n Choice 1 - add new question \n Choice 2 - Amend existing question");
                        int newOrAmend = UIMethods.GetUserInputNum();               // choice to add new question or amend existing question

                        if (newOrAmend == 1)                                        // add new question section
                        {
                            bool addNewQuestions = true;
                            while (addNewQuestions)
                            {
                                Question quizmakerQuestion = ManageQuestions.AddNewQuestion(QuizmakerList);  // new object, add object to list
                                quizmakerQuestion.QuestionText = UIMethods.DisplayAskToTypeQuestionText();  // set question text

                                ManageQuestions.AddAnswersToQuestion(quizmakerQuestion); // add answers to list

                                addNewQuestions = UIMethods.GetAdditionalQuestions();  // ask user if want to add another question
                                Console.Clear();
                            }
                        }

                        if (newOrAmend == 2)
                        {
                            ManageQuestions.ShowListOfQuestion(QuizmakerList);  // show list of questions
                            Console.WriteLine("Which question or answers for which question you would like to amend ?");
                            int questionToAmend = UIMethods.GetUserInputNum() - 1;                  //choice which question to amend
                            Console.WriteLine($"{QuizmakerList[questionToAmend].QuestionText}");

                            bool amending = true;
                            while (amending)
                            {
                                Console.WriteLine("Would you like to amend:\n" +
                                    " 1 - Question Text\n" +
                                    " 2 - Answers\n" +
                                    " 3 - Correct Answers\n");

                                int amendChoice = UIMethods.GetUserInputNum();
                                if (amendChoice == 1)
                                {
                                    Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
                                    QuizmakerList[questionToAmend].QuestionText = UIMethods.DisplayAskToTypeQuestionText();
                                    Console.WriteLine("Do you want to keep changing Question text, answers or correct answers ?");
                                    amending = UIMethods.MakeDecisionYorN();
                                    Console.Clear();
                                }
                                if (amendChoice == 2)
                                {
                                    bool amendOrRemoveAnswer = true;
                                    while (amendOrRemoveAnswer)
                                    {
                                        Console.WriteLine(
                                            "Press 1 to amend answer \n" +
                                            "Press 2 to remove answer");
                                        int choiceAmendOrRemoveAnswer = UIMethods.GetUserInputNum();
                                        if (choiceAmendOrRemoveAnswer == 1)
                                        {
                                            Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
                                            ManageQuestions.ShowListOfAnswers(QuizmakerList, questionToAmend);
                                            int answerToAmend = UIMethods.GetUserInputNum() - 1;
                                            Console.WriteLine("What this answer would you like to change to ?");
                                            QuizmakerList[questionToAmend].AnswersList[answerToAmend] = UIMethods.GetUserInput();
                                            Console.WriteLine("Would you like to change another answer");
                                            amendOrRemoveAnswer = UIMethods.MakeDecisionYorN();
                                        }

                                        if (choiceAmendOrRemoveAnswer == 2)
                                        {
                                            ManageQuestions.ShowListOfAnswers(QuizmakerList, questionToAmend);
                                            int answerToRemove = UIMethods.GetUserInputNum() - 1;
                                            QuizmakerList[questionToAmend].AnswersList.RemoveAt(answerToRemove);
                                            Console.WriteLine("Would you like to remove another answer ?");
                                            amendOrRemoveAnswer = UIMethods.MakeDecisionYorN();
                                        }
                                    }
                                }
                                if (amendChoice == 3 )
                                {

                                }

                                Console.WriteLine("Do you want to keep changing Question text, answers or correct answers ?");
                                amending = UIMethods.MakeDecisionYorN();

                            }
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