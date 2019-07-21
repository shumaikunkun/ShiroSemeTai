using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

    float timer = 0;
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        timer += Time.deltaTime;
        if (timer-(int)timer<0.5) {  //0.5秒ごとに点滅する
            text.text = "画面をクリックして戦闘開始";
        }
        else
        {
            text.text = "";
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
