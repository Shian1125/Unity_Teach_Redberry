using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

	Animator anim;
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	public void CloclWise(){
		anim.SetFloat("Speed", 1);
	}
	public void CounterCloclWise(){
		anim.SetFloat("Speed", -1);
	}
	public void Stop(){
		anim.SetFloat("Speed", 0);
	}
}
