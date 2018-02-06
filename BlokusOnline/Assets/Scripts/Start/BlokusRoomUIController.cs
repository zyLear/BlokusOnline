using protos.blokus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BlokusPlayer {
    public string name = "";
    public string color = "";
    public bool ready = true;
}

public class BlokusRoomUIController : MonoBehaviour {

    UIController myUIController;
    public Text BlokusRoomName;
    public Text BlokusYourName;
    public Text playerOneName;
    public Text playerTwoName;
    public Text playerThreeName;
    public Text playerFourName;
    public Text playerOneChoice;
    public Text playerTwoChoice;
    public Text playerThreeChoice;
    public Text playerFourChoice;
    public Text playerOneReady;
    public Text playerTwoReady;
    public Text playerThreeReady;
    public Text playerFourReady;


    public Button Red;
    public Button Blue;
    public Button yellow;
    public Button green;

    public Button back;
    public Button start;


    //private int GameCache.myColor = Color.BLUE;

    //IEnumerator GoToBlokus()
    //{
    //    while (PhotonNetwork.insideLobby)
    //    {
    //        yield return 0;
    //    }
    //    PhotonNetwork.JoinLobby(new TypedLobby() { Name = "Blokus" });
    //}

    public void Start() {
        myUIController = GameObject.Find("UIController").GetComponent<UIController>();
        Red.onClick.AddListener(OnRed);
        yellow.onClick.AddListener(OnYellow);
        green.onClick.AddListener(OnGreen);
        Blue.onClick.AddListener(OnBlue);

        back.onClick.AddListener(OnBack);
        start.onClick.AddListener(OnStart);
        //  //  UpDateBlokusRoomInfo();
    }

    private void OnStart() {
        NetManager.Instance.TransferMessage(MessageFormater.formatReadyMessage(GameCache.account, GameCache.roomName)); 
    }

    private void OnBack() {
        NetManager.Instance.TransferMessage(MessageFormater.formatLeaveRoomMessage());
        myUIController.hidePanel(myUIController.blokusRoomPanel);
        myUIController.showPanel(myUIController.roomListPanel);
    }


    //public void OnBackLobby()
    //{
    //    UIControl.PanelChange(myUIControl.BlokusRoom);
    //    UIControl.PanelChange(myUIControl.ChooseGame);
    //    PhotonNetwork.LeaveRoom();
    //   // StartCoroutine(GoToBlokus());
    // //   PhotonNetwork.JoinLobby(new TypedLobby() { Name = "Blokus" });
    //}

    //public void  OnReady()
    //{
    //    if (IsSuitcolor())
    //    {
    //        ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.player.AllProperties;
    //        ht["ready"] = ht["ready"].ToString().Equals("已准备") ? "未准备" : "已准备";
    //        PhotonNetwork.player.SetCustomProperties(ht);
    //        myPhotonView.RPC("UpDateBlokusRoomInfo", PhotonTargets.All); //所有人更新信息
    //    }
    //    if (IsAllReady())
    //    {
    //        myPhotonView.RPC("BlokusStart", PhotonTargets.All); //所有人更新信息
    //    }
    //}

    public void OnRed() {
        if (GameCache.myColor != Color.RED) {
            NetManager.Instance.TransferMessage(MessageFormater.chooseColor(GameCache.account, GameCache.roomName, Color.RED));
        }
        //    ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.player.AllProperties;
        //ht["color"] = "red";
        //PhotonNetwork.player.SetCustomProperties(ht);
        //myPhotonView.RPC("UpDateBlokusRoomInfo", PhotonTargets.All); //所有人更新信息
    }
    public void OnYellow() {
        if (GameCache.myColor != Color.YELLOW) {
            NetManager.Instance.TransferMessage(MessageFormater.chooseColor(GameCache.account, GameCache.roomName, Color.YELLOW));
        }
    }
    public void OnGreen() {
        if (GameCache.myColor != Color.GREEN) {
            NetManager.Instance.TransferMessage(MessageFormater.chooseColor(GameCache.account, GameCache.roomName, Color.GREEN));
        }
    }
    public void OnBlue() {
        if (GameCache.myColor != Color.BLUE) {
            NetManager.Instance.TransferMessage(MessageFormater.chooseColor(GameCache.account, GameCache.roomName, Color.BLUE));
        }
    }

    //public void OnBlokusReady()
    //{
    //    Application.LoadLevelAdditive("Blokus");
    //    UIControl.PanelChange(myUIControl.BlokusRoom);
    //}  

