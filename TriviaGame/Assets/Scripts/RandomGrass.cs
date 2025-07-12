using UnityEngine;

public class RandomGrass : MonoBehaviour
{
    public Sprite[] grassSprites;        // Your 3 grass sprites
    public GameObject grassPrefab;       // Prefab with a SpriteRenderer
    public int grassCount = 100;         // Number of grass clumps
    public Vector3 areaSize = new Vector3(10, 0, 10); // Width & depth of spawn area

    public Transform platform;           // Reference to the platform GameObject

    void Start()
    {
        Vector3 platformPos = platform.position;

        for (int i = 0; i < grassCount; i++)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-areaSize.x / 2, areaSize.x / 2),
                0f,
                Random.Range(-areaSize.z / 2, areaSize.z / 2)
            );

            Vector3 spawnPosition = platformPos + randomOffset;

            GameObject grass = Instantiate(grassPrefab, spawnPosition, Quaternion.identity);
            SpriteRenderer sr = grass.GetComponent<SpriteRenderer>();
            sr.sprite = grassSprites[Random.Range(0, grassSprites.Length)];
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, areaSize);
    }
}
