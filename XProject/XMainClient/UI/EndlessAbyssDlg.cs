using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EndlessAbyssDlg : DlgBase<EndlessAbyssDlg, EndlessAbyssBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/EndlessAbyssDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this.RefreshTimes();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
			base.uiBehaviour.m_goBattleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterTeamClick));
			base.uiBehaviour.m_shopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoToShop));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_EndlessAbyss);
			return true;
		}

		protected override void OnShow()
		{
			this.RequstLeftCount();
			this.FillItem();
		}

		protected override void OnHide()
		{
		}

		private bool OnGoToShop(IXUIButton button)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(EndlessAbyssDlg.GetShopSystem(), 0UL);
			return true;
		}

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

		private bool OnCloseDlg(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnEnterTeamClick(IXUIButton button)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch(this._doc.ExpeditionId);
			return true;
		}

		private void ShowTip(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.OnItemClick(sp);
		}

		private XExpeditionDocument _doc;
	}
}
