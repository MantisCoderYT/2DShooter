using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject Player;
    Rigidbody2D rb;
    public GameObject BulletPrefab;
    public float RecoilForce = 100f;
    public float RecoilTorque = 1.0f;
    public float orientationAngleTolerance;
    private LifeSystem lifeSystem;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeSystem = GetComponent<LifeSystem>();
    } 

    // Update is called once per frame
    void Update()
    {
        if (!lifeSystem.IsDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
    }
    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        rb.AddForce(transform.right * -RecoilForce);

        // add torque to player based on direction gun is facing


        // Get the dot product of the players right with the world's down
        float dotProduct = Vector3.Dot(transform.right, Vector3.down);
        // Convert the dot product to an angle
        float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        if (angle > orientationAngleTolerance)
        {
            Vector3 crossProduct = Vector3.Cross(transform.right, Vector3.up);
            float rotationDirection = 1.0f;
            if (crossProduct.z <= Mathf.Epsilon)
            {
                rotationDirection *= -1.0f;
            }

            rb.AddTorque(rotationDirection * RecoilTorque);

        }
        
    }
}
