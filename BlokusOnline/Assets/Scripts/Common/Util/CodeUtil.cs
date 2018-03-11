

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

class CodeUtil {

    private static int tempLength = 0;
    private static byte[] tempData = null; //deal stick
    private static readonly List<MessageBean> emptyList = new List<MessageBean>();


    public static List<MessageBean> decode(byte[] data, int totalLength) {

        Debug.Log("total length:" + totalLength);

        //for (int i = 0; i < totalLength; i++) {
        //    Debug.Log(i + "  bbbbbbbb:    " + data[i]);
        //}

        List<MessageBean> messages = new List<MessageBean>();
        int index = 0;


        //index point to data next start position
        while (index < totalLength) {

            if (tempLength != 0 && tempData != null) {
                byte[] temp = new byte[totalLength + tempLength];
                Array.Copy(tempData, 0, temp, 0, tempLength);
                Array.Copy(data, 0, temp, tempLength, totalLength);
                data = temp;
                totalLength += tempLength;
                tempLength = 0;
                tempData = null;
            }


            if (totalLength < 8) {
                Debug.Log("head less 8 bytes!");
                tempLength = totalLength;
                tempData = new byte[totalLength];
                Array.Copy(data, index, tempData, 0, totalLength);
                return messages;
            }

            int length = readInt(data, 0 + index);

            if (totalLength < length + 8) {
                Debug.Log("total length less 8+length!");
                tempLength = totalLength;
                tempData = new byte[totalLength];
                Array.Copy(data, index, tempData, 0, totalLength);
                return messages;
            }

            MessageBean message = new MessageBean();
            message.operationCode = readShort(data, 4 + index);
            message.statusCode = readShort(data, 6 + index);
            message.data = readBytes(data, 8 + index, length);
            messages.Add(message);
            index += (8 + length);
            totalLength -= (8 + length);
            Debug.Log("index :" + index);
        }
        return messages;
    }

    //private static MessageBean readMessage(byte[] data, int totalLength) {
    //    if (totalLength < 8) {
    //        Debug.Log("head less 8 bytes!");
    //        return null;
    //    }

    //    int length = readInt(data, 0);

    //    if (totalLength < length + 8) {
    //        Debug.Log("total length less 8+length!");
    //        return null;
    //    }

    //    MessageBean message = new MessageBean();
    //    message.operationCode = readShort(data, 4);
    //    message.statusCode = readShort(data, 6);
    //    message.data = readBytes(data, 8, length);

    //    byte[] temp = new byte[totalLength - 8 - length];
    //    temp = readBytes(data, 8 + length, totalLength - 8 - length);

    //    return null;
    //}


    private static int readInt(byte[] data, int startIndex) {

        byte[] temp = new byte[4];
        Array.Copy(data, startIndex, temp, 0, 4);
        Array.Reverse(temp);
        return BitConverter.ToInt32(temp, 0);
    }

    private static short readShort(byte[] data, int startIndex) {
        byte[] temp = new byte[2];
        Array.Copy(data, startIndex, temp, 0, 2);
        Array.Reverse(temp);
        return BitConverter.ToInt16(temp, 0);
    }

    private static byte[] readBytes(byte[] data, int startIndex, int length) {
        byte[] temp = new byte[length];
        Array.Copy(data, startIndex, temp, 0, length);
        return temp;
    }


    public static byte[] encode(MessageBean message) {

        int length = 0;
        if (message.data != null) {
            length = message.data.Length;
            Debug.Log("chang::" + length);
        }
        List<byte> byteList = new List<byte>();


        //foreach (byte b in BitConverter.GetBytes(length)) {
        //    Debug.Log("qian     " + b);
        //}

        //Debug.Log("length chang::" + BitConverter.GetBytes(length).Length);


        byte[] temp = BitConverter.GetBytes(length);
        Array.Reverse(temp);
        byteList.AddRange(temp);

        temp = BitConverter.GetBytes(message.operationCode);
        Array.Reverse(temp);
        byteList.AddRange(temp);


        temp = BitConverter.GetBytes(message.statusCode);
        Array.Reverse(temp);
        byteList.AddRange(temp);
        if (length != 0) {
            byteList.AddRange(message.data);
        }
        //Debug.Log("list chang::" + byteList.ToArray().Length);
        //byte[] data = new byte[8 + length];
        //int i = 0;
        //foreach (byte b in byteList.ToArray()) {
        //    Debug.Log(b);

        //    data[i] = b;
        //    i++;
        //}

        //Debug.Log("i" + i);


        return byteList.ToArray();

    }


}

