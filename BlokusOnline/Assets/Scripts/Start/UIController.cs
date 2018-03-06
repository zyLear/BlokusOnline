using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using protos.blokus;
using System;
using UnityEngine.Events;
//using ExitGames.Client.Photon;

public class UIController : MonoBehaviour {

    //string lobby = "Lobby";
    //string panel = "Panel";
    //string room = "Room";
    public Toggle toggleFour;
  //  public Toggle toggleTwo;

    public Transform loginPanel;
    public Text accountText;
    public Text passwordText;

    public Transform promptWithButtonPanel;
    public Text promptWithButtonText;
    //public Text promptWithButtonButton;

    public Transform promptPanel;
    public Text promptText;

    public Text roomNameInput;


    public Transform roomListPanel;


    public Transform blokusRoomPanel;


    public Text joinRoomNameInput;
    public Button joinRoomButton;






    Text UISureText;

    public GameObject roomContent;
    public GameObject roomItem;
    public GameObject GameName;//GameName Text
    public Transform Information;

    Transform lobby;
    public Transform panel;
    public static Transform room;

    public Transform ChooseGame;
    public Transform BlokusRoom;

    public GameObject InformationText;

    Text getRoomName;
    public static Text getName;

    Text yourNameLabel;
    Text roomNameLabel;
    Text matchNameLabel;
    Text yourChoiceLabel;
    Text matchChoiceLabel;
    Text readyLabel;
    Text matchReadyLabel;
    Text getMatchReady;
    //  static PhotonView myPhotonView;


    ArrayList roomList = new ArrayList();
    int currentRoomCount = 0;
    string yourName;
    bool flag = true;
    //float i = 5;

    void Awake() {
        //   PhotonNetwork.autoJoinLobby = false; 
    }

    public void Start() {
        joinRoomButton.onClick.AddListener(joinRoom);
        // lobby = GameObject.Find("Lobby").GetComponent<Transform>();
        //panel = GameObject.Find("Panel").GetComponent<Transform>();
        //room = GameObject.Find("Room").GetComponent<Transform>(); ;

        ////   proptWithButton = GameObject.Find("Message").GetComponent<Transform>();
        //getName = GameObject.Find("GetName").GetComponent<Text>();
        //getRoomName = GameObject.Find("GetRoomName").GetComponent<Text>();
        //yourNameLabel = GameObject.Find("YourName").GetComponent<Text>();
        //roomNameLabel = GameObject.Find("RoomName").GetComponent<Text>();
        //matchNameLabel = GameObject.Find("MatchName").GetComponent<Text>();
        //yourChoiceLabel = GameObject.Find("YourChoice").GetComponent<Text>();
        //matchChoiceLabel = GameObject.Find("MatchChoice").GetComponent<Text>();
        //readyLabel = GameObject.Find("GetReady").GetComponent<Text>();
        //getMatchReady = GameObject.Find("MatchGetReady").GetComponent<Text>();
        //UISureText = GameObject.Find("UIInfo").GetComponent<Text>();

        //   myPhotonView = GetComponent<PhotonView>();
        //   StartCoroutine(JudgeConnected());
    }

    private void joinRoom() {
        GameCache.roomNameRequest = joinRoomNameInput.text;
        NetManager.Instance.TransferMessage(MessageFormater.formatJoinRoomMessage(joinRoomNameInput.text));
    }

    /**********************************************协程*/
    //IEnumerator JudgeConnected()
    //{
    //    while (!PhotonNetwork.connected)
    //    {
    //        yield return 0;
    //    }
    //    PanelChange(lobby);
    //    PanelChange(ChooseGame);
    //    StartCoroutine(JudgeDisconnected());
    //}


    //IEnumerator JudgeDisconnected() {
    //    while (PhotonNetwork.connected) {
    //        yield return 0;
    //    }
    //    PanelChange(Information);
    //    InformationText.GetComponent<Text>().text = "已经掉线";
    //    Application.LoadLevel("Start");
    //}
    ///**********************************************/

    //public static void ChangeRoomPanel() {
    //    PanelChange(room);
    //}

    //static public void OutUpdate() {
    //    myPhotonView.RPC("UpdateRoomInfo", PhotonTargets.AllBuffered);
    //}

    //public void restar() {
    //    TypedLobby yl = new TypedLobby();
    //    PhotonNetwork.JoinLobby(yl);
    //    Application.LoadLevel("五子棋");
    //}


    //public void OnSee() {
    //    Application.LoadLevelAdditive("game");
    //}

    //public void OnBackChooseGame() {
    //    PanelChange(ChooseGame);
    //    PanelChange(panel);
    //    PhotonNetwork.LeaveLobby();
    //}

    //public void OnJoinGobang() {
    //    TypedLobby tl = new TypedLobby();
    //    tl.Name = "Gobang";
    //    PhotonNetwork.JoinLobby(new TypedLobby() { Name = "Gobang" });
    //}

