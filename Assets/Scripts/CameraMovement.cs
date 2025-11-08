using JetBrains.Annotations;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{ 
    public GameObject player;
    public Transform playertransform;
    [SerializeField]
    private float offsetx;
    [SerializeField]
    private float offsety;
    public float cameraSpeedThreshold = 1.0f;

    public float cameraSpeed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector2(playertransform.position.x - transform.position.x, playertransform.position.y - transform.position.y);

        // Vector3 resultVector = playertransform.position - transform.position;
        // resultVector = new Vector3(resultVector.x, resultVector.y, 0.0f);
        // float resultMagnitude = resultVector.magnitude;
        // resultMagnitude = (resultMagnitude > cameraSpeedThreshold) ? cameraSpeedThreshold : resultMagnitude;
        // resultMagnitude = 1.0f;
        //transform.position = transform.position + resultVector.normalized * resultMagnitude * cameraSpeed;
        transform.position = new Vector3(playertransform.position.x, playertransform.position.y, transform.position.z);
        

    }
}
