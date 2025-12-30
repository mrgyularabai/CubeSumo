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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            R.AddForce(Vector3.forward * P1.mul * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            R.AddForce(Vector3.back * P1.mul * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            R.AddForce(Vector3.left * P1.mul * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            R.AddForce(Vector3.right * P1.mul * Time.fixedDeltaTime, ForceMode.Impulse);
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