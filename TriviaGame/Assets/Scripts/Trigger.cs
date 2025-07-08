using System;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] string tagFilter;

    [SerializeField] UnityEvent onTriggerEnter;

    [SerializeField] UnityEvent onTriggerExit;

    void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && other.gameObject.CompareTag(tagFilter)) return;
        onTriggerEnter.Invoke();
        Debug.Log("Enter");
    }

    void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && other.gameObject.CompareTag(tagFilter)) return;
        onTriggerExit.Invoke();
        Debug.Log("Exit");
    }
}