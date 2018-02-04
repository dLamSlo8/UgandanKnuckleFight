using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit1 : MonoBehaviour
{

    public Rigidbody tearPrefab;
    const float interval = 0.5f;
    public float next_shot = 0f;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            if (Time.time >= next_shot)
            {
                next_shot = Time.time + interval;
                // TearY will be same as K position, maybe a bit higher to avoid collision immediately.
                // TearZ will be KOffset * sin(rotationY)
                // TearX will be KOffset * cos(rotationY)
                Debug.Log(transform.rotation.eulerAngles.y);
                float currentRotationY = transform.rotation.eulerAngles.y;
                if (currentRotationY <= 360 && currentRotationY >= 180)
                {
                    currentRotationY -= 360;
                }
                float currentRotationYRad = currentRotationY * Mathf.PI / 180f;
                float knuckPosZOffset = transform.position.z + 2.0f;
                float tearPositionNewX = 1.0f * Mathf.Sin(currentRotationYRad);
                float tearPositionNewZ = 1.0f * Mathf.Cos(currentRotationYRad);
                float tearPositionX = tearPositionNewX + transform.position.x;
                float tearPositionZ = tearPositionNewZ + transform.position.z;
                Debug.Log(tearPositionX);
                Debug.Log(tearPositionZ);

                Rigidbody tearInstance = Instantiate(tearPrefab, new Vector3(tearPositionX, transform.position.y + 1.0f, tearPositionZ), Quaternion.Euler(new Vector3(0, transform.rotation.y, 0))) as Rigidbody;
                Vector3 vectorFromTo = new Vector3(tearPositionNewX, 0, tearPositionNewZ);
                tearInstance.AddForce(60000 * vectorFromTo * Time.deltaTime, ForceMode.Force);
            }


        }
        GameObject[] tears = GameObject.FindGameObjectsWithTag("Tear");
        foreach (GameObject tear in tears)
        {
            if (tear.transform.position.y <= 0.8f)
            {
                Destroy(tear);
                tear.GetComponent<Renderer>().enabled = false;
            }
        }


    }
}


