using UnityEngine;

public class CamFollow : MonoBehaviour
{
    
    public GameObject cam;
    public GameObject toFollow;
    
    public Vector3 targetPos;
    public Vector3 offset;
    
    void Start()
    {
    }
    
    void Update()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, toFollow.transform.position+ offset, 1.8f);
    }
}
