using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamPartnerBonusHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_PopClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnPopCloseClicked));
			this.m_BtnOpenPop.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnPopOpenClicked));
		}

		private void _OnPopCloseClicked(IXUISprite iSp)
		{
			this.m_PopPanel.SetActive(false);
		}

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

		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshCurrent();
			this.RefreshPop();
		}

		private void _RefreshDetailInfo(GameObject go, DragonGuildTable.RowData rowData)
		{
			IXUILabel ixuilabel = go.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
			GameObject gameObject = go.transform.Find("Buff").gameObject;
			ixuilabel.SetText(rowData.level.ToString());
			this._RefreshBuff(gameObject, rowData);
		}

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

		private bool _OnGotoPartnerClicked(IXUIButton btn)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.ShowTab(XSysDefine.XSys_GuildCollectSummon);
			return true;
		}

		private GameObject m_CurrentBuff;

		private GameObject m_DisableBuff;

		private IXUILabel[] m_Levels;

		private List<int> m_QualityLevels;

		private IXUILabel m_DisableLevel;

		private GameObject m_Active;

		private GameObject m_Disactive;

		private GameObject m_PopActive;

		private GameObject m_PopDisactive;

		private IXUISprite m_BtnOpenPop;

		private GameObject m_PopPanel;

		private IXUISprite m_PopClose;

		private GameObject m_PopEmpty;

		private GameObject m_PopCurrentBuff;

		private GameObject m_PopNextBuff;

		private GameObject m_PopFinalBuff;

		private XTeamDocument _TeamDoc;

		private XDragonGuildDocument _Doc;

		private DragonGuildTable.RowData m_CurrentBuffData;

		private DragonGuildTable.RowData m_NextBuffData;

		private bool m_bFullLevel;

		private bool m_bActive;

		public bool bConsiderTeam = false;
	}
}
