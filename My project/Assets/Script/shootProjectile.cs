using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootProjectile : MonoBehaviour
{

    public Camera cam;
    public GameObject projectile;
    public Transform firePoint;
    private Vector3 destination;
    private bool leftHand;
    public float projectileSpeed = 30;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootProjectile();
        }
    }
    void ShootProjectile()

    {

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))

            destination = hit.point;
        else
            destination = ray.GetPoint(1000);

        if (leftHand)
        {
            leftHand = false;
            InstantiateProjectile(firePoint);
        }
        else
        {
            leftHand = true;
            InstantiateProjectile(firePoint);

        }



    }
       void InstantiateProjectile(Transform firePoint)

        {

            var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
            projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
        

         }
}


 