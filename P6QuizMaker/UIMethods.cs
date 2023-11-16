using System.ComponentModel.DataAnnotations;
using static P6QuizMaker.Options;

namespace P6QuizMaker
{
    internal class UIMethods
    {
        public static void DisplayTextAnswerNumber()
        {
            Console.WriteLine("Please type number associated with answer");
        }

        public static void DisplayPlayAnotherQuestionText()
        {
            Console.WriteLine("Would you like to play another question ?");
        }

        /// <summary>
        /// CW display questions and answers text from object in a list at index of randomQuesitonIndex
        /// </summary>
        /// <param name="QuizmakerList"> List with object Question </param>
        /// <param name="randomQuestionIndex"> random generated number variable </param>
        public static void DisplayQuestionAndAnswersToPlayer(List<Question> QuizmakerList, int randomQuestionIndex)
        {
            Console.WriteLine($"Please answer this Question: {QuizmakerList[randomQuestionIndex].QuestionText}");
            foreach (string answers in QuizmakerList[randomQuestionIndex].AnswersList)
            {
                Console.Write($"{QuizmakerList[randomQuestionIndex].AnswersList.IndexOf(answers) + 1}" + "-");
                Console.WriteLine(answers);
            }
        }
        public static void WelcomeText()
        {
            Console.WriteLine("                 Welcome to Quiz Maker Program !\n" +
                " You can add questions with answers or you can play Quizmaker and answer questions.\n");
        }

        public static void DisplayChoiceManagePlay()
        {
            Console.WriteLine(
                "Press 1 to manage Questions\n" +
                "Press 2 to Play Quizmaker"
                );
        }

        /// <summary>
        /// Asks user to enter integer, untill number is entered
        /// </summary>
        /// <returns> user entered integer </returns>
        public static int GetUserInputNum()
        {
            int choiceNumber;
            bool convertToInt = false;
            while (!convertToInt)
            {
                convertToInt = int.TryParse(Console.ReadLine(), out choiceNumber);
                if (convertToInt)
                {
                    return choiceNumber;
                }
                else
                {
                    Console.WriteLine("Please enter Number !");
                }
            }
            return 0; //not all code paths return a value
        }

        /// <summary>
        /// Choice of enum to provide amount of items in enum
        /// </summary>
        /// <param name="enumChoice"></param>
        /// <returns> int of amount of items in enum </returns>
        public static int EnumLength(EnumChoice enumChoice)
        {
            switch (enumChoice)
            {
                case Options.EnumChoice.ModificationOptions:
                    return Enum.GetNames(typeof(ModificationOptions)).Length;
                case Options.EnumChoice.ModificationTarget:
                    return Enum.GetNames(typeof(ModificationTarget)).Length;
                default:
                    {
                        return 0;
                    }
            }
        }
        public static int GetUserInputNum(int enumChoice)
        {
            int choiceNumber;
            bool convertToInt = false;
            while (!convertToInt)
            {
                convertToInt = int.TryParse(Console.ReadLine(), out choiceNumber);
                if (convertToInt && choiceNumber > 0 && choiceNumber < enumChoice +1)
                {
                    return choiceNumber;
                }
                if (!convertToInt)
                {
                    Console.WriteLine($"Please enter number less than {enumChoice+1}!");
                }
            }
            return 0; //not all code paths return a value
        }


        public static string GetUserInput()
        {
            return Console.ReadLine();
        }
        public static string DisplayAskToTypeQuestionText()
        {
            Console.Write("Please write question for QuizMaker ! : ");
            return GetUserInput();
        }

        public static bool MakeDecisionYorN()
        {
            PrintPressYesOrNo();
            string answer = Console.ReadLine().ToLower();
            char[] firstChar = answer.ToCharArray();
            return (firstChar[0] != 'n');
        }

        public static void PrintPressYesOrNo()
        {
            Console.Write("Press Y - if Yes or N - if No! : ");
        }

        public static bool GetAdditionalQuestions()
        {
            Console.WriteLine("Would you like to add Questions ?");
            return MakeDecisionYorN();
        }

        public static bool GetNewQuestion()
        {
            Console.WriteLine("Do you want to add new Question ?");
            return MakeDecisionYorN();
        }
        public static bool GetAdditionalAnswer()
        {
            Console.Write("Would you like to add additional Answer ? : ");
            return MakeDecisionYorN();
        }

        public static int DiplayGetNumberText()
        {
            Console.Write("Type answer Number : ");
            return GetUserInputNum();
        }

        public static string GetAndDisplayTypeAnswerText()
        {
            Console.Write("Type answer to be added: ");
            return GetUserInput();
        }

        public static bool IsCorrectAnswer()
        {
            Console.Write("Is this correct answer ? : ");
            return MakeDecisionYorN();
        }


        /// <summary>
        /// WriteLine List with object Question text
        /// </summary>
        /// <param name="list"> list with/of objects </param>
        public static void ShowListOfQuestion(List<Question> list)
        {
            foreach (Question question in list)
            {
                Console.WriteLine($"{list.IndexOf(question) + 1}" + " " + question.QuestionText);
            }
            Console.WriteLine("Which question or answers for which question you would like to amend ?");
        }

        public static void ShowListOfAnswers(List<Question> QuizmakerList, int questionToAmend, ModificationTarget amendChoice)
        {
            if (amendChoice == Options.ModificationTarget.AnswerList)
            {
                Console.WriteLine("Here's list of Answers: ");
                foreach (string answer in QuizmakerList[questionToAmend].AnswersList)
                {
                    Console.WriteLine($"{QuizmakerList[questionToAmend].AnswersList.IndexOf(answer) + 1}" + " " + answer);
                }
            }
            if (amendChoice == Options.ModificationTarget.CorrectAnswerList)
            {
                Console.WriteLine("Here's list of Answers: ");
                foreach (string answer in QuizmakerList[questionToAmend].AnswersList)
                {
                    Console.WriteLine($"{QuizmakerList[questionToAmend].AnswersList.IndexOf(answer) + 1}" + " " + answer);
                }

                Console.WriteLine("Here's list of Correct Answers");
                foreach (int answer in QuizmakerList[questionToAmend].CorrectAnswersList)
                {
                    Console.WriteLine($"{answer}  {QuizmakerList[questionToAmend].AnswersList[answer]}");
                }
            }
        }

        public static void DisplayTextAddRemoveAmend()
        {
            Console.WriteLine(
                                 "Press 1 to amend answer \n" +
                                 "Press 2 to remove answer\n" +
                                 "Press 3 to add answer");
        }

    }
}
