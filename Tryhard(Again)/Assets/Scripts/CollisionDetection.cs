using UnityEngine;
using UnityEngine.UI;
public class CollisionDetection : MonoBehaviour
{
    public Text text;
    void OnCollisionEnter(Collision obj)
    {
        if (obj.collider.tag =="Reward")
        {
            text.text = "Positive Reward";
            Debug.Log("+50");
        }
        if(obj.collider.tag=="Wall")
        {
            text.text = "Negative Reward";
            Debug.Log("Highway to hell");
        }
    }
}
