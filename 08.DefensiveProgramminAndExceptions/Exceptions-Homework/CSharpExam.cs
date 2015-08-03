namespace ExceptionsHomework
{
    using System;

    public class CSharpExam : Exam
    {
        public const int MinScore = 0;
        public const int MaxScore = 100;

        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < MinScore || value > MaxScore)
                {
                    throw new ArgumentOutOfRangeException(string.Format(
                        "The Score is {0} and is out of range [{1}-{2}]",
                        this.Score,
                        MinScore,
                        MaxScore));
                }

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
        }
    }
}