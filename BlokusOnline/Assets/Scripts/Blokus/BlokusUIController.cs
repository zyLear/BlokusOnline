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
    const int DEADLINETIME = 60;


    const int blue = Color.BLUE;//定义颜色常量
    const int green = Color.GREEN;
    const int red = Color.RED;
    const int yellow = Color.YELLOW;

    float deadline = DEADLINETIME;
    int currentShowTime = DEADLINETIME;

    BlokusController myBlokusController;

    public void Start() {
        myUIController = GameObject.Find("UIController").GetComponent<UIController>();
        myBlokusController = GameObject.Find("BlokusController").GetComponent<BlokusController>();
        StartCoroutine(JudgeTimeOut());   //开启协程
                                          //   InitBlokusRoomUIInfo();
    }

    //public void Update()
    //{
    //   // chatContent.text = chatContentString;
    //    //testText.text = chatContentString;

    //}

    /********协程***************/
    IEnumerator JudgeTimeOut() {
        while (true) {
            while (deadline > 0) {
                deadline -= Time.deltaTime;
                int time = (int)deadline;
                if (time < currentShowTime) {
                    currentShowTime = time;
                    ShowTime.text = "时间：" + currentShowTime;
                }
                yield return 0;
            }
            if (myBlokusController.loseCount == 3) {
                print(myBlokusController.CurrentColor);
                if (myBlokusController.CurrentColor == myBlokusController.myColor) {
                    ShowMessage("恭喜你赢了！");
                }
                break;
            }
            deadline = DEADLINETIME;
            currentShowTime = DEADLINETIME;

            if (myBlokusController.CurrentColor == myBlokusController.myColor) {
                ShowMessage("下棋截止时间到，很遗憾，你输啦~~");
            } else {
                ShowMessage("下棋截止时间到，" + getColor(myBlokusController.CurrentColor) + "方输了！");
            }
            myBlokusController.fail(myBlokusController.CurrentColor);
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
        SendMessageToAll(str);
    }

    //public void Siut()
    //{
    //    print("按下发送按钮");
    //    string str = "<color="+getColor(myBlokusController.myColor) +">" + PhotonNetwork.player.NickName + "说：" + inputInfo.text + "</color>";
    //    GetComponent<PhotonView>().RPC("SendMessageToAll", PhotonTargets.All, str);
    //}

    public void OnGiveUp() {
        if (myBlokusController.loseCount < 3) {
            if (myBlokusController.loseColor[myBlokusController.myColor] == 0) {
                //   myBlokusController.getFail(myBlokusController.myColor);
            }
            ShowMessage("你已经输了~");
        }
        ShowMessage("恭喜你赢啦！");
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

        //    UIControl.PanelChange(myUIControl.BlokusRoom);

        Application.UnloadLevel("Blokus");
    }

    public void OnButtonOnMessage() {
        ShowMessage("");
    }

    public void BlokusUIUpdate(int color)   //其他脚本调用的函数
    {
        CurrentColor.text = "目前下棋的颜色:" + getColor(color);
        deadline = DEADLINETIME;
        currentShowTime = DEADLINETIME;
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
    public void SendMessageToAll(string message) {
        chatContent.text = chatContent.text + "\n" + message;
        scrollbar.value = 0;
    }
}
