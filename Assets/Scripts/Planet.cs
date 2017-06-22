using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
    private bool x = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {   
        if (!x)
        {
            print("hit planet!");
            Vector3 collisionNormal = collision.contacts[0].normal;
            collision.transform.rotation = Quaternion.Euler(collisionNormal);
            collision.rigidbody.freezeRotation = true;
            print(collisionNormal);
            x = true;
        }
        

    }

    void OnTriggerEnter(Collider collider)
    {
        print("HIT");

        if (collider.gameObject.name.Equals("KiteContainer"))
        {
            Transform playerTransform = collider.transform.parent;
            Destroy(collider.gameObject);

            Vector3 playerPos = playerTransform.position;
            Vector3 velocity = transform.position - playerPos;

            CharacterController controller = playerTransform.gameObject.GetComponent<CharacterController>();


            GameObject player = playerTransform.gameObject;
            Rigidbody rb = player.AddComponent<Rigidbody>();
            rb.angularDrag = 0;
            rb.useGravity = false;

            rb.AddForce(velocity * 0.05f, ForceMode.VelocityChange);
      


            
            //collider.gameObject.transform.parent
           
        }
    }
  

}
