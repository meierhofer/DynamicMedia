using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera_ray : MonoBehaviour
{
    public LayerMask ignoreMe;
    public Transform crosshair_t;
    public Transform push_object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        crosshair_t.position = new Vector3(crosshair_t.position.x, 0f, crosshair_t.position.z); //below floor
        if (!Input.GetButton("Fire1"))
        {
            push_object.GetComponent<Rigidbody>().isKinematic = true; //make push object not physical
            push_object.position = new Vector3(push_object.position.x, -1f, push_object.position.z);
        }
        if (Physics.Raycast(ray, out hit, 50f, ~ignoreMe))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(Vector3.up, ForceMode.Impulse);
            }
            else if (hit.collider.name == "Floor")
            {
                crosshair_t.position = new Vector3(hit.point.x, 0.51f, hit.point.z); //above floor
                if (Input.GetButton("Fire1"))
                {
                    if (push_object.GetComponent<Rigidbody>().isKinematic)
                    {
                        push_object.position = new Vector3(hit.point.x, Mathf.Max(-1f, push_object.position.y), hit.point.z);
                        push_object.GetComponent<Rigidbody>().isKinematic = false;

                    }
                    push_object.GetComponent<Rigidbody>().AddForce(Vector3.up * 100f * Time.deltaTime, ForceMode.Impulse);
                }
            }
        }
    }
}
