using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silemi : MonoBehaviour
{
	public float speed = 20.0f;
	public float lifeDuration = 5.0f;
   public float damageDealt = 2.0f;
   // Start is called before the first frame update
   void Start()
   {
   	Invoke("Kill",lifeDuration);
   }

   void OnTriggerEnter(Collider col)
	{
      EnemyHealth health = col.gameObject.GetComponent<EnemyHealth>();
 
      if (health != null)
      {
         health.TakeDamage(damageDealt);
      }

		Kill();
	}
 
	void Kill()
	{
      //Debug.Log("adieu monde cruel");
		Destroy(gameObject);
	}


   // Update is called once per frame
   void Update()
   {
      transform.position += transform.forward * speed * Time.deltaTime;
      transform.Rotate (Vector3.forward, 600* Time.deltaTime);
   }
}
