using UnityEngine;

public class FollowAgent : MonoBehaviour
{
    public Transform AgentTransform;
    public Vector3 offset = new Vector3 (0f,1f,-4f);
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = AgentTransform.position + offset;
    }
}
