// Decompiled with JetBrains decompiler
// Type: XMainClient.ChatMemberList
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class ChatMemberList : DlgBase<ChatMemberList, ChatMemberBehaviour>
    {
        private List<CGroupPlayerInfo> players;

        public override string fileName => "GameSystem/ChatMemberList";

        public override bool autoload => true;

        public override bool isHideChat => false;

        protected override void Init() => base.Init();

        public override void RegisterEvent()
        {
            this.uiBehaviour.m_wrap.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
            this.uiBehaviour.m_sprClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClick));
        }

        protected override void OnShow()
        {
            base.OnShow();
            this.uiBehaviour.m_scroll.ResetPosition();
            XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID).ReqGetGroupInfo(DlgBase<XChatView, XChatBehaviour>.singleton.ChatGroupId);
        }

        public void Refresh()
        {
            GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
            if (specificDocument.players == null)
                return;
            CGroupPlayerInfo[] cgroupPlayerInfoArray = new CGroupPlayerInfo[specificDocument.players.Count];
            specificDocument.players.CopyTo(cgroupPlayerInfoArray);
            this.SelectByState(cgroupPlayerInfoArray);
            this.uiBehaviour.m_wrap.SetContentCount(this.players.Count);
        }

        private void SelectByState(CGroupPlayerInfo[] pp)
        {
            if (this.players == null)
                this.players = new List<CGroupPlayerInfo>();
            else
                this.players.Clear();
            int index = 0;
            for (int length = pp.Length; index < length; ++index)
            {
                if (pp[index].degree < 0 && (long)pp[index].roleid != (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                    this.players.Add(pp[index]);
            }
        }

        private void OnCloseClick(IXUISprite spr) => this.SetVisible(false, true);

        private void WrapContentItemUpdated(Transform t, int index)
        {
            if (this.players == null || this.players[index] == null)
                return;
            IXUISprite component1 = t.Find("head").GetComponent("XUISprite") as IXUISprite;
            IXUILabel component2 = t.Find("level").GetComponent("XUILabel") as IXUILabel;
            IXUILabel component3 = t.Find("UID").GetComponent("XUILabel") as IXUILabel;
            IXUILabel component4 = t.Find("PPT").GetComponent("XUILabel") as IXUILabel;
            IXUILabelSymbol component5 = t.Find("name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
            IXUISprite component6 = t.Find("Btn_chat").GetComponent("XUISprite") as IXUISprite;
            IXUISprite component7 = t.Find("add").GetComponent("XUISprite") as IXUISprite;
            IXUILabel component8 = t.Find("guild").GetComponent("XUILabel") as IXUILabel;
            IXUISprite component9 = t.Find("ProfIcon").GetComponent("XUISprite") as IXUISprite;
            int profession = (int)this.players[index].profession;
            component9.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(profession);
            component1.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(profession);
            component6.ID = this.players[index].roleid;
            component7.ID = this.players[index].roleid;
            string guild = this.players[index].guild;
            if (string.IsNullOrEmpty(guild))
                guild = XStringDefineProxy.GetString("NONE");
            component8.SetText(guild);
            component6.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChatClick));
            component7.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnFriendClick));
            bool flag = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(this.players[index].roleid);
            component7.SetVisible(!flag);
            component2.SetText(this.players[index].level.ToString());
            component4.SetText(this.players[index].ppt.ToString());
            component5.InputText = this.players[index].rolename;
            component3.SetText(this.players[index].uid.ToString());
        }

        private void OnChatClick(IXUISprite spr)
        {
            this.SetVisible(false, true);
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends))
            {
                int sysid = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Friends);
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EXPEDITION_REQUIRED_LEVEL", (object)XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(sysid)) + XSingleton<XGameSysMgr>.singleton.GetSysName(sysid), "fece00");
            }
            else
            {
                CGroupPlayerInfo player = this.GetPlayer(spr.ID);
                DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetPlayerInfo(spr.ID, player.rolename, player.setid, player.ppt, player.profession);
                DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.PrivateChat((IXUIButton)null);
            }
        }

        private void OnFriendClick(IXUISprite spr) => DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(spr.ID);

        private CGroupPlayerInfo GetPlayer(ulong roleid)
        {
            if (this.players != null)
            {
                List<CGroupPlayerInfo>.Enumerator enumerator = this.players.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if ((long)enumerator.Current.roleid == (long)roleid)
                        return enumerator.Current;
                }
            }
            return (CGroupPlayerInfo)null;
        }
    }
}
