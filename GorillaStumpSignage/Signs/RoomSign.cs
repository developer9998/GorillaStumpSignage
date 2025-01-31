using System;
using System.Collections.Generic;
using System.Text;
using GorillaStumpSignage.Behaviours;
using Photon.Realtime;
using UnityEngine.UI;

namespace GorillaStumpSignage.Signs
{
    public class RoomSign : Sign, IMatchmakingCallbacks
    {
        private StringBuilder stringBuilder = new();

        private Text txtRoom, txtBody;

        private const short gameFullCode = 32765;

        public override void Initialize()
        {
            txtRoom = Canvas.Find("RoomLabel").GetComponent<Text>();
            txtBody = Canvas.Find("BodyLabel").GetComponent<Text>();
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            var state = NetworkSystem.Instance.netState;
        }

        public void OnCreatedRoom()
        {
            
        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {
            
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
            
        }

        public void OnJoinedRoom()
        {
            
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
            
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
            
        }

        public void OnLeftRoom()
        {
            
        }

        public void OnPreLeavingRoom()
        {
            
        }
    }
}
