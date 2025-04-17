using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGame : MonoBehaviour
{
    public GameManager gameManager;
    public Audio audio;
    public TextMeshProUGUI textMeshPro;
    private int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        { 
            score++;
            textMeshPro.text = score.ToString();
            audio.PlayCoinSound();
            Destroy(collision.gameObject);
            if(score == 4)
            {
                SceneManager.LoadScene("Menu");
            }
        } else if (collision.CompareTag("Enemy"))
        {
            audio.PlayDeadSound();
            gameManager.ShowGameOver();
        }
    }
}
