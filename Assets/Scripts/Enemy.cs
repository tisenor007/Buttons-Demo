using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    private Vector3 direction = new Vector3(-1, 0, 0);
    private int speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        Debug.Log(health);
    }

    public void TakeDamage(int value)
    {
        health = health - value;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            health = 0;
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        direction *= -1;
    }
}
