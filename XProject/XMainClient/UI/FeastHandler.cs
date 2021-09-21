using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200179B RID: 6043
	internal class FeastHandler : DlgHandlerBase
	{
		// Token: 0x17003852 RID: 14418
		// (get) Token: 0x0600F99F RID: 63903 RVA: 0x003973C0 File Offset: 0x003955C0
		protected override string FileName
		{
			get
			{
				return "Home/FeastHandler";
			}
		}

		// Token: 0x0600F9A0 RID: 63904 RVA: 0x003973D7 File Offset: 0x003955D7
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
			this.InitLeftTabs();
		}

		// Token: 0x0600F9A1 RID: 63905 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F9A2 RID: 63906 RVA: 0x003973EF File Offset: 0x003955EF
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshUI();
		}

		// Token: 0x0600F9A3 RID: 63907 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F9A4 RID: 63908 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F9A5 RID: 63909 RVA: 0x00397400 File Offset: 0x00395600
		public void RefreshUI()
		{
			this.SetHoldPatryState();
			this.SetDefaultTab();
		}

		// Token: 0x0600F9A6 RID: 63910 RVA: 0x00397411 File Offset: 0x00395611
		public void BeginToFeast()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("BeginToFeast", null, null, null, null, null);
			this.RefreshPartyBtnState(false);
		}

		// Token: 0x0600F9A7 RID: 63911 RVA: 0x00397431 File Offset: 0x00395631
		public void RefreshPartyBtnState(bool enable)
		{
			this._holdPartyBtn.SetEnable(enable, false);
		}

		// Token: 0x0600F9A8 RID: 63912 RVA: 0x00397444 File Offset: 0x00395644
		private void InitLeftTabs()
		{
			this._tabList.Clear();
			this._tabPool.ReturnAll(false);
			GardenBanquetCfg.RowData[] table = XHomeCookAndPartyDocument.GardenBanquetCfgTable.Table;
			for (int i = 0; i < table.Length; i++)
			{
				GameObject gameObject = this._tabPool.FetchGameObject(false);
				this.InitTabItem(gameObject.transform, table[i]);
				gameObject.transform.parent = this._tabs;
				gameObject.transform.localPosition = new Vector3(this._tabPool.TplPos.x, this._tabPool.TplPos.y - (float)(i * this._tabPool.TplHeight), 0f);
				this._tabList.Add(gameObject.transform);
			}
		}

		// Token: 0x0600F9A9 RID: 63913 RVA: 0x00397518 File Offset: 0x00395718
		private void InitProperties()
		{
			this._tabs = base.transform.Find("Tabs");
			this._tabPool.SetupPool(this._tabs.gameObject, this._tabs.Find("Combo").gameObject, 2U, false);
			this._items = base.transform.Find("Content/NeedFood/Items");
			this._itemPool.SetupPool(this._items.gameObject, this._items.Find("Item").gameObject, 2U, false);
			this._packageName = (base.transform.FindChild("Content/Tittle/Name").GetComponent("XUILabel") as IXUILabel);
			this._partyDesc = (base.transform.FindChild("Content/FeastDes/ContentLab").GetComponent("XUILabel") as IXUILabel);
			this._rewardSnap = base.transform.FindChild("Content/FeastReward/SnapShot");
			this._holdPartyBtn = (base.transform.Find("HoldFeastBtn").GetComponent("XUIButton") as IXUIButton);
			this._holdPartyBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickHoldParty));
			this._inviteBtn = (base.transform.Find("InviteFriendsBtn").GetComponent("XUIButton") as IXUIButton);
			this._inviteBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickInviteBtn));
		}

		// Token: 0x0600F9AA RID: 63914 RVA: 0x00397688 File Offset: 0x00395888
		private void InitTabItem(Transform item, GardenBanquetCfg.RowData info)
		{
			IXUICheckBox ixuicheckBox = item.GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.ID = (ulong)info.BanquetID;
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnPackageChange));
			Transform transform = item.Find("Tittle");
			IXUILabel ixuilabel = item.Find("Tittle").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = item.Find("Select/SL").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(info.BanquetName);
			ixuilabel2.SetText(info.BanquetName);
		}

		// Token: 0x0600F9AB RID: 63915 RVA: 0x00397724 File Offset: 0x00395924
		private void SetDefaultTab()
		{
			bool flag = this._tabList.Count > 0;
			if (flag)
			{
				IXUICheckBox ixuicheckBox = this._tabList[0].GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ForceSetFlag(true);
				this.RefreshRightPanel((uint)ixuicheckBox.ID);
			}
		}

		// Token: 0x0600F9AC RID: 63916 RVA: 0x00397778 File Offset: 0x00395978
		private void RefreshRightPanel(uint id)
		{
			GardenBanquetCfg.RowData gardenBanquetInfoByID = XHomeCookAndPartyDocument.Doc.GetGardenBanquetInfoByID(id);
			bool flag = gardenBanquetInfoByID != null;
			if (flag)
			{
				this._itemPool.ReturnAll(false);
				this._packageName.SetText(gardenBanquetInfoByID.BanquetName);
				this._partyDesc.SetText(gardenBanquetInfoByID.Desc);
				for (int i = 0; i < gardenBanquetInfoByID.Stuffs.Count; i++)
				{
					Transform transform = this.DrawItem((int)gardenBanquetInfoByID.Stuffs[i, 0], (int)gardenBanquetInfoByID.Stuffs[i, 1], this._items, i);
					IXUILabel ixuilabel = transform.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
					uint itemid = gardenBanquetInfoByID.Stuffs[i, 0];
					ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)itemid);
					string text = itemCount + "/" + gardenBanquetInfoByID.Stuffs[i, 1];
					bool flag2 = itemCount < (ulong)gardenBanquetInfoByID.Stuffs[i, 1];
					if (flag2)
					{
						text = string.Concat(new object[]
						{
							"[ff0000]",
							itemCount,
							"/",
							gardenBanquetInfoByID.Stuffs[i, 1],
							"[-]"
						});
					}
					ixuilabel.SetText(text);
				}
				for (int j = 0; j < gardenBanquetInfoByID.BanquetAwards.Count; j++)
				{
					this.DrawItem((int)gardenBanquetInfoByID.BanquetAwards[j, 0], (int)gardenBanquetInfoByID.BanquetAwards[j, 1], this._rewardSnap, j);
				}
			}
		}

		// Token: 0x0600F9AD RID: 63917 RVA: 0x00397934 File Offset: 0x00395B34
		private Transform DrawItem(int itemID, int num, Transform parent, int index)
		{
			GameObject gameObject = this._itemPool.FetchGameObject(false);
			gameObject.transform.parent = parent;
			gameObject.transform.localPosition = new Vector3((float)(index * this._itemPool.TplWidth), 0f, 0f);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemID, num, true);
			IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)itemID);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			return gameObject.transform;
		}

		// Token: 0x0600F9AE RID: 63918 RVA: 0x003979E8 File Offset: 0x00395BE8
		private bool OnPackageChange(IXUICheckBox box)
		{
			bool bChecked = box.bChecked;
			bool result;
			if (bChecked)
			{
				uint num = (uint)box.ID;
				this._banquetID = num;
				this.RefreshRightPanel(num);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600F9AF RID: 63919 RVA: 0x00397A24 File Offset: 0x00395C24
		private bool OnClickInviteBtn(IXUIButton btn)
		{
			XActivityInviteDocument.Doc.ShowActivityInviteView(2, XActivityInviteDocument.OpType.Invite);
			return true;
		}

		// Token: 0x0600F9B0 RID: 63920 RVA: 0x00397A44 File Offset: 0x00395C44
		private bool OnClickHoldParty(IXUIButton btn)
		{
			bool flag = !this.IsFoodEnough();
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("FoodNotEnough"), "fece00");
				result = false;
			}
			else
			{
				bool flag2 = this.IsHasEnoughParters();
				if (flag2)
				{
					XHomeCookAndPartyDocument.Doc.SendGardenBanquet(this._banquetID);
					result = true;
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GargenPepleLack"), "fece00");
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600F9B1 RID: 63921 RVA: 0x00397ACC File Offset: 0x00395CCC
		private bool IsHasEnoughParters()
		{
			List<XEntity> all = XSingleton<XEntityMgr>.singleton.GetAll();
			int num = 0;
			for (int i = 0; i < all.Count; i++)
			{
				bool isRole = all[i].IsRole;
				if (isRole)
				{
					num++;
				}
			}
			return num >= XSingleton<XGlobalConfig>.singleton.GetInt("GardenBanquetGuests");
		}

		// Token: 0x0600F9B2 RID: 63922 RVA: 0x00397B3C File Offset: 0x00395D3C
		private void SetHoldPatryState()
		{
			bool flag = !HomeMainDocument.Doc.IsInMyOwnHomeGarden() || XHomeCookAndPartyDocument.Doc.CurBanquetState > 0U;
			if (flag)
			{
				this._holdPartyBtn.SetEnable(false, false);
			}
			else
			{
				this._holdPartyBtn.SetEnable(true, false);
			}
		}

		// Token: 0x0600F9B3 RID: 63923 RVA: 0x00397B88 File Offset: 0x00395D88
		protected bool IsFoodEnough()
		{
			GardenBanquetCfg.RowData gardenBanquetInfoByID = XHomeCookAndPartyDocument.Doc.GetGardenBanquetInfoByID(this._banquetID);
			bool flag = gardenBanquetInfoByID != null;
			if (flag)
			{
				for (int i = 0; i < gardenBanquetInfoByID.Stuffs.Count; i++)
				{
					uint itemid = gardenBanquetInfoByID.Stuffs[i, 0];
					uint num = gardenBanquetInfoByID.Stuffs[i, 1];
					uint num2 = (uint)XBagDocument.BagDoc.GetItemCount((int)itemid);
					bool flag2 = num2 < num;
					if (flag2)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x04006D31 RID: 27953
		protected XUIPool _tabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006D32 RID: 27954
		protected XUIPool _itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006D33 RID: 27955
		private Transform _rewardSnap;

		// Token: 0x04006D34 RID: 27956
		private IXUILabel _packageName;

		// Token: 0x04006D35 RID: 27957
		private IXUILabel _partyDesc;

		// Token: 0x04006D36 RID: 27958
		private Transform _tabs;

		// Token: 0x04006D37 RID: 27959
		private Transform _items;

		// Token: 0x04006D38 RID: 27960
		private IXUIButton _inviteBtn;

		// Token: 0x04006D39 RID: 27961
		private IXUIButton _holdPartyBtn;

		// Token: 0x04006D3A RID: 27962
		private List<Transform> _tabList = new List<Transform>();

		// Token: 0x04006D3B RID: 27963
		private uint _banquetID = 0U;
	}
}
