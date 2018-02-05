using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnClick_Rotate : MonoBehaviour {
	public bool turn_flag=true;
	//public Button RotateButton;
	// Use this for initialization

	void Start () {
		this.GetComponent<Button> ().onClick.AddListener(Rotate);
	}
	void Rotate()
	{
		
		Button rotateBtn=GameObject.Find ("Canvas").GetComponent<ChoosePanel> ().getCurrentBtn ();
		if (rotateBtn == null)
			return;
		//if(turn_flag==true)
		rotateBtn.transform.Find("Image").transform.Rotate(new Vector3(0,0,-90));
		/*else
			rotateBtn.transform.Rotate(new Vector3(0,0,90));
		*/
		GameObject.Find ("BlokusControl").GetComponent<BlokusControl> ().squareRotation ();
	}

	//public void setTurnFlag(int state)
	//{
	//	if (state == 1)
	//		turn_flag = !turn_flag;
	//	else
	//		turn_flag = true;
	//}
	// Update is called once per frame
	void Update () {
		
	}
}
