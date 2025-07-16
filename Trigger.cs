using System;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public GameObject prefab;
    public BuildManager managment;
    public GameObject location;
    private Vector3 new_location;

    [Header("Tag Filtering")]
    [SerializeField] string tagFilter = "Player";

    [Header("Trigger Events")]
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    [Header("Barrier Logic")]
    public bool isCorrect;

    [Header("Sounds")]
    public AudioClip correctSound;
    public AudioClip wrongSound;

    void Awake()
    {
        Renderer cubeRenderer = GetComponent<Renderer>();
        string tag = gameObject.tag;

        if (tag == "Left" && managment.left)
            SetCorrect(true, cubeRenderer);
        else if (tag == "Right" && managment.right)
            SetCorrect(true, cubeRenderer);
        else if (tag == "Center" && managment.center)
            SetCorrect(true, cubeRenderer);
        else
            SetCorrect(false, cubeRenderer);
    }

    void SetCorrect(bool correct, Renderer renderer)
    {
        isCorrect = correct;
        renderer.material.color = correct ? Color.green : Color.red;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.CompareTag(tagFilter)) return;

        onTriggerEnter.Invoke();
        Debug.Log("Enter");

        new_location = location.transform.position + new Vector3(0, 0, 25);
        Instantiate(prefab, new_location, Quaternion.identity);

        if (isCorrect)
        {
            managment.score += 100;
            PlaySoundAndLetItFinish(correctSound);
        }
        else
        {
            managment.LoseHealth();
            PlaySoundAndLetItFinish(wrongSound);
        }

        Destroy(gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.CompareTag(tagFilter)) return;
        onTriggerExit.Invoke();
        Debug.Log("Exit");
    }

    void PlaySoundAndLetItFinish(AudioClip clip)
    {
        if (clip == null) return;

        GameObject tempAudio = new GameObject("TempAudio");
        tempAudio.transform.position = transform.position;
        AudioSource source = tempAudio.AddComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        Destroy(tempAudio, clip.length + 0.1f);
    }
}
