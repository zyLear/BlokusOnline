using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnClick : MonoBehaviour {


    // Use this for initialization
    void Start() {
        this.GetComponent<Button>().onClick.AddListener(Choose);
    }
    void Choose() {

        string squareName0 = this.transform.Find("Image").GetComponent<Image>().sprite.ToString();
        string[] squareName = squareName0.Split(' ');

        //print (squareName[0]+"1");

        GameObject.Find("BlokusController").GetComponent<BlokusController>().setCurrentSquareName(squareName[0]);

        /*Button preBtn=GameObject.Find ("Canvas").GetComponent<ChoosePanel> ().getCurrentBtn ();
		if (preBtn != null)
		{
			
			Vector3 rotation = preBtn.transform.localEulerAngles;
			rotation.x = 0;rotation.y = 0;rotation.z = 0;
			preBtn.transform.localEulerAngles = rotation;
			GameObject.Find ("Canvas/menu Panel/rotateBtn").GetComponent<BtnClick_Rotate> ().setTurnFlag (0);
		}
*/
        //GameObject.Find ("Canvas/squareAdjust_Panel/rotateBtn").GetComponent<BtnClick_Rotate> ().setTurnFlag (0);
        GameObject.Find("Canvas").GetComponent<ChoosePanel>().setCurrentBtn(this.GetComponent<Button>());
        GameObject.Find("Canvas").GetComponent<ChoosePanel>().setCurrentBigBtn(this.gameObject);

    }
}
