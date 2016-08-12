using UnityEngine;
using System.Collections;

public class Conzi : MonoBehaviour {

	Animator anim;
	public float speed;
	public float h;
	public float v;

	public float rSpeed;
	public float clockWise;

	void Start () {
		anim = this.GetComponent<Animator>();
	}
	

	void Update () {

		Move ();

		AnimControll ();

		Rotation ();
	}
	void Move(){
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		transform.Translate(Vector3.forward * Time.deltaTime * speed * v , Space.World);
		transform.Translate(Vector3.right * Time.deltaTime * speed * h, Space.World);
	}
	void AnimControll(){
		if (h != 0 || v != 0) {
			anim.SetBool ("Run", true);
		} else {
			anim.SetBool ("Run", false);
		}

	}
	void Rotation(){

		if (v > 0) {
			if (h > 0) {	//north east(45 degree)
				this.transform.localEulerAngles = new Vector3 (0, 45, 0);
			} else if (h < 0) {	//north west(315 degree)
				this.transform.localEulerAngles = new Vector3 (0, 315, 0);
			} else {	//north (0 degree)
				this.transform.localEulerAngles = new Vector3 (0, 0, 0);
			}
		} else if (v < 0) {
			if (h > 0) {	//south east(135 degree)
				this.transform.localEulerAngles = new Vector3 (0, 135, 0);
			} else if (h < 0) {	//south west(225 degree)
				this.transform.localEulerAngles = new Vector3 (0, 225, 0);
			} else {	//south(180 degree)
				this.transform.localEulerAngles = new Vector3 (0, 180, 0);
			}
		} else {	//v = 0
			if(h > 0){	//east(90 degree)
				this.transform.localEulerAngles = new Vector3(0, 90, 0);
			}else if(h < 0){	//west(270 degree)
				this.transform.localEulerAngles = new Vector3(0, 270, 0);
			}else{	//h = 0 (didn't move)
				//this.transform.localEulerAngles = new Vector3(0, 180, 0);
			}
		}
		/*
		if (v > 0) {
			if (h > 0) {	//north east(45 degree)
				Rotate(45);
			} else if (h < 0) {	//north west(315 degree)
				Rotate(315);
			} else {	//north (0 degree)
				Rotate(0);
			}
		} else if (v < 0) {
			if (h > 0) {	//south east(135 degree)
				Rotate(135);
			} else if (h < 0) {	//south west(225 degree)
				Rotate(225);
			} else {	//south(180 degree)
				Rotate(180);
			}
		} else {	//v = 0
			if(h > 0){	//east(90 degree)
				Rotate(90);
			}else if(h < 0){	//west(270 degree)
				Rotate(270);
			}else{	//h = 0 (didn't move)
				//this.transform.localEulerAngles = new Vector3(0, 180, 0);
			}
		}
		*/
	}
	void Rotate(float targtAngle){
		//Debug.Log (targtAngle);
		float curAngle = this.transform.localEulerAngles.y;
		if (Mathf.Abs (curAngle - targtAngle) > 3) {
			if ( targtAngle >= 360 - curAngle || targtAngle < curAngle) {
				//CounterClockWise
				clockWise = -1;

			} else {
				clockWise = 1;
			}
			//Debug.Log(clockWise);
			this.transform.Rotate (new Vector3 (0, 1, 0) * clockWise * Time.deltaTime * rSpeed);
		} else {
			this.transform.localEulerAngles = new Vector3(0, targtAngle, 0);
		}
	}
}
