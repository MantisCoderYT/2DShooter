using System.Threading;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float Power = 50f;
    private float DestroyTimer = 5.0f;

    private float FadeTime = 1.0f;
    private float FadeTimer;
    bool isDestroyed = false;
    Color alphaColor;
    Color initialColor;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialColor = sr.color;
        alphaColor = sr.color;
        alphaColor.a = 0.0f;

        FadeTimer = FadeTime;

        rb.linearVelocity = transform.right * Power;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || true)
        { 
            DestroyTimer -= Time.deltaTime;
            if (DestroyTimer <= 0.0f)
            {
                DestroyBullet();
            }
        }

        if (isDestroyed)
        {
            sr.color = Color.Lerp(initialColor, alphaColor, (FadeTime - FadeTimer)/FadeTime);
            FadeTimer -= Time.deltaTime;
            if (FadeTimer <= 0.0f)
            {
                Destroy(gameObject);
            }
        }

    }
    void DestroyBullet()
    {
        isDestroyed = true;
    }
}
