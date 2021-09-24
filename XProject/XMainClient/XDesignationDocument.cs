using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDesignationDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDesignationDocument.uuID;
			}
		}

		public DesignationTable _DesignationTable
		{
			get
			{
				return XDesignationDocument._designationTable;
			}
		}

		public List<List<DesignationInfo>> DesList
		{
			get
			{
				return this._desList;
			}
		}

		public string SpecialDesignation
		{
			get
			{
				return this._specialDesignation;
			}
		}

		public uint CoverDesignationID
		{
			get
			{
				return this._coverDesignationID;
			}
		}

		public uint AbilityDesignationID
		{
			get
			{
				return this._abilityDesignationID;
			}
		}

		public bool RedPoint
		{
			get
			{
				return this._redPoint;
			}
			set
			{
				this._redPoint = value;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XDesignationDocument.AsyncLoader.AddTask("Table/Designation", XDesignationDocument._designationTable, false);
			XDesignationDocument.AsyncLoader.AddTask("Table/Achievement", XDesignationDocument.achieveTable, false);
			XDesignationDocument.AsyncLoader.AddTask("Table/AchievementPointReward", XDesignationDocument.achieveRwdTable, false);
			XDesignationDocument.AsyncLoader.Execute(callback);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public string GetMyCoverDesignation()
		{
			DesignationTable.RowData byID = XDesignationDocument._designationTable.GetByID((int)this._coverDesignationID);
			bool flag = byID == null;
			string result;
			if (flag)
			{
				result = XStringDefineProxy.GetString("NONE");
			}
			else
			{
				bool flag2 = byID.Effect == "";
				if (flag2)
				{
					bool special = byID.Special;
					if (special)
					{
						result = byID.Color + this._specialDesignation;
					}
					else
					{
						result = byID.Color + byID.Designation;
					}
				}
				else
				{
					result = XLabelSymbolHelper.FormatAnimation(byID.Atlas, byID.Effect, XDesignationDocument.DESIGNATION_FRAME_RATE);
				}
			}
			return result;
		}

		private int Compare(DesignationInfo x, DesignationInfo y)
		{
			bool flag = x.ID == y.ID;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = x.isNew != y.isNew;
				if (flag2)
				{
					result = (y.isNew ? 1 : -1);
				}
				else
				{
					bool flag3 = x.completed != y.completed;
					if (flag3)
					{
						result = (y.completed ? 1 : -1);
					}
					else
					{
						result = x.sortID - y.sortID;
					}
				}
			}
			return result;
		}

		public void UpdateRedPoints()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Design, true);
		}

		public void SendQueryDesignationInfo()
		{
			RpcC2G_GetDesignationReq rpc = new RpcC2G_GetDesignationReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void SendQuerySetDesignation(uint type, uint ID)
		{
			RpcC2G_SetDesignationReq rpcC2G_SetDesignationReq = new RpcC2G_SetDesignationReq();
			rpcC2G_SetDesignationReq.oArg.type = type;
			rpcC2G_SetDesignationReq.oArg.designationID = ID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SetDesignationReq);
		}

		public void SendQueryDesignationList(uint type)
		{
			RpcC2G_GetClassifyDesignationReq rpcC2G_GetClassifyDesignationReq = new RpcC2G_GetClassifyDesignationReq();
			rpcC2G_GetClassifyDesignationReq.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetClassifyDesignationReq);
		}

		public void SetTabRedPoint(List<bool> list)
		{
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler.SetTabRedPoint(list);
			}
		}

		public void DealWithAppearRedPoint(uint abilityDesID, List<bool> list)
		{
			bool flag = this.IsMaxAbilityDes && this.GetPPTOfAbilityDes(abilityDesID) != this.MaxAbilityDesNum;
			if (flag)
			{
				this.SetTabRedPoint(list);
			}
		}

		public void SendQueryGetAchiPointReward(uint ID)
		{
			bool flag = ID != this._lastSurveyID;
			if (flag)
			{
				RpcC2G_GetAchievePointRewardReq rpcC2G_GetAchievePointRewardReq = new RpcC2G_GetAchievePointRewardReq();
				rpcC2G_GetAchievePointRewardReq.oArg.rewardId = ID;
				this._lastSurveyID = ID;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetAchievePointRewardReq);
			}
		}

		public void SetDesignationListData(List<StcDesignationInfo> list, int type)
		{
			this.GetSignTime = this.GetNowTime();
			this.hash.Clear();
			this._desList[type].Clear();
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			for (int i = 0; i < list.Count; i++)
			{
				this.hash.Add((int)list[i].designationID);
				DesignationTable.RowData byID = XDesignationDocument._designationTable.GetByID((int)list[i].designationID);
				bool flag = byID == null || (ulong)level < (ulong)((long)byID.Level[0]) || (ulong)level > (ulong)((long)byID.Level[1]) || !this.CheckChannelShow(byID);
				if (!flag)
				{
					DesignationInfo designationInfo = new DesignationInfo();
					designationInfo.isNew = list[i].isNew;
					designationInfo.ID = byID.ID;
					designationInfo.desName = byID.Designation;
					designationInfo.explanation = byID.Explanation;
					designationInfo.attribute = byID.Attribute;
					designationInfo.color = byID.Color;
					designationInfo.completed = true;
					designationInfo.effect = byID.Effect;
					designationInfo.atlas = byID.Atlas;
					designationInfo.sortID = byID.SortID;
					bool flag2 = byID.Pragmaticality != 0 && list[i].reachTimestamp > 0U;
					if (flag2)
					{
						designationInfo.leftTime = (int)list[i].reachTimestamp;
					}
					else
					{
						designationInfo.leftTime = -1;
					}
					this._desList[type].Add(designationInfo);
				}
			}
			int j = 0;
			while (j < XDesignationDocument._designationTable.Table.Length)
			{
				bool flag3 = XDesignationDocument._designationTable.Table[j].Type == type + 1;
				if (flag3)
				{
					bool flag4 = !this.hash.Contains(XDesignationDocument._designationTable.Table[j].ID);
					if (flag4)
					{
						DesignationTable.RowData byID2 = XDesignationDocument._designationTable.GetByID(XDesignationDocument._designationTable.Table[j].ID);
						bool flag5 = byID2 == null || (ulong)level < (ulong)((long)byID2.Level[0]) || (ulong)level > (ulong)((long)byID2.Level[1]) || !this.CheckChannelShow(byID2);
						if (!flag5)
						{
							DesignationInfo designationInfo2 = new DesignationInfo();
							designationInfo2.isNew = false;
							designationInfo2.ID = byID2.ID;
							designationInfo2.desName = byID2.Designation;
							designationInfo2.explanation = byID2.Explanation;
							designationInfo2.attribute = byID2.Attribute;
							designationInfo2.color = byID2.Color;
							designationInfo2.completed = false;
							designationInfo2.effect = byID2.Effect;
							designationInfo2.atlas = byID2.Atlas;
							designationInfo2.sortID = byID2.SortID;
							designationInfo2.leftTime = -1;
							this._desList[type].Add(designationInfo2);
						}
					}
				}
				IL_2ED:
				j++;
				continue;
				goto IL_2ED;
			}
			this._desList[type].Sort(new Comparison<DesignationInfo>(this.Compare));
			this.hash.Clear();
			bool flag6 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler.IsVisible();
			if (flag6)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler.SetDesignationList(this._desList[type], type, true);
			}
		}

		private bool CheckChannelShow(DesignationTable.RowData data)
		{
			bool flag = data.Channel == 0;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = data.Channel == 1;
				if (flag2)
				{
					result = (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
				}
				else
				{
					bool flag3 = data.Channel == 2;
					if (flag3)
					{
						result = (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("designation channel error! check config on designation table. ID = ", data.ID.ToString(), null, null, null, null);
						result = true;
					}
				}
			}
			return result;
		}

		public uint GetPPTOfAbilityDes(uint ID)
		{
			DesignationTable.RowData byID = XDesignationDocument._designationTable.GetByID((int)ID);
			bool flag = ID == 0U || byID == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				double num = 0.0;
				for (int i = 0; i < byID.Attribute.Count; i++)
				{
					num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(byID.Attribute[i, 0], byID.Attribute[i, 1], null, -1);
				}
				result = (uint)num;
			}
			return result;
		}

		public void SetCoverDesignationID(uint ID, string specialDesi)
		{
			this._specialDesignation = specialDesi;
			this._coverDesignationID = ID;
			XDesignationInfoChange @event = XEventPool<XDesignationInfoChange>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		public void SetDesignationInfo(uint type, uint ID, string specialDesi)
		{
			bool flag = type == 1U;
			if (flag)
			{
				this.SetCoverDesignationID(ID, specialDesi);
			}
			else
			{
				this._abilityDesignationID = ID;
				bool flag2 = this.GetPPTOfAbilityDes(this._abilityDesignationID) == this.MaxAbilityDesNum;
				if (flag2)
				{
					bool flag3 = !this.IsMaxAbilityDes;
					if (flag3)
					{
						this.IsMaxAbilityDes = true;
						bool flag4 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler.IsVisible();
						if (flag4)
						{
							DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler.HideTabRedPoint();
						}
					}
				}
				else
				{
					bool isMaxAbilityDes = this.IsMaxAbilityDes;
					if (isMaxAbilityDes)
					{
						this.IsMaxAbilityDes = false;
					}
				}
			}
			bool flag5 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler.IsVisible();
			if (flag5)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler.SetCurrentChooseDes(type, ID);
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler.SetDesignationList(this._desList[this.LastDisPlayTab], this.LastDisPlayTab, false);
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._desList.Clear();
			for (int i = 0; i < 6; i++)
			{
				List<DesignationInfo> item = new List<DesignationInfo>();
				this._desList.Add(item);
			}
		}

		private int Sort(AchieveItemInfo x, AchieveItemInfo y)
		{
			bool flag = x.state != y.state;
			int result;
			if (flag)
			{
				result = x.state - y.state;
			}
			else
			{
				bool flag2 = x.row.SortID != y.row.SortID;
				if (flag2)
				{
					result = x.row.SortID - y.row.SortID;
				}
				else
				{
					result = x.row.ID - y.row.ID;
				}
			}
			return result;
		}

		public void FetchAchieveSurvey()
		{
			RpcC2G_GetAchieveBrifInfoReq rpc = new RpcC2G_GetAchieveBrifInfoReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnResAchieveSurvey(GetAchieveBrifInfoRes oRes)
		{
			this.achieveSurveyInfo = oRes;
			bool flag = this.achieveView != null && this.achieveView.IsVisible();
			if (flag)
			{
				this.achieveView.RefreshSurvey();
			}
			else
			{
				bool flag2 = DlgBase<XOptionsView, XOptionsBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetAchievementLabel();
				}
			}
		}

		public void GetPPT(out string text, out uint value, SeqListRef<uint> list, bool hasLineBreak = false)
		{
			text = "";
			double num = 0.0;
			for (int i = 0; i < list.Count; i++)
			{
				num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(list[i, 0], list[i, 1], null, -1);
				text += XStringDefineProxy.GetString((XAttributeDefine)list[i, 0]);
				text = text + "+" + list[i, 1].ToString();
				text += "   ";
				bool flag = hasLineBreak && i == 1 && i + 1 < list.Count;
				if (flag)
				{
					text += "\n";
				}
			}
			value = (uint)num;
		}

		public void FetchAchieveType(AchieveType type)
		{
			RpcC2G_GetAchieveClassifyInfoReq rpcC2G_GetAchieveClassifyInfoReq = new RpcC2G_GetAchieveClassifyInfoReq();
			rpcC2G_GetAchieveClassifyInfoReq.oArg.type = (uint)type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetAchieveClassifyInfoReq);
		}

		public void OnResAchieveType(GetAchieveClassifyInfoRes oRes)
		{
			this.achievesDetails.Clear();
			bool flag = this.achieveView != null && this.achieveView.IsVisible();
			if (flag)
			{
				foreach (StcAchieveInfo stcAchieveInfo in oRes.dataList)
				{
					AchieveItemInfo achieveItemInfo = new AchieveItemInfo();
					achieveItemInfo.row = this.FindAchieve(stcAchieveInfo);
					bool flag2 = stcAchieveInfo.rewardStatus == 0U;
					if (flag2)
					{
						achieveItemInfo.state = AchieveState.Normal;
					}
					else
					{
						bool flag3 = stcAchieveInfo.rewardStatus == 1U;
						if (flag3)
						{
							achieveItemInfo.state = AchieveState.Claim;
						}
						else
						{
							achieveItemInfo.state = AchieveState.Claimed;
						}
					}
					this.achievesDetails.Add(achieveItemInfo);
				}
				foreach (AchievementV2Table.RowData rowData in XDesignationDocument.achieveTable.Table)
				{
					bool flag4 = !this.FindAchieve(rowData);
					if (flag4)
					{
						bool flag5 = rowData.Type == (int)this.achieveView.m_achieveType;
						if (flag5)
						{
							AchieveItemInfo achieveItemInfo2 = new AchieveItemInfo();
							achieveItemInfo2.row = rowData;
							achieveItemInfo2.state = AchieveState.Normal;
							this.achievesDetails.Add(achieveItemInfo2);
						}
					}
				}
				this.achievesDetails.Sort(new Comparison<AchieveItemInfo>(this.Sort));
				this.achieveView.RefreshDetails();
			}
		}

		public bool FindAchieve(AchievementV2Table.RowData row)
		{
			foreach (AchieveItemInfo achieveItemInfo in this.achievesDetails)
			{
				bool flag = achieveItemInfo.row.ID == row.ID;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public AchievementV2Table.RowData FindAchieve(StcAchieveInfo info)
		{
			foreach (AchievementV2Table.RowData rowData in XDesignationDocument.achieveTable.Table)
			{
				bool flag = (long)rowData.ID == (long)((ulong)info.achieveID);
				if (flag)
				{
					return rowData;
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("not find info in achievement table id: ", info.achieveID.ToString(), null, null, null, null);
			return null;
		}

		public void OnReachAhieveNtf(PtcG2C_ReachAchieveNtf res)
		{
			uint achieveID = res.Data.achieveID;
			foreach (AchievementV2Table.RowData rowData in XDesignationDocument.achieveTable.Table)
			{
				bool flag = (long)rowData.ID == (long)((ulong)achieveID);
				if (flag)
				{
					DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.Show(rowData);
				}
			}
		}

		public void OnReachDesignationNtf(PtcG2C_ReachDesignationNtf res)
		{
			DesignationTable.RowData byID = XDesignationDocument._designationTable.GetByID((int)res.Data.designationID);
			DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.ShowDesignation(byID);
		}

		public void ClaimAchieve(int id)
		{
			XSingleton<XDebug>.singleton.AddLog("ClaimAchieve ", id.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			RpcC2G_GetAchieveRewardReq rpcC2G_GetAchieveRewardReq = new RpcC2G_GetAchieveRewardReq();
			rpcC2G_GetAchieveRewardReq.oArg.achieveID = (uint)id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetAchieveRewardReq);
		}

		public void OnClaimedAchieve(uint id)
		{
			bool flag = this.achievesDetails != null && this.achieveView != null && this.achieveSurveyInfo != null;
			if (flag)
			{
				for (int i = 0; i < this.achievesDetails.Count; i++)
				{
					bool flag2 = this.achievesDetails[i].row.ID == (int)id;
					if (flag2)
					{
						this.achievesDetails[i].state = AchieveState.Claimed;
						break;
					}
				}
				foreach (AchievementV2Table.RowData rowData in XDesignationDocument.achieveTable.Table)
				{
					bool flag3 = (long)rowData.ID == (long)((ulong)id);
					if (flag3)
					{
						foreach (AchieveBriefInfo achieveBriefInfo in this.achieveSurveyInfo.dataList)
						{
							bool flag4 = (ulong)achieveBriefInfo.achieveClassifyType == (ulong)((long)rowData.Type);
							if (flag4)
							{
								AchieveBriefInfo achieveBriefInfo2 = achieveBriefInfo;
								uint canRewardCount = achieveBriefInfo2.canRewardCount;
								achieveBriefInfo2.canRewardCount = canRewardCount - 1U;
								this.achieveView.RefreshPoints();
								bool flag5 = achieveBriefInfo.canRewardCount <= 0U;
								if (flag5)
								{
									this.FetchAchieveSurvey();
								}
								break;
							}
						}
						break;
					}
				}
				this.achievesDetails.Sort(new Comparison<AchieveItemInfo>(this.Sort));
				this.achieveView.RefreshDetails();
			}
		}

		public double GetNowTime()
		{
			return (double)(DateTime.Now.Ticks / 10000000L);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DesignationDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public List<AchieveItemInfo> achievesDetails = new List<AchieveItemInfo>();

		public XAchieveView achieveView;

		public GetAchieveBrifInfoRes achieveSurveyInfo;

		private static DesignationTable _designationTable = new DesignationTable();

		public static AchievementV2Table achieveTable = new AchievementV2Table();

		public static AchievementPointRewardTable achieveRwdTable = new AchievementPointRewardTable();

		private List<List<DesignationInfo>> _desList = new List<List<DesignationInfo>>();

		private HashSet<int> hash = new HashSet<int>();

		private static readonly int DESIGNATION_FRAME_RATE = 16;

		private string _specialDesignation;

		private uint _coverDesignationID;

		private uint _abilityDesignationID;

		public bool IsMaxAbilityDes;

		public int LastDisPlayTab = 0;

		public uint MaxAbilityDesNum;

		private bool _redPoint = false;

		private uint _lastSurveyID = 0U;

		public double GetSignTime;
	}
}
