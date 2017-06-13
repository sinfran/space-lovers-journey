using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteDevice : MonoBehaviour {
    public float kiteSpeed = 10.0f;
    public enum State {DORMANT, GET_ON_KITE, FLY };
    public State s;
    private GameObject player;
    public Vector3 kitePos;
    public float mountSpeed = 3.0f;

	void Start () {
        s = State.DORMANT;
        kitePos = transform.parent.gameObject.transform.localPosition;
        print(kitePos);
	}
    //TODO: Handle offset between person and kite
    void Update()
    {
        
        switch (s)
        {
            case (State.DORMANT):
                break;
            case (State.GET_ON_KITE):
                //TODO: This logic is faulty we think... but we can skip this because fly positions kite underneath player
                //Vector3 playerPos = player.transform.position;
                //playerPos = Vector3.MoveTowards(playerPos, kitePos, mountSpeed*Time.deltaTime);
                //player.transform.position = playerPos;
                s = State.FLY;
                break;
            case (State.FLY):
                Transform camera = player.transform.GetChild(0).transform;
                Vector3 direction = player.transform.GetChild(0).transform.forward;
                GameObject kiteContainer = transform.parent.gameObject;
                direction *= Time.deltaTime * 6.0f;
                Rigidbody kiteBody = kiteContainer.GetComponent<Rigidbody>();
                kiteBody.MovePosition(transform.position + direction);

                //Moving person on top of kite
                Vector3 playerTargetPos = kiteContainer.transform.position;
                playerTargetPos.y += 2f;
                player.transform.position = playerTargetPos;

                ////rotating kite
                kiteContainer.transform.rotation = Quaternion.Lerp(kiteContainer.transform.rotation, camera.rotation, 0.5f*Time.deltaTime);
                break;
            default:
                print("Invalid state");
                break;
        }
    }

    // Operate is called by Device Operator
    public void Operate (DeviceOperator devo) {
        print("Kite Operate called.");

        //Logic to move the person on top of the kite
        Person p = devo.GetComponent<Person>();
        p.canMove = false;

        player = p.gameObject;

        s = State.GET_ON_KITE;      
	}

}

