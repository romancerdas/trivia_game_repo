using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public GameObject prefab;
    public BuildManager managment;
    public GameObject location;
    private Vector3 new_location;

    [SerializeField] string tagFilter = "Player";
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    public bool isCorrect;

    void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.CompareTag(tagFilter)) return;

        onTriggerEnter.Invoke();
        Debug.Log("Enter");

        new_location = location.transform.position + new Vector3(0, 0, 20);
        Instantiate(prefab, new_location, Quaternion.identity);

        if (isCorrect)
        {
            managment.score += 100;
            Debug.Log("✅ Correct!");
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            managment.LoseHealth();
            Debug.Log("❌ Wrong!");
            GetComponent<Renderer>().material.color = Color.red;
        }

        managment.UpdateScore();
    }

    void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.CompareTag(tagFilter)) return;

        onTriggerExit.Invoke();
        Debug.Log("Exit");

        Destroy(gameObject);
    }
}
