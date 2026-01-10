using System.Data;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public bool IsDead;
    private float RespawnTime = 3.0f;
    private float RespawnDelay;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    CircleCollider2D cc2d;
    SpriteRenderer gunRenderer;
    Transform gunTransform;
    GameObject pieces;
    public GameObject deathPieces;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
        gunTransform = transform.Find("Pew Pew Thing");
        gunRenderer = gunTransform.GetComponent<SpriteRenderer>();
        ToggleVisibility(true);
        IsDead = false;
        RespawnDelay = RespawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)
        {
            HandleDeath();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroyer")
        {
            Die();
        }
    }
    void Die()
    {
        SpawnDeathPieces();
        rb.simulated = false;
        cc2d.enabled = false;
        IsDead = true;
    }

    void HandleDeath()
    {
        RespawnDelay -= Time.deltaTime;
        ToggleVisibility(false);
        if(RespawnDelay <= Mathf.Epsilon)
        {
            Respawn();
        }
    }
    void Respawn()
    {
        RespawnDelay = RespawnTime;
        ToggleVisibility(true);
        IsDead = false;
        rb.simulated = true;
        cc2d.enabled = true;
        Destroy(pieces);
        playerMovement.Respawn();
    }
    void ToggleVisibility(bool show)
    {
        spriteRenderer.enabled = show;
        gunRenderer.enabled = show;
    }

    void SpawnDeathPieces()
    {
        pieces = Instantiate(deathPieces, transform.position, transform.rotation);
        Rigidbody2D[] childrenRB2D = deathPieces.GetComponentsInChildren<Rigidbody2D>();
        //sets the velocity for each child
        foreach(Rigidbody2D rb2d in childrenRB2D)
        {
            rb2d.linearVelocity = rb.linearVelocity;
        }

    }
}
