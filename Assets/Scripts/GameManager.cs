using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text textScore;

    void Start()
    {
        score = 0;
        textScore.text = "Score: " + score.ToString();
    }
    public void AddScore()
    {
        score++;
        textScore.text = "Score: " + score.ToString();
    }
}
