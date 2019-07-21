using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    float timer= new System.Random().Next(10);  //timerの初期値は0～9の間（敵ごとにバラバラに撃ち始めさせるため）

    public GameObject rice;
    public GameObject exp;
    public GameObject perticle;

    public AudioClip throwSound;
    AudioSource audioSource; //音源（スピーカー）

    private void Start()
    {
        if (this.gameObject.name == "MovingEnemy1" || this.gameObject.name == "StoppingEnemy") { maxEnemyHP = enemyHP = 5; }
        if (this.gameObject.name == "MovingEnemy2") { maxEnemyHP = enemyHP = 10; }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = throwSound;

    }

    void Update()
    {
        //transform.rotation = Camera.main.transform.rotation;
        //カメラの方向に向かせる。
        //canvas.transform.LookAt(playerTransform);
        //transform.rotation = Quaternion.LookRotation(playerPos, Vector3.up);

        playerPos = GameObject.Find("Player").transform.position;  //プレイヤーの座標
        enemyPos = transform.position;  //敵の座標
        distance = Vector2.Distance(playerPos, enemyPos);  //敵とプレイヤーとの距離

        Vector3 target = playerPos;
        target.y = transform.position.y;
        transform.LookAt(target);  //y軸を固定してプレイヤーを向かせる

        timer += Time.deltaTime;

        if (timer  >= 10 && distance < 50)
        {
            Instantiate(allow, transform.position + new Vector3(1, 1.5f, 1), transform.rotation).GetComponent<Rigidbody>().AddForce((playerPos - enemyPos) * 100);
            audioSource.Play();
            timer = 0;
        }
    }


	// Playerにダメージを与えられた時
	void Damage(){
		enemyHP--; //体力を1減らす
        slider.maxValue = maxEnemyHP;
        slider.value = enemyHP;

        transform.position += (enemyPos - playerPos)/10;  //ダメージ受けるとちょっと後ろに下がる
        Instantiate(perticle, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);  //流血


        // 体力がゼロになったら
        if (enemyHP == 0) {
            //if (Bomb) {
            // 爆発を起こす
            //Instantiate (Bomb, transform.position, transform.rotation);
            //}
            // 敵を倒した数を1増やす
            if (this.gameObject.name == "MovingEnemy2")
            {
                SceneManager.LoadScene("GameClear");
            }
            if (timer > 7)  //擬似乱数によって落下物を決めて生成（3/10でおにぎり、7/10で経験値を落下）
            {
                Instantiate(rice, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(exp, transform.position, Quaternion.identity);
            }

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
            //Destroy(this.gameObject);
        }
		// 自分は消える

	}
}
