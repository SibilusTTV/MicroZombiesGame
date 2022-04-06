using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform zombie;

    private Transform player1;
    private Transform player2;
    private Transform player3;
    private Transform player4;
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player1Object = GameObject.Find("Player1");
        GameObject player2Object = GameObject.Find("Player2");
        GameObject player3Object = GameObject.Find("Player3");
        GameObject player4Object = GameObject.Find("Player4");
        if (player1Object != null)
        {
            player1 = player1Object.transform;

            if (player2Object != null)
            {
                player2 = player2Object.transform;

                if (player3Object != null)
                {
                    player3 = player3Object.transform;

                    if (player4Object != null)
                    {
                        player4 = player4Object.transform;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetClosestPlayer();

        agent.SetDestination(destination);
    }

    public void GetClosestPlayer()
    { 
        if (player1 != null)
        {
            if (player2 != null)
            {
                float player1Distance = Vector3.Distance(zombie.position, player1.position);
                float player2Distance = Vector3.Distance(zombie.position, player2.position);

                if (player3 != null)
                {
                    float player3Distance = Vector3.Distance(zombie.position, player3.position);

                    if (player4 != null)
                    {
                        float player4Distance = Vector3.Distance(zombie.position, player4.position);

                        if (player1Distance < player2Distance && player1Distance < player3Distance && player1Distance < player4Distance)
                        {
                            destination = player1.position;
                        }
                        else if (player2Distance < player1Distance && player2Distance < player3Distance && player2Distance < player4Distance)
                        {
                            destination = player2.position;
                        }
                        else if (player3Distance < player1Distance && player3Distance < player2Distance && player3Distance < player4Distance)
                        {
                            destination = player3.position;
                        }
                        else
                        {
                            destination = player4.position;
                        }
                    }
                    else
                    {
                        if (player1Distance < player2Distance && player1Distance < player3Distance)
                        {
                            destination = player1.position;
                        }
                        else if (player2Distance < player1Distance && player2Distance < player3Distance)
                        {
                            destination = player2.position;
                        }
                        else
                        {
                            destination = player3.position;
                        }
                    }
                }
                else
                {
                    if (player1Distance < player2Distance)
                    {
                        destination = player1.position;
                    }
                    else
                    {
                        destination = player2.position;
                    }
                }
            }
            else
            {
                destination = player1.position;
            }
        }
    }
}
