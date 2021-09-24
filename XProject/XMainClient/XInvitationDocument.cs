

using KKSG;
using System.Collections.Generic;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XInvitationDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("InvitationDocument");
        public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
        private static NoticeTable m_NoticeTable = new NoticeTable();
        private XInvitationDocument.InvitationChatLinkData m_ChatLinkData = new XInvitationDocument.InvitationChatLinkData();
        private static int mLiveID = 0;
        private static int mType = 1;

        public override uint ID => XInvitationDocument.uuID;

        public static void Execute(OnLoadedCallback callback = null)
        {
            XInvitationDocument.AsyncLoader.AddTask("Table/Notice", (CVSReader)XInvitationDocument.m_NoticeTable);
            XInvitationDocument.AsyncLoader.Execute(callback);
        }

        public NoticeTable.RowData GetNoticeData(NoticeType type) => XInvitationDocument.m_NoticeTable.GetByid(this.ToID(type));

        public NoticeTable.RowData GetNoticeData(uint id) => XInvitationDocument.m_NoticeTable.GetByid(id);

        private uint ToID(NoticeType type) => (uint)XFastEnumIntEqualityComparer<NoticeType>.ToInt(type);

        private bool _IsOpenSys(NoticeType type) => NoticeType.NT_OPENSYS_BEGIN <= type && type < NoticeType.NT_OPENSYS_END;

        private void _SendMessage(
          uint channel,
          string content,
          List<ChatParam> param,
          bool bIsSystem = true,
          bool isRecruit = false,
          bool isDragonGuildRecruit = false)
        {
            if (channel == 1U)
            {
                this.m_ChatLinkData.Reset();
                this.m_ChatLinkData.channel = (ChatChannelType)channel;
                this.m_ChatLinkData.content = content;
                this.m_ChatLinkData.param = param;
                this.m_ChatLinkData.bIsSystem = bIsSystem;
                if (!DlgBase<XChatView, XChatBehaviour>.singleton.CheckWorldSendMsg(false, new ButtonClickEventHandler(this._RealSendMsg), ChatChannelType.World))
                    return;
                DlgBase<XChatView, XChatBehaviour>.singleton.SendChatContent(content, (ChatChannelType)channel, param: param, bIsSystem: bIsSystem, isRecruit: isRecruit, isDragonGuildRecruit: isDragonGuildRecruit);
            }
            else
                DlgBase<XChatView, XChatBehaviour>.singleton.SendChatContent(content, (ChatChannelType)channel, param: param, bIsSystem: bIsSystem, isRecruit: isRecruit, isDragonGuildRecruit: isDragonGuildRecruit);
        }

        private bool _RealSendMsg(IXUIButton btn)
        {
            DlgBase<XChatView, XChatBehaviour>.singleton.SendChatContent(this.m_ChatLinkData.content, this.m_ChatLinkData.channel, param: this.m_ChatLinkData.param, bIsSystem: this.m_ChatLinkData.bIsSystem);
            this.m_ChatLinkData.Reset();
            return DlgBase<XChatView, XChatBehaviour>.singleton.CheckSelect(btn);
        }

        public void SendGuildInvitation()
        {
            XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
            if (!specificDocument.CheckInGuild())
                return;
            NoticeTable.RowData noticeData = this.GetNoticeData(NoticeType.NT_INVITE_GUILD);
            if (noticeData == null)
                return;
            List<ChatParam> chatParamList = new List<ChatParam>();
            ChatParam chatParam1 = new ChatParam()
            {
                guild = new ChatParamGuild()
            };
            chatParam1.guild.guildid = specificDocument.UID;
            chatParam1.guild.guildname = specificDocument.BasicData.guildName;
            ChatParam chatParam2 = new ChatParam()
            {
                link = new ChatParamLink()
            };
            chatParam2.link.id = noticeData.linkparam;
            chatParam2.link.content = noticeData.linkcontent;
            chatParam2.guild = chatParam1.guild;
            chatParamList.Add(chatParam1);
            chatParamList.Add(chatParam2);
            this._SendMessage((uint)noticeData.channel, string.Format(noticeData.info, (object)specificDocument.BasicData.guildName), chatParamList, isRecruit: true);
        }

        public void SendDragonGuildInvitation()
        {
            XDragonGuildDocument doc = XDragonGuildDocument.Doc;
            if (!doc.IsInDragonGuild())
                return;
            NoticeTable.RowData noticeData = this.GetNoticeData(NoticeType.NT_INVITE_DRAGON_GUILD);
            if (noticeData == null)
                return;
            List<ChatParam> chatParamList = new List<ChatParam>();
            ChatParam chatParam1 = new ChatParam()
            {
                dragonguild = new ChatParamDragonGuild()
            };
            chatParam1.dragonguild.dragonguildId = doc.UID;
            chatParam1.dragonguild.dragonguildname = doc.BaseData.dragonGuildName;
            ChatParam chatParam2 = new ChatParam()
            {
                link = new ChatParamLink()
            };
            chatParam2.link.id = noticeData.linkparam;
            chatParam2.link.content = noticeData.linkcontent;
            chatParam2.dragonguild = chatParam1.dragonguild;
            chatParamList.Add(chatParam1);
            chatParamList.Add(chatParam2);
            this._SendMessage((uint)noticeData.channel, string.Format(noticeData.info, (object)doc.BaseData.dragonGuildName), chatParamList, isDragonGuildRecruit: true);
        }

        public void SendSpectateInvitation(
          uint noticeid,
          uint liveID,
          LiveType liveType,
          params object[] args)
        {
            NoticeTable.RowData noticeData = this.GetNoticeData(noticeid);
            if (noticeData == null)
                return;
            List<ChatParam> chatParamList = new List<ChatParam>();
            ChatParam chatParam = new ChatParam()
            {
                link = new ChatParamLink()
            };
            chatParam.link.id = noticeData.linkparam;
            chatParam.link.content = noticeData.linkcontent;
            chatParam.spectate = new ChatParamSpectate();
            chatParam.spectate.liveid = liveID;
            chatParam.spectate.livetype = (uint)liveType;
            chatParamList.Add(chatParam);
            this._SendMessage((uint)DlgBase<XChatView, XChatBehaviour>.singleton.activeChannelType, string.Format(noticeData.info, args), chatParamList);
        }

        public string GetSpectateLinkString(uint noticeid, params object[] args)
        {
            NoticeTable.RowData noticeData = this.GetNoticeData(noticeid);
            return noticeData == null ? string.Empty : string.Format(noticeData.info, args).Replace("$L", XSingleton<XCommon>.singleton.StringCombine("[56eaef][u]", noticeData.linkcontent, "[/u][-]"));
        }

        public void SendGuildInvitationPrivate()
        {
            XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
            if (!specificDocument.CheckInGuild())
                return;
            NoticeTable.RowData noticeData = this.GetNoticeData(NoticeType.NT_INVITE_GUILD_PRIVATE);
            if (noticeData == null)
                return;
            List<ChatParam> chatParamList = new List<ChatParam>();
            ChatParam chatParam1 = new ChatParam()
            {
                role = new ChatParamRole()
            };
            chatParam1.role.uniqueid = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
            chatParam1.role.name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
            chatParam1.role.profession = XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
            ChatParam chatParam2 = new ChatParam()
            {
                guild = new ChatParamGuild()
            };
            chatParam2.guild.guildid = specificDocument.UID;
            chatParam2.guild.guildname = specificDocument.BasicData.guildName;
            ChatParam chatParam3 = new ChatParam()
            {
                link = new ChatParamLink()
            };
            chatParam3.link.id = noticeData.linkparam;
            chatParam3.link.content = noticeData.linkcontent;
            chatParam3.guild = chatParam2.guild;
            chatParamList.Add(chatParam1);
            chatParamList.Add(chatParam2);
            chatParamList.Add(chatParam3);
            this._SendMessage((uint)noticeData.channel, string.Format(noticeData.info, (object)XSingleton<XAttributeMgr>.singleton.XPlayerData.Name, (object)specificDocument.BasicData.guildName), chatParamList);
        }

        public void SendTeamInvitation(NoticeType teamType, uint teamid, uint expid, string expName)
        {
            NoticeTable.RowData noticeData = this.GetNoticeData(teamType);
            if (noticeData == null)
                return;
            List<ChatParam> chatParamList = new List<ChatParam>();
            ChatParam chatParam = new ChatParam()
            {
                team = new ChatParamTeam()
            };
            chatParam.team.teamid = teamid;
            chatParam.team.expeditionid = expid;
            chatParam.link = new ChatParamLink();
            chatParam.link.id = noticeData.linkparam;
            chatParam.link.content = noticeData.linkcontent;
            chatParamList.Add(chatParam);
            this._SendMessage((uint)noticeData.channel, string.Format(noticeData.info, (object)expName), chatParamList);
        }

        public string GetOpenSysLinkString(NoticeType noticeType, params object[] args)
        {
            NoticeTable.RowData byid = XInvitationDocument.m_NoticeTable.GetByid((uint)XFastEnumIntEqualityComparer<NoticeType>.ToInt(noticeType));
            return byid == null ? string.Empty : string.Format(byid.info, args).Replace("$L", XSingleton<XCommon>.singleton.StringCombine("[56eaef][u]", byid.linkcontent, "[/u][-]"));
        }

        public void SendOpenSysInvitation(NoticeType noticeType, params ulong[] param)
        {
            NoticeTable.RowData byid = XInvitationDocument.m_NoticeTable.GetByid((uint)XFastEnumIntEqualityComparer<NoticeType>.ToInt(noticeType));
            if (byid == null)
                return;
            List<ChatParam> paramList = XInvitationDocument.GetParamList(byid, param);
            int channel = byid.channel;
            if (channel == -9999)
                channel = XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(DlgBase<XChatView, XChatBehaviour>.singleton.activeChannelType);
            this._SendMessage((uint)channel, byid.info, paramList);
        }

        public void SendOpenSysInvitation(XSysDefine sys, params ulong[] param)
        {
            NoticeTable.RowData noticeData = this.GetNoticeData(sys);
            if (noticeData == null)
                return;
            List<ChatParam> paramList = XInvitationDocument.GetParamList(noticeData, param);
            this._SendMessage((uint)noticeData.channel, noticeData.info, paramList);
        }

        public void SendActivityInvitation(XSysDefine sys, ulong param = 0, bool self = true)
        {
            NoticeTable.RowData noticeData = this.GetNoticeData(sys);
            if (noticeData == null)
                return;
            List<ChatParam> paramList = XInvitationDocument.GetParamList(noticeData, param);
            DlgBase<XChatView, XChatBehaviour>.singleton.SendChatContent(noticeData.info, (ChatChannelType)noticeData.channel, self, paramList, true);
        }

        public static List<ChatParam> GetParamList(
          NoticeTable.RowData data,
          params ulong[] param)
        {
            List<ChatParam> chatParamList = new List<ChatParam>();
            ChatParam chatParam = new ChatParam()
            {
                link = new ChatParamLink()
            };
            chatParam.link.id = data.linkparam;
            chatParam.link.content = data.linkcontent;
            if (param != null)
            {
                for (int index = 0; index < param.Length; ++index)
                    chatParam.link.param.Add(param[index]);
            }
            chatParamList.Add(chatParam);
            return chatParamList;
        }

        public NoticeTable.RowData GetNoticeData(XSysDefine sys)
        {
            NoticeTable.RowData rowData = (NoticeTable.RowData)null;
            uint num = 0;
            while ((long)num < (long)XInvitationDocument.m_NoticeTable.Table.Length)
            {
                rowData = XInvitationDocument.m_NoticeTable.Table[(int)num];
                if ((XSysDefine)rowData.linkparam != sys || !this._IsOpenSys((NoticeType)rowData.id))
                {
                    ++num;
                    rowData = (NoticeTable.RowData)null;
                }
                else
                    break;
            }
            return rowData;
        }

        public string ParseLink(ChatParam param)
        {
            if (param.link == null)
                return "";
            string content = param.link.content;
            if (param.team != null)
                return XLabelSymbolHelper.FormatTeam(content, (int)param.team.teamid, param.team.expeditionid);
            if (param.guild != null)
                return XLabelSymbolHelper.FormatGuild(content, param.guild.guildid);
            if (param.dragonguild != null)
                return XLabelSymbolHelper.FormatDragonGuild(content, param.dragonguild.dragonguildname);
            return param.spectate != null ? XLabelSymbolHelper.FormatSpectate(content, (int)param.spectate.liveid, (int)param.spectate.livetype) : XLabelSymbolHelper.FormatUI(content, (ulong)param.link.id, param.link.param);
        }

        public static void OnUIHyperLinkClick(string param)
        {
            if (DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded())
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NOT_IN_HALL_SPECTATE"), "fece00");
            else if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall)
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NOT_IN_HALL_STAGE"), "fece00");
            else if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_FAMILYGARDEN && XHomeCookAndPartyDocument.Doc.CurBanquetID > 0U)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("HomeFeasting"), "fece00");
            }
            else
            {
                ulong sysid = 0;
                List<ulong> sysParamList = new List<ulong>();
                if (!XLabelSymbolHelper.ParseUIParam(param, ref sysid, ref sysParamList))
                    return;
                XSingleton<XDebug>.singleton.AddLog("UI link clicked: ", param);
                if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened((XSysDefine)sysid))
                {
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SYSTEM_NOT_OPEN"), "fece00");
                }
                else
                {
                    switch ((XSysDefine)sysid)
                    {
                        case XSysDefine.XSys_Personal_Career:
                            DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.OpenOtherPush(sysParamList);
                            break;
                        case XSysDefine.XSys_Home_Feast:
                            if (sysParamList.Count == 1)
                            {
                                string name = "";
                                if ((long)sysParamList[0] == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.EntityID)
                                {
                                    name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
                                }
                                else
                                {
                                    XFriendData friendDataById = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDataById(sysParamList[0]);
                                    if (friendDataById != null)
                                        name = friendDataById.name;
                                }
                                HomeMainDocument.Doc.ReqEnterHomeScene(sysParamList[0], name);
                                break;
                            }
                            break;
                        case XSysDefine.XSys_Wedding:
                            if (sysParamList.Count == 1)
                            {
                                XWeddingDocument.Doc.WeddingInviteOperate(WeddingInviteOperType.Wedding_Apply, XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, sysParamList[0]);
                                break;
                            }
                            break;
                        case XSysDefine.XSys_GuildDialyDonate:
                            if (sysParamList.Count == 1)
                            {
                                XGuildDonateDocument.Doc.ShowViewWithID((uint)sysParamList[0]);
                                break;
                            }
                            break;
                        case XSysDefine.XSys_GuildWeeklyDonate:
                            if (sysParamList.Count == 1)
                            {
                                XGuildDonateDocument.Doc.ShowViewWithID((uint)sysParamList[0], GuildDonateType.WeeklyDonate);
                                break;
                            }
                            break;
                        default:
                            XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)sysid);
                            break;
                    }
                }
            }
        }

        public static void OnSpectateClick(string param)
        {
            if (DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded())
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NOT_IN_HALL_SPECTATE"), "fece00");
            else if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NOT_IN_HALL_STAGE"), "fece00");
            }
            else
            {
                if (!XLabelSymbolHelper.ParseSpectateParam(param, ref XInvitationDocument.mLiveID, ref XInvitationDocument.mType))
                    return;
                XSingleton<XDebug>.singleton.AddLog("xxxxxxxxxxx=> liveid: " + (object)XInvitationDocument.mLiveID + " type: " + (object)XInvitationDocument.mType);
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(XStringDefineProxy.GetString("Spectate_Sure"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL));
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(XInvitationDocument.OnGoSpectate));
            }
        }

        private static bool OnGoSpectate(IXUIButton btn)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID).EnterSpectateBattle((uint)XInvitationDocument.mLiveID, (LiveType)XInvitationDocument.mType);
            return true;
        }

        protected override void OnReconnected(XReconnectedEventArgs arg)
        {
        }

        private class InvitationChatLinkData
        {
            public ChatChannelType channel;
            public string content;
            public List<ChatParam> param;
            public bool bIsSystem;

            public void Reset()
            {
                if (this.param != null)
                    this.param.Clear();
                this.param = (List<ChatParam>)null;
            }
        }
    }
}
