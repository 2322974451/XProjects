using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPartnerDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XPartnerDocument.uuID;
			}
		}

		public static XPartnerDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XPartnerDocument.uuID) as XPartnerDocument;
			}
		}

		public static PartnerTable PartnerTab
		{
			get
			{
				return XPartnerDocument.m_partnerTab;
			}
		}

		public static PartnerLivenessTable PartnerLivenessTab
		{
			get
			{
				return XPartnerDocument.m_partnerLivenessTab;
			}
		}

		public static PartnerWelfare PartnerWelfareTab
		{
			get
			{
				return XPartnerDocument.m_partnerWelfareTab;
			}
		}

		public ulong PartnerID
		{
			get
			{
				return this.m_partnerID;
			}
		}

		public uint Degree
		{
			get
			{
				return this.m_degree;
			}
		}

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

		public uint LastLeaveTime
		{
			get
			{
				return this.m_lastLeaveTime;
			}
		}

		public Dictionary<ulong, Partner> PartnerDic
		{
			get
			{
				return this.m_partnerDic;
			}
		}

		public ulong RoleId
		{
			get
			{
				return XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			}
		}

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

		public bool IsHadRedDot
		{
			get
			{
				bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Partner);
				return !flag && (this.IsHadShopRedPoint | this.IsHadLivenessRedPoint);
			}
		}

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

		public bool IsOPen()
		{
			return false;
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XPartnerDocument.AsyncLoader.AddTask("Table/Partner", XPartnerDocument.m_partnerTab, false);
			XPartnerDocument.AsyncLoader.AddTask("Table/PartnerLiveness", XPartnerDocument.m_partnerLivenessTab, false);
			XPartnerDocument.AsyncLoader.AddTask("Table/PartnerWelfare", XPartnerDocument.m_partnerWelfareTab, false);
			XPartnerDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		public static void OnTableLoaded()
		{
			XPartnerDocument.PartnerLivenessData = new PartnerLiveness(XPartnerDocument.m_partnerLivenessTab);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public PartnerTable.RowData GetPartnerRow(uint Partnerlevel)
		{
			return XPartnerDocument.m_partnerTab.GetBylevel(Partnerlevel);
		}

		public Partner GetMyParnerInfo()
		{
			Partner result = null;
			this.PartnerDic.TryGetValue(this.RoleId, out result);
			return result;
		}

		public List<partnerShopRecord> ShopRecordList
		{
			get
			{
				return this.m_shopRecordList;
			}
		}

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

		public void ReqPartnerInfo()
		{
			RpcC2M_GetPartnerInfo rpc = new RpcC2M_GetPartnerInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqPartnerDetailInfo()
		{
			RpcC2M_GetPartnerDetailInfo rpc = new RpcC2M_GetPartnerDetailInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqLeavePartner()
		{
			RpcC2M_LeavePartner rpc = new RpcC2M_LeavePartner();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqCancleLeavePartner()
		{
			RpcC2M_CancelLeavePartner rpc = new RpcC2M_CancelLeavePartner();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqShopRecords()
		{
			RpcC2M_GetPartnerShopRecord rpc = new RpcC2M_GetPartnerShopRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XPartnerDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static PartnerTable m_partnerTab = new PartnerTable();

		private static PartnerLivenessTable m_partnerLivenessTab = new PartnerLivenessTable();

		private static PartnerWelfare m_partnerWelfareTab = new PartnerWelfare();

		public static readonly int MaxAvata = 4;

		public PartnerMainHandler View;

		public PartnerShopRecordsHandler ShopRecordsHandler;

		private ulong m_partnerID = 0UL;

		private uint m_degree = 0U;

		private uint m_curPartnerLevel = 0U;

		private uint m_lastLeaveTime = 0U;

		private Dictionary<ulong, Partner> m_partnerDic = new Dictionary<ulong, Partner>();

		private bool m_bIsHadLivenessRedPoint = false;

		private bool m_bIsHadShopRedPoint = false;

		public static PartnerLiveness PartnerLivenessData = null;

		private List<partnerShopRecord> m_shopRecordList = new List<partnerShopRecord>();
	}
}
