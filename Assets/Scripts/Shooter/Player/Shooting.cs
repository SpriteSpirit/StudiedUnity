using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shooting : MonoBehaviour
{
  //  public ParticleSystem fire;
    private float range = 100;
    private float damage = 1f;
    public Camera mainCamera;
    public GameObject bulletEffects;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // fire.Play();
            Shoots();
        }
    }

    private void Shoots()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

        GameObject bullet = Instantiate(bulletEffects, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(bullet, 2f);
    }
}
