using System;
using System.Collections;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A6D RID: 2669
	internal class XWelfareDocument : XDocComponent, IComparer
	{
		// Token: 0x17002F3E RID: 12094
		// (get) Token: 0x0600A1BD RID: 41405 RVA: 0x001B6D04 File Offset: 0x001B4F04
		public override uint ID
		{
			get
			{
				return XWelfareDocument.uuID;
			}
		}

		// Token: 0x17002F3F RID: 12095
		// (get) Token: 0x0600A1BE RID: 41406 RVA: 0x001B6D1C File Offset: 0x001B4F1C
		public static XWelfareDocument Doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			}
		}

		// Token: 0x17002F40 RID: 12096
		// (get) Token: 0x0600A1BF RID: 41407 RVA: 0x001B6D38 File Offset: 0x001B4F38
		// (set) Token: 0x0600A1C0 RID: 41408 RVA: 0x001B6D40 File Offset: 0x001B4F40
		public XWelfareView View { get; set; }

		// Token: 0x17002F41 RID: 12097
		// (get) Token: 0x0600A1C1 RID: 41409 RVA: 0x001B6D4C File Offset: 0x001B4F4C
		// (set) Token: 0x0600A1C2 RID: 41410 RVA: 0x001B6D64 File Offset: 0x001B4F64
		public bool FirstRewardBack
		{
			get
			{
				return this.m_firstRewardBack;
			}
			set
			{
				this.m_firstRewardBack = value;
			}
		}

		// Token: 0x17002F42 RID: 12098
		// (get) Token: 0x0600A1C3 RID: 41411 RVA: 0x001B6D70 File Offset: 0x001B4F70
		// (set) Token: 0x0600A1C4 RID: 41412 RVA: 0x001B6D88 File Offset: 0x001B4F88
		public bool FirstMoneyTree
		{
			get
			{
				return this.m_firstMoneyTree;
			}
			set
			{
				this.m_firstMoneyTree = value;
			}
		}

		// Token: 0x17002F43 RID: 12099
		// (get) Token: 0x0600A1C5 RID: 41413 RVA: 0x001B6D92 File Offset: 0x001B4F92
		// (set) Token: 0x0600A1C6 RID: 41414 RVA: 0x001B6D9A File Offset: 0x001B4F9A
		public bool ServerPushRewardBack { get; set; }

		// Token: 0x17002F44 RID: 12100
		// (get) Token: 0x0600A1C7 RID: 41415 RVA: 0x001B6DA3 File Offset: 0x001B4FA3
		// (set) Token: 0x0600A1C8 RID: 41416 RVA: 0x001B6DAB File Offset: 0x001B4FAB
		public bool ServerPushMoneyTree { get; set; }

		// Token: 0x17002F45 RID: 12101
		// (get) Token: 0x0600A1C9 RID: 41417 RVA: 0x001B6DB4 File Offset: 0x001B4FB4
		public MoneyTreeData WelfareMoneyTreeData
		{
			get
			{
				return this.m_MoneyTreeData;
			}
		}

		// Token: 0x17002F46 RID: 12102
		// (get) Token: 0x0600A1CA RID: 41418 RVA: 0x001B6DCC File Offset: 0x001B4FCC
		public List<PayCard> PayCardInfo
		{
			get
			{
				return this._payCardInfo;
			}
		}

		// Token: 0x17002F47 RID: 12103
		// (get) Token: 0x0600A1CB RID: 41419 RVA: 0x001B6DE4 File Offset: 0x001B4FE4
		public List<ItemFindBackInfo2Client> FindBackInfo
		{
			get
			{
				return this.m_FindBackInfo;
			}
		}

		// Token: 0x17002F48 RID: 12104
		// (get) Token: 0x0600A1CC RID: 41420 RVA: 0x001B6DFC File Offset: 0x001B4FFC
		public uint PayCardRemainTime
		{
			get
			{
				return this._payCardRemainTime;
			}
		}

		// Token: 0x17002F49 RID: 12105
		// (get) Token: 0x0600A1CD RID: 41421 RVA: 0x001B6E14 File Offset: 0x001B5014
		public PayAileen PayGiftBagInfo
		{
			get
			{
				return this._payGiftBagInfo;
			}
		}

		// Token: 0x17002F4A RID: 12106
		// (get) Token: 0x0600A1CE RID: 41422 RVA: 0x001B6E2C File Offset: 0x001B502C
		public uint RewardLittleGiftBag
		{
			get
			{
				return this._LittleGiftBag;
			}
		}

		// Token: 0x17002F4B RID: 12107
		// (get) Token: 0x0600A1CF RID: 41423 RVA: 0x001B6E44 File Offset: 0x001B5044
		public PayMemberPrivilege PayMemberPrivilege
		{
			get
			{
				return this._payMemberPrivilege;
			}
		}

		// Token: 0x17002F4C RID: 12108
		// (get) Token: 0x0600A1D0 RID: 41424 RVA: 0x001B6E5C File Offset: 0x001B505C
		public List<PayMember> PayMemeberInfo
		{
			get
			{
				return this._payMemberInfo;
			}
		}

		// Token: 0x17002F4D RID: 12109
		// (get) Token: 0x0600A1D1 RID: 41425 RVA: 0x001B6E74 File Offset: 0x001B5074
		public uint VipLevel
		{
			get
			{
				return this._vipLevel;
			}
		}

		// Token: 0x17002F4E RID: 12110
		// (get) Token: 0x0600A1D2 RID: 41426 RVA: 0x001B6E8C File Offset: 0x001B508C
		public static PayAileenTable AileenTable
		{
			get
			{
				return XWelfareDocument._payAileenTable;
			}
		}

		// Token: 0x17002F4F RID: 12111
		// (get) Token: 0x0600A1D3 RID: 41427 RVA: 0x001B6EA4 File Offset: 0x001B50A4
		public static PayWelfareTable WelfareTable
		{
			get
			{
				return XWelfareDocument._welfareTable;
			}
		}

		// Token: 0x17002F50 RID: 12112
		// (get) Token: 0x0600A1D4 RID: 41428 RVA: 0x001B6EBC File Offset: 0x001B50BC
		public static PayMemberTable PayMemberTable
		{
			get
			{
				return XWelfareDocument._payMemberTable;
			}
		}

		// Token: 0x0600A1D5 RID: 41429 RVA: 0x001B6ED4 File Offset: 0x001B50D4
		public void RegisterRedPoint(XSysDefine define, bool state, bool refresh = true)
		{
			bool flag = this._redpointState.ContainsKey(define);
			if (flag)
			{
				this._redpointState[define] = state;
			}
			else
			{
				this._redpointState.Add(define, state);
			}
			this.RefreshRedPoint(define, refresh);
		}

		// Token: 0x0600A1D6 RID: 41430 RVA: 0x001B6F1C File Offset: 0x001B511C
		public bool GetRedPointState(XSysDefine define)
		{
			return this._redpointState.ContainsKey(define) && this._redpointState[define];
		}

		// Token: 0x0600A1D7 RID: 41431 RVA: 0x001B6F4C File Offset: 0x001B514C
		public void RegisterFirstClick(XSysDefine define, bool state, bool refresh = true)
		{
			bool flag = this.m_clickDic.ContainsKey(define);
			if (flag)
			{
				this.m_clickDic[define] = state;
			}
			else
			{
				this.m_clickDic.Add(define, state);
			}
			this.RefreshRedPoint(define, refresh);
		}

		// Token: 0x0600A1D8 RID: 41432 RVA: 0x001B6F94 File Offset: 0x001B5194
		public bool GetFirstClick(XSysDefine define)
		{
			return !this.m_clickDic.ContainsKey(define) || this.m_clickDic[define];
		}

		// Token: 0x0600A1D9 RID: 41433 RVA: 0x001B6FC4 File Offset: 0x001B51C4
		public void RefreshRedPoint(XSysDefine define, bool refresh = true)
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(define, true);
			bool flag = refresh && this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshRedpoint();
			}
		}

		// Token: 0x0600A1DA RID: 41434 RVA: 0x001B700C File Offset: 0x001B520C
		public bool GetRedPoint(XSysDefine define)
		{
			bool flag = define == XSysDefine.XSyS_Welfare_RewardBack;
			bool result;
			if (flag)
			{
				bool flag2 = this.View != null;
				result = (flag2 && this.View.HadRewardBackRedPoint() && !this.GetFirstClick(define));
			}
			else
			{
				bool flag3 = define == XSysDefine.XSys_Welfare_MoneyTree;
				if (flag3)
				{
					bool flag4 = this.View != null;
					if (flag4)
					{
						result = this.View.HasMoneyTreeRedPoint();
					}
					else
					{
						result = this.ServerPushMoneyTree;
					}
				}
				else
				{
					bool flag5 = define == XSysDefine.XSys_Welfare_KingdomPrivilege;
					if (flag5)
					{
						result = (this.GetRedPoint(XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer) || this.GetRedPoint(XSysDefine.XSys_Welfare_KingdomPrivilege_Commerce) || this.GetRedPoint(XSysDefine.XSys_Welfare_KingdomPrivilege_Court));
					}
					else
					{
						bool flag6 = define == XSysDefine.XSys_Welfare_GiftBag;
						if (flag6)
						{
							result = (this.GetRedPointState(define) || (this.IsSystemAvailable(XSysDefine.XSys_Welfare_GiftBag) && this._LittleGiftBag == 0U));
						}
						else
						{
							bool flag7 = define == XSysDefine.XSys_Welfare_NiceGirl;
							if (flag7)
							{
								result = (this.GetRedPointState(define) || this.GetSpecialGiftRedPoint());
							}
							else
							{
								bool flag8 = define == XSysDefine.XSys_Welfare_YyMall;
								if (flag8)
								{
									result = this.GetRedPointState(define);
								}
								else
								{
									bool flag9 = define == XSysDefine.XSys_Welfare_GiftBag || define == XSysDefine.XSys_Welfare_KingdomPrivilege || define == XSysDefine.XSys_Welfare_StarFund || define == XSysDefine.XSys_Welfare_FirstRechange || define == XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer || define == XSysDefine.XSys_Welfare_KingdomPrivilege_Commerce || define == XSysDefine.XSys_Welfare_KingdomPrivilege_Court || define == XSysDefine.XSys_Welfare_NiceGirl;
									bool flag10 = !flag9 && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(define) && !this.GetFirstClick(define);
									result = (this.GetRedPointState(define) || flag10);
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600A1DB RID: 41435 RVA: 0x001B71CC File Offset: 0x001B53CC
		public static void Execute(OnLoadedCallback callback = null)
		{
			XWelfareDocument.AsyncLoader.AddTask("Table/PayAileen", XWelfareDocument._payAileenTable, false);
			XWelfareDocument.AsyncLoader.AddTask("Table/PayWelfare", XWelfareDocument._welfareTable, false);
			XWelfareDocument.AsyncLoader.AddTask("Table/Recharge/RechargeTable", XWelfareDocument._RechargeTable, false);
			XWelfareDocument.AsyncLoader.AddTask("Table/Recharge/PayFirst", XWelfareDocument._payFirst, false);
			XWelfareDocument.AsyncLoader.AddTask("Table/ItemBack", XWelfareDocument._rewardBackTable, false);
			XWelfareDocument.AsyncLoader.AddTask("Table/PayMember", XWelfareDocument._payMemberTable, false);
			XWelfareDocument.AsyncLoader.AddTask("Table/ArgentaDaily", XWelfareDocument._argentaDaily, false);
			XWelfareDocument.AsyncLoader.AddTask("Table/ArgentaTask", XWelfareDocument._argentaTask, false);
			XWelfareDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A1DC RID: 41436 RVA: 0x001B7296 File Offset: 0x001B5496
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnActivityUpdate));
		}

		// Token: 0x0600A1DD RID: 41437 RVA: 0x001B72B8 File Offset: 0x001B54B8
		public static void OnTableLoaded()
		{
			XWelfareDocument.m_RechargeDic.Clear();
			XWelfareDocument.m_PayDic.Clear();
			XWelfareDocument.m_payMemberIDDic.Clear();
			XWelfareDocument.m_AileenTableDic.Clear();
			int i = 0;
			int num = XWelfareDocument._RechargeTable.Table.Length;
			while (i < num)
			{
				RechargeTable.RowData rowData = XWelfareDocument._RechargeTable.Table[i];
				XWelfareDocument.m_RechargeDic.Add(rowData.SystemID, rowData);
				i++;
			}
			i = 0;
			num = XWelfareDocument._payFirst.Table.Length;
			while (i < num)
			{
				PayFirst.RowData rowData2 = XWelfareDocument._payFirst.Table[i];
				XWelfareDocument.m_PayDic.Add(rowData2.SystemID, rowData2);
				i++;
			}
			i = 0;
			num = XWelfareDocument._payMemberTable.Table.Length;
			while (i < num)
			{
				MemberPrivilege id = (MemberPrivilege)XWelfareDocument._payMemberTable.Table[i].ID;
				XWelfareDocument.m_payMemberIDDic[id] = XWelfareDocument._payMemberTable.Table[i];
				i++;
			}
			i = 0;
			num = XWelfareDocument._payAileenTable.Table.Length;
			while (i < num)
			{
				string paramID = XWelfareDocument._payAileenTable.Table[i].ParamID;
				List<PayAileenTable.RowData> list;
				bool flag = XWelfareDocument.m_AileenTableDic.TryGetValue(paramID, out list);
				if (flag)
				{
					list.Add(XWelfareDocument._payAileenTable.Table[i]);
				}
				else
				{
					list = new List<PayAileenTable.RowData>();
					list.Add(XWelfareDocument._payAileenTable.Table[i]);
					XWelfareDocument.m_AileenTableDic[paramID] = list;
				}
				i++;
			}
		}

		// Token: 0x0600A1DE RID: 41438 RVA: 0x001B744C File Offset: 0x001B564C
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._redpointState.Clear();
			this.ServerPushRewardBack = false;
			this.ServerPushMoneyTree = false;
			this.ArgentaMainInterfaceState = true;
		}

		// Token: 0x0600A1DF RID: 41439 RVA: 0x001B747C File Offset: 0x001B567C
		public void HideGiftBagBtn(string paramID)
		{
			XSingleton<XDebug>.singleton.AddLog("Pay [HideGiftBagBtn] servicecode = " + paramID, null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = this._payGiftBagInfo != null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("Pay [HideGiftBagBtn] 1", null, null, null, null, null, XDebugColor.XDebug_None);
				for (int i = 0; i < this._payGiftBagInfo.AileenInfo.Count; i++)
				{
					XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
					{
						"Pay [HideGiftBagBtn] 2 paramID = ",
						this._payGiftBagInfo.AileenInfo[i].paramID,
						", weekDays = ",
						this.PayGiftBagInfo.weekDays
					}), null, null, null, null, null, XDebugColor.XDebug_None);
					PayAileenTable.RowData giftBagTableData = XWelfareDocument.GetGiftBagTableData(this._payGiftBagInfo.AileenInfo[i].paramID, this.PayGiftBagInfo.weekDays);
					bool flag2 = giftBagTableData != null;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddLog("Pay [HideGiftBagBtn] 3 servicecode = " + giftBagTableData.ServiceCode, null, null, null, null, null, XDebugColor.XDebug_None);
					}
					bool flag3 = giftBagTableData != null && giftBagTableData.ServiceCode == paramID;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddLog("Pay [HideGiftBagBtn] 3 isBuy = true", null, null, null, null, null, XDebugColor.XDebug_None);
						this._payGiftBagInfo.AileenInfo[i].isBuy = true;
						break;
					}
				}
			}
			bool flag4 = this.View != null && this.View.IsVisible();
			if (flag4)
			{
				XSingleton<XDebug>.singleton.AddLog("Pay [HideGiftBagBtn] refreshData", null, null, null, null, null, XDebugColor.XDebug_None);
				this.View.RefreshData();
			}
		}

		// Token: 0x0600A1E0 RID: 41440 RVA: 0x001B7628 File Offset: 0x001B5828
		public void ResetGiftBagBtnCD(int interval)
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				DlgHandlerBase handler = this.View.GetHandler(XSysDefine.XSys_Welfare_GiftBag);
				bool flag2 = handler != null && handler.IsVisible();
				if (flag2)
				{
					XWelfareGiftBagHandler xwelfareGiftBagHandler = handler as XWelfareGiftBagHandler;
					bool flag3 = xwelfareGiftBagHandler != null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddLog("Pay [ResetGiftBagBtnCD] ResetGiftBagBtnCD", null, null, null, null, null, XDebugColor.XDebug_None);
						xwelfareGiftBagHandler.ResetGiftBagBtnCD(interval);
					}
				}
			}
		}

		// Token: 0x0600A1E1 RID: 41441 RVA: 0x001B76A8 File Offset: 0x001B58A8
		public void ReqPayAllInfo()
		{
			XSingleton<XDebug>.singleton.AddLog("Pay [ReqPayAllInfo]", null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2G_GetPayAllInfo rpc = new RpcC2G_GetPayAllInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A1E2 RID: 41442 RVA: 0x001B76E0 File Offset: 0x001B58E0
		public void OnGetPayAllInfo(GetPayAllInfoArg oArg, GetPayAllInfoRes oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				this.SetAllPayInfoData(oRes.info);
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.RefreshData();
				}
			}
		}

		// Token: 0x0600A1E3 RID: 41443 RVA: 0x001B7734 File Offset: 0x001B5934
		private void SetAllPayInfoData(PayAllInfo info)
		{
			bool flag = info == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Pay [SetAllPayInfoData] info == null", null, null, null, null, null);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("Pay [SetAllPayInfoData]", null, null, null, null, null, XDebugColor.XDebug_None);
				this._payGiftBagInfo = info.aileen;
				this._LittleGiftBag = info.rewardCoolTime;
				this._payCardInfo = info.card;
				this._vipLevel = info.vipLevel;
				this.RegisterFirstClick(XSysDefine.XSys_Welfare_GiftBag, info.payAileenFirstClick, false);
				this._payCardRemainTime = info.payCardRemainTime;
				this.m_rechargeFirstGift = info.payFirstAward;
				this.RegisterFirstClick(XSysDefine.XSys_Welfare_FirstRechange, info.payFirstAwardClick, false);
				this.RegisterFirstClick(XSysDefine.XSys_Welfare_StarFund, info.growthFundClick, false);
				this.RegisterFirstClick(XSysDefine.XSyS_Welfare_RewardBack, this.m_firstRewardBack, false);
				this.m_hasBuyGrowthFund = info.buyGrowthFund;
				this.m_loginDayCount = (int)info.totalLoginDays;
				this.m_growthFundDic[1] = info.growthFundLevelInfo;
				this.m_growthFundDic[2] = info.growthFundLoginInfo;
				this.CalculateGrowthFundRedPoint(false);
				this.CalculateRechargetFirstRedPoint(false);
				this.CalculateRewardBackRedPoint();
				this._payMemberInfo = info.payMemberInfo;
				this.RegisterPayMemberClick(info.payMemberInfo);
				this.CheckMemberPrivilegeType(this._payMemberInfo);
				XWelfareDocument.SetMemberPrivilegeIcon(this._payMemberInfo);
			}
		}

		// Token: 0x0600A1E4 RID: 41444 RVA: 0x001B7896 File Offset: 0x001B5A96
		public void OnGetPayMemberPrivilege(PayMemberPrivilege data)
		{
			this._payMemberPrivilege = data;
		}

		// Token: 0x0600A1E5 RID: 41445 RVA: 0x001B78A0 File Offset: 0x001B5AA0
		public int GetPayMemberReviveLeftCount()
		{
			bool flag = this._payMemberPrivilege == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				for (int i = 0; i < XWelfareDocument._payMemberTable.Table.Length; i++)
				{
					bool flag2 = this.IsOwnMemberPrivilege((MemberPrivilege)XWelfareDocument._payMemberTable.Table[i].ID);
					if (flag2)
					{
						num += XWelfareDocument._payMemberTable.Table[i].ReviveCount;
					}
				}
				result = num - this._payMemberPrivilege.usedReviveCount;
			}
			return result;
		}

		// Token: 0x0600A1E6 RID: 41446 RVA: 0x001B7924 File Offset: 0x001B5B24
		private void CheckMemberPrivilegeType(List<PayMember> info)
		{
			this.m_MemberPrivilege.Clear();
			XWelfareDocument._memberPrivilegeFlag = 0U;
			for (int i = 0; i < info.Count; i++)
			{
				MemberPrivilege id = (MemberPrivilege)info[i].ID;
				this.m_MemberPrivilege[id] = (info[i].ExpireTime > 0);
				bool flag = info[i].ExpireTime > 0;
				if (flag)
				{
					XWelfareDocument._memberPrivilegeFlag += (uint)Math.Pow(2.0, (double)info[i].ID);
				}
			}
		}

		// Token: 0x0600A1E7 RID: 41447 RVA: 0x001B79C0 File Offset: 0x001B5BC0
		public bool IsOwnMemberPrivilege(MemberPrivilege type)
		{
			bool flag2;
			bool flag = this.m_MemberPrivilege.TryGetValue(type, out flag2);
			return flag && flag2;
		}

		// Token: 0x0600A1E8 RID: 41448 RVA: 0x001B79EC File Offset: 0x001B5BEC
		public PayMemberTable.RowData GetMemberPrivilegeConfig(MemberPrivilege type)
		{
			PayMemberTable.RowData rowData;
			bool flag = XWelfareDocument.m_payMemberIDDic.TryGetValue(type, out rowData);
			PayMemberTable.RowData result;
			if (flag)
			{
				result = rowData;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A1E9 RID: 41449 RVA: 0x001B7A18 File Offset: 0x001B5C18
		private static void SetMemberPrivilegeIcon(List<PayMember> info)
		{
			XWelfareDocument._payMemberIcon.Clear();
			string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("WelfareMemberPrivilegeIconName", XGlobalConfig.ListSeparator);
			for (int i = 0; i < andSeparateValue.Length; i++)
			{
				string[] array = andSeparateValue[i].Split(new char[]
				{
					'='
				});
				bool flag = array.Length != 2;
				if (!flag)
				{
					uint key = uint.Parse(array[0]);
					XWelfareDocument._payMemberIcon[key] = array[1];
				}
			}
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshSelfMemberPrivilegeIcon();
		}

		// Token: 0x0600A1EA RID: 41450 RVA: 0x001B7AA4 File Offset: 0x001B5CA4
		public static string GetMemberPrivilegeIconString(uint value)
		{
			bool flag = !XWelfareDocument._payMemberIcon.ContainsKey(value);
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				result = XLabelSymbolHelper.FormatImage(XWelfareDocument.MEMBER_PRIVILEGE_ATLAS, XWelfareDocument._payMemberIcon[value]);
			}
			return result;
		}

		// Token: 0x0600A1EB RID: 41451 RVA: 0x001B7AE8 File Offset: 0x001B5CE8
		public static string GetSelfMemberPrivilegeIconString()
		{
			bool flag = !XWelfareDocument._payMemberIcon.ContainsKey(XWelfareDocument._memberPrivilegeFlag);
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				result = XLabelSymbolHelper.FormatImage(XWelfareDocument.MEMBER_PRIVILEGE_ATLAS, XWelfareDocument._payMemberIcon[XWelfareDocument._memberPrivilegeFlag]);
			}
			return result;
		}

		// Token: 0x0600A1EC RID: 41452 RVA: 0x001B7B34 File Offset: 0x001B5D34
		public static string GetSelfMemberPrivilegeIconName()
		{
			bool flag = !XWelfareDocument._payMemberIcon.ContainsKey(XWelfareDocument._memberPrivilegeFlag);
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				result = XWelfareDocument._payMemberIcon[XWelfareDocument._memberPrivilegeFlag];
			}
			return result;
		}

		// Token: 0x0600A1ED RID: 41453 RVA: 0x001B7B74 File Offset: 0x001B5D74
		public string GetMemberPrivilegeIcon(MemberPrivilege type)
		{
			uint key = (uint)Math.Pow(2.0, XFastEnumIntEqualityComparer<MemberPrivilege>.ToInt(type));
			string text;
			bool flag = XWelfareDocument._payMemberIcon.TryGetValue(key, out text);
			string result;
			if (flag)
			{
				result = text;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600A1EE RID: 41454 RVA: 0x001B7BBC File Offset: 0x001B5DBC
		public void PayAllInfoNtf(PayAllInfo info)
		{
			XSingleton<XDebug>.singleton.AddLog("Pay [PayAllInfoNtf]", null, null, null, null, null, XDebugColor.XDebug_None);
			this.CheckPayMemberResult(info);
			this.SetAllInfoMessage(info);
			this.SetAllPayInfoData(info);
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshRedpoint();
				this.View.RefreshData();
			}
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			specificDocument.RefreshSelfMemberPriviligeInfo(XWelfareDocument._memberPrivilegeFlag);
			XMainInterfaceDocument specificDocument2 = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			specificDocument2.RefreshVirtualItem(6);
		}

		// Token: 0x0600A1EF RID: 41455 RVA: 0x001B7C58 File Offset: 0x001B5E58
		private void SetAllInfoMessage(PayAllInfo info)
		{
			bool flag = info.payType == XFastEnumIntEqualityComparer<PayParamType>.ToInt(PayParamType.PAY_PARAM_GROWTH_FUND);
			if (flag)
			{
				RechargeTable.RowData rowData = null;
				bool flag2 = info.buyGrowthFund && !this.m_hasBuyGrowthFund && this.TryGetGrowthFundConf(XSysDefine.XSys_Welfare_StarFund, out rowData);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("WELFARE_GROWTHFUND_ERRORCODE", new object[]
					{
						rowData.Diamond
					}), "fece00");
				}
			}
		}

		// Token: 0x0600A1F0 RID: 41456 RVA: 0x001B7CD0 File Offset: 0x001B5ED0
		public void ReqPayClick(PayParamType type, XSysDefine define = XSysDefine.XSys_None)
		{
			bool flag = define == XSysDefine.XSys_None;
			if (!flag)
			{
				bool flag2 = false;
				bool flag3 = this.m_clickDic.TryGetValue(define, out flag2) && flag2;
				if (!flag3)
				{
					bool flag4 = define == XSysDefine.XSys_Welfare_KingdomPrivilege;
					if (flag4)
					{
						foreach (KeyValuePair<MemberPrivilege, PayMemberTable.RowData> keyValuePair in XWelfareDocument.m_payMemberIDDic)
						{
							bool flag5 = XSingleton<XGameSysMgr>.singleton.IsSystemOpen(keyValuePair.Value.SystemID);
							if (flag5)
							{
								RpcC2G_PayClick rpcC2G_PayClick = new RpcC2G_PayClick();
								rpcC2G_PayClick.oArg.buttonType = XFastEnumIntEqualityComparer<PayParamType>.ToInt(PayParamType.PAY_PARAM_MEMBER);
								rpcC2G_PayClick.oArg.memberid = XFastEnumIntEqualityComparer<MemberPrivilege>.ToInt(keyValuePair.Key);
								XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PayClick);
							}
						}
					}
					else
					{
						RpcC2G_PayClick rpcC2G_PayClick2 = new RpcC2G_PayClick();
						rpcC2G_PayClick2.oArg.buttonType = XFastEnumIntEqualityComparer<PayParamType>.ToInt(type);
						XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PayClick2);
					}
				}
			}
		}

		// Token: 0x0600A1F1 RID: 41457 RVA: 0x001B7DE4 File Offset: 0x001B5FE4
		public void RefreshFirstClickTabRedpoint(PayClickArg oArg, PayClickRes oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				bool flag2 = oArg.buttonType == XFastEnumIntEqualityComparer<PayParamType>.ToInt(PayParamType.PAY_PARAM_CARD);
				if (!flag2)
				{
					bool flag3 = oArg.buttonType == XFastEnumIntEqualityComparer<PayParamType>.ToInt(PayParamType.PAY_PARAM_AILEEN);
					if (flag3)
					{
						this.RegisterRedPoint(XSysDefine.XSys_Welfare_GiftBag, false, false);
						this.RegisterFirstClick(XSysDefine.XSys_Welfare_GiftBag, true, true);
					}
					else
					{
						bool flag4 = oArg.buttonType == XFastEnumIntEqualityComparer<PayParamType>.ToInt(PayParamType.PAY_PARAM_GROWTH_FUND);
						if (flag4)
						{
							this.RegisterFirstClick(XSysDefine.XSys_Welfare_StarFund, true, true);
						}
						else
						{
							bool flag5 = oArg.buttonType == XFastEnumIntEqualityComparer<PayParamType>.ToInt(PayParamType.PAY_PARAM_FIRSTAWARD);
							if (flag5)
							{
								this.RegisterFirstClick(XSysDefine.XSys_Welfare_FirstRechange, true, true);
							}
							else
							{
								bool flag6 = oArg.buttonType == XFastEnumIntEqualityComparer<PayParamType>.ToInt(PayParamType.PAY_PARAM_MEMBER);
								if (flag6)
								{
									foreach (KeyValuePair<MemberPrivilege, PayMemberTable.RowData> keyValuePair in XWelfareDocument.m_payMemberIDDic)
									{
										bool flag7 = keyValuePair.Key == (MemberPrivilege)oArg.memberid;
										if (flag7)
										{
											this.RegisterRedPoint((XSysDefine)keyValuePair.Value.SystemID, false, false);
											this.RegisterFirstClick((XSysDefine)keyValuePair.Value.SystemID, true, true);
											break;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A1F2 RID: 41458 RVA: 0x001B7F40 File Offset: 0x001B6140
		public bool IsSystemAvailable(XSysDefine sys)
		{
			if (sys != XSysDefine.XSys_ReceiveEnergy && sys != XSysDefine.XSys_Reward_Login)
			{
				switch (sys)
				{
				case XSysDefine.XSys_Welfare_GiftBag:
					return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Welfare_GiftBag) && this.PayGiftBagInfo != null && this.PayGiftBagInfo.AileenInfo.Count > 0;
				case XSysDefine.XSys_Welfare_StarFund:
				case XSysDefine.XSys_Welfare_FirstRechange:
				case XSysDefine.XSyS_Welfare_RewardBack:
				case XSysDefine.XSys_Welfare_MoneyTree:
				case XSysDefine.XSys_Welfare_NiceGirl:
				case XSysDefine.XSys_Welfare_YyMall:
					goto IL_BD;
				case XSysDefine.XSys_Welfare_KingdomPrivilege:
					return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Welfare_KingdomPrivilege_Court) || XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer) || XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Welfare_KingdomPrivilege_Commerce);
				}
				return false;
			}
			IL_BD:
			return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys);
		}

		// Token: 0x0600A1F3 RID: 41459 RVA: 0x001B8020 File Offset: 0x001B6220
		public bool GetTabRedpointState(XSysDefine type)
		{
			return this.GetRedPoint(type);
		}

		// Token: 0x0600A1F4 RID: 41460 RVA: 0x001B803C File Offset: 0x001B623C
		private void RefreshData()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshData();
			}
		}

		// Token: 0x0600A1F5 RID: 41461 RVA: 0x001B8074 File Offset: 0x001B6274
		public bool IsGiftBagItem(int itemID)
		{
			for (int i = 0; i < XWelfareDocument._payAileenTable.Table.Length; i++)
			{
				bool flag = XWelfareDocument._payAileenTable.Table[i].LevelSealGiftID != null;
				if (flag)
				{
					for (int j = 0; j < XWelfareDocument._payAileenTable.Table[i].LevelSealGiftID.Length; j++)
					{
						bool flag2 = itemID == XWelfareDocument._payAileenTable.Table[i].LevelSealGiftID[j];
						if (flag2)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600A1F6 RID: 41462 RVA: 0x001B8108 File Offset: 0x001B6308
		public void GetCardDailyDiamond(uint type)
		{
			RpcC2G_PayCardAward rpcC2G_PayCardAward = new RpcC2G_PayCardAward();
			rpcC2G_PayCardAward.oArg.type = (int)type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PayCardAward);
		}

		// Token: 0x0600A1F7 RID: 41463 RVA: 0x001B8138 File Offset: 0x001B6338
		public void OnGetCardDailyDiamond(PayCardAwardArg oArg, PayCardAwardRes oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				for (int i = 0; i < this._payCardInfo.Count; i++)
				{
					bool flag2 = (ulong)this._payCardInfo[i].type == (ulong)((long)oArg.type);
					if (flag2)
					{
						this._payCardInfo.RemoveAt(i);
						this._payCardInfo.Add(oRes.info);
						break;
					}
				}
				bool flag3 = false;
				for (int j = 0; j < this._payCardInfo.Count; j++)
				{
					bool flag4 = !this._payCardInfo[j].isGet;
					if (flag4)
					{
						flag3 = true;
						break;
					}
				}
				bool flag5 = !flag3;
				if (flag5)
				{
				}
				bool flag6 = this.View != null && this.View.IsVisible();
				if (flag6)
				{
					this.View.RefreshData();
				}
			}
		}

		// Token: 0x0600A1F8 RID: 41464 RVA: 0x001B8234 File Offset: 0x001B6434
		public static PayCardTable.RowData GetPayCardConfig(uint type)
		{
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			for (int i = 0; i < specificDocument.PayCardReader.Table.Length; i++)
			{
				bool flag = (long)specificDocument.PayCardReader.Table[i].Type == (long)((ulong)type);
				if (flag)
				{
					return specificDocument.PayCardReader.Table[i];
				}
			}
			return null;
		}

		// Token: 0x0600A1F9 RID: 41465 RVA: 0x001B82A0 File Offset: 0x001B64A0
		public static int GetGiftBagTableIndex(string patamID)
		{
			for (int i = 0; i < XWelfareDocument._payAileenTable.Table.Length; i++)
			{
				bool flag = XWelfareDocument._payAileenTable.Table[i].ParamID == patamID;
				if (flag)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600A1FA RID: 41466 RVA: 0x001B82F0 File Offset: 0x001B64F0
		public static PayAileenTable.RowData GetGiftBagTableData(string paramID, uint weekDay)
		{
			List<PayAileenTable.RowData> list;
			bool flag = XWelfareDocument.m_AileenTableDic.TryGetValue(paramID, out list);
			if (flag)
			{
				for (int i = 0; i < list.Count; i++)
				{
					bool flag2 = (long)list[i].Days == (long)((ulong)weekDay);
					if (flag2)
					{
						return list[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0600A1FB RID: 41467 RVA: 0x001B8354 File Offset: 0x001B6554
		public void GetLittleGiftBag()
		{
			RpcC2G_GetPayReward rpc = new RpcC2G_GetPayReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A1FC RID: 41468 RVA: 0x001B8374 File Offset: 0x001B6574
		public void OnGetLittleGiftBox(GetPayRewardArg oArg, GetPayRewardRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				this._LittleGiftBag = oRes.cdTime;
				this.RefreshRedPoint(XSysDefine.XSys_Welfare_GiftBag, true);
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.RefreshData();
				}
			}
		}

		// Token: 0x17002F51 RID: 12113
		// (get) Token: 0x0600A1FD RID: 41469 RVA: 0x001B83EC File Offset: 0x001B65EC
		public int LoginDayCount
		{
			get
			{
				return this.m_loginDayCount;
			}
		}

		// Token: 0x0600A1FE RID: 41470 RVA: 0x001B8404 File Offset: 0x001B6604
		public bool TryGetGrowthFundConf(XSysDefine define, out RechargeTable.RowData rowData)
		{
			return XWelfareDocument.m_RechargeDic.TryGetValue(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(define), out rowData);
		}

		// Token: 0x17002F52 RID: 12114
		// (get) Token: 0x0600A1FF RID: 41471 RVA: 0x001B8428 File Offset: 0x001B6628
		public bool HasBuyGrowthFund
		{
			get
			{
				return this.m_hasBuyGrowthFund;
			}
		}

		// Token: 0x0600A200 RID: 41472 RVA: 0x001B8440 File Offset: 0x001B6640
		public bool HasGrowthFundGet(int type, int value)
		{
			return this.m_growthFundDic.ContainsKey(type) && this.m_growthFundDic[type].Contains(value);
		}

		// Token: 0x0600A201 RID: 41473 RVA: 0x001B8478 File Offset: 0x001B6678
		public void GetGrowthFundAward(int type, int value)
		{
			RpcC2G_GrowthFundAward rpcC2G_GrowthFundAward = new RpcC2G_GrowthFundAward();
			rpcC2G_GrowthFundAward.oArg.type = type;
			rpcC2G_GrowthFundAward.oArg.value = value;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GrowthFundAward);
		}

		// Token: 0x0600A202 RID: 41474 RVA: 0x001B84B4 File Offset: 0x001B66B4
		public int GetGrowthFundLength()
		{
			int num = 0;
			List<int> list;
			bool flag = this.m_growthFundDic.TryGetValue(1, out list);
			if (flag)
			{
				num += list.Count;
			}
			bool flag2 = this.m_growthFundDic.TryGetValue(2, out list);
			if (flag2)
			{
				num += list.Count;
			}
			return num;
		}

		// Token: 0x0600A203 RID: 41475 RVA: 0x001B8508 File Offset: 0x001B6708
		public void OnGetGrowthFundAward(GrowthFundAwardArg oArg, GrowthFundAwardRes oRes)
		{
			bool flag = oRes.errcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errcode, "fece00");
			}
			else
			{
				List<int> list;
				bool flag2 = this.m_growthFundDic.TryGetValue(1, out list);
				if (flag2)
				{
					int i = 0;
					int count = oRes.growthFundLevelInfo.Count;
					while (i < count)
					{
						bool flag3 = list.IndexOf(oRes.growthFundLevelInfo[i]) == -1;
						if (flag3)
						{
							list.Add(oRes.growthFundLevelInfo[i]);
						}
						i++;
					}
				}
				bool flag4 = this.m_growthFundDic.TryGetValue(2, out list);
				if (flag4)
				{
					int i = 0;
					int count = oRes.growthFundLoginInfo.Count;
					while (i < count)
					{
						bool flag5 = list.IndexOf(oRes.growthFundLoginInfo[i]) == -1;
						if (flag5)
						{
							list.Add(oRes.growthFundLoginInfo[i]);
						}
						i++;
					}
				}
				this.CalcaulateGrowthFundMessage(oArg.type, oArg.value);
				this.CalculateGrowthFundRedPoint(true);
				this.RefreshData();
			}
		}

		// Token: 0x0600A204 RID: 41476 RVA: 0x001B862C File Offset: 0x001B682C
		private void CalcaulateGrowthFundMessage(int type, int key)
		{
			bool flag = false;
			int num = 0;
			RechargeTable.RowData rowData;
			bool flag2 = this.TryGetGrowthFundConf(XSysDefine.XSys_Welfare_StarFund, out rowData);
			if (flag2)
			{
				bool flag3 = this.GetGrowthFundLength() == rowData.RoleLevels.Count + rowData.LoginDays.Count;
				bool flag4 = type == 1;
				if (flag4)
				{
					int i = 0;
					int count = rowData.RoleLevels.Count;
					while (i < count)
					{
						bool flag5 = rowData.RoleLevels[i, 0] == key;
						if (flag5)
						{
							num = rowData.RoleLevels[i, 1];
							flag = true;
							break;
						}
						i++;
					}
				}
				else
				{
					bool flag6 = type == 2;
					if (flag6)
					{
						int i = 0;
						int count = rowData.LoginDays.Count;
						while (i < count)
						{
							bool flag7 = rowData.LoginDays[i, 0] == key;
							if (flag7)
							{
								num = rowData.LoginDays[i, 1];
								flag = true;
								break;
							}
							i++;
						}
					}
				}
			}
			bool flag8 = flag;
			if (flag8)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("WELFARE_GROWTHFUND_ERRORCODE1", new object[]
				{
					num
				}), "fece00");
			}
		}

		// Token: 0x0600A205 RID: 41477 RVA: 0x001B8768 File Offset: 0x001B6968
		private void CalculateGrowthFundRedPoint(bool refresh = true)
		{
			bool flag = !this.m_hasBuyGrowthFund;
			if (flag)
			{
				this.RegisterRedPoint(XSysDefine.XSys_Welfare_StarFund, false, refresh);
			}
			else
			{
				RechargeTable.RowData rowData;
				bool flag2 = this.TryGetGrowthFundConf(XSysDefine.XSys_Welfare_StarFund, out rowData);
				if (flag2)
				{
					uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
					int i = 0;
					int count = rowData.RoleLevels.Count;
					while (i < count)
					{
						bool flag3 = !this.HasGrowthFundGet(1, rowData.RoleLevels[i, 0]) && (long)rowData.RoleLevels[i, 0] <= (long)((ulong)level);
						if (flag3)
						{
							this.RegisterRedPoint(XSysDefine.XSys_Welfare_StarFund, true, refresh);
							return;
						}
						i++;
					}
					i = 0;
					count = rowData.LoginDays.Count;
					while (i < count)
					{
						bool flag4 = !this.HasGrowthFundGet(2, rowData.LoginDays[i, 0]) && rowData.LoginDays[i, 0] <= this.m_loginDayCount;
						if (flag4)
						{
							this.RegisterRedPoint(XSysDefine.XSys_Welfare_StarFund, true, refresh);
							return;
						}
						i++;
					}
				}
				this.RegisterRedPoint(XSysDefine.XSys_Welfare_StarFund, false, refresh);
			}
		}

		// Token: 0x0600A206 RID: 41478 RVA: 0x001B88A4 File Offset: 0x001B6AA4
		public bool HasFullFirstRecharge()
		{
			bool result = false;
			PayFirst.RowData rowData;
			bool flag = this.TryGetPayFirstData(XSysDefine.XSys_Welfare_FirstRechange, out rowData);
			if (flag)
			{
				int money = rowData.Money;
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				result = ((float)money <= specificDocument.TotalPay * 100f);
			}
			return result;
		}

		// Token: 0x17002F53 RID: 12115
		// (get) Token: 0x0600A207 RID: 41479 RVA: 0x001B88F8 File Offset: 0x001B6AF8
		public bool HasGetFirstRecharge
		{
			get
			{
				return this.m_rechargeFirstGift;
			}
		}

		// Token: 0x17002F54 RID: 12116
		// (get) Token: 0x0600A208 RID: 41480 RVA: 0x001B8910 File Offset: 0x001B6B10
		public List<uint> CurArgentaDailyIDList
		{
			get
			{
				return this._curArgentaDailyIDList;
			}
		}

		// Token: 0x0600A209 RID: 41481 RVA: 0x001B8928 File Offset: 0x001B6B28
		public bool TryGetPayFirstData(XSysDefine define, out PayFirst.RowData rowData)
		{
			int key = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(define);
			return XWelfareDocument.m_PayDic.TryGetValue(key, out rowData);
		}

		// Token: 0x0600A20A RID: 41482 RVA: 0x001B8950 File Offset: 0x001B6B50
		public void GetPayFirstAward()
		{
			RpcC2G_PayFirstAward rpc = new RpcC2G_PayFirstAward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A20B RID: 41483 RVA: 0x001B8970 File Offset: 0x001B6B70
		public void OnGetPayFirstAward(PayFirstAwardRes oRes)
		{
			bool flag = oRes.errcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errcode, "fece00");
			}
			else
			{
				this.CalculateRechargetFirstRedPoint(true);
				this.RefreshData();
			}
		}

		// Token: 0x0600A20C RID: 41484 RVA: 0x001B89B4 File Offset: 0x001B6BB4
		public bool GetCanRechargeFirst()
		{
			return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Welfare_FirstRechange) && !this.m_rechargeFirstGift && this.HasFullFirstRecharge();
		}

		// Token: 0x0600A20D RID: 41485 RVA: 0x001B89E8 File Offset: 0x001B6BE8
		private void CalculateRechargetFirstRedPoint(bool refresh = true)
		{
			bool canRechargeFirst = this.GetCanRechargeFirst();
			this.RegisterRedPoint(XSysDefine.XSys_Welfare_FirstRechange, this.GetCanRechargeFirst(), refresh);
		}

		// Token: 0x0600A20E RID: 41486 RVA: 0x001B8A10 File Offset: 0x001B6C10
		public static ItemBackTable.RowData GetRewardBackByIndex(int index)
		{
			for (int i = 0; i < XWelfareDocument._rewardBackTable.Table.Length; i++)
			{
				bool flag = XWelfareDocument._rewardBackTable.Table[i].ID == index;
				if (flag)
				{
					return XWelfareDocument._rewardBackTable.Table[i];
				}
			}
			return null;
		}

		// Token: 0x0600A20F RID: 41487 RVA: 0x001B8A68 File Offset: 0x001B6C68
		private void CalculateRewardBackRedPoint()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshRedpoint();
				this.RegisterRedPoint(XSysDefine.XSyS_Welfare_RewardBack, this.View.HadRewardBackRedPoint(), true);
			}
		}

		// Token: 0x0600A210 RID: 41488 RVA: 0x001B8AB8 File Offset: 0x001B6CB8
		public void ReqRewardInfo()
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSyS_Welfare_RewardBack);
			if (!flag)
			{
				RpcC2G_ItemFindBackInfo rpc = new RpcC2G_ItemFindBackInfo();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
				XSuperRiskDocument doc = XSuperRiskDocument.Doc;
				bool flag2 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_SuperRisk);
				if (flag2)
				{
					RiskMapFile.RowData mapIdByIndex = doc.GetMapIdByIndex(0);
					bool flag3 = mapIdByIndex != null && (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (ulong)((long)mapIdByIndex.NeedLevel);
					if (flag3)
					{
						doc.ReqMapDynamicInfo(1, false, true);
					}
				}
			}
		}

		// Token: 0x0600A211 RID: 41489 RVA: 0x001B8B48 File Offset: 0x001B6D48
		public void ReqMoneyTreeInfo()
		{
			RpcC2G_GoldClick rpcC2G_GoldClick = new RpcC2G_GoldClick();
			rpcC2G_GoldClick.oArg.type = 0U;
			rpcC2G_GoldClick.oArg.count = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GoldClick);
		}

		// Token: 0x0600A212 RID: 41490 RVA: 0x001B8B84 File Offset: 0x001B6D84
		public void OnRefreshRewardBack()
		{
			bool flag = this.View != null && this.View.IsLoaded() && this.View.IsVisible();
			if (flag)
			{
				this.RefreshData();
			}
		}

		// Token: 0x0600A213 RID: 41491 RVA: 0x001B8BC0 File Offset: 0x001B6DC0
		public void OnGetRewardInfo(ItemFindBackInfoRes oRes)
		{
			this.m_FindBackInfo = oRes.backInfo;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshRewardBackData();
				this.View.OnGetRewardInfo(oRes);
			}
			this.CalculateRewardBackRedPoint();
		}

		// Token: 0x0600A214 RID: 41492 RVA: 0x001B8C18 File Offset: 0x001B6E18
		public void ReqRewardFindBack(ItemFindBackType type, int count)
		{
			RpcC2G_ItemFindBack rpcC2G_ItemFindBack = new RpcC2G_ItemFindBack();
			rpcC2G_ItemFindBack.oArg.id = type;
			rpcC2G_ItemFindBack.oArg.findBackCount = count;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ItemFindBack);
		}

		// Token: 0x0600A215 RID: 41493 RVA: 0x001B8C54 File Offset: 0x001B6E54
		public void OnGetRewardFindBack(ItemFindBackArg oArg)
		{
			int num = oArg.findBackCount;
			int num2 = 0;
			for (int i = 0; i < this.m_FindBackInfo.Count; i++)
			{
				bool flag = this.m_FindBackInfo[i].id == oArg.id;
				if (flag)
				{
					bool flag2 = oArg.backType == 1;
					if (flag2)
					{
						num2 = XWelfareDocument.GetRewardBackByIndex(XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.DICE_BACK)).ItemDragonCoin[0, 1];
					}
					else
					{
						num2 = XWelfareDocument.GetRewardBackByIndex(XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.DICE_BACK)).ItemGold[0, 1];
					}
					bool flag3 = this.m_FindBackInfo[i].findBackCount >= num;
					if (flag3)
					{
						this.m_FindBackInfo[i].findBackCount -= num;
						break;
					}
					num -= this.m_FindBackInfo[i].findBackCount;
					this.m_FindBackInfo[i].findBackCount = 0;
				}
			}
			this.RefreshData();
			this.CalculateRewardBackRedPoint();
			bool flag4 = oArg.id == ItemFindBackType.DICE_BACK;
			if (flag4)
			{
				string text = string.Format("[{0}]{1}", XSingleton<UiUtility>.singleton.GetItemQualityRGB((int)XBagDocument.GetItemConf(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DICE)).ItemQuality).ToString(), XSingleton<UiUtility>.singleton.ChooseProfString(XBagDocument.GetItemConf(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DICE)).ItemName, 0U));
				string text2 = string.Format("{0}[ffffff]x{1}", XStringDefineProxy.GetString("GET_ITEM", new object[]
				{
					text
				}), (oArg.findBackCount * num2).ToString());
				XSingleton<UiUtility>.singleton.ShowSystemTip(text2, "fece00");
			}
		}

		// Token: 0x0600A216 RID: 41494 RVA: 0x001B8E04 File Offset: 0x001B7004
		public void OnPtcFindItemBack()
		{
			bool flag = !this.m_firstRewardBack;
			if (flag)
			{
				this.ServerPushRewardBack = true;
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSyS_Welfare_RewardBack, true);
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Welfare, true);
			}
		}

		// Token: 0x0600A217 RID: 41495 RVA: 0x001B8E4C File Offset: 0x001B704C
		public void OnPtcFirstNotify(bool first)
		{
			if (first)
			{
				bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL;
				if (flag)
				{
					bool flag2 = DlgBase<XWelfareView, XWelfareBehaviour>.singleton.IsVisible();
					if (flag2)
					{
						DlgBase<XWelfareView, XWelfareBehaviour>.singleton.RefershRewardBack();
					}
					DlgBase<XWelfareView, XWelfareBehaviour>.singleton.Show(XSysDefine.XSyS_Welfare_RewardBack);
				}
			}
		}

		// Token: 0x0600A218 RID: 41496 RVA: 0x001B8EA0 File Offset: 0x001B70A0
		public void OnPtcMoneyTree()
		{
			bool flag = !this.m_firstMoneyTree;
			if (flag)
			{
				this.ServerPushMoneyTree = true;
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Welfare_MoneyTree, true);
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Welfare, true);
			}
		}

		// Token: 0x0600A219 RID: 41497 RVA: 0x001B8EE8 File Offset: 0x001B70E8
		private void RegisterPayMemberClick(List<PayMember> info)
		{
			for (int i = 0; i < info.Count; i++)
			{
				int id = info[i].ID;
				for (int j = 0; j < XWelfareDocument._payMemberTable.Table.Length; j++)
				{
					bool flag = id == XWelfareDocument._payMemberTable.Table[j].ID;
					if (flag)
					{
						int systemID = XWelfareDocument._payMemberTable.Table[j].SystemID;
						this.RegisterFirstClick((XSysDefine)systemID, info[i].isClick, false);
					}
				}
			}
		}

		// Token: 0x0600A21A RID: 41498 RVA: 0x001B8F84 File Offset: 0x001B7184
		private void CheckPayMemberResult(PayAllInfo info)
		{
			bool flag = this._payMemberInfo == null;
			if (!flag)
			{
				bool flag2 = info.payType == 6;
				if (flag2)
				{
					for (int i = 0; i < this._payMemberInfo.Count; i++)
					{
						for (int j = 0; j < info.payMemberInfo.Count; j++)
						{
							bool flag3 = this._payMemberInfo[i].ID == info.payMemberInfo[j].ID;
							if (flag3)
							{
								PayMember payMember = this._payMemberInfo[i];
								PayMember payMember2 = info.payMemberInfo[j];
								bool flag4 = payMember.ExpireTime != 0 && payMember2.ExpireTime > payMember.ExpireTime;
								if (flag4)
								{
									PayMemberTable.RowData info2;
									bool flag5 = XWelfareDocument.m_payMemberIDDic.TryGetValue((MemberPrivilege)this._payMemberInfo[i].ID, out info2);
									if (flag5)
									{
										DlgBase<XWelfareKingdomPrivilegeRenewView, XWelfareKingdomPrivilegeRenewBehaviour>.singleton.Show(info2, true, payMember2.ExpireTime);
										break;
									}
								}
								else
								{
									bool flag6 = payMember.ExpireTime == 0 && payMember2.ExpireTime > 0;
									if (flag6)
									{
										PayMemberTable.RowData info3;
										bool flag7 = XWelfareDocument.m_payMemberIDDic.TryGetValue((MemberPrivilege)this._payMemberInfo[i].ID, out info3);
										if (flag7)
										{
											DlgBase<XWelfareKingdomPrivilegeDetailView, XWelfareKingdomPrivilegeDetailBehaviour>.singleton.ShowDetail(info3, false);
											break;
										}
									}
									else
									{
										bool flag8 = payMember.ExpireTime > 0 && payMember2.ExpireTime == 0;
										if (flag8)
										{
											PayMemberTable.RowData rowData;
											bool flag9 = XWelfareDocument.m_payMemberIDDic.TryGetValue((MemberPrivilege)this._payMemberInfo[i].ID, out rowData);
											if (flag9)
											{
												XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("PAY_KINGDOM_OUT_OF_DATE", new object[]
												{
													rowData.Name
												}), "fece00");
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A21B RID: 41499 RVA: 0x001B9178 File Offset: 0x001B7378
		public void OnGetMoneyTreeInfo(uint type, uint count, GoldClickRes res)
		{
			bool flag = res.freeallcount == 0U || res.allcount == 0U;
			if (flag)
			{
				bool flag2 = type == 1U;
				if (flag2)
				{
					this.m_MoneyTreeData.free_count += 1U;
					this.m_MoneyTreeData.left_time = res.freetimeleft;
					this.m_MoneyTreeData.req_time = Time.time;
				}
				else
				{
					bool flag3 = type == 2U;
					if (flag3)
					{
						this.m_MoneyTreeData.count += count;
					}
				}
			}
			else
			{
				this.m_MoneyTreeData.free_count = res.freecount;
				this.m_MoneyTreeData.free_all_count = res.freeallcount;
				this.m_MoneyTreeData.count = res.count;
				this.m_MoneyTreeData.all_count = res.allcount;
				this.m_MoneyTreeData.left_time = res.freetimeleft;
				this.m_MoneyTreeData.req_time = Time.time;
				this.m_MoneyTreeData.result = res.results;
			}
			bool flag4 = this.View != null && this.View.IsVisible();
			if (flag4)
			{
				this.View.OnGetMoneyTreeInfo(type, count, res);
			}
		}

		// Token: 0x0600A21C RID: 41500 RVA: 0x001B92A0 File Offset: 0x001B74A0
		public ArgentaDaily.RowData GetArgentDailyDataByIndex(int index)
		{
			bool flag = index < XWelfareDocument._argentaDaily.Table.Length;
			ArgentaDaily.RowData result;
			if (flag)
			{
				result = XWelfareDocument._argentaDaily.Table[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A21D RID: 41501 RVA: 0x001B92D8 File Offset: 0x001B74D8
		public int GetArgentDailyDataCount()
		{
			return XWelfareDocument._argentaDaily.Table.Length;
		}

		// Token: 0x0600A21E RID: 41502 RVA: 0x001B92F8 File Offset: 0x001B74F8
		public ArgentaTask.RowData GetArgentTaskDataByIndex(int index)
		{
			bool flag = index < XWelfareDocument._argentaTask.Table.Length;
			ArgentaTask.RowData result;
			if (flag)
			{
				result = XWelfareDocument._argentaTask.Table[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A21F RID: 41503 RVA: 0x001B9330 File Offset: 0x001B7530
		public void SendArgentaActivityInfo(uint type, uint taskid)
		{
			RpcC2G_ArgentaActivity rpcC2G_ArgentaActivity = new RpcC2G_ArgentaActivity();
			rpcC2G_ArgentaActivity.oArg.type = type;
			rpcC2G_ArgentaActivity.oArg.id = taskid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ArgentaActivity);
		}

		// Token: 0x0600A220 RID: 41504 RVA: 0x001B936C File Offset: 0x001B756C
		public void OnGetArgentaActivityInfo(ArgentaActivityArg oArg, ArgentaActivityRes oRes)
		{
			bool flag = oArg.type == 1U;
			if (flag)
			{
				this._curArgentaDailyIDList = oRes.getRewardIDs;
				this.ActivityLeftTime = oRes.leftTime + (uint)Time.realtimeSinceStartup;
				this._rewardsLevel = oRes.level;
			}
			else
			{
				this.CurArgentaDailyIDList.Add(oArg.id);
				this.SortArgentDailyData();
				bool flag2 = this.IsDailyAllGetted();
				bool flag3 = flag2;
				if (flag3)
				{
					this.RegisterRedPoint(XSysDefine.XSys_Welfare_NiceGirl, !flag2, true);
				}
			}
			bool flag4 = this.View != null && this.View.IsLoaded() && this.View.IsVisible();
			if (flag4)
			{
				this.RefreshData();
			}
			bool bState = this.GetRedPointState(XSysDefine.XSys_Welfare_NiceGirl) || this.GetSpecialGiftRedPoint();
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Welfare_NiceGirl, bState);
			this.RefreshRedPoint(XSysDefine.XSys_Welfare_NiceGirl, true);
		}

		// Token: 0x0600A221 RID: 41505 RVA: 0x001B9454 File Offset: 0x001B7654
		public bool IsDailyAllGetted()
		{
			bool result = true;
			for (int i = 0; i < XWelfareDocument._argentaDaily.Table.Length; i++)
			{
				ArgentaDaily.RowData rowData = XWelfareDocument._argentaDaily.Table[i];
				bool flag = !this._curArgentaDailyIDList.Contains(rowData.ID);
				if (flag)
				{
					result = false;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600A222 RID: 41506 RVA: 0x001B94B4 File Offset: 0x001B76B4
		public bool IsNiceGirlTasksFinished()
		{
			return this.IsAllSpecialGiftTaskFinished() && !this.GetDailyGiftRedPoint();
		}

		// Token: 0x0600A223 RID: 41507 RVA: 0x001B94DC File Offset: 0x001B76DC
		public bool GetSpecialGiftRedPoint()
		{
			List<SpActivityTask> activityTaskListByType = XTempActivityDocument.Doc.GetActivityTaskListByType(7U);
			bool flag = activityTaskListByType != null;
			if (flag)
			{
				for (int i = 0; i < activityTaskListByType.Count; i++)
				{
					bool flag2 = activityTaskListByType[i].state == 1U;
					if (flag2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600A224 RID: 41508 RVA: 0x001B9538 File Offset: 0x001B7738
		public bool IsAllSpecialGiftTaskFinished()
		{
			List<SpActivityTask> activityTaskListByType = XTempActivityDocument.Doc.GetActivityTaskListByType(7U);
			bool flag = activityTaskListByType != null;
			if (flag)
			{
				for (int i = 0; i < activityTaskListByType.Count; i++)
				{
					bool flag2 = activityTaskListByType[i].state != 2U;
					if (flag2)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0600A225 RID: 41509 RVA: 0x001B9598 File Offset: 0x001B7798
		public bool GetDailyGiftRedPoint()
		{
			return this.GetRedPointState(XSysDefine.XSys_Welfare_NiceGirl);
		}

		// Token: 0x0600A226 RID: 41510 RVA: 0x001B95B8 File Offset: 0x001B77B8
		public SeqListRef<uint>? GetArgentTaskRewards(uint taskid)
		{
			for (int i = 0; i < XWelfareDocument._argentaTask.Table.Length; i++)
			{
				ArgentaTask.RowData rowData = XWelfareDocument._argentaTask.Table[i];
				bool flag = this._rewardsLevel >= rowData.LevelRange[0] && this._rewardsLevel <= rowData.LevelRange[1];
				if (flag)
				{
					bool flag2 = rowData.TaskID == taskid;
					if (flag2)
					{
						return new SeqListRef<uint>?(rowData.Reward);
					}
				}
			}
			return null;
		}

		// Token: 0x0600A227 RID: 41511 RVA: 0x001B9652 File Offset: 0x001B7852
		public void RefreshYYMallRedPoint()
		{
			this.RegisterRedPoint(XSysDefine.XSys_Welfare_YyMall, false, true);
		}

		// Token: 0x0600A228 RID: 41512 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetBackFlowOpenSystem(List<uint> openIds, List<uint> closedIds)
		{
		}

		// Token: 0x0600A229 RID: 41513 RVA: 0x001B9663 File Offset: 0x001B7863
		public void SetBackFlowModal()
		{
			this._SholdOpenBackFlowTaskModal = true;
		}

		// Token: 0x0600A22A RID: 41514 RVA: 0x001B9670 File Offset: 0x001B7870
		public void CallBackFlowModal()
		{
			bool sholdOpenBackFlowTaskModal = this._SholdOpenBackFlowTaskModal;
			if (sholdOpenBackFlowTaskModal)
			{
				this._SholdOpenBackFlowTaskModal = false;
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("BackFlowTaskGift"), XStringDefineProxy.GetString("PVPActivity_Go"), new ButtonClickEventHandler(this.ShowBackFlowTask), 50);
			}
		}

		// Token: 0x0600A22B RID: 41515 RVA: 0x001B96C0 File Offset: 0x001B78C0
		private bool ShowBackFlowTask(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("BackFlowTaskConfig", true);
			XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc((uint)sequenceList[0, 1]);
			return true;
		}

		// Token: 0x0600A22C RID: 41516 RVA: 0x001B970C File Offset: 0x001B790C
		private void SortArgentDailyData()
		{
			Array.Sort(XWelfareDocument._argentaDaily.Table, this);
		}

		// Token: 0x0600A22D RID: 41517 RVA: 0x001B9720 File Offset: 0x001B7920
		public int Compare(object x, object y)
		{
			ArgentaDaily.RowData rowData = x as ArgentaDaily.RowData;
			ArgentaDaily.RowData rowData2 = x as ArgentaDaily.RowData;
			bool flag = this._curArgentaDailyIDList.Contains(rowData.ID);
			bool flag2 = this._curArgentaDailyIDList.Contains(rowData2.ID);
			bool flag3 = flag && !flag2;
			int result;
			if (flag3)
			{
				result = 1;
			}
			else
			{
				bool flag4 = !flag && flag2;
				if (flag4)
				{
					result = -1;
				}
				else
				{
					result = (int)(rowData.ID - rowData2.ID);
				}
			}
			return result;
		}

		// Token: 0x0600A22E RID: 41518 RVA: 0x001B979C File Offset: 0x001B799C
		private bool OnActivityUpdate(XEventArgs e)
		{
			XActivityTaskUpdatedArgs xactivityTaskUpdatedArgs = e as XActivityTaskUpdatedArgs;
			bool flag = xactivityTaskUpdatedArgs != null;
			if (flag)
			{
				bool flag2 = xactivityTaskUpdatedArgs.xActID == 7U;
				if (flag2)
				{
					bool flag3 = this.View != null && this.View.IsLoaded() && this.View.IsVisible();
					if (flag3)
					{
						this.RefreshData();
					}
					bool bState = this.GetRedPointState(XSysDefine.XSys_Welfare_NiceGirl) || this.GetSpecialGiftRedPoint();
					XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Welfare_NiceGirl, bState);
					this.RefreshRedPoint(XSysDefine.XSys_Welfare_NiceGirl, true);
				}
			}
			return true;
		}

		// Token: 0x0600A22F RID: 41519 RVA: 0x001B9838 File Offset: 0x001B7A38
		public int GetPrivilegeFreeRefreshCount(MemberPrivilege privilege)
		{
			int num = 0;
			PayMemberTable.RowData memberPrivilegeConfig = this.GetMemberPrivilegeConfig(privilege);
			bool flag = memberPrivilegeConfig != null;
			if (flag)
			{
				num += memberPrivilegeConfig.ShopRefresh;
			}
			return num;
		}

		// Token: 0x0600A230 RID: 41520 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600A231 RID: 41521 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x04003A60 RID: 14944
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("WelfareDocument");

		// Token: 0x04003A61 RID: 14945
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003A62 RID: 14946
		private static PayAileenTable _payAileenTable = new PayAileenTable();

		// Token: 0x04003A63 RID: 14947
		private static PayWelfareTable _welfareTable = new PayWelfareTable();

		// Token: 0x04003A64 RID: 14948
		private static PayFirst _payFirst = new PayFirst();

		// Token: 0x04003A65 RID: 14949
		private static RechargeTable _RechargeTable = new RechargeTable();

		// Token: 0x04003A66 RID: 14950
		private static ItemBackTable _rewardBackTable = new ItemBackTable();

		// Token: 0x04003A67 RID: 14951
		private static PayMemberTable _payMemberTable = new PayMemberTable();

		// Token: 0x04003A68 RID: 14952
		private static ArgentaDaily _argentaDaily = new ArgentaDaily();

		// Token: 0x04003A69 RID: 14953
		private static ArgentaTask _argentaTask = new ArgentaTask();

		// Token: 0x04003A6A RID: 14954
		private static Dictionary<int, RechargeTable.RowData> m_RechargeDic = new Dictionary<int, RechargeTable.RowData>();

		// Token: 0x04003A6B RID: 14955
		private static Dictionary<int, PayFirst.RowData> m_PayDic = new Dictionary<int, PayFirst.RowData>();

		// Token: 0x04003A6C RID: 14956
		private static Dictionary<MemberPrivilege, PayMemberTable.RowData> m_payMemberIDDic = new Dictionary<MemberPrivilege, PayMemberTable.RowData>();

		// Token: 0x04003A6D RID: 14957
		private static Dictionary<string, List<PayAileenTable.RowData>> m_AileenTableDic = new Dictionary<string, List<PayAileenTable.RowData>>();

		// Token: 0x04003A6E RID: 14958
		private Dictionary<XSysDefine, bool> _redpointState = new Dictionary<XSysDefine, bool>();

		// Token: 0x04003A6F RID: 14959
		private Dictionary<XSysDefine, bool> m_clickDic = new Dictionary<XSysDefine, bool>();

		// Token: 0x04003A70 RID: 14960
		private Dictionary<int, List<int>> m_growthFundDic = new Dictionary<int, List<int>>();

		// Token: 0x04003A71 RID: 14961
		private Dictionary<MemberPrivilege, bool> m_MemberPrivilege = new Dictionary<MemberPrivilege, bool>();

		// Token: 0x04003A72 RID: 14962
		private List<ItemFindBackInfo2Client> m_FindBackInfo = new List<ItemFindBackInfo2Client>();

		// Token: 0x04003A73 RID: 14963
		private MoneyTreeData m_MoneyTreeData = new MoneyTreeData();

		// Token: 0x04003A74 RID: 14964
		private int m_loginDayCount = 0;

		// Token: 0x04003A75 RID: 14965
		private bool m_hasBuyGrowthFund = false;

		// Token: 0x04003A77 RID: 14967
		private bool m_rechargeFirstGift = false;

		// Token: 0x04003A78 RID: 14968
		private bool m_firstRewardBack = false;

		// Token: 0x04003A79 RID: 14969
		private bool m_firstMoneyTree = false;

		// Token: 0x04003A7A RID: 14970
		private static uint _memberPrivilegeFlag;

		// Token: 0x04003A7B RID: 14971
		private static Dictionary<uint, string> _payMemberIcon = new Dictionary<uint, string>();

		// Token: 0x04003A7E RID: 14974
		private List<PayCard> _payCardInfo;

		// Token: 0x04003A7F RID: 14975
		private uint _payCardRemainTime;

		// Token: 0x04003A80 RID: 14976
		private PayAileen _payGiftBagInfo;

		// Token: 0x04003A81 RID: 14977
		private uint _LittleGiftBag = 1U;

		// Token: 0x04003A82 RID: 14978
		private PayMemberPrivilege _payMemberPrivilege;

		// Token: 0x04003A83 RID: 14979
		private List<PayMember> _payMemberInfo;

		// Token: 0x04003A84 RID: 14980
		private uint _vipLevel;

		// Token: 0x04003A85 RID: 14981
		public static readonly string MEMBER_PRIVILEGE_ATLAS = "common/Universal";

		// Token: 0x04003A86 RID: 14982
		private List<uint> _curArgentaDailyIDList = new List<uint>();

		// Token: 0x04003A87 RID: 14983
		public uint ActivityLeftTime = 0U;

		// Token: 0x04003A88 RID: 14984
		public bool ArgentaMainInterfaceState = false;

		// Token: 0x04003A89 RID: 14985
		public bool q = false;

		// Token: 0x04003A8A RID: 14986
		private uint _rewardsLevel;

		// Token: 0x04003A8B RID: 14987
		private bool _SholdOpenBackFlowTaskModal = false;
	}
}
