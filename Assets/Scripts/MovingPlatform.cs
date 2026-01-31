using System.IO;
using System.Numerics;
using UnityEngine;
using Vec2 = UnityEngine.Vector2;
using Vec3 = UnityEngine.Vector3;
public class MovingPlatform : MonoBehaviour
{
    Vec2 starting;
    public Vec2 destination;
    Vec2 target;
    bool movingAway = true;
    public float movementSpeed = 2.0f;
    Vec3 path;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        starting = transform.position;
        SetTarget(destination);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + path * Time.deltaTime;
        
        // find the distance between our position and the target
        float distance = Vec2.Distance(target, transform.position);

        //TODO: if the distance ever skips and it's larger than .1 then we won't flip infinitely need to fix
        if(distance < 0.1f)
        {
            SetTarget(movingAway ? starting : destination);
        }
    }

    void SetTarget(Vec2 endpoint)
    {
        target = endpoint;
        movingAway = !movingAway;

        Vec2 pos = new Vec2(transform.position.x, transform.position.y);
        path = target - pos;
        path.Normalize();
    }
}
