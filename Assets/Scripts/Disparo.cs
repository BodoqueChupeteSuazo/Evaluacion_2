using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject theBullet;
    public Transform barrelEnd;
    AudioSource Audio;
    public int bulletSpeed;
    public float despawnTime = 3.0f;
    public AudioClip ataque;

    public bool shootAble = true;
    public float waitBeforeNextShot = 0.25f;
    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (shootAble)
            {
                shootAble = false;
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        shootAble = true;
    }
    void Shoot()
    {
        var bullet = Instantiate(theBullet, barrelEnd.position, barrelEnd.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, despawnTime);
        Audio.PlayOneShot(ataque);

    }
}
