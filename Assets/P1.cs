using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour
{
    public GameObject winText;
    public GameObject winTextO;
    public Rigidbody R;
    public Rigidbody RO;
    public static float mul = 85f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            R.angularVelocity = Vector3.zero;
            R.velocity = Vector3.zero;
            RO.angularVelocity = Vector3.zero;
            RO.velocity = Vector3.zero;
            GameObject.Find("Player 1").transform.position = new Vector3(0f, 2.5f, -3.5f);
            GameObject.Find("Player 1").transform.rotation = Quaternion.identity;
            GameObject.Find("Player 2").transform.position = new Vector3(0f, 2.5f, 3.5f);
            GameObject.Find("Player 2").transform.rotation = Quaternion.identity;
            winText.SetActive(false);
            winTextO.SetActive(false);
            P2.win = 0;
            recording = false;
            P2.recording = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            R.AddForce(Vector3.forward * mul * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            R.AddForce(Vector3.back * mul * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            R.AddForce(Vector3.left * mul * Time.fixedDeltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            R.AddForce(Vector3.right * mul * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }

    bool recording = false;
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
            if (P2.win != 0)
            {
                return;
            }
            P2.win = 2;
            winText.SetActive(true);
        }
    }
}
