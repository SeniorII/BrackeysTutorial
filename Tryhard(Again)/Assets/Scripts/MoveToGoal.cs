using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToGoal : Agent
{
    [SerializeField] private Transform targetTransform;
    float x, z;
    public float ms = 3f;
    [SerializeField] private Material rewardMaterial;
    [SerializeField] private Material punishMaterial;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private MeshRenderer groundRenderer;
    
    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(Random.Range(-4.4f,4.4f),0,Random.Range(-4.4f,4.4f));
        targetTransform.localPosition = new Vector3(Random.Range(-4.4f,4.4f),0,Random.Range(-4.4f,4.4f));
    }

    public override void CollectObservations(VectorSensor sensor) {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        x = actions.ContinuousActions[0];
        z = actions.ContinuousActions[1];
        transform.localPosition += new Vector3(x,0,z)*Time.deltaTime*ms;
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.collider.tag =="Reward")
        {
            groundRenderer.material = rewardMaterial;
            SetReward(1f);
            EndEpisode();
        }
        else if(obj.collider.tag=="Wall")
        {
            groundRenderer.material = punishMaterial;
            SetReward(-1f);
            EndEpisode();
        }
        else
            groundRenderer.material = normalMaterial;
    }
}
