using UnityEngine;
using System.Collections;

public class HitAndDestroy : MonoBehaviour {

	public float force = -500f;
	public float destroyAtPosition = 0f;
	public float defaultY = 12f;

	public float spawnTime = 50f;

	Transform myTransform;


	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Camera.main.transform.position.x % 50);
		if(Camera.main.transform.position.x % spawnTime > spawnTime-1 && gameObject.rigidbody2D.gravityScale == 0){
			ReplaceAndSetActive();
		}
		if(myTransform.position.y < destroyAtPosition){
			gameObject.rigidbody2D.gravityScale = 0; 
			gameObject.rigidbody2D.AddForce(new Vector2(0,0));
			myTransform.position =  new Vector3 (myTransform.position.x ,myTransform.position.y,-10000);
		}
	}

	void ReplaceAndSetActive(){
		float dist = (transform.position - Camera.main.transform.position).z;
		//float camMaxY = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).y;
		float camMaxY = defaultY;
		float camMaxX = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).x;

		Debug.Log (camMaxY);
		Debug.Log (camMaxX);

		float randomX = Random.Range (camMaxX-15,camMaxX-5);
		float randomY = Random.Range (camMaxY-15,camMaxY-5);
		myTransform.position =  new Vector3 (randomX ,randomY,0);
		gameObject.rigidbody2D.gravityScale = 1; 
		gameObject.rigidbody2D.AddForce(gameObject.transform.right*force);

	}

	void OnCollisionEnter2D(Collision2D theCollision){
		if(theCollision.gameObject.tag == "Player"){
			Debug.Log("Hit the Player");
			gameObject.rigidbody2D.gravityScale = 0; 
			gameObject.rigidbody2D.AddForce(new Vector2(0,0));
			myTransform.position =  new Vector3 (myTransform.position.x ,defaultY,-10000);
		}else if(theCollision.gameObject.tag == "Mushroom"){
			Destroy(theCollision.gameObject);
		}
	}
}
