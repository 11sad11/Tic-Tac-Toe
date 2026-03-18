public class GameManager : Singleton<GameManager>
{
    protected override bool _isPersistent => false;

    public byte _pointsPlayer1 { get; private set; }
    public byte _pointsPlayer2 { get; private set; }


    public void ResetPoints()
    {
        _pointsPlayer1 = 0;
        _pointsPlayer2 = 0;
    }

    public void AddPoint(Winner winner)
    {
        if (winner == Winner.Player1) _pointsPlayer1++;
        else if (winner == Winner.Player2) _pointsPlayer2++;
        print("Player1: " + _pointsPlayer1);
        print("Player: " + _pointsPlayer2);
    }
}