using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    private int _goodScore;
    private int _badScore;

    public void CheckScore(out int goodScore, out int badScore)
    {
        goodScore = _goodScore;
        badScore = _badScore;
    }

    private void Start()
    {
        _goodScore = 1;
        _badScore = 2;
        CheckScore(out var test, out var test2);
        print("good"+test+"bad"+test2);
    }
}
