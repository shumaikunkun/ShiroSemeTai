using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {
    public Canvas canvas;
    public Slider slider;
    public const int maxEnemyHP = 3;

	public int enemyHP = 3; // 敵の体力
	public GameObject Bomb; // 爆発のオブジェクト

    public Vector3 playerPos;
    public Vector3 enemyPos;
    public Vector2 playerPos2d;
    public Vector2 enemyPos2d;

    public GameObject allow;

    Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //transform.rotation = Camera.main.transform.rotation;
        //カメラの方向に向かせる。
        canvas.transform.LookAt(playerTransform);
        playerPos = GameObject.Find("Player").transform.position;
        enemyPos = transform.position;
        playerPos2d = new Vector2(playerPos.x, playerPos.z);
        enemyPos2d = new Vector2(enemyPos.x, enemyPos.z);

        if (Input.GetKey(KeyCode.Z))
        {
            var obj = Instantiate(allow, transform.position + new Vector3(0, 1.5f, 0), transform.rotation);
            obj.transform.LookAt(playerPos);
            obj.GetComponent<Rigidbody>().AddForce((playerPos - enemyPos) * 100);
        }

    }

	// Playerにダメージを与えられた時
	void Damage(){
		enemyHP--; //体力を1減らす
        slider.maxValue = maxEnemyHP;
        slider.value = enemyHP;


		// 体力がゼロになったら
		if (enemyHP == 0) {
			if (Bomb) {
				// 爆発を起こす
				Instantiate (Bomb, transform.position, transform.rotation);
			}
			// 敵を倒した数を1増やす
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
