public class GameManager : Singleton<GameManager>
{
    public int pointsPlayer1 { get; private set; }
    public int pointsPlayer2 { get; private set; }


    public void ResetPoints()
    {
        pointsPlayer1 = 0;
        pointsPlayer2 = 0;
    }

    public void AddPoint(byte index)
    {
        if (index == 1) pointsPlayer1++;
        else if (index == 2) pointsPlayer2++;
    }
}