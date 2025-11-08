using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public bool IsDead;
    private float RespawnTime = 3.0f;
    private float RespawnDelay;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;
    SpriteRenderer gunRenderer;
    Transform gunTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        playerMovement.Respawn();
    }
    void ToggleVisibility(bool show)
    {
        spriteRenderer.enabled = show;
        gunRenderer.enabled = show;
    }
}
