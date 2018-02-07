using protos.blokus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokusController : MonoBehaviour {

    public GameObject currentCenterPrefab;

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

    int[] a1 = new int[5];   //记录用来传递的一维数组信息(由二维数组拆成的五个一维数组)
    int[] b1 = new int[5];
    int[] c1 = new int[5];
    int[] d1 = new int[5];
    int[] e1 = new int[5];
    int firstFour = 1;     //判断前四次下棋子
    string CurrentSquareName;   //当前选择的棋子的名字
    bool isSelect = false;     //是否已经选择棋子
    int[,] allChess = new int[20, 20];    //棋盘数组，记录棋局信息
    Square CurrentSquare;   //当前操作的棋子对象   
    const int blue = 1;//定义颜色常量
    const int green = 2;
    const int red = 3;
    const int yellow = 4;
    public Hashtable allSquare = new Hashtable();  //记录棋子对象的哈希表，用来快速按名字查找
    public GameObject currentCenter;

    public int[] loseColor;  //记录已经输了的颜色
    public int CurrentColor = blue;    //当前下棋子的颜色
    public int myColor = 0;  //玩家的颜色
    public int loseCount = 0;  //已经输的玩家的个数


    //public void getFailCurrent()
    //{
    //    if (loseCount == 3)
    //    {
    //        return;
    //    }
    //    GetComponent<PhotonView>().RPC("fail", PhotonTargets.AllBuffered, CurrentColor);
    //}

    //public void getFail(int color)
    //{
    //    //if (loseCount == 3)
    //    //{
    //    //    return;
    //    //}
    //    GetComponent<PhotonView>().RPC("fail", PhotonTargets.AllBuffered, color);
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
        CurrentColor++;
        if (CurrentColor > 4) {
            CurrentColor = 1;
        }

        while (loseColor[CurrentColor] == 1) {
            CurrentColor++;
            if (CurrentColor > 4) {
                CurrentColor = 1;
            }
        }
        GameObject.Find("BlokusUIController").GetComponent<BlokusUIController>().BlokusUIUpdate(CurrentColor);
    }

    // Use this for initialization
    void Start() {
        GameObject.Find("BlokusCamera").GetComponent<Camera>().enabled = true;
        GameObject.Find("StartCamera").GetComponent<Camera>().enabled = false;

        loseColor = new int[5] { 0, 0, 0, 0, 0 };
        intiChessBoard();
        getMyColor();
        InitSquare initSquare = new InitSquare();

        // myColor = Temp.myColor;
    }

    // Update is called once per frame
    void Update() {
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
                if (firstFour > 0) {
                    print("firstfour");
                    if (judgeFirstTime(x, y, CurrentSquare.model, CurrentSquare.color)) //四个角的判断
                    {
                        print("OK,可以放下,第一次");
                        //setModel();
                        GameObject.Find("Canvas").GetComponent<ChoosePanel>().DestoryBtn();//销毁图形

                        //   GetComponent<PhotonView>().RPC("judgeSuccess", PhotonTargets.AllBuffered,x, y,CurrentSquareName,CurrentSquare.rotationFlag,CurrentSquare.symmetryFlag,a1,b1,c1,d1,e1);
                        //   print("OK,可以放下,第一次");    
                        // judgeSuccess(x, y, CurrentSquareName, CurrentSquare.rotationFlag, CurrentSquare.symmetryFlag, a1, b1, c1, d1, e1);



                        NetManager.Instance.TransferMessage(MessageFormater.formatChessDoneMessage(x, y, CurrentSquareName, CurrentSquare.rotationFlag, CurrentSquare.symmetryFlag, CurrentSquare.model));

                    }
                } else if (judge(x, y, CurrentSquare.model, CurrentSquare.color)) //判断是否可以放下
                  {
                    //  setModel();
                    GameObject.Find("Canvas").GetComponent<ChoosePanel>().DestoryBtn();//销毁图形
                    print("OK,可以放下,后面");                                                                 //   GetComponent<PhotonView>().RPC("judgeSuccess", PhotonTargets.AllBuffered, x, y, CurrentSquareName, CurrentSquare.rotationFlag, CurrentSquare.symmetryFlag, a1, b1, c1, d1, e1);
                    NetManager.Instance.TransferMessage(MessageFormater.formatChessDoneMessage(x, y, CurrentSquareName, CurrentSquare.rotationFlag, CurrentSquare.symmetryFlag, CurrentSquare.model));
                }
            }
        }
    }

    void intiChessBoard() //初始化棋盘
    {
        for (int i = 0; i < 20; i++) {
            for (int j = 0; j < 20; j++) {
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

    void setModel()//获取数组模型的一维数组，用来传递
    {

        for (int i = 0; i < 5; i++)
            a1[i] = CurrentSquare.model[0, i];
        for (int i = 0; i < 5; i++)
            b1[i] = CurrentSquare.model[1, i];
        for (int i = 0; i < 5; i++)
            c1[i] = CurrentSquare.model[2, i];
        for (int i = 0; i < 5; i++)
            d1[i] = CurrentSquare.model[3, i];
        for (int i = 0; i < 5; i++)
            e1[i] = CurrentSquare.model[4, i];
    }



    int[,] getModel(int[] a, int[] b, int[] c, int[] d, int[] e) {  //一维数组组成二维数组


        int[,] m = new int[5, 5];
        for (int i = 0; i < 5; i++)
            m[0, i] = a[i];
        for (int i = 0; i < 5; i++)
            m[1, i] = b[i];
        for (int i = 0; i < 5; i++)
            m[2, i] = c[i];
        for (int i = 0; i < 5; i++)
            m[3, i] = d[i];
        for (int i = 0; i < 5; i++)
            m[4, i] = e[i];
        return m;
    }


    //public void OtherCallFail(int color)
    //{
    //    if (loseCount == 3)
    //    {
    //        //color赢啦
    //        return;
    //    }
    //    if (loseColor[color] == 1)
    //    {
    //        //color已经输了，不能再输
    //        return;
    //    }
    //    loseCount++;
    //    loseColor[color] = 1;
    //    if (color == CurrentColor)
    //    {
    //        changeCurrentColor();
    //    }
    //    firstFour--;
    //    GameObject.Find("BlokusUIController").GetComponent<BlokusUIController>().SendMessageByYourself(color);
    //}

    // [PunRPC]
    public void fail(int color) {
        //if (loseCount == 3)
        //{
        //    //color赢啦
        //    return;
        //}
        //if (loseColor[color] == 1)
        //{
        //    //color已经输了，不能再输
        //    return;
        //}
        loseCount++;
        loseColor[color] = 1;

        if (CurrentColor <= color) {
            firstFour--;
        }
        if (color == CurrentColor) {
            changeCurrentColor();
        }
        GameObject.Find("BlokusUIController").GetComponent<BlokusUIController>().ChangeMessageByYourself(color);
    }


    void judgeSuccess(BLOKUSChessDoneInfo chessDoneInfo) {
        Square oweSquare = (Square)allSquare[chessDoneInfo.squareName];
        int oldRF = oweSquare.rotationFlag;
        int oldSF = oweSquare.symmetryFlag;
        oweSquare.rotationFlag = chessDoneInfo.rotationFlag;
        oweSquare.symmetryFlag = chessDoneInfo.symmetryFlag;
        int x = chessDoneInfo.x;
        int y = chessDoneInfo.y;
        oweSquare.set(x + 0.5f, -(y + 0.5f));
        Destroy(currentCenter);
        print("实例化");
        currentCenter = (GameObject)Instantiate(currentCenterPrefab, new Vector2((float)(x + 0.5), -(float)(y + 0.5)), Quaternion.identity); //中心 图片转换   
        updateChess(x, y, chessDoneInfo.model, oweSquare.color);
        isSelect = false;
        //changeCurrentColor();
        //GameObject.Find("Canvas").GetComponent<ChoosePanel>().setPanelColor();//切换画板

        if (firstFour > 0) {
            firstFour--;
        }
        oweSquare.rotationFlag = oldRF;
        oweSquare.symmetryFlag = oldSF;
    }



    // [PunRPC]
    void judgeSuccess(int x, int y, string name, int rFlag, int sFlag, int[] a, int[] b, int[] c, int[] d, int[] e) {
        Square oweSquare = (Square)allSquare[name];
        int oldRF = oweSquare.rotationFlag;
        int oldSF = oweSquare.symmetryFlag;
        oweSquare.rotationFlag = rFlag;
        oweSquare.symmetryFlag = sFlag;
        oweSquare.set(x + 0.5f, -(y + 0.5f));
        Destroy(currentCenter);
        print("实例化");
        currentCenter = (GameObject)Instantiate(currentCenterPrefab, new Vector2((float)(x + 0.5), -(float)(y + 0.5)), Quaternion.identity); //中心 图片转换   
        updateChess(x, y, getModel(a, b, c, d, e), oweSquare.color);
        isSelect = false;
        //  changeCurrentColor();
        //GameObject.Find("Canvas").GetComponent<ChoosePanel>().setPanelColor();//切换画板

        if (firstFour > 0) {
            firstFour--;
        }
        oweSquare.rotationFlag = oldRF;
        oweSquare.symmetryFlag = oldSF;
    }




    bool touchOutLine(int x, int y)  //判断触摸出界
    {
        if (x < 0 || x > 19 || y < 0 || y > 19) {
            return true;
        }
        return false;
    }

    bool outLine(int x, int y)   //判断棋子位置是否出界
    {
        if (x < 0 || x > 19 || y < 0 || y > 19) {
            return true;
        }
        return false;
    }

    bool modelOutLine(int x, int y)   //判断数组模型是否出界
    {
        if (x < 0 || x > 4 || y < 0 || y > 4) {
            return true;
        }
        return false;
    }

    void updateChess(int x, int y, int[,] model, int color) //成功下棋子之后更新棋盘数组
    {
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

    void updateChess(int x, int y, byte[] model, int color) //成功下棋子之后更新棋盘数组
    {
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

    bool judgeFirstTime(int x, int y, int[,] model, int color)//前四次下棋子判断
    {
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
                    switch (color) {
                        case green:
                            if (wx == 0 && wy == 0) { return true; }
                            break;
                        case red:
                            if (wx == 0 && wy == 19) { return true; }
                            break;
                        case yellow:
                            if (wx == 19 && wy == 19) { return true; }
                            break;
                        case blue:
                            if (wx == 19 && wy == 0) { return true; }
                            break;
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

