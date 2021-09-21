using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D13 RID: 3347
	internal class XTeamPartnerBonusHandler : DlgHandlerBase
	{
		// Token: 0x0600BACE RID: 47822 RVA: 0x00263890 File Offset: 0x00261A90
		protected override void Init()
		{
			base.Init();
			this.m_Active = base.PanelObject.transform.Find("Active").gameObject;
			this.m_Disactive = base.PanelObject.transform.Find("Disactive").gameObject;
			this.m_CurrentBuff = this.m_Active.transform.Find("Buff").gameObject;
			this.m_DisableBuff = this.m_Disactive.transform.Find("Buff").gameObject;
			this.m_BtnOpenPop = (base.PanelObject.transform.Find("BtnOpenPop").GetComponent("XUISprite") as IXUISprite);
			this.m_PopPanel = base.PanelObject.transform.Find("FriendBonusPop").gameObject;
			this.m_PopClose = (this.m_PopPanel.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_PopActive = this.m_PopPanel.transform.Find("Active").gameObject;
			this.m_PopDisactive = this.m_PopPanel.transform.Find("Disactive").gameObject;
			this.m_PopEmpty = this.m_PopDisactive.transform.Find("Empty").gameObject;
			IXUILabel ixuilabel = this.m_PopEmpty.transform.Find("Slogan").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("TeamBonusNoPartner")));
			IXUIButton ixuibutton = this.m_PopEmpty.transform.Find("BtnPartner").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnGotoPartnerClicked));
			this.m_PopCurrentBuff = this.m_PopActive.transform.Find("CurrentBuff").gameObject;
			this.m_PopNextBuff = this.m_PopActive.transform.Find("NextBuff").gameObject;
			this.m_PopFinalBuff = this.m_PopActive.transform.Find("FinalBuff").gameObject;
			this.m_QualityLevels = XSingleton<XGlobalConfig>.singleton.GetIntList("TeamFriendDegreeBuffQuality");
			this.m_Levels = new IXUILabel[this.m_QualityLevels.Count];
			for (int i = 0; i < this.m_Levels.Length; i++)
			{
				this.m_Levels[i] = (this.m_Active.transform.Find(XSingleton<XCommon>.singleton.StringCombine("Level", i.ToString())).GetComponent("XUILabel") as IXUILabel);
			}
			this.m_DisableLevel = (this.m_Disactive.transform.Find("Level0").GetComponent("XUILabel") as IXUILabel);
			this._TeamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this._Doc = XDragonGuildDocument.Doc;
			this.m_PopPanel.SetActive(false);
		}

		// Token: 0x0600BACF RID: 47823 RVA: 0x00263BA4 File Offset: 0x00261DA4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_PopClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnPopCloseClicked));
			this.m_BtnOpenPop.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnPopOpenClicked));
		}

		// Token: 0x0600BAD0 RID: 47824 RVA: 0x00263BDE File Offset: 0x00261DDE
		private void _OnPopCloseClicked(IXUISprite iSp)
		{
			this.m_PopPanel.SetActive(false);
		}

		// Token: 0x0600BAD1 RID: 47825 RVA: 0x00263BF0 File Offset: 0x00261DF0
		private void _OnPopOpenClicked(IXUISprite iSp)
		{
			bool flag = this.IsHadDragonGuildMemberInTeam();
			if (!flag)
			{
				bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GuildCollectSummon);
				if (flag2)
				{
					OpenSystemTable.RowData sysData = XSingleton<XGameSysMgr>.singleton.GetSysData(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildCollectSummon));
					bool flag3 = sysData != null;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("LEVEL_REQUIRE_LEVEL"), sysData.PlayerLevel), "fece00");
					}
				}
				else
				{
					this.m_PopPanel.SetActive(true);
					this.RefreshPop();
				}
			}
		}

		// Token: 0x0600BAD2 RID: 47826 RVA: 0x00263C80 File Offset: 0x00261E80
		public void RefreshCurrent()
		{
			this.m_CurrentBuffData = null;
			bool bActive = this.IsHadDragonGuildMemberInTeam();
			uint level = this._Doc.BaseData.level;
			DragonGuildTable.RowData bylevel = XDragonGuildDocument.DragonGuildBuffTable.GetBylevel(level);
			bool flag = bylevel != null;
			if (flag)
			{
				this.m_CurrentBuffData = bylevel;
				this.m_bFullLevel = ((ulong)level == (ulong)((long)XDragonGuildDocument.DragonGuildBuffTable.Table.Length));
			}
			this.m_bActive = bActive;
			this.m_NextBuffData = bylevel;
			bool flag2 = this.m_CurrentBuffData == null;
			if (flag2)
			{
				this.m_CurrentBuffData = this.m_NextBuffData;
			}
			this.m_Active.SetActive(this.m_bActive);
			this.m_Disactive.SetActive(!this.m_bActive);
			bool flag3 = this.m_CurrentBuffData != null;
			if (flag3)
			{
				bool bActive2 = this.m_bActive;
				if (bActive2)
				{
					int num = 0;
					for (int i = this.m_QualityLevels.Count - 1; i >= 0; i--)
					{
						bool flag4 = (ulong)this.m_CurrentBuffData.level >= (ulong)((long)this.m_QualityLevels[i]);
						if (flag4)
						{
							num = i;
							break;
						}
					}
					for (int j = 0; j < this.m_Levels.Length; j++)
					{
						this.m_Levels[j].SetVisible(j == num);
					}
					this.m_Levels[num].SetText(this.m_CurrentBuffData.level.ToString());
					this._RefreshBuff(this.m_CurrentBuff, this.m_CurrentBuffData);
				}
				else
				{
					this.m_DisableLevel.SetText(this.m_CurrentBuffData.level.ToString());
					this._RefreshBuff(this.m_DisableBuff, this.m_CurrentBuffData);
				}
			}
			else
			{
				bool flag5 = this.m_NextBuffData != null;
				if (flag5)
				{
					this.m_DisableLevel.SetText(this.m_NextBuffData.level.ToString());
					this._RefreshBuff(this.m_DisableBuff, this.m_NextBuffData);
				}
			}
		}

		// Token: 0x0600BAD3 RID: 47827 RVA: 0x00263E88 File Offset: 0x00262088
		private bool IsHadDragonGuildMemberInTeam()
		{
			bool result = false;
			bool flag = this.bConsiderTeam;
			if (flag)
			{
				bool flag2 = this._TeamDoc.bInTeam && this._Doc.IsInDragonGuild();
				if (flag2)
				{
					for (int i = 0; i < this._TeamDoc.MyTeam.members.Count; i++)
					{
						XTeamMember xteamMember = this._TeamDoc.MyTeam.members[i];
						bool flag3 = xteamMember == this._TeamDoc.MyTeam.myData;
						if (!flag3)
						{
							bool flag4 = this._Doc.IsMyDragonGuildMember(xteamMember.dragonGuildID);
							if (flag4)
							{
								result = true;
								break;
							}
						}
					}
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600BAD4 RID: 47828 RVA: 0x00263F50 File Offset: 0x00262150
		public void RefreshPop()
		{
			bool flag = !this.m_PopPanel.activeSelf;
			if (!flag)
			{
				this.m_PopActive.SetActive(this.m_bActive);
				this.m_PopDisactive.SetActive(!this.m_bActive);
				bool flag2 = !this.m_bActive;
				if (!flag2)
				{
					bool bFullLevel = this.m_bFullLevel;
					if (bFullLevel)
					{
						this.m_PopFinalBuff.SetActive(true);
						this.m_PopCurrentBuff.SetActive(false);
						this.m_PopNextBuff.SetActive(false);
						this._RefreshDetailInfo(this.m_PopFinalBuff, this.m_CurrentBuffData);
					}
					else
					{
						this.m_PopFinalBuff.SetActive(false);
						this.m_PopCurrentBuff.SetActive(true);
						this.m_PopNextBuff.SetActive(true);
						this._RefreshDetailInfo(this.m_PopCurrentBuff, this.m_CurrentBuffData);
						this._RefreshDetailInfo(this.m_PopNextBuff, this.m_NextBuffData);
					}
				}
			}
		}

		// Token: 0x0600BAD5 RID: 47829 RVA: 0x00264045 File Offset: 0x00262245
		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshCurrent();
			this.RefreshPop();
		}

		// Token: 0x0600BAD6 RID: 47830 RVA: 0x00264060 File Offset: 0x00262260
		private void _RefreshDetailInfo(GameObject go, DragonGuildTable.RowData rowData)
		{
			IXUILabel ixuilabel = go.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
			GameObject gameObject = go.transform.Find("Buff").gameObject;
			ixuilabel.SetText(rowData.level.ToString());
			this._RefreshBuff(gameObject, rowData);
		}

		// Token: 0x0600BAD7 RID: 47831 RVA: 0x002640E0 File Offset: 0x002622E0
		private void _RefreshBuff(GameObject go, DragonGuildTable.RowData rowData)
		{
			IXUILabel ixuilabel = go.GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
			BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(rowData.buf[0], rowData.buf[1]);
			bool flag = buffData == null;
			if (flag)
			{
				ixuilabel.SetText(string.Empty);
				ixuilabel2.SetText(string.Empty);
			}
			else
			{
				ixuilabel.SetText(buffData.BuffName);
				ixuilabel2.SetText(string.Empty);
			}
		}

		// Token: 0x0600BAD8 RID: 47832 RVA: 0x00264180 File Offset: 0x00262380
		private bool _OnGotoPartnerClicked(IXUIButton btn)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.ShowTab(XSysDefine.XSys_GuildCollectSummon);
			return true;
		}

		// Token: 0x04004B26 RID: 19238
		private GameObject m_CurrentBuff;

		// Token: 0x04004B27 RID: 19239
		private GameObject m_DisableBuff;

		// Token: 0x04004B28 RID: 19240
		private IXUILabel[] m_Levels;

		// Token: 0x04004B29 RID: 19241
		private List<int> m_QualityLevels;

		// Token: 0x04004B2A RID: 19242
		private IXUILabel m_DisableLevel;

		// Token: 0x04004B2B RID: 19243
		private GameObject m_Active;

		// Token: 0x04004B2C RID: 19244
		private GameObject m_Disactive;

		// Token: 0x04004B2D RID: 19245
		private GameObject m_PopActive;

		// Token: 0x04004B2E RID: 19246
		private GameObject m_PopDisactive;

		// Token: 0x04004B2F RID: 19247
		private IXUISprite m_BtnOpenPop;

		// Token: 0x04004B30 RID: 19248
		private GameObject m_PopPanel;

		// Token: 0x04004B31 RID: 19249
		private IXUISprite m_PopClose;

		// Token: 0x04004B32 RID: 19250
		private GameObject m_PopEmpty;

		// Token: 0x04004B33 RID: 19251
		private GameObject m_PopCurrentBuff;

		// Token: 0x04004B34 RID: 19252
		private GameObject m_PopNextBuff;

		// Token: 0x04004B35 RID: 19253
		private GameObject m_PopFinalBuff;

		// Token: 0x04004B36 RID: 19254
		private XTeamDocument _TeamDoc;

		// Token: 0x04004B37 RID: 19255
		private XDragonGuildDocument _Doc;

		// Token: 0x04004B38 RID: 19256
		private DragonGuildTable.RowData m_CurrentBuffData;

		// Token: 0x04004B39 RID: 19257
		private DragonGuildTable.RowData m_NextBuffData;

		// Token: 0x04004B3A RID: 19258
		private bool m_bFullLevel;

		// Token: 0x04004B3B RID: 19259
		private bool m_bActive;

		// Token: 0x04004B3C RID: 19260
		public bool bConsiderTeam = false;
	}
}
