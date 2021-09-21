using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CB3 RID: 3251
	internal class SkyArenaEntranceView : DlgBase<SkyArenaEntranceView, SkyArenaEntranceBehaviour>
	{
		// Token: 0x17003253 RID: 12883
		// (get) Token: 0x0600B6F2 RID: 46834 RVA: 0x00245BA4 File Offset: 0x00243DA4
		public override string fileName
		{
			get
			{
				return "GameSystem/SkyArena/SkyArenaEntrance";
			}
		}

		// Token: 0x17003254 RID: 12884
		// (get) Token: 0x0600B6F3 RID: 46835 RVA: 0x00245BBC File Offset: 0x00243DBC
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003255 RID: 12885
		// (get) Token: 0x0600B6F4 RID: 46836 RVA: 0x00245BD0 File Offset: 0x00243DD0
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003256 RID: 12886
		// (get) Token: 0x0600B6F5 RID: 46837 RVA: 0x00245BE4 File Offset: 0x00243DE4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003257 RID: 12887
		// (get) Token: 0x0600B6F6 RID: 46838 RVA: 0x00245BF8 File Offset: 0x00243DF8
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003258 RID: 12888
		// (get) Token: 0x0600B6F7 RID: 46839 RVA: 0x00245C0C File Offset: 0x00243E0C
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003259 RID: 12889
		// (get) Token: 0x0600B6F8 RID: 46840 RVA: 0x00245C20 File Offset: 0x00243E20
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700325A RID: 12890
		// (get) Token: 0x0600B6F9 RID: 46841 RVA: 0x00245C34 File Offset: 0x00243E34
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_MulActivity_SkyArena);
			}
		}

		// Token: 0x0600B6FA RID: 46842 RVA: 0x00245C50 File Offset: 0x00243E50
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XSkyArenaEntranceDocument>(XSkyArenaEntranceDocument.uuID);
			this.doc.View = this;
		}

		// Token: 0x0600B6FB RID: 46843 RVA: 0x00245C70 File Offset: 0x00243E70
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_SingleJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartSingleClicked));
			base.uiBehaviour.m_TeamJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartTeamClicked));
			base.uiBehaviour.m_RewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRewardClicked));
		}

		// Token: 0x0600B6FC RID: 46844 RVA: 0x00245D10 File Offset: 0x00243F10
		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B6FD RID: 46845 RVA: 0x00245D2C File Offset: 0x00243F2C
		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_MulActivity_SkyArena);
			return true;
		}

		// Token: 0x0600B6FE RID: 46846 RVA: 0x00245D50 File Offset: 0x00243F50
		private bool OnStartSingleClicked(IXUIButton btn)
		{
			this.doc.ReqSingleJoin();
			return true;
		}

		// Token: 0x0600B6FF RID: 46847 RVA: 0x00245D70 File Offset: 0x00243F70
		private bool OnStartTeamClicked(IXUIButton btn)
		{
			this.SetVisible(false, true);
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			List<ExpeditionTable.RowData> expeditionList = specificDocument.GetExpeditionList(TeamLevelType.TeamLevelSkyArena);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag = expeditionList.Count > 0;
			if (flag)
			{
				specificDocument2.SetAndMatch(expeditionList[0].DNExpeditionID);
			}
			return true;
		}

		// Token: 0x0600B700 RID: 46848 RVA: 0x00245DCF File Offset: 0x00243FCF
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshPage();
		}

		// Token: 0x0600B701 RID: 46849 RVA: 0x00245DE0 File Offset: 0x00243FE0
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B702 RID: 46850 RVA: 0x00245DEA File Offset: 0x00243FEA
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<PointRewardHandler>(ref this._PointRewardHandler);
			this.doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600B703 RID: 46851 RVA: 0x00245E0C File Offset: 0x0024400C
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x0600B704 RID: 46852 RVA: 0x00245E18 File Offset: 0x00244018
		public void RefreshPage()
		{
			SkyArenaReward.RowData skyArenaRewardShow = this.doc.GetSkyArenaRewardShow();
			base.uiBehaviour.m_RewardPool.FakeReturnAll();
			for (int i = 0; i < skyArenaRewardShow.Reward.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				int spriteWidth = ixuisprite.spriteWidth;
				gameObject.transform.localPosition = new Vector3(((float)i + 0.5f - (float)skyArenaRewardShow.Reward.Count / 2f) * (float)spriteWidth, 0f, 0f);
				uint num = skyArenaRewardShow.Reward[i, 0];
				Transform transform = gameObject.transform.Find("Item");
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform.gameObject, (int)num, 0, false);
				IXUISprite ixuisprite2 = transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.ID = (ulong)num;
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
			}
			base.uiBehaviour.m_RewardPool.ActualReturnAll(false);
			base.uiBehaviour.m_Time.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_TIME"));
		}

		// Token: 0x0600B705 RID: 46853 RVA: 0x001EECC3 File Offset: 0x001ECEC3
		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		// Token: 0x0600B706 RID: 46854 RVA: 0x00245F78 File Offset: 0x00244178
		public bool OnRewardClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<PointRewardHandler>(ref this._PointRewardHandler, base.uiBehaviour.m_Bg, false, null);
			this.OpenReward(this._PointRewardHandler);
			return true;
		}

		// Token: 0x0600B707 RID: 46855 RVA: 0x00245FB4 File Offset: 0x002441B4
		public void OpenReward(PointRewardHandler handler)
		{
			bool flag = handler.Sys != XSysDefine.XSys_MulActivity_SkyArena;
			if (flag)
			{
				List<SkyArenaReward.RowData> skyArenaRewardList = XSkyArenaEntranceDocument.Doc.GetSkyArenaRewardList();
				List<PointRewardData> list = new List<PointRewardData>(skyArenaRewardList.Count);
				for (int i = 0; i < skyArenaRewardList.Count; i++)
				{
					PointRewardData pointRewardData = default(PointRewardData);
					pointRewardData.Init();
					pointRewardData.point = skyArenaRewardList[i].Floor;
					for (int j = 0; j < skyArenaRewardList[i].Reward.Count; j++)
					{
						pointRewardData.rewardItem.Add((int)skyArenaRewardList[i].Reward[j, 0], (int)skyArenaRewardList[i].Reward[j, 1]);
					}
					list.Add(pointRewardData);
				}
				handler.SetData(list, XSysDefine.XSys_MulActivity_SkyArena);
			}
			handler.SetVisible(true);
		}

		// Token: 0x040047BB RID: 18363
		private XSkyArenaEntranceDocument doc = null;

		// Token: 0x040047BC RID: 18364
		private PointRewardHandler _PointRewardHandler;
	}
}
