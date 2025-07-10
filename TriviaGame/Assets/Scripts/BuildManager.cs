using UnityEngine;
using TMPro;
public class BuildManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float score = 0;
    public TextMeshProUGUI score_text;
    void Awake()
    {
        score_text.text = "Score: 000 ";
    }
    
    void Update()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        score_text.text = "Score: " + score;
    }

}
