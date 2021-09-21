using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E8E RID: 3726
	internal class XWelfareView : DlgBase<XWelfareView, XWelfareBehaviour>
	{
		// Token: 0x170034AD RID: 13485
		// (get) Token: 0x0600C6F9 RID: 50937 RVA: 0x002C1370 File Offset: 0x002BF570
		public override string fileName
		{
			get
			{
				return "GameSystem/Welfare/WelfareDlg";
			}
		}

		// Token: 0x170034AE RID: 13486
		// (get) Token: 0x0600C6FA RID: 50938 RVA: 0x002C1388 File Offset: 0x002BF588
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170034AF RID: 13487
		// (get) Token: 0x0600C6FB RID: 50939 RVA: 0x002C139C File Offset: 0x002BF59C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170034B0 RID: 13488
		// (get) Token: 0x0600C6FC RID: 50940 RVA: 0x002C13B0 File Offset: 0x002BF5B0
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C6FE RID: 50942 RVA: 0x002C13F8 File Offset: 0x002BF5F8
		protected override void OnLoad()
		{
			base.OnLoad();
			this.m_InitTab = true;
		}

		// Token: 0x0600C6FF RID: 50943 RVA: 0x002C140C File Offset: 0x002BF60C
		private void RegisterHandler<T>(XSysDefine define) where T : DlgHandlerBase, new()
		{
			bool flag = !this.m_AllHandlers.ContainsKey(define);
			if (flag)
			{
				T t = default(T);
				t = DlgHandlerBase.EnsureCreate<T>(ref t, base.uiBehaviour.m_RightHandlerParent, false, this);
				this.m_AllHandlers.Add(define, t);
			}
		}

		// Token: 0x0600C700 RID: 50944 RVA: 0x002C1460 File Offset: 0x002BF660
		private void RemoveHandler(XSysDefine define)
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_AllHandlers.TryGetValue(define, out dlgHandlerBase);
			if (flag)
			{
				DlgHandlerBase.EnsureUnload<DlgHandlerBase>(ref dlgHandlerBase);
				this.m_AllHandlers.Remove(define);
			}
		}

		// Token: 0x0600C701 RID: 50945 RVA: 0x002C1498 File Offset: 0x002BF698
		protected override void OnUnload()
		{
			this.RemoveHandler(XSysDefine.XSys_Welfare_GiftBag);
			this.RemoveHandler(XSysDefine.XSys_Welfare_StarFund);
			this.RemoveHandler(XSysDefine.XSys_Welfare_FirstRechange);
			this.RemoveHandler(XSysDefine.XSyS_Welfare_RewardBack);
			this.RemoveHandler(XSysDefine.XSys_ReceiveEnergy);
			this.RemoveHandler(XSysDefine.XSys_Reward_Login);
			this.RemoveHandler(XSysDefine.XSys_Welfare_MoneyTree);
			this.RemoveHandler(XSysDefine.XSys_Welfare_KingdomPrivilege);
			this.RemoveHandler(XSysDefine.XSys_Welfare_NiceGirl);
			this.RemoveHandler(XSysDefine.XSys_Welfare_YyMall);
			this.m_AllHandlers.Clear();
			this.m_AllTabs.Clear();
			this._Doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600C702 RID: 50946 RVA: 0x002C1548 File Offset: 0x002BF748
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this._Doc.View = this;
			this.RegisterHandler<XWelfareGiftBagHandler>(XSysDefine.XSys_Welfare_GiftBag);
			this.RegisterHandler<XWelfareGrowthFundHandler>(XSysDefine.XSys_Welfare_StarFund);
			this.RegisterHandler<XWelffareFirstRechargrHandler>(XSysDefine.XSys_Welfare_FirstRechange);
			this.RegisterHandler<XWelfareRewardBackHandler>(XSysDefine.XSyS_Welfare_RewardBack);
			this.RegisterHandler<ReceiveEnergyDlg>(XSysDefine.XSys_ReceiveEnergy);
			this.RegisterHandler<XLoginRewardView>(XSysDefine.XSys_Reward_Login);
			this.RegisterHandler<XWelfareMoneyTreeHandler>(XSysDefine.XSys_Welfare_MoneyTree);
			this.RegisterHandler<XWelfareKingdomPrivilegeHandler>(XSysDefine.XSys_Welfare_KingdomPrivilege);
			this.RegisterHandler<XWelfareNiceGirlHandler>(XSysDefine.XSys_Welfare_NiceGirl);
			this.RegisterHandler<XWelfareYyMallHandler>(XSysDefine.XSys_Welfare_YyMall);
		}

		// Token: 0x0600C703 RID: 50947 RVA: 0x002C15EF File Offset: 0x002BF7EF
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600C704 RID: 50948 RVA: 0x002C1618 File Offset: 0x002BF818
		public void Show(XSysDefine define = XSysDefine.XSys_None)
		{
			bool flag = define == XSysDefine.XSys_Welfare_KingdomPrivilege_Court || define == XSysDefine.XSys_Welfare_KingdomPrivilege_Commerce || define == XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer;
			if (flag)
			{
				define = XSysDefine.XSys_Welfare_KingdomPrivilege;
			}
			bool flag2 = !base.IsVisible();
			if (flag2)
			{
				this.m_normalDefine = define;
				this.SetVisibleWithAnimation(true, null);
			}
			else
			{
				this.SelectTab(define);
			}
		}

		// Token: 0x0600C705 RID: 50949 RVA: 0x002C1678 File Offset: 0x002BF878
		public void RefershRewardBack()
		{
			bool flag = this.m_AllHandlers.ContainsKey(XSysDefine.XSyS_Welfare_RewardBack) && this.m_AllTabs.ContainsKey(XSysDefine.XSyS_Welfare_RewardBack);
			if (flag)
			{
				bool bChecked = this.m_AllTabs[XSysDefine.XSyS_Welfare_RewardBack].bChecked;
				if (bChecked)
				{
					this.RefreshData();
					XWelfareRewardBackHandler xwelfareRewardBackHandler = (XWelfareRewardBackHandler)this.m_AllHandlers[XSysDefine.XSyS_Welfare_RewardBack];
					xwelfareRewardBackHandler.OnCencelBuy(null);
				}
			}
		}

		// Token: 0x0600C706 RID: 50950 RVA: 0x002C16F4 File Offset: 0x002BF8F4
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			this._Doc.ReqPayAllInfo();
			this._Doc.ReqRewardInfo();
			this._Doc.ReqMoneyTreeInfo();
			this._Doc.ServerPushRewardBack = false;
			this._Doc.ServerPushMoneyTree = false;
			XPlatformAbilityDocument.Doc.QueryQQVipInfo();
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			}
		}

		// Token: 0x0600C707 RID: 50951 RVA: 0x002C1774 File Offset: 0x002BF974
		protected override void OnHide()
		{
			base.OnHide();
			foreach (KeyValuePair<XSysDefine, DlgHandlerBase> keyValuePair in this.m_AllHandlers)
			{
				keyValuePair.Value.SetVisible(false);
			}
			this.m_InitTab = true;
		}

		// Token: 0x0600C708 RID: 50952 RVA: 0x002C17E4 File Offset: 0x002BF9E4
		private void InitTabs()
		{
			this.m_AllTabs.Clear();
			List<XSysDefine> list = new List<XSysDefine>();
			base.uiBehaviour.m_TabPool.FakeReturnAll();
			for (int i = 0; i < XWelfareDocument.WelfareTable.Table.Length; i++)
			{
				PayWelfareTable.RowData rowData = XWelfareDocument.WelfareTable.Table[i];
				XSysDefine sysID = (XSysDefine)rowData.SysID;
				bool flag = this._Doc.IsSystemAvailable(sysID);
				if (flag)
				{
					list.Add(sysID);
					IXUICheckBox ixuicheckBox = base.uiBehaviour.m_TabPool.FetchGameObject(false).GetComponent("XUICheckBox") as IXUICheckBox;
					ixuicheckBox.gameObject.transform.parent = base.uiBehaviour.m_TabList.gameObject.transform;
					ixuicheckBox.gameObject.transform.localScale = Vector3.one;
					ixuicheckBox.ID = (ulong)((long)XWelfareDocument.WelfareTable.Table[i].SysID);
					this.InitTabInfo(ixuicheckBox.gameObject, rowData);
					ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClicked));
					this.m_AllTabs.Add(sysID, ixuicheckBox);
				}
			}
			base.uiBehaviour.m_TabPool.ActualReturnAll(false);
			base.uiBehaviour.m_TabList.Refresh();
			this.SelectDefaultTab(list);
		}

		// Token: 0x0600C709 RID: 50953 RVA: 0x002C1944 File Offset: 0x002BFB44
		private void InitTabInfo(GameObject tab, PayWelfareTable.RowData data)
		{
			IXUILabel ixuilabel = tab.transform.Find("Title").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = tab.transform.Find("redpoint").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = tab.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel2 = tab.transform.Find("Selected/Title1").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite3 = tab.transform.Find("Selected/Icon").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText(data.TabName);
			ixuilabel2.SetText(data.TabName);
			ixuisprite.SetAlpha(0f);
			ixuisprite2.SetSprite(data.TabIcon);
			ixuisprite3.SetSprite(data.TabIcon);
		}

		// Token: 0x0600C70A RID: 50954 RVA: 0x002C1A34 File Offset: 0x002BFC34
		private void SelectDefaultTab(List<XSysDefine> listOpen)
		{
			List<XSysDefine> list = new List<XSysDefine>();
			string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("WelfareChildSysOrder", XGlobalConfig.ListSeparator);
			for (int i = 0; i < andSeparateValue.Length; i++)
			{
				int num = listOpen.IndexOf((XSysDefine)int.Parse(andSeparateValue[i]));
				bool flag = num >= 0;
				if (flag)
				{
					list.Add(listOpen[num]);
					listOpen.RemoveAt(num);
				}
			}
			list.AddRange(listOpen);
			bool flag2 = false;
			bool flag3 = this.m_normalDefine == XSysDefine.XSys_None;
			if (flag3)
			{
				for (int j = 0; j < list.Count; j++)
				{
					bool tabRedpointState = this._Doc.GetTabRedpointState(list[j]);
					if (tabRedpointState)
					{
						this.m_AllTabs[list[j]].bChecked = true;
						bool flag4 = this.m_AllHandlers.ContainsKey(list[j]);
						if (flag4)
						{
							this.SetHandlerVisible(list[j], true);
						}
						flag2 = true;
						break;
					}
				}
			}
			else
			{
				for (int k = 0; k < list.Count; k++)
				{
					bool flag5 = list[k] == this.m_normalDefine;
					if (flag5)
					{
						this.m_normalDefine = XSysDefine.XSys_None;
						this.m_AllTabs[list[k]].bChecked = true;
						this.SetHandlerVisible(list[k], true);
						flag2 = true;
						break;
					}
				}
				this.m_normalDefine = XSysDefine.XSys_None;
			}
			bool flag6 = !flag2 && list.Count > 0;
			if (flag6)
			{
				this.m_AllTabs[list[0]].bChecked = true;
				bool flag7 = this.m_AllHandlers.ContainsKey(list[0]);
				if (flag7)
				{
					this.SetHandlerVisible(list[0], true);
				}
			}
		}

		// Token: 0x0600C70B RID: 50955 RVA: 0x002C1C18 File Offset: 0x002BFE18
		public void RefreshRedpoint()
		{
			foreach (KeyValuePair<XSysDefine, IXUICheckBox> keyValuePair in this.m_AllTabs)
			{
				bool flag = keyValuePair.Value != null && keyValuePair.Value.IsVisible();
				if (flag)
				{
					IXUISprite ixuisprite = keyValuePair.Value.gameObject.transform.Find("redpoint").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetAlpha((float)(this._Doc.GetRedPoint(keyValuePair.Key) ? 1 : 0));
				}
				bool flag2 = keyValuePair.Key == XSysDefine.XSyS_Welfare_RewardBack;
				if (flag2)
				{
					IXUISprite ixuisprite2 = keyValuePair.Value.gameObject.transform.Find("redpoint").GetComponent("XUISprite") as IXUISprite;
					bool flag3 = this.m_AllHandlers.ContainsKey(XSysDefine.XSyS_Welfare_RewardBack);
					if (flag3)
					{
						XWelfareRewardBackHandler xwelfareRewardBackHandler = (XWelfareRewardBackHandler)this.m_AllHandlers[XSysDefine.XSyS_Welfare_RewardBack];
						bool flag4 = xwelfareRewardBackHandler.HasRedPoint() && !this._Doc.GetFirstClick(XSysDefine.XSyS_Welfare_RewardBack);
						if (flag4)
						{
							ixuisprite2.SetAlpha(1f);
						}
						else
						{
							ixuisprite2.SetAlpha(0f);
						}
					}
					else
					{
						ixuisprite2.SetAlpha(0f);
					}
				}
				bool flag5 = keyValuePair.Key == XSysDefine.XSys_Welfare_MoneyTree;
				if (flag5)
				{
					IXUISprite ixuisprite3 = keyValuePair.Value.gameObject.transform.Find("redpoint").GetComponent("XUISprite") as IXUISprite;
					bool flag6 = this.m_AllHandlers.ContainsKey(XSysDefine.XSys_Welfare_MoneyTree);
					if (flag6)
					{
						bool flag7 = this._Doc.WelfareMoneyTreeData.free_all_count > this._Doc.WelfareMoneyTreeData.free_count && this._Doc.WelfareMoneyTreeData.free_count + this._Doc.WelfareMoneyTreeData.count < this._Doc.WelfareMoneyTreeData.all_count && (this._Doc.WelfareMoneyTreeData.left_time == 0U || this._Doc.WelfareMoneyTreeData.left_time < Time.time - this._Doc.WelfareMoneyTreeData.req_time);
						if (flag7)
						{
							ixuisprite3.SetAlpha(1f);
						}
						else
						{
							ixuisprite3.SetAlpha(0f);
						}
					}
				}
				bool flag8 = keyValuePair.Key == XSysDefine.XSys_Reward_Login || keyValuePair.Key == XSysDefine.XSys_ReceiveEnergy;
				if (flag8)
				{
					IXUISprite ixuisprite4 = keyValuePair.Value.gameObject.transform.Find("redpoint").GetComponent("XUISprite") as IXUISprite;
					ixuisprite4.SetAlpha((float)(XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(keyValuePair.Key) ? 1 : 0));
				}
			}
		}

		// Token: 0x0600C70C RID: 50956 RVA: 0x002C1F34 File Offset: 0x002C0134
		public bool HadRewardBackRedPoint()
		{
			bool serverPushRewardBack = this._Doc.ServerPushRewardBack;
			bool result;
			if (serverPushRewardBack)
			{
				result = true;
			}
			else
			{
				bool flag = this.m_AllHandlers.ContainsKey(XSysDefine.XSyS_Welfare_RewardBack);
				if (flag)
				{
					XWelfareRewardBackHandler xwelfareRewardBackHandler = (XWelfareRewardBackHandler)this.m_AllHandlers[XSysDefine.XSyS_Welfare_RewardBack];
					result = xwelfareRewardBackHandler.HasRedPoint();
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600C70D RID: 50957 RVA: 0x002C1F90 File Offset: 0x002C0190
		public bool HasMoneyTreeRedPoint()
		{
			bool serverPushMoneyTree = this._Doc.ServerPushMoneyTree;
			bool result;
			if (serverPushMoneyTree)
			{
				result = true;
			}
			else
			{
				bool flag = this.m_AllHandlers.ContainsKey(XSysDefine.XSys_Welfare_MoneyTree);
				result = (flag && (this._Doc.WelfareMoneyTreeData.free_all_count > this._Doc.WelfareMoneyTreeData.free_count && this._Doc.WelfareMoneyTreeData.free_count + this._Doc.WelfareMoneyTreeData.count < this._Doc.WelfareMoneyTreeData.all_count) && (this._Doc.WelfareMoneyTreeData.left_time == 0U || this._Doc.WelfareMoneyTreeData.left_time < Time.time - this._Doc.WelfareMoneyTreeData.req_time));
			}
			return result;
		}

		// Token: 0x0600C70E RID: 50958 RVA: 0x002C206C File Offset: 0x002C026C
		private void SetHandlerVisible(XSysDefine define, bool isVisble)
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_AllHandlers.TryGetValue(define, out dlgHandlerBase);
			if (flag)
			{
				dlgHandlerBase.SetVisible(isVisble);
				if (isVisble)
				{
					this.m_currentDefine = define;
				}
			}
		}

		// Token: 0x0600C70F RID: 50959 RVA: 0x002C20A4 File Offset: 0x002C02A4
		public DlgHandlerBase GetHandler(XSysDefine define)
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_AllHandlers.TryGetValue(define, out dlgHandlerBase);
			DlgHandlerBase result;
			if (flag)
			{
				result = dlgHandlerBase;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600C710 RID: 50960 RVA: 0x002C20D0 File Offset: 0x002C02D0
		public bool OnTabClicked(IXUICheckBox checkbox)
		{
			bool flag = !checkbox.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XSysDefine xsysDefine = (XSysDefine)checkbox.ID;
				bool flag2 = this.m_currentDefine == xsysDefine;
				if (flag2)
				{
					result = false;
				}
				else
				{
					this.SetHandlerVisible(this.m_currentDefine, false);
					this.SetHandlerVisible(xsysDefine, true);
					switch (this.m_currentDefine)
					{
					case XSysDefine.XSys_Welfare_GiftBag:
						this._Doc.ReqPayClick(PayParamType.PAY_PARAM_AILEEN, XSysDefine.XSys_Welfare_GiftBag);
						break;
					case XSysDefine.XSys_Welfare_StarFund:
						this._Doc.ReqPayClick(PayParamType.PAY_PARAM_GROWTH_FUND, XSysDefine.XSys_Welfare_StarFund);
						break;
					case XSysDefine.XSys_Welfare_FirstRechange:
						this._Doc.ReqPayClick(PayParamType.PAY_PARAM_FIRSTAWARD, XSysDefine.XSys_Welfare_FirstRechange);
						break;
					case XSysDefine.XSyS_Welfare_RewardBack:
						this._Doc.RegisterFirstClick(XSysDefine.XSyS_Welfare_RewardBack, true, true);
						this._Doc.FirstRewardBack = true;
						break;
					case XSysDefine.XSys_Welfare_MoneyTree:
						this._Doc.RegisterFirstClick(XSysDefine.XSys_Welfare_MoneyTree, true, true);
						this._Doc.FirstMoneyTree = true;
						break;
					case XSysDefine.XSys_Welfare_KingdomPrivilege:
						this._Doc.ReqPayClick(PayParamType.PAY_PARAM_MEMBER, XSysDefine.XSys_Welfare_KingdomPrivilege);
						break;
					}
					this.RefreshData();
					this._Doc.ReqPayAllInfo();
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600C711 RID: 50961 RVA: 0x002C2218 File Offset: 0x002C0418
		public void RefreshData()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool initTab = this.m_InitTab;
				if (initTab)
				{
					this.m_InitTab = false;
					this.InitTabs();
					this.RefreshRedpoint();
				}
				DlgHandlerBase dlgHandlerBase;
				bool flag2 = this.m_AllHandlers.TryGetValue(this.m_currentDefine, out dlgHandlerBase) && dlgHandlerBase.IsVisible();
				if (flag2)
				{
					dlgHandlerBase.RefreshData();
					bool flag3 = this.m_currentDefine == XSysDefine.XSyS_Welfare_RewardBack;
					if (flag3)
					{
						this._Doc.FirstRewardBack = true;
						this._Doc.RegisterFirstClick(XSysDefine.XSyS_Welfare_RewardBack, true, true);
					}
				}
			}
		}

		// Token: 0x0600C712 RID: 50962 RVA: 0x002C22BC File Offset: 0x002C04BC
		public void SelectTab(XSysDefine tab)
		{
			bool flag = !base.IsVisible() || this.m_InitTab;
			if (!flag)
			{
				IXUICheckBox ixuicheckBox;
				bool flag2 = this.m_AllTabs.TryGetValue(tab, out ixuicheckBox);
				if (flag2)
				{
					bool flag3 = this.m_AllTabs.ContainsKey(this.m_currentDefine);
					if (flag3)
					{
						this.m_AllTabs[this.m_currentDefine].bChecked = false;
					}
					this.m_AllTabs[tab].bChecked = true;
					bool flag4 = this.m_AllHandlers.ContainsKey(tab);
					if (flag4)
					{
						this.SetHandlerVisible(tab, true);
					}
				}
			}
		}

		// Token: 0x0600C713 RID: 50963 RVA: 0x002C2354 File Offset: 0x002C0554
		public void RefreshRewardBackData()
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_AllHandlers.TryGetValue(XSysDefine.XSyS_Welfare_RewardBack, out dlgHandlerBase);
			if (flag)
			{
				dlgHandlerBase.RefreshData();
			}
		}

		// Token: 0x0600C714 RID: 50964 RVA: 0x002C2384 File Offset: 0x002C0584
		public void OnGetRewardInfo(ItemFindBackInfoRes oRes)
		{
			bool flag = this.m_currentDefine == XSysDefine.XSyS_Welfare_RewardBack;
			if (flag)
			{
				DlgHandlerBase dlgHandlerBase;
				bool flag2 = this.m_AllHandlers.TryGetValue(this.m_currentDefine, out dlgHandlerBase) && dlgHandlerBase.IsVisible();
				if (flag2)
				{
					dlgHandlerBase.RefreshData();
				}
			}
		}

		// Token: 0x0600C715 RID: 50965 RVA: 0x002C23D0 File Offset: 0x002C05D0
		public void OnGetMoneyTreeInfo(uint type, uint count, GoldClickRes clickres)
		{
			this.RefreshRedpoint();
			bool flag = this.m_currentDefine == XSysDefine.XSys_Welfare_MoneyTree;
			if (flag)
			{
				DlgHandlerBase dlgHandlerBase;
				bool flag2 = this.m_AllHandlers.TryGetValue(this.m_currentDefine, out dlgHandlerBase) && dlgHandlerBase.IsVisible();
				if (flag2)
				{
					dlgHandlerBase.RefreshData();
				}
				this._Doc.RegisterFirstClick(XSysDefine.XSys_Welfare_MoneyTree, true, true);
				this._Doc.FirstMoneyTree = true;
			}
		}

		// Token: 0x0600C716 RID: 50966 RVA: 0x002C2444 File Offset: 0x002C0644
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600C717 RID: 50967 RVA: 0x002C2460 File Offset: 0x002C0660
		public bool CheckActiveMemberPrivilege(MemberPrivilege type)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			bool flag = specificDocument.IsOwnMemberPrivilege(type);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				PayMemberTable.RowData memberPrivilegeConfig = XWelfareDocument.Doc.GetMemberPrivilegeConfig(type);
				bool flag2 = memberPrivilegeConfig == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					string @string = XStringDefineProxy.GetString("PAY_KINGDOM_GO_TO_BUY", new object[]
					{
						memberPrivilegeConfig.Name
					});
					string string2 = XStringDefineProxy.GetString("COMMON_OK");
					string string3 = XStringDefineProxy.GetString("COMMON_CANCEL");
					DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
					DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
					DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(@string, string2, string3);
					DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnActiveMemberPrivilege), null);
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600C718 RID: 50968 RVA: 0x002C2524 File Offset: 0x002C0724
		private bool OnActiveMemberPrivilege(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			DlgBase<XWelfareView, XWelfareBehaviour>.singleton.Show(XSysDefine.XSys_Welfare_KingdomPrivilege);
			return true;
		}

		// Token: 0x0400574C RID: 22348
		private Dictionary<XSysDefine, IXUICheckBox> m_AllTabs = new Dictionary<XSysDefine, IXUICheckBox>();

		// Token: 0x0400574D RID: 22349
		public Dictionary<XSysDefine, DlgHandlerBase> m_AllHandlers = new Dictionary<XSysDefine, DlgHandlerBase>();

		// Token: 0x0400574E RID: 22350
		private XSysDefine m_currentDefine = XSysDefine.XSys_None;

		// Token: 0x0400574F RID: 22351
		private XSysDefine m_normalDefine = XSysDefine.XSys_None;

		// Token: 0x04005750 RID: 22352
		private XWelfareDocument _Doc;

		// Token: 0x04005751 RID: 22353
		private bool m_InitTab = true;
	}
}
