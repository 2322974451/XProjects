using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018E1 RID: 6369
	internal class XWelfareGrowthFundHandler : DlgHandlerBase
	{
		// Token: 0x17003A78 RID: 14968
		// (get) Token: 0x0601098A RID: 67978 RVA: 0x004176A8 File Offset: 0x004158A8
		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/GrowthFund";
			}
		}

		// Token: 0x0601098B RID: 67979 RVA: 0x004176C0 File Offset: 0x004158C0
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this.m_ScrollView = (base.FindInChild("XUIScrollView", "ScrollView") as IXUIScrollView);
			this.m_ItemGrid = (base.FindInChild("XUIList", "ScrollView/Grid") as IXUIList);
			this.m_ItemTemp = base.FindChild("ScrollView/Grid/ItemTpl");
			this.m_ItemTemp.gameObject.SetActive(false);
			this.m_rechargeBtn = (base.FindInChild("XUIButton", "ScrollView/Grid/Recharge/Recharge") as IXUIButton);
			this.m_hasBuySprite = (base.FindInChild("XUISprite", "ScrollView/Grid/Recharge/HasBuy") as IXUISprite);
			this.m_rechargeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRechargeHandler));
			this.InitWelfreGrowthList();
		}

		// Token: 0x0601098C RID: 67980 RVA: 0x00417794 File Offset: 0x00415994
		private bool OnClickRechargeHandler(IXUIButton btn)
		{
			RechargeTable.RowData rowData;
			bool flag = this._Doc.TryGetGrowthFundConf(XSysDefine.XSys_Welfare_StarFund, out rowData);
			if (flag)
			{
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				bool flag2 = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.Android;
				if (flag2)
				{
					specificDocument.SDKSubscribe(rowData.Price, 1, rowData.ServiceCode, rowData.Name, rowData.ParamID, PayParamType.PAY_PARAM_GROWTH_FUND);
				}
				else
				{
					bool flag3 = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.IOS;
					if (flag3)
					{
						int @int = XSingleton<XGlobalConfig>.singleton.GetInt("WelfareGrowthFundDays");
						specificDocument.SDKSubscribe(rowData.Price, @int, rowData.ServiceCode, rowData.Name, rowData.ParamID, PayParamType.PAY_PARAM_GROWTH_FUND);
					}
				}
			}
			return true;
		}

		// Token: 0x0601098D RID: 67981 RVA: 0x00417858 File Offset: 0x00415A58
		private void InitWelfreGrowthList()
		{
			this.m_ItemList = new List<WelfareGrowthFundItem>();
			RechargeTable.RowData rowData;
			bool flag = this._Doc.TryGetGrowthFundConf(XSysDefine.XSys_Welfare_StarFund, out rowData);
			if (flag)
			{
				WelfareGrowthFundItem welfareGrowthFundItem = this.CreateGrowthFundItem();
				welfareGrowthFundItem.Set(0, 0, rowData.Diamond);
				int i = 0;
				int count = rowData.RoleLevels.Count;
				while (i < count)
				{
					welfareGrowthFundItem = this.CreateGrowthFundItem();
					welfareGrowthFundItem.Set(1, rowData.RoleLevels[i, 0], rowData.RoleLevels[i, 1]);
					i++;
				}
				i = 0;
				count = rowData.LoginDays.Count;
				while (i < count)
				{
					welfareGrowthFundItem = this.CreateGrowthFundItem();
					welfareGrowthFundItem.Set(2, rowData.LoginDays[i, 0], rowData.LoginDays[i, 1]);
					i++;
				}
			}
		}

		// Token: 0x0601098E RID: 67982 RVA: 0x0041793C File Offset: 0x00415B3C
		private WelfareGrowthFundItem CreateGrowthFundItem()
		{
			GameObject gameObject = XCommon.Instantiate<GameObject>(this.m_ItemTemp.gameObject);
			gameObject.transform.parent = this.m_ItemGrid.gameObject.transform;
			gameObject.transform.localScale = Vector2.one;
			gameObject.name = this.m_ItemList.Count.ToString();
			WelfareGrowthFundItem welfareGrowthFundItem = new WelfareGrowthFundItem();
			gameObject.SetActive(true);
			welfareGrowthFundItem.Init(gameObject.transform);
			this.m_ItemList.Add(welfareGrowthFundItem);
			return welfareGrowthFundItem;
		}

		// Token: 0x0601098F RID: 67983 RVA: 0x004179D4 File Offset: 0x00415BD4
		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshRechargeHandler();
			bool flag = this.m_ItemList == null;
			if (!flag)
			{
				int i = 0;
				int count = this.m_ItemList.Count;
				while (i < count)
				{
					this.m_ItemList[i].Refresh();
					i++;
				}
			}
		}

		// Token: 0x06010990 RID: 67984 RVA: 0x00417A2F File Offset: 0x00415C2F
		private void RefreshRechargeHandler()
		{
			this.m_rechargeBtn.SetVisible(!this._Doc.HasBuyGrowthFund);
			this.m_hasBuySprite.SetVisible(this._Doc.HasBuyGrowthFund);
		}

		// Token: 0x0400787C RID: 30844
		private IXUIScrollView m_ScrollView;

		// Token: 0x0400787D RID: 30845
		private IXUIList m_ItemGrid;

		// Token: 0x0400787E RID: 30846
		private List<WelfareGrowthFundItem> m_ItemList;

		// Token: 0x0400787F RID: 30847
		private Transform m_ItemTemp;

		// Token: 0x04007880 RID: 30848
		private IXUISprite m_hasBuySprite;

		// Token: 0x04007881 RID: 30849
		private IXUIButton m_rechargeBtn;

		// Token: 0x04007882 RID: 30850
		private XWelfareDocument _Doc;
	}
}
