using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWelffareFirstRechargrHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/RechargeFirstGift";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this.m_ItemEffectList = new List<XFx>();
			this.m_contentLabel = (base.PanelObject.transform.FindChild("Content").GetComponent("XUILabel") as IXUILabel);
			this.m_rechargeBtn = (base.PanelObject.transform.FindChild("Recharge").GetComponent("XUIButton") as IXUIButton);
			this.m_getGiftBtn = (base.PanelObject.transform.FindChild("GetGift").GetComponent("XUIButton") as IXUIButton);
			this.m_itemList = (base.PanelObject.transform.FindChild("Reward").GetComponent("XUIList") as IXUIList);
			this.m_itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			Transform transform = base.PanelObject.transform.FindChild("Reward/item");
			this.m_itemPool.SetupPool(this.m_itemList.gameObject, transform.gameObject, 5U, false);
			this.InitAwardList();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_rechargeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickRechargeHandler));
			this.m_getGiftBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickGetGiftHandler));
		}

		private bool ClickRechargeHandler(IXUIButton btn)
		{
			DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowPurchase(ItemEnum.DIAMOND);
			return true;
		}

		private bool ClickGetGiftHandler(IXUIButton btn)
		{
			this._Doc.GetPayFirstAward();
			return true;
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			bool flag = this.m_itemPool != null;
			if (flag)
			{
				this.m_itemPool.ReturnAllDisable();
				this.m_itemPool = null;
			}
			bool flag2 = this.m_ItemEffectList != null;
			if (flag2)
			{
				int i = 0;
				int count = this.m_ItemEffectList.Count;
				while (i < count)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this.m_ItemEffectList[i], true);
					i++;
				}
				this.m_ItemEffectList.Clear();
				this.m_ItemEffectList = null;
			}
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

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
		}

		public override void RefreshData()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.m_rechargeBtn.SetVisible(!this._Doc.HasFullFirstRecharge());
				this.m_getGiftBtn.SetVisible(this._Doc.GetCanRechargeFirst());
			}
		}

		private void InitAwardList()
		{
			this.ClearEffectList();
			PayFirst.RowData rowData;
			bool flag = this._Doc.TryGetPayFirstData(XSysDefine.XSys_Welfare_FirstRechange, out rowData);
			if (flag)
			{
				this.m_itemPool.FakeReturnAll();
				List<DropList.RowData> list = new List<DropList.RowData>();
				List<ChestList.RowData> list2;
				bool flag2 = XBagDocument.TryGetChestListConf(rowData.Award, out list2);
				if (flag2)
				{
					int i = 0;
					int count = list2.Count;
					while (i < count)
					{
						ChestList.RowData rowData2 = list2[i];
						bool flag3 = !XBagDocument.IsProfMatchedFeable((uint)rowData2.Profession, XItemDrawerParam.DefaultProfession, false);
						if (!flag3)
						{
							bool flag4 = XBagDocument.TryGetDropConf(rowData2.DropID, ref list);
							if (flag4)
							{
								int j = 0;
								int count2 = list.Count;
								while (j < count2)
								{
									ItemList.RowData itemConf = XBagDocument.GetItemConf(list[j].ItemID);
									GameObject gameObject = this.m_itemPool.FetchGameObject(false);
									gameObject.transform.parent = this.m_itemList.gameObject.transform;
									XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemConf, list[j].ItemCount, false);
									IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
									IXUISprite ixuisprite2 = gameObject.transform.FindChild("Icon/Icon").GetComponent("XUISprite") as IXUISprite;
									bool flag5 = itemConf == null;
									if (flag5)
									{
										XSingleton<XDebug>.singleton.AddGreenLog("Not Exsit Item:", list[j].ItemID.ToString(), null, null, null, null);
									}
									else
									{
										this.SetItemEffect(ixuisprite2.gameObject, itemConf.ItemEffect);
										ixuisprite.ID = (ulong)((long)list[j].ItemID);
										ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
									}
									j++;
								}
							}
						}
						i++;
					}
				}
				this.m_itemPool.ActualReturnAll(false);
				this.m_itemList.Refresh();
			}
		}

		private IXUILabel m_contentLabel;

		private IXUIButton m_rechargeBtn;

		private IXUIButton m_getGiftBtn;

		private XUIPool m_itemPool;

		private IXUIList m_itemList;

		private List<XFx> m_ItemEffectList;

		private XWelfareDocument _Doc;
	}
}
