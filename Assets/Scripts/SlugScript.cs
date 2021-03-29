using UnityEngine;

public class SlugScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private LineRenderer ForceRay;

    private Vector2 StartPoint;
    private Vector2 EndPoint;
    private Vector2 Force;
    private float MaxSpeed = 10f;
    private float Speed;
    private bool Aiming = false;
    public Rigidbody2D nextRigidbody;
    public float multiplier = 0.5f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();        
        rb.bodyType = RigidbodyType2D.Dynamic;

        ForceRay = gameObject.GetComponentInChildren(typeof(LineRenderer), true) as LineRenderer;

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        DrawRay();
    }

    void DrawRay()
    {
        ForceRay.gameObject.SetActive(Aiming);
        if (Aiming)
        {
            var StartPointWorldRel = Camera.main.ScreenToWorldPoint(StartPoint);
            var MousePositionWorldRel = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ForceRay.SetPosition(0, new Vector3(StartPointWorldRel.x, StartPointWorldRel.y, 0f));
            ForceRay.SetPosition(1, new Vector3(MousePositionWorldRel.x, MousePositionWorldRel.y, 0f));
        }
    }

    void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPoint = Input.mousePosition;
            Aiming = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Aiming = false;

            EndPoint = Input.mousePosition;
            Speed = Mathf.Min(Vector2.Distance(EndPoint, StartPoint) / 50, MaxSpeed);
            Force = (EndPoint - StartPoint).normalized * Speed;
            rb.velocity = Force;
            if(nextRigidbody != null)
                nextRigidbody.velocity = Force * multiplier;
        }
    }
}
