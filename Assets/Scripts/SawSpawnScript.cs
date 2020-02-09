using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawnScript : MonoBehaviour
{
    public GameObject Saw;
    public Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            Instantiate(Saw,new Vector3( SpawnPoint.position.x,SpawnPoint.position.y),Quaternion.identity);
        }
    }
}
