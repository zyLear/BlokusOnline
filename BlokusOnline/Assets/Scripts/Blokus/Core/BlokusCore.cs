
public class BlokusCore {


    const int blue = 1;//定义颜色常量
    const int green = 2;
    const int red = 3;
    const int yellow = 4;





    ////判断触摸出界
    //bool touchOutLine(int x, int y) {
    //    if (x < 0 || x > MAX_ROW_AND_COLUMN - 1 || y < 0 || y > MAX_ROW_AND_COLUMN - 1) {
    //        return true;
    //    }
    //    return false;
    //}

    ////判断棋子位置是否出界
    //bool outLine(int x, int y) {
    //    if (x < 0 || x > MAX_ROW_AND_COLUMN - 1 || y < 0 || y > MAX_ROW_AND_COLUMN - 1) {
    //        return true;
    //    }
    //    return false;
    //}

    ////判断数组模型是否出界
    //bool modelOutLine(int x, int y) {
    //    if (x < 0 || x > 4 || y < 0 || y > 4) {
    //        return true;
    //    }
    //    return false;
    //}



    //////前四次下棋子判断
    ////bool judgeFirstTime(int x, int y, int[,] model, int color) {
    ////    for (int j = 0; j < 5; j++) {
    ////        for (int i = 0; i < 5; i++) {
    ////            if (model[j, i] == 1) {
    ////                int wx = x - 2 + i;
    ////                int wy = y - 2 + j;
    ////                //print(wx + "++" + wy);
    ////                if (outLine(wx, wy)) {
    ////                   // print("出界");
    ////                    return false;
    ////                }
    ////            }
    ////        }
    ////    }
    ////    for (int j = 0; j < 5; j++) {
    ////        for (int i = 0; i < 5; i++) {
    ////            if (model[j, i] == 1) {
    ////                int wx = x - 2 + i;
    ////                int wy = y - 2 + j;
    ////                //print(wx + "++" + wy);       
    ////                if (MAX_PLAYERS_COUNT == 2) {
    ////                    switch (color) {
    ////                        case green:
    ////                            if (wx == 0 && wy == MAX_ROW_AND_COLUMN - 1) { return true; }
    ////                            break;
    ////                        case blue:
    ////                            if (wx == MAX_ROW_AND_COLUMN - 1 && wy == 0) { return true; }
    ////                            break;
    ////                    }
    ////                } else {
    ////                    switch (color) {
    ////                        case green:
    ////                            if (wx == 0 && wy == 0) { return true; }
    ////                            break;
    ////                        case red:
    ////                            if (wx == 0 && wy == MAX_ROW_AND_COLUMN - 1) { return true; }
    ////                            break;
    ////                        case yellow:
    ////                            if (wx == MAX_ROW_AND_COLUMN - 1 && wy == MAX_ROW_AND_COLUMN - 1) { return true; }
    ////                            break;
    ////                        case blue:
    ////                            if (wx == MAX_ROW_AND_COLUMN - 1 && wy == 0) { return true; }
    ////                            break;
    ////                    }
    ////                }
    ////            }
    ////        }
    ////    }
    ////    return false;
    ////}

    ////判断四边是否有棋子跟自身颜色一样，有就返回true
    //bool judgeOne(int new_wx, int new_wy, int new_i, int new_j, int[,] model, int color) {
    //    if (!outLine(new_wx, new_wy)) {
    //        if (modelOutLine(new_i, new_j)) {
    //            if (allChess[new_wx, new_wy] == color) {
    //                return true;
    //            }
    //        } else if (model[new_j, new_i] != 1) {
    //            if (allChess[new_wx, new_wy] == color) {
    //                return true;
    //            }
    //        }
    //    }
    //    return false;
    //}

    ////判断是否有一个角和自身颜色一样，有就返回true
    //bool judgeTow(int new_wx, int new_wy, int new_i, int new_j, int[,] model, int color) {
    //    if (!outLine(new_wx, new_wy)) {
    //        if (modelOutLine(new_i, new_j)) {
    //            if (allChess[new_wx, new_wy] == color) {
    //                return true;
    //            }
    //        } else if (model[new_j, new_i] != 1) {
    //            if (allChess[new_wx, new_wy] == color) {
    //                return true;
    //            }
    //        }
    //    }
    //    return false;
    //}

    ////下棋判断函数
    //bool judge(int x, int y, int[,] model, int color) {
    //    for (int j = 0; j < 5; j++) {
    //        for (int i = 0; i < 5; i++) {
    //            if (model[j, i] == 1) {
    //                int wx = x - 2 + i;
    //                int wy = y - 2 + j;
    //              //  print(wx + "++" + wy);
    //                if (outLine(wx, wy)) {
    //                 //   print("出界");
    //                    return false;
    //                }
    //                if (allChess[wx, wy] != 0) {
    //                    return false;
    //                }
    //                if (allChess[wx, wy] == 0) {
    //                    if (judgeOne(wx + 1, wy, i + 1, j, model, color)) {
    //                        return false;
    //                    }
    //                    if (judgeOne(wx, wy - 1, i, j - 1, model, color)) {
    //                        return false;
    //                    }
    //                    if (judgeOne(wx, wy + 1, i, j + 1, model, color)) {
    //                        return false;
    //                    }
    //                    if (judgeOne(wx - 1, wy, i - 1, j, model, color)) {
    //                        return false;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    print("第一阶段判断成功");
    //    for (int j = 0; j < 5; j++) {
    //        for (int i = 0; i < 5; i++) {
    //            if (model[j, i] == 1) {
    //                int wx = x - 2 + i;
    //                int wy = y - 2 + j;

    //                if (judgeTow(wx + 1, wy + 1, i + 1, j + 1, model, color)) {
    //                    return true;
    //                }
    //                if (judgeTow(wx - 1, wy + 1, i - 1, j + 1, model, color)) {
    //                    return true;
    //                }
    //                if (judgeTow(wx + 1, wy - 1, i + 1, j - 1, model, color)) {
    //                    return true;
    //                }
    //                if (judgeTow(wx - 1, wy - 1, i - 1, j - 1, model, color)) {
    //                    return true;
    //                }
    //            }
    //        }
    //    }
    //    print("第二阶段判断成功");
    //    return false;
    //}

}
