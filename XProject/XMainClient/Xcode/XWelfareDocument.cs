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

	internal class XWelfareDocument : XDocComponent, IComparer
	{

		public override uint ID
		{
			get
			{
				return XWelfareDocument.uuID;
			}
		}

		public static XWelfareDocument Doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			}
		}

		public XWelfareView View { get; set; }

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

		public bool ServerPushRewardBack { get; set; }

		public bool ServerPushMoneyTree { get; set; }

		public MoneyTreeData WelfareMoneyTreeData
		{
			get
			{
				return this.m_MoneyTreeData;
			}
		}

		public List<PayCard> PayCardInfo
		{
			get
			{
				return this._payCardInfo;
			}
		}

		public List<ItemFindBackInfo2Client> FindBackInfo
		{
			get
			{
				return this.m_FindBackInfo;
			}
		}

		public uint PayCardRemainTime
		{
			get
			{
				return this._payCardRemainTime;
			}
		}

		public PayAileen PayGiftBagInfo
		{
			get
			{
				return this._payGiftBagInfo;
			}
		}

		public uint RewardLittleGiftBag
		{
			get
			{
				return this._LittleGiftBag;
			}
		}

		public PayMemberPrivilege PayMemberPrivilege
		{
			get
			{
				return this._payMemberPrivilege;
			}
		}

		public List<PayMember> PayMemeberInfo
		{
			get
			{
				return this._payMemberInfo;
			}
		}

		public uint VipLevel
		{
			get
			{
				return this._vipLevel;
			}
		}

		public static PayAileenTable AileenTable
		{
			get
			{
				return XWelfareDocument._payAileenTable;
			}
		}

		public static PayWelfareTable WelfareTable
		{
			get
			{
				return XWelfareDocument._welfareTable;
			}
		}

		public static PayMemberTable PayMemberTable
		{
			get
			{
				return XWelfareDocument._payMemberTable;
			}
		}

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

		public bool GetRedPointState(XSysDefine define)
		{
			return this._redpointState.ContainsKey(define) && this._redpointState[define];
		}

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

		public bool GetFirstClick(XSysDefine define)
		{
			return !this.m_clickDic.ContainsKey(define) || this.m_clickDic[define];
		}

		public void RefreshRedPoint(XSysDefine define, bool refresh = true)
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(define, true);
			bool flag = refresh && this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshRedpoint();
			}
		}

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

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ActivityTaskUpdate, new XComponent.XEventHandler(this.OnActivityUpdate));
		}

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

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._redpointState.Clear();
			this.ServerPushRewardBack = false;
			this.ServerPushMoneyTree = false;
			this.ArgentaMainInterfaceState = true;
		}

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

		public void ReqPayAllInfo()
		{
			XSingleton<XDebug>.singleton.AddLog("Pay [ReqPayAllInfo]", null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2G_GetPayAllInfo rpc = new RpcC2G_GetPayAllInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void OnGetPayMemberPrivilege(PayMemberPrivilege data)
		{
			this._payMemberPrivilege = data;
		}

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

		public bool IsOwnMemberPrivilege(MemberPrivilege type)
		{
			bool flag2;
			bool flag = this.m_MemberPrivilege.TryGetValue(type, out flag2);
			return flag && flag2;
		}

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

		public bool GetTabRedpointState(XSysDefine type)
		{
			return this.GetRedPoint(type);
		}

		private void RefreshData()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshData();
			}
		}

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

		public void GetCardDailyDiamond(uint type)
		{
			RpcC2G_PayCardAward rpcC2G_PayCardAward = new RpcC2G_PayCardAward();
			rpcC2G_PayCardAward.oArg.type = (int)type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PayCardAward);
		}

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

		public void GetLittleGiftBag()
		{
			RpcC2G_GetPayReward rpc = new RpcC2G_GetPayReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public int LoginDayCount
		{
			get
			{
				return this.m_loginDayCount;
			}
		}

		public bool TryGetGrowthFundConf(XSysDefine define, out RechargeTable.RowData rowData)
		{
			return XWelfareDocument.m_RechargeDic.TryGetValue(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(define), out rowData);
		}

		public bool HasBuyGrowthFund
		{
			get
			{
				return this.m_hasBuyGrowthFund;
			}
		}

		public bool HasGrowthFundGet(int type, int value)
		{
			return this.m_growthFundDic.ContainsKey(type) && this.m_growthFundDic[type].Contains(value);
		}

		public void GetGrowthFundAward(int type, int value)
		{
			RpcC2G_GrowthFundAward rpcC2G_GrowthFundAward = new RpcC2G_GrowthFundAward();
			rpcC2G_GrowthFundAward.oArg.type = type;
			rpcC2G_GrowthFundAward.oArg.value = value;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GrowthFundAward);
		}

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

		public bool HasGetFirstRecharge
		{
			get
			{
				return this.m_rechargeFirstGift;
			}
		}

		public List<uint> CurArgentaDailyIDList
		{
			get
			{
				return this._curArgentaDailyIDList;
			}
		}

		public bool TryGetPayFirstData(XSysDefine define, out PayFirst.RowData rowData)
		{
			int key = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(define);
			return XWelfareDocument.m_PayDic.TryGetValue(key, out rowData);
		}

		public void GetPayFirstAward()
		{
			RpcC2G_PayFirstAward rpc = new RpcC2G_PayFirstAward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public bool GetCanRechargeFirst()
		{
			return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Welfare_FirstRechange) && !this.m_rechargeFirstGift && this.HasFullFirstRecharge();
		}

		private void CalculateRechargetFirstRedPoint(bool refresh = true)
		{
			bool canRechargeFirst = this.GetCanRechargeFirst();
			this.RegisterRedPoint(XSysDefine.XSys_Welfare_FirstRechange, this.GetCanRechargeFirst(), refresh);
		}

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

		private void CalculateRewardBackRedPoint()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshRedpoint();
				this.RegisterRedPoint(XSysDefine.XSyS_Welfare_RewardBack, this.View.HadRewardBackRedPoint(), true);
			}
		}

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

		public void ReqMoneyTreeInfo()
		{
			RpcC2G_GoldClick rpcC2G_GoldClick = new RpcC2G_GoldClick();
			rpcC2G_GoldClick.oArg.type = 0U;
			rpcC2G_GoldClick.oArg.count = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GoldClick);
		}

		public void OnRefreshRewardBack()
		{
			bool flag = this.View != null && this.View.IsLoaded() && this.View.IsVisible();
			if (flag)
			{
				this.RefreshData();
			}
		}

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

		public void ReqRewardFindBack(ItemFindBackType type, int count)
		{
			RpcC2G_ItemFindBack rpcC2G_ItemFindBack = new RpcC2G_ItemFindBack();
			rpcC2G_ItemFindBack.oArg.id = type;
			rpcC2G_ItemFindBack.oArg.findBackCount = count;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ItemFindBack);
		}

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

		public int GetArgentDailyDataCount()
		{
			return XWelfareDocument._argentaDaily.Table.Length;
		}

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

		public void SendArgentaActivityInfo(uint type, uint taskid)
		{
			RpcC2G_ArgentaActivity rpcC2G_ArgentaActivity = new RpcC2G_ArgentaActivity();
			rpcC2G_ArgentaActivity.oArg.type = type;
			rpcC2G_ArgentaActivity.oArg.id = taskid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ArgentaActivity);
		}

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

		public bool IsNiceGirlTasksFinished()
		{
			return this.IsAllSpecialGiftTaskFinished() && !this.GetDailyGiftRedPoint();
		}

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

		public bool GetDailyGiftRedPoint()
		{
			return this.GetRedPointState(XSysDefine.XSys_Welfare_NiceGirl);
		}

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

		public void RefreshYYMallRedPoint()
		{
			this.RegisterRedPoint(XSysDefine.XSys_Welfare_YyMall, false, true);
		}

		public void SetBackFlowOpenSystem(List<uint> openIds, List<uint> closedIds)
		{
		}

		public void SetBackFlowModal()
		{
			this._SholdOpenBackFlowTaskModal = true;
		}

		public void CallBackFlowModal()
		{
			bool sholdOpenBackFlowTaskModal = this._SholdOpenBackFlowTaskModal;
			if (sholdOpenBackFlowTaskModal)
			{
				this._SholdOpenBackFlowTaskModal = false;
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("BackFlowTaskGift"), XStringDefineProxy.GetString("PVPActivity_Go"), new ButtonClickEventHandler(this.ShowBackFlowTask), 50);
			}
		}

		private bool ShowBackFlowTask(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("BackFlowTaskConfig", true);
			XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc((uint)sequenceList[0, 1]);
			return true;
		}

		private void SortArgentDailyData()
		{
			Array.Sort(XWelfareDocument._argentaDaily.Table, this);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("WelfareDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static PayAileenTable _payAileenTable = new PayAileenTable();

		private static PayWelfareTable _welfareTable = new PayWelfareTable();

		private static PayFirst _payFirst = new PayFirst();

		private static RechargeTable _RechargeTable = new RechargeTable();

		private static ItemBackTable _rewardBackTable = new ItemBackTable();

		private static PayMemberTable _payMemberTable = new PayMemberTable();

		private static ArgentaDaily _argentaDaily = new ArgentaDaily();

		private static ArgentaTask _argentaTask = new ArgentaTask();

		private static Dictionary<int, RechargeTable.RowData> m_RechargeDic = new Dictionary<int, RechargeTable.RowData>();

		private static Dictionary<int, PayFirst.RowData> m_PayDic = new Dictionary<int, PayFirst.RowData>();

		private static Dictionary<MemberPrivilege, PayMemberTable.RowData> m_payMemberIDDic = new Dictionary<MemberPrivilege, PayMemberTable.RowData>();

		private static Dictionary<string, List<PayAileenTable.RowData>> m_AileenTableDic = new Dictionary<string, List<PayAileenTable.RowData>>();

		private Dictionary<XSysDefine, bool> _redpointState = new Dictionary<XSysDefine, bool>();

		private Dictionary<XSysDefine, bool> m_clickDic = new Dictionary<XSysDefine, bool>();

		private Dictionary<int, List<int>> m_growthFundDic = new Dictionary<int, List<int>>();

		private Dictionary<MemberPrivilege, bool> m_MemberPrivilege = new Dictionary<MemberPrivilege, bool>();

		private List<ItemFindBackInfo2Client> m_FindBackInfo = new List<ItemFindBackInfo2Client>();

		private MoneyTreeData m_MoneyTreeData = new MoneyTreeData();

		private int m_loginDayCount = 0;

		private bool m_hasBuyGrowthFund = false;

		private bool m_rechargeFirstGift = false;

		private bool m_firstRewardBack = false;

		private bool m_firstMoneyTree = false;

		private static uint _memberPrivilegeFlag;

		private static Dictionary<uint, string> _payMemberIcon = new Dictionary<uint, string>();

		private List<PayCard> _payCardInfo;

		private uint _payCardRemainTime;

		private PayAileen _payGiftBagInfo;

		private uint _LittleGiftBag = 1U;

		private PayMemberPrivilege _payMemberPrivilege;

		private List<PayMember> _payMemberInfo;

		private uint _vipLevel;

		public static readonly string MEMBER_PRIVILEGE_ATLAS = "common/Universal";

		private List<uint> _curArgentaDailyIDList = new List<uint>();

		public uint ActivityLeftTime = 0U;

		public bool ArgentaMainInterfaceState = false;

		public bool q = false;

		private uint _rewardsLevel;

		private bool _SholdOpenBackFlowTaskModal = false;
	}
}
