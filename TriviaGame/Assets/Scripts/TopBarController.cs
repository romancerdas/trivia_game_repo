using TMPro;
using UnityEngine;

public class TopBarController : MonoBehaviour
{
    public static TopBarController Instance;

    public TextMeshProUGUI questionLabel;

    private void Awake()
    {
        // Singleton pattern so other scripts can access it
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetQuestion(string questionText)
    {
        if (questionLabel != null)
        {
            questionLabel.text = questionText;
        }
        else
        {
            Debug.LogWarning("Question Label is not assigned!");
        }
    }
}
