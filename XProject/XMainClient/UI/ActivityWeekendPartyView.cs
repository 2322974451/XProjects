using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001708 RID: 5896
	internal class ActivityWeekendPartyView : DlgBase<ActivityWeekendPartyView, ActivityWeekendPartyBehaviour>
	{
		// Token: 0x17003782 RID: 14210
		// (get) Token: 0x0600F366 RID: 62310 RVA: 0x00365628 File Offset: 0x00363828
		public override string fileName
		{
			get
			{
				return "GameSystem/WeekendPartyDlg";
			}
		}

		// Token: 0x17003783 RID: 14211
		// (get) Token: 0x0600F367 RID: 62311 RVA: 0x00365640 File Offset: 0x00363840
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003784 RID: 14212
		// (get) Token: 0x0600F368 RID: 62312 RVA: 0x00365654 File Offset: 0x00363854
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003785 RID: 14213
		// (get) Token: 0x0600F369 RID: 62313 RVA: 0x00365668 File Offset: 0x00363868
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003786 RID: 14214
		// (get) Token: 0x0600F36A RID: 62314 RVA: 0x0036567C File Offset: 0x0036387C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003787 RID: 14215
		// (get) Token: 0x0600F36B RID: 62315 RVA: 0x00365690 File Offset: 0x00363890
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F36C RID: 62316 RVA: 0x003656A3 File Offset: 0x003638A3
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID);
		}

		// Token: 0x0600F36D RID: 62317 RVA: 0x003656BD File Offset: 0x003638BD
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.ReqWeekendPartInfo();
			this.RefreshMatchBtn();
			base.uiBehaviour.m_TimeTip.SetText(XSingleton<XStringTable>.singleton.GetString("WeekendPartyTimeTip"));
		}

		// Token: 0x0600F36E RID: 62318 RVA: 0x003656FC File Offset: 0x003638FC
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

		// Token: 0x0600F36F RID: 62319 RVA: 0x003658A0 File Offset: 0x00363AA0
		private void FillAwardItem(GameObject item, uint id, uint count)
		{
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(item, (int)id, (int)count, false);
			IXUISprite ixuisprite = item.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)id;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
		}

		// Token: 0x0600F370 RID: 62320 RVA: 0x00365904 File Offset: 0x00363B04
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_SingleMatch.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSingleMatchClick));
			base.uiBehaviour.m_TeamMatch.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTeamMatchClick));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClick));
		}

		// Token: 0x0600F371 RID: 62321 RVA: 0x0036598D File Offset: 0x00363B8D
		protected override void OnHide()
		{
			base.uiBehaviour.m_Bg.SetTexturePath("");
		}

		// Token: 0x0600F372 RID: 62322 RVA: 0x003659A8 File Offset: 0x00363BA8
		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F373 RID: 62323 RVA: 0x003659C4 File Offset: 0x00363BC4
		private bool OnHelpBtnClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_MulActivity_WeekendParty);
			return true;
		}

		// Token: 0x0600F374 RID: 62324 RVA: 0x003659E8 File Offset: 0x00363BE8
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

		// Token: 0x0600F375 RID: 62325 RVA: 0x00365A4C File Offset: 0x00363C4C
		public void RefreshMatchBtn()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			base.uiBehaviour.m_SingleMatchLabel.SetText((specificDocument.SoloMatchType == KMatchType.KMT_WEEKEND_ACT) ? string.Format("{0}...", XStringDefineProxy.GetString("MATCHING")) : XStringDefineProxy.GetString("CAPTAINPVP_SINGLE"));
			base.uiBehaviour.m_TeamMatch.SetEnable(specificDocument.SoloMatchType != KMatchType.KMT_WEEKEND_ACT, false);
		}

		// Token: 0x0600F376 RID: 62326 RVA: 0x00365AC0 File Offset: 0x00363CC0
		private bool OnTeamMatchClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch((int)this.sceneID);
			return true;
		}

		// Token: 0x04006888 RID: 26760
		private XWeekendPartyDocument _Doc;

		// Token: 0x04006889 RID: 26761
		private uint sceneID = 0U;
	}
}
