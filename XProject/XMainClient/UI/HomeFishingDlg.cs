using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HomeFishingDlg : DlgBase<HomeFishingDlg, HomeFishingBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Home/FishingDlg";
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

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XHomeFishingDocument>(XHomeFishingDocument.uuID);
			this._itemDoc = XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID);
			this._sweepDoc = XDocuments.GetSpecificDocument<XSweepDocument>(XSweepDocument.uuID);
			this._welfareDoc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			base.uiBehaviour.m_FishLevelFrame.SetActive(false);
			base.uiBehaviour.m_HighQualityFx.SetActive(false);
			base.uiBehaviour.m_LowQualityFx.SetActive(false);
		}

		protected override void OnLoad()
		{
			DlgHandlerBase.EnsureCreate<XYuyinView>(ref this._yuyinHandler, base.uiBehaviour.transform, true, this);
			this._yuyinHandler.SetVisible(false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_StartFishingBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartFishingBtnClick));
			base.uiBehaviour.m_SweepBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSweepButtonClicked));
			base.uiBehaviour.m_HomeMainBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHomeMainBtnClick));
			base.uiBehaviour.m_HomeShopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHomeShopBtnClick));
			base.uiBehaviour.m_HomeCookingBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHomeCookingBtnClick));
			base.uiBehaviour.m_FishLevelBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFishLevelBtnClick));
			base.uiBehaviour.m_LevelFrameCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFishLevelFrameCloseBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_FishingTips.SetActive(false);
			bool flag = this._yuyinHandler != null;
			if (flag)
			{
				this._yuyinHandler.Show(YuyinIconType.HOME, 2);
				this._yuyinHandler.Refresh(YuyinIconType.HOME);
			}
		}

		protected override void OnHide()
		{
			bool isFishing = this._doc.IsFishing;
			if (isFishing)
			{
				this._doc.LeaveFishing();
				XSingleton<XInput>.singleton.Freezed = false;
			}
			this._itemDoc.ToggleBlock(false);
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetVisible(true, true);
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			base.uiBehaviour.m_HighQualityFx.SetActive(false);
			base.uiBehaviour.m_LowQualityFx.SetActive(false);
			base.OnHide();
		}

		protected override void OnUnload()
		{
			bool isFishing = this._doc.IsFishing;
			if (isFishing)
			{
				this._doc.LeaveFishing();
			}
			XSingleton<XInput>.singleton.Freezed = false;
			this._itemDoc.ToggleBlock(false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			DlgHandlerBase.EnsureUnload<XYuyinView>(ref this._yuyinHandler);
			base.OnUnload();
		}

		public void Refresh(bool showFishResult = false)
		{
			this._itemDoc.ToggleBlock(false);
			bool flag = showFishResult && !this._doc.LastFishingHasFish;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("HomeFishingFail"), "fece00");
			}
			bool lastLevelUp = this._doc.LastLevelUp;
			if (lastLevelUp)
			{
				XSingleton<XFxMgr>.singleton.CreateAndPlay(XHomeFishingDocument.LEVELUPFX, XSingleton<XEntityMgr>.singleton.Player.EngineObject, Vector3.zero, Vector3.one, 1f, false, 2f, true);
				this._doc.LastLevelUp = false;
			}
			base.uiBehaviour.m_FishLevelNum.SetText(this._doc.FishingLevel.ToString());
			GardenFishConfig.RowData byFishLeve = this._doc._HomeFishTable.GetByFishLeve(this._doc.FishingLevel);
			base.uiBehaviour.m_FishExpValue.value = ((byFishLeve.Experience == 0U) ? 1f : (this._doc.CurrentExp * 1f / byFishLeve.Experience));
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(XHomeFishingDocument.stoshID);
			base.uiBehaviour.m_StoshNum.SetText(itemCount.ToString());
			base.uiBehaviour.m_NoStosh.SetActive(itemCount == 0UL);
			base.uiBehaviour.m_NoFishTips.SetActive(this._doc.FishList.Count == 0);
			base.uiBehaviour.m_ItemScrollView.SetPosition(0f);
			base.uiBehaviour.m_FishPool.ReturnAll(false);
			Vector3 tplPos = base.uiBehaviour.m_FishPool.TplPos;
			for (int i = this._doc.FishList.Count - 1; i >= 0; i--)
			{
				GameObject gameObject = base.uiBehaviour.m_FishPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x + (float)((this._doc.FishList.Count - 1 - i) * base.uiBehaviour.m_FishPool.TplWidth), tplPos.y);
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this._doc.FishList[i].itemID);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemConf, (int)this._doc.FishList[i].itemCount, true);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)this._doc.FishList[i].itemID;
				bool flag2 = !itemConf.CanTrade;
				if (flag2)
				{
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnBindItemClick));
				}
				else
				{
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
			}
			bool activeInHierarchy = base.uiBehaviour.m_FishLevelFrame.activeInHierarchy;
			if (activeInHierarchy)
			{
				base.uiBehaviour.m_LevelFrameLevel.SetText(this._doc.FishingLevel.ToString());
				bool flag3 = byFishLeve.Experience == 0U;
				if (flag3)
				{
					base.uiBehaviour.m_LevelFrameExp.SetText(XStringDefineProxy.GetString("FishingLevelMax"));
					base.uiBehaviour.m_LevelFrameExpBar.value = 1f;
				}
				else
				{
					base.uiBehaviour.m_LevelFrameExp.SetText(string.Format("{0}/{1}", this._doc.CurrentExp, byFishLeve.Experience));
					base.uiBehaviour.m_LevelFrameExpBar.value = this._doc.CurrentExp * 1f / byFishLeve.Experience;
				}
			}
		}

		private void ShowFishLevelFrame()
		{
			uint fishingLevel = this._doc.FishingLevel;
			int num = this._doc._HomeFishTable.Table.Length;
			uint num2 = 0U;
			base.uiBehaviour.m_FishLevelFrame.SetActive(true);
			base.uiBehaviour.m_LevelFrameLevel.SetText(this._doc.FishingLevel.ToString());
			base.uiBehaviour.m_FishLevelPool.ReturnAll(false);
			base.uiBehaviour.m_LevelItemPool.ReturnAll(false);
			List<GameObject> list = new List<GameObject>();
			HashSet<int> hashSet = new HashSet<int>();
			for (int i = 0; i < this._doc.FishInfoTable.Table.Length; i++)
			{
				bool flag = !this._doc.FishInfoTable.Table[i].ShowInLevel;
				if (flag)
				{
					hashSet.Add((int)this._doc.FishInfoTable.Table[i].FishID);
				}
			}
			IXUIPanel ixuipanel = base.uiBehaviour.m_FishLevelPool._tpl.transform.parent.GetComponent("XUIPanel") as IXUIPanel;
			int num3 = (int)(fishingLevel - 1U);
			int num4 = num3;
			bool flag2 = false;
			bool flag3 = (float)(base.uiBehaviour.m_FishLevelPool.TplHeight * (num - num3)) < ixuipanel.ClipRange.w;
			if (flag3)
			{
				num4 = 0;
				flag2 = true;
			}
			Vector3 tplPos = base.uiBehaviour.m_FishLevelPool.TplPos;
			Vector3 tplPos2 = base.uiBehaviour.m_LevelItemPool.TplPos;
			for (int j = 0; j < num; j++)
			{
				GardenFishConfig.RowData rowData = this._doc._HomeFishTable.Table[j];
				GameObject gameObject = base.uiBehaviour.m_FishLevelPool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(string.Format("{0}{1}", rowData.FishLeve, XStringDefineProxy.GetString("LevelName")));
				IXUILabel ixuilabel2 = gameObject.transform.Find("Rate").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(string.Format("{0}%", rowData.SuccessRate));
				IXUILabel ixuilabel3 = gameObject.transform.Find("Exp").GetComponent("XUILabel") as IXUILabel;
				ixuilabel3.SetText(num2.ToString());
				num2 = rowData.Experience;
				bool flag4 = j == num3;
				if (flag4)
				{
					base.uiBehaviour.m_LevelFrameExp.SetText(string.Format("{0}/{1}", this._doc.CurrentExp, num2));
					base.uiBehaviour.m_LevelFrameExpBar.value = this._doc.CurrentExp * 1f / num2;
				}
				int num5 = 0;
				for (int k = 0; k < rowData.FishWeight.Count; k++)
				{
					bool flag5 = !hashSet.Contains(rowData.FishWeight[k, 0]);
					if (flag5)
					{
						hashSet.Add(rowData.FishWeight[k, 0]);
						GameObject gameObject2 = base.uiBehaviour.m_LevelItemPool.FetchGameObject(false);
						gameObject2.transform.parent = gameObject.transform;
						gameObject2.transform.localPosition = new Vector3(tplPos2.x + (float)(num5 * base.uiBehaviour.m_LevelItemPool.TplWidth), 0f);
						ItemList.RowData itemConf = XBagDocument.GetItemConf(rowData.FishWeight[k, 0]);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, itemConf, 0, false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject2, rowData.FishWeight[k, 0]);
						num5++;
					}
				}
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(base.uiBehaviour.m_FishLevelPool.TplHeight * (j - num4)), 0f);
				bool flag6 = !flag2 && j < num3;
				if (flag6)
				{
					gameObject.SetActive(false);
					list.Add(gameObject);
				}
			}
			base.uiBehaviour.m_FishLevelScrollView.ResetPosition();
			bool flag7 = flag2;
			if (flag7)
			{
				base.uiBehaviour.m_FishLevelScrollView.SetPosition(1f);
			}
			else
			{
				for (int l = 0; l < list.Count; l++)
				{
					list[l].SetActive(true);
				}
			}
		}

		private bool OnFishLevelBtnClick(IXUIButton btn)
		{
			this.ShowFishLevelFrame();
			return true;
		}

		private bool OnFishLevelFrameCloseBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_FishLevelFrame.SetActive(false);
			return true;
		}

		private bool OnSweepButtonClicked(IXUIButton button)
		{
			bool flag = DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer);
			if (flag)
			{
				bool flag2 = XBagDocument.BagDoc.GetItemCount(XHomeFishingDocument.stoshID) == 0UL;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FishingStoshLess"), "fece00");
					return true;
				}
				bool flag3 = !XOutlookHelper.CanPlaySpecifiedAnimation(XSingleton<XEntityMgr>.singleton.Player);
				if (flag3)
				{
					return true;
				}
				bool flag4 = DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IsLoaded() && DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IsVisible();
				if (flag4)
				{
					DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(false, true);
				}
				this._doc.isSweep = true;
				this._yuyinHandler.SetVisible(true);
				this._doc.SendLevelExpQuery();
				this._doc.FishList.Clear();
				base.uiBehaviour.m_NoFishTips.SetActive(true);
				this.Refresh(false);
				base.uiBehaviour.m_InFishingFrame.SetActive(true);
				base.uiBehaviour.m_NotFishingFrame.SetActive(false);
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetVisible(false, true);
				DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetForceShow(true);
				XSingleton<XInput>.singleton.Freezed = true;
				this._doc.StartFishing();
			}
			return true;
		}

		private bool OnStartFishingBtnClick(IXUIButton btn)
		{
			bool flag = XBagDocument.BagDoc.GetItemCount(XHomeFishingDocument.stoshID) == 0UL;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FishingStoshLess"), "fece00");
				result = true;
			}
			else
			{
				bool flag2 = !XOutlookHelper.CanPlaySpecifiedAnimation(XSingleton<XEntityMgr>.singleton.Player);
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IsLoaded() && DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(false, true);
					}
					this._doc.isSweep = false;
					this._yuyinHandler.SetVisible(true);
					this._doc.SendLevelExpQuery();
					this._doc.FishList.Clear();
					base.uiBehaviour.m_NoFishTips.SetActive(true);
					this.Refresh(false);
					base.uiBehaviour.m_InFishingFrame.SetActive(true);
					base.uiBehaviour.m_NotFishingFrame.SetActive(false);
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetVisible(false, true);
					DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetForceShow(true);
					XSingleton<XInput>.singleton.Freezed = true;
					this._doc.StartFishing();
					result = true;
				}
			}
			return result;
		}

		private bool OnHomeMainBtnClick(IXUIButton btn)
		{
			DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Home);
			return true;
		}

		private bool OnHomeCookingBtnClick(IXUIButton btn)
		{
			DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Home_Cooking);
			return true;
		}

		public bool OnCloseBtnClick(IXUIButton btn)
		{
			this._yuyinHandler.SetVisible(false);
			this._doc.LeaveFishing();
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetForceShow(false);
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetFakeHide(false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			base.uiBehaviour.m_InFishingFrame.SetActive(false);
			base.uiBehaviour.m_HighQualityFx.SetActive(false);
			base.uiBehaviour.m_LowQualityFx.SetActive(false);
			base.uiBehaviour.m_NotFishingFrame.SetActive(true);
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetVisible(true, true);
			XSingleton<XInput>.singleton.Freezed = false;
			this._itemDoc.ToggleBlock(false);
			bool flag = this._doc.FishList.Count != 0;
			if (flag)
			{
				DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.ShowByTitle(this._doc.FishList, XStringDefineProxy.GetString("FishRewardTitle"), null);
			}
			return true;
		}

		public void SetFishingTipsState(bool state)
		{
			base.uiBehaviour.m_FishingTips.SetActive(state);
		}

		private bool OnHomeShopBtnClick(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Home, 0UL);
			return true;
		}

		public void SetUIState(bool state)
		{
			if (state)
			{
				this.SetVisibleWithAnimation(true, null);
				base.uiBehaviour.m_InFishingFrame.SetActive(false);
				base.uiBehaviour.m_NotFishingFrame.SetActive(true);
			}
			else
			{
				this.SetVisible(false, true);
			}
		}

		public void PlayGetFishFx(bool high)
		{
			base.uiBehaviour.m_HighQualityFx.SetActive(false);
			base.uiBehaviour.m_LowQualityFx.SetActive(false);
			if (high)
			{
				base.uiBehaviour.m_HighQualityFx.SetActive(true);
			}
			else
			{
				base.uiBehaviour.m_LowQualityFx.SetActive(true);
			}
		}

		public void DelayShowFish()
		{
			this._timeToken = XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this.ShowGetFish), null);
		}

		private void ShowGetFish(object o = null)
		{
			this.Refresh(true);
		}

		private XHomeFishingDocument _doc = null;

		private XCharacterItemDocument _itemDoc = null;

		private XSweepDocument _sweepDoc = null;

		private XWelfareDocument _welfareDoc = null;

		public XYuyinView _yuyinHandler;

		private uint _timeToken;
	}
}
