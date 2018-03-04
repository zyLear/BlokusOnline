using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Color {
    public const int BLUE = 1;//定义颜色常量
    public const int GREEN = 2;
    public const int RED = 3;
    public const int YELLOW = 4;

    public static string getColorText(int color) {
        switch (color) {
            case BLUE: return "blue";
            case GREEN: return "green";
            case RED: return "red";
            case YELLOW: return "yellow";
            default: return "blue";
        }
    }

    
}
