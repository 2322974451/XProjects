using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018EC RID: 6380
	internal class XWelffareFirstRechargrHandler : DlgHandlerBase
	{
		// Token: 0x17003A83 RID: 14979
		// (get) Token: 0x060109F2 RID: 68082 RVA: 0x0041BACC File Offset: 0x00419CCC
		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/RechargeFirstGift";
			}
		}

		// Token: 0x060109F3 RID: 68083 RVA: 0x0041BAE4 File Offset: 0x00419CE4
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

		// Token: 0x060109F4 RID: 68084 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x060109F5 RID: 68085 RVA: 0x0041BC0D File Offset: 0x00419E0D
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_rechargeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickRechargeHandler));
			this.m_getGiftBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickGetGiftHandler));
		}

		// Token: 0x060109F6 RID: 68086 RVA: 0x0041BC48 File Offset: 0x00419E48
		private bool ClickRechargeHandler(IXUIButton btn)
		{
			DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowPurchase(ItemEnum.DIAMOND);
			return true;
		}

		// Token: 0x060109F7 RID: 68087 RVA: 0x0041BC68 File Offset: 0x00419E68
		private bool ClickGetGiftHandler(IXUIButton btn)
		{
			this._Doc.GetPayFirstAward();
			return true;
		}

		// Token: 0x060109F8 RID: 68088 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x060109F9 RID: 68089 RVA: 0x0041BC88 File Offset: 0x00419E88
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

		// Token: 0x060109FA RID: 68090 RVA: 0x0041BD1C File Offset: 0x00419F1C
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

		// Token: 0x060109FB RID: 68091 RVA: 0x0041BD7C File Offset: 0x00419F7C
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

		// Token: 0x060109FC RID: 68092 RVA: 0x0035654D File Offset: 0x0035474D
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
		}

		// Token: 0x060109FD RID: 68093 RVA: 0x0041BDC0 File Offset: 0x00419FC0
		public override void RefreshData()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.m_rechargeBtn.SetVisible(!this._Doc.HasFullFirstRecharge());
				this.m_getGiftBtn.SetVisible(this._Doc.GetCanRechargeFirst());
			}
		}

		// Token: 0x060109FE RID: 68094 RVA: 0x0041BE10 File Offset: 0x0041A010
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

		// Token: 0x040078E7 RID: 30951
		private IXUILabel m_contentLabel;

		// Token: 0x040078E8 RID: 30952
		private IXUIButton m_rechargeBtn;

		// Token: 0x040078E9 RID: 30953
		private IXUIButton m_getGiftBtn;

		// Token: 0x040078EA RID: 30954
		private XUIPool m_itemPool;

		// Token: 0x040078EB RID: 30955
		private IXUIList m_itemList;

		// Token: 0x040078EC RID: 30956
		private List<XFx> m_ItemEffectList;

		// Token: 0x040078ED RID: 30957
		private XWelfareDocument _Doc;
	}
}
