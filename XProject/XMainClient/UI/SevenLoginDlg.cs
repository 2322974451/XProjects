using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SevenLoginDlg : DlgBase<SevenLoginDlg, SevenLoginBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/SevenAwardDlg";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SevenActivity);
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

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickCloseHandle));
			base.uiBehaviour.m_dialogClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickDialogClose));
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XSevenLoginDocument>(XSevenLoginDocument.uuID);
			this._Doc.SevenLoginView = this;
			base.uiBehaviour.m_dialogTransform.gameObject.SetActive(false);
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			this.m_WrapContentItems = new List<SevenLoginWrapItem>();
			this.m_ItemEffectList = new List<XFx>();
			this.m_ItemScale = new Vector3(0.8f, 0.8f, 0.8f);
		}

		protected override void OnUnload()
		{
			bool flag = this.m_WrapContentItems != null;
			if (flag)
			{
				int i = 0;
				int count = this.m_WrapContentItems.Count;
				while (i < count)
				{
					this.m_WrapContentItems[i] = null;
					i++;
				}
				this.m_WrapContentItems.Clear();
				this.m_WrapContentItems = null;
			}
			bool flag2 = this.m_ItemEffectList != null;
			if (flag2)
			{
				int j = 0;
				int count2 = this.m_ItemEffectList.Count;
				while (j < count2)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this.m_ItemEffectList[j], true);
					j++;
				}
				this.m_ItemEffectList.Clear();
				this.m_ItemEffectList = null;
			}
			this.ClearShardTexture();
			this.ClearDialogSharedTexture();
			this._Doc.SevenLoginView = null;
			base.OnUnload();
		}

		private void ClearEffectList()
		{
			bool flag = this.m_ItemEffectList != null;
			if (flag)
			{
				int i = 0;
				int count = this.m_ItemEffectList.Count;
				while (i < count)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this.m_ItemEffectList[i], true);
					i++;
				}
				this.m_ItemEffectList.Clear();
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
		}

		protected override void OnHide()
		{
			int i = 0;
			int count = this.m_ItemEffectList.Count;
			while (i < count)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_ItemEffectList[i], true);
				i++;
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_TimeRecord);
			base.OnHide();
		}

		public void Refresh()
		{
			this.ConfigSevenItemList();
			this.ConfigSevenMessage();
			this.ConfigImportTime(null);
		}

		public void ShowDialogSheredTexture()
		{
			bool flag = this._Doc.NextImportItem == 0;
			if (!flag)
			{
				this.ClearDialogSharedTexture();
				string dialogSharedString = this._Doc.GetDialogSharedString();
				bool flag2 = string.IsNullOrEmpty(dialogSharedString) || dialogSharedString.Equals(this.m_dialogSharedLocation);
				if (!flag2)
				{
					base.uiBehaviour.m_dialogTexture.SetTexturePath(dialogSharedString);
					this.m_dialogSharedLocation = dialogSharedString;
					base.uiBehaviour.m_dialogTransform.gameObject.SetActive(true);
					base.uiBehaviour.m_dialogTexture.MakePixelPerfect();
				}
			}
		}

		private bool ClickDialogClose(IXUIButton btn)
		{
			base.uiBehaviour.m_dialogTransform.gameObject.SetActive(false);
			return true;
		}

		private bool OnClickCloseHandle(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private void ConfigImportTime(object o)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_TimeRecord);
			int lastSecond = this._Doc.GetLastSecond();
			bool flag = lastSecond > 0;
			if (flag)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(this._Doc.NextImportItem);
				base.uiBehaviour.m_LoginDayLabel.SetText(XStringDefineProxy.GetString("SEVEN_LOGIN_TIMERECORD", new object[]
				{
					(itemConf == null) ? string.Empty : itemConf.ItemName[0],
					XSingleton<UiUtility>.singleton.TimeDuarationFormatString(lastSecond, 3)
				}));
				this.m_TimeRecord = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.ConfigImportTime), null);
			}
			else
			{
				base.uiBehaviour.m_LoginDayLabel.SetText(string.Empty);
			}
		}

		private void ConfigSevenMessage()
		{
			bool flag = this._Doc.NextImportDay > 0;
			if (flag)
			{
				base.uiBehaviour.m_MessageLabel.SetVisible(true);
				string key = XSingleton<XCommon>.singleton.StringCombine("SEVEN_LOGIN_MESSAGE", this._Doc.NextImportDay.ToString());
				ItemList.RowData itemConf = XBagDocument.GetItemConf(this._Doc.NextImportItem);
				base.uiBehaviour.m_MessageLabel.SetText(XStringDefineProxy.GetString(key, new object[]
				{
					this._Doc.NextImportDay,
					(itemConf == null) ? string.Empty : itemConf.ItemName[0]
				}));
				string sharedString = this._Doc.GetSharedString();
				base.uiBehaviour.m_shardTexture.SetTexturePath(sharedString);
			}
			else
			{
				this.ResetShow();
				base.uiBehaviour.m_MessageLabel.SetVisible(false);
			}
		}

		private void ClearShardTexture()
		{
			base.uiBehaviour.m_shardTexture.SetTexturePath("");
		}

		private void ClearDialogSharedTexture()
		{
			this.m_uiBehaviour.m_dialogTexture.SetTexturePath("");
			this.m_dialogSharedLocation = string.Empty;
		}

		private void ResetShow()
		{
			int i = 0;
			int count = this.m_ItemEffectList.Count;
			while (i < count)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_ItemEffectList[i], true);
				i++;
			}
		}

		private void ConfigSevenItemList()
		{
			this.ClearEffectList();
			int i = this.m_WrapContentItems.Count;
			List<LoginReward> loginRewards = this._Doc.LoginRewards;
			loginRewards.Sort(new Comparison<LoginReward>(this.CompareWrapItem));
			int count = loginRewards.Count;
			Vector3 localPosition = base.uiBehaviour.m_WrapContentTemp.localPosition;
			while (i < count)
			{
				GameObject gameObject = XCommon.Instantiate<GameObject>(base.uiBehaviour.m_WrapContentTemp.gameObject);
				gameObject.SetActive(true);
				gameObject.name = XSingleton<XCommon>.singleton.StringCombine("WrapItem_", i.ToString());
				gameObject.transform.parent = base.uiBehaviour.m_WrapContentScrollView.gameObject.transform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = localPosition;
				localPosition.y += (float)this.m_wrapContentHeight;
				SevenLoginWrapItem sevenLoginWrapItem = new SevenLoginWrapItem();
				sevenLoginWrapItem.Init(gameObject.transform);
				this.m_WrapContentItems.Add(sevenLoginWrapItem);
				sevenLoginWrapItem.m_GetButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetRewardClick));
				i++;
			}
			base.uiBehaviour.m_RewardPool.FakeReturnAll();
			for (int j = 0; j < i; j++)
			{
				bool flag = j < count;
				if (flag)
				{
					this.WrapContentItemUpdated(this.m_WrapContentItems[j], loginRewards[j]);
				}
				else
				{
					this.WrapContentItemUpdated(this.m_WrapContentItems[j], null);
				}
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(this.m_WrapContentItems[j].transform.gameObject);
			}
			base.uiBehaviour.m_RewardPool.ActualReturnAll(false);
			base.uiBehaviour.m_WrapContentScrollView.ResetPosition();
		}

		private bool OnGetRewardClick(IXUIButton btn)
		{
			this.mCurDayID = (int)btn.ID;
			int num = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.FATIGUE);
			uint redayFatigue = this._Doc.GetRedayFatigue(this.mCurDayID);
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("MaxFatigue");
			bool flag = redayFatigue > 0U && (long)num + (long)((ulong)redayFatigue) > (long)@int;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowFatigueSureDlg(new ButtonClickEventHandler(this.GetSureLogReward));
			}
			else
			{
				btn.SetEnable(false, false);
				this.GetSureLogReward(null);
			}
			return true;
		}

		private bool GetSureLogReward(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._Doc.GetLoginReward(this.mCurDayID);
			return true;
		}

		private void SetItemEffect(GameObject parent, string effectName)
		{
			bool flag = string.IsNullOrEmpty(effectName);
			if (!flag)
			{
				XFx xfx = XSingleton<XFxMgr>.singleton.CreateUIFx(effectName, parent.transform, false);
				bool flag2 = xfx != null;
				if (flag2)
				{
					this.m_ItemEffectList.Add(xfx);
				}
			}
		}

		private void WrapContentItemUpdated(SevenLoginWrapItem slwi, LoginReward reward)
		{
			bool flag = reward == null;
			if (flag)
			{
				slwi.Set(null);
			}
			else
			{
				List<ItemBrief> items = reward.items;
				slwi.Set(reward);
				int i = 0;
				int count = items.Count;
				while (i < count)
				{
					GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
					gameObject.transform.parent = slwi.RewardParent;
					gameObject.transform.localPosition = new Vector3(this.m_RewardStartPos.x + (float)(i * 75), this.m_RewardStartPos.y, this.m_RewardStartPos.z);
					gameObject.transform.localScale = this.m_ItemScale;
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite2 = gameObject.transform.FindChild("Quality").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)items[i].itemID;
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)items[i].itemID);
					this.SetItemEffect(ixuisprite2.gameObject, itemConf.ItemEffect);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemConf, (int)items[i].itemCount, false);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					i++;
				}
			}
		}

		private int CompareWrapItem(LoginReward reward1, LoginReward reward2)
		{
			bool flag = reward1.state == reward2.state;
			int result;
			if (flag)
			{
				result = reward2.day - reward1.day;
			}
			else
			{
				result = this.GetSortIndexByState(reward1.state) - this.GetSortIndexByState(reward2.state);
			}
			return result;
		}

		private int GetSortIndexByState(LoginRewardState state)
		{
			int result = 0;
			switch (state)
			{
			case LoginRewardState.LOGINRS_CANNOT:
				result = 2;
				break;
			case LoginRewardState.LOGINRS_HAVEHOT:
				result = 3;
				break;
			case LoginRewardState.LOGINRS_HAVE:
				result = 1;
				break;
			}
			return result;
		}

		private XSevenLoginDocument _Doc;

		private List<SevenLoginWrapItem> m_WrapContentItems;

		private int m_wrapContentHeight = 104;

		private Vector3 m_RewardStartPos = Vector3.zero;

		private uint m_TimeRecord = 0U;

		private List<XFx> m_ItemEffectList;

		private Vector3 m_ItemScale;

		private string m_dialogSharedLocation = string.Empty;

		private int mCurDayID = 0;
	}
}
