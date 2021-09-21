using System;
using System.Collections;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001714 RID: 5908
	internal class WeekShareRewardHandler : DlgHandlerBase
	{
		// Token: 0x0600F3F9 RID: 62457 RVA: 0x00369833 File Offset: 0x00367A33
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600F3FA RID: 62458 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F3FB RID: 62459 RVA: 0x00369844 File Offset: 0x00367A44
		protected override void OnShow()
		{
			base.OnShow();
			bool flag = !this._doc.Monday;
			if (flag)
			{
				DlgBase<RewardSystemDlg, TabDlgBehaviour>.singleton.uiBehaviour.StartCoroutine(this.RefreshMonday());
			}
			this.RefreshUI();
		}

		// Token: 0x0600F3FC RID: 62460 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F3FD RID: 62461 RVA: 0x0036988A File Offset: 0x00367A8A
		public override void OnUnload()
		{
			this._itemPool.ReturnAll(false);
			this._doc.ShareHandler = null;
			this._doc = null;
			base.OnUnload();
		}

		// Token: 0x0600F3FE RID: 62462 RVA: 0x003698B5 File Offset: 0x00367AB5
		public void RefreshUI()
		{
			this.RefreshBtnState();
			this.RefreshRewards();
		}

		// Token: 0x0600F3FF RID: 62463 RVA: 0x003698C6 File Offset: 0x00367AC6
		public void RefreshBtnState()
		{
			this._shareBtn.gameObject.SetActive(!this._doc.HasWeekReward);
			this._getBtn.gameObject.SetActive(this._doc.HasWeekReward);
		}

		// Token: 0x0600F400 RID: 62464 RVA: 0x00369904 File Offset: 0x00367B04
		private void InitProperties()
		{
			this._doc = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
			this._doc.ShareHandler = this;
			this._shareBtn = (base.transform.Find("BtnShare").GetComponent("XUIButton") as IXUIButton);
			this._shareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickToShare));
			this._getBtn = (base.transform.Find("BtnGet").GetComponent("XUIButton") as IXUIButton);
			this._getBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGetBtn));
			this._weekDes = (base.transform.Find("WeekDesc").GetComponent("XUILabel") as IXUILabel);
			this._activityDes = (base.transform.Find("ActivityDes").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("ItemList");
			GameObject gameObject = transform.Find("ItemTpl").gameObject;
			this._itemPool.SetupPool(transform.gameObject, gameObject, 4U, false);
		}

		// Token: 0x0600F401 RID: 62465 RVA: 0x00369A2C File Offset: 0x00367C2C
		private bool OnClickGetBtn(IXUIButton button)
		{
			this._doc.SendToGetWeekShareReward();
			return true;
		}

		// Token: 0x0600F402 RID: 62466 RVA: 0x00369A4C File Offset: 0x00367C4C
		private bool ClickToShare(IXUIButton button)
		{
			XSingleton<PDatabase>.singleton.shareCallbackType = ShareCallBackType.WeekShare;
			XSingleton<UIManager>.singleton.CloseAllUI();
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.ShowMainView();
			return true;
		}

		// Token: 0x0600F403 RID: 62467 RVA: 0x00369A90 File Offset: 0x00367C90
		private void RefreshRewards()
		{
			this._weekDes.SetText(XSingleton<XStringTable>.singleton.GetString("WeekRewardsTime"));
			this._activityDes.SetText(XSingleton<XStringTable>.singleton.GetString("WeekShareDec"));
			this._itemPool.ReturnAll(false);
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("WeekShareReward", true);
			for (int i = 0; i < (int)sequenceList.Count; i++)
			{
				GameObject gameObject = this._itemPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(i * this._itemPool.TplWidth), 0f, 0f);
				IXUILabel ixuilabel = gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
				int num = sequenceList[i, 0];
				int itemCount = sequenceList[i, 1];
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, num, itemCount, true);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)num);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		// Token: 0x0600F404 RID: 62468 RVA: 0x00369BD5 File Offset: 0x00367DD5
		private IEnumerator RefreshMonday()
		{
			yield return new WaitForEndOfFrame();
			this._doc.DisappearMonday();
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_WeekShareReward, true);
			yield break;
		}

		// Token: 0x040068E6 RID: 26854
		private IXUIButton _shareBtn;

		// Token: 0x040068E7 RID: 26855
		private IXUIButton _getBtn;

		// Token: 0x040068E8 RID: 26856
		private IXUILabel _weekDes;

		// Token: 0x040068E9 RID: 26857
		private IXUILabel _activityDes;

		// Token: 0x040068EA RID: 26858
		private XUIPool _itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040068EB RID: 26859
		protected XAchievementDocument _doc;
	}
}
