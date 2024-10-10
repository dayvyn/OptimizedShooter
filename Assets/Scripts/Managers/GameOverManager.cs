using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;
    public static readonly int GameOver = Animator.StringToHash("GameOver");

    Animator anim;
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
        PlayerHealth.PlayerDamagedHealth.AddListener(CheckGameOver);
    }

    void CheckGameOver(int health)
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger(GameOver);
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
