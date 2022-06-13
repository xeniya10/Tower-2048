public static class Score
{
	private static int ScoreNumber;

	public static void SetScore(int score)
	{
		ScoreNumber = score;
	}

	public static void ResetScore()
	{
		ScoreNumber = 0;
	}

	public static int GetScore()
	{
		return ScoreNumber;
	}
}
