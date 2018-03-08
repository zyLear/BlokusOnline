using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankItemData : MonoBehaviour {


    [HideInInspector]
    public string number;
    [HideInInspector]
    public string account;
    [HideInInspector]
    public string rankScore;
    [HideInInspector]
    public int winCount;
    [HideInInspector]
    public int loseCount;
    [HideInInspector]
    public int escapeCount;



    public Text numberText;
    public Text accountText;
    public Text rankScoreText;
    public Text rankDetailText;

    public void ShowRankInfo() {
        numberText.text = number;
        accountText.text = account;
        rankScoreText.text = "rank:" + rankScore;
        rankDetailText.text = "win:" + winCount + "   lose:" + loseCount + "   escape:" + escapeCount;
    }

    //private string getRoomStatusString(int roomStatus) {
    //    if (roomStatus == RoomStatus.WAITING) {
    //        return "waiting";
    //    } else {
    //        return "gaming";
    //    }
    //}
}
