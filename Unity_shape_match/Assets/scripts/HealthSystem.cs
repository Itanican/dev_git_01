using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthSystem : MonoBehaviour
{

    [FormerlySerializedAs("health")] //don't lose data on variable name change
    public float maxHealth;
    float currentHealth;
    

    public GameObject healthBarPrefab;
    public float YOffset;

    HealthBarBehaviour myHealthBar;







    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() //create health panel on canvas
    {
        currentHealth = maxHealth ;

        GameObject healthBarObject = Instantiate(healthBarPrefab, References.canvas.transform);
        myHealthBar = healthBarObject.GetComponent<HealthBarBehaviour>();
    }

    private void OnDestroy()
    {
        if (gameObject != null)
        {
            Destroy(myHealthBar.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //track healthbar position to player
       //myHealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position) + Vector3.up * 30 ;

        myHealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * YOffset);


        myHealthBar.ShowHealthFraction(currentHealth / maxHealth);

    }
}
