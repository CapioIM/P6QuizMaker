using System.ComponentModel.DataAnnotations;
using static P6QuizMaker.Options;

namespace P6QuizMaker
{
    internal class UIMethods
    {
        public static void DisplayTextAnswerNumber()
        {
            Console.WriteLine("Please type number associated with answer to modify.");
        }

        public static void DisplayPlayAnotherQuestionText()
        {
            Console.WriteLine("Would you like to play another question ?");
        }

        /// <summary>
        /// CW display questions and answers text from object in a list at index of randomQuesitonIndex
        /// </summary>
        /// <param name="QuizmakerList"> List with object Question </param>
        /// <param name="QuestionIndex"> random generated number variable </param>
        public static void DisplayQuestionAndAnswersToPlayer(List<Question> QuizmakerList, int QuestionIndex)
        {
            Console.WriteLine($"Please answer this Question: {QuizmakerList[QuestionIndex].QuestionText}");
            foreach (string answers in QuizmakerList[QuestionIndex].AnswersList)
            {
                Console.Write($"{QuizmakerList[QuestionIndex].AnswersList.IndexOf(answers) + 1}" + "-");
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
            int choiceNumber = 0;
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
            return choiceNumber; //not all code paths return a value
        }

        public static int GetUserInputNum(string askAQuestion)
        {
            Console.WriteLine(askAQuestion);
            bool convertToInt = false;
            while (!convertToInt)
            {
                convertToInt = int.TryParse(Console.ReadLine(), out int choiceNumber);
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
                case EnumChoice.ModificationOptions:
                    return Enum.GetNames(typeof(ModificationOptions)).Length;
                case EnumChoice.ModificationTarget:
                    return Enum.GetNames(typeof(ModificationTarget)).Length;
                default:
                    {
                        return 0;
                    }
            }
        }
        public static int GetUserInputNum(int enumChoice)
        {
            int choiceNumber = 0;
            bool convertToInt = false;
            while (!convertToInt)
            {
                convertToInt = int.TryParse(Console.ReadLine(), out choiceNumber);
                if (convertToInt && choiceNumber > 0 && choiceNumber <= enumChoice)
                {
                    return choiceNumber;
                }
                if (!convertToInt)
                {
                    Console.WriteLine($"Please enter number less than {enumChoice + 1}!");
                }
            }
            return choiceNumber;
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
            DisplayTextPressYesOrNo();
            string answer = Console.ReadLine().ToLower();
            char[] firstChar = answer.ToCharArray();
            return (firstChar[0] != 'n');
        }

        public static bool MakeDecisionYorN(string askAQuestion)
        {
            Console.WriteLine(askAQuestion);
            DisplayTextPressYesOrNo();
            string answer = Console.ReadLine().ToLower();
            char[] firstChar = answer.ToCharArray();
            return (firstChar[0] != 'n');
        }

        public static void DisplayTextPressYesOrNo()
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

        public static int DiplayGetNumberText(Question quizmaker)
        {
            Console.Write("Type answer Number : ");
            return GetUserInputNum(quizmaker.AnswersList.Count);
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

        public static void ShowListOfAnswers(Question quizmaker, ModificationTarget amendChoice)
        {
            if (amendChoice == ModificationTarget.AnswerList)
            {
                Console.WriteLine("Here's list of Answers: ");
                foreach (string answer in quizmaker.AnswersList)
                {
                    Console.WriteLine($"{quizmaker.AnswersList.IndexOf(answer) + 1}" + " " + answer);
                }
            }
            if (amendChoice == ModificationTarget.CorrectAnswerList)
            {
                Console.WriteLine("Here's list of Answers: ");
                foreach (string answer in quizmaker.AnswersList)
                {
                    Console.WriteLine($"{quizmaker.AnswersList.IndexOf(answer) + 1}" + " " + answer);
                }

                Console.WriteLine("Here's list of Correct Answers");
                foreach (int answer in quizmaker.CorrectAnswersList)
                {
                    Console.WriteLine($"{quizmaker.CorrectAnswersList.IndexOf(answer) + 1}" + " " + $"{quizmaker.AnswersList[answer]}");
                }
            }
        }

        public static void DisplayTextAddRemoveAmend()
        {
            Console.WriteLine(
                                 "Press 1 to Amend answer \n" +
                                 "Press 2 to Remove answer\n" +
                                 "Press 3 to Add answer");
        }
        public static void ModifyQuestionText(List<Question> QuizmakerList, int questionToAmend)
        {
            Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
            QuizmakerList[questionToAmend].QuestionText = UIMethods.DisplayAskToTypeQuestionText();
        }
    }
}
