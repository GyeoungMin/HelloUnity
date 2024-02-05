
public class AppleCatchGameManager 
{
    public static int endScore = 0;
    public static int endApple = 0;
    public static int endBomb = 0;
    public static bool timeUp;

    public static void AppleCatchResult(float score, int apple, int bomb)
    {
        endApple = apple;
        endBomb = bomb;
        endScore = (int)score;
    }

    public static int[] GetResult()
    {
        int[] result = new int[3];
        result[0] = endApple;
        result[1] = endBomb;
        result[2] = endScore;
        return result;
    }

}
