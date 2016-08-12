using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public GameObject stage;
	public GameObject[] arrayPlant;
	public GameObject curPlant;
	public int curNo;
	//UI
	public GameObject ui_Main;
	public Text ui_Text;
	public string[] textLine;

	void Start () {
		//focus mode ON
		//CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		//Load text from Resources
		TextAsset textAsset = Resources.Load ("SolarSystem") as TextAsset;
		string textTotal = textAsset.text;
		textLine = textTotal.Split ('/');
		//set Earth
		curNo = 2;	//Earth
		ChangePlant (curNo);
	}
	
	void Update () {

	}

	public void ChangePlant_Next(){
		if (curNo == arrayPlant.Length - 1) {
			curNo = 0;
		} else {
			curNo += 1;
		}
		ChangePlant (curNo);
		Debug.Log ("NextBT");

	}

	public void ChangePlant_Back(){
		if (curNo == 0) {
			curNo = arrayPlant.Length - 1;
		} else {
			curNo -= 1;
		}
		ChangePlant (curNo);
		Debug.Log ("BackBT");

	}
	void ChangePlant(int plantNo){
		Destroy (curPlant);
		curPlant = Instantiate (arrayPlant[plantNo]);
		curPlant.transform.SetParent (stage.transform);
		curPlant.transform.localScale = new Vector3 (1, 1, 1);
		curPlant.transform.localPosition = new Vector3 (0, 0, 0);
		//text
		ui_Text.text = textLine [plantNo];
	}
}
