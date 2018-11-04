using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chat
{
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]

    public class ServiceChat : IServiceChat
    {

        List<ServerUser> users = new List<ServerUser>();
        int nextID = 1;


        public int Connect(string name)
        {
            ServerUser user = new ServerUser { ID = nextID, Name = name, operationContext = OperationContext.Current };
            nextID++;
            SendMsg(user.Name + " подключился к чату!");
            users.Add(user);
            return user.ID;

        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(item=>item.ID==id);
            if (user != null) 
            {
                users.Remove(user);
                SendMsg(user.Name + " покинул чат!");
            }
        }

        public void SendMsg(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
