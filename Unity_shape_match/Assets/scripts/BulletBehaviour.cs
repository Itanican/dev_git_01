using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{


    public float bulletspeed;
    public float secondsUntilDestroyed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = transform.forward * bulletspeed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * bulletspeed * Time.deltaTime;

        secondsUntilDestroyed -= Time.deltaTime;

        if (secondsUntilDestroyed < 1)
        {
            ShrinkObject(secondsUntilDestroyed);
        }

        if (secondsUntilDestroyed < 0)
        {

            Destroy(gameObject);
        }
    }





    private void OnCollisionEnter(Collision thisCollision)
    {
        GameObject theirGameObject = thisCollision.gameObject;

        if (theirGameObject.GetComponent<EnemyBehaviour>() != null)
        {
            HealthSystem theirHealthSystem = theirGameObject.GetComponent<HealthSystem>();
            if (theirHealthSystem != null)
                {
                    theirHealthSystem.TakeDamage(damage);
                }
           // Destroy(theirGameObject);
            Destroy(gameObject);
        }
    }


    
    public void ShrinkObject(float amount)
    {
        transform.localScale *= amount;
    }
    
}

