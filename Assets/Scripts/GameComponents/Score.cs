public static class Score
{
    private static int _number;

    public static int Number { get => _number; set => _number = value; }

    public static void Reset() => _number = 0;
}
