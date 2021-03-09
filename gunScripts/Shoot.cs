using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shoot : MonoBehaviour
{
    public float firerate = 0.1f;

    float lastFireTime = 0;

    public int defaultAmmo = 120;

    public int magSize = 30;

    public int currentAmmo;

    public int currentMagAmmo;

    public Camera camera;

    public int range;

    [Header("Gun Damege On Hit")]

    public int damage;

    public GameObject bloodPrefab;

    public GameObject decalPrefab;

    public GameObject magObject;

    public ParticleSystem muzzleParticle;

    int miniAngle = 2;
    int maxAngle = 5;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = defaultAmmo - magSize;
        currentMagAmmo = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Reload();

        }
        if (Input.GetMouseButton(0))
        {
            if (CanFire())
            {
                Fire();
            }
            
        }
    }

    private void Reload()
    {
        if (currentAmmo == 0 || currentMagAmmo == magSize)
        {
            return;
        }
        if (currentAmmo < magSize)
        {
            currentMagAmmo =currentAmmo + 1;
            currentAmmo = 0;           
        }
        else
        {
            currentAmmo -= 30;
            currentMagAmmo = magSize;
        }
        if (currentMagAmmo > 30)
        {
            currentMagAmmo = magSize;
        }
        GameObject newMagobject = Instantiate(magObject);
        newMagobject.transform.position = magObject.transform.position;
        newMagobject.AddComponent<Rigidbody>();
    }

    private bool CanFire()
    {
        if (currentMagAmmo > 0 && lastFireTime + firerate < Time.time)
        {
            lastFireTime = Time.time + firerate;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Fire()
    {
        muzzleParticle.Play(true);
        currentMagAmmo -= 1;
        Debug.Log("kalan mermi" + currentMagAmmo);
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 10))
        {
            if(hit.transform.tag == "Zombie")
            {
                hit.transform.GetComponent<Enemyhp>().Hit(damage);

                GenerateBloodEffect(hit);
            }
            else
            {
                GenerateHitEffect(hit);
            }
        }
        transform.localEulerAngles = new Vector3(Random.Range(miniAngle, maxAngle), Random.Range(miniAngle, maxAngle),Random.Range(miniAngle, maxAngle));
    }

    private void GenerateBloodEffect(RaycastHit hit)
    {
        GameObject bloodObject = Instantiate(bloodPrefab, hit.point, hit.transform.rotation);
        
    }

    private void GenerateHitEffect(RaycastHit hit)
    {
        GameObject hitObject = Instantiate(decalPrefab, hit.point, Quaternion.identity);
        hitObject.transform.rotation = Quaternion.FromToRotation(decalPrefab.transform.forward * -1, hit.normal);
    }


}
