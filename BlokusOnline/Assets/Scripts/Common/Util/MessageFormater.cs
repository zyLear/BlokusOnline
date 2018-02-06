using protos.blokus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class MessageFormater {

    public static MessageBean createRoom(string roomName) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CREATE_ROOM;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSRoomName bLOKUSRoomName = new BLOKUSRoomName();
        bLOKUSRoomName.roomName = roomName;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSRoomName);
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

        BLOKUSChooseColor bLOKUSChooseColor = new BLOKUSChooseColor();
        bLOKUSChooseColor.account = account;
        bLOKUSChooseColor.roomName = roomName;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSChooseColor);
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
}

