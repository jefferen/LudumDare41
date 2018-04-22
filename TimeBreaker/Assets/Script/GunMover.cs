using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMover : MonoBehaviour // at this point it's more like a game manager!
{
    public GameObject bullet, player;
    List<GameObject> bullets = new List<GameObject>();
    public Transform firePoint;
    bool canShoot = true;
    public GameObject gun;
    public AudioSource backgroundMusic, gunShoot;

	void Start ()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject b = Instantiate(bullet, transform.position, bullet.transform.rotation);
            b.SetActive(false);
            bullets.Add(b);
        }
       // backgroundMusic.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            foreach (GameObject bullet in bullets)
            {
                if (!bullet.activeInHierarchy)
                {
                    gunShoot.Play();
                    bullet.transform.position = firePoint.position;
                    bullet.transform.rotation = firePoint.rotation;
                    bullet.SetActive(true);
                    canShoot = false;
                    CancelInvoke();
                    Invoke("ShootDelay", 0.1f);
                    break;
                }
            }
        }
	}

    private void FixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, 1);
    }

    void ShootDelay()
    {
        canShoot = true;
    }
}
