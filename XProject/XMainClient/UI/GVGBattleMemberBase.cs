

using KKSG;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class GVGBattleMemberBase : IGVGBattleMember
    {
        private Transform transform;
        private IXUIWrapContent m_WrapContent;
        private IXUIScrollView m_ScrollView;
        private IXUILabelSymbol m_GuildName;
        private XGuildArenaBattleDocument _Doc;
        private XGuildDocument _GuildDoc;
        private List<GmfRole> mRoles;
        private int mIndex = 1;
        private bool isSelfGuild = false;
        private ulong needRemoveID;

        public void Setup(GameObject sv, int index)
        {
            this.mIndex = index;
            this._Doc = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
            this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
            this.transform = sv.transform;
            this.m_GuildName = this.transform.FindChild("Title/Title1").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
            this.m_ScrollView = this.transform.FindChild("MemberScrollView").GetComponent("XUIScrollView") as IXUIScrollView;
            this.m_WrapContent = this.transform.FindChild("MemberScrollView/MemberList").GetComponent("XUIWrapContent") as IXUIWrapContent;
            this.m_WrapContent.RegisterItemUpdateEventHandler(new UILib.WrapItemUpdateEventHandler(this.WrapItemUpdateEventHandler));
        }

        private void FormatRole(ref List<GmfRole> roles)
        {
            if (roles == null)
                roles = new List<GmfRole>();
            int battleSignNumber = this._Doc.GetBattleSignNumber();
            if (roles.Count >= battleSignNumber)
                return;
            for (int count = roles.Count; count < battleSignNumber; ++count)
                roles.Add(new GmfRole()
                {
                    rolename = XSingleton<XStringTable>.singleton.GetString("GUILD_ARENA_TAB_PERSON"),
                    index = count,
                    roleID = 0UL,
                    profession = 0
                });
        }

        public void ReFreshData(GVGBattleInfo battleInfo)
        {
            if (battleInfo.Base == null || battleInfo.Group == null)
                return;
            if (this.mRoles == null)
                this.mRoles = new List<GmfRole>();
            this.mRoles.Clear();
            this.mRoles.AddRange((IEnumerable<GmfRole>)battleInfo.Group);
            this.FormatRole(ref this.mRoles);
            this.isSelfGuild = this._GuildDoc.bInGuild && (long)this._GuildDoc.BasicData.uid == (long)battleInfo.Base.guildid;
            this.m_WrapContent.SetContentCount(this.mRoles.Count);
            this.m_ScrollView.ResetPosition();
            if (this._Doc.IsGCF())
                this.m_GuildName.InputText = XStringDefineProxy.GetString("CROSS_GVG_GUILDNAME", (object)battleInfo.Base.serverid, (object)battleInfo.Base.guildname);
            else
                this.m_GuildName.InputText = battleInfo.Base.guildname;
        }

        private void WrapItemUpdateEventHandler(Transform t, int index)
        {
            if (index < 0 || index >= this.mRoles.Count)
                return;
            GmfRole mRole = this.mRoles[index];
            if (mRole == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("XMainClient.UI.GuildArenaBattleMemberPanel.WrapItemUpdateEventHandler is null ");
            }
            else
            {
                IXUILabel component1 = t.FindChild("Status/Num").GetComponent("XUILabel") as IXUILabel;
                IXUISprite component2 = t.FindChild("Status/Battle").GetComponent("XUISprite") as IXUISprite;
                IXUILabel component3 = t.FindChild("Fight").GetComponent("XUILabel") as IXUILabel;
                IXUILabel component4 = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
                IXUISprite component5 = t.FindChild("kick").GetComponent("XUISprite") as IXUISprite;
                IXUISprite component6 = t.Find("job").GetComponent("XUISprite") as IXUISprite;
                GameObject gameObject = t.FindChild("icon").gameObject;
                component1.SetText((index + 1).ToString());
                component4.SetText(mRole.rolename);
                component6.SetAlpha(1f);
                component6.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(mRole.profession));
                component5.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRemove));
                component5.ID = mRole.roleID;
                if (mRole.roleID == 0UL)
                {
                    component2.gameObject.SetActive(false);
                    component3.gameObject.SetActive(false);
                    component5.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                    component1.SetVisible(true);
                    component1.SetColor(Color.white);
                    component4.SetColor(Color.white);
                    component3.SetColor(Color.white);
                    component6?.SetAlpha(0.0f);
                }
                else
                {
                    component2.gameObject.SetActive(true);
                    component3.gameObject.SetActive(true);
                    component5.gameObject.SetActive(true);
                    gameObject.SetActive(true);
                    this.SetupOtherMemberInfo(t, mRole);
                    bool flag = this.isSelfGuild;
                    switch (this._Doc.mArenaSection)
                    {
                        case XGuildArenaBattleDocument.GuildArenaSection.Prepare:
                            flag &= this.SetPrepareFightState(mRole, component2, component1, component4);
                            break;
                        case XGuildArenaBattleDocument.GuildArenaSection.Battle:
                            flag &= this.SetMatchFightState(mRole, component2, component1, component4, component3);
                            break;
                    }
                    if (this._GuildDoc.Position != GuildPosition.GPOS_LEADER && this._GuildDoc.Position != GuildPosition.GPOS_VICELEADER)
                        flag = false;
                    else if (this._GuildDoc.Position == GuildPosition.GPOS_VICELEADER && (mRole.guildpos == 0 || mRole.guildpos == 1))
                        flag = false;
                    if ((long)mRole.roleID == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                        flag = false;
                    if (this._Doc.MyReadyType == XGuildArenaBattleDocument.ReadyType.Observer)
                        flag = false;
                    component5.gameObject.SetActive(flag);
                }
            }
        }

        protected virtual void SetupOtherMemberInfo(Transform t, GmfRole role)
        {
        }

        private void OnRemove(IXUISprite button)
        {
            this.needRemoveID = button.ID;
            XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GUILD_ARENA_KICK"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnRemoveQuery));
        }

        private bool OnRemoveQuery(IXUIButton btn)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            if (this.needRemoveID > 0UL)
                this._Doc.ReadyReq(this.needRemoveID, GMFReadyType.GMF_READY_KICK);
            this.needRemoveID = 0UL;
            return true;
        }

        private bool SetPrepareFightState(
          GmfRole roleInfo,
          IXUISprite sprite,
          IXUILabel rank,
          IXUILabel name)
        {
            rank.gameObject.SetActive(true);
            sprite.gameObject.SetActive(false);
            Color c = Color.white;
            if ((long)roleInfo.roleID == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                c = Color.green;
            name.SetColor(c);
            return true;
        }

        private bool SetMatchFightState(
          GmfRole roleInfo,
          IXUISprite sprite,
          IXUILabel rank,
          IXUILabel name,
          IXUILabel fight)
        {
            bool flag = true;
            Color c = Color.white;
            if ((long)roleInfo.roleID == (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
                c = Color.green;
            string str = "guildpvp_icon_2";
            switch (roleInfo.state)
            {
                case GuildMatchFightState.GUILD_MF_WAITING:
                    sprite.gameObject.SetActive(false);
                    rank.gameObject.SetActive(true);
                    str = "guildpvp_icon_1";
                    flag = this._GuildDoc.Position == GuildPosition.GPOS_LEADER || this._GuildDoc.Position == GuildPosition.GPOS_VICELEADER;
                    break;
                case GuildMatchFightState.GUILD_MF_FIGHTING:
                    sprite.gameObject.SetActive(true);
                    rank.gameObject.SetActive(false);
                    string strSprite1;
                    if (this.mIndex == 2)
                    {
                        strSprite1 = "guildpvp_icon_4";
                        c = new Color(0.92f, 0.23f, 0.23f);
                    }
                    else
                    {
                        strSprite1 = "guildpvp_icon_3";
                        c = new Color(0.0f, 0.658f, 1f);
                    }
                    sprite.SetSprite(strSprite1);
                    flag = false;
                    break;
                case GuildMatchFightState.GUILD_MF_FAILED:
                    sprite.gameObject.SetActive(true);
                    rank.gameObject.SetActive(false);
                    string strSprite2 = "guildpvp_icon_0";
                    sprite.SetSprite(strSprite2);
                    c = Color.white;
                    flag = false;
                    break;
            }
            rank.SetColor(c);
            name.SetColor(c);
            fight.SetColor(c);
            return flag;
        }

        public void OnUpdate()
        {
        }

        public void SetActive(bool active)
        {
            if (!((Object)this.transform != (Object)null))
                return;
            this.transform.gameObject.SetActive(active);
        }

        public bool IsActive() => (Object)this.transform != (Object)null && this.transform.gameObject.activeSelf;

        public void Recycle()
        {
            if (this.mRoles == null)
                return;
            this.mRoles.Clear();
            this.mRoles = (List<GmfRole>)null;
        }
    }
}
