using protos.blokus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class MessageFormater {

    public static MessageBean createRoom(string roomName, int roomType) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CREATE_ROOM;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSCreateRoom bLOKUSCreateRoom = new BLOKUSCreateRoom();
        bLOKUSCreateRoom.roomName = roomName;
        bLOKUSCreateRoom.roomType = roomType;

        message.data = ProtobufHelper.SerializerToBytes(bLOKUSCreateRoom);
        return message;
    }

    public static MessageBean chooseColor(string account, string roomName, int color) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CHOOSE_COLOR;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSChooseColor bLOKUSChooseColor = new BLOKUSChooseColor();
        bLOKUSChooseColor.account = account;
        bLOKUSChooseColor.roomName = roomName;
        bLOKUSChooseColor.color = color;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSChooseColor);
        return message;
    }

    internal static MessageBean formatLoginMessage(string accountText, string password) {
        BLOKUSAccount account = new BLOKUSAccount();
        account.account = accountText;
        account.password = password;

        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.LOGIN;
        message.statusCode = StatusCode.SUCCESS;
        message.data = ProtobufHelper.SerializerToBytes(account);
        return message;
    }

    public static MessageBean formatLeaveRoomMessage() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.LEAVE_ROOM;
        message.statusCode = StatusCode.SUCCESS;
        return message;
    }

    public static MessageBean formatReadyMessage(string account, string roomName) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.READY;
        message.statusCode = StatusCode.SUCCESS;

        //BLOKUSChooseColor bLOKUSChooseColor = new BLOKUSChooseColor();
        //bLOKUSChooseColor.account = account;
        //bLOKUSChooseColor.roomName = roomName;
        //message.data = ProtobufHelper.SerializerToBytes(bLOKUSChooseColor);
        return message;
    }

    internal static MessageBean formatWinMessage() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.WIN;
        message.statusCode = StatusCode.SUCCESS;
        return message;
    }

    public static MessageBean formatJoinRoomMessage(string roomName) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.JOIN_ROOM;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSRoomName bLOKUSRoomName = new BLOKUSRoomName();
        bLOKUSRoomName.roomName = roomName;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSRoomName);
        return message;
    }

    internal static MessageBean formatFailMessage() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.FAIL;
        message.statusCode = StatusCode.SUCCESS;
        return message;
    }

    internal static MessageBean formatChessDoneMessage(int x, int y, string currentSquareName, int rotationFlag, int symmetryFlag, int[,] model) {

        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CHESS_DONE;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSChessDoneInfo chessDoneInfo = new BLOKUSChessDoneInfo();
        chessDoneInfo.x = x;
        chessDoneInfo.y = y;
        chessDoneInfo.squareName = currentSquareName;
        chessDoneInfo.rotationFlag = rotationFlag;
        chessDoneInfo.symmetryFlag = symmetryFlag;
        chessDoneInfo.model = getModelBytes(model);
        message.data = ProtobufHelper.SerializerToBytes(chessDoneInfo);
        return message;
    }

    internal static MessageBean formatGiveUpMessage(int myColor) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.GIVE_UP;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSChooseColor bLOKUSChooseColor = new BLOKUSChooseColor();
        bLOKUSChooseColor.color = myColor;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSChooseColor);
        return message;
    }

    private static byte[] getModelBytes(int[,] model) {
        byte[] modelBytes = new byte[25];

        for (int i = 0; i < 25; i++) {
            modelBytes[i] = (byte)model[i / 5, i % 5];
        }

        return modelBytes;
        //for (int j = 0; j < 5; j++) {
        //    for (int i = 0; i < 5; i++) {
        //        if (model[j, i] == 1) {
        //            int wx = x - 2 + i;
        //            int wy = y - 2 + j;
        //            modelBytes[wx, wy]=
        //        }
        //    }
        //}
    }


}

