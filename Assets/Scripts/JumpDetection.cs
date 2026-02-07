using UnityEngine;


public class JumpDetection : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject player;
    Vector3 playerScale;
    Vector3 targetScale;
    bool performScale = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScale = player.transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            playerMovement.Grounded();
            //gets the player
            Debug.Log("Player Lossy Scale Preparent: " + player.transform.lossyScale);
            Debug.Log("Platform Lossy Scale Preparent: " + collision.transform.lossyScale);

            player.transform.SetParent(collision.transform);
            targetScale = new Vector3(playerScale.x / collision.transform.lossyScale.x, 
                                                      playerScale.y / collision.transform.lossyScale.y, 
                                                      playerScale.z / collision.transform.lossyScale.z);
            Debug.Log("Player computed Local Scale Preparent: " + player.transform.localScale);
            Debug.Log("Player Lossy Scale Postparent: " + player.transform.lossyScale);
            performScale = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Object"))
        {
            playerMovement.Grounded();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Object") || collision.gameObject.CompareTag("MovingPlatform"))
        {
            playerMovement.Ungrounded();
            player.transform.SetParent(null);
            
        }
    }

    void LateUpdate()
    {
        if (performScale)
        {
            player.transform.localScale = targetScale;
            performScale = false;
        }
    }
}
