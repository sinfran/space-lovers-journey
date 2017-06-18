using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider collider)
    {
        print("HIT");

        if (collider.gameObject.name.Equals("KiteContainer"))
        {
            Transform player = collider.transform.parent;

            Vector3 playerPos = player.position;

            Vector3 velocity = playerPos - transform.position;

            CharacterController controller = player.gameObject.GetComponent<CharacterController>();

          
            

            //collider.gameObject.transform.parent
            Destroy(collider.gameObject);
        }
    }


}
