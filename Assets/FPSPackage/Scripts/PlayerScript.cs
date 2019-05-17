using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript: MonoBehaviour {

    public const int maxplayerHP = 100;
    public int playerHP = 100;
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
        HPLabel.text = playerHP.ToString();
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


            SceneManager.LoadScene("GameOver");

            //Enemyタグがついているゲームオブジェクトをすべて消す
            //GameObject.FindGameObjectsWithTag("Enemy")は配列を返す
            //for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
            //{
            //    Destroy(GameObject.FindGameObjectsWithTag("Enemy")[i]);
            //}
            //プレイヤーが移動しないようにする
            //GetComponent<CharacterController>().enabled = false;

            //gameOver.text = "GAME OVER";

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

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="rice")
        {
            for(int i = 0; i < 5; i++)  //HP5回復する
            {
                if (playerHP < 100)
                {
                    playerHP += 1;
                    slider.value = playerHP;
                    HPLabel.text = playerHP.ToString();
                }
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "BigRice")  //でっかいおにぎりに触れたらHP全回復
        {
            playerHP = 100;
            Destroy(col.gameObject);
        }
    }

}

