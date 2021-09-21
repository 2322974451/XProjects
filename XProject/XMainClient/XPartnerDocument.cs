using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C65 RID: 3173
	internal class XPartnerDocument : XDocComponent
	{
		// Token: 0x170031BC RID: 12732
		// (get) Token: 0x0600B396 RID: 45974 RVA: 0x0022F880 File Offset: 0x0022DA80
		public override uint ID
		{
			get
			{
				return XPartnerDocument.uuID;
			}
		}

		// Token: 0x170031BD RID: 12733
		// (get) Token: 0x0600B397 RID: 45975 RVA: 0x0022F898 File Offset: 0x0022DA98
		public static XPartnerDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XPartnerDocument.uuID) as XPartnerDocument;
			}
		}

		// Token: 0x170031BE RID: 12734
		// (get) Token: 0x0600B398 RID: 45976 RVA: 0x0022F8C4 File Offset: 0x0022DAC4
		public static PartnerTable PartnerTab
		{
			get
			{
				return XPartnerDocument.m_partnerTab;
			}
		}

		// Token: 0x170031BF RID: 12735
		// (get) Token: 0x0600B399 RID: 45977 RVA: 0x0022F8DC File Offset: 0x0022DADC
		public static PartnerLivenessTable PartnerLivenessTab
		{
			get
			{
				return XPartnerDocument.m_partnerLivenessTab;
			}
		}

		// Token: 0x170031C0 RID: 12736
		// (get) Token: 0x0600B39A RID: 45978 RVA: 0x0022F8F4 File Offset: 0x0022DAF4
		public static PartnerWelfare PartnerWelfareTab
		{
			get
			{
				return XPartnerDocument.m_partnerWelfareTab;
			}
		}

		// Token: 0x170031C1 RID: 12737
		// (get) Token: 0x0600B39B RID: 45979 RVA: 0x0022F90C File Offset: 0x0022DB0C
		public ulong PartnerID
		{
			get
			{
				return this.m_partnerID;
			}
		}

		// Token: 0x170031C2 RID: 12738
		// (get) Token: 0x0600B39C RID: 45980 RVA: 0x0022F924 File Offset: 0x0022DB24
		public uint Degree
		{
			get
			{
				return this.m_degree;
			}
		}

		// Token: 0x170031C3 RID: 12739
		// (get) Token: 0x0600B39D RID: 45981 RVA: 0x0022F93C File Offset: 0x0022DB3C
		// (set) Token: 0x0600B39E RID: 45982 RVA: 0x0022F954 File Offset: 0x0022DB54
		public uint CurPartnerLevel
		{
			get
			{
				return this.m_curPartnerLevel;
			}
			set
			{
				this.m_curPartnerLevel = value;
			}
		}

		// Token: 0x170031C4 RID: 12740
		// (get) Token: 0x0600B39F RID: 45983 RVA: 0x0022F960 File Offset: 0x0022DB60
		public uint LastLeaveTime
		{
			get
			{
				return this.m_lastLeaveTime;
			}
		}

		// Token: 0x170031C5 RID: 12741
		// (get) Token: 0x0600B3A0 RID: 45984 RVA: 0x0022F978 File Offset: 0x0022DB78
		public Dictionary<ulong, Partner> PartnerDic
		{
			get
			{
				return this.m_partnerDic;
			}
		}

		// Token: 0x170031C6 RID: 12742
		// (get) Token: 0x0600B3A1 RID: 45985 RVA: 0x0022F990 File Offset: 0x0022DB90
		public ulong RoleId
		{
			get
			{
				return XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			}
		}

		// Token: 0x170031C7 RID: 12743
		// (get) Token: 0x0600B3A2 RID: 45986 RVA: 0x0022F9B4 File Offset: 0x0022DBB4
		// (set) Token: 0x0600B3A3 RID: 45987 RVA: 0x0022F9CC File Offset: 0x0022DBCC
		public bool IsHadLivenessRedPoint
		{
			get
			{
				return this.m_bIsHadLivenessRedPoint;
			}
			set
			{
				bool flag = this.m_bIsHadLivenessRedPoint != value;
				if (flag)
				{
					this.m_bIsHadLivenessRedPoint = value;
					DlgBase<XFriendsView, XFriendsBehaviour>.singleton.SetRedPoint(TabIndex.Partner, this.IsHadRedDot);
					bool flag2 = this.View != null && this.View.IsVisible();
					if (flag2)
					{
						this.View.RefreshUIRedPoint();
					}
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Friends, true);
					bool flag3 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<XFriendsView, XFriendsBehaviour>.singleton.UpdateRedpointUI();
					}
				}
			}
		}

		// Token: 0x170031C8 RID: 12744
		// (get) Token: 0x0600B3A4 RID: 45988 RVA: 0x0022FA54 File Offset: 0x0022DC54
		// (set) Token: 0x0600B3A5 RID: 45989 RVA: 0x0022FA6C File Offset: 0x0022DC6C
		public bool IsHadShopRedPoint
		{
			get
			{
				return this.m_bIsHadShopRedPoint;
			}
			set
			{
				bool flag = this.m_bIsHadShopRedPoint != value;
				if (flag)
				{
					this.m_bIsHadShopRedPoint = value;
					DlgBase<XFriendsView, XFriendsBehaviour>.singleton.SetRedPoint(TabIndex.Partner, this.IsHadRedDot);
					bool flag2 = this.View != null && this.View.IsVisible();
					if (flag2)
					{
						this.View.RefreshUIRedPoint();
					}
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Friends, true);
					bool flag3 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<XFriendsView, XFriendsBehaviour>.singleton.UpdateRedpointUI();
					}
				}
			}
		}

		// Token: 0x170031C9 RID: 12745
		// (get) Token: 0x0600B3A6 RID: 45990 RVA: 0x0022FAF4 File Offset: 0x0022DCF4
		public bool IsHadRedDot
		{
			get
			{
				bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Partner);
				return !flag && (this.IsHadShopRedPoint | this.IsHadLivenessRedPoint);
			}
		}

		// Token: 0x170031CA RID: 12746
		// (get) Token: 0x0600B3A7 RID: 45991 RVA: 0x0022FB30 File Offset: 0x0022DD30
		public uint CurLevelMaxExp
		{
			get
			{
				bool flag = this.m_curPartnerLevel == XPartnerDocument.m_partnerTab.Table[XPartnerDocument.m_partnerTab.Table.Length - 1].level;
				uint partnerlevel;
				if (flag)
				{
					partnerlevel = this.m_curPartnerLevel;
				}
				else
				{
					partnerlevel = this.m_curPartnerLevel + 1U;
				}
				PartnerTable.RowData partnerRow = this.GetPartnerRow(partnerlevel);
				bool flag2 = partnerRow == null;
				uint result;
				if (flag2)
				{
					result = 0U;
				}
				else
				{
					result = partnerRow.degree;
				}
				return result;
			}
		}

		// Token: 0x0600B3A8 RID: 45992 RVA: 0x0022FBA0 File Offset: 0x0022DDA0
		public bool IsOPen()
		{
			return false;
		}

		// Token: 0x0600B3A9 RID: 45993 RVA: 0x0022FBB4 File Offset: 0x0022DDB4
		public static void Execute(OnLoadedCallback callback = null)
		{
			XPartnerDocument.AsyncLoader.AddTask("Table/Partner", XPartnerDocument.m_partnerTab, false);
			XPartnerDocument.AsyncLoader.AddTask("Table/PartnerLiveness", XPartnerDocument.m_partnerLivenessTab, false);
			XPartnerDocument.AsyncLoader.AddTask("Table/PartnerWelfare", XPartnerDocument.m_partnerWelfareTab, false);
			XPartnerDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600B3AA RID: 45994 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600B3AB RID: 45995 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600B3AC RID: 45996 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x0600B3AD RID: 45997 RVA: 0x0022FC10 File Offset: 0x0022DE10
		public static void OnTableLoaded()
		{
			XPartnerDocument.PartnerLivenessData = new PartnerLiveness(XPartnerDocument.m_partnerLivenessTab);
		}

		// Token: 0x0600B3AE RID: 45998 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600B3AF RID: 45999 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x0600B3B0 RID: 46000 RVA: 0x0022FC24 File Offset: 0x0022DE24
		public PartnerTable.RowData GetPartnerRow(uint Partnerlevel)
		{
			return XPartnerDocument.m_partnerTab.GetBylevel(Partnerlevel);
		}

		// Token: 0x0600B3B1 RID: 46001 RVA: 0x0022FC44 File Offset: 0x0022DE44
		public Partner GetMyParnerInfo()
		{
			Partner result = null;
			this.PartnerDic.TryGetValue(this.RoleId, out result);
			return result;
		}

		// Token: 0x170031CB RID: 12747
		// (get) Token: 0x0600B3B2 RID: 46002 RVA: 0x0022FC70 File Offset: 0x0022DE70
		public List<partnerShopRecord> ShopRecordList
		{
			get
			{
				return this.m_shopRecordList;
			}
		}

		// Token: 0x0600B3B3 RID: 46003 RVA: 0x0022FC88 File Offset: 0x0022DE88
		public bool IsMyPartner(ulong roleId)
		{
			bool flag = this.m_partnerID == 0UL;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.m_partnerDic.ContainsKey(roleId);
				result = flag2;
			}
			return result;
		}

		// Token: 0x0600B3B4 RID: 46004 RVA: 0x0022FCC4 File Offset: 0x0022DEC4
		public void ReqPartnerInfo()
		{
			RpcC2M_GetPartnerInfo rpc = new RpcC2M_GetPartnerInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B3B5 RID: 46005 RVA: 0x0022FCE4 File Offset: 0x0022DEE4
		public void ReqPartnerDetailInfo()
		{
			RpcC2M_GetPartnerDetailInfo rpc = new RpcC2M_GetPartnerDetailInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B3B6 RID: 46006 RVA: 0x0022FD04 File Offset: 0x0022DF04
		public void ReqLeavePartner()
		{
			RpcC2M_LeavePartner rpc = new RpcC2M_LeavePartner();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B3B7 RID: 46007 RVA: 0x0022FD24 File Offset: 0x0022DF24
		public void ReqCancleLeavePartner()
		{
			RpcC2M_CancelLeavePartner rpc = new RpcC2M_CancelLeavePartner();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B3B8 RID: 46008 RVA: 0x0022FD44 File Offset: 0x0022DF44
		public void ReqShopRecords()
		{
			RpcC2M_GetPartnerShopRecord rpc = new RpcC2M_GetPartnerShopRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B3B9 RID: 46009 RVA: 0x0022FD64 File Offset: 0x0022DF64
		public void OnGetPartnerInfoBack(GetPartnerInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				this.m_partnerDic.Clear();
				this.m_partnerID = oRes.id;
				bool flag2 = oRes.id > 0UL;
				if (flag2)
				{
					this.m_degree = oRes.degree;
					this.m_curPartnerLevel = oRes.level;
					this.m_lastLeaveTime = oRes.last_leave_time;
					this.IsHadLivenessRedPoint = oRes.liveness_redpoint;
					this.IsHadShopRedPoint = oRes.shop_redpoint;
					for (int i = 0; i < oRes.memberids.Count; i++)
					{
						Partner partner = new Partner();
						partner.MemberId = oRes.memberids[i];
						this.m_partnerDic.Add(oRes.memberids[i], partner);
					}
				}
				else
				{
					this.IsHadLivenessRedPoint = false;
					this.IsHadShopRedPoint = false;
				}
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.SetRedPoint(TabIndex.Partner, this.IsHadRedDot);
			}
		}

		// Token: 0x0600B3BA RID: 46010 RVA: 0x0022FE74 File Offset: 0x0022E074
		public void OnGetPartDetailInfoBack(GetPartnerDetailInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
					else
					{
						this.m_partnerDic.Clear();
						bool flag4 = this.m_partnerID > 0UL;
						if (flag4)
						{
							this.m_degree = oRes.degree;
							this.m_curPartnerLevel = oRes.level;
							this.m_bIsHadLivenessRedPoint = oRes.liveness_redpoint;
							this.m_bIsHadShopRedPoint = oRes.shop_redpoint;
							for (int i = 0; i < oRes.members.Count; i++)
							{
								Partner partner = new Partner();
								partner.MemberId = oRes.members[i].memberid;
								partner.SetDetailInfo(oRes.members[i]);
								this.m_partnerDic.Add(oRes.members[i].memberid, partner);
							}
						}
						else
						{
							this.m_bIsHadLivenessRedPoint = false;
							this.m_bIsHadShopRedPoint = false;
						}
						bool flag5 = this.View != null && this.View.IsVisible();
						if (flag5)
						{
							this.View.RefreshUi();
						}
					}
				}
			}
		}

		// Token: 0x0600B3BB RID: 46011 RVA: 0x00230004 File Offset: 0x0022E204
		public void OnLeavePartnerBack(LeavePartnerRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
					else
					{
						Partner partner;
						bool flag4 = this.m_partnerDic.TryGetValue(this.RoleId, out partner);
						if (flag4)
						{
							partner.UpdateLeaveInfo(true, (uint)XSingleton<XGlobalConfig>.singleton.GetInt("PartnerLeaveTime"));
						}
						else
						{
							XSingleton<XDebug>.singleton.AddGreenLog("this error,this data should exist", null, null, null, null, null);
						}
						bool flag5 = this.View != null && this.View.IsVisible();
						if (flag5)
						{
							this.View.RefreshUi();
						}
					}
				}
			}
		}

		// Token: 0x0600B3BC RID: 46012 RVA: 0x00230100 File Offset: 0x0022E300
		public void OnCancleLeavePartnerBack(CancelLeavePartnerRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
					else
					{
						Partner partner;
						bool flag4 = this.m_partnerDic.TryGetValue(this.RoleId, out partner);
						if (flag4)
						{
							partner.UpdateLeaveInfo(false, 0U);
						}
						else
						{
							XSingleton<XDebug>.singleton.AddGreenLog("this error,this data should exist", null, null, null, null, null);
						}
						bool flag5 = this.View != null && this.View.IsVisible();
						if (flag5)
						{
							this.View.RefreshUi();
						}
					}
				}
			}
		}

		// Token: 0x0600B3BD RID: 46013 RVA: 0x002301F0 File Offset: 0x0022E3F0
		public void MakePartnerResult(PtcM2C_MakePartnerResultNtf roPtc)
		{
			bool flag = roPtc.Data.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				bool flag2 = roPtc.Data.result == ErrorCode.ERR_PARTNER_ALREADY_HAS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("TEAM_ERR_PARTNER_ALREADY_HAS"), roPtc.Data.err_rolename), "fece00");
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(roPtc.Data.result, "fece00");
				}
			}
			else
			{
				this.m_partnerID = roPtc.Data.partnerid;
				this.m_curPartnerLevel = roPtc.Data.level;
				this.m_degree = roPtc.Data.degree;
				for (int i = 0; i < roPtc.Data.memberid.Count; i++)
				{
					bool flag3 = this.m_partnerDic.ContainsKey(roPtc.Data.memberid[i]);
					if (flag3)
					{
						Partner partner = new Partner();
						partner.MemberId = roPtc.Data.memberid[i];
						this.m_partnerDic.Add(roPtc.Data.memberid[i], partner);
					}
				}
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GetPartnerSuccess"), "fece00");
				bool flag4 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
				if (flag4)
				{
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.PlayGetPartnerEffect();
				}
			}
		}

		// Token: 0x0600B3BE RID: 46014 RVA: 0x00230370 File Offset: 0x0022E570
		public void UpdatePartnerToClient(PtcM2C_UpdatePartnerToClient roPtc)
		{
			switch (roPtc.Data.type)
			{
			case PartnerUpdateType.PUType_Normal:
			{
				this.m_degree = roPtc.Data.degree;
				this.m_curPartnerLevel = roPtc.Data.level;
				bool flag = this.View != null && this.View.IsVisible();
				if (flag)
				{
					this.View.RefreshUi();
				}
				break;
			}
			case PartnerUpdateType.PUType_Leave:
			{
				bool flag2 = roPtc.Data.leave_id != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					bool flag3 = this.m_partnerDic.ContainsKey(roPtc.Data.leave_id);
					if (flag3)
					{
						this.m_partnerDic.Remove(roPtc.Data.leave_id);
					}
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("HadPartnerLeave"), roPtc.Data.leave_name), "fece00");
				}
				else
				{
					this.m_partnerID = 0UL;
					this.m_partnerDic.Clear();
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("HadLeavedPartner"), roPtc.Data.leave_name), "fece00");
				}
				bool flag4 = this.View != null && this.View.IsVisible();
				if (flag4)
				{
					this.View.RefreshUi();
				}
				break;
			}
			case PartnerUpdateType.PUType_Dissolve:
			{
				this.m_partnerID = 0UL;
				this.m_partnerDic.Clear();
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PartnerEnd"), "fece00");
				bool flag5 = this.View != null && this.View.IsVisible();
				if (flag5)
				{
					this.View.RefreshUi();
				}
				break;
			}
			case PartnerUpdateType.PUType_Shop:
				this.IsHadShopRedPoint = true;
				break;
			}
		}

		// Token: 0x0600B3BF RID: 46015 RVA: 0x0023055C File Offset: 0x0022E75C
		public void OnGetShopRecordBack(GetPartnerShopRecordRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
					else
					{
						this.m_shopRecordList.Clear();
						for (int i = 0; i < oRes.record.Count; i++)
						{
							this.m_shopRecordList.Add(new partnerShopRecord(oRes.record[i]));
						}
						bool flag4 = this.ShopRecordsHandler != null && this.ShopRecordsHandler.IsVisible();
						if (flag4)
						{
							this.ShopRecordsHandler.FillContent();
						}
					}
				}
			}
		}

		// Token: 0x0400459A RID: 17818
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XPartnerDocument");

		// Token: 0x0400459B RID: 17819
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400459C RID: 17820
		private static PartnerTable m_partnerTab = new PartnerTable();

		// Token: 0x0400459D RID: 17821
		private static PartnerLivenessTable m_partnerLivenessTab = new PartnerLivenessTable();

		// Token: 0x0400459E RID: 17822
		private static PartnerWelfare m_partnerWelfareTab = new PartnerWelfare();

		// Token: 0x0400459F RID: 17823
		public static readonly int MaxAvata = 4;

		// Token: 0x040045A0 RID: 17824
		public PartnerMainHandler View;

		// Token: 0x040045A1 RID: 17825
		public PartnerShopRecordsHandler ShopRecordsHandler;

		// Token: 0x040045A2 RID: 17826
		private ulong m_partnerID = 0UL;

		// Token: 0x040045A3 RID: 17827
		private uint m_degree = 0U;

		// Token: 0x040045A4 RID: 17828
		private uint m_curPartnerLevel = 0U;

		// Token: 0x040045A5 RID: 17829
		private uint m_lastLeaveTime = 0U;

		// Token: 0x040045A6 RID: 17830
		private Dictionary<ulong, Partner> m_partnerDic = new Dictionary<ulong, Partner>();

		// Token: 0x040045A7 RID: 17831
		private bool m_bIsHadLivenessRedPoint = false;

		// Token: 0x040045A8 RID: 17832
		private bool m_bIsHadShopRedPoint = false;

		// Token: 0x040045A9 RID: 17833
		public static PartnerLiveness PartnerLivenessData = null;

		// Token: 0x040045AA RID: 17834
		private List<partnerShopRecord> m_shopRecordList = new List<partnerShopRecord>();
	}
}
