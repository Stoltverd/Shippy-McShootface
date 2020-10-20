using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    private Pooler pooler;
    

    void Start()
    {
        pooler = Pooler.Instance;
    }

    private void FixedUpdate()//se ejecuta antes de cada step de la fisica 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement*speed;
        GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
                0.0f, 
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f,0.0f,GetComponent<Rigidbody>().velocity.x * -tilt);
    }

    void Update()
    {
        if (Input.GetButton("Fire1")&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            pooler.SpawnFromPool("Bullet", shotSpawn.position, shotSpawn.rotation); //as GameObject;
            GetComponent<AudioSource>().Play();
        }

        if (Input.GetButtonDown("Fire2") && GameManager.Instance.misiles > 0)
        {
            nextFire = Time.time + fireRate;
            pooler.SpawnFromPool("Missile", shotSpawn.position, shotSpawn.rotation); //as GameObject;
            GameManager.Instance.misiles--;
        }

    }
}
