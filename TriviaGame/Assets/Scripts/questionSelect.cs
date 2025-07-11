using UnityEngine;

public class questionSelect : MonoBehaviour
{
    public BuildManager management;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        management.RandomAnswer();
    }

}
