using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepListener : MonoBehaviour {
    public Transform camera;

    void Start()
    {
        camera = this.gameObject.transform.GetChild(0);
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }
    public float speed = 10.0F;

    // Update is called once per frame
    void Update()
    {
        Person person = GetComponent<Person>();
        if (!person.canMove) return;

        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;
        dir.z = Input.acceleration.z;

        //transform.Translate (transform.forward * 1.0f * Time.deltaTime	); 

        if (dir.sqrMagnitude < 0.3)
        {
            transform.Translate(camera.forward * speed * Time.deltaTime);
        }


    }
}
