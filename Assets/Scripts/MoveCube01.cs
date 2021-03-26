using UnityEngine;

public class MoveCube01 : MonoBehaviour
{
    public bool moving = false;

    public Vector2 targetPosition;

    float smoothTime = 0.3f;
    float yVelocity = 0.0f;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.localPosition, targetPosition, Color.green);

        Jump();
        if(moving)
        {
            transform.localPosition = UpdatedPosition(transform.localPosition);
        }

        if (Vector3.Distance(transform.localPosition, targetPosition) <= 0.1f)
            moving = false;
    }

    Vector3 UpdatedPosition(Vector3 position)
    {
        return new Vector2(position.x, UpdateForce());
    }

    float UpdateForce()
    {
        return Mathf.SmoothDamp(transform.position.y, targetPosition.y, ref yVelocity, smoothTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetPosition = new Vector2(0,transform.localPosition.y + 5f);
            moving = true;
        }
    }
}
