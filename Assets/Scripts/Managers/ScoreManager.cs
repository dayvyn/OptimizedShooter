using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    [SerializeField] Text text;


    void Awake ()
    {
        score = 0;
    }

    private void Start()
    {
        EnemyHealth.enemyDead.AddListener(UpdateScore);
    }


    public void UpdateScore (int score)
    {
        ScoreManager.score += score;
        text.text = "Score: " + ScoreManager.score;
    }
}
