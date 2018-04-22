using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    public GameObject blood;

	void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Deactivate", 1.2f);
        rb.AddForce(transform.right * speed * 100);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // make effect
        if (other.gameObject.CompareTag("Ignore")) return;
        if (other.gameObject.CompareTag("Target"))
        {
            Instantiate(blood, new Vector3(transform.position.x, transform.position.y, blood.transform.position.z), Quaternion.identity);
            other.gameObject.GetComponent<Dialog>().DieAndSpeak();
        }

        Deactivate();
    }
}
