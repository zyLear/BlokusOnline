using protos.blokus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class SendMessageHelper {

    public static MessageBean createRoom(string roomName) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CREATE_ROOM;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSRoomName bLOKUSRoomName = new BLOKUSRoomName();
        bLOKUSRoomName.roomName = roomName;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSRoomName);
        return message;
    }

}

