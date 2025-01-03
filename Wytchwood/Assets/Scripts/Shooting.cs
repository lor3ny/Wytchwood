using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shooting : MonoBehaviour
{
    
    private Vector2 mousePos;
    private Vector2 mouseWorldPos;

    public Sprite crosshair;
    public GameObject bullet;
    public float bulletSpeed;
    public float bulletDelay;

    private AudioSource source;
    public AudioClip clip;

    private bool hasShot = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }


    void Update()
    {

        mousePos = (Vector2) Input.mousePosition;
        mouseWorldPos = (Vector2) Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        Debug.DrawLine(transform.position, mouseWorldPos);
        if (Input.GetKeyDown(KeyCode.Mouse0) && hasShot == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Vector2 direction = (mouseWorldPos - (Vector2)gameObject.transform.position).normalized;
                GameObject bull = Instantiate(bullet);
                bull.GetComponent<SpriteRenderer>().color = Color.red;
                bull.GetComponent<BulletManager>().sucking = false;
                bull.transform.position = gameObject.transform.position;
                bull.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                source.PlayOneShot(clip);
            }
            else
            {
                Vector2 direction = (mouseWorldPos - (Vector2)gameObject.transform.position).normalized;
                GameObject bull = Instantiate(bullet);
                bull.GetComponent<SpriteRenderer>().color = Color.green;
                bull.GetComponent<BulletManager>().sucking = true;
                bull.transform.position = gameObject.transform.position;
                bull.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
              
            }
            //
            hasShot = true;
            StartCoroutine(shootDelay());
        }
    }


    IEnumerator shootDelay()
    {   
        yield return new WaitForSeconds(bulletDelay);
        hasShot = false;
    }
}
