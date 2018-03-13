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
    public InputField passwordText;

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


    public GameObject roomContent;
    public GameObject roomItem;



    public Transform registerPanel;
    public Text registerAccountText;
    public InputField registerPasswordText;
    public InputField registerRepeatedPasswordText;



    public Transform rankPanel;
    public GameObject fourPlayersRankContent;
    public GameObject twoPlayersRankContent;
    public GameObject rankItem;


    public Text profileAccount;
    public Transform profilePanel;
    public GameObject playerGameLogContent;
    public GameObject LogItem;

    public Text profileRankScoreText2;
    public Text profileRecordDetailText2;

    public Text profileRankScoreText4;
    public Text profileRecordDetailText4;


    public Transform settingPanel;

    public Transform helpPanel;
    public GameObject EnglishHelp;
    public GameObject ChineseHelp;



    //Text UISureText;


    //public GameObject GameName;//GameName Text
    //public Transform Information;

    //Transform lobby;
    //public Transform panel;
    //public static Transform room;

    //public Transform ChooseGame;
    //public Transform BlokusRoom;

    //public GameObject InformationText;

    //Text getRoomName;
    //public static Text getName;

    //Text yourNameLabel;
    //Text roomNameLabel;
    //Text matchNameLabel;
    //Text yourChoiceLabel;
    //Text matchChoiceLabel;
    //Text readyLabel;
    //Text matchReadyLabel;
    //Text getMatchReady;
    //  static PhotonView myPhotonView;


    ArrayList roomList = new ArrayList();
    ArrayList fourPlayersRankInfoList = new ArrayList();
    ArrayList twoPlayersRankInfoList = new ArrayList();
    ArrayList playerGameLogList = new ArrayList();

    //int currentRoomCount = 0;
    //string yourName;
    //bool flag = true;
    //float i = 5;

    private const int UPDATE_ROOM_LIST_TIME_INTERVAL_SECONDS = 2;
    private float timeTemp = UPDATE_ROOM_LIST_TIME_INTERVAL_SECONDS;


    private const int REGISTER_REQUEST_TIME_INTERVAL_SECONDS = 5;
    [HideInInspector]
    public float registerTimeTemp = REGISTER_REQUEST_TIME_INTERVAL_SECONDS;

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

    private void Update() {
        timeTemp -= Time.deltaTime;
        if (timeTemp < 0) {
            if (GameCache.inRoomListPanel) {
                NetManager.Instance.TransferMessage(MessageFormater.formatRoomListMessage());
            }
            timeTemp = UPDATE_ROOM_LIST_TIME_INTERVAL_SECONDS;
        }

        if (registerTimeTemp > 0) {
            registerTimeTemp -= Time.deltaTime;
        }
    }

    private void joinRoom() {
        //  GameCache.roomNameRequest = joinRoomNameInput.text;
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
            NetManager.Instance.TransferMessage(MessageFormater.createRoom(roomName, GameType.BLOKUS_FOUR));
        } else {
            NetManager.Instance.TransferMessage(MessageFormater.createRoom(roomName, GameType.BLOKUS_TWO));
        }

        //PhotonNetwork.CreateRoom(str, roomOptions, TypedLobby.Default);
    }

    public void createRoomSuccess() {
        hidePanel(promptPanel);
        hidePanel(roomListPanel);
        GameObject.Find("BlokusRoomUIController").GetComponent<BlokusRoomUIController>().maskColor();
        showPanel(blokusRoomPanel);
    }

    public void createRoomFail() {

        promptWithButtonText.text = "create room fail!";
        hidePanel(promptPanel);
        showPanel(promptWithButtonPanel);
    }

    public void joinRoomSuccess() {
        hidePanel(roomListPanel);
        GameObject.Find("BlokusRoomUIController").GetComponent<BlokusRoomUIController>().maskColor();
        showPanel(blokusRoomPanel);
    }


    public void onGoToSettingPanel() {
        showPanel(settingPanel);
    }

    public void onBackFromSettingPanel() {
        hidePanel(settingPanel);
    }


    public void onLogout() {
        showPanel(loginPanel);
        hidePanel(settingPanel);
        hidePanel(roomListPanel);
        GameCache.inRoomListPanel = false;
        NetManager.Instance.TransferMessage(MessageFormater.formatLogoutMessage());
    }





    //void OnPhotonRandomJoinFailed()  //加入随机房间失败
    //{
    //    print("随机房间加入失败");
    //    UISureText.text = "加入房间失败！";
    //    PanelChange(message);
    //    PanelChange(Information);
    //    OnReceivedRoomListUpdate();
    //}



    void OnRoomListUpdate(BLOKUSRoomList roomInfos)   //房间列表更新
    {
        //print("改变");

        foreach (GameObject gameObject in roomList) {
            Destroy(gameObject);
        }
        roomList.Clear();
        foreach (BLOKUSRoomInfo roomInfo in roomInfos.roomItems) {
            GameObject room = Instantiate(roomItem, roomContent.transform, false);
            roomList.Add(room);
            // room.transform.SetParent(roomContent.transform);

            RoomItemData roomItemData = room.GetComponent<RoomItemData>();
            roomItemData.roomName = roomInfo.roomName;
            roomItemData.connectPlayer = roomInfo.currentPlayers;
            roomItemData.roomStatus = roomInfo.RoomStatus;
            if (roomInfo.gameType == GameType.BLOKUS_FOUR) {
                roomItemData.maxPlayer = 4;
            } else {
                roomItemData.maxPlayer = 2;
            }

            roomItemData.ShowRoomInfo();

            room.GetComponent<Button>().onClick.AddListener(delegate {
                NetManager.Instance.TransferMessage(MessageFormater.formatJoinRoomMessage(roomInfo.roomName));
            });
        }
    }




    public void onGoToProfilePanel() {
        profileAccount.text = GameCache.account;
        NetManager.Instance.TransferMessage(MessageFormater.formatProfileMessage(GameCache.account));
        showPanel(profilePanel);
    }

    public void onGoToProfilePanel(String account) {
        profileAccount.text = account;
        NetManager.Instance.TransferMessage(MessageFormater.formatProfileMessage(account));
        showPanel(profilePanel);
    }

    public void onBackFromProfilePanel() {
        hidePanel(profilePanel);
    }

    public void onShowProfile(BLOKUSProfile profile) {
        foreach (GameObject gameObject in playerGameLogList) {
            Destroy(gameObject);
        }
        playerGameLogList.Clear();

        BLOKUSRankItem bLOKUSRankItem2 = profile.twoPlayersRankItem;
        BLOKUSRankItem bLOKUSRankItem4 = profile.fourPlayersRankItem;

        profileRankScoreText2.text = bLOKUSRankItem2.rankScore + "";
        profileRecordDetailText2.text = "win:" + bLOKUSRankItem2.winCount +
            "   lose:" + bLOKUSRankItem2.loseCount + "   escape:" + bLOKUSRankItem2.escapeCount;
        profileRankScoreText4.text = bLOKUSRankItem4.rankScore + "";
        profileRecordDetailText4.text = "win:" + bLOKUSRankItem4.winCount +
           "   lose:" + bLOKUSRankItem4.loseCount + "   escape:" + bLOKUSRankItem4.escapeCount;

        foreach (BLOKUSPlayerGameLogItem gameLogItem in profile.playerGameLogs) {
            GameObject logItemObject = Instantiate(LogItem, playerGameLogContent.transform, false);
            playerGameLogList.Add(logItemObject);

            LogItemData logItemData = logItemObject.GetComponent<LogItemData>();
            if ("win".Equals(gameLogItem.result)) {
                logItemData.resultText.color = new UnityEngine.Color(0.2588F, 0.6549F, 0.2274F, 1);
            } else if ("lose".Equals(gameLogItem.result)) {
                logItemData.resultText.color = new UnityEngine.Color(0.9411F, 0.098F, 0.098F, 1);
            } else {
                logItemData.resultText.color = new UnityEngine.Color(1, 0.6862F, 0.047F, 1);
            }
            logItemData.result = gameLogItem.result;
            logItemData.stepsCount = gameLogItem.stepsCount + "";
            if (GameType.BLOKUS_FOUR == gameLogItem.gameType) {
                logItemData.gameType = "4 players";
            } else {
                logItemData.gameType = "2 players";
            }
            logItemData.detail = gameLogItem.detail;
            logItemData.time = gameLogItem.time;
            logItemData.score = gameLogItem.changeScore + "";
            logItemData.ShowGameLogInfo();
        }
    }



    public void onRefreshRank() {
        NetManager.Instance.TransferMessage(MessageFormater.formatRankInfoMessagae());
    }

    public void onBackToRoomListPanelFromRankPanel() {
        hidePanel(rankPanel);
        showPanel(roomListPanel);
    }

    public void onGoToRankPanel() {
        NetManager.Instance.TransferMessage(MessageFormater.formatRankInfoMessagae());
        hidePanel(roomListPanel);
        showPanel(rankPanel);
    }

    public void updateRankInfo(BLOKUSRankInfo rankInfo) {

        foreach (GameObject gameObject in fourPlayersRankInfoList) {
            Destroy(gameObject);
        }
        fourPlayersRankInfoList.Clear();
        foreach (GameObject gameObject in twoPlayersRankInfoList) {
            Destroy(gameObject);
        }
        twoPlayersRankInfoList.Clear();


        for (int i = 0; i < rankInfo.twoPlayersRankItems.Count; i++) {
            GameObject rankItemGameObject = Instantiate(rankItem, twoPlayersRankContent.transform, false);
            twoPlayersRankInfoList.Add(rankItemGameObject);

            BLOKUSRankItem bLOKUSRankItem = rankInfo.twoPlayersRankItems[i];
            RankItemData rankItemData = rankItemGameObject.GetComponent<RankItemData>();
            rankItemData.number = i + 1 + "";
            rankItemData.account = bLOKUSRankItem.account;
            rankItemData.rankScore = bLOKUSRankItem.rankScore + "";
            rankItemData.winCount = bLOKUSRankItem.winCount;
            rankItemData.loseCount = bLOKUSRankItem.loseCount;
            rankItemData.escapeCount = bLOKUSRankItem.escapeCount;
            rankItemData.ShowRankInfo();

            rankItemGameObject.GetComponent<Button>().onClick.AddListener(delegate {
                onGoToProfilePanel(bLOKUSRankItem.account);
            });
        }

        for (int i = 0; i < rankInfo.fourPlayersRankItems.Count; i++) {
            GameObject rankItemGameObject = Instantiate(rankItem, fourPlayersRankContent.transform, false);
            fourPlayersRankInfoList.Add(rankItemGameObject);

            BLOKUSRankItem bLOKUSRankItem = rankInfo.fourPlayersRankItems[i];
            RankItemData rankItemData = rankItemGameObject.GetComponent<RankItemData>();
            rankItemData.number = i + 1 + "";
            rankItemData.account = bLOKUSRankItem.account;
            rankItemData.rankScore = bLOKUSRankItem.rankScore + "";
            rankItemData.winCount = bLOKUSRankItem.winCount;
            rankItemData.loseCount = bLOKUSRankItem.loseCount;
            rankItemData.escapeCount = bLOKUSRankItem.escapeCount;
            rankItemData.ShowRankInfo();

            rankItemGameObject.GetComponent<Button>().onClick.AddListener(delegate {
                onGoToProfilePanel(bLOKUSRankItem.account);
            });
        }


    }





    public bool isRoomNameNull() {
        if (roomNameInput.text.Equals("")) {
            promptWithButtonText.text = "please input room name";
            showPanel(promptWithButtonPanel);
            return true;
        }
        return false;
    }


    public void onGoToHelpPanel() {
        showPanel(helpPanel);
    }

    public void onEnglishHelp() {
        ChineseHelp.SetActive(false);
        EnglishHelp.SetActive(true);
    }

    public void onChineseHelp() {
        EnglishHelp.SetActive(false);
        ChineseHelp.SetActive(true);
    }

    public void onBackFromHelpPanel() {
        hidePanel(helpPanel);
    }


    public void login() {
        //  GameCache.accountReqest = accountText.text;
        NetManager.Instance.TransferMessage(MessageFormater.formatLoginMessage(accountText.text, passwordText.text));
    }

    public void onBackToLoginPanel() {
        hidePanel(registerPanel);
        showPanel(loginPanel);
    }

    public void onGoToRegisterPanel() {
        hidePanel(loginPanel);
        showPanel(registerPanel);
    }

    public void onRegister() {
        string account = registerAccountText.text;
        string password = registerPasswordText.text;
        string repeatedPassword = registerRepeatedPasswordText.text;

        if (account.Length < 6 || password.Length < 6) {
            showPromptWithButtonMessage("Password must be no fewer than six");
            return;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(account, "^[0-9a-zA-Z]+$")) {
            showPromptWithButtonMessage("Can only be made up of letters and numbers");
            return;
        }

        if (!password.Equals(repeatedPassword)) {
            showPromptWithButtonMessage("Two passwords are different");
            return;
        }

        if (registerTimeTemp > 0) {
            showPromptWithButtonMessage("Too frequent operation");
            return;
        }

        NetManager.Instance.TransferMessage(MessageFormater.formatRegisterMessage(account, password));
        registerTimeTemp = REGISTER_REQUEST_TIME_INTERVAL_SECONDS;
    }



    public void registerSuccess() {
        showPromptWithButtonMessage("register success!");
    }

    public void registerFail() {
        showPromptWithButtonMessage("register fail!");
    }






    public void checkVersionFail() {
        promptText.text = "please download new version";
        showPanel(promptPanel);
    }




    public void showPromptWithButtonMessage(string message) {
        promptWithButtonText.text = message;
        showPanel(promptWithButtonPanel);
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

    public void showOffline() {
        promptText.text = "你已经掉线，请重新登录";
        showPanel(promptPanel);
    }

}
