

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameObjectCamera : MonoBehaviour
{

    [Header("Focus Settings")]
    public Transform focusTarget;          // Objet à regarder
    public float focusSpeed = 5f;           // Vitesse de rotation
    public float zoomFOV = 30f;              // FOV pendant le focus
    public float zoomSpeed = 5f;             // Vitesse du zoom

    private Camera cam;
    private float defaultFOV;
    private bool isFocusing = false;

    void Start()
    {
        cam = GetComponent<Camera>();
        defaultFOV = cam.fieldOfView;
    }

    void Update()
    {
        if (isFocusing && focusTarget)
        {
            // Rotation vers la cible
            Vector3 direction = focusTarget.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * focusSpeed
            );

            // Zoom (FOV)
            cam.fieldOfView = Mathf.Lerp(
                cam.fieldOfView,
                zoomFOV,
                Time.deltaTime * zoomSpeed
            );
        }
    }

    public void StartFocus(Transform target)
    {
        //focusTarget = target;
        //isFocusing = true;
    }

    public void StopFocus()
    {
        //isFocusing = false;
       // StartCoroutine(ResetFOV());
    }

    private IEnumerator ResetFOV()
    {
        while (Mathf.Abs(cam.fieldOfView - defaultFOV) > 0.1f)
        {
            cam.fieldOfView = Mathf.Lerp(
                cam.fieldOfView,
                defaultFOV,
                Time.deltaTime * zoomSpeed
            );
            yield return null;
        }

        cam.fieldOfView = defaultFOV;
    }
    
    
}