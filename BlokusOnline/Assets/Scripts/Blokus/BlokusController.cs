using protos.blokus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokusController : MonoBehaviour {

    public int MAX_PLAYERS_COUNT; //玩家数量
    public int MAX_ROW_AND_COLUMN;

    public GameObject currentCenterPrefab;
    public GameObject tempCenterPrefab;

    //每个棋子的预设体
    public GameObject green1_a_p;
    public GameObject green2_a_p;
    public GameObject green3_a_p;
    public GameObject green3_b_p;
    public GameObject green4_a_p;
    public GameObject green4_b_p;
    public GameObject green4_c_p;
    public GameObject green4_d_p;
    public GameObject green4_e_p;
    public GameObject green5_a_p;
    public GameObject green5_b_p;
    public GameObject green5_c_p;
    public GameObject green5_d_p;
    public GameObject green5_e_p;
    public GameObject green5_f_p;
    public GameObject green5_g_p;
    public GameObject green5_h_p;
    public GameObject green5_i_p;
    public GameObject green5_j_p;
    public GameObject green5_k_p;
    public GameObject green5_l_p;

    public GameObject red1_a_p;
    public GameObject red2_a_p;
    public GameObject red3_a_p;
    public GameObject red3_b_p;
    public GameObject red4_a_p;
    public GameObject red4_b_p;
    public GameObject red4_c_p;
    public GameObject red4_d_p;
    public GameObject red4_e_p;
    public GameObject red5_a_p;
    public GameObject red5_b_p;
    public GameObject red5_c_p;
    public GameObject red5_d_p;
    public GameObject red5_e_p;
    public GameObject red5_f_p;
    public GameObject red5_g_p;
    public GameObject red5_h_p;
    public GameObject red5_i_p;
    public GameObject red5_j_p;
    public GameObject red5_k_p;
    public GameObject red5_l_p;

    public GameObject blue1_a_p;
    public GameObject blue2_a_p;
    public GameObject blue3_a_p;
    public GameObject blue3_b_p;
    public GameObject blue4_a_p;
    public GameObject blue4_b_p;
    public GameObject blue4_c_p;
    public GameObject blue4_d_p;
    public GameObject blue4_e_p;
    public GameObject blue5_a_p;
    public GameObject blue5_b_p;
    public GameObject blue5_c_p;
    public GameObject blue5_d_p;
    public GameObject blue5_e_p;
    public GameObject blue5_f_p;
    public GameObject blue5_g_p;
    public GameObject blue5_h_p;
    public GameObject blue5_i_p;
    public GameObject blue5_j_p;
    public GameObject blue5_k_p;
    public GameObject blue5_l_p;

    public GameObject yellow1_a_p;
    public GameObject yellow2_a_p;
    public GameObject yellow3_a_p;
    public GameObject yellow3_b_p;
    public GameObject yellow4_a_p;
    public GameObject yellow4_b_p;
    public GameObject yellow4_c_p;
    public GameObject yellow4_d_p;
    public GameObject yellow4_e_p;
    public GameObject yellow5_a_p;
    public GameObject yellow5_b_p;
    public GameObject yellow5_c_p;
    public GameObject yellow5_d_p;
    public GameObject yellow5_e_p;
    public GameObject yellow5_f_p;
    public GameObject yellow5_g_p;
    public GameObject yellow5_h_p;
    public GameObject yellow5_i_p;
    public GameObject yellow5_j_p;
    public GameObject yellow5_k_p;
    public GameObject yellow5_l_p;


    int firstFour;     //判断前四次下棋子
    string CurrentSquareName;   //当前选择的棋子的名字
    bool isSelect = false;     //是否已经选择棋子
    int[,] allChess;  //棋盘数组，记录棋局信息
    Square CurrentSquare;   //当前操作的棋子对象   
    const int blue = 1;//定义颜色常量
    const int green = 2;
    const int red = 3;
    const int yellow = 4;
    public Hashtable allSquare = new Hashtable();  //记录棋子对象的哈希表，用来快速按名字查找
    public GameObject currentCenterTemp;
    public GameObject currentCenter;

    public int[] loseColor;  //记录已经输了的颜色
    public int CurrentColor = blue;    //当前下棋子的颜色
    public int myColor = 0;  //玩家的颜色
    public int loseCount = 0;  //已经输的玩家的个数

    public bool gameOver = false;

    public GameObject tempSquare;

    private System.Object CHESS_JUDGE_LOCK = new System.Object();

    private System.Object CHESS_DONE_LOCK = new System.Object();

    private System.Object SURE_LOCK = new System.Object();

    // Use this for initialization
    void Start() {
        firstFour = MAX_PLAYERS_COUNT;
        allChess = new int[MAX_ROW_AND_COLUMN, MAX_ROW_AND_COLUMN];
        GameObject.Find("BlokusCamera").GetComponent<Camera>().enabled = true;
        GameObject.Find("StartCamera").GetComponent<Camera>().enabled = false;

        loseColor = new int[5] { 0, 0, 0, 0, 0 };
        intiChessBoard();
        getMyColor();
        InitSquare.init(this);

        // myColor = Temp.myColor;
    }

    //public void getFailCurrent()
    //{
    //    if (loseCount == 3)
    //    {
    //        return;
    //    }
    //    GetComponent<PhotonView>().RPC("fail", PhotonTargets.AllBuffered, CurrentColor);
    //}

    //public void giveUp(int color) {
    //    //if (loseCount == 3)
    //    //{
    //    //    return;
    //    //}
    //    GetComponent<PhotonView>().RPC("", PhotonTargets.AllBuffered, color);
    //}

    //当前棋子旋转操作
    public void squareRotation() {
        if (CurrentSquare.symmetryFlag == 0) {
            CurrentSquare.rotationOne();
        } else {
            CurrentSquare.rotationTwo();
        }
    }

    //当前棋子对称操作
    public void squareSymmetry() {
        CurrentSquare.symmetry();
    }

    //设置新的当前操作的棋子
    public void setCurrentSquareName(string name) {
        print(name);
        isSelect = true;
        CurrentSquareName = name;
        CurrentSquare = (Square)allSquare[name];
    }

    void changeCurrentColor() {
        CurrentColor = getNextColor(CurrentColor);
        GameObject.Find("BlokusUIController").GetComponent<BlokusUIController>().BlokusUIUpdate(CurrentColor);
    }

    public int getNextColor(int color) {
        if (loseCount >= MAX_PLAYERS_COUNT) {
            return color;
        }

        //color++;
        //if (color > MAX_PLAYERS_COUNT) {
        //    color = 1;
        //}

        //while (loseColor[color] == 1) {
        //    color++;
        //    if (color > MAX_PLAYERS_COUNT) {
        //        color = 1;
        //    }
        //}

        do {
            color++;
            if (color > MAX_PLAYERS_COUNT) {
                color = 1;
            }
        } while (loseColor[color] == 1);

        return color;
    }



    // Update is called once per frame
    void Update() {
        lock (CHESS_JUDGE_LOCK) {
            chessDoneJudge();
        }
    }

    private void chessDoneJudge() {
        if (Input.touchCount == 1 || Input.GetMouseButtonUp(0)) {
            Vector2 p = new Vector2();
            if (Input.GetMouseButtonUp(0)) {
                p = Input.mousePosition;
            } else if (Input.touches[0].phase == TouchPhase.Began) {
                p = Input.touches[0].position;
            } else if (Input.touches[0].phase != TouchPhase.Began) {
                return;
            }
            Vector2 pos = Camera.main.ScreenToWorldPoint(p);//屏幕坐标转化为世界坐标

            int x = (int)(pos.x);
            int y = (int)(-pos.y);

            print(x + "," + y);
            if (touchOutLine(x, y)) {
                print("触摸出界");
                return;
            }
            if (!isSelect) {
                print("没有选择");
                return;
            }
            if (myColor != CurrentColor) {
                return;
            }
            if (isSelect) {
                print("选择了");
                judgeAround(x, y);
            }
        }
    }

    private void judgeAround(int x, int y) {
        bool judgeSuccess = false;
        int lastX = x;
        int lastY = y;

        if (judgeOverall(x, y)) {
            judgeSuccess = true;
        } else {
            foreach (ChessPoint point in getAroundPoints(x, y)) {
                if (judgeOverall(point.x, point.y)) {
                    judgeSuccess = true;
                    lastX = point.x;
                    lastY = point.y;
                    break;
                }
            }
        }

        if (judgeSuccess) {
            MessageBean message = MessageFormater.formatChessDoneMessage(lastX, lastY, CurrentSquareName, CurrentSquare.rotationFlag, CurrentSquare.symmetryFlag, CurrentSquare.model);
            BLOKUSChessDoneInfo chessDoneInfo = ProtobufHelper.DederializerFromBytes<BLOKUSChessDoneInfo>(message.data);
            GameObject.Find("BlokusUIController").GetComponent<BlokusUIController>().tryChess(chessDoneInfo);
            //  chessDone(chessDoneInfo);
        }
    }

    private List<ChessPoint> getAroundPoints(int x, int y) {
        List<ChessPoint> points = new List<ChessPoint>(8);
        points.Add(new ChessPoint(x - 1, y - 1));
        points.Add(new ChessPoint(x - 1, y));
        points.Add(new ChessPoint(x - 1, y + 1));
        points.Add(new ChessPoint(x + 1, y - 1));
        points.Add(new ChessPoint(x + 1, y));
        points.Add(new ChessPoint(x + 1, y + 1));
        points.Add(new ChessPoint(x, y - 1));
        points.Add(new ChessPoint(x, y + 1));

        return points;
    }


    private bool judgeOverall(int x, int y) {


        if (firstFour > 0 && judgeFirstTime(x, y, CurrentSquare.model, CurrentSquare.color)) {
            print("firstfour");
            //四个角的判断

            print("OK,可以放下,第一次");
            return true;

        } else if (judge(x, y, CurrentSquare.model, CurrentSquare.color)) {
            //判断是否可以放下
            print("OK,可以放下,后面");
            //   GetComponent<PhotonView>().RPC("judgeSuccess", PhotonTargets.AllBuffered, x, y, CurrentSquareName, CurrentSquare.rotationFlag, CurrentSquare.symmetryFlag, a1, b1, c1, d1, e1);
            return true;
        }

        return false;
    }



    void intiChessBoard() //初始化棋盘
    {
        for (int i = 0; i < MAX_ROW_AND_COLUMN; i++) {
            for (int j = 0; j < MAX_ROW_AND_COLUMN; j++) {
                allChess[i, j] = 0;
            }
        }
    }

    void getMyColor() {
        myColor = GameCache.myColor;
        string str = Color.getColorText(GameCache.myColor);
        if (str.Equals("blue")) {
        } else if (str.Equals("green")) {
            GameObject.Find("Canvas").GetComponent<ChoosePanel>().ShowGreen();
        } else if (str.Equals("red")) {
            GameObject.Find("Canvas").GetComponent<ChoosePanel>().ShowRed();
        } else if (str.Equals("yellow")) {
            GameObject.Find("Canvas").GetComponent<ChoosePanel>().ShowYellow();
        }
    }

    // [PunRPC]
    public void lose(int color) {
        if (loseCount == MAX_PLAYERS_COUNT - 1) {
            //color赢啦
            return;
        }
        if (loseColor[color] == 1) {
            //color已经输了，不能再输
            return;
        }

        loseCount++;
        loseColor[color] = 1;

        if (CurrentColor <= color) {
            firstFour--;
        }
        if (color == CurrentColor) {
            changeCurrentColor();
        }
    }


    public void tryChess(BLOKUSChessDoneInfo chessDoneInfo) {
        Square oweSquare = (Square)allSquare[chessDoneInfo.squareName];
        int oldRF = oweSquare.rotationFlag;
        int oldSF = oweSquare.symmetryFlag;
        oweSquare.rotationFlag = chessDoneInfo.rotationFlag;
        oweSquare.symmetryFlag = chessDoneInfo.symmetryFlag;
        int x = chessDoneInfo.x;
        int y = chessDoneInfo.y;
        Destroy(tempSquare);
        tempSquare = oweSquare.trySet(x + 0.5f, -(y + 0.5f));
        Destroy(currentCenterTemp);
        print("实例化");
        currentCenterTemp = Instantiate(tempCenterPrefab, new Vector2((float)(x + 0.5), -(float)(y + 0.5)), Quaternion.identity);

        oweSquare.rotationFlag = oldRF;
        oweSquare.symmetryFlag = oldSF;
    }

    internal void chessDoneOutSide(BLOKUSChessDoneInfo chessDoneInfoTemp, bool sure) {
        Destroy(currentCenterTemp);
        Destroy(tempSquare);
        if (sure) {
            lock (SURE_LOCK) {
                if (CurrentColor == myColor) {
                    GameObject.Find("Canvas").GetComponent<ChoosePanel>().DestoryBtn();
                    NetManager.Instance.TransferMessage(MessageFormater.formatChessDoneMessage(chessDoneInfoTemp));
                    chessDone(chessDoneInfoTemp);
                }
            }
        }
    }


    public void chessDone(BLOKUSChessDoneInfo chessDoneInfo) {

        lock (CHESS_DONE_LOCK) {

            Debug.Log("show dao************************************************************");
            Square oweSquare = (Square)allSquare[chessDoneInfo.squareName];

            if (oweSquare.color != CurrentColor) {
                return;
            }

            int oldRF = oweSquare.rotationFlag;
            int oldSF = oweSquare.symmetryFlag;
            oweSquare.rotationFlag = chessDoneInfo.rotationFlag;
            oweSquare.symmetryFlag = chessDoneInfo.symmetryFlag;
            int x = chessDoneInfo.x;
            int y = chessDoneInfo.y;
            oweSquare.set(x + 0.5f, -(y + 0.5f));
            Destroy(currentCenter);
            print("实例化");
            currentCenter = Instantiate(currentCenterPrefab, new Vector2((float)(x + 0.5), -(float)(y + 0.5)), Quaternion.identity); //中心 图片转换   
            GameObject.Find("BlokusUIController").GetComponent<BlokusUIController>().playChessDoneMusic();
            updateChess(x, y, chessDoneInfo.model, oweSquare.color);
            isSelect = false;
            changeCurrentColor();
            //GameObject.Find("Canvas").GetComponent<ChoosePanel>().setPanelColor();//切换画板

            if (firstFour > 0) {
                firstFour--;
            }
            oweSquare.rotationFlag = oldRF;
            oweSquare.symmetryFlag = oldSF;
        }
    }



    //// [PunRPC]
    //void judgeSuccess(int x, int y, string name, int rFlag, int sFlag, int[] a, int[] b, int[] c, int[] d, int[] e) {
    //    Square oweSquare = (Square)allSquare[name];
    //    int oldRF = oweSquare.rotationFlag;
    //    int oldSF = oweSquare.symmetryFlag;
    //    oweSquare.rotationFlag = rFlag;
    //    oweSquare.symmetryFlag = sFlag;
    //    oweSquare.set(x + 0.5f, -(y + 0.5f));
    //    Destroy(currentCenter);
    //    print("实例化");
    //    currentCenter = (GameObject)Instantiate(currentCenterPrefab, new Vector2((float)(x + 0.5), -(float)(y + 0.5)), Quaternion.identity); //中心 图片转换   
    //    updateChess(x, y, getModel(a, b, c, d, e), oweSquare.color);
    //    isSelect = false;
    //    //  changeCurrentColor();
    //    //GameObject.Find("Canvas").GetComponent<ChoosePanel>().setPanelColor();//切换画板

    //    if (firstFour > 0) {
    //        firstFour--;
    //    }
    //    oweSquare.rotationFlag = oldRF;
    //    oweSquare.symmetryFlag = oldSF;
    //}



    //判断触摸出界
    bool touchOutLine(int x, int y) {
        if (x < 0 || x > MAX_ROW_AND_COLUMN - 1 || y < 0 || y > MAX_ROW_AND_COLUMN - 1) {
            return true;
        }
        return false;
    }

    //判断棋子位置是否出界
    bool outLine(int x, int y) {
        if (x < 0 || x > MAX_ROW_AND_COLUMN - 1 || y < 0 || y > MAX_ROW_AND_COLUMN - 1) {
            return true;
        }
        return false;
    }

    //判断数组模型是否出界
    bool modelOutLine(int x, int y) {
        if (x < 0 || x > 4 || y < 0 || y > 4) {
            return true;
        }
        return false;
    }

    //成功下棋子之后更新棋盘数组
    void updateChess(int x, int y, int[,] model, int color) {
        for (int j = 0; j < 5; j++) {
            for (int i = 0; i < 5; i++) {
                if (model[j, i] == 1) {
                    int wx = x - 2 + i;
                    int wy = y - 2 + j;
                    allChess[wx, wy] = color;
                }
            }
        }
    }

    //成功下棋子之后更新棋盘数组
    void updateChess(int x, int y, byte[] model, int color) {
        //for (int j = 0; j < 5; j++) {
        //    for (int i = 0; i < 5; i++) {
        //        if (model[j, i] == 1) {
        //            int wx = x - 2 + i;
        //            int wy = y - 2 + j;
        //            allChess[wx, wy] = color;
        //        }
        //    }
        //}

        for (int i = 0; i < 25; i++) {
            if (model[i] == 1) {
                int wx = x - 2 + i % 5;
                int wy = y - 2 + i / 5;
                allChess[wx, wy] = color;
            }
        }
    }

    //前四次下棋子判断
    bool judgeFirstTime(int x, int y, int[,] model, int color) {
        for (int j = 0; j < 5; j++) {
            for (int i = 0; i < 5; i++) {
                if (model[j, i] == 1) {
                    int wx = x - 2 + i;
                    int wy = y - 2 + j;
                    //print(wx + "++" + wy);
                    if (outLine(wx, wy)) {
                        print("出界");
                        return false;
                    }
                }
            }
        }
        for (int j = 0; j < 5; j++) {
            for (int i = 0; i < 5; i++) {
                if (model[j, i] == 1) {
                    int wx = x - 2 + i;
                    int wy = y - 2 + j;
                    //print(wx + "++" + wy);       
                    if (MAX_PLAYERS_COUNT == 2) {
                        switch (color) {
                            case green:
                                if (wx == 0 && wy == MAX_ROW_AND_COLUMN - 1) { return true; }
                                break;
                            case blue:
                                if (wx == MAX_ROW_AND_COLUMN - 1 && wy == 0) { return true; }
                                break;
                        }
                    } else {
                        switch (color) {
                            case green:
                                if (wx == 0 && wy == 0) { return true; }
                                break;
                            case red:
                                if (wx == 0 && wy == MAX_ROW_AND_COLUMN - 1) { return true; }
                                break;
                            case yellow:
                                if (wx == MAX_ROW_AND_COLUMN - 1 && wy == MAX_ROW_AND_COLUMN - 1) { return true; }
                                break;
                            case blue:
                                if (wx == MAX_ROW_AND_COLUMN - 1 && wy == 0) { return true; }
                                break;
                        }
                    }
                }
            }
        }
        return false;
    }

    //判断四边是否有棋子跟自身颜色一样，有就返回true
    bool judgeOne(int new_wx, int new_wy, int new_i, int new_j, int[,] model, int color) {
        if (!outLine(new_wx, new_wy)) {
            if (modelOutLine(new_i, new_j)) {
                if (allChess[new_wx, new_wy] == color) {
                    return true;
                }
            } else if (model[new_j, new_i] != 1) {
                if (allChess[new_wx, new_wy] == color) {
                    return true;
                }
            }
        }
        return false;
    }

    //判断是否有一个角和自身颜色一样，有就返回true
    bool judgeTow(int new_wx, int new_wy, int new_i, int new_j, int[,] model, int color) {
        if (!outLine(new_wx, new_wy)) {
            if (modelOutLine(new_i, new_j)) {
                if (allChess[new_wx, new_wy] == color) {
                    return true;
                }
            } else if (model[new_j, new_i] != 1) {
                if (allChess[new_wx, new_wy] == color) {
                    return true;
                }
            }
        }
        return false;
    }

    //下棋判断函数
    bool judge(int x, int y, int[,] model, int color) {
        for (int j = 0; j < 5; j++) {
            for (int i = 0; i < 5; i++) {
                if (model[j, i] == 1) {
                    int wx = x - 2 + i;
                    int wy = y - 2 + j;
                    print(wx + "++" + wy);
                    if (outLine(wx, wy)) {
                        print("出界");
                        return false;
                    }
                    if (allChess[wx, wy] != 0) {
                        return false;
                    }
                    if (allChess[wx, wy] == 0) {
                        if (judgeOne(wx + 1, wy, i + 1, j, model, color)) {
                            return false;
                        }
                        if (judgeOne(wx, wy - 1, i, j - 1, model, color)) {
                            return false;
                        }
                        if (judgeOne(wx, wy + 1, i, j + 1, model, color)) {
                            return false;
                        }
                        if (judgeOne(wx - 1, wy, i - 1, j, model, color)) {
                            return false;
                        }
                    }
                }
            }
        }
        print("第一阶段判断成功");
        for (int j = 0; j < 5; j++) {
            for (int i = 0; i < 5; i++) {
                if (model[j, i] == 1) {
                    int wx = x - 2 + i;
                    int wy = y - 2 + j;

                    if (judgeTow(wx + 1, wy + 1, i + 1, j + 1, model, color)) {
                        return true;
                    }
                    if (judgeTow(wx - 1, wy + 1, i - 1, j + 1, model, color)) {
                        return true;
                    }
                    if (judgeTow(wx + 1, wy - 1, i + 1, j - 1, model, color)) {
                        return true;
                    }
                    if (judgeTow(wx - 1, wy - 1, i - 1, j - 1, model, color)) {
                        return true;
                    }
                }
            }
        }
        print("第二阶段判断成功");
        return false;
    }
}

