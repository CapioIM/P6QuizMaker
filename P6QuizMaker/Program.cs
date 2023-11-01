﻿namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.WelcomeText();

            List<Question> QuizmakerList = new List<Question>();

            bool addQuestions = true;
            while (addQuestions)
            {
                UIMethods.DisplayAskToTypeQuestionText();
                Question quizmaker = new Question();
                QuizmakerList.Add(quizmaker);
                quizmaker.QuestionText = UIMethods.GetUserInput();

                bool addMoreAnswers = true;
                while (addMoreAnswers)
                {
                    string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                    quizmaker.AnswersList.Add(answerText);

                    if (UIMethods.IsCorrectAnswer())
                    {
                        quizmaker.CorrectAnswersIndexList.Add(quizmaker.AnswersList.IndexOf(answerText));
                    }

                    addMoreAnswers = UIMethods.GetAdditionalAnswer();
                }
                addQuestions = UIMethods.GetAdditionalQuestions();
            }

        // in progress    FileOperations.writeXMLfile(QuizList);


            Console.ReadLine();
        }
    }
}