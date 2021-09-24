using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FeastHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Home/FeastHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.InitProperties();
			this.InitLeftTabs();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshUI();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public void RefreshUI()
		{
			this.SetHoldPatryState();
			this.SetDefaultTab();
		}

		public void BeginToFeast()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("BeginToFeast", null, null, null, null, null);
			this.RefreshPartyBtnState(false);
		}

		public void RefreshPartyBtnState(bool enable)
		{
			this._holdPartyBtn.SetEnable(enable, false);
		}

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

		private bool OnClickInviteBtn(IXUIButton btn)
		{
			XActivityInviteDocument.Doc.ShowActivityInviteView(2, XActivityInviteDocument.OpType.Invite);
			return true;
		}

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

		protected XUIPool _tabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		protected XUIPool _itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform _rewardSnap;

		private IXUILabel _packageName;

		private IXUILabel _partyDesc;

		private Transform _tabs;

		private Transform _items;

		private IXUIButton _inviteBtn;

		private IXUIButton _holdPartyBtn;

		private List<Transform> _tabList = new List<Transform>();

		private uint _banquetID = 0U;
	}
}
