using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoosePanel : MonoBehaviour {
    //public GameObject squareBtn;   
    public GameObject bluePanel;
    public GameObject redPanel;
    public GameObject greenPanel;
    public GameObject yellowPanel;
    string currentColorPanel;
    public Button current;
    public GameObject currentBtn;
    // Use this for initialization
    public void setCurrentBtn(Button b) {
        current = b;
    }
    public void setCurrentBigBtn(GameObject btn) {
        currentBtn = btn;
    }
    public Button getCurrentBtn() {
        return current;
    }

    public void setPanelColor() {
        if (currentColorPanel == "blue") {
            bluePanel.SetActive(false);
            greenPanel.SetActive(true);
            currentColorPanel = "green";
        } else if (currentColorPanel == "green") {
            greenPanel.SetActive(false);
            redPanel.SetActive(true);
            currentColorPanel = "red";

        } else if (currentColorPanel == "red") {
            redPanel.SetActive(false);
            yellowPanel.SetActive(true);
            currentColorPanel = "yellow";

        } else if (currentColorPanel == "yellow") {
            yellowPanel.SetActive(false);
            bluePanel.SetActive(true);
            currentColorPanel = "blue";
        }
    }

    public void ShowGreen() {
        bluePanel.SetActive(false);
        greenPanel.SetActive(true);
        currentColorPanel = "green";
    }

    public void ShowRed() {
        bluePanel.SetActive(false);
        redPanel.SetActive(true);
        currentColorPanel = "red";
    }

    public void ShowYellow() {
        bluePanel.SetActive(false);
        yellowPanel.SetActive(true);
        currentColorPanel = "yellow";
    }

    public void DestoryBtn() {
        Destroy(currentBtn);
    }



    void Start() {
        bluePanel.SetActive(true);
        currentColorPanel = "blue";
    }

    // Update is called once per frame
    void Update() {

    }
}
