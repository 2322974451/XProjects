using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ActivityWeekendPartyView : DlgBase<ActivityWeekendPartyView, ActivityWeekendPartyBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/WeekendPartyDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
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

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.ReqWeekendPartInfo();
			this.RefreshMatchBtn();
			base.uiBehaviour.m_TimeTip.SetText(XSingleton<XStringTable>.singleton.GetString("WeekendPartyTimeTip"));
		}

		public void RefreshActivityInfo(WeekEnd4v4GetInfoRes oRes)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				WeekEnd4v4List.RowData activityInfo = this._Doc.GetActivityInfo(oRes.thisActivityID);
				bool flag2 = activityInfo != null;
				if (flag2)
				{
					this.sceneID = activityInfo.SceneID;
					base.uiBehaviour.m_CurrActName.SetText(activityInfo.Name);
					base.uiBehaviour.m_Rule.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(activityInfo.Rule));
					base.uiBehaviour.m_Bg.SetTexturePath(activityInfo.TexturePath);
					base.uiBehaviour.m_Times.SetText(string.Format("{0}/{1}", (activityInfo.RewardTimes > oRes.joinCount) ? (activityInfo.RewardTimes - oRes.joinCount) : 0U, activityInfo.RewardTimes));
					base.uiBehaviour.m_DropAwardPool.FakeReturnAll();
					for (int i = 0; i < activityInfo.DropItems.Count; i++)
					{
						GameObject gameObject = base.uiBehaviour.m_DropAwardPool.FetchGameObject(false);
						gameObject.transform.parent = base.uiBehaviour.m_DropAward.gameObject.transform;
						gameObject.transform.localScale = Vector3.one;
						this.FillAwardItem(gameObject, activityInfo.DropItems[i, 0], activityInfo.DropItems[i, 1]);
					}
					base.uiBehaviour.m_DropAwardPool.ActualReturnAll(true);
					base.uiBehaviour.m_DropAward.Refresh();
				}
			}
		}

		private void FillAwardItem(GameObject item, uint id, uint count)
		{
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(item, (int)id, (int)count, false);
			IXUISprite ixuisprite = item.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)id;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_SingleMatch.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSingleMatchClick));
			base.uiBehaviour.m_TeamMatch.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTeamMatchClick));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClick));
		}

		protected override void OnHide()
		{
			base.uiBehaviour.m_Bg.SetTexturePath("");
		}

		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnHelpBtnClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_MulActivity_WeekendParty);
			return true;
		}

		private bool OnSingleMatchClick(IXUIButton btn)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool bInTeam = specificDocument.bInTeam;
			bool result;
			if (bInTeam)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CAPTAIN_SINGLE_MATCH_TIP"), "fece00");
				result = false;
			}
			else
			{
				KMatchOp op = (specificDocument.SoloMatchType != KMatchType.KMT_WEEKEND_ACT) ? KMatchOp.KMATCH_OP_START : KMatchOp.KMATCH_OP_STOP;
				specificDocument.ReqMatchStateChange(KMatchType.KMT_WEEKEND_ACT, op, false);
				result = true;
			}
			return result;
		}

		public void RefreshMatchBtn()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			base.uiBehaviour.m_SingleMatchLabel.SetText((specificDocument.SoloMatchType == KMatchType.KMT_WEEKEND_ACT) ? string.Format("{0}...", XStringDefineProxy.GetString("MATCHING")) : XStringDefineProxy.GetString("CAPTAINPVP_SINGLE"));
			base.uiBehaviour.m_TeamMatch.SetEnable(specificDocument.SoloMatchType != KMatchType.KMT_WEEKEND_ACT, false);
		}

		private bool OnTeamMatchClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch((int)this.sceneID);
			return true;
		}

		private XWeekendPartyDocument _Doc;

		private uint sceneID = 0U;
	}
}
