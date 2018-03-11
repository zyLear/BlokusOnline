using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogItemData : MonoBehaviour {


    [HideInInspector]
    public string result;
    [HideInInspector]
    public string stepsCount;
    [HideInInspector]
    public string gameType;
    [HideInInspector]
    public string detail;
    [HideInInspector]
    public string time;



    public Text resultText;
    public Text stepsCountText;
    public Text gameTypeText;
    public Text detailText;
    public Text timeText;

    public void ShowGameLogInfo() {
        resultText.text = result;
        stepsCountText.text = stepsCount;
        gameTypeText.text = gameType;
        detailText.text = detail;
        timeText.text = time;
    }

    //private string getRoomStatusString(int roomStatus) {
    //    if (roomStatus == RoomStatus.WAITING) {
    //        return "waiting";
    //    } else {
    //        return "gaming";
    //    }
    //}
}