    //public void OnJoinBlokus() {
    //    PhotonNetwork.JoinLobby(new TypedLobby() { Name = "Blokus" });
    //}

    //public void OnLobby() {
    //    print("点击加入游戏大厅");
    //    TypedLobby yl = new TypedLobby();
    //    yl.Name = "五子棋";
    //    PhotonNetwork.JoinLobby(yl);
    //    PhotonNetwork.ConnectUsingSettings("v1.1");
    //}

    //public void OnRoom() {
    //    Application.LoadLevelAdditive("game");

    //    if (IsNameNull()) {
    //        return;
    //    }
    //    print("点击加入房间");
    //    yourName = GameObject.Find("GetName").GetComponent<Text>().text;
    //    InformationText.GetComponent<Text>().text = "正在加入房间...";
    //    PanelChange(Information);
    //    PhotonNetwork.JoinRandomRoom();

    //}

    public void createRoom() {
        print("创房间");
        if (isRoomNameNull()) {
            return;
        }
        promptText.text = "creating...";
        showPanel(promptPanel);
        string roomName = roomNameInput.text;


        //RoomOptions roomOptions = null;
        //if (PhotonNetwork.lobby.Name.Equals("Gobang")) {
        //    roomOptions = new RoomOptions() { IsVisible = true, MaxPlayers = 2 };
        //} else {
        //    roomOptions = new RoomOptions() { IsVisible = true, MaxPlayers = 4 };
        //}
        //GameCache.roomNameRequest = roomName;
        //  = GameObject.Find("ToggleGroup").GetComponent<ToggleGroup>();
        if (toggleFour.isOn) {
            NetManager.Instance.TransferMessage(MessageFormater.createRoom(roomName, RoomType.BLOKUS_FOUR));
        } else {
            NetManager.Instance.TransferMessage(MessageFormater.createRoom(roomName, RoomType.BLOKUS_TWO));
        }

        //PhotonNetwork.CreateRoom(str, roomOptions, TypedLobby.Default);
    }

    public void createRoomSuccess() {
        hidePanel(promptPanel);
        hidePanel(roomListPanel);
        showPanel(blokusRoomPanel);
    }

    public void createRoomFail() {

        promptWithButtonText.text = "create room fail!";
        hidePanel(promptPanel);
        showPanel(promptWithButtonPanel);
    }

    public void joinRoomSuccess() {
        hidePanel(roomListPanel);
        showPanel(blokusRoomPanel);
    }










    //void OnPhotonRandomJoinFailed()  //加入随机房间失败
    //{
    //    print("随机房间加入失败");
    //    UISureText.text = "加入房间失败！";
    //    PanelChange(message);
    //    PanelChange(Information);
    //    OnReceivedRoomListUpdate();
    //}



    void OnRoomListUpdate()   //房间列表更新
    {
        //print("改变");

        //foreach (GameObject r in roomList) {
        //    Destroy(r);
        //}
        //roomList.Clear();
        //foreach (RoomInfo r in PhotonNetwork.GetRoomList()) {
        //    GameObject room = (GameObject)Instantiate(roomItem);
        //    roomList.Add(room);
        //    room.transform.SetParent(roomContent.transform);

        //    RoomData rd = room.GetComponent<RoomData>();
        //    rd.roomName = r.Name;
        //    rd.connectPlayer = r.PlayerCount;
        //    rd.maxPlayer = r.MaxPlayers;
        //    rd.ShowRoomInfo();

        //    room.GetComponent<Button>().onClick.AddListener(delegate {
        //        if (IsNameNull()) {
        //            return;
        //        }
        //        PhotonNetwork.JoinRoom(rd.roomName);
        //    });
        //}
    }







    public bool isRoomNameNull() {
        if (roomNameInput.text.Equals("")) {
            promptWithButtonText.text = "please input room name!！";
            showPanel(promptWithButtonPanel);
            return true;
        }
        return false;
    }



    public void login() {
        GameCache.accountReqest = accountText.text;
        NetManager.Instance.TransferMessage(MessageFormater.formatLoginMessage(accountText.text, passwordText.text));
    }



    //public void PanelChange(Transform change) {
    //    Vector3 p = change.position;
    //    Vector3 newPositoin = new Vector3(0, 0, 0);
    //    print(p.y);
    //    if (100 > p.y && p.y > -100) {
    //        newPositoin = new Vector3(0, -1080, 0);
    //    }
    //    change.position = newPositoin;
    //}

    //public void onHidePromptWithButtonPanel() {
    //    hidePanel(promptWithButtonPanel);
    //}

    public void showPanel(Transform change) {
        Vector3 p = change.position;
        if (100 <= p.y || p.y <= -100) {
            change.position = new Vector3(0, 0, 0);
        }
    }

    public void hidePanel(Transform change) {
        Vector3 p = change.position;
        if (100 > p.y && p.y > -100) {
            change.position = new Vector3(0, -1080, 0);
        }
    }

}
