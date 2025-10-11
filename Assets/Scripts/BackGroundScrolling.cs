using UnityEngine;
using UnityEngine.UIElements;

public class BackGroundScrolling : MonoBehaviour
{
    public GameObject player;
    public Transform playertransform;
    [SerializeField]
    private float playerposx;
    [SerializeField]
    private float playerposy;
    [SerializeField]
    private float offsetx;
    [SerializeField]
    private float offsety;
    public Vector2 offset;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerposx = playertransform.position.x;
        playerposy = playertransform.position.y;
        offsetx = (playerposx / 2);
        offsety = (playerposy / 2);
        transform.position = new Vector3(offsetx + offset.x, offsety + offset.y, transform.position.z);
    }
}
