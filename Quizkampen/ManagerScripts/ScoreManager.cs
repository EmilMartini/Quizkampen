namespace Quizkampen
{
    class ScoreManager
    {
        private int currentScore;

        public void IncreaseScore()
        {
            currentScore += 1;
        }
        public int GetScore()
        {
            return currentScore;
        }
        public void ResetScore()
        {
            currentScore = 0;
        }
    }
}
