

using KKSG;
using MiniJSON;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XChatView : DlgBase<XChatView, XChatBehaviour>
    {
        private XChatView.ChatGroupState _groupState = XChatView.ChatGroupState.GROUPS;
        private XChatView.ChatFriendState _friendState = XChatView.ChatFriendState.FRIENDS;
        private ChatChannelType cacheChannelType = ChatChannelType.World;
        private List<LoopItemData> cacheLoopList = new List<LoopItemData>();
        private System.Action mOnSend;
        private InputUIType mInputType;
        private string mLinkContent;
        private Transform[] mTransTab = new Transform[11];
        private IXUICheckBox[] mCheckbox = new IXUICheckBox[11];
        private XChatDocument _doc = (XChatDocument)null;
        private ChatChannelType currentSpeakChannel = ChatChannelType.World;
        private SetEffectInfo m_iSetEffectInfo = (SetEffectInfo)null;
        private const int CHAT_CHANNEL_NUM = 11;
        private bool Inited = false;
        private int m_ChatIdIndex = 1;
        private XChatUIOP m_UIOP = XSingleton<XChatUIOP>.singleton;
        public static bool m_YunvaInited = false;
        private bool m_CancelRecord = false;
        private Vector2 m_DragDistance = Vector2.zero;
        private uint _GetFlowerCDToken;
        private DateTime[] m_lastChatTime = new DateTime[15];
        public List<string> chatContentItem = new List<string>();
        public ulong ChatFriendId = 0;
        public ulong ChatGroupId = 0;
        private string m_sPrivateChatCurrName = "";
        public bool cacheShow = false;
        public uint _worldSpeadTimes;
        public ChatChannelType activeChannelType = ChatChannelType.World;
        private ChatChannelType[] showChannelIds = new ChatChannelType[11]
        {
      ChatChannelType.World,
      ChatChannelType.Guild,
      ChatChannelType.Friends,
      ChatChannelType.Curr,
      ChatChannelType.Team,
      ChatChannelType.Partner,
      ChatChannelType.Group,
      ChatChannelType.Broadcast,
      ChatChannelType.Spectate,
      ChatChannelType.Battle,
      ChatChannelType.System
        };
        private ChatChannelType[] showVoiceBar = new ChatChannelType[4]
        {
      ChatChannelType.World,
      ChatChannelType.Curr,
      ChatChannelType.Team,
      ChatChannelType.Guild
        };
        private ChatInfo mChatInfo;
        private bool mIsVoice;

        public XChatView.ChatGroupState groupState
        {
            get => this._groupState;
            set
            {
                this.ShowGroup(value);
                this._groupState = value;
            }
        }

        private void RegistGroupEvent()
        {
            this.uiBehaviour.m_sprGroupQuit.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGroupQuitClick));
            this.uiBehaviour.m_sprGroupClear.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGroupClearClick));
            this.uiBehaviour.m_sprGroupBind.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGroupBindClick));
            this.uiBehaviour.m_sprGroupBack.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGroupBackClick));
            this.uiBehaviour.m_sprMember.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMemberClick));
            this.uiBehaviour.m_sprList.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnListClick));
            this.uiBehaviour.m_sprMore.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMoreClick));
            this.uiBehaviour.m_sprGroupCreate.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGroupCreateClick));
        }

        private void ShowGroup(XChatView.ChatGroupState state)
        {
            bool bVisible = state == XChatView.ChatGroupState.GROUPS;
            this.uiBehaviour.m_sprGroupBack.SetVisible(!bVisible);
            this.uiBehaviour.m_sprGroupBind.SetVisible(!bVisible);
            this.uiBehaviour.m_sprGroupClear.SetVisible(bVisible);
            this.uiBehaviour.m_sprGroupQuit.SetVisible(!bVisible);
            this.uiBehaviour.m_sprMore.SetVisible(!bVisible);
            this.uiBehaviour.m_lblGroupChat.SetVisible(!bVisible);
            this.uiBehaviour.m_sprGroupCreate.SetVisible(bVisible);
            this.m_uiBehaviour.m_friendView.gameobject.SetActive(false);
            this.uiBehaviour.m_loopView.gameobject.SetActive(!bVisible);
            this.uiBehaviour.m_TextBoard.SetVisible(!bVisible);
            this.m_uiBehaviour.m_groupView.gameobject.SetActive(bVisible);
            GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
            this.uiBehaviour.m_sprMember.SetVisible(!bVisible && specificDocument.currGroup != null && specificDocument.currGroup.captain);
            this.uiBehaviour.m_sprList.SetVisible(!bVisible && specificDocument.currGroup != null && !specificDocument.currGroup.captain);
            if (specificDocument.currGroup == null)
                return;
            this.uiBehaviour.m_lblGroupChat.SetText(XStringDefineProxy.GetString("CHAT_GROUP_SIGN", (object)specificDocument.currGroup.name));
        }

        public void OnFocus()
        {
            for (int index = 0; index < 11; ++index)
            {
                if (this.showChannelIds[index] == ChatChannelType.Group)
                {
                    this.mCheckbox[index].ForceSetFlag(true);
                    break;
                }
            }
        }

        public void ProcessGroupMsg()
        {
            if (!this.IsVisible() || this.activeChannelType != ChatChannelType.Group)
                return;
            if (this.groupState == XChatView.ChatGroupState.GROUPS)
                this.RefreshGrouplist();
            else
                this.JumpToGrouplist((IXUISprite)null);
        }

        private void JumpToGrouplist(IXUISprite spr)
        {
            this.ShowGroup(XChatView.ChatGroupState.GROUPS);
            this.RefreshGrouplist();
        }

        public void JumpToGroupChat(IXUISprite spr)
        {
            this.groupState = XChatView.ChatGroupState.CHATS;
            this.ShowGroup(XChatView.ChatGroupState.CHATS);
            this.ShowMore(false);
            this.RefreshLoopScroll(ChatChannelType.Group);
        }

        private void OnMoreClick(IXUISprite spr) => this.ShowMore(!this.uiBehaviour.m_sprGroupQuit.IsVisible());

        private void ShowMore(bool show)
        {
            GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
            bool flag = false;
            if (specificDocument.currGroup != null)
                flag = specificDocument.currGroup.captain;
            this.uiBehaviour.m_sprMember.gameObject.SetActive(show & flag);
            this.uiBehaviour.m_sprList.gameObject.SetActive(show && !flag);
            this.uiBehaviour.m_sprGroupQuit.gameObject.SetActive(show);
        }

        private void OnMemberClick(IXUISprite spr) => DlgBase<ChatGroupList, ChatGroupBehaviour>.singleton.SetVisible(true, true);

        private void OnGroupClearClick(IXUISprite spr)
        {
            GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
            specificDocument.ReqClearGroup();
            if (specificDocument.groups != null)
                specificDocument.groups.Clear();
            this.RefreshGrouplist();
        }

        private void OnListClick(IXUISprite spr) => DlgBase<ChatMemberList, ChatMemberBehaviour>.singleton.SetVisible(true, true);

        private bool IsGroupWith(ChatInfo data) => DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible() && DlgBase<XChatView, XChatBehaviour>.singleton.activeChannelType == ChatChannelType.Group && this._friendState == XChatView.ChatFriendState.CHATS && data.group != null && (long)this.ChatGroupId == (long)data.group.groupchatID;

        public bool HasNewGroupMsg()
        {
            this._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
            List<ChatInfo> chatInfoList = this._doc.GetChatInfoList(ChatChannelType.Group);
            if (chatInfoList != null)
            {
                for (int index = 0; index < chatInfoList.Count; ++index)
                {
                    if (!this.IsGroupWith(chatInfoList[index]) && !chatInfoList[index].isUIShowed && !chatInfoList[index].isSelfSender)
                        return true;
                }
            }
            return false;
        }

        public bool HasRedpointGroupMsg(ulong groupid)
        {
            List<ChatInfo> groupChatInfoList = this._doc.GetGroupChatInfoList(DlgBase<XChatView, XChatBehaviour>.singleton.ChatGroupId);
            if (groupChatInfoList != null)
            {
                for (int index = 0; index < groupChatInfoList.Count; ++index)
                {
                    if (!groupChatInfoList[index].isUIShowed && !groupChatInfoList[index].isSelfSender)
                        return true;
                }
            }
            return false;
        }

        private void OnGroupBindClick(IXUISprite spr)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(XStringDefineProxy.GetString("CHAT_CLEAR"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL));
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnOKClearGroups));
        }

        private bool OnOKClearGroups(IXUIButton btn) => true;

        public void OnGroupQuitClick(IXUISprite spr)
        {
            CBrifGroupInfo currGroup = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID).currGroup;
            if (currGroup == null)
                return;
            bool captain = currGroup.captain;
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(XStringDefineProxy.GetString(captain ? "CHAT_GROUP_QUIT1" : "CHAT_GROUP_QUIT2"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL));
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnModalDlgOK));
        }

        private void OnGroupBackClick(IXUISprite spr) => this.JumpToGrouplist(spr);

        private void OnGroupCreateClick(IXUISprite spr)
        {
            DlgBase<CreateChatGroupDlg, CreateChatGroupBehaviour>.singleton.SetVisible(true, true);
            DlgBase<CreateChatGroupDlg, CreateChatGroupBehaviour>.singleton.SetCallBack(new CreatechatGroupCall(this.OnCreateGroup));
        }

        private bool OnCreateGroup(string groupname) => XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID).ReqCreateGroupChat(groupname);

        private bool OnModalDlgOK(IXUIButton btn)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            this.groupState = XChatView.ChatGroupState.GROUPS;
            GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
            CBrifGroupInfo currGroup = specificDocument.currGroup;
            if (currGroup == null)
                XSingleton<XDebug>.singleton.AddErrorLog("quit group id is null");
            specificDocument.ReqQuitGroup(currGroup.id);
            return true;
        }

        public XChatView.ChatFriendState friendState
        {
            get => this._friendState;
            set
            {
                this.ShowFriend(value == XChatView.ChatFriendState.FRIENDS);
                this._friendState = value;
            }
        }

        private void RegistFriendEvent()
        {
            this.uiBehaviour.m_sprFriendAdd.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddFriendClick));
            this.uiBehaviour.m_sprFriendBack.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.JumpToFriends));
            this.uiBehaviour.m_sprFriendClear.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClearFriendClick));
            this.uiBehaviour.m_sprFriendChat.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ShowFriendsUI));
        }

        private void RefreshFriendList() => this.RefreshFriendsScroll(this._doc.FetchFriendsIcons());

        public void RefreshFriendUI() => this.RefreshFriendUI(this.friendState);

        public void RefreshFriendUI(XChatView.ChatFriendState _state)
        {
            if (this.ChatFriendId == 0UL || this._doc.ChatFriendList.Count <= 0 || _state == XChatView.ChatFriendState.FRIENDS)
            {
                this.friendState = XChatView.ChatFriendState.FRIENDS;
                this.RefreshFriendList();
            }
            else
            {
                this.friendState = XChatView.ChatFriendState.CHATS;
                this.RefreshLoopScroll(ChatChannelType.Friends);
            }
        }

        private void OnAddFriendClick(IXUISprite spr) => DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(this.ChatFriendId);

        private void OnClearFriendClick(IXUISprite spr)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.m_OKButton.ID = 0UL;
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(XStringDefineProxy.GetString("CHAT_CLEAR"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL));
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnOKClearFriends));
        }

        private bool OnOKClearFriends(IXUIButton btn)
        {
            this.OnSendClearFriend(btn.ID);
            return true;
        }

        public void OnSendClearFriend(ulong uid)
        {
            this.ChatFriendId = 0UL;
            this._doc.ClearFriendMsg(uid);
            this.RefreshFriendUI(XChatView.ChatFriendState.FRIENDS);
            this.ShowTabFriendRed();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_ClearPrivateChatList()
            {
                oArg = {
          roleid = uid
        }
            });
        }

        private void ShowFriendsUI(IXUISprite spr)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends))
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIEND_UI_LOCK"), "fece00");
            else
                XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Friends);
        }

        private void JumpToFriends(IXUISprite spr)
        {
            this.friendState = XChatView.ChatFriendState.FRIENDS;
            this.RefreshFriendUI();
            this.ShowFriend(true);
        }

        public void JumpToChats(IXUISprite spr)
        {
            this.friendState = XChatView.ChatFriendState.CHATS;
            this.ChatFriendId = spr.ID;
            this.ResetRedpointMsg(DlgBase<XChatView, XChatBehaviour>.singleton.ChatFriendId);
            this.ShowTabFriendRed();
            this.ShowFriend(false);
            this.RefreshLoopScroll(ChatChannelType.Friends);
        }

        private void ShowFriend(bool isFriends)
        {
            ulong chatFriendId = DlgBase<XChatView, XChatBehaviour>.singleton.ChatFriendId;
            bool flag = chatFriendId > 0UL && DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(chatFriendId);
            this.m_uiBehaviour.m_friendView.gameobject.SetActive(isFriends);
            this.m_uiBehaviour.m_loopView.gameobject.SetActive(!isFriends);
            this.uiBehaviour.m_groupView.gameobject.SetActive(false);
            this.uiBehaviour.m_TextBoard.SetVisible(!isFriends);
            this.m_uiBehaviour.m_sprFriendAdd.SetVisible(!isFriends && !flag);
            this.m_uiBehaviour.m_sprFriendClear.SetVisible(isFriends && this._doc.ChatFriendList.Count > 0);
            this.m_uiBehaviour.m_sprFriendBack.SetVisible(!isFriends);
            this.m_uiBehaviour.m_lblFriendTip.SetVisible(!isFriends);
            this.m_uiBehaviour.m_sprFriendChat.SetVisible(isFriends && this._doc.ChatFriendList.Count <= 0);
            if (isFriends)
                return;
            ChatFriendData currChatFriendData = this.UIOP.CurrChatFriendData;
            if (currChatFriendData != null)
                this.m_uiBehaviour.m_lblFriendTip.SetText(XStringDefineProxy.GetString("CHAT_WITH", (object)currChatFriendData.name));
        }

        public void ResetRedpointMsg(ulong uid)
        {
            if (this._doc == null)
                this._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
            List<ChatInfo> friendChatInfoList = this._doc.GetFriendChatInfoList(uid);
            for (int index = 0; index < friendChatInfoList.Count; ++index)
                friendChatInfoList[index].isUIShowed = true;
            for (int index = 0; index < this._doc.ChatFriendList.Count; ++index)
            {
                if ((long)this._doc.ChatFriendList[index].roleid == (long)uid)
                {
                    this._doc.ChatFriendList[index].hasOfflineRead = false;
                    break;
                }
            }
        }

        public bool HasRedpointMsg(ulong uid)
        {
            this._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
            List<ChatFriendData> chatFriendList = this._doc.ChatFriendList;
            for (int index = 0; index < chatFriendList.Count; ++index)
            {
                if ((long)chatFriendList[index].roleid == (long)uid && chatFriendList[index].hasOfflineRead)
                    return true;
            }
            List<ChatInfo> friendChatInfoList = this._doc.GetFriendChatInfoList(uid);
            for (int index = 0; index < friendChatInfoList.Count; ++index)
            {
                if (!friendChatInfoList[index].isUIShowed && !friendChatInfoList[index].isSelfSender)
                    return true;
            }
            return false;
        }

        private bool IsChatWith(ChatInfo data) => DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible() && DlgBase<XChatView, XChatBehaviour>.singleton.activeChannelType == ChatChannelType.Friends && this._friendState == XChatView.ChatFriendState.CHATS && ((long)this.ChatFriendId == (long)data.mReceiverId || (long)this.ChatFriendId == (long)data.mSenderId);

        private bool IsInFriendsList(ChatInfo data, List<ChatFriendData> friends)
        {
            for (int index = 0; index < friends.Count; ++index)
            {
                if ((long)friends[index].roleid == (data.isSelfSender ? (long)data.mReceiverId : (long)data.mSenderId))
                    return true;
            }
            return false;
        }

        public bool HasNewFriendMsg()
        {
            this._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
            List<ChatFriendData> chatFriendList = this._doc.ChatFriendList;
            for (int index = 0; index < chatFriendList.Count; ++index)
            {
                if (chatFriendList[index].hasOfflineRead)
                    return true;
            }
            List<ChatInfo> chatInfoList = this._doc.GetChatInfoList(ChatChannelType.Friends);
            if (chatInfoList != null)
            {
                for (int index = 0; index < chatInfoList.Count; ++index)
                {
                    if (!this.IsChatWith(chatInfoList[index]) && !chatInfoList[index].isUIShowed && !chatInfoList[index].isSelfSender && this.IsInFriendsList(chatInfoList[index], chatFriendList))
                        return true;
                }
            }
            return false;
        }

        private void LoopInit()
        {
            GameObject tpl1 = this.uiBehaviour.m_loopView.GetTpl();
            if ((UnityEngine.Object)tpl1 != (UnityEngine.Object)null && (UnityEngine.Object)tpl1.GetComponent<ChatItem>() == (UnityEngine.Object)null)
                tpl1.AddComponent<ChatItem>();
            GameObject tpl2 = this.uiBehaviour.m_systemView.GetTpl();
            if ((UnityEngine.Object)tpl2 != (UnityEngine.Object)null && (UnityEngine.Object)tpl2.GetComponent<ChatSystemItem>() == (UnityEngine.Object)null)
                tpl2.AddComponent<ChatSystemItem>();
            GameObject tpl3 = this.uiBehaviour.m_friendView.GetTpl();
            if ((UnityEngine.Object)tpl3 != (UnityEngine.Object)null && (UnityEngine.Object)tpl3.GetComponent<ChatFriendItem>() == (UnityEngine.Object)null)
                tpl3.AddComponent<ChatFriendItem>();
            GameObject tpl4 = this.uiBehaviour.m_groupView.GetTpl();
            if (!((UnityEngine.Object)tpl4 != (UnityEngine.Object)null) || !((UnityEngine.Object)tpl4.GetComponent<ChatGroupItem>() == (UnityEngine.Object)null))
                return;
            tpl4.AddComponent<ChatGroupItem>();
        }

        private void SetLoopActive(ChatChannelType type)
        {
            this.uiBehaviour.m_systemView.gameobject.SetActive(type == ChatChannelType.System);
            if (type != ChatChannelType.Friends)
            {
                this.uiBehaviour.m_loopView.gameobject.SetActive(type != ChatChannelType.System);
                this.uiBehaviour.m_friendView.gameobject.SetActive(false);
                this.uiBehaviour.m_groupView.gameobject.SetActive(false);
                if (type != ChatChannelType.System)
                    this.uiBehaviour.m_loopView.ResetScroll();
            }
            this.uiBehaviour.m_tranOffset.localPosition = new Vector3(0.0f, type == ChatChannelType.Friends || type == ChatChannelType.Group || this.IsVoicebarShow() ? -24f : 0.0f, 0.0f);
        }

        public void RefreshLoopScroll(ChatChannelType type)
        {
            if (!this.IsVisible())
                return;
            switch (type)
            {
                case ChatChannelType.Friends:
                    if (this.friendState == XChatView.ChatFriendState.CHATS)
                    {
                        List<ChatInfo> friendChatInfoList = this._doc.GetFriendChatInfoList(DlgBase<XChatView, XChatBehaviour>.singleton.ChatFriendId);
                        this.uiBehaviour.m_loopView.SetClipSize(new Vector2(434f, 504f));
                        this.RefreshLoopScroll(type, friendChatInfoList);
                        this.cacheChannelType = type;
                        break;
                    }
                    this.friendState = XChatView.ChatFriendState.FRIENDS;
                    this.RefreshFriendList();
                    break;
                case ChatChannelType.System:
                    this.RefreshSystemScroll(this._doc.GetChatInfoList(type));
                    break;
                case ChatChannelType.Group:
                    if (this.groupState == XChatView.ChatGroupState.CHATS)
                    {
                        List<ChatInfo> groupChatInfoList = this._doc.GetGroupChatInfoList(DlgBase<XChatView, XChatBehaviour>.singleton.ChatGroupId);
                        this.uiBehaviour.m_loopView.SetClipSize(new Vector2(434f, 504f));
                        this.RefreshLoopScroll(type, groupChatInfoList);
                        this.cacheChannelType = type;
                        break;
                    }
                    this.groupState = XChatView.ChatGroupState.GROUPS;
                    break;
                default:
                    List<ChatInfo> chatInfoList = this._doc.GetChatInfoList(type);
                    this.uiBehaviour.m_loopView.SetClipSize(this.IsVoicebarShow() ? new Vector2(434f, 504f) : new Vector2(434f, 544f));
                    this.RefreshLoopScroll(type, chatInfoList);
                    this.cacheChannelType = type;
                    break;
            }
        }

        private void RefreshLoopScroll(ChatChannelType type, List<ChatInfo> chats)
        {
            List<LoopItemData> datas = new List<LoopItemData>();
            if (chats != null)
            {
                for (int index = 0; index < chats.Count; ++index)
                {
                    chats[index].LoopID = XSingleton<XCommon>.singleton.XHash(XSingleton<XCommon>.singleton.StringCombine(chats[index].mContent, chats[index].mSenderPaymemberid.ToString()));
                    datas.Add((LoopItemData)chats[index]);
                }
            }
            this.cacheLoopList = datas;
            if (!this.uiBehaviour.m_loopView.IsScrollLast() && this.cacheChannelType == type && this.cacheChannelType != ChatChannelType.Friends && this.cacheChannelType != ChatChannelType.Group || !this.uiBehaviour.m_loopView.gameobject.activeInHierarchy)
                return;
            this.uiBehaviour.m_loopView.Init(datas, new DelegateHandler(this.RefreshItem), new System.Action(this.OnDragFinish), datas.Count > 5 ? 1 : 0);
        }

        private void OnDragFinish() => this.uiBehaviour.m_loopView.Init(this.cacheLoopList, new DelegateHandler(this.RefreshItem), new System.Action(this.OnDragFinish), this.cacheLoopList.Count > 5 ? 1 : 0);

        private void RefreshFriendsScroll(List<ChatFriendData> friends)
        {
            List<LoopItemData> datas = new List<LoopItemData>();
            if (friends != null)
            {
                for (int index = 0; index < friends.Count; ++index)
                {
                    ChatFriendData chatFriendData = new ChatFriendData();
                    chatFriendData.isfriend = friends[index].isfriend;
                    chatFriendData.name = friends[index].name;
                    chatFriendData.powerpoint = friends[index].powerpoint;
                    chatFriendData.profession = friends[index].profession;
                    chatFriendData.roleid = friends[index].roleid;
                    chatFriendData.msgtime = friends[index].msgtime;
                    chatFriendData.viplevel = friends[index].viplevel;
                    chatFriendData.setid = friends[index].setid;
                    chatFriendData.LoopID = XSingleton<XCommon>.singleton.XHash(friends[index].name + Time.unscaledTime.ToString());
                    datas.Add((LoopItemData)chatFriendData);
                }
            }
            this.uiBehaviour.m_friendView.Init(datas, new DelegateHandler(this.RefreshFriendItem), (System.Action)null);
        }

        private void RefreshGrouplist()
        {
            HashSet<CBrifGroupInfo> groups = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID).groups;
            if (groups == null)
                return;
            List<LoopItemData> datas = new List<LoopItemData>();
            HashSet<CBrifGroupInfo>.Enumerator enumerator = groups.GetEnumerator();
            while (enumerator.MoveNext())
                datas.Add((LoopItemData)enumerator.Current);
            datas.Sort(new Comparison<LoopItemData>(this.SortGroup));
            this.uiBehaviour.m_groupView.Init(datas, new DelegateHandler(this.RefreshGroupItem), (System.Action)null, forceRefreshPerTime: true);
        }

        private int SortGroup(LoopItemData x, LoopItemData y) => (x as CBrifGroupInfo).createTime.CompareTo((y as CBrifGroupInfo).createTime);

        private void RefreshSystemScroll(List<ChatInfo> chats)
        {
            List<LoopItemData> datas = new List<LoopItemData>();
            if (chats != null)
            {
                for (int index = 0; index < chats.Count; ++index)
                {
                    chats[index].LoopID = XSingleton<XCommon>.singleton.XHash(chats[index].mContent);
                    datas.Add((LoopItemData)chats[index]);
                }
            }
            this.uiBehaviour.m_systemView.Init(datas, new DelegateHandler(this.RefreshSystemItem), (System.Action)null, datas.Count > 5 ? 1 : 0);
        }

        private void RefreshItem(ILoopItemObject item, LoopItemData data)
        {
            if (data is ChatInfo info)
                item.GetObj().GetComponent<ChatItem>().Refresh(info);
            else
                XSingleton<XDebug>.singleton.AddErrorLog("info is nil");
        }

        private void RefreshFriendItem(ILoopItemObject item, LoopItemData data)
        {
            if (data is ChatFriendData data1)
                item.GetObj().GetComponent<ChatFriendItem>().Refresh(data1);
            else
                XSingleton<XDebug>.singleton.AddErrorLog("friend info is null");
        }

        private void RefreshGroupItem(ILoopItemObject item, LoopItemData data)
        {
            if (data is CBrifGroupInfo d)
                item.GetObj().GetComponent<ChatGroupItem>().Refresh(d);
            else
                XSingleton<XDebug>.singleton.AddErrorLog("group info is null");
        }

        private void RefreshSystemItem(ILoopItemObject item, LoopItemData data)
        {
            if (data is ChatInfo info)
                item.GetObj().GetComponent<ChatSystemItem>().Refresh(info);
            else
                XSingleton<XDebug>.singleton.AddErrorLog("system info is nil");
        }

        private bool isFighting => XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_READY;

        private void InitTabs()
        {
            for (int index = 0; index < 11; ++index)
            {
                Transform child = this.uiBehaviour.transform.FindChild("Bg/tabs/tab" + (object)(int)this.showChannelIds[index]);
                this.mTransTab[index] = child;
                IXUICheckBox component = child.FindChild("template/Bg").GetComponent("XUICheckBox") as IXUICheckBox;
                this.mCheckbox[index] = component;
            }
        }

        private void ResetTabs()
        {
            for (int index = 0; index < this.mCheckbox.Length; ++index)
                this.mCheckbox[index].bChecked = false;
        }

        private void SetDepth()
        {
            int d = 16;
            XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
            if (specificDocument != null && specificDocument.MyTeamView != null && specificDocument.MyTeamView.IsVisible())
                d = 13;
            this.uiBehaviour.m_panelText.SetDepth(d + 1);
            this.uiBehaviour.m_panelRoot.SetDepth(d);
            this.uiBehaviour.m_loopView.SetDepth(d + 1);
            this.uiBehaviour.m_friendView.SetDepth(d + 1);
            this.uiBehaviour.m_systemView.SetDepth(d + 1);
            this.uiBehaviour.m_panelSubMenu.SetDepth(d + 2);
        }

        private void ShowTextboard(ChatChannelType channel)
        {
            if (channel == ChatChannelType.World && !this.ChatDoc.CheckLevelLimit(channel))
            {
                this.uiBehaviour.m_TextBoard.SetVisible(false);
                this.uiBehaviour.m_LimitBoard.SetVisible(true);
            }
            else
            {
                this.uiBehaviour.m_LimitBoard.SetVisible(false);
                this.uiBehaviour.m_TextBoard.SetVisible(channel != ChatChannelType.System);
            }
        }

        private void ShowTabs()
        {
            int num = 0;
            int spriteHeight = (this.uiBehaviour.transform.FindChild("Bg/tabs/tab1").GetComponent("XUISprite") as IXUISprite).spriteHeight;
            for (int index = 0; index < 11; ++index)
            {
                ChatChannelType showChannelId = this.showChannelIds[index];
                Transform child = this.uiBehaviour.transform.FindChild("Bg/tabs/tab" + (object)(int)showChannelId);
                if ((UnityEngine.Object)child != (UnityEngine.Object)null)
                {
                    switch (showChannelId)
                    {
                        case ChatChannelType.Guild:
                            bool flag1 = this.CheckGuildOpen();
                            this.mCheckbox[index].ForceSetFlag(false);
                            child.gameObject.SetActive(flag1);
                            if (!flag1 && this.activeChannelType == ChatChannelType.Guild)
                                this.activeChannelType = ChatChannelType.World;
                            if (flag1)
                                break;
                            continue;
                        case ChatChannelType.Friends:
                            child.gameObject.SetActive(!this.isFighting);
                            if (this.isFighting)
                            {
                                if (this.activeChannelType == ChatChannelType.Friends)
                                {
                                    this.activeChannelType = ChatChannelType.World;
                                    continue;
                                }
                                continue;
                            }
                            break;
                        case ChatChannelType.Team:
                            bool flag2 = this.CheckTeamOpen();
                            this.mCheckbox[index].ForceSetFlag(false);
                            child.gameObject.SetActive(flag2);
                            if (!flag2 && this.activeChannelType == ChatChannelType.Team)
                                this.activeChannelType = ChatChannelType.World;
                            if (flag2)
                                break;
                            continue;
                        case ChatChannelType.Spectate:
                            bool flag3 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsVisible();
                            this.mCheckbox[index].ForceSetFlag(false);
                            child.gameObject.SetActive(flag3);
                            if (!flag3)
                            {
                                if (this.activeChannelType == ChatChannelType.Spectate)
                                {
                                    this.activeChannelType = ChatChannelType.World;
                                    continue;
                                }
                                continue;
                            }
                            break;
                        case ChatChannelType.Curr:
                            bool flag4 = !DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsVisible();
                            if (!flag4)
                                this.mCheckbox[index].bChecked = false;
                            child.gameObject.SetActive(flag4);
                            if (!flag4)
                            {
                                if (this.activeChannelType == ChatChannelType.Curr)
                                {
                                    this.activeChannelType = ChatChannelType.World;
                                    continue;
                                }
                                continue;
                            }
                            break;
                        case ChatChannelType.Partner:
                            bool flag5 = this.CheckDragonGuildOpen();
                            this.mCheckbox[index].ForceSetFlag(false);
                            child.gameObject.SetActive(flag5);
                            if (!flag5)
                            {
                                if (this.activeChannelType == ChatChannelType.Partner)
                                {
                                    this.activeChannelType = ChatChannelType.World;
                                    continue;
                                }
                                continue;
                            }
                            break;
                        case ChatChannelType.Broadcast:
                            this.mCheckbox[index].ForceSetFlag(false);
                            bool flag6 = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID).GetValue(XOptionsDefine.OD_RADIO) == 1 & (long)XSingleton<XGlobalConfig>.singleton.GetInt("RadioChatOpen") <= (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
                            child.gameObject.SetActive(flag6);
                            if (!flag6)
                            {
                                if (this.activeChannelType == ChatChannelType.Broadcast)
                                {
                                    this.activeChannelType = ChatChannelType.World;
                                    continue;
                                }
                                continue;
                            }
                            break;
                        case ChatChannelType.Battle:
                            bool flag7 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && this.ChatDoc.GetBattleRaw().battle == 1;
                            if (!flag7)
                                this.mCheckbox[index].bChecked = false;
                            child.gameObject.SetActive(flag7);
                            if (!flag7)
                            {
                                if (this.activeChannelType == ChatChannelType.Battle)
                                {
                                    this.activeChannelType = ChatChannelType.World;
                                    continue;
                                }
                                continue;
                            }
                            break;
                        case ChatChannelType.Group:
                            this.mCheckbox[index].ForceSetFlag(false);
                            bool flag8 = (long)XSingleton<XGlobalConfig>.singleton.GetInt("GroupChatOpen") <= (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
                            child.gameObject.SetActive(flag8);
                            if (!flag8)
                            {
                                if (this.activeChannelType == ChatChannelType.Group)
                                {
                                    this.activeChannelType = ChatChannelType.World;
                                    continue;
                                }
                                continue;
                            }
                            break;
                    }
                    child.transform.localPosition = new Vector3(0.0f, (float)(272 - spriteHeight * num), 0.0f);
                    ++num;
                }
            }
        }

        public void ShowBtns()
        {
            this.uiBehaviour.m_sprMail.SetVisible(!this.isFighting & XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Mail));
            this.uiBehaviour.m_sprSet.SetVisible(!this.isFighting);
        }

        public void ShowMailRedpoint()
        {
            if (this.IsVisible())
                this.uiBehaviour.m_sprMailRedpoint.SetVisible(XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(XSysDefine.XSys_Mail));
            if (!DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.IsVisible())
                return;
            DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowMailRedpoint();
        }

        public void ShowTabFriendRed()
        {
            bool show = this.HasNewFriendMsg();
            if (DlgBase<XChatView, XChatBehaviour>.singleton.IsLoaded())
            {
                GameObject gameObject = this.uiBehaviour.transform.FindChild("Bg/tabs/tab" + (object)3).Find("template/Bg/redpoint").gameObject;
                if ((UnityEngine.Object)gameObject != (UnityEngine.Object)null)
                    gameObject.SetActive(show);
            }
            if (!DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.IsVisible())
                return;
            DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetRedpoint(show);
        }

        private bool CheckTeamOpen()
        {
            XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
            return specificDocument.MyTeam != null && specificDocument.MyTeam.teamBrief.teamID != 0;
        }

        public bool CheckGuildOpen() => XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).bInGuild;

        public bool CheckDragonGuildOpen() => XDocuments.GetSpecificDocument<XDragonGuildDocument>(XDragonGuildDocument.uuID).IsInDragonGuild();

        public void RegistLinkSend(string content, System.Action onSend)
        {
            this.mLinkContent = content;
            this.mInputType = InputUIType.Linked;
            this.mOnSend = onSend;
            XSingleton<XDebug>.singleton.AddLog("length: ", content.Length.ToString(), " content:", content);
            this.uiBehaviour.m_Input.SetText(content);
        }

        private void DispatchLinkClick()
        {
            if (this.mOnSend != null)
                this.mOnSend();
            this.mInputType = InputUIType.Normal;
            this.ResetInput();
        }

        private void OnUIInputChanged(IXUIInput input)
        {
            if (this.mInputType != InputUIType.Linked || input.GetText().Length == this.mLinkContent.Length)
                return;
            this.mInputType = InputUIType.Normal;
            this.ResetInput();
        }

        private void OnUIInputSubmit(IXUIInput input)
        {
            if (Application.platform != RuntimePlatform.WindowsEditor)
                return;
            this.DoSendTextChat((IXUIButton)null);
        }

        public XChatDocument ChatDoc => XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);

        public int ChatIdIndex
        {
            get => this.m_ChatIdIndex;
            set => this.m_ChatIdIndex = value;
        }

        public bool IsInited => this.Inited;

        public XChatUIOP UIOP => this.m_UIOP;

        public ChatChannelType CurrentSpeakChannel
        {
            get => this.currentSpeakChannel;
            set => this.currentSpeakChannel = value;
        }

        public override string fileName => "GameSystem/ChatNewDlg";

        public string PrivateChatCurrName
        {
            get => this.m_sPrivateChatCurrName;
            set => this.m_sPrivateChatCurrName = value;
        }

        public SetEffectInfo Info
        {
            get
            {
                if (this.m_iSetEffectInfo == null)
                    this.m_iSetEffectInfo = new SetEffectInfo();
                return this.m_iSetEffectInfo;
            }
            set => this.m_iSetEffectInfo = value;
        }

        public override int group => 1;

        public uint worldSpeakTimes
        {
            get
            {
                XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
                if (specificDocument == null || specificDocument.PayMemberPrivilege == null)
                    return this._worldSpeadTimes;
                bool flag = specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
                int num = specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Court).ChatCount - specificDocument.PayMemberPrivilege.usedChatCount;
                return flag ? this._worldSpeadTimes + (uint)num : this._worldSpeadTimes;
            }
        }

        protected override void Init()
        {
            this._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
            this._doc.ChatView = this;
            this.InitTabs();
            for (int index = 0; index < 11; ++index)
            {
                ulong showChannelId = (ulong)this.showChannelIds[index];
                this.mCheckbox[index].RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.SelectChatChannel));
                this.mCheckbox[index].ID = showChannelId;
                if (this.showChannelIds[index] == this.activeChannelType)
                    this.mCheckbox[index].bChecked = true;
            }
            this.LoopInit();
            DlgBase<XOptionsView, XOptionsBehaviour>.singleton.OnOptionClose += new System.Action(this.RefreshVoiceBarStatus);
            this.mInputType = InputUIType.Normal;
            this.Inited = true;
        }

        public override void RegisterEvent()
        {
            this.uiBehaviour.m_ChangeToVoice.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnVoiceChatButton));
            this.uiBehaviour.m_ChangeToVoice.RegisterDragEventHandler(new ButtonDragEventHandler(this.OnVoiceButtonDrag));
            this.uiBehaviour.m_DoSendChat.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoSendTextChat));
            this.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
            this.uiBehaviour.m_btnAdd.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtmAddClick));
            this.uiBehaviour.m_GetFlowerBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetFlower));
            this.RegistFriendEvent();
            this.RegistGroupEvent();
            this.uiBehaviour.m_sprMail.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMailClick));
            this.uiBehaviour.m_sprSet.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSetClick));
            this.uiBehaviour.m_sprXinyue.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnXinyueClick));
            this.uiBehaviour.m_sprFriend.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnFriendsClick));
            this.uiBehaviour.m_chxAutoVoice.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnAutoVoiceClick));
            this.uiBehaviour.m_Input.RegisterChangeEventHandler(new InputChangeEventHandler(this.OnUIInputChanged));
            this.uiBehaviour.m_Input.RegisterSubmitEventHandler(new InputSubmitEventHandler(this.OnUIInputSubmit));
            this.uiBehaviour.m_sprTq.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMemberPrivilegeClick));
        }

        private void OnMemberPrivilegeClick(IXUISprite btn)
        {
            if (this.isFighting)
                return;
            DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
        }

        protected override void OnShow()
        {
            base.OnShow();
            this.SetDepth();
            this.cacheShow = true;
            this.ShowTabs();
            this.ShowBtns();
            this.ShowMailRedpoint();
            if (this.activeChannelType == ChatChannelType.Friends)
                DlgBase<XFriendsView, XFriendsBehaviour>.singleton.QueryRoleState();
            this.DoSelectChannel(this.activeChannelType);
            this.SwitchTab((object)this.activeChannelType);
            XSingleton<XChatIFlyMgr>.singleton.SetAutoPlayChannel(this.activeChannelType);
            this.ResetInput();
            this.uiBehaviour.m_sprXinyueRed.SetVisible(XSingleton<XGameSysMgr>.singleton.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GC_XiaoYueGuanJia));
            this.uiBehaviour.m_Flower.SetActive(false);
            if (!DlgBase<XTeamView, TabDlgBehaviour>.singleton.IsVisible())
                return;
            DlgBase<XTeamView, TabDlgBehaviour>.singleton.SetRelatedDlg((IXUIDlg)this);
        }

        protected override void OnHide()
        {
            this.ResetTabs();
            this.mInputType = InputUIType.Normal;
            this.mOnSend = (System.Action)null;
            XSingleton<XChatIFlyMgr>.singleton.SetAutoPlayChannel(ChatChannelType.DEFAULT);
            if (DlgBase<XTeamView, TabDlgBehaviour>.singleton.IsVisible())
                DlgBase<XTeamView, TabDlgBehaviour>.singleton.SetRelatedDlg((IXUIDlg)null);
            if (DlgBase<ChatAssistView, ChatAssistBehaviour>.singleton.IsVisible())
                DlgBase<ChatAssistView, ChatAssistBehaviour>.singleton.SetVisible(false, true);
            base.OnHide();
        }

        protected override void OnUnload()
        {
            this._doc = (XChatDocument)null;
            base.OnUnload();
        }

        public void TryCloseChat(IXUIDlg dlg)
        {
            if (!this.IsVisible() || !(dlg.fileName != this.fileName) || !dlg.isHideChat)
                return;
            DlgBase<XChatView, XChatBehaviour>.singleton.SetVisible(false, true);
        }

        public void TryShowChat(IXUIDlg dlg)
        {
            List<IXUIDlg> showedUi = XSingleton<UIManager>.singleton.GetShowedUI();
            if (!XSingleton<UIManager>.singleton.IsUIShowed() && showedUi.Count < 3 && dlg.fileName != this.fileName && this.cacheShow)
                this.SetVisible(true, true);
            if (!this.IsVisible())
                return;
            this.ShowMailRedpoint();
        }

        private void DoChatWith(ulong friendId)
        {
            this.ChatFriendId = friendId;
            this.activeChannelType = ChatChannelType.Friends;
            if (!this.IsVisible())
                this.SetVisibleWithAnimation(true, new DlgBase<XChatView, XChatBehaviour>.OnAnimationOver(this.DoChatRefresh));
            else
                this.DoChatRefresh();
        }

        public void DoChatRefresh()
        {
            ChatFriendData friendData = this._doc.FindFriendData(this.ChatFriendId);
            if (friendData == null)
                return;
            friendData.msgtime = DateTime.Now;
            this.SelectChatFriends((object)this.ChatFriendId);
        }

        public void SelectChatFriends(object obj)
        {
            this.ChatFriendId = (ulong)obj;
            this.activeChannelType = ChatChannelType.Friends;
            this.SwitchTab((object)ChatChannelType.Friends);
            this.RefreshFriendUI(XChatView.ChatFriendState.CHATS);
        }

        public void SelectChatTeam() => this.SwitchTab((object)ChatChannelType.Team);

        public void ShowMyChatVoiceInfo(ChatVoiceInfo info)
        {
            this.mChatInfo = new ChatInfo();
            this.mChatInfo.mChannelId = !info.isLocalPath ? info.channel + 1 : this.activeChannelType;
            this.mChatInfo.voice = info;
            this.mChatInfo.mSenderId = info.sendIndexId;
            this.mChatInfo.mSenderName = info.sendName;
            this.mChatInfo.mChatType = ChatType.SelfVoice;
            this.mChatInfo.mSenderVip = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID).VipLevel;
            this.mChatInfo.mServerProfession = (uint)XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession;
            this.mChatInfo.isSelfSender = true;
            this.mChatInfo.mTime = DateTime.Now;
            this.mChatInfo.isAudioPlayed = true;
            if (this.mChatInfo.mChannelId == ChatChannelType.Friends)
            {
                this.mChatInfo.mReceiverId = this.ChatFriendId;
                this.mChatInfo.mReceiverName = this.m_sPrivateChatCurrName;
            }
            this.mChatInfo.mContent = "";
            this._doc.ReceiveChatInfo(this.mChatInfo);
            if (!this.IsVisible())
                return;
            (this.mChatInfo.mUIObject.transform.FindChild("voice/content").GetComponent("XUILabelSymbol") as IXUILabelSymbol).InputText = "     ";
        }

        public bool CheckWorldSendMsg(
          bool isVoice,
          ButtonClickEventHandler okClickHandler = null,
          ChatChannelType channel = ChatChannelType.DEFAULT)
        {
            bool flag = true;
            if (okClickHandler == null)
                okClickHandler = new ButtonClickEventHandler(this.OKClickEventHandler);
            if (channel == ChatChannelType.DEFAULT)
                channel = this.activeChannelType;
            if (channel == ChatChannelType.World && this.worldSpeakTimes <= 0U && XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(51) < 1UL)
            {
                string[] strArray = XSingleton<XGlobalConfig>.singleton.GetValue("ChatItemCost").Split(XGlobalConfig.SequenceSeparator);
                ulong result = 1;
                ulong.TryParse(strArray[1], out result);
                DateTime now = DateTime.Now;
                int month = now.Month;
                now = DateTime.Now;
                int day = now.Day;
                int num1 = month + day;
                int num2 = PlayerPrefs.GetInt("chat_timestamp", 0);
                this.mIsVoice = isVoice;
                if (num2 == 0 || num2 != num1)
                {
                    DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
                    DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
                    string mainLabel = XStringDefineProxy.GetString("CHAT_BUY", (object)result);
                    string frLabel = XStringDefineProxy.GetString("CHAT_BUY_OK");
                    string secLabel = XStringDefineProxy.GetString("CHAT_BUY_CANCEL");
                    DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ShowNoTip(XTempTipDefine.OD_CHAT_WORLD);
                    DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(mainLabel, frLabel, secLabel);
                    DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(okClickHandler, new ButtonClickEventHandler(this.CheckSelect));
                }
                else
                {
                    int num3 = okClickHandler((IXUIButton)null) ? 1 : 0;
                }
                flag = false;
            }
            return flag;
        }

        public bool CheckSelect(IXUIButton select)
        {
            if (DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_CHAT_WORLD))
                PlayerPrefs.SetInt("chat_timestamp", DateTime.Now.Month + DateTime.Now.Day);
            if (DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.IsVisible())
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.DoClose((IXUIButton)null);
            return true;
        }

        private bool OKClickEventHandler(IXUIButton button)
        {
            this.CheckSelect(button);
            string[] strArray = XSingleton<XGlobalConfig>.singleton.GetValue("ChatItemCost").Split(XGlobalConfig.SequenceSeparator);
            ulong result1 = 7;
            ulong result2 = 1;
            ulong.TryParse(strArray[0], out result1);
            ulong.TryParse(strArray[1], out result2);
            if (XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(7) >= result2)
            {
                XSingleton<XDebug>.singleton.AddLog("buy lanniao msg send");
                XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
                if (this.mIsVoice)
                {
                    XSingleton<XChatIFlyMgr>.singleton.ResendLastWorldChat();
                }
                else
                {
                    this.SendChatContent(this.uiBehaviour.m_ChatText.GetText(), this.activeChannelType);
                    this.ResetInput();
                }
            }
            else
            {
                DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ShowBorad((ItemEnum)result1);
                this.ResetInput();
            }
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.DoCancel(button);
            return true;
        }

        public void ShowOtherChatVoiceInfo(ChatVoiceInfo info)
        {
            ChatInfo chatInfo = new ChatInfo();
            chatInfo.mChannelId = !info.isLocalPath ? info.channel : this.CurrentSpeakChannel;
            chatInfo.voice = info;
            chatInfo.mSenderId = info.sendIndexId;
            chatInfo.mSenderName = info.sendName;
            chatInfo.mChatType = ChatType.OtherVoice;
            chatInfo.isSelfSender = false;
            chatInfo.mContent = info.txt;
            chatInfo.mTime = DateTime.Now;
            if (chatInfo.mChannelId == ChatChannelType.Team)
                chatInfo.isAudioPlayed = true;
            XFriendData friendDataById = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDataById(chatInfo.mSenderId);
            if (friendDataById != null)
            {
                chatInfo.mSenderVip = friendDataById.viplevel;
                chatInfo.mServerProfession = friendDataById.profession;
            }
            else
            {
                chatInfo.mSenderVip = 0U;
                uint result = 1;
                chatInfo.mServerProfession = !uint.TryParse(info.sendProf, out result) ? 1U : result;
            }
            if (this._doc == null)
                this._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
            if (info.channel == ChatChannelType.Team && XSingleton<XChatIFlyMgr>.singleton.IsAutoPlayEnable)
                XSingleton<XChatIFlyMgr>.singleton.AddAutoPlayList(chatInfo);
            this._doc.ReceiveChatInfo(chatInfo);
        }

        public void PrivateChatTo(ChatFriendData data)
        {
            if (this._doc == null)
                this._doc = this.ChatDoc;
            XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
            if (xplayerData == null || (long)data.roleid == (long)xplayerData.RoleID)
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_NOT_SELF"), "fece00");
            else if (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_FORBIT_WORLD"), "fece00");
            }
            else
            {
                ChatFriendData friendData = this._doc.FindFriendData(data.roleid);
                if (friendData == null)
                    this._doc.ChatFriendList.Add(data);
                else
                    friendData.msgtime = DateTime.Now;
                this.DoChatWith(data.roleid);
            }
        }

        private bool IsContentValid(string content, ChatChannelType type)
        {
            if (content == XStringDefineProxy.GetString("CHAT_DEFAULT"))
                return false;
            content = content.Replace("{@", "").Replace("@}", "");
            string pattern1 = "[\\u4e00-\\u9fa5]";
            string str1 = Regex.Replace(content, pattern1, "aa", RegexOptions.IgnoreCase);
            if (this._doc == null)
            {
                this._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
                this._doc.ChatView = this;
            }
            uint length = this._doc.GetRawData(type).length;
            string str2 = str1.Trim();
            if (length != 0U && (long)str2.Length > (long)length)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_TOO_LONG"), "fece00");
                return false;
            }
            if (str2.Length == 0)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_TOO_SHORT"), "fece00");
                return false;
            }
            string pattern2 = "\\[[0-9a-fA-F]{6}\\]";
            string pattern3 = "\\[[a-fA-F\\-]{1}\\]";
            string pattern4 = "\\[[0-9a-fA-F]{2}\\]";
            if (!Regex.IsMatch(content, pattern2) && !Regex.IsMatch(content, pattern3) && !Regex.IsMatch(content, pattern4) && !content.Contains("[color=#"))
                return true;
            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_INVALID"), "fece00");
            return false;
        }

        public void SendVoiceChat(
          string content,
          ChatChannelType channelType,
          ulong audioid,
          float audiotime)
        {
            this.SendChatContent(content, channelType, audioid: audioid, audiotime: audiotime);
        }

        private string HandlerContent(string content)
        {
            content = content.Replace("[b]", "").Replace("[/b]", "").Replace("[\\b]", "");
            content = content.Replace("[i]", "").Replace("[/i]", "").Replace("[\\i]", "");
            content = content.Replace("[u]", "").Replace("[/u]", "").Replace("[\\u]", "");
            content = content.Replace("[s]", "").Replace("[/s]", "").Replace("[\\s]", "");
            content = content.Replace("[sub]", "").Replace("[/sub]", "").Replace("[\\sub]", "");
            content = content.Replace("[url=http", "").Replace("[/url]", "").Replace("[\\url]", "");
            if (content.IndexOf("{@") != -1)
            {
                string pattern = "\\{\\@[0-9]*[A-Za-z0-9_\\u4e00-\\u9fa5]*\\@\\}";
                MatchCollection matchCollection = Regex.Matches(content, pattern, RegexOptions.IgnoreCase);
                if (matchCollection != null)
                {
                    if (matchCollection.Count > 0)
                        content += "e@equip";
                    for (int i = 0; i < matchCollection.Count; ++i)
                    {
                        string oldValue = matchCollection[i].Value;
                        string str1 = oldValue.Replace("{@", "").Replace("@}", "");
                        int result1 = -1;
                        int.TryParse(str1.Split('_')[0], out result1);
                        if (result1 <= 0 || result1 - 1 >= this.chatContentItem.Count)
                        {
                            content = content.Replace(oldValue, str1.Replace(result1.ToString() + "_", ""));
                        }
                        else
                        {
                            string str2 = this.chatContentItem[result1 - 1].Replace(";", "");
                            int result2 = -1;
                            int.TryParse(str2.Split('_')[5], out result2);
                            if (result2 <= 0)
                                content = content.Replace(oldValue, str1.Replace(result1.ToString() + "_", ""));
                            else if (result1 != result2)
                            {
                                content = content.Replace(oldValue, str1.Replace(result1.ToString() + "_", ""));
                            }
                            else
                            {
                                string str3 = str2.Split('_')[4];
                                content = content.Replace(oldValue, "{@" + str3 + "@}");
                                content += this.chatContentItem[result1 - 1];
                            }
                        }
                    }
                }
            }
            content = content.IndexOf("\\\\") != 0 ? content.Replace("\\n", "/n").Replace("\\", "/") : (content.IndexOf("\\\\n") != 0 ? content.Substring(0, 2) + content.Substring(2, content.Length - 2).Replace("\\\\n", "//n").Replace("\\", "/") : content.Substring(0, 3) + content.Substring(3, content.Length - 3).Replace("\\\\n", "//n").Replace("\\", "/"));
            return XSingleton<XForbidWordMgr>.singleton.FilterForbidWord(content);
        }

        public void SendChatContent(
          string content,
          ChatChannelType channelType,
          bool selfReceive = true,
          List<ChatParam> param = null,
          bool bIsSystem = false,
          ulong audioid = 0,
          float audiotime = 0.0f,
          bool isRecruit = false,
          bool isDragonGuildRecruit = false)
        {
            XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
            if (!this.IsContentValid(content, channelType) || xplayerData == null)
                return;
            if (channelType == ChatChannelType.Friends && DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsBlock(this.ChatFriendId))
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_BLOCK_2"), "fece00");
            }
            else
            {
                content = this.HandlerContent(content);
                RpcC2M_chat rpcC2MChat = new RpcC2M_chat()
                {
                    oArg = {
            chatinfo = new KKSG.ChatInfo()
          }
                };
                rpcC2MChat.oArg.chatinfo.channel = (uint)channelType;
                if (channelType == ChatChannelType.Friends)
                {
                    rpcC2MChat.oArg.chatinfo.dest = new ChatDest();
                    rpcC2MChat.oArg.chatinfo.dest.roleid.Add(this.ChatFriendId);
                    ChatInfo chatInfo = new ChatInfo()
                    {
                        mSenderName = xplayerData.Name,
                        mSenderId = xplayerData.RoleID,
                        mReceiverId = this.ChatFriendId,
                        mReceiverName = this.UIOP.CurrChatFriendData == null ? "" : this.UIOP.CurrChatFriendData.name,
                        mReceiverVip = this.UIOP.CurrChatFriendData == null ? 1U : this.UIOP.CurrChatFriendData.viplevel,
                        mRecieverProfession = this.UIOP.CurrChatFriendData == null ? 1U : this.UIOP.CurrChatFriendData.profession,
                        mReciverPowerPoint = this.UIOP.CurrChatFriendData == null ? 0U : this.UIOP.CurrChatFriendData.powerpoint,
                        mContent = content,
                        mChannelId = ChatChannelType.Friends,
                        mChatType = ChatType.SelfText,
                        isSelfSender = true,
                        mAudioId = audioid,
                        mAudioTime = (uint)audiotime
                    };
                    if (DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsBlock(this.ChatFriendId))
                    {
                        XSingleton<UiUtility>.singleton.ShowSystemTip(DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetBlockFriendNameById(this.ChatFriendId) + XStringDefineProxy.GetString("CHAT_BAN_LIST"), "fece00");
                        return;
                    }
                }
                if (channelType == ChatChannelType.Group)
                {
                    rpcC2MChat.oArg.chatinfo.groupchatinfo = new GroupChatTeamInfo();
                    rpcC2MChat.oArg.chatinfo.groupchatinfo.groupchatID = DlgBase<XChatView, XChatBehaviour>.singleton.ChatGroupId;
                }
                rpcC2MChat.oArg.chatinfo.info = content;
                if (param != null)
                {
                    for (int index = 0; index < param.Count; ++index)
                        rpcC2MChat.oArg.chatinfo.param.Add(param[index]);
                }
                rpcC2MChat.oArg.chatinfo.param.Add(new ChatParam());
                rpcC2MChat.oArg.chatinfo.issystem = bIsSystem;
                rpcC2MChat.oArg.chatinfo.isRecruit = isRecruit;
                rpcC2MChat.oArg.chatinfo.audioUid = audioid;
                rpcC2MChat.oArg.chatinfo.audioLen = (double)audiotime >= 1000.0 ? (uint)audiotime : 1000U;
                rpcC2MChat.oArg.chatinfo.isDragonGuildRecruit = isDragonGuildRecruit;
                XSingleton<XClientNetwork>.singleton.Send((Rpc)rpcC2MChat);
            }
        }

        public void SendExternalFriendChat(
          string content,
          ChatInfo recvInfo,
          ulong audioid = 0,
          float audiotime = 0.0f,
          List<ChatParam> param = null)
        {
            if (DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsBlock(recvInfo.mReceiverId))
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_BLOCK_2"), "fece00");
            }
            else
            {
                this.HandlerContent(content);
                RpcC2M_chat rpcC2MChat = new RpcC2M_chat()
                {
                    oArg = {
            chatinfo = new KKSG.ChatInfo()
          }
                };
                rpcC2MChat.oArg.chatinfo.channel = 3U;
                rpcC2MChat.oArg.chatinfo.dest = new ChatDest();
                rpcC2MChat.oArg.chatinfo.dest.roleid.Add(recvInfo.mReceiverId);
                ChatInfo chatInfo = new ChatInfo();
                chatInfo.mSenderName = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
                chatInfo.mSenderId = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
                chatInfo.mReceiverId = recvInfo.mReceiverId;
                chatInfo.mReceiverName = recvInfo.mReceiverName;
                chatInfo.mReceiverVip = recvInfo.mReceiverVip;
                chatInfo.mRecieverProfession = recvInfo.mRecieverProfession;
                chatInfo.mReciverPowerPoint = recvInfo.mReciverPowerPoint;
                chatInfo.mContent = content;
                chatInfo.mChannelId = ChatChannelType.Friends;
                chatInfo.mChatType = ChatType.SelfText;
                chatInfo.isSelfSender = true;
                chatInfo.mAudioId = audioid;
                chatInfo.mAudioTime = (uint)audiotime;
                this.ProcessText(chatInfo, param);
                if (this._doc != null)
                    this._doc.ReceiveChatInfo(chatInfo);
                rpcC2MChat.oArg.chatinfo.info = content;
                if (param != null)
                {
                    for (int index = 0; index < param.Count; ++index)
                        rpcC2MChat.oArg.chatinfo.param.Add(param[index]);
                }
                rpcC2MChat.oArg.chatinfo.param.Add(new ChatParam());
                rpcC2MChat.oArg.chatinfo.issystem = false;
                rpcC2MChat.oArg.chatinfo.isRecruit = false;
                rpcC2MChat.oArg.chatinfo.audioUid = audioid;
                rpcC2MChat.oArg.chatinfo.audioLen = (double)audiotime >= 1000.0 ? (uint)audiotime : 1000U;
                XSingleton<XClientNetwork>.singleton.Send((Rpc)rpcC2MChat);
            }
        }

        private void ProcessText(ChatInfo chatInfo, List<ChatParam> chatParam = null)
        {
            if (chatParam == null)
                return;
            for (int index1 = 0; index1 < chatParam.Count; ++index1)
            {
                ChatParam chatParam1 = chatParam[index1];
                if (chatParam1 != null)
                {
                    for (int index2 = 0; index2 < chatInfo.mContent.Length; ++index2)
                    {
                        if (chatInfo.mContent[index2] == '$')
                        {
                            string str1 = "";
                            if (chatParam1.link != null && chatInfo.mContent[index2 + 1] == 'L')
                                str1 = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID).ParseLink(chatParam1);
                            string str2 = chatInfo.mContent.Substring(0, index2);
                            string str3 = chatInfo.mContent.Substring(index2 + 2, chatInfo.mContent.Length - (index2 + 2));
                            chatInfo.mContent = str2 + str1 + str3;
                            break;
                        }
                    }
                }
            }
        }

        public void AddChat(
          string content,
          ChatChannelType type,
          List<ChatParam> param = null,
          bool bIsSystem = false)
        {
            this.SendChatContent(content, type, param: param, bIsSystem: bIsSystem);
        }

        public void SetActiveChannel(ChatChannelType type)
        {
            this.activeChannelType = type;
            if (!this.IsVisible())
                return;
            this.SwitchTab((object)type);
        }

        public void ShowChannel(ChatChannelType type)
        {
            this.SetVisibleWithAnimation(true, (DlgBase<XChatView, XChatBehaviour>.OnAnimationOver)null);
            int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.SwitchTab), (object)type);
        }

        public void SwitchTab(object obj)
        {
            int num = (int)obj;
            for (int index = 0; index < 11; ++index)
            {
                if ((ChatChannelType)num == this.showChannelIds[index])
                    this.mCheckbox[index].bChecked = true;
            }
        }

        public void RefeshWorldSpeakTimes()
        {
            if ((UnityEngine.Object)this.uiBehaviour != (UnityEngine.Object)null && this.uiBehaviour.m_lblWorldTimes != null)
            {
                this.uiBehaviour.m_lblWorldTimes.SetVisible(this.worldSpeakTimes > 0U);
                if (this.worldSpeakTimes > 0U && this.activeChannelType == ChatChannelType.World)
                {
                    this.uiBehaviour.m_worldTween.ResetTween(true);
                    this.uiBehaviour.m_worldTween.PlayTween(true);
                }
                XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
                bool flag = specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
                PayMemberPrivilege payMemberPrivilege = specificDocument.PayMemberPrivilege;
                if (flag && payMemberPrivilege != null && payMemberPrivilege.usedChatCount < specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Court).ChatCount)
                    this.uiBehaviour.m_lblWorldTimes.SetText(XStringDefineProxy.GetString("CHAT_WORLD2", (object)("[ffff00]" + (object)this.worldSpeakTimes + "[-]")));
                else
                    this.uiBehaviour.m_lblWorldTimes.SetText(XStringDefineProxy.GetString("CHAT_WORLD2", (object)this.worldSpeakTimes));
            }
            if (!((UnityEngine.Object)this.uiBehaviour != (UnityEngine.Object)null) || this.uiBehaviour.m_ChatTextCost == null)
                return;
            this.uiBehaviour.m_ChatTextCost.SetText(this.worldSpeakTimes > 0U ? XStringDefineProxy.GetString("DRAW_FREE") : XStringDefineProxy.GetString("DRAW_BIRD"));
        }

        public void DoSelectChannel(ChatChannelType type)
        {
            this.activeChannelType = type;
            this.ShowTabFriendRed();
            this.RefeshWorldSpeakTimes();
            this.uiBehaviour.m_objFriendBar.SetActive(type == ChatChannelType.Friends);
            this.uiBehaviour.m_objGroupBar.SetActive(type == ChatChannelType.Group);
            this.uiBehaviour.m_lblWorldTimes.SetVisible(type == ChatChannelType.World && this.worldSpeakTimes > 0U);
            XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
            bool flag = specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
            this.uiBehaviour.m_sprTq.gameObject.SetActive(type == ChatChannelType.World && this.worldSpeakTimes > 0U);
            this.uiBehaviour.m_sprTq.SetSprite(specificDocument.GetMemberPrivilegeIcon(MemberPrivilege.KingdomPrivilege_Court));
            this.uiBehaviour.m_lblPriviledge.SetText(XStringDefineProxy.GetString("CHAT_PRIVILEDGE", (object)specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Court).ChatCount));
            this.uiBehaviour.m_sprTq.SetGrey(flag);
            this.uiBehaviour.m_lblPriviledge.SetEnabled(flag);
            this.uiBehaviour.m_sprFriend.SetAlpha(XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall ? 1f : 0.0f);
            this.RefreshVoiceBarStatus();
            this.ShowTextboard(type);
            this.m_uiBehaviour.m_ChatTextCost.SetVisible(type == ChatChannelType.World);
            this.SetLoopActive(type);
            switch (type)
            {
                case ChatChannelType.Friends:
                    this.RefreshFriendUI(this.friendState);
                    break;
                case ChatChannelType.Group:
                    this.groupState = XChatView.ChatGroupState.GROUPS;
                    this.RefreshGrouplist();
                    break;
                default:
                    this.RefreshLoopScroll(type);
                    break;
            }
            XSingleton<XChatIFlyMgr>.singleton.SetAutoPlayChannel(type);
        }

        private void RefreshVoiceBarStatus()
        {
            if (!this.IsVisible())
                return;
            this.uiBehaviour.m_btns.SetActive(this.IsVoicebarShow());
            this.uiBehaviour.m_lblAutoVoice.SetText(XStringDefineProxy.GetString("CHAT_AutoPlay", (object)this.ChatDoc.GetRawData(this.activeChannelType).name));
            this.uiBehaviour.m_chxAutoVoice.bChecked = this.GetAutoVoiceSetting(this.activeChannelType);
        }

        private bool IsVoicebarShow()
        {
            bool flag = false;
            int index = 0;
            for (int length = this.showVoiceBar.Length; index < length; ++index)
            {
                if (this.activeChannelType == this.showVoiceBar[index])
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        private bool GetAutoVoiceSetting(ChatChannelType type) => Convert.ToBoolean(XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID).GetValue(this.Channel2OptionDef(type)));

        private void SetAutoVoice(ChatChannelType type, bool val)
        {
            XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
            specificDocument.SetValue(this.Channel2OptionDef(type), val ? 1 : 0);
            specificDocument.SaveSetting();
        }

        private XOptionsDefine Channel2OptionDef(ChatChannelType type)
        {
            switch (type)
            {
                case ChatChannelType.ZeroChannel:
                    return XOptionsDefine.OD_RADIO_WIFI;
                case ChatChannelType.World:
                    return XOptionsDefine.OD_RADIO_WORLD;
                case ChatChannelType.Guild:
                    return XOptionsDefine.OD_RADIO_PUBLIC;
                case ChatChannelType.Friends:
                    return XOptionsDefine.OD_RADIO_PRIVATE;
                case ChatChannelType.Team:
                    return XOptionsDefine.OD_RADIO_TEAM;
                case ChatChannelType.Camp:
                    return XOptionsDefine.OD_RADIO_CAMP;
                case ChatChannelType.Curr:
                    return XOptionsDefine.OD_RADIO_AUTO_PALY;
                default:
                    return XOptionsDefine.OD_RADIO_WORLD;
            }
        }

        private string GetPlayerNameById(ulong uid) => DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendNameById(uid);

        public void OnRefreshGetFlowerInfo()
        {
            if (!this.IsVisible())
                return;
            this.uiBehaviour.m_GetFlowerLeftTime.gameObject.SetActive(this._doc.getFlowerLeftTime > 0);
            this.uiBehaviour.m_GetFlowerBtn.SetEnable(this._doc.getFlowerLeftTime == 0);
            this.uiBehaviour.m_FlowerEff.SetActive(this._doc.getFlowerLeftTime == 0 && this._doc.canGetFlower);
            if (!this._doc.canGetFlower)
                this.uiBehaviour.m_GetFlowerBtn.SetGrey(this._doc.canGetFlower);
            if (this._doc.getFlowerLeftTime == 0 && this._doc.canGetFlower)
                this.uiBehaviour.m_FlowerTween.PlayTween(true);
            else
                this.uiBehaviour.m_FlowerTween.StopTween();
            if (this._doc.getFlowerLeftTime > 0)
            {
                this.uiBehaviour.m_GetFlowerLeftTime.SetText(string.Format("{0}", (object)XSingleton<UiUtility>.singleton.TimeFormatString(this._doc.getFlowerLeftTime, 2, 3, 4, false, true)));
                XSingleton<XTimerMgr>.singleton.KillTimer(this._GetFlowerCDToken);
                this._GetFlowerCDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.GetFlowerCDUpdate), (object)null);
            }
            this.UpdateFlowerCount();
        }

        private void GetFlowerCDUpdate(object o)
        {
            this._doc.getFlowerLeftTime = (int)XSingleton<XGameSysMgr>.singleton.GetFlowerRemainTime;
            this.OnRefreshGetFlowerInfo();
        }

        private bool OnGetFlower(IXUIButton go)
        {
            if (this._doc.canGetFlower)
                this._doc.ReqGetFlower();
            else
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FLOWER_CHATDLG_MAX_TIMES_ERR"), "fece00");
            return true;
        }

        private void UpdateFlowerCount()
        {
            int itemid = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GetFlowerTime").Split(XGlobalConfig.SequenceSeparator)[0]);
            this.uiBehaviour.m_FlowerOwnCount.SetText(string.Format(XStringDefineProxy.GetString("FLOWER_CHATDLG_OWN_COUNT"), (object)XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(itemid).ToString()));
        }

        public bool OnCloseClicked(IXUIButton sp)
        {
            this.cacheShow = false;
            this.SetVisibleWithAnimation(false, (DlgBase<XChatView, XChatBehaviour>.OnAnimationOver)null);
            DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RefreshUI();
            return true;
        }

        private bool OnBtmAddClick(IXUIButton btn)
        {
            DlgBase<ChatAssistView, ChatAssistBehaviour>.singleton.Show(new ChatInputStringBack(this.OnAddSelect), ChatAssetType.EMOTION);
            return true;
        }

        private void OnSetClick(IXUISprite spr)
        {
            if (XSingleton<XSceneMgr>.singleton.IsPVPScene() || XSingleton<XSceneMgr>.singleton.IsPVEScene())
                return;
            DlgBase<XOptionsView, XOptionsBehaviour>.singleton.prefabTab = OptionsTab.VoiceTab;
            DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XOptionsView, XOptionsBehaviour>.OnAnimationOver)null);
        }

        public void OnMailClick(IXUISprite sp) => DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Mail_System);

        private void OnXinyueClick(IXUISprite spr)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            XSingleton<UiUtility>.singleton.CloseSysAndNoticeServer((uint)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GC_XiaoYueGuanJia));
            this.uiBehaviour.m_sprXinyueRed.SetVisible(false);
            string str1 = Application.platform == RuntimePlatform.Android ? "1" : "0";
            string str2 = string.Format("{0}?game_id={1}&opencode={2}&sig={3}&timestamp={4}&role_id={5}&partition_id={6}&plat_id={7}", (object)XSingleton<XGlobalConfig>.singleton.GetValue("XiaoYueUrl"), (object)XSingleton<XGlobalConfig>.singleton.GetValue("XiaoYueGameID"), (object)XSingleton<XClientNetwork>.singleton.OpenCode, (object)XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetMD5(string.Format("{0}{1}", (object)XSingleton<XClientNetwork>.singleton.MSDKKey, (object)XSingleton<UiUtility>.singleton.GetTimeStamp())), (object)XSingleton<UiUtility>.singleton.GetTimeStamp(), (object)XSingleton<UiUtility>.singleton.GetRoleId(), (object)XSingleton<XClientNetwork>.singleton.ServerID, (object)str1);
            XSingleton<XDebug>.singleton.AddLog("url = " + str2);
            dictionary["url"] = str2;
            dictionary["screendir"] = "SENSOR";
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
        }

        private void OnFriendsClick(IXUISprite spr) => DlgBase<XFriendsView, XFriendsBehaviour>.singleton.SetVisible(true, true);

        private bool OnAutoVoiceClick(IXUICheckBox box)
        {
            this.SetAutoVoice(this.activeChannelType, box.bChecked);
            return true;
        }

        private void OnAddSelect(string motionstr)
        {
            string text = this.uiBehaviour.m_ChatInput.GetText();
            this.uiBehaviour.m_ChatInput.SetText(text + motionstr);
            if (this.uiBehaviour.m_ChatInput.GetText().Length - text.Length >= motionstr.Length)
                return;
            this.uiBehaviour.m_ChatInput.SetText(text);
        }

        public bool DoSendTextChat(IXUIButton sp)
        {
            if (this.mInputType == InputUIType.Normal)
            {
                if (this.activeChannelType == ChatChannelType.Guild)
                {
                    if (!this.CheckGuildOpen())
                    {
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_NOT_IN_GUILD"), "fece00");
                        this.ResetInput();
                        return false;
                    }
                }
                else if (this.activeChannelType == ChatChannelType.Partner)
                {
                    if (!this.CheckDragonGuildOpen())
                    {
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_DG_NOT_IN_GUILD"), "fece00");
                        this.ResetInput();
                        return false;
                    }
                }
                else if (this.activeChannelType == ChatChannelType.Team)
                {
                    if (!this.CheckTeamOpen())
                    {
                        XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_NOT_IN_TEAM"), "fece00");
                        this.ResetInput();
                        return false;
                    }
                }
                else if (this.activeChannelType == ChatChannelType.World)
                {
                    if (!this.CheckWorldSendMsg(false))
                        return false;
                }
                else if (this.activeChannelType == ChatChannelType.Friends && this.ChatFriendId == 0UL)
                {
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_NOT_HAVE_FRIEND"), "fece00");
                    this.ResetInput();
                    return false;
                }
                string text = this.uiBehaviour.m_ChatText.GetText();
                if (!XSingleton<UiUtility>.singleton.IsSystemExpress(text))
                    this.SendChatContent(text, this.activeChannelType);
                this.ResetInput();
            }
            else if (this.mInputType == InputUIType.Linked)
                this.DispatchLinkClick();
            return true;
        }

        private void ResetInput()
        {
            if (!this.IsVisible())
                return;
            this.uiBehaviour.m_ChatText.SetText("");
            this.uiBehaviour.m_Input.SetText("");
            this.uiBehaviour.m_Input.SetDefault(XStringDefineProxy.GetString("CHAT_DEFAULT"));
        }

        public void OnVoiceButtonDrag(IXUIButton sp, Vector2 delta)
        {
            this.m_DragDistance += delta;
            this.m_CancelRecord = (double)this.m_DragDistance.magnitude >= 100.0;
        }

        public void OnVoiceChatButton(IXUIButton sp, bool state)
        {
            if (state)
            {
                this.m_CancelRecord = false;
                this.m_DragDistance = Vector2.zero;
                this.m_uiBehaviour.m_SpeakEff.SetActive(true);
                this.StartRecord();
            }
            else
            {
                this.m_uiBehaviour.m_SpeakEff.SetActive(false);
                if (XChatDocument.UseApollo)
                    XSingleton<XChatApolloMgr>.singleton.StopRecord(this.m_CancelRecord);
                else
                    XSingleton<XChatIFlyMgr>.singleton.StopRecord(this.m_CancelRecord);
                this.m_CancelRecord = false;
            }
        }

        private void StartRecord()
        {
            if (XChatDocument.UseApollo)
                XSingleton<XChatApolloMgr>.singleton.StartRecord(callback: new EndRecordCallBack(this.AutoQuitRecord));
            else
                XSingleton<XChatIFlyMgr>.singleton.StartRecord(callback: new EndRecordCallBack(this.AutoQuitRecord));
        }

        private void AutoQuitRecord()
        {
        }

        private bool SelectChatChannel(IXUICheckBox iXUICheckBox)
        {
            ChatChannelType id = (ChatChannelType)iXUICheckBox.ID;
            if (iXUICheckBox.bChecked)
                this.DoSelectChannel(id);
            return true;
        }

        public void OnAddFriend(IXUILabel sp) => DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(this.ChatFriendId);

        private void OnStopAudioRecord(ChatInfo chatinfo)
        {
            if (this._doc == null)
            {
                this._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
                this._doc.ChatView = this;
            }
            ChatVoiceInfo voice = chatinfo.voice;
            if (voice == null)
                return;
            ChatChannelType activeChannelType = this.activeChannelType;
            voice.channel = activeChannelType;
            if (activeChannelType == ChatChannelType.Friends)
            {
                ulong roleId = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
                this.PrivateChatCurrName = this.GetPlayerNameById(this.ChatFriendId) + "_" + this.ChatFriendId.ToString();
            }
            else
            {
                DateTime now = DateTime.Now;
                uint num = 0;
                if (activeChannelType == ChatChannelType.World)
                    num = 60U;
                int index = (int)(activeChannelType - 1);
                if ((now - this.m_lastChatTime[index]).TotalSeconds > (double)num)
                    this.m_lastChatTime[(int)(activeChannelType - 1)] = DateTime.Now;
                this.ShowMyChatVoiceInfo(voice);
            }
            this.OnStartVoiceCD();
        }

        private void OnRefreshChatTextRecognize(ChatInfo info)
        {
            if (this._doc == null)
                return;
            this._doc.OnReceiveChatSmallInfo(info);
        }

        public void OnStartVoiceCD()
        {
        }

        public enum ChatGroupState
        {
            GROUPS,
            CHATS,
        }

        public enum ChatFriendState
        {
            FRIENDS,
            CHATS,
        }
    }
}
