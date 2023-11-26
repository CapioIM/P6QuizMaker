namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> QuizmakerList = new List<Question>();

            bool interestedToUseProgramm = true;
            while (interestedToUseProgramm)
            {
                UIMethods.WelcomeText();                                                                              //welcome text
                UIMethods.DisplayChoiceManagePlay();
                int manageOrPlay = UIMethods.GetUserInputNum(Enum.GetNames(typeof(GameMode)).Length) - 1;             //choice to manage quesitons or play
                GameMode gameModeChoice = UIMethods.GameModeChoice(manageOrPlay);

                if (gameModeChoice == GameMode.Manage)
                {
                    ManageQuestions.Manage(QuizmakerList);
                }

                if (gameModeChoice == GameMode.Play)
                {
                    Logic.Play(QuizmakerList);
                    UIMethods.DisplayPlayAnotherQuestionText();
                    interestedToUseProgramm = UIMethods.MakeDecisionYorN();
                }
            }
        }
    }
}




