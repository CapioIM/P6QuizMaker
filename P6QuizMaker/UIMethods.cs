using static System.Formats.Asn1.AsnWriter;

namespace P6QuizMaker
{
    internal class UIMethods
    {

        /// <summary>
        /// Displays text : Please type number associated with answer.
        /// </summary>
        public static void DisplayPlayAnswerNumber()
        {
            Console.WriteLine("Please type number associated with answer.");
        }

        /// <summary>
        /// Displays text : Would you like to play another question ?
        /// </summary>
        public static void DisplayPlayAnotherQuestionText()
        {
            Console.WriteLine("Would you like to play another question ?");
        }

        /// <summary>
        /// Displays text : Welcome to Quiz Maker Program !\n" + You can add questions with answers or you can play Quizmaker and answer questions.
        /// </summary>
        public static void WelcomeText()
        {
            ClearConcole();
            Console.WriteLine("                 Welcome to Quiz Maker Program !\n" +
                " You can add questions with answers or you can play Quizmaker and answer questions.\n");
        }

        /// <summary>
        /// Displays text : Welcome to Quiz Maker Game !\n" + "You are asked question and you need to press number to pick correct answer!
        /// </summary>
        public static void DisplayGameDiscription()
        {
            Console.WriteLine("                 Welcome to Quiz Maker Game !\n" +
                "You are asked question and you need to press number to pick correct answer!");
        }

        /// <summary>
        /// Displays text : Press number (pick option)
        /// </summary>
        public static void DisplayGameModeChoice()
        {
            Console.WriteLine(
                "Press 1 to Manage Questions\n" +
                "Press 2 to Play Quizmaker\n" +
                "Press 3 to Exit Programm"
                );
        }

