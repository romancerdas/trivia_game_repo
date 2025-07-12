using UnityEngine;
using TMPro;
public class BuildManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float score = 0;
    public TextMeshProUGUI score_text;
    public bool left = false;
    public bool right = false;
    public bool center = false;
    public GameObject canvas_menu;
    public GameObject canvas_main;
    void Awake()
    {
        score_text.text = "Score: 000 ";
        RandomAnswer();
    }
    
    void Update()
    {
        UpdateScore();
    }
    public void RandomAnswer()
    {
        int randomIndex = Random.Range(0, 3);
        if (randomIndex == 0)
        {
            left = false;
            right = false;
            center = true;
        }
        if (randomIndex == 1)
        {
            left = true;
            right = false;
            center = false;
        }
        if (randomIndex == 2)
        {
            left = false;
            right = true;
            center = false;
        }
    }
    public void UpdateScore()
    {
        score_text.text = "Score: " + score;
    }
    public void Menu()
    {
        canvas_menu.SetActive(true);
        canvas_main.SetActive(false);
    }
    public void Close_Menu()
    {
        canvas_menu.SetActive(false);
        canvas_main.SetActive(true);
    }
}
