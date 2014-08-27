using UnityEngine;
using System.Collections;

public class Parallexing : MonoBehaviour {

	public Transform[] backgrounds;			// Array List of all Back und Foregrounds
	private float[]  parallexScales;		// Cameras Movement scales
	public float smoothing = 1f;

	private Transform cam;
	private Vector3 previousCamPos;

	// Called before Start()
	void Awake() {
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		previousCamPos = cam.position;

		parallexScales = new float[backgrounds.Length];
		for (int i=0; i< backgrounds.Length; i++) {
			parallexScales[i] = backgrounds[i].position.z*-1; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i< backgrounds.Length; i++) {
			float parallax = (previousCamPos.x -cam.position.x) * parallexScales[i];

			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX,backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position,backgroundTargetPos,smoothing * Time.deltaTime);
		}

		previousCamPos = cam.position;
	}
}