        /// <summary>
        /// parses user input, which is not greater than provided int amount
        /// </summary>
        /// <param name="enumChoice"> Enum name </param>
        /// <returns> number more than 0 , and less than provided int </returns>
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
                if (!convertToInt || (convertToInt && (choiceNumber <= 0 || choiceNumber > enumChoice)))
                {
                    Console.WriteLine($"Please enter number less than {enumChoice + 1}!");
                    convertToInt = false;
                }
            }
            return choiceNumber;
        }

        /// <summary>
        /// user has to input...
        /// </summary>
        /// <returns> value user input </returns>
        public static string GetUserInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Ask user to input data
        /// </summary>
        /// <returns> input data </returns>
        public static string GetQuestionText()
        {
            Console.Write("Please write question for QuizMaker ! : ");
            return GetUserInput();
        }

        /// <summary>
        /// ask user input, n = false , anything else = true
        /// </summary>
        /// <returns> n = false , anything else = true </returns>
        public static bool MakeDecisionYorN()
        {
            DisplayTextPressYesOrNo();
            string answer = Console.ReadLine().ToLower();
            char[] firstChar = answer.ToCharArray();
            return (firstChar[0] != 'n');
        }

        /// <summary>
        /// displays text : Press Y - if Yes or N - if No! : 
        /// </summary>
        public static void DisplayTextPressYesOrNo()
        {
            Console.Write("Press Y - if Yes or N - if No! : ");
        }

        /// <summary>
        /// ask if user wants to input additional data
        /// </summary>
        /// <returns> user want/don't want to input data </returns>
        public static bool GetAdditionalAnswer()
        {
            Console.Write("Would you like to add additional Answer ? : ");
            return MakeDecisionYorN();
        }

        /// <summary>
        /// Ask user to input number 
        /// </summary>
        /// <param name="questionObject"> object (for answerList count amount) </param>
        /// <returns> valid number between 0 -  list count </returns>
        public static int DiplayGetNumberText(QuestionsAndAnswers questionObject)
        {
            Console.Write("Type answer Number : ");
            return GetUserInputNum(questionObject.AnswersListCount);
        }

        /// <summary>
        /// Display text : Type answer to be added: and return user input
        /// </summary>
        /// <returns> user input </returns>
        public static string GetAndDisplayTypeAnswerText()
        {
            Console.Write("Type answer to be added: ");
            return GetUserInput();
        }

        /// <summary>
        /// Display text : What this answer would you like to change to ?
        /// </summary>
        public static void DisplayTextAskWhatToChange()
        {
            Console.WriteLine("What this answer would you like to change to ?");
        }

        /// <summary>
        /// is this answer Correct ?
        /// </summary>
        /// <returns> bool </returns>
        public static bool IsCorrectAnswer()
        {
            Console.Write("Is this correct answer ? : ");
            return MakeDecisionYorN();
        }

        /// <summary>
        /// WriteLine List with object Question text
        /// </summary>
        /// <param name="list"> list with/of objects </param>
        public static void ShowListOfQuestion(List<QuestionsAndAnswers> list)
        {
            foreach (QuestionsAndAnswers question in list)
            {
                Console.WriteLine($"{list.IndexOf(question) + 1}" + " " + question.QuestionText);
            }
        }

        /// <summary>
        /// Display text , options to Amend,Remove,Add,Return to previous menu.
        /// </summary>
        public static void DisplayTextAddRemoveAmend()
        {
            Console.WriteLine(
                                 "Press 1 to Amend  \n" +
                                 "Press 2 to Remove \n" +
                                 "Press 3 to Add \n" +
                                 "Press 4 to Return to previous menu");
        }

        /// <summary>
        /// replace QuestionText data with user input
        /// </summary>
        /// <param name="question"> Object reference </param>
        public static void ModifyQuestionText(QuestionsAndAnswers question)
        {
            Console.WriteLine($"Question you are changing is : {question.QuestionText}");
            question.QuestionText = UIMethods.GetQuestionText();
        }

        /// <summary>
        /// Display Text: Type number associated with question to Amend/Remove!
        /// </summary>
        /// <param name="modifyOrRemove"></param>
        public static void DisplayTextQuestionToRemoveOrAmend(ModificationOptions modifyOrRemove)
        {
            Console.WriteLine($"Type number associated with question to {modifyOrRemove}!");
        }

        /// <summary>
        /// Converts int in to Enum
        /// </summary>
        /// <param name="modificationTargetChoice"> provide int </param>
        /// <returns> returns enum based on number provided </returns>
        public static ModificationTarget ModificationTargetChoice(int modificationTargetChoice)
        {
            switch (modificationTargetChoice)
            {
                case 1:
                    return ModificationTarget.Questions;
                case 2:
                    return ModificationTarget.AnswerList;
                case 3:
                    return ModificationTarget.CorrectAnswerList;
                case 5:
                    return ModificationTarget.SaveChanges;
                default:
                    return ModificationTarget.Exit;
            }
        }

        /// <summary>
        /// Converts int in to Enum
        /// </summary>
        /// <param name="modificationOptionChoice"> provide int </param>
        /// <returns> returns enum based on number provided </returns>
        public static ModificationOptions ModificationOptionChoice(int modificationOptionChoice)
        {
            switch (modificationOptionChoice)
            {
                case 1:
                    return ModificationOptions.Amend;
                case 2:
                    return ModificationOptions.Remove;
                case 3:
                    return ModificationOptions.Add;
                default:
                    return ModificationOptions.Exit;
            }
        }
        /// <summary>
        /// Converts int in to Enum
        /// </summary>
        /// <param name="manageOrPlay"> provide int  </param>
        /// <returns> returns enum based on number provided </returns>
        public static GameMode GameModeChoice(int manageOrPlay)
        {
            switch (manageOrPlay)
            {
                case 0:
                    return GameMode.Manage;
                case 1:
                    return GameMode.Play;
                default:
                    return GameMode.Exit;
            }
        }
        /// <summary>
        /// Display List of object.QuestionText data, user choose(input number) object based on list of object, display list of that object based on 'ModificationTarget enum option'
        /// </summary>
        /// <param name="QuizmakerList"> List with objects </param>
        /// <param name="modificationTarget"> enum option </param>
        /// <returns> returns user input number of object in List </returns>
        public static int ShowAnswersListInfo(List<QuestionsAndAnswers> QuizmakerList, ModificationTarget modificationTarget)
        {
            ShowListOfQuestion(QuizmakerList);
            Console.WriteLine($"Answers for which question would you like to modify?");
            int questionToAmend = GetUserInputNum(QuizmakerList.Count) - 1;
            UIMethods.DisplayAnswers(QuizmakerList[questionToAmend]);

            if (IsCorrectAnswerList(modificationTarget))
            {
                UIMethods.DisplayCorrectAnswers(QuizmakerList[questionToAmend]);
            }

            Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
            return questionToAmend;
        }

        /// <summary>
        /// Display Text of options , await for user input(choice of option) , return user choice enum
        /// </summary>
        /// <returns> return user choice </returns>
        public static ModificationOptions ShowModificationOptionsInfo()
        {
            int countEnum = Logic.GetEnumLengthByType(EnumChoice.ModificationOptions);
            UIMethods.DisplayTextAddRemoveAmend();
            int addRemoveAmendUserChoice = UIMethods.GetUserInputNum(countEnum);
            ModificationOptions modificationOptions = UIMethods.ModificationOptionChoice(addRemoveAmendUserChoice);
            return modificationOptions;
        }

        /// <summary>
        /// Display text of target for options
        /// </summary>
        public static void DisplayOptionsTargetToModify()
        {
            Console.WriteLine("What would you like to amend:\n" +
                               " 1 - Questions \n" +
                               " 2 - Answers\n" +
                               " 3 - Correct Answers\n" +
                               " 4 - Return to game mode choice\n" +
                               " 5 - Save Changes");
        }

        /// <summary>
        /// clears console window
        /// </summary>
        public static void ClearConcole()
        {
            Console.Clear();
        }

        /// <summary>
        /// check if enum provided is correctAnswer list
        /// </summary>
        /// <param name="modificationTarget"> provide enum of target </param>
        /// <returns> true if enum is correctAnsewerList </returns>
        private static bool IsCorrectAnswerList(ModificationTarget modificationTarget)
        {
            if (modificationTarget == ModificationTarget.CorrectAnswerList)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// takes list of object and display whole list
        /// </summary>
        public static void DisplayAnswers(QuestionsAndAnswers questionData)
        {
            Console.WriteLine("Here's list of Answers: ");
            foreach (string answer in questionData.AnswersList)
            {
                Console.WriteLine($"{questionData.AnswersList.IndexOf(answer) + 1}" + " " + answer);
            }
        }

        /// <summary>
        /// takes list of object and display whole list
        /// </summary>
        public static void DisplayCorrectAnswers(QuestionsAndAnswers questionData)
        {
            Console.WriteLine("Here's list of Correct Answers");
            foreach (int answer in questionData.CorrectAnswersList)
            {
                Console.WriteLine($"Answer Nr: {questionData.CorrectAnswersList.IndexOf(answer) + 1} Description of answer: {questionData.AnswersList[answer]} .");
            }
        }

        /// <summary>
        /// Displays text : This answer is already in the list
        /// </summary>
        public static void DisplayCorrectAnswerExists()
        {
            Console.WriteLine("This answer is already in the list");

        }

        /// <summary>
        /// Display Text: Type number of answer you want to {modificationOptions}!
        /// </summary>
        /// <param name="modificationOptions"> enum text variable </param>
        public static void DisplayTypeAnswerNumberToModify(ModificationOptions modificationOptions)
        {
            Console.WriteLine($"Type number of answer you want to {modificationOptions}!");
        }

        /// <summary>
        /// Display Game Question Text to player
        /// </summary>
        /// <param name="questionPlaying"> Question object reference </param>
        public static void DisplayQuestionTextToPlayer(QuestionsAndAnswers questionPlaying)
        {
            Console.WriteLine($"Please answer this Question: {questionPlaying.QuestionText}");
        }

        /// <summary>
        /// Display score text
        /// </summary>
        /// <param name="score"> int current score var </param>
        public static void DisplayUpdatedScore(int score)
        {
            Console.WriteLine($"Your score: {score}");
        }
    }
}


