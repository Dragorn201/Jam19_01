using UnityEngine;

public class LaunchBrick : MonoBehaviour
{
    public float impulseForce;
    public Vector2 impulseDirection;
    private float keyDownTime = 0f;
    private bool isKeyHeld = false;

    public float maxForce;
    
    public Vector3 startPos;
    public Vector3 endPos;

    void Start()
    {
        startPos = transform.position;
        Debug.Log(startPos);
    }
    
    void Update()
    {
        endPos = transform.position;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyDownTime = Time.time;
            isKeyHeld = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) && isKeyHeld)
        {
            float heldDuration = Time.time - keyDownTime;
            Debug.Log(heldDuration);
            isKeyHeld = false;
            
            impulseForce = impulseForce * heldDuration;
            if (impulseForce > maxForce)
            {
                impulseForce = maxForce;
                Debug.Log("MaxReach");
            }
            
            GetComponent<Rigidbody>().AddForce(impulseDirection * impulseForce,ForceMode.Impulse);
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        endPos = collision.contacts[0].point;
    }
}