using System.ComponentModel.Design;

namespace P6QuizMaker
{
    internal class UIMethods
    {

        public static void DisplayQuestionAndAnswers(List<Question> QuizmakerList, int randomQuestionIndex)
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
                " You will be asked to type questions and answers or to answer these questions.\n" +
                " After you will enter answers program will ask you to pick if answer is correct.\n" +
                " And lastly program will bring random question with answers.\n");
        }

        public static void DisplayChoiceManagePlay()
        {
            Console.WriteLine("Press 1 to manage Questions\n" +
                "Press 2 to Play Quizmaker");
        }

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
        public static void WelcomeAddQuestionsChoice()
        {
            Console.WriteLine("Type Question to add to list of Questions!");
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
            Console.WriteLine("Would you like to add another Question ?");
            return MakeDecisionYorN();
        }
        public static bool GetAdditionalAnswer()
        {
            Console.WriteLine("Would you like to add additional Answer ?");
            bool addAnswer = MakeDecisionYorN();
            return addAnswer;
        }
        public static string GetAndDisplayTypeAnswerText()
        {
            Console.Write("Type answer : ");
            return GetUserInput();
        }
        public static bool IsCorrectAnswer()
        {
            Console.WriteLine("Is this correct answer ? : ");
            return MakeDecisionYorN();
        }
    }
}
