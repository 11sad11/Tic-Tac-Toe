using TMPro;
using UnityEngine;

public class ScoreChange : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerScore1 = null;
    [SerializeField] private TMP_Text _playerScore2 = null;

    public void OnScoreChanged(byte player1, byte player2)
    {
        _playerScore1.text = player1.ToString();
        _playerScore2.text = player2.ToString();
    }

    private void Start()
    {
        OnScoreChanged(GameManager.Instance._pointsPlayer1, GameManager.Instance._pointsPlayer2);
        GameManager.Instance.ScoreChanged += OnScoreChanged;
    }


    private void OnDisable() => GameManager.Instance.ScoreChanged -= OnScoreChanged;
}