using System.Threading;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float Power = 50f;
    public Rigidbody2D rb;
    Timer timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.right * Power;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(gameObject);
        }
    }
}
