using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TilingPlatforms : MonoBehaviour {

	public float maxHeight = 2f;
	public float offsetX = -200f;
	public bool isRoot = false;
	public float rePlaceoffset = 5;

	private List<float> allCreated;

	private float camMinX = 0;
	private float camMaxX = 0;

	private float camX = 0;
	//private int index = 0;
	//public float spriteWidth = 0f;

	//public bool hasARightBuddy = false;
	//public bool hasALeftBuddy = false;

	private Camera cam;
	private Transform myTransform;
	
	void Awake(){
		cam = Camera.main;
		myTransform = transform;
		allCreated = new List<float>();
		allCreated.Add(0);
		offsetX = cam.transform.position.x;

		var dist = (transform.position - cam.transform.position).z;
		camMinX = cam.ViewportToWorldPoint(new Vector3(0,0,dist)).x;
		camMaxX = cam.ViewportToWorldPoint(new Vector3(1,0,dist)).x;

		//InvokeRepeating("MakeNewBody", 1f, 3f);
	}
	
	// Use this for initialization
	void Start () {
		if (isRoot) {
			MakeNewBody (-1);
			MakeNewBody (-1);
			MakeNewBody (1);
			MakeNewBody (1);
		}
	}

	
	// Update is called once per frame
	void Update () {
		if (isRoot) {
			var dist = (transform.position - cam.transform.position).z;
			var leftBorder = cam.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
			var rightBorder = cam.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;


			if((cam.transform.position.x-camX)>5){
				MakeNewBody (-1);
				camX = cam.transform.position.x;
				Debug.Log ("tet");
			}
		}

	}
	
	public void MakeNewBody(int rightOrLeft){

		float randomHeight = Random.Range(-2,maxHeight);
		if (rightOrLeft < 0) {
			offsetX = allCreated[allCreated.Count - 1] + Random.Range(8,15);
		}else if(rightOrLeft > 0){
			offsetX = (allCreated[0] + Random.Range(8,15))*-1;
		}
		Vector3 newPosition = new Vector3 (myTransform.position.x + offsetX ,myTransform.position.y+randomHeight,myTransform.position.z);

		Transform newBody = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;
		newBody.GetComponent<TilingPlatforms>().isRoot = false;
		if (rightOrLeft < 0) {
			allCreated.Add(newBody.position.x);
		}else if(rightOrLeft > 0){
			allCreated.Reverse();
			allCreated.Add(newBody.position.x);
			allCreated.Reverse();
		}

		newBody.parent = myTransform.parent;
	}
}
