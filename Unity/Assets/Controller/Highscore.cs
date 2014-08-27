using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {

	public Transform target;
	public static float highscore;

	private GUIText highscoreText;
	private float lastPosition;

	
	void Awake(){
		highscoreText = guiText;
		Time.timeScale = 1;
	}

	// Use this for initialization
	void Start () {
		highscore = 0;
		highscoreText.text = "Highscore: "+highscore;
		lastPosition = target.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(target.position.x-lastPosition>1){
			lastPosition = target.position.x;
			highscore++;
			highscoreText.text = "Highscore: "+highscore;
		}

	}
}
