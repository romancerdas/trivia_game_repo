using UnityEngine;
using System.Collections;


public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float laneSize = 5f;
    public float shiftSpeed = 10f;
    private bool shifting = false;
    private int currentLane = 0;  // -1 = left, 0 = center, 1 = right
    [SerializeField] private Rigidbody rb;

    private void Update()
    {
        if (!shifting)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 1)
            {
                currentLane++;
                StartCoroutine(ShiftToLane(currentLane));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > -1)
            {
                currentLane--;
                StartCoroutine(ShiftToLane(currentLane));
            }
        }
    }

    private IEnumerator ShiftToLane(int lane)
    {
        shifting = true;
        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(lane * laneSize, startPos.y, startPos.z);

        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, shiftSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        shifting = false;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, speed);  // Constant forward motion
    }
}