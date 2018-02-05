using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlokusPlayer
{
    public string name = "";
    public string color = "";
    public bool ready = true;
}

public class BlokusRoomController : MonoBehaviour {
  
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


    //IEnumerator GoToBlokus()
    //{
    //    while (PhotonNetwork.insideLobby)
    //    {
    //        yield return 0;
    //    }
    //    PhotonNetwork.JoinLobby(new TypedLobby() { Name = "Blokus" });
    //}

    //public void Start()
    //{
    //    myUIControl = GameObject.Find("UIControl").GetComponent<UIControl>();
    //    myPhotonView = GetComponent<PhotonView>();
    //    Red.onClick.AddListener(OnRed);
    //    yellow.onClick.AddListener(OnYellow);
    //    green.onClick.AddListener(OnGreen);
    //    Blue.onClick.AddListener(OnBlue);
    //  //  UpDateBlokusRoomInfo();
    //}


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

    //public void OnRed()
    //{
    //    ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.player.AllProperties;
    //    ht["color"] = "red";
    //    PhotonNetwork.player.SetCustomProperties(ht);
    //    myPhotonView.RPC("UpDateBlokusRoomInfo", PhotonTargets.All); //所有人更新信息
    //}
    //public void OnYellow()
    //{
    //    ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.player.AllProperties;
    //    ht["color"] = "yellow";
    //    PhotonNetwork.player.SetCustomProperties(ht);
    //    myPhotonView.RPC("UpDateBlokusRoomInfo", PhotonTargets.All); //所有人更新信息
    //}
    //public void OnGreen()
    //{
    //    ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.player.AllProperties;
    //    ht["color"] = "green";
    //    PhotonNetwork.player.SetCustomProperties(ht);
    //    myPhotonView.RPC("UpDateBlokusRoomInfo", PhotonTargets.All); //所有人更新信息
    //}
    //public void OnBlue()
    //{
    //    ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.player.AllProperties;
    //    ht["color"]= "blue";
    //    PhotonNetwork.player.SetCustomProperties(ht);
    //    myPhotonView.RPC("UpDateBlokusRoomInfo", PhotonTargets.All); //所有人更新信息
    //}

    //public void OnBlokusReady()
    //{
    //    Application.LoadLevelAdditive("Blokus");s
    //    UIControl.PanelChange(myUIControl.BlokusRoom);
    //}  

    //[PunRPC]
    //public void UpDateBlokusRoomInfo()
    //{
    //    playerOneName.text = "";
    //    playerTwoName.text = "";
    //    playerThreeName.text = "";
    //    playerFourName.text = "";
    //    playerOneChoice.text = "";
    //    playerTwoChoice.text = "";
    //    playerThreeChoice.text = "";
    //    playerFourChoice.text = "";
    //    playerOneReady.text = "";
    //    playerTwoReady.text = "";
    //    playerThreeReady.text = "";
    //    playerFourReady.text = "";
    //    PhotonPlayer[] players = PhotonNetwork.playerList;
    //    int i = 1;

    //    foreach(PhotonPlayer p in players)
    //    {
    //        ExitGames.Client.Photon.Hashtable ht = p.AllProperties;
    //        switch (i)
    //        {
    //            case 1:
    //                {
    //                    playerOneName.text = ht["name"].ToString();
    //                    playerOneChoice.text = ht["color"].ToString();
    //                    playerOneReady.text = ht["ready"].ToString();
    //                    break;
    //                }
    //            case 2:
    //                {
    //                    playerTwoName.text = ht["name"].ToString();
    //                    playerTwoChoice.text = ht["color"].ToString();
    //                    playerTwoReady.text = ht["ready"].ToString();
    //                    break;
    //                }
    //            case 3:
    //                {
    //                    playerThreeName.text = ht["name"].ToString();
    //                    playerThreeChoice.text = ht["color"].ToString();
    //                    playerThreeReady.text = ht["ready"].ToString();
    //                    break;
    //                }
    //            case 4:
    //                {
    //                    playerFourName.text = ht["name"].ToString();
    //                    playerFourChoice.text = ht["color"].ToString();
    //                    playerFourReady.text = ht["ready"].ToString();
    //                    break;
    //                }                
    //        }
    //        i++;
    //    }
    //}


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
    //public void BlokusStart()
    //{

    //    ExitGames.Client.Photon.Hashtable ht = PhotonNetwork.player.AllProperties;
    //    ht["ready"] = "未准备";
    //    PhotonNetwork.player.SetCustomProperties(ht);
    //    UpDateBlokusRoomInfo();        //更新信息
    //    UIControl.PanelChange(myUIControl.BlokusRoom);
    //    Application.LoadLevelAdditive("Blokus");
    //}



    //void OnPhotonPlayerDisconnected(PhotonPlayer player)  //有玩家断开连接 
    //{
    //    UpDateBlokusRoomInfo();
    //}
}
