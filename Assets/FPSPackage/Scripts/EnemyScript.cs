using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {
    public Canvas canvas;
    public Slider slider;
    
    public int maxEnemyHP = 3;
	public int enemyHP = 3; // 敵の体力
	//public GameObject Bomb; // 爆発のオブジェクト

    public Vector3 playerPos;
    public Vector3 enemyPos;
    public float distance;

    public GameObject allow;

    Transform playerTransform;

    float timer;

    public GameObject rice;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        if (this.gameObject.name == "MovingEnemy1") { maxEnemyHP = enemyHP = 5; }
        if (this.gameObject.name == "MovingEnemy2") { maxEnemyHP = enemyHP = 10; }

    }

    void Update()
    {
        //transform.rotation = Camera.main.transform.rotation;
        //カメラの方向に向かせる。
        canvas.transform.LookAt(playerTransform);
        playerPos = GameObject.Find("Player").transform.position;  //プレイヤーの座標
        enemyPos = transform.position;  //敵の座標
        distance = Vector2.Distance(playerPos, enemyPos);  //敵とプレイヤーとの距離
        timer += Time.deltaTime;

        if (timer >= 10 && distance < 50)
        {
            Instantiate(allow, transform.position + new Vector3(1, 1.5f, 1), transform.rotation).GetComponent<Rigidbody>().AddForce((playerPos - enemyPos) * 100);
            timer = 0;
        }
    }
            

	// Playerにダメージを与えられた時
	void Damage(){
		enemyHP--; //体力を1減らす
        slider.maxValue = maxEnemyHP;
        slider.value = enemyHP;


		// 体力がゼロになったら
		if (enemyHP == 0) {
            //if (Bomb) {
            // 爆発を起こす
            //Instantiate (Bomb, transform.position, transform.rotation);
            //}
            // 敵を倒した数を1増やす
            Instantiate(rice, transform.position, Quaternion.identity);
            ScoreManager.instance.enemyCount++;
			Destroy (this.gameObject); //自分をしょうめつさせる
            gameObject.SetActive(false);

		}
	}
	// 物にさわった時に呼ばれる
	void OnTriggerEnter(Collider col){
		// もしPlayerにさわったら
		if (col.gameObject.tag == "Player") {
			col.SendMessage ("Damage"); //ダメージを与えて
            Destroy(this.gameObject);
        }
		// 自分は消える

	}
}
