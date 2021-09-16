using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forward = 50f;
    public float right = 50f;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0,0,forward*Time.deltaTime,ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0,0,-forward*Time.deltaTime,ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(right*Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-right*Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
    }
}
