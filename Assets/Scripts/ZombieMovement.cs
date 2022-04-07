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
            Vector3 player1Position = player1.position;
            player1Position.y -= 1.8f;
            if (player2 != null)
            {
                Vector3 zombiePosition = zombie.position;
                Vector3 player2Position = player2.position;
                player2Position.y -= 1.8f;
                float player1Distance = Vector3.Distance(zombiePosition, player1Position);
                float player2Distance = Vector3.Distance(zombiePosition, player2Position);

                if (player3 != null)
                {
                    Vector3 player3Position = player3.position;
                    player3Position.y -= 1.8f;
                    float player3Distance = Vector3.Distance(zombiePosition, player3Position);

                    if (player4 != null)
                    {
                        Vector3 player4Position = player4.position;
                        player4Position.y -= 1.8f;
                        float player4Distance = Vector3.Distance(zombiePosition, player4Position);

                        if (player1Distance < player2Distance && player1Distance < player3Distance && player1Distance < player4Distance)
                        {
                            destination = player1Position;
                        }
                        else if (player2Distance < player1Distance && player2Distance < player3Distance && player2Distance < player4Distance)
                        {
                            destination = player2Position;
                        }
                        else if (player3Distance < player1Distance && player3Distance < player2Distance && player3Distance < player4Distance)
                        {
                            destination = player3Position;
                        }
                        else
                        {
                            destination = player4Position;
                        }
                    }
                    else
                    {
                        if (player1Distance < player2Distance && player1Distance < player3Distance)
                        {
                            destination = player1Position;
                        }
                        else if (player2Distance < player1Distance && player2Distance < player3Distance)
                        {
                            destination = player2Position;
                        }
                        else
                        {
                            destination = player3Position;
                        }
                    }
                }
                else
                {
                    if (player1Distance < player2Distance)
                    {
                        destination = player1Position;
                    }
                    else
                    {
                        destination = player2Position;
                    }
                }
            }
            else
            {
                destination = player1Position;
            }
        }
    }
}
