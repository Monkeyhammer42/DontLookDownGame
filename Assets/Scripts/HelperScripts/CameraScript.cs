using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float resetSpeed = 0.5f;
    public float cameraSpeed = 0.3f;

    public Bounds cameraBounds;
    private Transform target;
    private float offsetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;
    private bool followsPlayer;
    public float bottomcamera=3f;
    public float leftcamera = 3f;
    void Awake()
    {
        BoxCollider2D myCol = GetComponent<BoxCollider2D>();
        myCol.size = new Vector2(Camera.main.aspect * 2f * Camera.main.orthographicSize, 15f);
        cameraBounds = myCol.bounds;

    }


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        lastTargetPosition = target.position;
        offsetZ = (transform.position - target.position).z;
        followsPlayer = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (followsPlayer)
        {
            Vector3 aheadTargetPos = target.position + Vector3.forward * offsetZ;
         //   Vector3 aboveTargetPos = target.position + Vector3.up * offsetZ;
           
                Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, resetSpeed);

                transform.position = new Vector3(newCameraPosition.x+leftcamera, newCameraPosition.y+bottomcamera, newCameraPosition.z);
                lastTargetPosition = target.position;
            
            //if (aboveTargetPos.y >= transform.position.y)
            //{
            //    Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, cameraSpeed);

            //    transform.position = new Vector3(transform.position.x, newCameraPosition.y, transform.position.z);
            //    lastTargetPosition = target.position;
            //}
        }
    }


































}
