using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001852 RID: 6226
	internal class SevenLoginDlg : DlgBase<SevenLoginDlg, SevenLoginBehaviour>
	{
		// Token: 0x1700396D RID: 14701
		// (get) Token: 0x060102FA RID: 66298 RVA: 0x003E355C File Offset: 0x003E175C
		public override string fileName
		{
			get
			{
				return "GameSystem/SevenAwardDlg";
			}
		}

		// Token: 0x1700396E RID: 14702
		// (get) Token: 0x060102FB RID: 66299 RVA: 0x003E3574 File Offset: 0x003E1774
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SevenActivity);
			}
		}

		// Token: 0x1700396F RID: 14703
		// (get) Token: 0x060102FC RID: 66300 RVA: 0x003E3590 File Offset: 0x003E1790
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003970 RID: 14704
		// (get) Token: 0x060102FD RID: 66301 RVA: 0x003E35A4 File Offset: 0x003E17A4
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003971 RID: 14705
		// (get) Token: 0x060102FE RID: 66302 RVA: 0x003E35B8 File Offset: 0x003E17B8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060102FF RID: 66303 RVA: 0x003E35CC File Offset: 0x003E17CC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickCloseHandle));
			base.uiBehaviour.m_dialogClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickDialogClose));
		}

		// Token: 0x06010300 RID: 66304 RVA: 0x003E361B File Offset: 0x003E181B
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XSevenLoginDocument>(XSevenLoginDocument.uuID);
			this._Doc.SevenLoginView = this;
			base.uiBehaviour.m_dialogTransform.gameObject.SetActive(false);
		}

		// Token: 0x06010301 RID: 66305 RVA: 0x003E3659 File Offset: 0x003E1859
		protected override void OnLoad()
		{
			base.OnLoad();
			this.m_WrapContentItems = new List<SevenLoginWrapItem>();
			this.m_ItemEffectList = new List<XFx>();
			this.m_ItemScale = new Vector3(0.8f, 0.8f, 0.8f);
		}

		// Token: 0x06010302 RID: 66306 RVA: 0x003E3694 File Offset: 0x003E1894
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

		// Token: 0x06010303 RID: 66307 RVA: 0x003E3778 File Offset: 0x003E1978
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

		// Token: 0x06010304 RID: 66308 RVA: 0x003E37D7 File Offset: 0x003E19D7
		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
		}

		// Token: 0x06010305 RID: 66309 RVA: 0x003E37E8 File Offset: 0x003E19E8
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

		// Token: 0x06010306 RID: 66310 RVA: 0x003E3844 File Offset: 0x003E1A44
		public void Refresh()
		{
			this.ConfigSevenItemList();
			this.ConfigSevenMessage();
			this.ConfigImportTime(null);
		}

		// Token: 0x06010307 RID: 66311 RVA: 0x003E3860 File Offset: 0x003E1A60
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

		// Token: 0x06010308 RID: 66312 RVA: 0x003E38F4 File Offset: 0x003E1AF4
		private bool ClickDialogClose(IXUIButton btn)
		{
			base.uiBehaviour.m_dialogTransform.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x06010309 RID: 66313 RVA: 0x003E3920 File Offset: 0x003E1B20
		private bool OnClickCloseHandle(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0601030A RID: 66314 RVA: 0x003E393C File Offset: 0x003E1B3C
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

		// Token: 0x0601030B RID: 66315 RVA: 0x003E3A04 File Offset: 0x003E1C04
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

		// Token: 0x0601030C RID: 66316 RVA: 0x003E3AF0 File Offset: 0x003E1CF0
		private void ClearShardTexture()
		{
			base.uiBehaviour.m_shardTexture.SetTexturePath("");
		}

		// Token: 0x0601030D RID: 66317 RVA: 0x003E3B09 File Offset: 0x003E1D09
		private void ClearDialogSharedTexture()
		{
			this.m_uiBehaviour.m_dialogTexture.SetTexturePath("");
			this.m_dialogSharedLocation = string.Empty;
		}

		// Token: 0x0601030E RID: 66318 RVA: 0x003E3B30 File Offset: 0x003E1D30
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

		// Token: 0x0601030F RID: 66319 RVA: 0x003E3B74 File Offset: 0x003E1D74
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

		// Token: 0x06010310 RID: 66320 RVA: 0x003E3D64 File Offset: 0x003E1F64
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

		// Token: 0x06010311 RID: 66321 RVA: 0x003E3DF8 File Offset: 0x003E1FF8
		private bool GetSureLogReward(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._Doc.GetLoginReward(this.mCurDayID);
			return true;
		}

		// Token: 0x06010312 RID: 66322 RVA: 0x003E3E28 File Offset: 0x003E2028
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

		// Token: 0x06010313 RID: 66323 RVA: 0x003E3E6C File Offset: 0x003E206C
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

		// Token: 0x06010314 RID: 66324 RVA: 0x003E3FEC File Offset: 0x003E21EC
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

		// Token: 0x06010315 RID: 66325 RVA: 0x003E403C File Offset: 0x003E223C
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

		// Token: 0x040073F1 RID: 29681
		private XSevenLoginDocument _Doc;

		// Token: 0x040073F2 RID: 29682
		private List<SevenLoginWrapItem> m_WrapContentItems;

		// Token: 0x040073F3 RID: 29683
		private int m_wrapContentHeight = 104;

		// Token: 0x040073F4 RID: 29684
		private Vector3 m_RewardStartPos = Vector3.zero;

		// Token: 0x040073F5 RID: 29685
		private uint m_TimeRecord = 0U;

		// Token: 0x040073F6 RID: 29686
		private List<XFx> m_ItemEffectList;

		// Token: 0x040073F7 RID: 29687
		private Vector3 m_ItemScale;

		// Token: 0x040073F8 RID: 29688
		private string m_dialogSharedLocation = string.Empty;

		// Token: 0x040073F9 RID: 29689
		private int mCurDayID = 0;
	}
}
