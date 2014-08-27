using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class OnFallDestroy : MonoBehaviour {

	public float deathOffset = -7f;
	private PlatformerCharacter2D character;

	private bool gameOver = false;
	public GUISkin guiSkin;
	Rect windowRect = new Rect (0, 0, 620, 520);

	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



		if(character.transform.position.y < deathOffset){
			//Destroy(character);
			windowRect.x = (Screen.width - windowRect.width) / 2;
			windowRect.y = (Screen.height - windowRect.height) / 2;

			gameOver = true;
			Time.timeScale =0;
			//Application.LoadLevel(Application.loadedLevel);
		}
	}

	void OnGUI(){
		if (gameOver){
			GUI.skin = guiSkin;
			windowRect = GUI.Window (0, windowRect, OverMenu, "Game Over");
		}
	}
	
	void OverMenu(int windowOver) {

		GUIStyle labelStyle = new GUIStyle ();
		labelStyle.fontSize = 30;
		labelStyle.normal.textColor = Color.white;

		GUI.Label(new Rect(140,70,340,50),"Highscore: "+Highscore.highscore,labelStyle);// Highscore.highscore
		if (GUI.Button (new Rect (140, 250, 340, 50), "Restart")) {
			Application.LoadLevel ("Scene1");
		}
		/*if (GUI.Button ( new Rect(140,120,340,50), "Main Menu"))
			Application.LoadLevel ("Menu");
		GUI.Button ( new Rect(140,190,340,50), "Options");*/
		//GUI.Button ( new Rect(140,260,340,50), "Score: " +GameLogicScript.score);
		if (GUI.Button (new Rect (140, 330, 340, 50), "Quit")) {
			Application.Quit ();
		}
	}
}
