using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public float Health = 10.0f;

	private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
      currentHealth = Health;
    }

    public void TakeDamage(float dommage)
    {
    	currentHealth -= dommage;
    	if(currentHealth <= 0){
    		Destroy(gameObject);
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
