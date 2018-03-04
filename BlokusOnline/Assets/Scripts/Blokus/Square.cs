using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {
    public GameObject spirit;
    public int[,] model;
    public int color;
    public int rotationFlag;
    public int symmetryFlag;
    public Square(int[,] m, GameObject g, int c) {
        spirit = g;
        model = m;
        rotationFlag = 0;
        symmetryFlag = 0;
        color = c;
    }

    int abs(int i) {
        if (i >= 0) return i;
        else return -i;
    }

    public void set(float x, float y) {
        GameObject instance = (GameObject)Instantiate(spirit, new Vector2(x, y), Quaternion.identity);
        BlokusUIController.allChess.Add(instance);
        instance.transform.Rotate(new Vector3(0, symmetryFlag * 180, -90 * rotationFlag));
    }

    public void rotationOne() {
        int[,] NewModel = new int[5, 5];   //数组旋转
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                NewModel[j, abs(4 - i)] = model[i, j];
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                model[i, j] = NewModel[i, j];

        rotationFlag++;    //图片旋转
        if (rotationFlag > 3) {
            rotationFlag = 0;
        }
    }


    public void rotationTwo() {
        int[,] NewModel = new int[5, 5];   //数组旋转
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                NewModel[abs(4 - i), j] = model[j, i];
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                model[i, j] = NewModel[i, j];

        rotationFlag++;    //图片旋转
        if (rotationFlag > 3) {
            rotationFlag = 0;
        }
    }


    public void symmetry() {
        int[,] copy = new int[5, 5];    //数组对称
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                copy[j, i] = model[j, i];
            }
        }
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                model[j, i] = copy[j, 4 - i];
            }
        }
        symmetryFlag = 1 - symmetryFlag;  //图片对称
    }
}

