using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiSpawn : MonoBehaviour
{
    [Tooltip("prefab à spawn")]
    public Transform prefabAI;
    [Tooltip("Point de spawn des ia")]
    public Transform spawnPoint;

    Transform Spawn()
    {
        Transform ai = GameObject.Instantiate<Transform>(prefabAI);
        ai.position = spawnPoint.position;
        ai.rotation = spawnPoint.rotation;
        return ai;

    }
    
    void Start()
    {
    Transform ai = Spawn();
    AddPichenette(ai, ai.forward * 5);
    }

    public float timeMax;
   public float time = 0;


    void AddPichenette(Transform ai, Vector3 pichenette)
    {
        Rigidbody rb = ai.GetComponent<Rigidbody>();
        rb.AddForce(pichenette, ForceMode.Impulse);

    }
    private Vector3 lastPichenette;
    void Update()
    {
        
        time = time + Time.deltaTime;
       
        if (time > timeMax)
        {
            Spawn();
            time = 0;
            Transform ai = Spawn();
            Vector3 pichenette = spawnPoint.forward * 5;
            //magie
            //Random.onUnitSphere();
            pichenette.x = Random.Range(0.2f, 2f);
            pichenette.y = Random.Range(0.2f, 2f);
            AddPichenette(ai, pichenette);
            lastPichenette = pichenette;
             time = 0;
        }
       
     


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(spawnPoint.position, spawnPoint.position + lastPichenette); ;
    }

}

