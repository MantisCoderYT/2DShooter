using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject Player;
    Rigidbody2D rb;
    public GameObject BulletPrefab;
    private float RecoilForce = 100f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        rb.AddForce(transform.right * -RecoilForce);
         
        
    }
}
