using System;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    public event Action<byte, byte> ScoreChanged;
    protected override bool _isPersistent => false;

    public byte _pointsPlayer1 { get; private set; }
    public byte _pointsPlayer2 { get; private set; }


    private void Start()
    {
        InputSystem.actions["Exit"].canceled += OnExit;
        ScoreChanged?.Invoke(_pointsPlayer1, _pointsPlayer2);
    }

    private void OnDestroy() => InputSystem.actions["Exit"].canceled -= OnExit;

    public void ResetPoints()
    {
        _pointsPlayer1 = 0;
        _pointsPlayer2 = 0;
        ScoreChanged?.Invoke(_pointsPlayer1, _pointsPlayer2);
    }

    public void AddPoint(Winner winner)
    {
        if (winner == Winner.Player1) _pointsPlayer1++;
        else if (winner == Winner.Player2) _pointsPlayer2++;
        ScoreChanged?.Invoke(_pointsPlayer1, _pointsPlayer2);
    }

    private void OnExit(InputAction.CallbackContext action)
    {
        SceneLoader.Instance.LoadMainMenu();
    }
}