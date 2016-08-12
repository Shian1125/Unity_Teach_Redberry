using UnityEngine;
using System.Collections;
using Vuforia;

public class Detect : MonoBehaviour {

	public GameObject detectCube;
	public GameObject ui;

	Renderer ren;

	void Start () {
		//focus mode ON
		CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		ren = detectCube.GetComponent<Renderer>();
	}
	
	void Update () {
		Detecting ();
	}

	void Detecting(){
		if (ren.enabled) {
			ui.SetActive (true);
		} else {
			ui.SetActive (false);
		}
	}
}
