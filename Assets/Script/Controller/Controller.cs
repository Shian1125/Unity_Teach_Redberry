using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	//controller
	public float space;
	public Transform mainPoint;
	public Transform kPoint;
	public float r;
	float oriWidth;
	float scale;
	float mDis;
	float kDis;
	//conzi
	public GameObject model;
	public Transform facePoint;
	public float wSpeed;

	void Start () {
		oriWidth = 1920;
		//calculate scaling of screen
		scale = (float)Screen.width / oriWidth;

		float selfWidth = this.GetComponent<RectTransform>().sizeDelta.x;
		r = ((selfWidth / 2) - space) * scale;
	}
	
	void Update () {
		ConziFaceAndMove();
	}
	public void Drag(){
		if(Input.touchCount > 0){
			kPoint.position = Input.GetTouch(0).position;
		}else{
			kPoint.position = Input.mousePosition;
		}
		kDis = Vector2.Distance(kPoint.position, this.transform.position);

		if(kDis < r){
			mainPoint.position = Input.GetTouch(0).position;
		}else{
			float a = Mathf.Abs(kPoint.localPosition.x);
			float b = Mathf.Abs(kPoint.localPosition.y);
			mainPoint.localPosition = Position(a, b);
		}
	}
	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(mainPoint.position, this.transform.position);
		Gizmos.DrawWireSphere(this.transform.position, r);
	}
	Vector3 Position(float a, float b){
		//calculate mPoint when touchPoint out of range
		float x = Mathf.Sqrt(Mathf.Pow(r,2) / (1 + Mathf.Pow(b,2) / Mathf.Pow(a,2)));
		float y = x * (b / a);
		//decide quadrant
		float i = kPoint.localPosition.x;
		float k = kPoint.localPosition.y;
		Vector3 posi = new Vector3();
		if(i < 0){
			if(k < 0){	posi = new Vector3(-x, -y, 0);	}
				else {	posi = new Vector3(-x, y, 0);	}
		}else{
			if(k < 0){	posi = new Vector3(x, -y, 0);	}
				else {	posi = new Vector3(x, y, 0);	}
		}
		return posi * 1 /scale;
	}
	public void Drop(){
		mainPoint.localPosition = new Vector3(0, 0, 0);
		kPoint.localPosition = new Vector3(0, 0, 0);
	}
	void ConziFaceAndMove(){
		Animator anim = model.GetComponent<Animator>();
		mDis = Vector2.Distance(mainPoint.position, this.transform.position);
		//detect moving or not
		if(mDis != 0){
			facePoint.transform.localPosition = new Vector3(mainPoint.localPosition.x , facePoint.transform.localPosition.y, mainPoint.localPosition.y);
			model.transform.LookAt(facePoint.transform);
			model.transform.Translate(Vector3.forward * Time.deltaTime * wSpeed * mDis / r);
			anim.SetBool ("Run", true);
		}else{
			anim.SetBool ("Run", false);
		}

	}
}