    //[PunRPC]
    public void updateRoomPlayersInfo(BLOKUSRoomPlayerList info) {
        BlokusRoomName.text = GameCache.roomName;
        BlokusYourName.text = GameCache.account;
        playerOneName.text = "";
        playerTwoName.text = "";
        playerThreeName.text = "";
        playerFourName.text = "";
        playerOneChoice.text = "";
        playerTwoChoice.text = "";
        playerThreeChoice.text = "";
        playerFourChoice.text = "";
        playerOneReady.text = "";
        playerTwoReady.text = "";
        playerThreeReady.text = "";
        playerFourReady.text = "";
        //PhotonPlayer[] players = PhotonNetwork.playerList;
        List<BLOKUSRoomPlayerInfo> playerInfos = info.itmes;



        for (int i = 0; i < playerInfos.Count; i++) {
            //ExitGames.Client.Photon.Hashtable ht = p.AllProperties;
            BLOKUSRoomPlayerInfo playerInfo = playerInfos[i];
            if (playerInfo.account.Equals(GameCache.account)) {
                GameCache.myColor = playerInfo.color;
            }
            switch (i) {
                case 0: {
                        playerOneName.text = playerInfo.account;
                        playerOneChoice.text = getColorText(playerInfo.color);
                        playerOneReady.text = getReadyText(playerInfo.isReady);
                        break;
                    }
                case 1: {
                        playerTwoName.text = playerInfo.account;
                        playerTwoChoice.text = getColorText(playerInfo.color);
                        playerTwoReady.text = getReadyText(playerInfo.isReady);
                        break;
                    }
                case 2: {
                        playerThreeName.text = playerInfo.account;
                        playerThreeChoice.text = getColorText(playerInfo.color);
                        playerThreeReady.text = getReadyText(playerInfo.isReady);
                        break;
                    }
                case 3: {
                        playerFourName.text = playerInfo.account;
                        playerFourChoice.text = getColorText(playerInfo.color);
                        playerFourReady.text = getReadyText(playerInfo.isReady);
                        break;
                    }
            }
        }
    }

    private string getColorText(int color) {
        switch (color) {
            case Color.BLUE: return "blue";
            case Color.GREEN: return "green";
            case Color.RED: return "red";
            case Color.YELLOW: return "yellow";
            default: return "blue";
        }
    }

    private string getReadyText(bool ready) {
        if (ready) {
            return "ready";
        } else {
            return "";
        }
    }


    //public bool IsAllReady()
    //{
    //    PhotonPlayer[] players = PhotonNetwork.playerList;
    //    int sign = 0;
    //    foreach (PhotonPlayer p in players)
    //    {
    //        if (p.AllProperties["ready"].ToString().Equals("已准备"))
    //        {
    //            sign++;
    //        }
    //    }
    //    if (sign == 4)
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    //public bool IsSuitcolor()
    //{
    //    PhotonPlayer[] players = PhotonNetwork.playerList;
    //    if (players.Length == 4)
    //    {
    //        HashSet<string> hs = new HashSet<string>();
    //        foreach (PhotonPlayer p in players)
    //        {
    //            string str=p.AllProperties["color"].ToString();
    //            if (!str.Equals(""))
    //            {
    //                hs.Add(p.AllProperties["color"].ToString());
    //            }            
    //        }
    //        if (hs.Count == 4)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}


    //public void JoinRoomSucceed()
    //{
    //    BlokusYourName.text = "你的名字:"+PhotonNetwork.player.NickName;
    //    BlokusRoomName.text = "房间名字:"+PhotonNetwork.room.Name;
    //    //新进入的玩家设置信息
    //    ExitGames.Client.Photon.Hashtable ht = new ExitGames.Client.Photon.Hashtable();
    //    ht.Add("name", PhotonNetwork.player.NickName);
    //    ht.Add("color", "");
    //    ht.Add("ready", "");
    //    PhotonNetwork.player.SetCustomProperties(ht);

    //    myPhotonView.RPC("UpDateBlokusRoomInfo", PhotonTargets.All); //进入房间，所有人更新信息
    //}

    //[PunRPC]
    public void BlokusStart() {
        //UpDateBlokusRoomInfo();        //更新信息
        myUIController.hidePanel(myUIController.blokusRoomPanel);
        Application.LoadLevelAdditive("Blokus");
    }



    //void OnPhotonPlayerDisconnected(PhotonPlayer player)  //有玩家断开连接 
    //{
    //    UpDateBlokusRoomInfo();
    //}
}
