using UnityEngine;

public class MoveCube01 : MonoBehaviour
{
    private bool moving = false;

    private Vector2 firstCursorPosition;
    private Vector2 secondCursorPosition;
    private Vector2 wantedDirection;

    private float deltaX;
    private float deltaY;

    public float maxForce = 5f;
    public float MaxFallingVelocity = 5f;
    public float slowingSpeed = 5f;

    // Update is called once per frame

    public Transform TempTransform;
    
    void Update()
    {
        Jump();        
        UpdateForce();
        UpdatePosition();

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.0) Debug.Log("I am left of the camera's view.");
        if (1.0 < pos.x) Debug.Log("I am right of the camera's view.");

        //Reset position and stop moving when cube touches "ground" ( y == 0 )
        if (transform.position.y <= 0.0f)
        {
            // Unity can overshoot position, because of difference in position between updates(y can be lower than 0)
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            moving = false;
        }
    }

    void UpdateForce()
    {
        //Slow down, basically simulating simple air drag:
        deltaY -= Time.smoothDeltaTime * slowingSpeed;
        //Clamp our force, to simulate earth gravity and terminal velocity (simplified)
        deltaY = Mathf.Clamp(deltaY, -MaxFallingVelocity, Mathf.Infinity);
    }

    void UpdatePosition()
    {
        if (!moving)
            return;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.0f)
        {
            deltaX *= -1f;
        }
        else if (1.0f < pos.x)
        {
            deltaX *= -1f;
        }

        Vector3 t = transform.localPosition;
        t.x += deltaX * Time.smoothDeltaTime;
        t.y += deltaY * Time.smoothDeltaTime;

        transform.localPosition = t; 
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Get initial cursor position in screen space(screen pixels):
            Debug.Log($"first{firstCursorPosition}");
            firstCursorPosition = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            secondCursorPosition = Input.mousePosition;
            //Get direction
            wantedDirection = (secondCursorPosition - firstCursorPosition);
            //Set Forces for movement simulation:
            //Dot product gives us angle in float relative to target
            //Normalized direction is to get its magnitude of 1;
            deltaX = Vector3.Dot(transform.TransformDirection(Vector3.right), wantedDirection.normalized) * maxForce;
            deltaY = maxForce;
            moving = true;
            //Visualize our cursor input for 3 seconds(because this is called in one update only)
            Debug.Log($"second{secondCursorPosition}");
            Debug.DrawRay(transform.localPosition, wantedDirection, Color.green, duration: 3f);
        }
    }
}
