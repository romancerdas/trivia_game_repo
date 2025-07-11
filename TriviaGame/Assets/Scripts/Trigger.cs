using System;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public GameObject prefab;
    public BuildManager managment;
    public GameObject location;
    private Vector3 new_location;
    [SerializeField] string tagFilter;

    [SerializeField] UnityEvent onTriggerEnter;

    [SerializeField] UnityEvent onTriggerExit;
    public bool isCorrect;
    void Awake()
    {
        Renderer cubeRenderer = GetComponent<Renderer>();
        
        if (gameObject.CompareTag("Left"))
        {
            if (managment.left)
            {
                isCorrect = true;
                cubeRenderer.material.color = Color.green;
            }
            else
            {
                isCorrect= false;
                cubeRenderer.material.color = Color.red;
            }
        }
        if (gameObject.CompareTag("Right"))
        {
            if (managment.right)
            {
                isCorrect = true;
                cubeRenderer.material.color = Color.green;
            }
            else
            {
                isCorrect = false;
                cubeRenderer.material.color = Color.red;
            }
        }
        if (gameObject.CompareTag("Center"))
        {
            if (managment.center)
            {
                isCorrect = true;
                cubeRenderer.material.color = Color.green;
            }
            else
            {
                isCorrect = false;
                cubeRenderer.material.color = Color.red;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && other.gameObject.CompareTag(tagFilter)) return;
        onTriggerEnter.Invoke();
        Debug.Log("Enter");
        new_location = location.transform.position + new Vector3(0, 0, 25);
        GameObject platform = Instantiate(prefab, new_location, Quaternion.identity);
        if (isCorrect)
        {
            managment.score += 100;
        }
        if (!isCorrect)
        {
            managment.score -= 100;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && other.gameObject.CompareTag(tagFilter)) return;
        onTriggerExit.Invoke();
        Debug.Log("Exit");
        Destroy(prefab);
    }
}