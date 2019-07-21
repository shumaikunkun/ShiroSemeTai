using UnityEngine;
using System.Collections;

public class MovingEnemyScript : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent agent; //NavMeshのエージェント
	GameObject player; //プレイヤー




	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> (); 
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
        EnemyScript enemyScript = GetComponent<EnemyScript>();  //他のソースコードから参照
        
        agent.SetDestination(player.transform.position);
        if (enemyScript.distance > 5 && enemyScript.distance < 20 )  //遠すぎず近すぎずの位置で敵が止まる
        {
            agent.speed=3.5f;  // 目的地をプレイヤーに設定する。
        }
        else 
        {
            agent.speed=0;
        }
	}
}
