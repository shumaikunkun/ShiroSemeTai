using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryManager : MonoBehaviour {

    public Text text;

	void Update(){

            //text.text = ScoreManager.instance.enemyCount.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            Retry(); //リトライ
        }
    }

	// リトライメソッド
	public void Retry(){
		if (ScoreManager.instance) {
			// 敵を倒した回数をゼロにリセットする 
			ScoreManager.instance.enemyCount = 0;
		}

        // メインシーンに移動する
        SceneManager.LoadScene("Start");
	}
}
