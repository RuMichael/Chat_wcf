﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chat
{

    [ServiceContract(CallbackContract = typeof(IServerChatCallBack))]
    public interface IServiceChat
    {
        [OperationContract]

        int Connect(string name);

        [OperationContract]

        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]

        void SendMsg(string msg);
    }

    public interface IServerChatCallBack
    {
        void CallBackMsg(string msg);
    }

}
