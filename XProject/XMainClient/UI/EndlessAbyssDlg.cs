using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200170B RID: 5899
	internal class EndlessAbyssDlg : DlgBase<EndlessAbyssDlg, EndlessAbyssBehaviour>
	{
		// Token: 0x1700378C RID: 14220
		// (get) Token: 0x0600F384 RID: 62340 RVA: 0x00365DA0 File Offset: 0x00363FA0
		public override string fileName
		{
			get
			{
				return "GameSystem/EndlessAbyssDlg";
			}
		}

		// Token: 0x1700378D RID: 14221
		// (get) Token: 0x0600F385 RID: 62341 RVA: 0x00365DB8 File Offset: 0x00363FB8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700378E RID: 14222
		// (get) Token: 0x0600F386 RID: 62342 RVA: 0x00365DCC File Offset: 0x00363FCC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700378F RID: 14223
		// (get) Token: 0x0600F387 RID: 62343 RVA: 0x00365DE0 File Offset: 0x00363FE0
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003790 RID: 14224
		// (get) Token: 0x0600F388 RID: 62344 RVA: 0x00365DF4 File Offset: 0x00363FF4
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003791 RID: 14225
		// (get) Token: 0x0600F389 RID: 62345 RVA: 0x00365E08 File Offset: 0x00364008
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F38A RID: 62346 RVA: 0x00365E1B File Offset: 0x0036401B
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this.RefreshTimes();
		}

		// Token: 0x0600F38B RID: 62347 RVA: 0x00365E38 File Offset: 0x00364038
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
			base.uiBehaviour.m_goBattleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterTeamClick));
			base.uiBehaviour.m_shopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoToShop));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x0600F38C RID: 62348 RVA: 0x00365EC4 File Offset: 0x003640C4
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_EndlessAbyss);
			return true;
		}

		// Token: 0x0600F38D RID: 62349 RVA: 0x00365EE7 File Offset: 0x003640E7
		protected override void OnShow()
		{
			this.RequstLeftCount();
			this.FillItem();
		}

		// Token: 0x0600F38E RID: 62350 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnHide()
		{
		}

		// Token: 0x0600F38F RID: 62351 RVA: 0x00365EF8 File Offset: 0x003640F8
		private bool OnGoToShop(IXUIButton button)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(EndlessAbyssDlg.GetShopSystem(), 0UL);
			return true;
		}

		// Token: 0x0600F390 RID: 62352 RVA: 0x00365F20 File Offset: 0x00364120
		public static XSysDefine GetShopSystem()
		{
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("EndlessabyssLevelInterval", true);
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("EndlessabyssShopType");
			int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			for (int i = 0; i < (int)sequenceList.Count; i++)
			{
				bool flag = level >= sequenceList[i, 0] && level <= sequenceList[i, 1];
				if (flag)
				{
					return (XSysDefine)(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Mall_MystShop) + intList[i]);
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("Can't find player level state from golbalconfig EndlessabyssLevelInterval. level = ", level.ToString(), null, null, null, null);
			return XSysDefine.XSys_Mall_32A;
		}

		// Token: 0x0600F391 RID: 62353 RVA: 0x00365FDC File Offset: 0x003641DC
		private void FillItem()
		{
			string text = "";
			List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("EndlessabyssDropShow");
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("EndlessabyssLevelInterval", true);
			bool flag = (int)sequenceList.Count != stringList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("EndlessAbyss reward config error! level interval's count is not the same as reward interval's cout.", null, null, null, null, null);
			}
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			for (int i = 0; i < (int)sequenceList.Count; i++)
			{
				bool flag2 = (ulong)level >= (ulong)((long)sequenceList[i, 0]) && (ulong)level <= (ulong)((long)sequenceList[i, 1]);
				if (flag2)
				{
					text = stringList[i];
				}
			}
			bool flag3 = text == "";
			if (flag3)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Can't find the reward of EndlessAbyss from globalconfig, level = ", level.ToString(), null, null, null, null);
			}
			string[] array = text.Split(XGlobalConfig.SequenceSeparator);
			base.uiBehaviour.m_ItemPool.ReturnAll(false);
			Vector3 tplPos = base.uiBehaviour.m_ItemPool.TplPos;
			float num = tplPos.x - ((float)array.Length - 1f) / 2f * (float)base.uiBehaviour.m_ItemPool.TplWidth;
			for (int j = 0; j < array.Length; j++)
			{
				int num2 = int.Parse(array[j]);
				GameObject gameObject = base.uiBehaviour.m_ItemPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(num + (float)(j * base.uiBehaviour.m_ItemPool.TplWidth), tplPos.y);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, num2, 0, false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)num2);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ShowTip));
			}
		}

		// Token: 0x0600F392 RID: 62354 RVA: 0x003661F0 File Offset: 0x003643F0
		public void RefreshTimes()
		{
			bool flag = this._doc == null || !base.IsVisible();
			if (!flag)
			{
				int dayCount = this._doc.GetDayCount(TeamLevelType.TeamLevelEndlessAbyss, null);
				int dayMaxCount = this._doc.GetDayMaxCount(TeamLevelType.TeamLevelEndlessAbyss, null);
				base.uiBehaviour.m_canJoinTimeslab.SetText(string.Format("{0}/{1}", dayCount, dayMaxCount));
				bool flag2 = dayCount > 0;
				base.uiBehaviour.m_goBattleBtn.SetVisible(flag2);
				base.uiBehaviour.m_noTimesGo.SetActive(!flag2);
			}
		}

		// Token: 0x0600F393 RID: 62355 RVA: 0x0036628C File Offset: 0x0036448C
		private void RequstLeftCount()
		{
			List<ExpeditionTable.RowData> expeditionList = this._doc.GetExpeditionList(TeamLevelType.TeamLevelEndlessAbyss);
			bool flag = expeditionList != null && expeditionList.Count > 0;
			if (flag)
			{
				XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
				for (int i = 0; i < expeditionList.Count; i++)
				{
					bool flag2 = specificDocument.SealType == expeditionList[i].LevelSealType;
					if (flag2)
					{
						this._doc.ExpeditionId = expeditionList[i].DNExpeditionID;
						XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
						specificDocument2.ReqTeamOp(TeamOperate.TEAM_QUERYCOUNT, 0UL, null, TeamMemberType.TMT_NORMAL, null);
						return;
					}
				}
			}
			XSingleton<XDebug>.singleton.AddLog("Df data is error,not find target DATA!", null, null, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x0600F394 RID: 62356 RVA: 0x00366348 File Offset: 0x00364548
		private bool OnCloseDlg(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F395 RID: 62357 RVA: 0x00366364 File Offset: 0x00364564
		private bool OnEnterTeamClick(IXUIButton button)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch(this._doc.ExpeditionId);
			return true;
		}

		// Token: 0x0600F396 RID: 62358 RVA: 0x00366394 File Offset: 0x00364594
		private void ShowTip(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.OnItemClick(sp);
		}

		// Token: 0x04006894 RID: 26772
		private XExpeditionDocument _doc;
	}
}
