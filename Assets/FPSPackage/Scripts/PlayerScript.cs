using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript: MonoBehaviour {

    public const int maxplayerHP = 10;
    public int playerHP = 10;
    public Text HPLabel;

    public Text gameOver;

    public Slider slider;

    //public int bulletCount = 20;  //弾の数
    //public Text bulletLabel;

    //public int reloadCount = 10;  //リロードの弾数
    //public Text reloadLabel;

    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject pauseUIInstance;

    // ゲームの1フレームごとに呼ばれるメソッド
    void Update () {
        HPLabel.text = "PlayerHP:" + playerHP.ToString();
        //bulletLabel.text = "残り弾数: " + bulletCount;
        //reloadLabel.text = "リロード数: " + reloadCount;

	}

	// ダメージを与えられた時に行いたい命令を書く
	void Damage(){
        playerHP--;
        slider.maxValue = maxplayerHP;
        slider.value = playerHP;

        if (playerHP <= 0)
        {


            //SceneManager.LoadScene("GameOver");

            //Enemyタグがついているゲームオブジェクトをすべて消す
            //GameObject.FindGameObjectsWithTag("Enemy")は配列を返す
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Enemy")[i]);
            }
            //プレイヤーが移動しないようにする
            //GetComponent<CharacterController>().enabled = false;

            gameOver.text = "GAME OVER";

            //pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;

        }

	}


    //void OnTriggerEnter(Collider col)
    //{
        //if (col.gameObject.tag=="Bullet")
        //{
            //bulletCount += 10;
            //Destroy(col.gameObject);
        //}
    //}
}

