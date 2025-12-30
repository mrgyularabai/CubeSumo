using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    public Rigidbody R;
    public GameObject winText;
    public static int win = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.I))
        {
            R.AddForce(Vector3.forward * P1.mul * Time.fixedDeltaTime, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.K))
        {
            R.AddForce(Vector3.back * P1.mul * Time.fixedDeltaTime, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.J))
        {
            R.AddForce(Vector3.left * P1.mul * Time.fixedDeltaTime, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.L))
        {
            R.AddForce(Vector3.right * P1.mul * Time.fixedDeltaTime, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.U))
        {
            R.AddTorque(Vector3.down * P1.mul * 0.5f * Time.fixedDeltaTime, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.O))
        {
            R.AddTorque(Vector3.up * P1.mul * 0.5f * Time.fixedDeltaTime, ForceMode.Force);
        }
    }

    public static bool recording = false;
    private void OnCollisionEnter(Collision collision)
    {
        recording = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (recording == false)
        {
            return;
        }
        if (collision.gameObject.name == "Platform")
        {
            if (win != 0)
            {
                return;
            }
            win = 1;
            winText.SetActive(true);
        }
    }
}