using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildTerritoryMainDlg : DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildTerritory/GuildTerritoryMainDlg";
			}
		}

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

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mMessage.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickMessage));
			base.uiBehaviour.mClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClose));
			base.uiBehaviour.mHelp.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpHandler));
			base.uiBehaviour.mRwd.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRwdClick));
		}

		private bool OnHelpHandler(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildTerritory);
			return false;
		}

		private bool OnRwdClick(IXUIButton btn)
		{
			DlgBase<GuildTerritoryRewardDlg, GuildTerritoryRewardBehaviour>.singleton.SetVisible(true, true);
			return false;
		}

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

		public override void StackRefresh()
		{
			this._Doc.SendGuildTerritoryCityInfo();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendGuildTerritoryCityInfo();
		}

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

		private bool OnClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnClickMessage(IXUIButton btn)
		{
			DlgBase<GuildTerritoryMessageDlg, GuildTerritoryMessageBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

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

		private List<GuildTerritoryDisplay> mTerritoryDisplays;

		private XGuildTerritoryDocument _Doc;

		private SeqList<int> TerritoryRewardValues;
	}
}
