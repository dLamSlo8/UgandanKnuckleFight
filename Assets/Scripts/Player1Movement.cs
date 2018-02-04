using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour  {
    public Rigidbody rb;
    public float sideRotation = 75f;
    public Spit1 spit1;
    //public LabelP2 p2label;
    public int pscore = 0;
    public TextMesh mesh;
    void Start()
    {
        transform.position.Set(9.0f, 0.203f, -11.0f);
        rb.constraints = RigidbodyConstraints.FreezeRotation;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Tear")
        {
            rb.MovePosition(new Vector3(transform.position.x, -18.0f, transform.position.z));
            //spit1.enabled = false;
            //gameObject.SetActive(false);
            pscore += 1;
            GameObject.FindGameObjectWithTag("P1").GetComponent<TextMesh>().text = "Player 1\n" + pscore;
            
        }
    }
    // Update is called once per frame
    void FixedUpdate()
{
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (pscore == 3)
        {
            spit1.enabled = false;
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("knookle").SetActive(false);
            GameObject.FindGameObjectWithTag("Winner").GetComponent<TextMesh>().text = "Player 1 Wins!";

        }
        if (GetComponent<Renderer>().enabled == false)
        {
            transform.position.Set(transform.position.x, -21.0f, transform.position.z);
            //spit1.enabled = false;
            //gameObject.SetActive(false);
            pscore += 1;
            mesh = GameObject.FindGameObjectWithTag("P2").GetComponent<TextMesh>();
            mesh.text = "Player 2\n" + pscore;

            
            //Application.Quit();

        }
        else
        {



            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.transform.Rotate(new Vector3(0, sideRotation, 0) * Time.deltaTime);

                //rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddRelativeForce(20 * Vector3.forward * Time.deltaTime, ForceMode.VelocityChange);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.transform.Rotate(new Vector3(0, -sideRotation, 0) * Time.deltaTime);
                //rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddRelativeForce(20 * Vector3.back * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (rb.transform.position.y <= -20)
            {
                rb.velocity = Vector3.zero;
                rb.MovePosition(new Vector3(Random.Range(-15.0f, 15.0f), 9.0f, Random.Range(-15.0f, 0.0f)));


            }
        }



    }





}
