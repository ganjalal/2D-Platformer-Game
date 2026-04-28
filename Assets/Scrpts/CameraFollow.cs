using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    public Transform player;
    public float smoothSpeed = 0.3f;
    public Vector3 offset;
    public Vector3 velocity = Vector3.zero;
    public float snowOffset = 2f;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position,desiredPosition,ref velocity,smoothSpeed);
    }
}
