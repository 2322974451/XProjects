using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GameMallShopHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			GameObject gameObject = base.transform.Find("Bg/RechargeFrame/ScrollView/Grid/TplMall").gameObject;
			this.m_ShopTypePool.SetupPool(gameObject.transform.parent.gameObject, gameObject, 7U, false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = this._doc == null;
			if (flag)
			{
				this._doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
			this.OnInitShops();
			this.RefreshRedPoint();
		}

		public void Refresh()
		{
		}

		private void OnInitShops()
		{
			List<string> list = new List<string>();
			List<XSysDefine> shopSystems = this._doc.ShopSystems;
			int index = 2;
			for (int i = 0; i < shopSystems.Count; i++)
			{
				bool flag = shopSystems[i] >= XSysDefine.XSys_LevelElite_Shop1 && shopSystems[i] <= XSysDefine.XSys_LevelElite_Shop4;
				if (flag)
				{
					index = i;
					break;
				}
			}
			for (int j = 335; j <= 338; j++)
			{
				ShopTypeTable.RowData shopTypeData = this._doc.GetShopTypeData((XSysDefine)j);
				bool flag2 = shopTypeData != null && XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Level >= shopTypeData.ShopLevel;
				if (flag2)
				{
					shopSystems[index] = (XSysDefine)j;
				}
			}
			index = 3;
			for (int k = 0; k < shopSystems.Count; k++)
			{
				bool flag3 = shopSystems[k] >= XSysDefine.XSys_Mall_32A && shopSystems[k] <= XSysDefine.XSys_Mall_60A;
				if (flag3)
				{
					index = k;
					break;
				}
			}
			for (int l = 330; l <= 333; l++)
			{
				ShopTypeTable.RowData shopTypeData2 = this._doc.GetShopTypeData((XSysDefine)l);
				bool flag4 = shopTypeData2 != null && XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Level >= shopTypeData2.ShopLevel;
				if (flag4)
				{
					shopSystems[index] = (XSysDefine)l;
				}
			}
			for (int m = 0; m < shopSystems.Count; m++)
			{
				ShopTypeTable.RowData shopTypeData3 = this._doc.GetShopTypeData(shopSystems[m]);
				bool flag5 = shopTypeData3 != null;
				if (flag5)
				{
					list.Add(shopTypeData3.ShopName);
				}
			}
			List<int> list2 = new List<int>();
			for (int n = 0; n < list.Count; n++)
			{
				ShopTypeTable.RowData shopTypeData4 = this._doc.GetShopTypeData(shopSystems[n]);
				bool flag6 = shopTypeData4 != null;
				if (flag6)
				{
					bool flag7 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(shopSystems[n]) && XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Level >= shopTypeData4.ShopLevel;
					if (flag7)
					{
						list2.Add(n);
					}
				}
			}
			for (int num = 0; num < list.Count; num++)
			{
				ShopTypeTable.RowData shopTypeData5 = this._doc.GetShopTypeData(shopSystems[num]);
				bool flag8 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(shopSystems[num]) || (shopTypeData5 != null && XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Level < shopTypeData5.ShopLevel);
				if (flag8)
				{
					list2.Add(num);
				}
			}
			this.m_ShopTypePool.ReturnAll(false);
			this._ShopGo.Clear();
			int num2 = 0;
			while (num2 < list.Count)
			{
				int index2 = list2[num2];
				GameObject gameObject = this.m_ShopTypePool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(this.m_ShopTypePool.TplPos.x + (float)(num2 % 3 * this.m_ShopTypePool.TplWidth), this.m_ShopTypePool.TplPos.y - (float)(num2 / 3 * this.m_ShopTypePool.TplHeight), this.m_ShopTypePool.TplPos.z);
				IXUILabel ixuilabel = gameObject.transform.FindChild("shopname").GetComponent("XUILabel") as IXUILabel;
				IXUITexture ixuitexture = gameObject.transform.FindChild("Icon").GetComponent("XUITexture") as IXUITexture;
				IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
				IXUITexture ixuitexture2 = gameObject.transform.FindChild("Lock").GetComponent("XUITexture") as IXUITexture;
				this._ShopGo.Add(gameObject);
				ShopTypeTable.RowData shopTypeData6 = this._doc.GetShopTypeData(shopSystems[index2]);
				ixuilabel.SetText(list[index2]);
				bool flag9 = shopTypeData6 != null && !string.IsNullOrEmpty(shopTypeData6.ShopIcon);
				if (flag9)
				{
					ixuitexture.SetTexturePath("atlas/UI/GameSystem/Activity/" + shopTypeData6.ShopIcon);
				}
				ixuisprite.ID = (ulong)((long)shopSystems[index2]);
				bool flag10 = false;
				int hour = DateTime.Now.Hour;
				int minute = DateTime.Now.Minute;
				bool flag11 = shopTypeData6 != null;
				if (flag11)
				{
					flag10 = this.IsShopOpen(shopSystems[index2]);
				}
				bool flag12 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(shopSystems[index2]) || XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Level < shopTypeData6.ShopLevel;
				if (flag12)
				{
					ixuitexture.SetEnabled(false);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.CannotOpenShop));
					ixuitexture2.SetVisible(true);
				}
				else
				{
					bool flag13 = shopSystems[index2] == XSysDefine.XSys_Mall_Guild;
					if (flag13)
					{
						XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
						bool flag14 = !specificDocument.bInGuild;
						if (flag14)
						{
							ixuitexture2.SetVisible(true);
							ixuitexture.SetEnabled(false);
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOpenGuild));
							goto IL_5C8;
						}
					}
					bool flag15 = !flag10;
					if (flag15)
					{
						ixuitexture2.SetVisible(true);
						ixuitexture.SetEnabled(false);
					}
					else
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOpenShop));
						ixuitexture2.SetVisible(false);
						ixuisprite.SetEnabled(true);
						ixuitexture.SetEnabled(true);
					}
				}
				IL_5C8:
				num2++;
				continue;
				goto IL_5C8;
			}
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<UiUtility>.singleton.DestroyTextureInActivePool(this.m_ShopTypePool, "Icon");
		}

		public override void RefreshData()
		{
			base.RefreshData();
		}

		public bool IsShopOpen(XSysDefine sys)
		{
			int hour = DateTime.Now.Hour;
			int minute = DateTime.Now.Minute;
			bool result = false;
			bool flag = this._doc == null;
			if (flag)
			{
				this._doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
			ShopTypeTable.RowData shopTypeData = this._doc.GetShopTypeData(sys);
			bool flag2 = shopTypeData != null;
			if (flag2)
			{
				bool flag3 = shopTypeData.ShopOpen.Count == 0;
				if (flag3)
				{
					result = true;
				}
				for (int i = 0; i < shopTypeData.ShopOpen.Count; i++)
				{
					int num = hour * 100 + minute;
					bool flag4 = (long)num >= (long)((ulong)shopTypeData.ShopOpen[i, 0]) && (long)num <= (long)((ulong)shopTypeData.ShopOpen[i, 1]);
					if (flag4)
					{
						result = true;
					}
				}
			}
			return result;
		}

		public void OnOpenShop(IXUISprite sp)
		{
			bool flag = this._doc.shopRedPoint.Contains((XSysDefine)sp.ID);
			if (flag)
			{
				this._doc.RefreshShopRedPoint((XSysDefine)sp.ID, false);
			}
			XSysDefine sys = (XSysDefine)sp.ID;
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.m_OpenFromGeneral = true;
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(sys, 0UL);
		}

		public void CannotOpenShop(IXUISprite sp)
		{
			XSysDefine xsysDefine = (XSysDefine)sp.ID;
			int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel((int)sp.ID);
			XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("SHOP_OPEN_LEVEL"), sysOpenLevel), "fece00");
		}

		public void OnOpenGuild(IXUISprite sp)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Guild, 0UL);
		}

		public void RefreshRedPoint()
		{
			bool flag = false;
			for (int i = 0; i < this._ShopGo.Count; i++)
			{
				IXUISprite ixuisprite = this._ShopGo[i].transform.GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = this._ShopGo[i].transform.FindChild("RedPoint").GetComponent("XUISprite") as IXUISprite;
				bool flag2 = this._doc.shopRedPoint.Contains((XSysDefine)ixuisprite.ID);
				if (flag2)
				{
					flag = true;
					ixuisprite2.SetVisible(true);
				}
				else
				{
					ixuisprite2.SetVisible(false);
				}
			}
			bool flag3 = !flag;
			if (flag3)
			{
				this._doc.shopRedPoint.Clear();
			}
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Mall, flag);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Mall, true);
		}

		private XGameMallDocument _doc = null;

		public XUIPool m_ShopTypePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private List<GameObject> _ShopGo = new List<GameObject>();
	}
}
