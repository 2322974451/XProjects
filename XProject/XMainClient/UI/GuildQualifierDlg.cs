using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200176B RID: 5995
	internal class GuildQualifierDlg : DlgBase<GuildQualifierDlg, GuildQualifierBehavior>
	{
		// Token: 0x17003810 RID: 14352
		// (get) Token: 0x0600F774 RID: 63348 RVA: 0x003855F4 File Offset: 0x003837F4
		public override string fileName
		{
			get
			{
				return "Guild/GuildQualifierDlg";
			}
		}

		// Token: 0x17003811 RID: 14353
		// (get) Token: 0x0600F775 RID: 63349 RVA: 0x0038560C File Offset: 0x0038380C
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003812 RID: 14354
		// (get) Token: 0x0600F776 RID: 63350 RVA: 0x00385620 File Offset: 0x00383820
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003813 RID: 14355
		// (get) Token: 0x0600F777 RID: 63351 RVA: 0x00385634 File Offset: 0x00383834
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003814 RID: 14356
		// (get) Token: 0x0600F778 RID: 63352 RVA: 0x00385648 File Offset: 0x00383848
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003815 RID: 14357
		// (get) Token: 0x0600F779 RID: 63353 RVA: 0x0038565C File Offset: 0x0038385C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F77A RID: 63354 RVA: 0x0038566F File Offset: 0x0038386F
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.RespositionActive();
		}

		// Token: 0x0600F77B RID: 63355 RVA: 0x00385680 File Offset: 0x00383880
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
			this._Doc.QualifierView = this;
			base.uiBehaviour.m_FrameWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnFrameWrapUpdate));
			base.uiBehaviour.m_RankWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnRankWrapUpdate));
		}

		// Token: 0x0600F77C RID: 63356 RVA: 0x003856EC File Offset: 0x003838EC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClose));
			base.uiBehaviour.m_Go.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoHandler));
			base.uiBehaviour.m_SelectAll.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSelectAllChecked));
			base.uiBehaviour.m_SelectSelf.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSelectSelfChecked));
		}

		// Token: 0x0600F77D RID: 63357 RVA: 0x00385778 File Offset: 0x00383978
		protected override void OnShow()
		{
			base.OnShow();
			this.InitAwardList();
			this._Doc.Select = GuildQualifierSelect.ALL;
			base.uiBehaviour.m_SelectAll.bChecked = true;
			this._Doc.SendSelectQualifierList();
			this.RefreshData();
		}

		// Token: 0x0600F77E RID: 63358 RVA: 0x003857C6 File Offset: 0x003839C6
		public override void StackRefresh()
		{
			base.StackRefresh();
			this._Doc.SendSelectQualifierList();
		}

		// Token: 0x0600F77F RID: 63359 RVA: 0x003857DC File Offset: 0x003839DC
		public void RefreshData()
		{
			this.m_uiBehaviour.m_Frame.gameObject.SetActive(this._Doc.ServerActive);
			this.m_uiBehaviour.m_Rank.gameObject.SetActive(this._Doc.ServerActive);
			this.m_uiBehaviour.m_unJoin.gameObject.SetActive(!this._Doc.ServerActive);
			bool serverActive = this._Doc.ServerActive;
			if (serverActive)
			{
				this.RepositionRank();
				this.RepositionFrame();
				this.RespositionActive();
				this.RepositionLastRewardCount();
			}
		}

		// Token: 0x0600F780 RID: 63360 RVA: 0x00385880 File Offset: 0x00383A80
		private void RespositionActive()
		{
			bool flag = this._Doc.ActiveTime > 0.0;
			if (flag)
			{
				base.uiBehaviour.m_Time.SetText(XSingleton<XCommon>.singleton.StringCombine(XStringDefineProxy.GetString("GUILD_QUALIFIER_TIME"), "(", XStringDefineProxy.GetString("GUILD_QUALIFER_STYLE1", new object[]
				{
					XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this._Doc.ActiveTime, 5)
				}), ")"));
			}
			else
			{
				base.uiBehaviour.m_Time.SetText(XSingleton<XCommon>.singleton.StringCombine(XStringDefineProxy.GetString("GUILD_QUALIFIER_TIME"), XStringDefineProxy.GetString("GUILD_QUALIFER_STYLE2")));
			}
		}

		// Token: 0x0600F781 RID: 63361 RVA: 0x00385934 File Offset: 0x00383B34
		private void RepositionLastRewardCount()
		{
			uint lastRewardCount = this._Doc.GetLastRewardCount();
			base.uiBehaviour.m_Content.SetText(XStringDefineProxy.GetString("GUILD_QUALIFIER_CONTENT", new object[]
			{
				lastRewardCount
			}));
			base.uiBehaviour.m_Rule.SetText(XStringDefineProxy.GetString("GUILD_QUALIFIER_RULE"));
		}

		// Token: 0x0600F782 RID: 63362 RVA: 0x00385994 File Offset: 0x00383B94
		private void RepositionRank()
		{
			List<GuildLadderRoleRank> guildRoleRankList = this._Doc.GuildRoleRankList;
			bool flag = guildRoleRankList == null || guildRoleRankList.Count == 0;
			if (flag)
			{
				base.uiBehaviour.m_SelfRankWrapItem.gameObject.SetActive(false);
				base.uiBehaviour.m_RankWrapContent.SetContentCount(0, false);
				base.uiBehaviour.m_EmptyRank.Alpha = 1f;
			}
			else
			{
				base.uiBehaviour.m_RankWrapContent.SetContentCount(guildRoleRankList.Count, false);
				base.uiBehaviour.m_RankScrollView.ResetPosition();
				base.uiBehaviour.m_EmptyRank.Alpha = (float)((guildRoleRankList.Count > 0) ? 0 : 1);
				int num = -1;
				int i = 0;
				int count = guildRoleRankList.Count;
				while (i < count)
				{
					bool flag2 = guildRoleRankList[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag2)
					{
						num = i;
						break;
					}
					i++;
				}
				bool flag3 = num >= 0;
				if (flag3)
				{
					base.uiBehaviour.m_SelfRankWrapItem.gameObject.SetActive(true);
					this.OnRankWrapUpdate(base.uiBehaviour.m_SelfRankWrapItem, num);
				}
				else
				{
					base.uiBehaviour.m_SelfRankWrapItem.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0600F783 RID: 63363 RVA: 0x00385AEC File Offset: 0x00383CEC
		private void RepositionFrame()
		{
			List<GuildLadderRank> guildRankList = this._Doc.GuildRankList;
			bool flag = guildRankList == null || guildRankList.Count == 0;
			if (flag)
			{
				base.uiBehaviour.m_FrameWrapContent.SetContentCount(0, false);
			}
			else
			{
				base.uiBehaviour.m_FrameWrapContent.SetContentCount(guildRankList.Count, false);
			}
			base.uiBehaviour.m_RankScrollView.ResetPosition();
		}

		// Token: 0x0600F784 RID: 63364 RVA: 0x00385B5C File Offset: 0x00383D5C
		private void OnRankWrapUpdate(Transform t, int index)
		{
			bool flag = t == null;
			if (!flag)
			{
				List<GuildLadderRoleRank> guildRoleRankList = this._Doc.GuildRoleRankList;
				bool flag2 = index >= guildRoleRankList.Count || index < 0;
				if (!flag2)
				{
					GuildLadderRoleRank guildLadderRoleRank = guildRoleRankList[index];
					IXUILabelSymbol ixuilabelSymbol = t.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
					IXUILabel ixuilabel = t.FindChild("Rank3").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite = t.FindChild("Rank").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel2 = t.FindChild("Win").GetComponent("XUILabel") as IXUILabel;
					uint index2;
					bool flag3 = this._Doc.TryGetGuildIcon(guildLadderRoleRank.guildid, out index2);
					string inputText;
					if (flag3)
					{
						inputText = XSingleton<XCommon>.singleton.StringCombine(XLabelSymbolHelper.FormatImage("common/Billboard", XGuildDocument.GetPortraitName((int)index2)), guildLadderRoleRank.name);
					}
					else
					{
						inputText = guildLadderRoleRank.name;
					}
					ixuilabelSymbol.InputText = inputText;
					bool flag4 = index + 1 > 3;
					ixuilabel.Alpha = (float)(flag4 ? 1 : 0);
					ixuilabel.SetText((index + 1).ToString());
					ixuisprite.SetAlpha((float)(flag4 ? 0 : 1));
					ixuisprite.SetSprite(XSingleton<XCommon>.singleton.StringCombine("N", (index + 1).ToString()));
					ixuilabel2.SetText(guildLadderRoleRank.wintimes.ToString());
				}
			}
		}

		// Token: 0x0600F785 RID: 63365 RVA: 0x00385CE0 File Offset: 0x00383EE0
		private void OnFrameWrapUpdate(Transform t, int index)
		{
			bool flag = t == null;
			if (!flag)
			{
				List<GuildLadderRank> guildRankList = this._Doc.GuildRankList;
				bool flag2 = index >= guildRankList.Count || index < 0;
				if (!flag2)
				{
					GuildLadderRank guildLadderRank = guildRankList[index];
					IXUILabelSymbol ixuilabelSymbol = t.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
					IXUILabel ixuilabel = t.FindChild("Rank3").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite = t.FindChild("Rank").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel2 = t.FindChild("Win").GetComponent("XUILabel") as IXUILabel;
					string s = XLabelSymbolHelper.FormatImage("common/Billboard", XGuildDocument.GetPortraitName((int)guildLadderRank.icon));
					ixuilabelSymbol.InputText = XSingleton<XCommon>.singleton.StringCombine(s, guildLadderRank.guildname);
					bool flag3 = index + 1 > 3;
					ixuilabel.Alpha = (float)(flag3 ? 1 : 0);
					ixuisprite.SetAlpha((float)(flag3 ? 0 : 1));
					ixuilabel2.SetText(XStringDefineProxy.GetString("GUILD_QUALIFER_WINNER", new object[]
					{
						guildLadderRank.wintimes
					}));
					ixuisprite.SetSprite(XSingleton<XCommon>.singleton.StringCombine("N", (index + 1).ToString()));
					Transform transform = t.FindChild("AwardList");
					GuildPkRankReward.RowData rowData;
					bool flag4 = XGuildQualifierDocument.TryGetRankReward(index + 1, out rowData);
					if (flag4)
					{
						transform.gameObject.SetActive(true);
						SeqListRef<uint> reward = rowData.reward;
						for (int i = 0; i < 4; i++)
						{
							GameObject gameObject = transform.FindChild(XSingleton<XCommon>.singleton.StringCombine("item", i.ToString())).gameObject;
							bool flag5 = i < reward.Count;
							if (flag5)
							{
								gameObject.SetActive(true);
								IXUISprite ixuisprite2 = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
								IXUISprite ixuisprite3 = gameObject.transform.FindChild("Quality").GetComponent("XUISprite") as IXUISprite;
								ixuisprite2.ID = (ulong)reward[i, 0];
								XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)reward[i, 0], (int)reward[i, 1], false);
								ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
							}
							else
							{
								gameObject.SetActive(false);
							}
						}
					}
					else
					{
						transform.gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x0600F786 RID: 63366 RVA: 0x00385F90 File Offset: 0x00384190
		private void InitAwardList()
		{
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("GuildLadderReward", true);
			base.uiBehaviour.m_RewardPool.ReturnAll(false);
			int i = 0;
			int count = (int)sequenceList.Count;
			while (i < count)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
				gameObject.transform.parent = base.uiBehaviour.m_RewardList;
				gameObject.transform.localPosition = new Vector3((float)(i * 100), 0f, 0f);
				gameObject.transform.localScale = Vector3.one;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, sequenceList[i, 0], sequenceList[i, 1], false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)sequenceList[i, 0]);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				i++;
			}
		}

		// Token: 0x0600F787 RID: 63367 RVA: 0x003860A8 File Offset: 0x003842A8
		private bool OnSelectSelfChecked(IXUICheckBox checkBox)
		{
			bool flag = !checkBox.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._Doc.Select = GuildQualifierSelect.SELF;
				this.RepositionRank();
				result = false;
			}
			return result;
		}

		// Token: 0x0600F788 RID: 63368 RVA: 0x003860E0 File Offset: 0x003842E0
		private bool OnSelectAllChecked(IXUICheckBox checkBox)
		{
			bool flag = !checkBox.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._Doc.Select = GuildQualifierSelect.ALL;
				this.RepositionRank();
				result = false;
			}
			return result;
		}

		// Token: 0x0600F789 RID: 63369 RVA: 0x00386118 File Offset: 0x00384318
		private bool OnClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F78A RID: 63370 RVA: 0x00386134 File Offset: 0x00384334
		private bool OnGoHandler(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Qualifying, 0UL);
			return false;
		}

		// Token: 0x04006BCC RID: 27596
		private XGuildQualifierDocument _Doc;

		// Token: 0x04006BCD RID: 27597
		private Vector3 m_ItemScale = new Vector3(0.5f, 0.5f, 0.5f);
	}
}
