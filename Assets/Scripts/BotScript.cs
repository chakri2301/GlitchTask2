using UnityEngine;
using UnityEngine.AI;

public class BotScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
