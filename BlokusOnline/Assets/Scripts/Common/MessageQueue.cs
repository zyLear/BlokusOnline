using System;
using System.Collections.Generic;


class MessageQueue {

    public static Queue<MessageBean> Instance = new Queue<MessageBean>();

    public static void put(List<MessageBean> messages) {

        if (messages != null) {
            foreach (MessageBean message in messages) {
                Instance.Enqueue(message);
            }
        }
    }

    public static MessageBean take() {
        try {
            return Instance.Dequeue();
        } catch {
            return null;
        }
    }

}

