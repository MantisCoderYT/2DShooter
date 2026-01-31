using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject followSubject;
    public Vector2 followOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Debug.Log("Follow Update");
        Vector2 followVec = followSubject.transform.position;
        transform.position = new Vector3(followVec.x + followOffset.x, followVec.y + followOffset.y);
    }
}
