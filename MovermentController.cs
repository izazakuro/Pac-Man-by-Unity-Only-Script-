using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovermentController : MonoBehaviour
{

    public GameManager gameManager;

    public GameObject currentNode;
    public float speed = 2.5f;

    public string direction = "";
    public string lastMovingDirection = "";

    public bool canWarp = true;

    public bool isGhost = false;


    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameIsRunning)
        {
            return;
        }


        NodeController currentNodeController = currentNode.GetComponent<NodeController>();

        transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, speed * Time.deltaTime); // リアルタイムに栽わせる

        bool reverseDirection = false;
        if (
            (direction == "left" && lastMovingDirection == "right") ||
            (direction == "right" && lastMovingDirection == "left") ||
            (direction == "up" && lastMovingDirection == "down") ||
            (direction  == "down" && lastMovingDirection == "up")
            )
            {
            reverseDirection = true;
        }

        //いまがいるところが�F壓のノ�`ドの寔ん嶄にいるかどうかを�_�Jする
        if((transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y) || reverseDirection)
        {
            if (isGhost)
            {
                GetComponent<EnemyController>().ReachedCenterofNode(currentNodeController);
            }
            //匯桑安に秘りましたら、嘔に剃��する
            if (currentNodeController.isWarpLeftNode && canWarp)
            {
                currentNode = gameManager.rightWarpNode;
                direction = "left";
                lastMovingDirection = "left";
                transform.position = currentNode.transform.position;
                canWarp = false;

            }
            //匯桑安に秘りましたら、恣に剃��する
            else if(currentNodeController.isWarpRightNode && canWarp)
            {
                currentNode = gameManager.leftWarpNode;
                direction = "right";
                lastMovingDirection = "right";
                transform.position = currentNode.transform.position;
                canWarp = false;

            }
            //麿の��栽、肝のノ�`ドを冥し、卞�咾垢�
            else
            {
                //ゴ�`ストではない、スタ�`トノ�`ドにいる�Hに、さらに、和に卞�咾靴燭い箸�、峭まる
                if(currentNodeController.isGhostStartingNode && direction == "down" && 
                    (!isGhost || GetComponent<EnemyController>().ghostNodeState != EnemyController.GhostNodeStatesEnum.respawning))
                {
                    direction = lastMovingDirection;
                }

                //書の了崔から肝に卞�咾任�るノ�`ドを�{べる
                GameObject newNode = currentNodeController.GetNodeFromDirection(direction);
                if (newNode != null)
                {
                    currentNode = newNode;
                    lastMovingDirection = direction;
                }
                // 卞�咾靴燭い箸海蹐慴��咾任�ない��栽に、さっきと揖じ圭�鬚拝��咾珪Aける
                else
                {
                    direction = lastMovingDirection;
                    newNode = currentNodeController.GetNodeFromDirection(direction);
                    if (newNode != null)
                    {
                        currentNode = newNode;

                    }
                }
            }
           
        }
        else
        {

            canWarp = true;

        }
    }


    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetDirection(string newDirection)
    {
        direction = newDirection;

    }
}
