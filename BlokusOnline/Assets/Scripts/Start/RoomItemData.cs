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


    public Text textRoomName;
    public Text textConnectInfo;

    public void ShowRoomInfo()
    {
        textRoomName.text = "房间名字:"+roomName;
        textConnectInfo.text = "("+connectPlayer + "/" + maxPlayer+")"; 
    }
}
