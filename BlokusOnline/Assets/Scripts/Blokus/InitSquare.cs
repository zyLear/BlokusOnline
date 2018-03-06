using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSquare : MonoBehaviour
{
    const int blue = 1;//定义颜色常量
    const int green = 2;
    const int red = 3;
    const int yellow = 4;
    //static BlokusController c;
    //public static initSquares(BlokusController blokusController)
    //{
    //    // c = GameObject.Find("BlokusController").GetComponent<BlokusController>();
    //    c = blokusController;
    //    init(blokusController);
    //}


    public static void init(BlokusController c)
    {
        int[,] green1_a_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square green1_a = new Square(green1_a_m, c.green1_a_p, green);
        c.allSquare.Add("green1_a", green1_a);

        //////////////////2
        int[,] green2_a_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square green2_a = new Square(green2_a_m, c.green2_a_p, green);
        c.allSquare.Add("green2_a", green2_a);

        ////////////////3        
        int[,] green3_a_m = new int[5, 5]
        {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
        };
        Square green3_a = new Square(green3_a_m, c.green3_a_p, green);
        c.allSquare.Add("green3_a", green3_a);

        /////////////4
        int[,] green3_b_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square green3_b = new Square(green3_b_m, c.green3_b_p, green);
        c.allSquare.Add("green3_b", green3_b);

        ////////////////5
        int[,] green4_a_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 1,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square green4_a = new Square(green4_a_m, c.green4_a_p, green);
        c.allSquare.Add("green4_a", green4_a);

        ///////////6
        int[,] green4_b_m = new int[5, 5]
    {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
    };
        Square green4_b = new Square(green4_b_m, c.green4_b_p, green);
        c.allSquare.Add("green4_b", green4_b);

        ///////////////7
        int[,] green4_c_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square green4_c = new Square(green4_c_m, c.green4_c_p, green);
        c.allSquare.Add("green4_c", green4_c);

        ////////////////8
        int[,] green4_d_m = new int[5, 5]
     {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
     };
        Square green4_d = new Square(green4_d_m, c.green4_d_p, green);
        c.allSquare.Add("green4_d", green4_d);

        ////////////////9
        int[,] green4_e_m = new int[5, 5]
     {
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
     };
        Square green4_e = new Square(green4_e_m, c.green4_e_p, green);
        c.allSquare.Add("green4_e", green4_e);

        ////////////////10
        int[,] green5_a_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 1,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square green5_a = new Square(green5_a_m, c.green5_a_p, green);
        c.allSquare.Add("green5_a", green5_a);

        ////////////////////11
        int[,] green5_b_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square green5_b = new Square(green5_b_m, c.green5_b_p, green);
        c.allSquare.Add("green5_b", green5_b);

        //////////////////////12
        int[,] green5_c_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square green5_c = new Square(green5_c_m, c.green5_c_p, green);
        c.allSquare.Add("green5_c", green5_c);

        ////////////////13
        int[,] green5_d_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square green5_d = new Square(green5_d_m, c.green5_d_p, green);
        c.allSquare.Add("green5_d", green5_d);

        ////////////////14
        int[,] green5_e_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,1,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square green5_e = new Square(green5_e_m, c.green5_e_p, green);
        c.allSquare.Add("green5_e", green5_e);

        /////////////15
        int[,] green5_f_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 }
       };
        Square green5_f = new Square(green5_f_m, c.green5_f_p, green);
        c.allSquare.Add("green5_f", green5_f);

        ///////////////16
        int[,] green5_g_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,1,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square green5_g = new Square(green5_g_m, c.green5_g_p, green);
        c.allSquare.Add("green5_g", green5_g);

        ////////////////17
        int[,] green5_h_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square green5_h = new Square(green5_h_m, c.green5_h_p, green);
        c.allSquare.Add("green5_h", green5_h);

        ////////////////////18
        int[,] green5_i_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,0,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square green5_i = new Square(green5_i_m, c.green5_i_p, green);
        c.allSquare.Add("green5_i", green5_i);

        /////////////////////19
        int[,] green5_j_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,0,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square green5_j = new Square(green5_j_m, c.green5_j_p, green);
        c.allSquare.Add("green5_j", green5_j);

        ///////////////////////20
        int[,] green5_k_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square green5_k = new Square(green5_k_m, c.green5_k_p, green);
        c.allSquare.Add("green5_k", green5_k);

        ///////////////////////21
        int[,] green5_l_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 }
       };
        Square green5_l = new Square(green5_l_m, c.green5_l_p, green);
        c.allSquare.Add("green5_l", green5_l);

        //////////////////er
        /////////1
        int[,] red1_a_m = new int[5, 5]
        {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
        };
        Square red1_a = new Square(red1_a_m, c.red1_a_p, red);
        c.allSquare.Add("red1_a", red1_a);

        //////////////////2
        int[,] red2_a_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square red2_a = new Square(red2_a_m, c.red2_a_p, red);
        c.allSquare.Add("red2_a", red2_a);

        ////////////////3        
        int[,] red3_a_m = new int[5, 5]
        {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
        };
        Square red3_a = new Square(red3_a_m, c.red3_a_p, red);
        c.allSquare.Add("red3_a", red3_a);

        /////////////4
        int[,] red3_b_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square red3_b = new Square(red3_b_m, c.red3_b_p, red);
        c.allSquare.Add("red3_b", red3_b);

        ////////////////5
        int[,] red4_a_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 1,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square red4_a = new Square(red4_a_m, c.red4_a_p, red);
        c.allSquare.Add("red4_a", red4_a);

        ///////////6
        int[,] red4_b_m = new int[5, 5]
    {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
    };
        Square red4_b = new Square(red4_b_m, c.red4_b_p, red);
        c.allSquare.Add("red4_b", red4_b);

        ///////////////7
        int[,] red4_c_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square red4_c = new Square(red4_c_m, c.red4_c_p, red);
        c.allSquare.Add("red4_c", red4_c);

        ////////////////8
        int[,] red4_d_m = new int[5, 5]
     {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
     };
        Square red4_d = new Square(red4_d_m, c.red4_d_p, red);
        c.allSquare.Add("red4_d", red4_d);

        ////////////////9
        int[,] red4_e_m = new int[5, 5]
     {
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
     };
        Square red4_e = new Square(red4_e_m, c.red4_e_p, red);
        c.allSquare.Add("red4_e", red4_e);

        ////////////////10
        int[,] red5_a_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 1,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square red5_a = new Square(red5_a_m, c.red5_a_p, red);
        c.allSquare.Add("red5_a", red5_a);

        ////////////////////11
        int[,] red5_b_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square red5_b = new Square(red5_b_m, c.red5_b_p, red);
        c.allSquare.Add("red5_b", red5_b);

        //////////////////////12
        int[,] red5_c_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square red5_c = new Square(red5_c_m, c.red5_c_p, red);
        c.allSquare.Add("red5_c", red5_c);

        ////////////////13
        int[,] red5_d_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square red5_d = new Square(red5_d_m, c.red5_d_p, red);
        c.allSquare.Add("red5_d", red5_d);

        ////////////////14
        int[,] red5_e_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,1,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square red5_e = new Square(red5_e_m, c.red5_e_p, red);
        c.allSquare.Add("red5_e", red5_e);

        /////////////15
        int[,] red5_f_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 }
       };
        Square red5_f = new Square(red5_f_m, c.red5_f_p, red);
        c.allSquare.Add("red5_f", red5_f);

        ///////////////16
        int[,] red5_g_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,1,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square red5_g = new Square(red5_g_m, c.red5_g_p, red);
        c.allSquare.Add("red5_g", red5_g);

        ////////////////17
        int[,] red5_h_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square red5_h = new Square(red5_h_m, c.red5_h_p, red);
        c.allSquare.Add("red5_h", red5_h);

        ////////////////////18
        int[,] red5_i_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,0,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square red5_i = new Square(red5_i_m, c.red5_i_p, red);
        c.allSquare.Add("red5_i", red5_i);

        /////////////////////19
        int[,] red5_j_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,0,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square red5_j = new Square(red5_j_m, c.red5_j_p, red);
        c.allSquare.Add("red5_j", red5_j);

        ///////////////////////20
        int[,] red5_k_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square red5_k = new Square(red5_k_m, c.red5_k_p, red);
        c.allSquare.Add("red5_k", red5_k);

        ///////////////////////21
        int[,] red5_l_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 }
       };
        Square red5_l = new Square(red5_l_m, c.red5_l_p, red);
        c.allSquare.Add("red5_l", red5_l);

        ////////////////////////////san
        /////////1
        int[,] blue1_a_m = new int[5, 5]
        {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
        };
        Square blue1_a = new Square(blue1_a_m, c.blue1_a_p, blue);
        c.allSquare.Add("blue1_a", blue1_a);

        //////////////////2
        int[,] blue2_a_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square blue2_a = new Square(blue2_a_m, c.blue2_a_p, blue);
        c.allSquare.Add("blue2_a", blue2_a);

        ////////////////3        
        int[,] blue3_a_m = new int[5, 5]
        {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
        };
        Square blue3_a = new Square(blue3_a_m, c.blue3_a_p, blue);
        c.allSquare.Add("blue3_a", blue3_a);

        /////////////4
        int[,] blue3_b_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square blue3_b = new Square(blue3_b_m, c.blue3_b_p, blue);
        c.allSquare.Add("blue3_b", blue3_b);

        ////////////////5
        int[,] blue4_a_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 1,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square blue4_a = new Square(blue4_a_m, c.blue4_a_p, blue);
        c.allSquare.Add("blue4_a", blue4_a);

        ///////////6
        int[,] blue4_b_m = new int[5, 5]
    {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
    };
        Square blue4_b = new Square(blue4_b_m, c.blue4_b_p, blue);
        c.allSquare.Add("blue4_b", blue4_b);

        ///////////////7
        int[,] blue4_c_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square blue4_c = new Square(blue4_c_m, c.blue4_c_p, blue);
        c.allSquare.Add("blue4_c", blue4_c);

        ////////////////8
        int[,] blue4_d_m = new int[5, 5]
     {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
     };
        Square blue4_d = new Square(blue4_d_m, c.blue4_d_p, blue);
        c.allSquare.Add("blue4_d", blue4_d);

        ////////////////9
        int[,] blue4_e_m = new int[5, 5]
     {
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
     };
        Square blue4_e = new Square(blue4_e_m, c.blue4_e_p, blue);
        c.allSquare.Add("blue4_e", blue4_e);

        ////////////////10
        int[,] blue5_a_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 1,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_a = new Square(blue5_a_m, c.blue5_a_p, blue);
        c.allSquare.Add("blue5_a", blue5_a);

        ////////////////////11
        int[,] blue5_b_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_b = new Square(blue5_b_m, c.blue5_b_p, blue);
        c.allSquare.Add("blue5_b", blue5_b);

        //////////////////////12
        int[,] blue5_c_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_c = new Square(blue5_c_m, c.blue5_c_p, blue);
        c.allSquare.Add("blue5_c", blue5_c);

        ////////////////13
        int[,] blue5_d_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_d = new Square(blue5_d_m, c.blue5_d_p, blue);
        c.allSquare.Add("blue5_d", blue5_d);

        ////////////////14
        int[,] blue5_e_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,1,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_e = new Square(blue5_e_m, c.blue5_e_p, blue);
        c.allSquare.Add("blue5_e", blue5_e);

        /////////////15
        int[,] blue5_f_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_f = new Square(blue5_f_m, c.blue5_f_p, blue);
        c.allSquare.Add("blue5_f", blue5_f);

        ///////////////16
        int[,] blue5_g_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,1,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_g = new Square(blue5_g_m, c.blue5_g_p, blue);
        c.allSquare.Add("blue5_g", blue5_g);

        ////////////////17
        int[,] blue5_h_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_h = new Square(blue5_h_m, c.blue5_h_p, blue);
        c.allSquare.Add("blue5_h", blue5_h);

        ////////////////////18
        int[,] blue5_i_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,0,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_i = new Square(blue5_i_m, c.blue5_i_p, blue);
        c.allSquare.Add("blue5_i", blue5_i);

        /////////////////////19
        int[,] blue5_j_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,0,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_j = new Square(blue5_j_m, c.blue5_j_p, blue);
        c.allSquare.Add("blue5_j", blue5_j);

        ///////////////////////20
        int[,] blue5_k_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_k = new Square(blue5_k_m, c.blue5_k_p, blue);
        c.allSquare.Add("blue5_k", blue5_k);

        ///////////////////////21
        int[,] blue5_l_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 }
       };
        Square blue5_l = new Square(blue5_l_m, c.blue5_l_p, blue);
        c.allSquare.Add("blue5_l", blue5_l);

        ///////////////////////////////si
        /////////1
        int[,] yellow1_a_m = new int[5, 5]
        {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
        };
        Square yellow1_a = new Square(yellow1_a_m, c.yellow1_a_p, yellow);
        c.allSquare.Add("yellow1_a", yellow1_a);

        //////////////////2
        int[,] yellow2_a_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square yellow2_a = new Square(yellow2_a_m, c.yellow2_a_p, yellow);
        c.allSquare.Add("yellow2_a", yellow2_a);

        ////////////////3        
        int[,] yellow3_a_m = new int[5, 5]
        {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
        };
        Square yellow3_a = new Square(yellow3_a_m, c.yellow3_a_p, yellow);
        c.allSquare.Add("yellow3_a", yellow3_a);

        /////////////4
        int[,] yellow3_b_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square yellow3_b = new Square(yellow3_b_m, c.yellow3_b_p, yellow);
        c.allSquare.Add("yellow3_b", yellow3_b);

        ////////////////5
        int[,] yellow4_a_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 1,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square yellow4_a = new Square(yellow4_a_m, c.yellow4_a_p, yellow);
        c.allSquare.Add("yellow4_a", yellow4_a);

        ///////////6
        int[,] yellow4_b_m = new int[5, 5]
    {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
    };
        Square yellow4_b = new Square(yellow4_b_m, c.yellow4_b_p, yellow);
        c.allSquare.Add("yellow4_b", yellow4_b);

        ///////////////7
        int[,] yellow4_c_m = new int[5, 5]
      {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
      };
        Square yellow4_c = new Square(yellow4_c_m, c.yellow4_c_p, yellow);
        c.allSquare.Add("yellow4_c", yellow4_c);

        ////////////////8
        int[,] yellow4_d_m = new int[5, 5]
     {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
     };
        Square yellow4_d = new Square(yellow4_d_m, c.yellow4_d_p, yellow);
        c.allSquare.Add("yellow4_d", yellow4_d);

        ////////////////9
        int[,] yellow4_e_m = new int[5, 5]
     {
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
     };
        Square yellow4_e = new Square(yellow4_e_m, c.yellow4_e_p, yellow);
        c.allSquare.Add("yellow4_e", yellow4_e);

        ////////////////10
        int[,] yellow5_a_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,0,0 },
           { 1,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_a = new Square(yellow5_a_m, c.yellow5_a_p, yellow);
        c.allSquare.Add("yellow5_a", yellow5_a);

        ////////////////////11
        int[,] yellow5_b_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_b = new Square(yellow5_b_m, c.yellow5_b_p, yellow);
        c.allSquare.Add("yellow5_b", yellow5_b);

        //////////////////////12
        int[,] yellow5_c_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_c = new Square(yellow5_c_m, c.yellow5_c_p, yellow);
        c.allSquare.Add("yellow5_c", yellow5_c);

        ////////////////13
        int[,] yellow5_d_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_d = new Square(yellow5_d_m, c.yellow5_d_p, yellow);
        c.allSquare.Add("yellow5_d", yellow5_d);

        ////////////////14
        int[,] yellow5_e_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,0,1,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_e = new Square(yellow5_e_m, c.yellow5_e_p, yellow);
        c.allSquare.Add("yellow5_e", yellow5_e);

        /////////////15
        int[,] yellow5_f_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_f = new Square(yellow5_f_m, c.yellow5_f_p, yellow);
        c.allSquare.Add("yellow5_f", yellow5_f);

        ///////////////16
        int[,] yellow5_g_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,1,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_g = new Square(yellow5_g_m, c.yellow5_g_p, yellow);
        c.allSquare.Add("yellow5_g", yellow5_g);

        ////////////////17
        int[,] yellow5_h_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,0,1,1,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_h = new Square(yellow5_h_m, c.yellow5_h_p, yellow);
        c.allSquare.Add("yellow5_h", yellow5_h);

        ////////////////////18
        int[,] yellow5_i_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,1,0 },
           { 0,0,1,0,0 },
           { 0,1,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_i = new Square(yellow5_i_m, c.yellow5_i_p, yellow);
        c.allSquare.Add("yellow5_i", yellow5_i);

        /////////////////////19
        int[,] yellow5_j_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,1,0,0 },
           { 0,0,1,1,1 },
           { 0,0,0,0,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_j = new Square(yellow5_j_m, c.yellow5_j_p, yellow);
        c.allSquare.Add("yellow5_j", yellow5_j);

        ///////////////////////20
        int[,] yellow5_k_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,0,1,0,0 },
           { 0,1,1,1,0 },
           { 0,0,1,0,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_k = new Square(yellow5_k_m, c.yellow5_k_p, yellow);
        c.allSquare.Add("yellow5_k", yellow5_k);

        ///////////////////////21
        int[,] yellow5_l_m = new int[5, 5]
       {
           { 0,0,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,0,0,0 },
           { 0,1,1,1,0 },
           { 0,0,0,0,0 }
       };
        Square yellow5_l = new Square(yellow5_l_m, c.yellow5_l_p, yellow);
        c.allSquare.Add("yellow5_l", yellow5_l);
    }
}
