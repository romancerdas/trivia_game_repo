using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BuildManager : MonoBehaviour
{
    public float score = 0;
    public TextMeshProUGUI score_text;
    public GameObject canvas_main;
    public GameObject canvas_menu;
    [Header("Answer Placement")]
    public bool left = false;
    public bool right = false;
    public bool center = false;

    [Header("Health System")]
    public Image[] hearts;       
    public int maxHealth = 3;
    private int currentHealth;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;  

    void Awake()
    {
        score_text.text = "Score: 0";
        currentHealth = maxHealth;
        UpdateHearts();
    }

    void Update()
    {
        UpdateScore();
    }

    public void RandomAnswer()
    {
        int randomIndex = Random.Range(0, 3);
        left = right = center = false;
        if (randomIndex == 0) center = true;
        if (randomIndex == 1) left = true;
        if (randomIndex == 2) right = true;
    }

    public void UpdateScore()
    {
        score_text.text = "Score: " + score;
    }

    public void LoseHealth()
{
    if (currentHealth > 0)
    {
        currentHealth--;
        UpdateHearts();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }
}

        void UpdateHearts()
    {
    for (int i = 0; i < hearts.Length; i++)
    {
        if (i >= currentHealth)
        {
            hearts[i].enabled = false;
        }
        else
        {
            hearts[i].enabled = true;
        }
    }
}


    void GameOver()
    {
        SceneManager.LoadScene(2);
        
    }
    public void Menu()
    {
        Time.timeScale = 0f; // pause the game
        canvas_menu.SetActive(true);
        canvas_main.SetActive(false);
    }
    public void Close_Menu()
    {
        Time.timeScale = 1f;
        canvas_menu.SetActive(false);
        canvas_main.SetActive(true);
    }
}
