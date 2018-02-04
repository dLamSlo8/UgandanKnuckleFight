
using UnityEngine;


public class Player2Movement : MonoBehaviour
{

    public Rigidbody rb;
    public Spit2 spit2;
    // Adds a forward force to player object.
    public float forwardForce = 2000f;
    public float movementForce = 1000f;
    //public float sidewayForce = 50f;
    public float sideRotation = 75f;
    public int pscore = 0;
    public TextMesh mesh;
    // Use this for initialization
    void Start()
    {
        transform.position.Set(-9.0f, 0.203f, -11.0f);
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
            GameObject.FindGameObjectWithTag("P2").GetComponent<TextMesh>().text = "Player 2\n" + pscore;

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (pscore == 3)
        {
            spit2.enabled = false;
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("knookle").SetActive(false);
            GameObject.FindGameObjectWithTag("Winner").GetComponent<TextMesh>().text = "Player 2 Wins!";

        }


            if (Input.GetKey("d"))
            {
                rb.transform.Rotate(new Vector3(0, sideRotation, 0) * Time.deltaTime);

                //rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else if (Input.GetKey("w"))
            {
                rb.AddRelativeForce(20 * Vector3.forward * Time.deltaTime, ForceMode.VelocityChange);
            }
            else if (Input.GetKey("a"))
            {
                rb.transform.Rotate(new Vector3(0, -sideRotation, 0) * Time.deltaTime);
                //rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else if (Input.GetKey("s"))
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
