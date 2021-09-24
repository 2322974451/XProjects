using System;
using System.Collections;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class WeekShareRewardHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

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

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			this._itemPool.ReturnAll(false);
			this._doc.ShareHandler = null;
			this._doc = null;
			base.OnUnload();
		}

		public void RefreshUI()
		{
			this.RefreshBtnState();
			this.RefreshRewards();
		}

		public void RefreshBtnState()
		{
			this._shareBtn.gameObject.SetActive(!this._doc.HasWeekReward);
			this._getBtn.gameObject.SetActive(this._doc.HasWeekReward);
		}

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

		private bool OnClickGetBtn(IXUIButton button)
		{
			this._doc.SendToGetWeekShareReward();
			return true;
		}

		private bool ClickToShare(IXUIButton button)
		{
			XSingleton<PDatabase>.singleton.shareCallbackType = ShareCallBackType.WeekShare;
			XSingleton<UIManager>.singleton.CloseAllUI();
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.ShowMainView();
			return true;
		}

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

		private IEnumerator RefreshMonday()
		{
			yield return new WaitForEndOfFrame();
			this._doc.DisappearMonday();
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_WeekShareReward, true);
			yield break;
		}

		private IXUIButton _shareBtn;

		private IXUIButton _getBtn;

		private IXUILabel _weekDes;

		private IXUILabel _activityDes;

		private XUIPool _itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		protected XAchievementDocument _doc;
	}
}
