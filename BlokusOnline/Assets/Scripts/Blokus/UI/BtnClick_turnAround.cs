using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnClick_turnAround : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Button> ().onClick.AddListener(turnAround);
	}
	void turnAround()
	{
		Button turnBtn=GameObject.Find ("Canvas").GetComponent<ChoosePanel> ().getCurrentBtn ();
		if (turnBtn == null)
			return;
		turnBtn.transform.Find("Image").transform.Rotate (new Vector3 (0, 180, 0),Space.World);
		//rotateImage.transform.Rotate(new Vector3 (0, 180, 0),Space.World);
		//turnBtn.GetComponent<Image> ().sprite = rotateImage;
		//turnBtn.transform.localScale*=-1;
		//GameObject.Find ("Canvas/squareAdjust_Panel/rotateBtn").GetComponent<BtnClick_Rotate> ().setTurnFlag (1);
		GameObject.Find ("BlokusController").GetComponent<BlokusController> ().squareSymmetry();

	}
	// Update is called once per frame
	void Update () {
		
	}
}
