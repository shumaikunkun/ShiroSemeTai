using UnityEngine;
using System.Collections;

public class MovingEnemyScript : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent agent; //NavMeshのエージェント
	GameObject player; //プレイヤー


    float distance;

	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> (); 
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
        EnemyScript enemyScript = GetComponent<EnemyScript>();  //他のソースコードから参照
        distance = Vector2.Distance(enemyScript.playerPos2d, enemyScript.enemyPos2d);  //敵とプレイヤーとの距離
        agent.SetDestination(player.transform.position);
        if (distance > 8 && distance < 30 )  //遠すぎず近すぎずの位置で敵が止まる
        {
            agent.speed=3.5f;  // 目的地をプレイヤーに設定する。

        }
        else 
        {
            agent.speed=0;
        }
	}
}
