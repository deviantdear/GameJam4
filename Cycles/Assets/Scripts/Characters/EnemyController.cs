using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent; //Allows us to use AI 
    Combat enemyCombat;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform; //Creates reference to the players location
        enemyCombat = GetComponent<Combat>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                //Attack
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    enemyCombat.Attack(targetStats);
                }
                FaceTarget(); //Face Target
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized; //gets postion of target and subtracts our position from it 
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); //calculates rotation of enemy
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); //smooths out transition of turn
    }

    private void OnDrawGizmosSelected()
    {
        //Shows in Unity inspect the range of vision of the Enemy.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
