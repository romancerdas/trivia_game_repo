using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_Control : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}

