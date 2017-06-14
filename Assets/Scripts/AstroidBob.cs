using UnityEngine;
using System.Collections;

public class AstroidBob : MonoBehaviour {
    
	public Vector3 initialPosition;
	public Vector3 direction;
	public float bobHeight = 0.5f;
	public float bobSpeed = 0.3f;
    public float offset = 0f;


	// Use this for initialization
	void Start () {
        //Choses a random direction to bob
        float rand = Random.Range(0.0f, 1.0f);
        if (rand > 0.5f)
        {
            direction = Vector3.up;
        } else
        {
            direction = Vector3.down;
        }
 
		initialPosition = transform.localPosition;
	}

	// Update is called once per frame
	void Update () {
        offset = transform.localPosition.y - initialPosition.y;
		if (offset > bobHeight) {
			direction = Vector3.down;
		}
		if (offset < -bobHeight) {
			direction = Vector3.up;
	}
		transform.Translate (direction * bobSpeed * Time.deltaTime, Space.World);
}
}
