namespace P6QuizMaker
{
    public class Score
    {
        public Score()
        {
            _score = 0;
        }
        private int _score {  get; set; }

        public int ScoreCount
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }
    }
}
