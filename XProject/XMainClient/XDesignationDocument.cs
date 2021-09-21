using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000984 RID: 2436
	internal class XDesignationDocument : XDocComponent
	{
		// Token: 0x17002C9B RID: 11419
		// (get) Token: 0x06009269 RID: 37481 RVA: 0x0015226C File Offset: 0x0015046C
		public override uint ID
		{
			get
			{
				return XDesignationDocument.uuID;
			}
		}

		// Token: 0x17002C9C RID: 11420
		// (get) Token: 0x0600926A RID: 37482 RVA: 0x00152284 File Offset: 0x00150484
		public DesignationTable _DesignationTable
		{
			get
			{
				return XDesignationDocument._designationTable;
			}
		}

		// Token: 0x17002C9D RID: 11421
		// (get) Token: 0x0600926B RID: 37483 RVA: 0x0015229C File Offset: 0x0015049C
		public List<List<DesignationInfo>> DesList
		{
			get
			{
				return this._desList;
			}
		}

		// Token: 0x17002C9E RID: 11422
		// (get) Token: 0x0600926C RID: 37484 RVA: 0x001522B4 File Offset: 0x001504B4
		public string SpecialDesignation
		{
			get
			{
				return this._specialDesignation;
			}
		}

		// Token: 0x17002C9F RID: 11423
		// (get) Token: 0x0600926D RID: 37485 RVA: 0x001522CC File Offset: 0x001504CC
		public uint CoverDesignationID
		{
			get
			{
				return this._coverDesignationID;
			}
		}

		// Token: 0x17002CA0 RID: 11424
		// (get) Token: 0x0600926E RID: 37486 RVA: 0x001522E4 File Offset: 0x001504E4
		public uint AbilityDesignationID
		{
			get
			{
				return this._abilityDesignationID;
			}
		}

		// Token: 0x17002CA1 RID: 11425
		// (get) Token: 0x0600926F RID: 37487 RVA: 0x001522FC File Offset: 0x001504FC
		// (set) Token: 0x06009270 RID: 37488 RVA: 0x00152314 File Offset: 0x00150514
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

		// Token: 0x06009271 RID: 37489 RVA: 0x00152320 File Offset: 0x00150520
		public static void Execute(OnLoadedCallback callback = null)
		{
			XDesignationDocument.AsyncLoader.AddTask("Table/Designation", XDesignationDocument._designationTable, false);
			XDesignationDocument.AsyncLoader.AddTask("Table/Achievement", XDesignationDocument.achieveTable, false);
			XDesignationDocument.AsyncLoader.AddTask("Table/AchievementPointReward", XDesignationDocument.achieveRwdTable, false);
			XDesignationDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009272 RID: 37490 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009273 RID: 37491 RVA: 0x0015237C File Offset: 0x0015057C
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

		// Token: 0x06009274 RID: 37492 RVA: 0x00152414 File Offset: 0x00150614
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

		// Token: 0x06009275 RID: 37493 RVA: 0x00152491 File Offset: 0x00150691
		public void UpdateRedPoints()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Design, true);
		}

		// Token: 0x06009276 RID: 37494 RVA: 0x001524A4 File Offset: 0x001506A4
		public void SendQueryDesignationInfo()
		{
			RpcC2G_GetDesignationReq rpc = new RpcC2G_GetDesignationReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009277 RID: 37495 RVA: 0x001524C4 File Offset: 0x001506C4
		public void SendQuerySetDesignation(uint type, uint ID)
		{
			RpcC2G_SetDesignationReq rpcC2G_SetDesignationReq = new RpcC2G_SetDesignationReq();
			rpcC2G_SetDesignationReq.oArg.type = type;
			rpcC2G_SetDesignationReq.oArg.designationID = ID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SetDesignationReq);
		}

		// Token: 0x06009278 RID: 37496 RVA: 0x00152500 File Offset: 0x00150700
		public void SendQueryDesignationList(uint type)
		{
			RpcC2G_GetClassifyDesignationReq rpcC2G_GetClassifyDesignationReq = new RpcC2G_GetClassifyDesignationReq();
			rpcC2G_GetClassifyDesignationReq.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetClassifyDesignationReq);
		}

		// Token: 0x06009279 RID: 37497 RVA: 0x00152530 File Offset: 0x00150730
		public void SetTabRedPoint(List<bool> list)
		{
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._DesignationHandler.SetTabRedPoint(list);
			}
		}

		// Token: 0x0600927A RID: 37498 RVA: 0x00152574 File Offset: 0x00150774
		public void DealWithAppearRedPoint(uint abilityDesID, List<bool> list)
		{
			bool flag = this.IsMaxAbilityDes && this.GetPPTOfAbilityDes(abilityDesID) != this.MaxAbilityDesNum;
			if (flag)
			{
				this.SetTabRedPoint(list);
			}
		}

		// Token: 0x0600927B RID: 37499 RVA: 0x001525B0 File Offset: 0x001507B0
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

		// Token: 0x0600927C RID: 37500 RVA: 0x001525F8 File Offset: 0x001507F8
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

		// Token: 0x0600927D RID: 37501 RVA: 0x00152980 File Offset: 0x00150B80
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

		// Token: 0x0600927E RID: 37502 RVA: 0x00152A00 File Offset: 0x00150C00
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

		// Token: 0x0600927F RID: 37503 RVA: 0x00152A8C File Offset: 0x00150C8C
		public void SetCoverDesignationID(uint ID, string specialDesi)
		{
			this._specialDesignation = specialDesi;
			this._coverDesignationID = ID;
			XDesignationInfoChange @event = XEventPool<XDesignationInfoChange>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x06009280 RID: 37504 RVA: 0x00152ACC File Offset: 0x00150CCC
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

		// Token: 0x06009281 RID: 37505 RVA: 0x00152BD8 File Offset: 0x00150DD8
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

		// Token: 0x06009282 RID: 37506 RVA: 0x00152C20 File Offset: 0x00150E20
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

		// Token: 0x06009283 RID: 37507 RVA: 0x00152CAC File Offset: 0x00150EAC
		public void FetchAchieveSurvey()
		{
			RpcC2G_GetAchieveBrifInfoReq rpc = new RpcC2G_GetAchieveBrifInfoReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009284 RID: 37508 RVA: 0x00152CCC File Offset: 0x00150ECC
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

		// Token: 0x06009285 RID: 37509 RVA: 0x00152D28 File Offset: 0x00150F28
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

		// Token: 0x06009286 RID: 37510 RVA: 0x00152DFC File Offset: 0x00150FFC
		public void FetchAchieveType(AchieveType type)
		{
			RpcC2G_GetAchieveClassifyInfoReq rpcC2G_GetAchieveClassifyInfoReq = new RpcC2G_GetAchieveClassifyInfoReq();
			rpcC2G_GetAchieveClassifyInfoReq.oArg.type = (uint)type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetAchieveClassifyInfoReq);
		}

		// Token: 0x06009287 RID: 37511 RVA: 0x00152E2C File Offset: 0x0015102C
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

		// Token: 0x06009288 RID: 37512 RVA: 0x00152FA4 File Offset: 0x001511A4
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

		// Token: 0x06009289 RID: 37513 RVA: 0x00153018 File Offset: 0x00151218
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

		// Token: 0x0600928A RID: 37514 RVA: 0x0015308C File Offset: 0x0015128C
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

		// Token: 0x0600928B RID: 37515 RVA: 0x001530E8 File Offset: 0x001512E8
		public void OnReachDesignationNtf(PtcG2C_ReachDesignationNtf res)
		{
			DesignationTable.RowData byID = XDesignationDocument._designationTable.GetByID((int)res.Data.designationID);
			DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.ShowDesignation(byID);
		}

		// Token: 0x0600928C RID: 37516 RVA: 0x00153118 File Offset: 0x00151318
		public void ClaimAchieve(int id)
		{
			XSingleton<XDebug>.singleton.AddLog("ClaimAchieve ", id.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			RpcC2G_GetAchieveRewardReq rpcC2G_GetAchieveRewardReq = new RpcC2G_GetAchieveRewardReq();
			rpcC2G_GetAchieveRewardReq.oArg.achieveID = (uint)id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetAchieveRewardReq);
		}

		// Token: 0x0600928D RID: 37517 RVA: 0x00153164 File Offset: 0x00151364
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

		// Token: 0x0600928E RID: 37518 RVA: 0x001532F0 File Offset: 0x001514F0
		public double GetNowTime()
		{
			return (double)(DateTime.Now.Ticks / 10000000L);
		}

		// Token: 0x0400310F RID: 12559
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DesignationDocument");

		// Token: 0x04003110 RID: 12560
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003111 RID: 12561
		public List<AchieveItemInfo> achievesDetails = new List<AchieveItemInfo>();

		// Token: 0x04003112 RID: 12562
		public XAchieveView achieveView;

		// Token: 0x04003113 RID: 12563
		public GetAchieveBrifInfoRes achieveSurveyInfo;

		// Token: 0x04003114 RID: 12564
		private static DesignationTable _designationTable = new DesignationTable();

		// Token: 0x04003115 RID: 12565
		public static AchievementV2Table achieveTable = new AchievementV2Table();

		// Token: 0x04003116 RID: 12566
		public static AchievementPointRewardTable achieveRwdTable = new AchievementPointRewardTable();

		// Token: 0x04003117 RID: 12567
		private List<List<DesignationInfo>> _desList = new List<List<DesignationInfo>>();

		// Token: 0x04003118 RID: 12568
		private HashSet<int> hash = new HashSet<int>();

		// Token: 0x04003119 RID: 12569
		private static readonly int DESIGNATION_FRAME_RATE = 16;

		// Token: 0x0400311A RID: 12570
		private string _specialDesignation;

		// Token: 0x0400311B RID: 12571
		private uint _coverDesignationID;

		// Token: 0x0400311C RID: 12572
		private uint _abilityDesignationID;

		// Token: 0x0400311D RID: 12573
		public bool IsMaxAbilityDes;

		// Token: 0x0400311E RID: 12574
		public int LastDisPlayTab = 0;

		// Token: 0x0400311F RID: 12575
		public uint MaxAbilityDesNum;

		// Token: 0x04003120 RID: 12576
		private bool _redPoint = false;

		// Token: 0x04003121 RID: 12577
		private uint _lastSurveyID = 0U;

		// Token: 0x04003122 RID: 12578
		public double GetSignTime;
	}
}
