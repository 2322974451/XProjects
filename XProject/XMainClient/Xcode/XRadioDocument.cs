

using KKSG;
using System;
using System.Collections.Generic;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XRadioDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash(nameof(XRadioDocument));
        public List<string> hostlist = new List<string>();
        public List<ulong> hostIDs = new List<ulong>();
        private bool mJoinBigRoomSucc = false;
        public bool isHost = false;
        public XRadioDocument.BigRoomState roomState = XRadioDocument.BigRoomState.OutRoom;
        private bool startLoop = false;
        private float acc_time = 0.0f;
        private float all_time = 0.0f;
        private int TimeOut = 8;
        private bool cacheRadioOpen = false;

        public override uint ID => XRadioDocument.uuID;

        protected override void OnReconnected(XReconnectedEventArgs arg)
        {
        }

        public override void Update(float fDeltaT)
        {
            base.Update(fDeltaT);
            if (!this.startLoop)
                return;
            this.acc_time += fDeltaT;
            this.all_time += fDeltaT;
            if ((double)this.all_time > (double)this.TimeOut && !this.mJoinBigRoomSucc)
            {
                this.startLoop = false;
                this.mJoinBigRoomSucc = false;
                this.roomState = XRadioDocument.BigRoomState.OutRoom;
                DlgBase<RadioDlg, RadioBehaviour>.singleton.Refresh(false);
                XSingleton<XDebug>.singleton.AddGreenLog("join room timeout, Apollo error!");
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("FM_ENTER_OVERTIME"), "fece00");
            }
            if ((double)this.acc_time > 0.400000005960464)
            {
                if (!this.mJoinBigRoomSucc)
                {
                    IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
                    if (xapolloManager.GetJoinRoomBigResult())
                    {
                        this.startLoop = false;
                        this.mJoinBigRoomSucc = true;
                        xapolloManager.openMusic = true;
                        xapolloManager.openSpeak = false;
                        this.roomState = XRadioDocument.BigRoomState.InRoom;
                        this.MuteSounds(false);
                        DlgBase<RadioDlg, RadioBehaviour>.singleton.Refresh(true);
                        DlgBase<RadioDlg, RadioBehaviour>.singleton.UpdateHostInfo();
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FM_ENTER_SUCCESS"), "fece00");
                        XSingleton<XChatIFlyMgr>.singleton.StopAutoPlay();
                        XSingleton<XChatIFlyMgr>.singleton.EnableAutoPlay(false);
                    }
                }
                this.acc_time = 0.0f;
            }
        }

        public override void OnDetachFromHost()
        {
            this.cacheRadioOpen = false;
            this.QuitApolloBigRoom();
            base.OnDetachFromHost();
        }

        public override void OnEnterScene()
        {
            base.OnEnterScene();
            if (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World)
            {
                if (XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID).GetBattleRaw().real <= 0)
                    return;
                if (this.roomState == XRadioDocument.BigRoomState.InRoom)
                    this.cacheRadioOpen = true;
                this.QuitBigRoom();
            }
            else
            {
                if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall || !this.cacheRadioOpen || this.roomState != XRadioDocument.BigRoomState.OutRoom)
                    return;
                this.JoinBigRoom();
                this.cacheRadioOpen = false;
            }
        }

        public void UpdateHost(List<string> names, List<ulong> roles)
        {
            if (names != null)
            {
                this.hostlist = names;
                this.hostIDs = roles;
            }
            if (!DlgBase<RadioDlg, RadioBehaviour>.singleton.IsVisible())
                return;
            DlgBase<RadioDlg, RadioBehaviour>.singleton.UpdateHostInfo();
        }

        public void MuteSounds(bool mute)
        {
            if (this.roomState != XRadioDocument.BigRoomState.InRoom)
                return;
            IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
            if (mute)
            {
                xapolloManager.SetMusicVolum(0);
            }
            else
            {
                XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
                int num = XSingleton<XGlobalConfig>.singleton.GetInt("SetSpeakerVolume");
                xapolloManager.SetMusicVolum((int)((double)num * (double)specificDocument.voiceVolme));
            }
        }

        public void JoinBigRoom()
        {
            if (this.mJoinBigRoomSucc || this.startLoop)
                return;
            this.roomState = XRadioDocument.BigRoomState.Processing;
            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FM_ENTERING"), "fece00");
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_JoinFmRoom());
        }

        public void ProcessJoinBigRoom(JoinLargeRoomReply reply)
        {
            this.acc_time = 0.0f;
            this.all_time = 0.0f;
            this.startLoop = true;
            this.mJoinBigRoomSucc = false;
            XSingleton<XDebug>.singleton.AddLog("url:", reply.url, " bussinessid:" + (object)reply.bussniessid, " role:" + (object)reply.key);
            XDebug singleton = XSingleton<XDebug>.singleton;
            ulong num = reply.roomid;
            string log2 = num.ToString();
            num = reply.roomkey;
            string log4 = num.ToString();
            singleton.AddLog("roomid: ", log2, " roomkey:", log4);
            IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
            xapolloManager.SetRealtimeMode();
            xapolloManager.JoinBigRoom(reply.url, (int)reply.key, reply.bussniessid, (long)reply.roomid, (long)reply.roomkey, (short)reply.memberid);
        }

        public void ProcessTimeOut()
        {
            this.mJoinBigRoomSucc = false;
            this.roomState = XRadioDocument.BigRoomState.OutRoom;
            DlgBase<RadioDlg, RadioBehaviour>.singleton.Refresh(false);
        }

        public void QuitBigRoom()
        {
            this.QuitApolloBigRoom();
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2M_LeaveLargeRoom());
        }

        private void QuitApolloBigRoom()
        {
            try
            {
                this.startLoop = false;
                this.mJoinBigRoomSucc = false;
                if (this.roomState == XRadioDocument.BigRoomState.InRoom)
                {
                    IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
                    if (xapolloManager != null)
                    {
                        xapolloManager.openSpeak = false;
                        xapolloManager.QuitBigRoom();
                    }
                }
                this.roomState = XRadioDocument.BigRoomState.OutRoom;
                if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall)
                    return;
                XSingleton<XChatIFlyMgr>.singleton.EnableAutoPlay(true);
                XSingleton<XChatIFlyMgr>.singleton.StartAutoPlay();
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddLog(ex.StackTrace.ToString());
            }
        }

        public bool isHosting()
        {
            IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
            return this.roomState != XRadioDocument.BigRoomState.OutRoom && this.isHost && xapolloManager.openSpeak;
        }

        public enum BigRoomState
        {
            OutRoom,
            Processing,
            InRoom,
        }
    }
}
