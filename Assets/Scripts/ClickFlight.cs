using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFlight : MonoBehaviour {
    private Camera _camera;
    private bool _flying = false;
    private Vector3 _flightDestination;
    private CharacterController _cc;
    public float speed = 20f;
    public Texture2D markerTexture;
    public float markerScale = 1;
	// Use this for initialization
	void Start () {
        _camera = transform.GetChild(0).GetComponent<Camera>();
        _cc = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
        if (_flying)
        {
            _Fly();
        } else if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit " + hit.transform.name);
                if (!hit.transform.name.Equals("Planet")) return;
                //Disabling motion control
                Person p = transform.GetComponent<Person>();
                p.canMove = false;
                //Fly               
                _flying = true;
                _flightDestination = hit.transform.position;
            }
        }
	}

    void _Fly()
    {
        //Moving forward
        Vector3 offset = _flightDestination - transform.position;
        offset = offset.normalized * speed;
        _cc.Move(offset * Time.deltaTime);
    }

    private void OnGUI()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name.Equals("Planet"))
            {
                //Render UI Marker
                float x = (_camera.pixelWidth - markerTexture.width * markerScale) / 2;
                float y = (_camera.pixelHeight - markerTexture.height * markerScale) / 2;

                GUI.DrawTexture(new Rect(x, y, markerTexture.width * markerScale, markerTexture.height * markerScale), markerTexture);
            }
        }
    }
}
