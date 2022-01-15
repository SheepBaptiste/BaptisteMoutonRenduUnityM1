using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 25f;
    public float range = 100f;

    public Camera fpsCam;
    public GameObject particle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            particle.SetActive(false);
        }
    }

    void Shoot()
    {
        particle.SetActive(true);
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(damage);
            AIMover target = hit.transform.GetComponent<AIMover>();
            if(target != null)
            {
                target.life = target.life - damage;
            }
        }
    }
}
