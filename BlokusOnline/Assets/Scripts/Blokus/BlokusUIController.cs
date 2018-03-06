using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlokusUIController : MonoBehaviour {

    static public ArrayList allChess = new ArrayList();
    UIController myUIController;
    public GameObject BlokusMessage;
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
        //GameObject gameObject = GameObject.Find("BlokusController");
        //if (gameObject != null) {
        //    myBlokusController = gameObject.GetComponent<BlokusController>();
        //    currentScenseName = "Blokus";
        //} else {
        myBlokusController = GameObject.Find("BlokusController").GetComponent<BlokusController>();
        //    currentScenseName = "BlokusTP";
        //}

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
            if (BlokusController.gameOver) {
                break;
            }
            while (deadline > 0) {
                deadline -= Time.deltaTime;
                int time = (int)deadline;
                if (time < currentShowTime) {
                    currentShowTime = time;
                    ShowTime.text = "Dealine：" + currentShowTime;
                }
                yield return 0;
            }

            //if (myBlokusController.loseCount == 1) {
            //    print(myBlokusController.CurrentColor);
            //    if (myBlokusController.CurrentColor == myBlokusController.myColor) {
            //        ShowMessage("恭喜你赢了！");
            //        NetManager.Instance.TransferMessage(MessageFormater.formatWinMessage());
            //    }
            //    break;
            //}




            //if (myBlokusController.loseCount == 2) {
            //    print(myBlokusController.CurrentColor);
            //    if (myBlokusController.CurrentColor == myBlokusController.myColor) {
            //        ShowMessage("下棋截止时间到，很遗憾，你输了");
            //        NetManager.Instance.TransferMessage(MessageFormater.formatFailMessage());
            //    } else {

            //    }
            //    break;
            //}

            deadline = DEADLINE_TIME;
            currentShowTime = DEADLINE_TIME;
            fail(myBlokusController.CurrentColor);

        }
    }


    public void fail(int color) {
        lock (lockObject) {
            if (myBlokusController.loseColor[color] == 1) {
                return;
            }

            if (myBlokusController.MAX_PLAYERS_COUNT - myBlokusController.loseCount == 2) {
                int nextColor = myBlokusController.getNextColor(color);
                Debug.LogError("nextColor:" + nextColor);
                if (color == myBlokusController.myColor) {
                    NetManager.Instance.TransferMessage(MessageFormater.formatFailMessage());
                    ShowMessage(getColor(nextColor) + "方赢了！");
                } else if (nextColor == myBlokusController.myColor) {
                    NetManager.Instance.TransferMessage(MessageFormater.formatWinMessage());
                    ShowMessage("恭喜你赢了！");
                } else {
                    ShowMessage(getColor(nextColor) + "方赢了！");
                }
                BlokusController.gameOver = true;
                return;
            }

            if (color == myBlokusController.myColor) {
                ShowMessage("很遗憾，你输了");  //下棋截止时间到，
                NetManager.Instance.TransferMessage(MessageFormater.formatFailMessage());
            } else {
                ShowMessage(getColor(color) + "方输了！");//"下棋截止时间到，" +
            }
            myBlokusController.fail(color);
            Debug.Log("lock  end*********************************!!!!!!!!!1");
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
        string str = "<size=33>" + getColor(color) + "方已输！</size>";
        //   SendMessageToAll(str);
    }

    public void OnSendMessage() {
        print("按下发送按钮");
        string str = "<color=" + getColor(myBlokusController.myColor) + ">" + GameCache.account + "(player)：" + inputInfo.text + "</color>";
        // GetComponent<PhotonView>().RPC("SendMessageToAll", PhotonTargets.All, str);
        NetManager.Instance.TransferMessage(MessageFormater.formatChatInGameMessage(str));
    }

    public void OnGiveUp() {
        if (myBlokusController.loseCount < 3) {
            if (myBlokusController.loseColor[myBlokusController.myColor] == 0) {
                //myBlokusController.giveUp(myBlokusController.myColor);
                NetManager.Instance.TransferMessage(MessageFormater.formatGiveUpMessage(myBlokusController.myColor));
            } else {
                ShowMessage("你已经输了~");
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
        OnGiveUp();

        myUIController.showPanel(myUIController.blokusRoomPanel);

        if (GameCache.roomType == RoomType.BLOKUS_FOUR) {
            Application.UnloadLevel("Blokus");
        } else {
            Application.UnloadLevel("BlokusTP");
        }
    }

    public void OnButtonOnMessage() {
        ShowMessage("");
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
    //            myBlokusController.fail(color);
    //        }
    //    }

    //    ShowMessage(str+"方已离开游戏");
    //    print("}断开连接");
    //}


    //public void InitBlokusRoomUIInfo()  //初始化房间信息
    //{
    //    BlokusRoomName.text = "房间名字:"+PhotonNetwork.room.Name;
    //    BlokusYourName.text = "你的名字:"+PhotonNetwork.player.NickName;
    //    playerOneName.text = "";
    //    playerTwoName.text = "";
    //    playerThreeName.text = "";
    //    playerFourName.text = "";
    //    playerOneChoice.text = "";
    //    playerTwoChoice.text = "";
    //    playerThreeChoice.text = "";
    //    playerFourChoice.text = "";
    //    CurrentColor.text = "目前下棋的颜色:蓝色";
    //    PhotonPlayer[] players = PhotonNetwork.playerList;
    //    int i = 1;

    //    foreach (PhotonPlayer p in players)
    //    {
    //        ExitGames.Client.Photon.Hashtable ht = p.AllProperties;
    //        switch (i)
    //        {
    //            case 1:
    //                {
    //                    playerOneName.text = ht["name"].ToString();
    //                    playerOneChoice.text = ht["color"].ToString();
    //                    break;
    //                }
    //            case 2:
    //                {
    //                    playerTwoName.text = ht["name"].ToString();
    //                    playerTwoChoice.text = ht["color"].ToString();
    //                    break;
    //                }
    //            case 3:
    //                {
    //                    playerThreeName.text = ht["name"].ToString();
    //                    playerThreeChoice.text = ht["color"].ToString();
    //                    break;
    //                }
    //            case 4:
    //                {
    //                    playerFourName.text = ht["name"].ToString();
    //                    playerFourChoice.text = ht["color"].ToString();
    //                    break;
    //                }
    //        }
    //        i++;
    //    }
    //}


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
        BlokusMessage.SetActive(BlokusMessage.activeSelf ? false : true);
        MessageText.text = message;
    }

    /******************功能函数***/


    // [PunRPC]
    //public void SendMessageToAll(string message) {
    //    chatContent.text = chatContent.text + "\n" + message;
    //    scrollbar.value = 0;
    //}

    public void chatInGame(string message) {
        chatContent.text = chatContent.text + "\n" + message;
        scrollbar.value = 0;
    }
}
