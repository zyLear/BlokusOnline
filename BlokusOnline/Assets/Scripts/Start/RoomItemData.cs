using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItemData : MonoBehaviour {


    [HideInInspector]
    public string roomName;
    [HideInInspector]
    public int connectPlayer;
    [HideInInspector]
    public int maxPlayer;
    [HideInInspector]
    public int roomStatus;


    public Text textRoomName;
    public Text textConnectInfo;

    public void ShowRoomInfo() {
        textRoomName.text = roomName;
        textConnectInfo.text = "(" + connectPlayer + "/" + maxPlayer + ") " + getRoomStatusString(roomStatus);
    }

    private string getRoomStatusString(int roomStatus) {
        if (roomStatus == RoomStatus.WAITING) {
            return "waiting";
        } else {
            return "gaming";
        }
    }
}
