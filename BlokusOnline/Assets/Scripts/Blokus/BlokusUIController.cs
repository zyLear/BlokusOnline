using protos.blokus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlokusUIController : MonoBehaviour {

    static public ArrayList allChess = new ArrayList();
    UIController myUIController;
    public GameObject blokusMessage;
    public Text MessageText;
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

    public Text chatContent;
    public Text inputInfo;
    public Scrollbar scrollbar;
    public Text CurrentColor;
    public Text ShowTime;

    public AudioSource audioSource;
    public GameObject confirmDialog;

    private BLOKUSChessDoneInfo chessDoneInfoTemp;




    const int DEADLINE_TIME = 120;

    const int blue = Color.BLUE;//定义颜色常量
    const int green = Color.GREEN;
    const int red = Color.RED;
    const int yellow = Color.YELLOW;

    private string currentScenseName;

    float deadline = DEADLINE_TIME;
    int currentShowTime = DEADLINE_TIME;

    BlokusController myBlokusController;

    private Queue<string> showMessageQueue = new Queue<string>();

    private static object lockObject = new object();

    public void Start() {
        myUIController = GameObject.Find("UIController").GetComponent<UIController>();
        myBlokusController = GameObject.Find("BlokusController").GetComponent<BlokusController>();
        NetManager.Instance.TransferMessage(MessageFormater.formatInitPlayerInfoInGameMessage());

        StartCoroutine(JudgeTimeOut());   //开启协程
                                          //   InitBlokusRoomUIInfo();
    }

    //public void Update() {
    //    chatContent.text = chatContentString;
    ////    testText.text = chatContentString;

    //}

    /********协程***************/
    IEnumerator JudgeTimeOut() {

        while (true) {
           
            while (deadline > 0) {
                if (myBlokusController.gameOver) {
                    break;
                }
                deadline -= Time.deltaTime;
                int time = (int)deadline;
                if (time < currentShowTime) {
                    currentShowTime = time;
                    ShowTime.text = "Dealine：" + currentShowTime;
                }
                yield return 0;
            }
            if (myBlokusController.gameOver) {
                break;
            }
            deadline = DEADLINE_TIME;
            currentShowTime = DEADLINE_TIME;
            LoseParam loseParam = new LoseParam { color = myBlokusController.CurrentColor, gameEvent = GameEvent.TIME_CONSUME };
            lose(loseParam);

        }
    }


    public void lose(LoseParam loseParam) {
        lock (lockObject) {
            int color = loseParam.color;
            int gameEvent = loseParam.gameEvent;
            if (myBlokusController.loseColor[color] == 1 ||
                myBlokusController.gameOver ||
                myBlokusController.loseCount == 1) {
                return;
            }

            if (myBlokusController.MAX_PLAYERS_COUNT - myBlokusController.loseCount == 2) {
                int nextColor = myBlokusController.getNextColor(color);
                //  Debug.LogError("nextColor:" + nextColor);
                if (color == myBlokusController.myColor) {
                    if (GameEvent.TIME_CONSUME == gameEvent) {
                        NetManager.Instance.TransferMessage(MessageFormater.formatLoseMessage());
                    }
                    ShowMessage(getColor(nextColor) + "player win！");
                } else if (nextColor == myBlokusController.myColor) {
                    NetManager.Instance.TransferMessage(MessageFormater.formatWinMessage());
                    ShowMessage("Congratulations to you on winning this match！");
                } else {
                    ShowMessage(getColor(nextColor) + "player win！");
                }
                myBlokusController.lose(color);
                myBlokusController.gameOver = true;
                return;
            }

            if (color == myBlokusController.myColor) {
                ShowMessage("you lose");  //下棋截止时间到，
                if (GameEvent.TIME_CONSUME == gameEvent) {
                    NetManager.Instance.TransferMessage(MessageFormater.formatLoseMessage());
                }
                //  NetManager.Instance.TransferMessage(MessageFormater.formatLoseMessage());
            } else {
                ShowMessage(getColor(color) + "player lose");//"下棋截止时间到，" +
            }
            myBlokusController.lose(color);
            Debug.Log("lock  end*********************************!!!!!!!!!1");
        }
    }


    //private string getShowMessageString(bool isWin, int gameEvent) {
    //    switch (gameEvent) {
    //        case GameEvent.TIME_CONSUME:
    //            if (isWin) {

    //            } else {

    //            }
    //            break;
    //    }
    //    return "";
    //}



    public void playChessDoneMusic() {
        audioSource.Play();
    }

    public void onPlayerOne() {
        if (!playerOneName.text.Equals("")) {
            myUIController.onGoToProfilePanel(playerOneName.text);
        }
    }

    public void onPlayerTwo() {
        if (!playerTwoName.text.Equals("")) {
            myUIController.onGoToProfilePanel(playerTwoName.text);
        }
    }

    public void onPlayerThree() {
        if (!playerThreeName.text.Equals("")) {
            myUIController.onGoToProfilePanel(playerThreeName.text);
        }
    }

    public void onPlayerFour() {
        if (!playerFourName.text.Equals("")) {
            myUIController.onGoToProfilePanel(playerFourName.text);
        }
    }












    /********协程***************/

    //public void StartDeadlineTime()
    //{
    //    StartCoroutine(JudgeTimeOut());
    //}


    //public void SendMessageCalledOutside(int color)
    //{
    //    string str = getColor(color) + "方已认输！";
    //    GetComponent<PhotonView>().RPC("SendMessageToAll", PhotonTargets.All, str);
    //    SendMessage(str);
    //}

    public void ChangeMessageByYourself(int color) {
        string str = "<size=33>" + getColor(color) + " player lose</size>";
        //   SendMessageToAll(str);
    }

    public void OnSendMessage() {
        print("按下发送按钮");
        string str = "<color=" + getColor(myBlokusController.myColor) + ">" + GameCache.account + ":\n  " +/*"(player)：" +*/ inputInfo.text + "</color>";
        NetManager.Instance.TransferMessage(MessageFormater.formatChatInGameMessage(str));
    }

    public void OnGiveUp() {
        if (myBlokusController.loseCount < myBlokusController.MAX_PLAYERS_COUNT - 1) {
            if (myBlokusController.loseColor[myBlokusController.myColor] == 0) {
                //myBlokusController.giveUp(myBlokusController.myColor);
                NetManager.Instance.TransferMessage(MessageFormater.formatGiveUpMessage(myBlokusController.myColor));
            } else {
                ShowMessage("you have lost already");
            }
        }
    }


    //public void OnShow()
    //{
    //    ShowMessage("按下退出");  
    //}

    public void OnExit() {
        Application.Quit();
    }


    public void OnBackRoom()   //返回处理。。。。。。。。。。。。
    {
        GameObject.Find("StartCamera").GetComponent<Camera>().enabled = true;
        GameObject.Find("BlokusCamera").GetComponent<Camera>().enabled = false;

        foreach (GameObject g in allChess) {
            Destroy(g);
        }
        Destroy(myBlokusController.currentCenter);
        Destroy(myBlokusController.tempSquare);
        Destroy(myBlokusController.currentCenterTemp);
        OnGiveUp();

        myUIController.showPanel(myUIController.blokusRoomPanel);

        if (GameCache.gameType == GameType.BLOKUS_FOUR) {
            Application.UnloadLevel("Blokus");
        } else {
            Application.UnloadLevel("BlokusTP");
        }
    }

    public void OnButtonOnMessage() {
        blokusMessage.SetActive(false);
    }

    public void BlokusUIUpdate(int color)   //其他脚本调用的函数
    {
        CurrentColor.text = "Current : " + getColor(color);
        deadline = DEADLINE_TIME;
        currentShowTime = DEADLINE_TIME;
    }

    //void OnPhotonPlayerDisconnected(PhotonPlayer player)  //玩家断开连接
    //{
    //    print("断开连接{");
    //    int color = 0;
    //    string str = player.AllProperties["color"].ToString();
    //    if(str.Equals("red"))
    //    {
    //        color = red;
    //    }
    //    else if (str.Equals("yellow"))
    //    {
    //        color = yellow;
    //    }
    //    else if (str.Equals("blue"))
    //    {
    //        color = blue;
    //    }
    //    else if (str.Equals("green"))
    //    {
    //        color = green;
    //    }

    //    if (myBlokusController.loseCount < 3)
    //    {
    //        if (myBlokusController.loseColor[color] == 0)
    //        {
    //            myBlokusController.lose(color);
    //        }
    //    }

    //    ShowMessage(str+"方已离开游戏");
    //    print("}断开连接");
    //}


    public void InitBlokusRoomUIInfo(BLOKUSRoomPlayerList info)  //初始化房间信息
    {
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
        List<BLOKUSRoomPlayerInfo> playerInfos = info.itmes;
        for (int i = 0; i < playerInfos.Count; i++) {
            BLOKUSRoomPlayerInfo playerInfo = playerInfos[i];
            if (playerInfo.account.Equals(GameCache.account)) {
                GameCache.myColor = playerInfo.color;
            }
            switch (i) {
                case 0: {
                        playerOneName.text = playerInfo.account;
                        playerOneChoice.text = Color.getColorText(playerInfo.color);
                        break;
                    }
                case 1: {
                        playerTwoName.text = playerInfo.account;
                        playerTwoChoice.text = Color.getColorText(playerInfo.color);
                        break;
                    }
                case 2: {
                        playerThreeName.text = playerInfo.account;
                        playerThreeChoice.text = Color.getColorText(playerInfo.color);
                        break;
                    }
                case 3: {
                        playerFourName.text = playerInfo.account;
                        playerFourChoice.text = Color.getColorText(playerInfo.color);
                        break;
                    }
            }
        }
    }

    public void tryChess(BLOKUSChessDoneInfo chessDoneInfo) {
        chessDoneInfoTemp = chessDoneInfo;
        myBlokusController.tryChess(chessDoneInfo);
        confirmDialog.SetActive(true);
    }

    public void onConfirmYes() {
        myBlokusController.chessDoneOutSide(chessDoneInfoTemp, true);
        confirmDialog.SetActive(false);
    }

    public void onConfirmNo() {
        myBlokusController.chessDoneOutSide(chessDoneInfoTemp, false);
        confirmDialog.SetActive(false);
    }


    /******************功能函数***/

    string getColor(int color) {
        string str = "";
        switch (color) {
            case red: str = "red"; break;
            case blue: str = "blue"; break;
            case green: str = "green"; break;
            case yellow: str = "yellow"; break;
        }
        return str;
    }

    void ShowMessage(string message) {
        blokusMessage.SetActive(true);
        MessageText.text = message;
    }

    void showPanel(GameObject gameObject) {
        gameObject.SetActive(true);
    }

    /******************功能函数***/


    // [PunRPC]
    //public void SendMessageToAll(string message) {
    //    chatContent.text = chatContent.text + "\n" + message;
    //    scrollbar.value = 0;
    //}

    public void chatInGame(string message) {
        chatContent.text = chatContent.text + "\n" + message;
        scrollbar.value = -10;
    }
}
