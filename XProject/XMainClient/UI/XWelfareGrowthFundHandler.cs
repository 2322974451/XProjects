using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWelfareGrowthFundHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/GrowthFund";
			}
		}

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

		private void RefreshRechargeHandler()
		{
			this.m_rechargeBtn.SetVisible(!this._Doc.HasBuyGrowthFund);
			this.m_hasBuySprite.SetVisible(this._Doc.HasBuyGrowthFund);
		}

		private IXUIScrollView m_ScrollView;

		private IXUIList m_ItemGrid;

		private List<WelfareGrowthFundItem> m_ItemList;

		private Transform m_ItemTemp;

		private IXUISprite m_hasBuySprite;

		private IXUIButton m_rechargeBtn;

		private XWelfareDocument _Doc;
	}
}
