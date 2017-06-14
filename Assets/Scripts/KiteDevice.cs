using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteDevice : MonoBehaviour
{
    public float kiteSpeed = 8.0f;
    public enum State { DORMANT, GET_ON_KITE, FLY };
    public State s;
    private GameObject player;
    private GameObject kiteContainer;
    private bool bound = false;
    void Start()
    {
        s = State.DORMANT;
        kiteContainer = transform.parent.gameObject;
    }
    //TODO: Handle offset between person and kite
    void Update()
    {

        switch (s)
        {
            case (State.DORMANT):
                break;
            case (State.GET_ON_KITE):
                s = State.FLY;
                break;
            case (State.FLY):
                //Bind kite to player
                Transform camera = player.transform.GetChild(0).transform;
                CharacterController playercontroller = player.GetComponent<CharacterController>();
                if (!bound)
                {
                    player.transform.position += new Vector3(0, 2.0f, 0);
                    kiteContainer.transform.parent = player.transform;
                    kiteContainer.transform.localPosition = new Vector3(0, -1, 0);
                    //Position kite under
                    bound = true;
                }

                //Move person   
                Vector3 cameraForward = camera.forward;
                playercontroller.Move(cameraForward * Time.deltaTime * kiteSpeed);

                //rotating kite
                kiteContainer.transform.rotation = Quaternion.Lerp(kiteContainer.transform.rotation, camera.rotation, 10f * Time.deltaTime);


                break;
            default:
                print("Invalid state");
                break;
        }
    }

    // Operate is called by Device Operator
    public void Operate(DeviceOperator devo)
    {
        print("Kite Operate called.");

        //Logic to move the person on top of the kite
        Person p = devo.GetComponent<Person>();
        p.canMove = false;
        player = p.gameObject;

        s = State.GET_ON_KITE;
    }

}
