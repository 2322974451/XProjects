

using KKSG;
using System;
using System.Collections.Generic;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XChatDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash(nameof(XChatDocument));
        private XChatView _XChatView = (XChatView)null;
        private XChatSmallView _XChatSmallView = (XChatSmallView)null;
        private XChatSettingView _XChatSettingView = (XChatSettingView)null;
        private XChatMaqueeView _XChatMaqueeView = (XChatMaqueeView)null;
        private DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        public List<ChatFriendData> ChatFriendList = new List<ChatFriendData>();
        private static Dictionary<ChatChannelType, List<ChatInfo>> m_ChatDic = new Dictionary<ChatChannelType, List<ChatInfo>>();
        private const int CHAT_MEMORY_COUNT = 200;
        private static List<ChatInfo> m_ChatSmallList = new List<ChatInfo>();
        private static List<ChatInfo> m_ProcessListSmall = new List<ChatInfo>();
        public static List<ChatInfo> offlineProcessList = new List<ChatInfo>();
        public List<string> recentSendmsg = new List<string>();
        public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
        public static byte[] m_ApolloKey = new byte[1024];
        public static int[] m_ApolloIPtable = new int[4];
        public static bool m_ApolloInited = false;
        public static string m_ClientIP = "127.0.0.1";
        public static int CLEAR_ENTER_AUDIO_COUNT = 5;
        public static bool is_delete_audio = true;
        public static bool m_AnswerUseApollo = true;
        public static bool UseApollo = true;
        public int getFlowerLeftTime;
        public bool canGetFlower;
        private string color_r1;
        private string color_r2;
        private string color_g;
        private string color_n;
        private string color_dg;
        private static ChatTable _chatTable = new ChatTable();
        private static ChatOpen _chatOpenTabel = new ChatOpen();
        public static ChatApollo _chatApolloTable = new ChatApollo();
        private static bool[] s_commonIcons = new bool[15];
        private bool firstIn = true;
        private const int MAX_RECNET_COUNT = 10;
        private const int MAX_OFFLINE_COUNT = 10;
        private Dictionary<int, ChatOpen.RowData> openTable = new Dictionary<int, ChatOpen.RowData>();
        private Dictionary<uint, ChatOpen.RowData> sOpenTbale = new Dictionary<uint, ChatOpen.RowData>();
        private XGuildDocument guildDoc;
        private XTeamDocument teamDoc;

        public override uint ID => XChatDocument.uuID;

        public XChatView ChatView
        {
            get => DlgBase<XChatView, XChatBehaviour>.singleton;
            set => this._XChatView = value;
        }

        public XChatSmallView ChatSmallView
        {
            get => this._XChatSmallView;
            set => this._XChatSmallView = value;
        }

        public XChatSettingView ChatSettingView
        {
            get => this._XChatSettingView;
            set => this._XChatSettingView = value;
        }

        public XChatMaqueeView ChatMaqueeView
        {
            get => this._XChatMaqueeView;
            set => this._XChatMaqueeView = value;
        }

        public bool onlyDisplayTeamChannel
        {
            get
            {
                XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
                return specificDocument == null || (uint)specificDocument.GetValue(XOptionsDefine.OD_Shield_NoTeam_Chat) > 0U;
            }
        }

        public static void Execute(OnLoadedCallback callback = null)
        {
            XChatDocument.AsyncLoader.AddTask("Table/Chat", (CVSReader)XChatDocument._chatTable);
            XChatDocument.AsyncLoader.AddTask("Table/ChatOpen", (CVSReader)XChatDocument._chatOpenTabel);
            XChatDocument.AsyncLoader.AddTask("Table/ChatApollo", (CVSReader)XChatDocument._chatApolloTable);
            XChatDocument.AsyncLoader.Execute(callback);
        }

        public ChatTable.RowData GetRawData(ChatChannelType type)
        {
            int num = XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(type);
            for (int index = 0; index < XChatDocument._chatTable.Table.Length; ++index)
            {
                if ((long)XChatDocument._chatTable.Table[index].id == (long)num)
                    return XChatDocument._chatTable.Table[index];
            }
            return XChatDocument._chatTable.Table[0];
        }

        public ChatApollo.RowData GetApollo(int speak, int music, int click)
        {
            int num = 100 * speak + 10 * music + click;
            for (int index = 0; index < XChatDocument._chatApolloTable.Table.Length; ++index)
            {
                ChatApollo.RowData rowData = XChatDocument._chatApolloTable.Table[index];
                if (100 * rowData.speak + 10 * rowData.music + rowData.click == num)
                    return rowData;
            }
            return (ChatApollo.RowData)null;
        }

        protected override void EventSubscribe() => base.EventSubscribe();

        public override void OnEnterSceneFinally()
        {
            base.OnEnterSceneFinally();
            DlgBase<XChatView, XChatBehaviour>.singleton.cacheShow = false;
            if (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall)
                XSingleton<XChatIFlyMgr>.singleton.EnableAutoPlay(true);
            if (this.recentSendmsg.Count <= 0)
                this.recentSendmsg = XSingleton<XGlobalConfig>.singleton.GetStringList("ChatArray");
            if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall)
                return;
            if (!XChatDocument.m_ApolloInited)
                XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_QueryClientIp());
            DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.CheckShow();
            XChatDocument.m_AnswerUseApollo = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("UseApollo")) == 1;
            DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(true);
        }

        public override void OnGamePause(bool pause)
        {
            base.OnGamePause(pause);
            DlgBase<BarrageDlg, BarrageBehaviour>.singleton.OnFouceGame(pause);
            if (!pause)
                DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.ResumeReplay();
            DlgBase<WebView, WebViewBehaviour>.singleton.OnScreenLock(pause);
        }

        public override void OnLeaveScene()
        {
            base.OnLeaveScene();
            if (DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible())
                DlgBase<XChatView, XChatBehaviour>.singleton.SetVisibleWithAnimation(false, (DlgBase<XChatView, XChatBehaviour>.OnAnimationOver)null);
            XSingleton<XChatIFlyMgr>.singleton.OnCloseWebView();
        }

        protected override void OnReconnected(XReconnectedEventArgs arg)
        {
        }

        public override void PostUpdate(float fDeltaT)
        {
            if (this.ChatMaqueeView == null)
                return;
            this.ChatMaqueeView.UpdateMaquee(fDeltaT);
        }

        public override void Update(float fDeltaT)
        {
            if (XChatDocument.m_ProcessListSmall.Count <= 0)
                return;
            for (int index = 0; index < XChatDocument.m_ProcessListSmall.Count; ++index)
                this.AddSmallChatInfo(XChatDocument.m_ProcessListSmall[index]);
            DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.OnReceieveChatInfos(XChatDocument.m_ProcessListSmall);
            XChatDocument.m_ProcessListSmall.Clear();
        }

        private void HanderSereverChatinfo(KKSG.ChatInfo info)
        {
            if (info == null)
                return;
            if (info.source != null)
            {
                if (DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsBlock(info.source.roleid))
                    return;
                this.HandlerReceiveChatInfo(info);
            }
            else if (info != null && XSingleton<XAttributeMgr>.singleton.XPlayerData != null && info.level <= XSingleton<XAttributeMgr>.singleton.XPlayerData.Level)
                this.HandlerReceiveChatInfo(info);
        }

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            PlayerPrefs.SetInt("BroadcastOpen", XSingleton<XGlobalConfig>.singleton.GetInt("BroadcastOpen"));
            XChatDocument.is_delete_audio = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("IsDeleteAudio")) == 1;
            this.color_r1 = XSingleton<XGlobalConfig>.singleton.GetValue("Chat_R1");
            this.color_r2 = XSingleton<XGlobalConfig>.singleton.GetValue("Chat_R2");
            this.color_g = XSingleton<XGlobalConfig>.singleton.GetValue("Chat_G");
            this.color_n = XSingleton<XGlobalConfig>.singleton.GetValue("Chat_N");
            this.color_dg = XSingleton<XGlobalConfig>.singleton.GetValue("Chat_DG");
        }

        public override void OnDetachFromHost()
        {
            this.OnClearAllData();
            this.firstIn = true;
            DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.StopBroad();
            DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.OnStopClick((IXUIButton)null);
        }

        public void SendOfflineMsg()
        {
            if (!this.firstIn)
                return;
            this.ClearAllData();
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2M_LoadOfflineChatNtf()
            {
                Data = {
          roleID = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID
        }
            });
            this.firstIn = false;
        }

        public void ClearRoleMsg(ulong roleid)
        {
            List<ChatInfo> list1;
            XChatDocument.m_ChatDic.TryGetValue(ChatChannelType.World, out list1);
            List<ChatInfo> list2;
            XChatDocument.m_ChatDic.TryGetValue(ChatChannelType.Guild, out list2);
            List<ChatInfo> list3;
            XChatDocument.m_ChatDic.TryGetValue(ChatChannelType.Team, out list3);
            List<ChatInfo> list4;
            XChatDocument.m_ChatDic.TryGetValue(ChatChannelType.Spectate, out list4);
            List<ChatInfo> list5;
            XChatDocument.m_ChatDic.TryGetValue(ChatChannelType.Friends, out list5);
            if (list1 != null)
                this.RemveRoleMsg(roleid, list1);
            if (list2 != null)
                this.RemveRoleMsg(roleid, list2);
            if (list3 != null)
                this.RemveRoleMsg(roleid, list3);
            if (list4 != null)
                this.RemveRoleMsg(roleid, list4);
            if (list5 != null)
                this.RemveRoleMsg(roleid, list5);
            if (XChatDocument.offlineProcessList != null)
                this.RemveRoleMsg(roleid, XChatDocument.offlineProcessList);
            if (XChatDocument.m_ChatSmallList != null)
                this.RemveRoleMsg(roleid, XChatDocument.m_ChatSmallList);
            if (XChatDocument.m_ProcessListSmall != null)
                this.RemveRoleMsg(roleid, XChatDocument.m_ProcessListSmall);
            this.ChatView.RefreshLoopScroll(this.ChatView.activeChannelType);
            if (!this.ChatSmallView.IsVisible())
                return;
            this.ChatSmallView.ShowCacheMsg();
        }

        private void RemveRoleMsg(ulong roleid, List<ChatInfo> list)
        {
            if (list == null)
                return;
            for (int index = list.Count - 1; index >= 0; --index)
            {
                if ((long)list[index].mSenderId == (long)roleid)
                    list.RemoveAt(index);
            }
        }

        public void ReceiveOfflineMsg(PtcM2C_MCChatOffLineNotify roPtc)
        {
            DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.CacheMsg();
            List<KKSG.ChatInfo> chatInfoList = new List<KKSG.ChatInfo>();
            if (DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.IsInited)
                return;
            for (int index = 0; index < roPtc.Data.rolechat.Count; ++index)
                chatInfoList.Add(roPtc.Data.rolechat[index]);
            for (int index = 0; index < roPtc.Data.guildchat.Count; ++index)
                chatInfoList.Add(roPtc.Data.guildchat[index]);
            for (int index = 0; index < roPtc.Data.teamchat.Count; ++index)
                chatInfoList.Add(roPtc.Data.teamchat[index]);
            for (int index = 0; index < roPtc.Data.worldchat.Count; ++index)
                chatInfoList.Add(roPtc.Data.worldchat[index]);
            for (int index = 0; index < roPtc.Data.partnerchat.Count; ++index)
                chatInfoList.Add(roPtc.Data.partnerchat[index]);
            for (int index = 0; index < roPtc.Data.groupchat.Count; ++index)
                chatInfoList.Add(roPtc.Data.groupchat[index]);
            chatInfoList.Sort(new Comparison<KKSG.ChatInfo>(this.SortOfflineData));
            for (int index = 0; index < chatInfoList.Count; ++index)
                this.HanderSereverChatinfo(chatInfoList[index]);
            this.HandlerOfflineFriend(roPtc.Data.privatechatlist);
        }

        private int SortOfflineData(KKSG.ChatInfo x, KKSG.ChatInfo y) => x.time.CompareTo(y.time);

        public void OnReceiveChatInfo(KKSG.ChatInfo info) => this.HanderSereverChatinfo(info);

        private ChatFriendData Chatinfo2FriendData(ChatSource friend, uint time) => new ChatFriendData()
        {
            isfriend = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(friend.roleid),
            name = friend.name,
            powerpoint = friend.powerpoint,
            profession = friend.profession,
            viplevel = friend.viplevel,
            roleid = friend.roleid,
            setid = friend.pre != null ? friend.pre.setid : new List<uint>(),
            msgtime = this.startTime.AddSeconds((double)time)
        };

        private void HandlerOfflineFriend(PrivateChatList friends)
        {
            if (friends != null && friends.rolelist != null)
            {
                for (int index = 0; index < friends.rolelist.Count; ++index)
                {
                    ChatFriendData chatFriendData1 = new ChatFriendData();
                    XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
                    if (friends.rolelist[index] != null && xplayerData != null && (long)friends.rolelist[index].roleid != (long)xplayerData.RoleID)
                    {
                        ChatFriendData chatFriendData2 = this.Chatinfo2FriendData(friends.rolelist[index], friends.lastChatTime[index]);
                        chatFriendData2.hasOfflineRead = friends.hasOfflineChat[index];
                        this.ChatFriendList.Add(chatFriendData2);
                    }
                }
            }
            this.RemoveBlockFriends();
        }

        public void SetFriendRelation(ulong uid, bool isfriend)
        {
            for (int index = 0; index < this.ChatFriendList.Count; ++index)
            {
                if ((long)this.ChatFriendList[index].roleid == (long)uid)
                {
                    this.ChatFriendList[index].isfriend = isfriend;
                    break;
                }
            }
        }

        public void OnReceiveChatSmallInfo(ChatInfo info)
        {
            if (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && this.onlyDisplayTeamChannel && info.mChannelId != ChatChannelType.Team && info.mChannelId != ChatChannelType.Curr && info.mChannelId != ChatChannelType.Battle)
                return;
            XChatDocument.m_ProcessListSmall.Add(info);
        }

        private void CacheRecentSendmsg(string str)
        {
            if (this.recentSendmsg.Contains(str))
                return;
            if (this.recentSendmsg.Count > 10)
                this.recentSendmsg.RemoveAt(0);
            this.recentSendmsg.Add(str);
        }

        private void CacheRecentChatinfo(ChatInfo info)
        {
            if (XChatDocument.offlineProcessList.Count > 10)
                XChatDocument.offlineProcessList.RemoveRange(0, XChatDocument.offlineProcessList.Count - 10);
            XChatDocument.offlineProcessList.Add(info);
        }

        public bool OnJoinTeam(XEventArgs args) => true;

        public bool OnLeaveTeam(XEventArgs args) => true;

        public ChatFriendData FindFriendData(ulong uid)
        {
            for (int index = 0; index < this.ChatFriendList.Count; ++index)
            {
                if ((long)this.ChatFriendList[index].roleid == (long)uid)
                    return this.ChatFriendList[index];
            }
            return (ChatFriendData)null;
        }

        public void RemoveBlockFriends()
        {
            for (int index = this.ChatFriendList.Count - 1; index >= 0; --index)
            {
                if (DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsBlock(this.ChatFriendList[index].roleid))
                    this.ChatFriendList.RemoveAt(index);
            }
        }

        public void RemoveFriend(ulong uid) => this.SetFriendRelation(uid, false);

        public void RemoveStranger(ulong uid) => this.SetFriendRelation(uid, true);

        public void AddStranger(ulong uid) => this.SetFriendRelation(uid, false);

        public List<ChatInfo> GetChatInfoList(ChatChannelType channelType)
        {
            List<ChatInfo> chatInfoList = (List<ChatInfo>)null;
            XChatDocument.m_ChatDic.TryGetValue(channelType, out chatInfoList);
            return chatInfoList;
        }

        public DateTime GetFriendChatInfoTime(ulong uid)
        {
            DateTime dateTime = DateTime.Today;
            List<ChatInfo> friendChatInfoList = this.GetFriendChatInfoList(uid);
            for (int index = 0; index < friendChatInfoList.Count; ++index)
            {
                if (friendChatInfoList[index].mTime.CompareTo(dateTime) > 0)
                    dateTime = friendChatInfoList[index].mTime;
            }
            return dateTime;
        }

        public List<ChatInfo> GetFriendChatInfoList(ulong uid)
        {
            List<ChatInfo> chatInfoList1 = (List<ChatInfo>)null;
            List<ChatInfo> chatInfoList2 = new List<ChatInfo>();
            XChatDocument.m_ChatDic.TryGetValue(ChatChannelType.Friends, out chatInfoList1);
            if (chatInfoList1 != null)
            {
                for (int index = 0; index < chatInfoList1.Count; ++index)
                {
                    XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
                    if (xplayerData != null)
                    {
                        bool flag = (long)chatInfoList1[index].mSenderId == (long)xplayerData.RoleID && (long)chatInfoList1[index].mReceiverId == (long)uid;
                        if (((long)chatInfoList1[index].mReceiverId == (long)xplayerData.RoleID && (long)chatInfoList1[index].mSenderId == (long)uid) | flag)
                            chatInfoList2.Add(chatInfoList1[index]);
                    }
                }
            }
            return chatInfoList2;
        }

        public List<ChatInfo> GetGroupChatInfoList(ulong groupid)
        {
            List<ChatInfo> chatInfoList1 = (List<ChatInfo>)null;
            List<ChatInfo> chatInfoList2 = new List<ChatInfo>();
            XChatDocument.m_ChatDic.TryGetValue(ChatChannelType.Group, out chatInfoList1);
            if (chatInfoList1 != null)
            {
                int index = 0;
                for (int count = chatInfoList1.Count; index < count; ++index)
                {
                    if (chatInfoList1[index].group != null && (long)chatInfoList1[index].group.groupchatID == (long)groupid)
                        chatInfoList2.Add(chatInfoList1[index]);
                }
            }
            return chatInfoList2;
        }

        public ChatInfo GetChatInfoById(int id)
        {
            List<ChatInfo> chatInfoList = (List<ChatInfo>)null;
            for (ChatChannelType key = ChatChannelType.World; key <= ChatChannelType.ChannelNum; ++key)
            {
                XChatDocument.m_ChatDic.TryGetValue(key, out chatInfoList);
                if (chatInfoList != null)
                {
                    for (int index = 0; index < chatInfoList.Count; ++index)
                    {
                        if (chatInfoList[index].id == id)
                            return chatInfoList[index];
                    }
                }
            }
            return (ChatInfo)null;
        }

        private string ReplaceRoleName(string name)
        {
            if (name.Length > 3)
            {
                name = name.Remove(name.Length - 2, 2);
                name = name.Insert(name.Length, "**");
            }
            else if (name.Length == 3)
            {
                name = name.Remove(name.Length - 1, 1);
                name = name.Insert(name.Length, "*");
            }
            return name;
        }

        public string ProcessText(KKSG.ChatInfo serverChatInfo)
        {
            int index1 = 0;
            XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.System);
            XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.System);
            for (int index2 = 0; index2 < serverChatInfo.param.Count; ++index2)
            {
                ChatParam chatParam = serverChatInfo.param[index2];
                if (chatParam != null)
                {
                    for (int index3 = 0; index3 < serverChatInfo.info.Length; ++index3)
                    {
                        if (serverChatInfo.info[index3] == '$' && serverChatInfo.info.Length >= index3 + 2)
                        {
                            string str1 = "";
                            uint num;
                            if (chatParam.role != null && serverChatInfo.info[index3 + 1] == 'R')
                            {
                                string name = chatParam.role.name;
                                str1 = (long)XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.System) != (long)serverChatInfo.channel ? ((long)chatParam.role.uniqueid != (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID ? this.color_r2 + name + "[-]" : this.color_r1 + name + "[-]") : name;
                                index1 = (int)(chatParam.role.profession % 10U) - 1;
                            }
                            else if (chatParam.item != null && serverChatInfo.info[index3 + 1] == 'I')
                            {
                                ItemList.RowData itemConf = XBagDocument.GetItemConf((int)chatParam.item.item.itemID);
                                if (itemConf == null)
                                {
                                    XDebug singleton = XSingleton<XDebug>.singleton;
                                    num = chatParam.item.item.itemID;
                                    string log2 = num.ToString();
                                    string info = serverChatInfo.info;
                                    singleton.AddErrorLog("itemid: ", log2, " content:", info);
                                }
                                else if ((long)XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.System) == (long)serverChatInfo.channel)
                                {
                                    if (itemConf != null)
                                    {
                                        if (XBagDocument.GetItemConf((int)chatParam.item.item.itemID).ItemName.Length > index1)
                                        {
                                            num = chatParam.item.item.itemCount;
                                            str1 = num.ToString() + itemConf.NumberName + itemConf.ItemName[index1];
                                        }
                                        else
                                        {
                                            num = chatParam.item.item.itemCount;
                                            str1 = num.ToString() + itemConf.NumberName + itemConf.ItemName[0];
                                        }
                                    }
                                }
                                else
                                {
                                    string itemQualityColorStr = XSingleton<UiUtility>.singleton.GetItemQualityColorStr((int)XBagDocument.GetItemConf((int)chatParam.item.item.itemID).ItemQuality);
                                    if (itemConf != null)
                                    {
                                        if (XBagDocument.GetItemConf((int)chatParam.item.item.itemID).ItemName.Length > 1)
                                        {
                                            string[] strArray = new string[7]
                                            {
                        "[",
                        itemQualityColorStr,
                        "]",
                        null,
                        null,
                        null,
                        null
                                            };
                                            num = chatParam.item.item.itemCount;
                                            strArray[3] = num.ToString();
                                            strArray[4] = itemConf.NumberName;
                                            strArray[5] = itemConf.ItemName[index1];
                                            strArray[6] = "[-]";
                                            str1 = string.Concat(strArray);
                                        }
                                        else
                                        {
                                            string[] strArray = new string[7]
                                            {
                        "[",
                        itemQualityColorStr,
                        "]",
                        null,
                        null,
                        null,
                        null
                                            };
                                            num = chatParam.item.item.itemCount;
                                            strArray[3] = num.ToString();
                                            strArray[4] = itemConf.NumberName;
                                            strArray[5] = itemConf.ItemName[0];
                                            strArray[6] = "[-]";
                                            str1 = string.Concat(strArray);
                                        }
                                    }
                                }
                            }
                            else if (chatParam.num != null && serverChatInfo.info[index3 + 1] == 'N')
                            {
                                if ((long)XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.System) == (long)serverChatInfo.channel)
                                {
                                    num = chatParam.num.num;
                                    str1 = num.ToString();
                                }
                                else
                                {
                                    string colorN = this.color_n;
                                    num = chatParam.num.num;
                                    string str2 = num.ToString();
                                    str1 = colorN + str2 + "[-]";
                                }
                            }
                            else if (chatParam.team != null && serverChatInfo.info[index3 + 1] == 'T')
                                str1 = XLabelSymbolHelper.FormatTeam(chatParam.team.teamname, (int)chatParam.team.teamid, chatParam.team.expeditionid);
                            else if (chatParam.guild != null && serverChatInfo.info[index3 + 1] == 'G')
                                str1 = this.color_g + chatParam.guild.guildname.ToString() + "[-]";
                            else if (chatParam.link != null && serverChatInfo.info[index3 + 1] == 'L')
                                str1 = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID).ParseLink(chatParam);
                            else if (chatParam.dragonguild != null && serverChatInfo.info[index3 + 1] == 'D')
                                str1 = this.color_dg + chatParam.dragonguild.dragonguildname.ToString() + "[-]";
                            string str3 = serverChatInfo.info.Substring(0, index3);
                            string str4 = serverChatInfo.info.Substring(index3 + 2, serverChatInfo.info.Length - (index3 + 2));
                            string str5 = str1.Replace("$", "%^&%");
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(str3);
                            stringBuilder.Append(str5);
                            stringBuilder.Append(str4);
                            serverChatInfo.info = stringBuilder.ToString();
                            break;
                        }
                    }
                }
            }
            return serverChatInfo.info.Replace("%^&%", "$");
        }

        private ulong GetFriendID(ChatInfo chatInfo)
        {
            XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
            return xplayerData != null && chatInfo != null ? ((long)chatInfo.mSenderId != (long)xplayerData.RoleID ? chatInfo.mSenderId : chatInfo.mReceiverId) : 0UL;
        }

        public void RefreshSelfMemberPriviligeInfo(uint payMemberID)
        {
            List<ChatChannelType> chatChannelTypeList = new List<ChatChannelType>()
      {
        ChatChannelType.World,
        ChatChannelType.Guild,
        ChatChannelType.Curr,
        ChatChannelType.Team
      };
            for (int index1 = 0; index1 < chatChannelTypeList.Count; ++index1)
            {
                List<ChatInfo> chatInfoList = (List<ChatInfo>)null;
                XChatDocument.m_ChatDic.TryGetValue(chatChannelTypeList[index1], out chatInfoList);
                if (chatInfoList != null)
                {
                    for (int index2 = 0; index2 < chatInfoList.Count; ++index2)
                    {
                        if (chatInfoList[index2].isSelfSender)
                            chatInfoList[index2].mSenderPaymemberid = payMemberID;
                    }
                    this.ChatView.RefreshLoopScroll(chatChannelTypeList[index1]);
                }
            }
        }

        public List<ChatInfo> AddChatInfo(ChatInfo chatInfo, ChatChannelType channelId)
        {
            ChatChannelType key = channelId;
            List<ChatInfo> chatInfoList = (List<ChatInfo>)null;
            XChatDocument.m_ChatDic.TryGetValue(key, out chatInfoList);
            if (chatInfoList == null)
            {
                chatInfoList = new List<ChatInfo>();
                chatInfoList.Add(chatInfo);
                XChatDocument.m_ChatDic.Add(key, chatInfoList);
            }
            else
            {
                if (chatInfoList.Count > 200)
                    chatInfoList.RemoveAt(0);
                chatInfoList.Add(chatInfo);
            }
            switch (channelId)
            {
                case ChatChannelType.Friends:
                    ChatFriendData friendData = this.FindFriendData(this.GetFriendID(chatInfo));
                    if (friendData == null && DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.IsInited)
                        this.AddChatinfo2FriendList(chatInfo);
                    if (friendData != null)
                        friendData.msgtime = DateTime.Now;
                    chatInfoList = this.GetFriendChatInfoList(this.ChatView.ChatFriendId);
                    break;
                case ChatChannelType.Group:
                    XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID).AddChat2Group(chatInfo);
                    break;
            }
            return chatInfoList;
        }

        public void AddChatinfo2FriendList(ChatInfo info)
        {
            ChatFriendData chatFriendData = new ChatFriendData();
            chatFriendData.msgtime = info.mTime;
            if (!info.isSelfSender)
            {
                chatFriendData.name = info.mSenderName;
                chatFriendData.roleid = info.mSenderId;
                chatFriendData.powerpoint = info.mSenderPowerPoint;
                chatFriendData.profession = info.mServerProfession;
                chatFriendData.viplevel = info.mSenderVip;
                chatFriendData.setid = info.payConsume != null ? info.payConsume.setid : new List<uint>();
                if (info.payConsume != null)
                    chatFriendData.setid = info.payConsume.setid;
                chatFriendData.isfriend = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(info.mSenderId);
            }
            else
            {
                chatFriendData.name = info.mReceiverName;
                chatFriendData.roleid = info.mReceiverId;
                chatFriendData.powerpoint = info.mReciverPowerPoint;
                chatFriendData.profession = info.mRecieverProfession;
                chatFriendData.viplevel = info.mReceiverVip;
                chatFriendData.isfriend = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(info.mReceiverId);
            }
            if (this.ContainRole(chatFriendData.roleid))
                return;
            this.ChatFriendList.Add(chatFriendData);
        }

        private bool ContainRole(ulong roleID)
        {
            for (int index = 0; index < this.ChatFriendList.Count; ++index)
            {
                if ((long)this.ChatFriendList[index].roleid == (long)roleID)
                    return true;
            }
            return false;
        }

        private void HandlerMaqueeInfo(KKSG.ChatInfo serverChatInfo)
        {
            for (int index1 = 0; index1 < serverChatInfo.param.Count; ++index1)
            {
                ChatParam chatParam = serverChatInfo.param[index1];
                if (chatParam != null)
                {
                    for (int index2 = 0; index2 < serverChatInfo.info.Length; ++index2)
                    {
                        if (serverChatInfo.info[index2] == '$' && serverChatInfo.info.Length >= index2 + 2 && chatParam.role != null && serverChatInfo.info[index2 + 1] == 'R')
                            chatParam.role.name = this.ReplaceRoleName(chatParam.role.name);
                    }
                }
            }
        }

        public void HandlerReceiveChatInfo(KKSG.ChatInfo serverChatInfo)
        {
            if (serverChatInfo.info == null || serverChatInfo.info == "" || XSingleton<XAttributeMgr>.singleton.XPlayerData == null)
                return;
            string info = serverChatInfo.info;
            if (serverChatInfo.channel == 5U || serverChatInfo.channel == 6U)
            {
                this.HandlerMaqueeInfo(serverChatInfo);
                serverChatInfo.info = this.ProcessText(serverChatInfo);
                DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.ReceiveChatInfo(serverChatInfo);
                serverChatInfo.channel = (uint)XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.System);
                serverChatInfo.info = info;
            }
            serverChatInfo.info = this.ProcessText(serverChatInfo);
            ChatInfo chatInfo = new ChatInfo()
            {
                mTime = this.startTime.AddSeconds((double)serverChatInfo.time),
                mAudioId = serverChatInfo.audioUid,
                mAudioTime = serverChatInfo.audioLen
            };
            chatInfo.voice = chatInfo.GetVoice(serverChatInfo.audioUid, serverChatInfo.audioLen);
            chatInfo.mRegression = false;
            chatInfo.CampDuelID = 0U;
            chatInfo.isAudioPlayed = !DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.IsInited;
            chatInfo.isUIShowed = !DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.IsInited;
            if (serverChatInfo.source != null)
            {
                chatInfo.mSenderName = serverChatInfo.source.name.TrimEnd();
                chatInfo.mSenderId = serverChatInfo.source.roleid;
                chatInfo.mSenderVip = serverChatInfo.source.viplevel;
                chatInfo.mSenderPaymemberid = serverChatInfo.source.paymemberid;
                chatInfo.mServerProfession = serverChatInfo.source.profession;
                chatInfo.mSenderPowerPoint = serverChatInfo.source.powerpoint;
                chatInfo.mCoverDesignationID = serverChatInfo.source.coverDesignationID;
                chatInfo.mSpecialDesignation = serverChatInfo.source.desname;
                chatInfo.militaryRank = serverChatInfo.source.military_rank;
                chatInfo.payConsume = serverChatInfo.source.pre;
                chatInfo.mHeroID = serverChatInfo.source.heroid;
                chatInfo.group = serverChatInfo.groupchatinfo;
                chatInfo.mRegression = serverChatInfo.source.isBackFlow;
                chatInfo.CampDuelID = serverChatInfo.source.campDuelID;
            }
            else if (serverChatInfo.channel == 7U && this.CheckTeam())
            {
                chatInfo.mSenderId = 0UL;
                chatInfo.mSenderName = XStringDefineProxy.GetString("CHAT_TEAM_NEW");
                chatInfo.mSenderVip = 1U;
                chatInfo.mSenderPaymemberid = 0U;
            }
            else if (serverChatInfo.channel == 2U && this.CheckGuild())
            {
                chatInfo.mSenderId = 0UL;
                chatInfo.mSenderName = XStringDefineProxy.GetString("CHAT_GUILD_NEW");
                chatInfo.mSenderVip = 1U;
                chatInfo.mSenderPaymemberid = 0U;
            }
            if (serverChatInfo.destList != null && serverChatInfo.destList.Count > 0)
            {
                chatInfo.mReceiverId = serverChatInfo.destList[0].roleid;
                chatInfo.mReceiverName = serverChatInfo.destList[0].name;
                chatInfo.mReceiverVip = serverChatInfo.destList[0].viplevel;
                chatInfo.mRecieverProfession = serverChatInfo.destList[0].profession;
                chatInfo.mReciverPowerPoint = serverChatInfo.destList[0].powerpoint;
            }
            else if (serverChatInfo.dest != null && serverChatInfo.dest.roleid.Count > 0)
                chatInfo.mReceiverId = serverChatInfo.dest.roleid[0];
            chatInfo.mContent = serverChatInfo.info;
            chatInfo.mChannelId = (ChatChannelType)serverChatInfo.channel;
            if ((long)chatInfo.mSenderId == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
            {
                chatInfo.isSelfSender = true;
                chatInfo.mChatType = chatInfo.isAudioChat ? ChatType.SelfVoice : ChatType.SelfText;
            }
            else
            {
                chatInfo.isSelfSender = false;
                chatInfo.mChatType = chatInfo.isAudioChat ? ChatType.OtherVoice : ChatType.OtherText;
            }
            this.ReceiveChatInfo(chatInfo);
        }

        public void ReceiveChatInfo(ChatInfo chatInfo)
        {
            if (chatInfo.isAudioChat && !chatInfo.isAudioPlayed)
            {
                if (chatInfo.isSelfSender)
                {
                    XSingleton<XChatIFlyMgr>.singleton.StopAutoPlay();
                    XSingleton<XChatIFlyMgr>.singleton.InsertAutoPlayList(chatInfo);
                    return;
                }
                if (XSingleton<XChatIFlyMgr>.singleton.IsAutoPlayEnable)
                {
                    if (XSingleton<XChatIFlyMgr>.singleton.AddAutoPlayList(chatInfo))
                        return;
                    chatInfo.isAudioPlayed = true;
                }
                chatInfo.isAudioPlayed = true;
            }
            if (DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.IsInited)
            {
                this.OnReceiveChatSmallInfo(chatInfo);
                if (chatInfo.isSelfSender && !chatInfo.isAudioChat && !chatInfo.mContent.Contains("tm=") && !chatInfo.mContent.Contains("gd=") && !chatInfo.mContent.Contains("ui=") && !chatInfo.mContent.Contains("sp="))
                    this.CacheRecentSendmsg(chatInfo.mContent);
                XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(chatInfo.mSenderId);
                if (entity != null)
                {
                    XCharacterShowChatComponent xcomponent4 = (XCharacterShowChatComponent)entity.GetXComponent(XCharacterShowChatComponent.uuID);
                    if (xcomponent4.GetType() == typeof(XCharacterShowChatComponent))
                        xcomponent4.AttachChatBubble();
                    xcomponent4?.DealWithChat(chatInfo.mContent);
                }
                DlgBase<BarrageDlg, BarrageBehaviour>.singleton.RealPush(chatInfo);
            }
            this.CacheRecentChatinfo(chatInfo);
            this.AddChatInfo(chatInfo, chatInfo.mChannelId);
            if (chatInfo.mChannelId == ChatChannelType.Friends)
                DlgBase<XChatView, XChatBehaviour>.singleton.ShowTabFriendRed();
            if (!this.ChatView.IsInited || !this.ChatView.IsVisible() || chatInfo.mChannelId != this.ChatView.activeChannelType)
                return;
            if (chatInfo.mContent.IndexOf("\\n") != -1)
                chatInfo.mContent = chatInfo.mContent.Replace("\\n", "/n");
            this.ChatView.RefreshLoopScroll(this.ChatView.activeChannelType);
        }

        public void ClearFriendMsg(ulong roleid)
        {
            if (roleid == 0UL)
            {
                this.ChatFriendList.Clear();
            }
            else
            {
                for (int index = 0; index < this.ChatFriendList.Count; ++index)
                {
                    if ((long)this.ChatFriendList[index].roleid == (long)roleid)
                        this.ChatFriendList.RemoveAt(index);
                }
            }
        }

        public List<ChatInfo> GetSmallChatList() => XChatDocument.m_ChatSmallList;

        public void RestrainSmallChatInfoNum()
        {
            if ((long)XChatDocument.m_ChatSmallList.Count <= (long)XChatSmallBehaviour.m_MaxShowMsg)
                return;
            XChatDocument.m_ChatSmallList.RemoveRange(0, XChatDocument.m_ChatSmallList.Count - (int)XChatSmallBehaviour.m_MaxShowMsg);
        }

        public void AddSmallChatInfo(ChatInfo info) => XChatDocument.m_ChatSmallList.Add(info);

        public void OnClearAllData()
        {
            this.ClearAllData();
            XSingleton<XChatIFlyMgr>.singleton.EnableAutoPlay(false);
            XSingleton<XChatIFlyMgr>.singleton.StopAutoPlay();
            XSingleton<XChatIFlyMgr>.singleton.ClearPlayList();
            DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.IsInited = false;
            DlgBase<XChatView, XChatBehaviour>.singleton.ChatFriendId = 0UL;
        }

        private void ClearAllData()
        {
            List<ChatChannelType> chatChannelTypeList = new List<ChatChannelType>((IEnumerable<ChatChannelType>)XChatDocument.m_ChatDic.Keys);
            for (int index = 0; index < chatChannelTypeList.Count; ++index)
                XChatDocument.m_ChatDic[chatChannelTypeList[index]]?.Clear();
            XChatDocument.m_ChatSmallList.Clear();
            XChatDocument.offlineProcessList.Clear();
            XChatDocument.m_ChatDic.Clear();
            XChatDocument.m_ProcessListSmall.Clear();
        }

        private ChatOpen.RowData ChatOpenRow(int type)
        {
            if (this.openTable.Count <= 0)
            {
                this.sOpenTbale.Clear();
                for (int index = 0; index < XChatDocument._chatOpenTabel.Table.Length; ++index)
                {
                    if (XChatDocument._chatOpenTabel.Table[index].sceneid == 0U)
                        this.openTable.Add((int)XChatDocument._chatOpenTabel.Table[index].id, XChatDocument._chatOpenTabel.Table[index]);
                    else if (!this.sOpenTbale.ContainsKey(XChatDocument._chatOpenTabel.Table[index].sceneid))
                        this.sOpenTbale.Add(XChatDocument._chatOpenTabel.Table[index].sceneid, XChatDocument._chatOpenTabel.Table[index]);
                }
            }
            uint sceneId = XSingleton<XScene>.singleton.SceneID;
            if (type < 100 && this.sOpenTbale.ContainsKey(sceneId))
                return this.sOpenTbale[sceneId];
            if (this.openTable.ContainsKey(type))
                return this.openTable[type];
            XSingleton<XDebug>.singleton.AddErrorLog("找胡博聃，配chatopen表! new scenetype:", type.ToString());
            return this.openTable[1];
        }

        public List<int> SortCommonIcons(int type)
        {
            List<int> intList = new List<int>((IEnumerable<int>)this.ChatOpenRow(type).opens);
            bool flag1 = this.CheckGuild();
            bool flag2 = this.CheckTeam();
            bool flag3 = this.CheckLevelLimit(ChatChannelType.World);
            if (intList.Contains(1) && !flag3)
                intList.Remove(1);
            if (intList.Contains(2) && !flag1)
                intList.Remove(2);
            if (intList.Contains(7) && !flag2)
                intList.Remove(7);
            return intList;
        }

        public ChatOpen.RowData GetYuyinRaw(int type) => this.ChatOpenRow(type);

        public ChatOpen.RowData GetBattleRaw() => this.GetYuyinRaw((int)XSingleton<XScene>.singleton.SceneType);

        public List<ChatFriendData> FetchFriendsIcons()
        {
            this.ChatFriendList.Sort(XSingleton<XChatUIOP>.singleton.CompareNewMsgCb);
            return this.ChatFriendList;
        }

        public uint GetChatMaxFriendCount(int type) => this.ChatOpenRow(type).friends;

        public bool CheckLevelLimit(ChatChannelType type)
        {
            int num = XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(type);
            XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
            return xplayerData != null && XChatDocument._chatTable.GetByid((uint)num).level <= xplayerData.Level;
        }

        public bool CheckGuild()
        {
            if (this.guildDoc == null)
                this.guildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
            return this.guildDoc.bInGuild;
        }

        public bool CheckTeam()
        {
            if (this.teamDoc == null)
                this.teamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
            return this.teamDoc.MyTeam != null && (uint)this.teamDoc.MyTeam.teamBrief.teamID > 0U;
        }

        public void ReqGetFlowerLeftTime() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_GetFlowerLeftTime());

        public void OnGetFlowerLeftTime(GetFlowerLeftTimeRes oRes)
        {
            if (oRes.errorCode != ErrorCode.ERR_SUCCESS)
                return;
            XSingleton<XGameSysMgr>.singleton.GetFlowerRemainTime = (float)oRes.leftTime;
            this.getFlowerLeftTime = oRes.leftTime;
            this.canGetFlower = oRes.canGet;
            if (!oRes.canGet)
                this.getFlowerLeftTime = 0;
            DlgBase<XChatView, XChatBehaviour>.singleton.OnRefreshGetFlowerInfo();
        }

        public void ReqGetFlower() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_GetFlower());

        public void OnGetFlower(GetFlowerRes oRes)
        {
            if (oRes.errorCode != ErrorCode.ERR_SUCCESS)
                return;
            XSingleton<XGameSysMgr>.singleton.GetFlowerRemainTime = (float)oRes.leftTime;
            this.getFlowerLeftTime = oRes.leftTime;
            this.canGetFlower = oRes.canGet;
            if (!oRes.canGet)
                this.getFlowerLeftTime = 0;
            DlgBase<XChatView, XChatBehaviour>.singleton.OnRefreshGetFlowerInfo();
        }
    }
}
