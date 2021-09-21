using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001776 RID: 6006
	internal class GuildTerritoryMainDlg : DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>
	{
		// Token: 0x17003822 RID: 14370
		// (get) Token: 0x0600F7EB RID: 63467 RVA: 0x00388F30 File Offset: 0x00387130
		public override string fileName
		{
			get
			{
				return "Guild/GuildTerritory/GuildTerritoryMainDlg";
			}
		}

		// Token: 0x0600F7EC RID: 63468 RVA: 0x00388F48 File Offset: 0x00387148
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			base.uiBehaviour.mWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnItemWrapUpdate));
			XSingleton<XDebug>.singleton.AddGreenLog(XSingleton<XGlobalConfig>.singleton.GetValue("TerritoryReward"), null, null, null, null, null);
			this.TerritoryRewardValues = XSingleton<XGlobalConfig>.singleton.GetSequenceList("TerritoryReward", false);
			base.uiBehaviour.mWrapContent.SetContentCount((int)this.TerritoryRewardValues.Count, false);
			base.uiBehaviour.mContent.SetText(XStringDefineProxy.GetString("TERRITORY_MAIN_DESCRIPTION"));
			base.uiBehaviour.mCrossGVGDescribe.SetText(XStringDefineProxy.GetString("CrossGVG_selectweek_message"));
			this.InitTerritoryDisplay();
		}

		// Token: 0x17003823 RID: 14371
		// (get) Token: 0x0600F7ED RID: 63469 RVA: 0x0038901C File Offset: 0x0038721C
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F7EE RID: 63470 RVA: 0x00389030 File Offset: 0x00387230
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mMessage.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickMessage));
			base.uiBehaviour.mClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClose));
			base.uiBehaviour.mHelp.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpHandler));
			base.uiBehaviour.mRwd.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRwdClick));
		}

		// Token: 0x0600F7EF RID: 63471 RVA: 0x003890BC File Offset: 0x003872BC
		private bool OnHelpHandler(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildTerritory);
			return false;
		}

		// Token: 0x0600F7F0 RID: 63472 RVA: 0x003890E0 File Offset: 0x003872E0
		private bool OnRwdClick(IXUIButton btn)
		{
			DlgBase<GuildTerritoryRewardDlg, GuildTerritoryRewardBehaviour>.singleton.SetVisible(true, true);
			return false;
		}

		// Token: 0x0600F7F1 RID: 63473 RVA: 0x00389100 File Offset: 0x00387300
		public void RefreshData()
		{
			int i = 0;
			int count = this.mTerritoryDisplays.Count;
			while (i < count)
			{
				this.mTerritoryDisplays[i].Refresh();
				i++;
			}
			bool flag = this._Doc.SelfGuildTerritoryID > 0U;
			if (flag)
			{
				TerritoryBattle.RowData byID = XGuildTerritoryDocument.mGuildTerritoryList.GetByID(this._Doc.SelfGuildTerritoryID);
				base.uiBehaviour.mTerritoryName.SetText(byID.territoryname);
			}
			else
			{
				base.uiBehaviour.mTerritoryName.SetText(XStringDefineProxy.GetString("TERRITORY_CURRENT"));
			}
			bool flag2 = this._Doc.SelfTargetTerritoryID > 0U;
			if (flag2)
			{
				TerritoryBattle.RowData byID2 = XGuildTerritoryDocument.mGuildTerritoryList.GetByID(this._Doc.SelfTargetTerritoryID);
				base.uiBehaviour.mTerritoryTarget.SetText(byID2.territoryname);
			}
			else
			{
				base.uiBehaviour.mTerritoryTarget.SetText(XStringDefineProxy.GetString("TERRITORY_TARGET"));
			}
			base.uiBehaviour.mMessage.SetVisible(this._Doc.CurrentType == GUILDTERRTYPE.TERR_END);
			XCrossGVGDocument specificDocument = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			base.uiBehaviour.mCrossGVG.gameObject.SetActive(specificDocument.TimeStep == CrossGvgTimeState.CGVG_Select);
		}

		// Token: 0x0600F7F2 RID: 63474 RVA: 0x0038924F File Offset: 0x0038744F
		public override void StackRefresh()
		{
			this._Doc.SendGuildTerritoryCityInfo();
		}

		// Token: 0x0600F7F3 RID: 63475 RVA: 0x0038925E File Offset: 0x0038745E
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendGuildTerritoryCityInfo();
		}

		// Token: 0x0600F7F4 RID: 63476 RVA: 0x00389274 File Offset: 0x00387474
		private void OnItemWrapUpdate(Transform t, int index)
		{
			int num = this.TerritoryRewardValues[index, 0];
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(t.gameObject, num, 0, false);
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			Transform transform = t.FindChild("Flag");
			transform.gameObject.SetActive(this.TerritoryRewardValues[index, 1] == 1);
			ixuisprite.ID = (ulong)((long)num);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
		}

		// Token: 0x0600F7F5 RID: 63477 RVA: 0x0038930C File Offset: 0x0038750C
		private bool OnClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F7F6 RID: 63478 RVA: 0x00389328 File Offset: 0x00387528
		private bool OnClickMessage(IXUIButton btn)
		{
			DlgBase<GuildTerritoryMessageDlg, GuildTerritoryMessageBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600F7F7 RID: 63479 RVA: 0x00389348 File Offset: 0x00387548
		private void InitTerritoryDisplay()
		{
			bool flag = this.mTerritoryDisplays == null;
			if (flag)
			{
				this.mTerritoryDisplays = new List<GuildTerritoryDisplay>();
			}
			this.mTerritoryDisplays.Clear();
			int childCount = base.uiBehaviour.mTerritoryTransform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = base.uiBehaviour.mTerritoryTransform.GetChild(i);
				GuildTerritoryDisplay guildTerritoryDisplay = new GuildTerritoryDisplay();
				guildTerritoryDisplay.Init(uint.Parse(child.name), child);
				this.mTerritoryDisplays.Add(guildTerritoryDisplay);
			}
		}

		// Token: 0x04006C24 RID: 27684
		private List<GuildTerritoryDisplay> mTerritoryDisplays;

		// Token: 0x04006C25 RID: 27685
		private XGuildTerritoryDocument _Doc;

		// Token: 0x04006C26 RID: 27686
		private SeqList<int> TerritoryRewardValues;
	}
}
