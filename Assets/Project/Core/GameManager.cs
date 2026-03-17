public class GameManager : Singleton<GameManager>
{
    public int _pointsPlayer1 { get; private set; }
    public int _pointsPlayer2 { get; private set; }


    public void ResetPoints()
    {
        _pointsPlayer1 = 0;
        _pointsPlayer2 = 0;
    }

    public void AddPoint(byte index)
    {
        if (index == 1) _pointsPlayer1++;
        else if (index == 2) _pointsPlayer2++;
    }
}