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

    void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && other.gameObject.CompareTag(tagFilter)) return;
        onTriggerEnter.Invoke();
        Debug.Log("Enter");
        new_location = location.transform.position + new Vector3(0, 0, 25);
        GameObject platform = Instantiate(prefab, new_location, Quaternion.identity);
        managment.score += 100;
    }

    void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && other.gameObject.CompareTag(tagFilter)) return;
        onTriggerExit.Invoke();
        Debug.Log("Exit");
        Destroy(prefab);
    }
}