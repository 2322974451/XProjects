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
	// Token: 0x02000953 RID: 2387
	internal class XMentorshipDocument : XDocComponent
	{
		// Token: 0x17002C2A RID: 11306
		// (get) Token: 0x06008F97 RID: 36759 RVA: 0x00142434 File Offset: 0x00140634
		public override uint ID
		{
			get
			{
				return XMentorshipDocument.uuID;
			}
		}

		// Token: 0x17002C2B RID: 11307
		// (get) Token: 0x06008F98 RID: 36760 RVA: 0x0014244C File Offset: 0x0014064C
		public static XMentorshipDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XMentorshipDocument.uuID) as XMentorshipDocument;
			}
		}

		// Token: 0x06008F99 RID: 36761 RVA: 0x00142477 File Offset: 0x00140677
		public static void Execute(OnLoadedCallback callback = null)
		{
			XMentorshipDocument.AsyncLoader.AddTask("Table/MentorCompleteReward", XMentorshipDocument._mentorCompleteReward, false);
			XMentorshipDocument.AsyncLoader.AddTask("Table/MentorTask", XMentorshipDocument._mentorTaskTable, false);
			XMentorshipDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008F9A RID: 36762 RVA: 0x001424B2 File Offset: 0x001406B2
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._gettedData = false;
		}

		// Token: 0x06008F9B RID: 36763 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06008F9C RID: 36764 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06008F9D RID: 36765 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008F9E RID: 36766 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x17002C2C RID: 11308
		// (get) Token: 0x06008F9F RID: 36767 RVA: 0x001424C4 File Offset: 0x001406C4
		// (set) Token: 0x06008FA0 RID: 36768 RVA: 0x001424DC File Offset: 0x001406DC
		public bool HasRedPointOnTasks
		{
			get
			{
				return this._hasRedPointOnTasks;
			}
			set
			{
				this._hasRedPointOnTasks = value;
				this._gettedData = false;
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.SetRedPoint(TabIndex.Mentorship, this.IsHasRedDot());
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Friends, true);
			}
		}

		// Token: 0x17002C2D RID: 11309
		// (get) Token: 0x06008FA1 RID: 36769 RVA: 0x0014250D File Offset: 0x0014070D
		// (set) Token: 0x06008FA2 RID: 36770 RVA: 0x00142515 File Offset: 0x00140715
		public bool LeaveFootprint { get; set; }

		// Token: 0x17002C2E RID: 11310
		// (get) Token: 0x06008FA3 RID: 36771 RVA: 0x00142520 File Offset: 0x00140720
		// (set) Token: 0x06008FA4 RID: 36772 RVA: 0x00142538 File Offset: 0x00140738
		public string MentorshipApplyWords
		{
			get
			{
				return this._mentorshipApplyWords;
			}
			set
			{
				this._mentorshipApplyWords = value;
			}
		}

		// Token: 0x17002C2F RID: 11311
		// (get) Token: 0x06008FA5 RID: 36773 RVA: 0x00142544 File Offset: 0x00140744
		public bool TipIconHasRedPoint
		{
			get
			{
				return this._tipIconHasRedPoint;
			}
		}

		// Token: 0x17002C30 RID: 11312
		// (get) Token: 0x06008FA6 RID: 36774 RVA: 0x0014255C File Offset: 0x0014075C
		public bool HasApplyMsg
		{
			get
			{
				return this._hasApplyMsg;
			}
		}

		// Token: 0x17002C31 RID: 11313
		// (get) Token: 0x06008FA7 RID: 36775 RVA: 0x00142574 File Offset: 0x00140774
		// (set) Token: 0x06008FA8 RID: 36776 RVA: 0x0014258B File Offset: 0x0014078B
		public static MentorCompleteRewardTable MentorCompleteReward
		{
			get
			{
				return XMentorshipDocument._mentorCompleteReward;
			}
			set
			{
				XMentorshipDocument._mentorCompleteReward = value;
			}
		}

		// Token: 0x06008FA9 RID: 36777 RVA: 0x00142594 File Offset: 0x00140794
		public MentorTaskTable.RowData GetTableTaskInfoByTaskID(uint taskID)
		{
			return XMentorshipDocument._mentorTaskTable.GetByTaskID(taskID);
		}

		// Token: 0x06008FAA RID: 36778 RVA: 0x001425B4 File Offset: 0x001407B4
		public MyMentorship GetMyMentorShip()
		{
			return this._myMentorship;
		}

		// Token: 0x06008FAB RID: 36779 RVA: 0x001425CC File Offset: 0x001407CC
		public void OnRecordExplanationStart()
		{
			bool useApollo = XChatDocument.UseApollo;
			if (useApollo)
			{
				XSingleton<XChatApolloMgr>.singleton.StartRecord(VoiceUsage.MENTORHIP, null);
			}
			else
			{
				XSingleton<XChatIFlyMgr>.singleton.StartRecord(VoiceUsage.MENTORHIP, null);
			}
		}

		// Token: 0x06008FAC RID: 36780 RVA: 0x00142600 File Offset: 0x00140800
		public void SendMentorshipInfoReq()
		{
			RpcC2M_GetMyMentorInfo rpc = new RpcC2M_GetMyMentorInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008FAD RID: 36781 RVA: 0x00142620 File Offset: 0x00140820
		public void OnGetMyMentorInfo(GetMyMentorInfoRes ores)
		{
			this._gettedData = true;
			this._myMentorship = MyMentorship.None;
			this.ReceiveingProtocolTime = ores.curTime - (int)Time.time;
			this.timeForReceive = (int)Time.time;
			this._mentorshipApplyWords = ores.mentorWords;
			this.LeaveFootprint = ores.isNeedStudent;
			bool flag = ores.mentorRelationList.Count > 0;
			if (flag)
			{
				EMentorRelationPosition pos = (EMentorRelationPosition)ores.mentorRelationList[0].pos;
				bool flag2 = pos == EMentorRelationPosition.EMentorPosMaster;
				if (flag2)
				{
					this._myMentorship = MyMentorship.Mentorship_Pupil;
				}
				else
				{
					bool flag3 = pos == EMentorRelationPosition.EMentorPosStudent;
					if (flag3)
					{
						this._myMentorship = MyMentorship.Mentorship_Master;
					}
				}
				this._relationList.Clear();
				for (int i = 0; i < ores.mentorRelationList.Count; i++)
				{
					OneMentorRelationInfo2Client oneMentorRelationInfo2Client = ores.mentorRelationList[i];
					this._relationList.Add(new MentorRelationInfo
					{
						roleInfo = oneMentorRelationInfo2Client.roleInfo,
						status = oneMentorRelationInfo2Client.curStatus,
						inheritStatus = oneMentorRelationInfo2Client.inheritStatus,
						inheritApplyRoleID = oneMentorRelationInfo2Client.inheritApplyRoleID,
						breakApplyRoleID = oneMentorRelationInfo2Client.breakApplyRoleID
					});
					List<MentorRelationTime> statusTimeList = this._relationList[i].statusTimeList;
					for (int j = 0; j < oneMentorRelationInfo2Client.relationlist.Count; j++)
					{
						statusTimeList.Add(new MentorRelationTime
						{
							status = (MentorRelationStatus)oneMentorRelationInfo2Client.relationlist[j].status,
							time = oneMentorRelationInfo2Client.relationlist[j].time
						});
					}
					List<MentorshipTaskInfo> taskList = this._relationList[i].taskList;
					this.AddTaskInfoUtil(oneMentorRelationInfo2Client.studentTaskList, taskList);
				}
				this._myMentorshipTaskList.Clear();
				bool flag4 = ores.mentorSelfInfo != null;
				if (flag4)
				{
					this.AddTaskInfoUtil(ores.mentorSelfInfo.selfTaskList, this._myMentorshipTaskList);
				}
			}
			bool flag5 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsVisible();
			if (flag5)
			{
				XMentorshipPupilsHandler mentorshipHandler = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.MentorshipHandler;
				bool flag6 = mentorshipHandler != null && mentorshipHandler.IsVisible();
				if (flag6)
				{
					mentorshipHandler.RefreshUI();
				}
			}
			bool flag7 = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag7)
			{
				XDramaDocument specificDocument = XDocuments.GetSpecificDocument<XDramaDocument>(XDramaDocument.uuID);
				XDramaOperate openedOperate = specificDocument.GetOpenedOperate(XSysDefine.XSys_Mentorship);
				bool flag8 = openedOperate != null;
				if (flag8)
				{
					XMentorshipPupilsDramaOperate xmentorshipPupilsDramaOperate = openedOperate as XMentorshipPupilsDramaOperate;
					bool flag9 = xmentorshipPupilsDramaOperate != null;
					if (flag9)
					{
						xmentorshipPupilsDramaOperate.RefreshOperateStatus();
					}
				}
			}
			this.RefreshMainUIRedPoint();
		}

		// Token: 0x06008FAE RID: 36782 RVA: 0x001428B4 File Offset: 0x00140AB4
		public bool IsHasRedDot()
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !this._gettedData;
				if (flag2)
				{
					result = this._hasRedPointOnTasks;
				}
				else
				{
					int i = 0;
					int count = this._relationList.Count;
					while (i < count)
					{
						bool oneRedStausByIndex = this.GetOneRedStausByIndex(i);
						if (oneRedStausByIndex)
						{
							return true;
						}
						i++;
					}
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06008FAF RID: 36783 RVA: 0x00142928 File Offset: 0x00140B28
		public bool GetOneRedStausByIndex(int mentorShipIndex)
		{
			bool flag = this._myMentorship == MyMentorship.Mentorship_Pupil;
			if (flag)
			{
				MentorRelationInfo mentorRelationInfo = this._relationList[mentorShipIndex];
				bool flag2 = mentorRelationInfo.inheritStatus == EMentorTaskStatus.EMentorTask_AlreadyReport && mentorRelationInfo.inheritApplyRoleID != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					return true;
				}
				bool flag3 = !this.IsAllReported(mentorRelationInfo.roleInfo.roleID);
				if (flag3)
				{
					return true;
				}
			}
			bool flag4 = this._myMentorship == MyMentorship.Mentorship_Master;
			if (flag4)
			{
				MentorRelationInfo mentorRelationInfo2 = this._relationList[mentorShipIndex];
				bool flag5 = mentorRelationInfo2.inheritStatus == EMentorTaskStatus.EMentorTask_AlreadyReport && mentorRelationInfo2.inheritApplyRoleID != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag5)
				{
					return true;
				}
				bool flag6 = !this.IsAllAgreed(mentorRelationInfo2.roleInfo.roleID);
				if (flag6)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06008FB0 RID: 36784 RVA: 0x00142A1C File Offset: 0x00140C1C
		public ulong GetMentorShipInTime(ulong currentRoleID)
		{
			ulong result = 0UL;
			MentorRelationInfo relationTargetInfoByRoleID = this.GetRelationTargetInfoByRoleID(currentRoleID);
			bool flag = relationTargetInfoByRoleID != null;
			if (flag)
			{
				for (int i = 0; i < relationTargetInfoByRoleID.statusTimeList.Count; i++)
				{
					bool flag2 = relationTargetInfoByRoleID.statusTimeList[i].status == MentorRelationStatus.MentorRelationIn;
					if (flag2)
					{
						result = (ulong)relationTargetInfoByRoleID.statusTimeList[i].time;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06008FB1 RID: 36785 RVA: 0x00142A94 File Offset: 0x00140C94
		public bool IsAllAgreed(ulong roleID)
		{
			List<MentorshipTaskInfo> taskListWithRoleID = this.GetTaskListWithRoleID(roleID);
			bool flag = taskListWithRoleID == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				for (int i = 0; i < taskListWithRoleID.Count; i++)
				{
					List<MentorshipTaskStatus> taskStatusList = taskListWithRoleID[i].taskStatusList;
					for (int j = 0; j < taskStatusList.Count; j++)
					{
						bool flag2 = taskStatusList[j].status == 3U;
						if (flag2)
						{
							return false;
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06008FB2 RID: 36786 RVA: 0x00142B1C File Offset: 0x00140D1C
		public bool IsAllReported(ulong roleID)
		{
			ulong mentorShipInTime = this.GetMentorShipInTime(roleID);
			for (int i = 0; i < this._myMentorshipTaskList.Count; i++)
			{
				List<MentorshipTaskStatus> taskStatusList = this._myMentorshipTaskList[i].taskStatusList;
				for (int j = 0; j < taskStatusList.Count; j++)
				{
					bool flag = taskStatusList[j].roleID == roleID && taskStatusList[j].status == 2U;
					if (flag)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06008FB3 RID: 36787 RVA: 0x00142BB0 File Offset: 0x00140DB0
		public int GetRelationTargetsCount()
		{
			return this._relationList.Count;
		}

		// Token: 0x06008FB4 RID: 36788 RVA: 0x00142BD0 File Offset: 0x00140DD0
		public MentorRelationInfo GetRelationTargetInfo(int index)
		{
			bool flag = index < this._relationList.Count;
			MentorRelationInfo result;
			if (flag)
			{
				result = this._relationList[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008FB5 RID: 36789 RVA: 0x00142C04 File Offset: 0x00140E04
		public int GetRelationIndexByRoleID(ulong roleID)
		{
			int result = -1;
			for (int i = 0; i < this._relationList.Count; i++)
			{
				bool flag = this._relationList[i].roleInfo.roleID == roleID;
				if (flag)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x06008FB6 RID: 36790 RVA: 0x00142C5C File Offset: 0x00140E5C
		public MentorRelationInfo GetRelationTargetInfoByRoleID(ulong roleID)
		{
			for (int i = 0; i < this._relationList.Count; i++)
			{
				MentorRelationInfo mentorRelationInfo = this._relationList[i];
				bool flag = mentorRelationInfo.roleInfo.roleID == roleID;
				if (flag)
				{
					return mentorRelationInfo;
				}
			}
			return null;
		}

		// Token: 0x06008FB7 RID: 36791 RVA: 0x00142CB0 File Offset: 0x00140EB0
		public MentorRelationInfo GetInheritStatusByRoleID(ulong roleID)
		{
			for (int i = 0; i < this._relationList.Count; i++)
			{
				bool flag = this._relationList[i].roleInfo.roleID == roleID;
				if (flag)
				{
					return this._relationList[i];
				}
			}
			return null;
		}

		// Token: 0x06008FB8 RID: 36792 RVA: 0x00142D0C File Offset: 0x00140F0C
		public void SendToGetMyApplyPupilsInfo(bool refreh = false)
		{
			RpcC2M_GetMyApplyStudentInfo rpcC2M_GetMyApplyStudentInfo = new RpcC2M_GetMyApplyStudentInfo();
			rpcC2M_GetMyApplyStudentInfo.oArg.isRefresh = refreh;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetMyApplyStudentInfo);
		}

		// Token: 0x06008FB9 RID: 36793 RVA: 0x00142D3C File Offset: 0x00140F3C
		public void OnGetMyApplyPupilsInfo(GetMyApplyStudentInfoRes oRes)
		{
			this._pupilApplyInfo.applyTargetInfoList.Clear();
			for (int i = 0; i < oRes.canApplyList.Count; i++)
			{
				OneMentorApplyStudentShow oneMentorApplyStudentShow = oRes.canApplyList[i];
				this._pupilApplyInfo.applyTargetInfoList.Add(new PupilTargetItemInfo
				{
					roleInfo = oRes.canApplyList[i].oneStudent,
					isApplied = oRes.canApplyList[i].hasApply,
					applyWords = oRes.canApplyList[i].applyWords
				});
			}
			this._myApplyPupilRefreshTime = oRes.leftRefreshTime;
			this.StartCountDown();
			this.RefreshViewCD();
			bool flag = DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshUI();
			}
		}

		// Token: 0x06008FBA RID: 36794 RVA: 0x00142E14 File Offset: 0x00141014
		public void SendToGetMyApplyMasterInfo(bool refresh = false)
		{
			RpcC2M_GetMyApplyMasterInfo rpcC2M_GetMyApplyMasterInfo = new RpcC2M_GetMyApplyMasterInfo();
			rpcC2M_GetMyApplyMasterInfo.oArg.isRefresh = refresh;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetMyApplyMasterInfo);
		}

		// Token: 0x06008FBB RID: 36795 RVA: 0x00142E44 File Offset: 0x00141044
		public void OnGetMyApplyMasterInfo(GetMyApplyMasterInfoRes oRes)
		{
			this._masterApplyInfoList.Clear();
			for (int i = 0; i < oRes.canApplyMasters.Count; i++)
			{
				OneMentorApplyMasterShow oneMentorApplyMasterShow = oRes.canApplyMasters[i];
				this._masterApplyInfoList.Add(new MasterApplyInfoItem
				{
					applyWords = oneMentorApplyMasterShow.applyWords,
					hasApply = oneMentorApplyMasterShow.hasApply,
					roleInfo = oneMentorApplyMasterShow.oneMaster
				});
			}
			this._myApplyMasterRefreshTime = oRes.leftRefreshTime;
			this.StartCountDown();
			this.RefreshViewCD();
			bool flag = DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshUI();
			}
		}

		// Token: 0x06008FBC RID: 36796 RVA: 0x00142EF0 File Offset: 0x001410F0
		public void SendCandidatesOpReq(EMentorMsgOpType opType, ulong roleID = 0UL, MentorMsgApplyType type = MentorMsgApplyType.MentorMsgApplyMax, int taskID = 0, bool isAll = false)
		{
			RpcC2M_MentorMyBeAppliedMsg rpcC2M_MentorMyBeAppliedMsg = new RpcC2M_MentorMyBeAppliedMsg();
			rpcC2M_MentorMyBeAppliedMsg.oArg.operation = opType;
			rpcC2M_MentorMyBeAppliedMsg.oArg.msgType = type;
			rpcC2M_MentorMyBeAppliedMsg.oArg.roleID = roleID;
			rpcC2M_MentorMyBeAppliedMsg.oArg.taskID = taskID;
			rpcC2M_MentorMyBeAppliedMsg.oArg.operatingAllTask = isAll;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_MentorMyBeAppliedMsg);
		}

		// Token: 0x06008FBD RID: 36797 RVA: 0x00142F54 File Offset: 0x00141154
		public void OnGetMyBeenApplyedMsg(MentorMyBeAppliedMsgArg oArg, MentorMyBeAppliedMsgRes oRes)
		{
			bool flag = oArg.operation != EMentorMsgOpType.EMentorMsgOp_Get;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("OperateSuccess"), "fece00");
			}
			switch (oArg.operation)
			{
			case EMentorMsgOpType.EMentorMsgOp_Get:
			{
				bool flag2 = oRes.error == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					this._beenApplyedInfoList.Clear();
					for (int i = 0; i < oRes.msgList.Count; i++)
					{
						OneMentorBeAppliedMsg oneMentorBeAppliedMsg = oRes.msgList[i];
						this._beenApplyedInfoList.Add(new MentorBeenApplyedInfo
						{
							applyType = oneMentorBeAppliedMsg.type,
							time = oneMentorBeAppliedMsg.time,
							reportTaskID = oneMentorBeAppliedMsg.reportTaskID,
							roleInfo = oneMentorBeAppliedMsg.roleBrief
						});
					}
					bool flag3 = DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshUI();
					}
					bool flag4 = DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>.singleton.IsVisible();
					if (flag4)
					{
						DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>.singleton.RefreshUI();
					}
					this.RefreshMsgMainSceneIcon();
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
				break;
			}
			case EMentorMsgOpType.EMentorMsgOpType_Clear:
			{
				bool flag5 = oRes.error == ErrorCode.ERR_SUCCESS;
				if (flag5)
				{
					this.RemoveApplyNewsButInheritReport(oArg);
					bool flag6 = DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.IsVisible();
					if (flag6)
					{
						DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshUI();
					}
					bool flag7 = DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>.singleton.IsVisible();
					if (flag7)
					{
						DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>.singleton.RefreshUI();
					}
					this.RefreshMsgMainSceneIcon();
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
				break;
			}
			case EMentorMsgOpType.EMentorMsgOpType_Agree:
			{
				bool flag8 = oRes.error == ErrorCode.ERR_SUCCESS;
				if (flag8)
				{
					bool flag9 = oArg.msgType == MentorMsgApplyType.MentorMsgApplyInherit;
					if (flag9)
					{
						for (int j = 0; j < this._relationList.Count; j++)
						{
							MentorRelationInfo mentorRelationInfo = this._relationList[j];
							bool flag10 = mentorRelationInfo.roleInfo.roleID == oArg.roleID;
							if (flag10)
							{
								mentorRelationInfo.inheritStatus = EMentorTaskStatus.EMentorTask_ConfirmReport;
								bool flag11 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsVisible();
								if (flag11)
								{
									XMentorshipPupilsHandler mentorshipHandler = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.MentorshipHandler;
									bool flag12 = mentorshipHandler != null && mentorshipHandler.IsVisible();
									if (flag12)
									{
										mentorshipHandler.UpdateInheritTaskItem();
									}
								}
								this.RefreshMainUIRedPoint();
								break;
							}
						}
					}
					else
					{
						bool flag13 = oArg.msgType == MentorMsgApplyType.MentorMsgApplyReportTask;
						if (flag13)
						{
							List<MentorshipTaskInfo> taskListWithRoleID = this.GetTaskListWithRoleID(oArg.roleID);
							bool flag14 = taskListWithRoleID != null;
							if (flag14)
							{
								for (int k = 0; k < taskListWithRoleID.Count; k++)
								{
									MentorshipTaskInfo mentorshipTaskInfo = taskListWithRoleID[k];
									bool flag15 = mentorshipTaskInfo.taskID == oArg.taskID;
									if (flag15)
									{
										List<MentorshipTaskStatus> taskStatusList = mentorshipTaskInfo.taskStatusList;
										bool flag16 = false;
										for (int l = 0; l < taskStatusList.Count; l++)
										{
											bool flag17 = taskStatusList[l].roleID == oArg.roleID;
											if (flag17)
											{
												taskStatusList[l].status = 4U;
												flag16 = true;
												break;
											}
										}
										bool flag18 = flag16;
										if (flag18)
										{
											this.RefreshTaskItems();
											break;
										}
									}
								}
							}
						}
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
				bool flag19 = oArg.operatingAllTask && oArg.msgType == MentorMsgApplyType.MentorMsgApplyReportTask;
				if (flag19)
				{
					for (int m = this._beenApplyedInfoList.Count - 1; m >= 0; m--)
					{
						bool flag20 = this._beenApplyedInfoList[m].applyType == MentorMsgApplyType.MentorMsgApplyReportTask;
						if (flag20)
						{
							this._beenApplyedInfoList.RemoveAt(m);
						}
					}
				}
				else
				{
					for (int n = this._beenApplyedInfoList.Count - 1; n >= 0; n--)
					{
						bool flag21 = this._beenApplyedInfoList[n].roleInfo.roleID == oArg.roleID && oArg.msgType == this._beenApplyedInfoList[n].applyType;
						if (flag21)
						{
							bool flag22 = oArg.msgType == MentorMsgApplyType.MentorMsgApplyMaster || oArg.msgType == MentorMsgApplyType.MentorMsgApplyStudent;
							if (flag22)
							{
								this._beenApplyedInfoList.RemoveAt(n);
							}
							else
							{
								bool flag23 = oRes.error == ErrorCode.ERR_SUCCESS;
								if (flag23)
								{
									bool flag24 = this._beenApplyedInfoList[n].applyType == MentorMsgApplyType.MentorMsgApplyReportTask && this._beenApplyedInfoList[n].reportTaskID == oArg.taskID;
									if (flag24)
									{
										this._beenApplyedInfoList.RemoveAt(n);
									}
									else
									{
										bool flag25 = this._beenApplyedInfoList[n].applyType != MentorMsgApplyType.MentorMsgApplyReportTask;
										if (flag25)
										{
											this._beenApplyedInfoList.RemoveAt(n);
										}
									}
								}
							}
						}
					}
				}
				this.RefreshMsgMainSceneIcon();
				this.RefreshRedPointWithoutData();
				bool flag26 = DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>.singleton.IsVisible();
				if (flag26)
				{
					DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>.singleton.RefreshUI();
				}
				bool flag27 = DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.IsVisible();
				if (flag27)
				{
					DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshUI();
				}
				break;
			}
			case EMentorMsgOpType.EMentorMsgOpType_Reject:
			{
				bool flag28 = oRes.error == ErrorCode.ERR_SUCCESS;
				if (flag28)
				{
					for (int num = this._beenApplyedInfoList.Count - 1; num >= 0; num--)
					{
						bool flag29 = this._beenApplyedInfoList[num].roleInfo.roleID == oArg.roleID && this._beenApplyedInfoList[num].applyType == oArg.msgType;
						if (flag29)
						{
							this._beenApplyedInfoList.RemoveAt(num);
						}
					}
					this.RefreshMsgMainSceneIcon();
					bool flag30 = DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.IsVisible();
					if (flag30)
					{
						DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshUI();
					}
					bool flag31 = DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>.singleton.IsVisible();
					if (flag31)
					{
						DlgBase<XMentorshipApplicationsView, XMentorshipApplicationBehavior>.singleton.RefreshUI();
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
				break;
			}
			}
		}

		// Token: 0x06008FBE RID: 36798 RVA: 0x001435A0 File Offset: 0x001417A0
		private void RefreshRedPointWithoutData()
		{
			this._hasRedPointOnTasks = false;
			for (int i = 0; i < this._beenApplyedInfoList.Count; i++)
			{
				bool flag = this._beenApplyedInfoList[i].applyType == MentorMsgApplyType.MentorMsgApplyInherit || this._beenApplyedInfoList[i].applyType == MentorMsgApplyType.MentorMsgApplyReportTask;
				if (flag)
				{
					this._hasRedPointOnTasks = true;
				}
			}
			this.RefreshMainUIRedPoint();
		}

		// Token: 0x06008FBF RID: 36799 RVA: 0x00143610 File Offset: 0x00141810
		private void RefreshMainUIRedPoint()
		{
			this._hasRedPointOnTasks = this.IsHasRedDot();
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.SetRedPoint(TabIndex.Mentorship, this._hasRedPointOnTasks);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Friends, true);
			bool flag = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.UpdateRedpointUI();
			}
		}

		// Token: 0x06008FC0 RID: 36800 RVA: 0x00143664 File Offset: 0x00141864
		private void RefreshMsgMainSceneIcon()
		{
			bool flag = this._beenApplyedInfoList.Count == 0;
			if (flag)
			{
				this._hasApplyMsg = false;
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_MentorshipMsg_Tip, true);
			}
		}

		// Token: 0x06008FC1 RID: 36801 RVA: 0x001436A0 File Offset: 0x001418A0
		private void RemoveApplyNewsButInheritReport(MentorMyBeAppliedMsgArg oArg)
		{
			for (int i = this._beenApplyedInfoList.Count - 1; i >= 0; i--)
			{
				bool flag = this._beenApplyedInfoList[i].applyType == MentorMsgApplyType.MentorMsgApplyStudent || this._beenApplyedInfoList[i].applyType == MentorMsgApplyType.MentorMsgApplyMaster;
				if (flag)
				{
					this._beenApplyedInfoList.RemoveAt(i);
				}
			}
		}

		// Token: 0x06008FC2 RID: 36802 RVA: 0x0014370C File Offset: 0x0014190C
		public MentorBeenApplyedInfo GetMentorshipCandidateInfoByIndex(int index)
		{
			bool flag = index < this._beenApplyedInfoList.Count;
			MentorBeenApplyedInfo result;
			if (flag)
			{
				result = this._beenApplyedInfoList[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008FC3 RID: 36803 RVA: 0x00143740 File Offset: 0x00141940
		private void AddTaskInfoUtil(List<OneMentorTaskInfo> src, List<MentorshipTaskInfo> des)
		{
			for (int i = 0; i < src.Count; i++)
			{
				OneMentorTaskInfo oneMentorTaskInfo = src[i];
				MentorshipTaskInfo mentorshipTaskInfo = new MentorshipTaskInfo
				{
					taskID = oneMentorTaskInfo.taskID,
					completeProgress = oneMentorTaskInfo.completeProgress,
					completeTime = oneMentorTaskInfo.completeTime
				};
				List<MentorshipTaskStatus> taskStatusList = mentorshipTaskInfo.taskStatusList;
				for (int j = 0; j < oneMentorTaskInfo.taskApplyStatus.Count; j++)
				{
					taskStatusList.Add(new MentorshipTaskStatus
					{
						roleID = oneMentorTaskInfo.taskApplyStatus[j].key,
						status = oneMentorTaskInfo.taskApplyStatus[j].value
					});
				}
				des.Add(mentorshipTaskInfo);
				bool flag = this._myMentorship == MyMentorship.Mentorship_Pupil && des == this._myMentorshipTaskList;
				if (flag)
				{
					for (int k = 0; k < this._relationList.Count; k++)
					{
						bool flag2 = false;
						ulong num = 0UL;
						for (int l = 0; l < taskStatusList.Count; l++)
						{
							bool flag3 = this._relationList[k].roleInfo.roleID == taskStatusList[l].roleID;
							if (flag3)
							{
								flag2 = true;
								break;
							}
						}
						bool flag4 = !flag2;
						if (flag4)
						{
							for (int m = 0; m < this._relationList[k].statusTimeList.Count; m++)
							{
								bool flag5 = this._relationList[k].statusTimeList[m].status == MentorRelationStatus.MentorRelationIn;
								if (flag5)
								{
									num = (ulong)this._relationList[k].statusTimeList[m].time;
									break;
								}
							}
							bool flag6 = mentorshipTaskInfo.completeTime != 0;
							if (flag6)
							{
								bool flag7 = (long)mentorshipTaskInfo.completeTime < (long)num;
								if (flag7)
								{
									taskStatusList.Add(new MentorshipTaskStatus
									{
										roleID = this._relationList[k].roleInfo.roleID,
										status = 5U
									});
								}
								else
								{
									taskStatusList.Add(new MentorshipTaskStatus
									{
										roleID = this._relationList[k].roleInfo.roleID,
										status = 2U
									});
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06008FC4 RID: 36804 RVA: 0x001439B8 File Offset: 0x00141BB8
		public MessageShowInfoItem GetCandidateMsgShowInfo(int index)
		{
			bool flag = this.CurViewType == CandidatesViewType.Application;
			if (flag)
			{
				while (index < this._beenApplyedInfoList.Count)
				{
					MentorBeenApplyedInfo mentorshipCandidateInfoByIndex = this.GetMentorshipCandidateInfoByIndex(index);
					bool flag2 = mentorshipCandidateInfoByIndex != null && mentorshipCandidateInfoByIndex.applyType != MentorMsgApplyType.MentorMsgApplyInherit && mentorshipCandidateInfoByIndex.applyType != MentorMsgApplyType.MentorMsgApplyReportTask;
					if (flag2)
					{
						this._tempShowInfo.taskID = mentorshipCandidateInfoByIndex.reportTaskID;
						this._tempShowInfo.roleInfo = mentorshipCandidateInfoByIndex.roleInfo;
						this._tempShowInfo.msgType = mentorshipCandidateInfoByIndex.applyType;
						this._tempShowInfo.audioTime = mentorshipCandidateInfoByIndex.audioTime;
						this._tempShowInfo.audioID = mentorshipCandidateInfoByIndex.audioID;
						this._tempShowInfo.promiseWords = mentorshipCandidateInfoByIndex.applyWords;
						return this._tempShowInfo;
					}
					index++;
				}
			}
			else
			{
				bool flag3 = this.CurViewType == CandidatesViewType.Recommend;
				if (flag3)
				{
					bool flag4 = this.CurRecommendType == CandidatesViewRecommendType.Master;
					if (flag4)
					{
						bool flag5 = index < this._masterApplyInfoList.Count;
						if (flag5)
						{
							MasterApplyInfoItem masterApplyInfoItem = this._masterApplyInfoList[index];
							this._tempShowInfo.roleInfo = masterApplyInfoItem.roleInfo;
							this._tempShowInfo.promiseWords = masterApplyInfoItem.applyWords;
							this._tempShowInfo.applied = masterApplyInfoItem.hasApply;
							return this._tempShowInfo;
						}
					}
					else
					{
						bool flag6 = index < this._pupilApplyInfo.applyTargetInfoList.Count;
						if (flag6)
						{
							this._tempShowInfo.roleInfo = this._pupilApplyInfo.applyTargetInfoList[index].roleInfo;
							this._tempShowInfo.promiseWords = this._pupilApplyInfo.applyTargetInfoList[index].applyWords;
							this._tempShowInfo.applied = this._pupilApplyInfo.applyTargetInfoList[index].isApplied;
							return this._tempShowInfo;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06008FC5 RID: 36805 RVA: 0x00143BB8 File Offset: 0x00141DB8
		public int GetMyPupilTaskTotalNumber(ulong roleID)
		{
			List<MentorshipTaskInfo> taskListWithRoleID = this.GetTaskListWithRoleID(roleID);
			bool flag = taskListWithRoleID != null;
			int result;
			if (flag)
			{
				result = taskListWithRoleID.Count;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06008FC6 RID: 36806 RVA: 0x00143BE4 File Offset: 0x00141DE4
		public List<MentorshipTaskInfo> GetTaskListWithRoleID(ulong roleID)
		{
			for (int i = 0; i < this._relationList.Count; i++)
			{
				bool flag = this._relationList[i].roleInfo.roleID == roleID;
				if (flag)
				{
					return this._relationList[i].taskList;
				}
			}
			return null;
		}

		// Token: 0x06008FC7 RID: 36807 RVA: 0x00143C44 File Offset: 0x00141E44
		public int GetRelationPassedDays(ulong _currentRoleID, MentorRelationStatus status)
		{
			for (int i = 0; i < this._relationList.Count; i++)
			{
				bool flag = this._relationList[i].roleInfo.roleID == _currentRoleID;
				if (flag)
				{
					uint num = 0U;
					List<MentorRelationTime> statusTimeList = this._relationList[i].statusTimeList;
					for (int j = 0; j < statusTimeList.Count; j++)
					{
						bool flag2 = statusTimeList[j].status == status;
						if (flag2)
						{
							num = statusTimeList[j].time;
						}
					}
					return TimeSpan.FromSeconds((double)((long)this.ReceiveingProtocolTime + (long)((ulong)((uint)Time.time)) - (long)((ulong)num))).Days;
				}
			}
			return 0;
		}

		// Token: 0x06008FC8 RID: 36808 RVA: 0x00143D18 File Offset: 0x00141F18
		public bool IsMentorshipInDaysEnough(ulong roleID)
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("Mentor_NormalCompleteDay");
			int relationPassedDays = XMentorshipDocument.Doc.GetRelationPassedDays(roleID, MentorRelationStatus.MentorRelationIn);
			bool flag = relationPassedDays >= @int;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_MENTOR_COMPLETE_IN_RELATION_NEED_DAYS"), "fece00");
				result = false;
			}
			return result;
		}

		// Token: 0x06008FC9 RID: 36809 RVA: 0x00143D78 File Offset: 0x00141F78
		public bool IsCompletedTaskEnough(ulong roleID)
		{
			int completedTaskCount = XMentorshipDocument.Doc.GetCompletedTaskCount(roleID);
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("Mentor_NormalComplete");
			bool flag = completedTaskCount >= @int;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_MENTOR_COMPLETE_IN_RELATION_NEED_DAYS"), "fece00");
				result = false;
			}
			return result;
		}

		// Token: 0x06008FCA RID: 36810 RVA: 0x00143DD8 File Offset: 0x00141FD8
		public MentorshipTaskInfo GetTaskInfoWithIndexAndRoleID(int index, ulong roleID)
		{
			List<MentorshipTaskInfo> taskListWithRoleID = this.GetTaskListWithRoleID(roleID);
			bool flag = taskListWithRoleID != null && index < taskListWithRoleID.Count;
			MentorshipTaskInfo result;
			if (flag)
			{
				result = taskListWithRoleID[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008FCB RID: 36811 RVA: 0x00143E10 File Offset: 0x00142010
		public int GetCanidatesShowMsgCount()
		{
			bool flag = this.CurViewType == CandidatesViewType.Application;
			int result;
			if (flag)
			{
				int num = 0;
				for (int i = 0; i < this._beenApplyedInfoList.Count; i++)
				{
					bool flag2 = this._beenApplyedInfoList[i].applyType != MentorMsgApplyType.MentorMsgApplyReportTask && this._beenApplyedInfoList[i].applyType != MentorMsgApplyType.MentorMsgApplyInherit;
					if (flag2)
					{
						num++;
					}
				}
				result = num;
			}
			else
			{
				bool flag3 = this.CurViewType == CandidatesViewType.Recommend;
				if (flag3)
				{
					bool flag4 = this.CurRecommendType == CandidatesViewRecommendType.Master;
					if (flag4)
					{
						result = this._masterApplyInfoList.Count;
					}
					else
					{
						result = this._pupilApplyInfo.applyTargetInfoList.Count;
					}
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x06008FCC RID: 36812 RVA: 0x00143ED0 File Offset: 0x001420D0
		public int GetBeenApplyMsgCount()
		{
			return this._beenApplyedInfoList.Count;
		}

		// Token: 0x06008FCD RID: 36813 RVA: 0x00143EF0 File Offset: 0x001420F0
		public int GetBeenApplyReportsMsgCount()
		{
			int num = 0;
			for (int i = 0; i < this._beenApplyedInfoList.Count; i++)
			{
				bool flag = this._beenApplyedInfoList[i].applyType == MentorMsgApplyType.MentorMsgApplyReportTask;
				if (flag)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06008FCE RID: 36814 RVA: 0x00143F44 File Offset: 0x00142144
		public MentorBeenApplyedInfo GetBeenApplyInfoByIndex(int index)
		{
			bool flag = index < this._beenApplyedInfoList.Count;
			MentorBeenApplyedInfo result;
			if (flag)
			{
				result = this._beenApplyedInfoList[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008FCF RID: 36815 RVA: 0x00143F78 File Offset: 0x00142178
		public int GetMyMentorshipTaskCount()
		{
			return this._myMentorshipTaskList.Count;
		}

		// Token: 0x06008FD0 RID: 36816 RVA: 0x00143F98 File Offset: 0x00142198
		public MentorshipTaskInfo GetMyMentorshipTaskInfoByIndex(int index)
		{
			bool flag = index < this._myMentorshipTaskList.Count;
			MentorshipTaskInfo result;
			if (flag)
			{
				result = this._myMentorshipTaskList[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008FD1 RID: 36817 RVA: 0x00143FCC File Offset: 0x001421CC
		public MessageShowInfoItem GetApplicationViewMsgInfoByIndex(int index)
		{
			bool flag = index < this._myMentorshipTaskList.Count;
			MessageShowInfoItem result;
			if (flag)
			{
				MentorshipTaskInfo mentorshipTaskInfo = this._myMentorshipTaskList[index];
				result = this._tempShowInfo;
			}
			else
			{
				index -= this._myMentorshipTaskList.Count;
				bool flag2 = index < this._beenApplyedInfoList.Count;
				if (flag2)
				{
					result = this._tempShowInfo;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06008FD2 RID: 36818 RVA: 0x00144035 File Offset: 0x00142235
		public void SetCandidatesViewVisible(CandidatesViewType viewType, CandidatesViewRecommendType recommendType = CandidatesViewRecommendType.None)
		{
			this.CurViewType = viewType;
			this.CurRecommendType = recommendType;
			DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x06008FD3 RID: 36819 RVA: 0x00144053 File Offset: 0x00142253
		public void ResetCandidatesView()
		{
			this.CurViewType = CandidatesViewType.None;
			this.CurRecommendType = CandidatesViewRecommendType.None;
		}

		// Token: 0x06008FD4 RID: 36820 RVA: 0x00144064 File Offset: 0x00142264
		public void SendMentorRelationOp(MentorRelationOpType opType, ulong roleID, int taskID = 0)
		{
			RpcC2M_MentorRelationOp rpcC2M_MentorRelationOp = new RpcC2M_MentorRelationOp();
			rpcC2M_MentorRelationOp.oArg.destRoleID = roleID;
			rpcC2M_MentorRelationOp.oArg.operation = opType;
			rpcC2M_MentorRelationOp.oArg.reportTaskID = taskID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_MentorRelationOp);
		}

		// Token: 0x06008FD5 RID: 36821 RVA: 0x001440AC File Offset: 0x001422AC
		public void OnGetMentorshipOpReply(MentorRelationOpArg oArg, MentorRelationOpRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_FAILED;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_MENTOR_ASKMAXTODAY;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
				else
				{
					switch (oArg.operation)
					{
					case MentorRelationOpType.MentorRelationOp_ApplyMaster:
					{
						int num = -1;
						for (int i = 0; i < this._masterApplyInfoList.Count; i++)
						{
							bool flag3 = this._masterApplyInfoList[i].roleInfo.roleID == oArg.destRoleID;
							if (flag3)
							{
								num = i;
								break;
							}
						}
						bool flag4 = num >= 0;
						if (flag4)
						{
							bool flag5 = oRes.error == ErrorCode.ERR_SUCCESS;
							if (flag5)
							{
								this._masterApplyInfoList[num].hasApply = true;
								bool flag6 = DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.IsVisible();
								if (flag6)
								{
									DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshAllVisible();
								}
								XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("SendMessageSuccess"), "fece00");
							}
							else
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
								this._masterApplyInfoList.RemoveAt(num);
								bool flag7 = DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.IsVisible();
								if (flag7)
								{
									DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshUI();
								}
							}
						}
						break;
					}
					case MentorRelationOpType.MentorRelationOp_ApplyStudent:
					{
						int num2 = -1;
						for (int j = 0; j < this._pupilApplyInfo.applyTargetInfoList.Count; j++)
						{
							PupilTargetItemInfo pupilTargetItemInfo = this._pupilApplyInfo.applyTargetInfoList[j];
							bool flag8 = pupilTargetItemInfo.roleInfo.roleID == oArg.destRoleID;
							if (flag8)
							{
								num2 = j;
								break;
							}
						}
						bool flag9 = num2 >= 0;
						if (flag9)
						{
							bool flag10 = oRes.error == ErrorCode.ERR_SUCCESS;
							if (flag10)
							{
								this._pupilApplyInfo.applyTargetInfoList[num2].isApplied = true;
								XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("SendMessageSuccess"), "fece00");
								bool flag11 = DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.IsVisible();
								if (flag11)
								{
									DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshAllVisible();
								}
							}
							else
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
								this._pupilApplyInfo.applyTargetInfoList.RemoveAt(num2);
								bool flag12 = DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.IsVisible();
								if (flag12)
								{
									DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshUI();
								}
							}
						}
						break;
					}
					case MentorRelationOpType.MentorRelationOp_Inherit:
					{
						bool flag13 = oRes.error == ErrorCode.ERR_SUCCESS;
						if (flag13)
						{
							for (int k = 0; k < this._relationList.Count; k++)
							{
								bool flag14 = this._relationList[k].roleInfo.roleID == oArg.destRoleID;
								if (flag14)
								{
									this._relationList[k].inheritStatus = EMentorTaskStatus.EMentorTask_AlreadyReport;
									this._relationList[k].inheritApplyRoleID = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
									bool flag15 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsVisible();
									if (flag15)
									{
										XMentorshipPupilsHandler mentorshipHandler = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.MentorshipHandler;
										bool flag16 = mentorshipHandler != null && mentorshipHandler.IsVisible();
										if (flag16)
										{
											mentorshipHandler.UpdateInheritTaskItem();
										}
									}
									break;
								}
							}
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
						}
						break;
					}
					case MentorRelationOpType.MentorRelationOp_ReportTask:
					{
						bool flag17 = oRes.error == ErrorCode.ERR_SUCCESS;
						if (flag17)
						{
							List<MentorshipTaskInfo> myMentorshipTaskList = this._myMentorshipTaskList;
							foreach (MentorshipTaskInfo mentorshipTaskInfo in myMentorshipTaskList)
							{
								bool flag18 = mentorshipTaskInfo.taskID == oArg.reportTaskID;
								if (flag18)
								{
									bool flag19 = false;
									for (int l = 0; l < mentorshipTaskInfo.taskStatusList.Count; l++)
									{
										bool flag20 = mentorshipTaskInfo.taskStatusList[l].roleID == oArg.destRoleID;
										if (flag20)
										{
											mentorshipTaskInfo.taskStatusList[l].status = (uint)XFastEnumIntEqualityComparer<EMentorTaskStatus>.ToInt(EMentorTaskStatus.EMentorTask_AlreadyReport);
											flag19 = true;
										}
									}
									bool flag21 = !flag19;
									if (flag21)
									{
										mentorshipTaskInfo.taskStatusList.Add(new MentorshipTaskStatus
										{
											roleID = oArg.destRoleID,
											status = (uint)XFastEnumIntEqualityComparer<EMentorTaskStatus>.ToInt(EMentorTaskStatus.EMentorTask_AlreadyReport)
										});
									}
								}
							}
							MentorRelationInfo relationTargetInfoByRoleID = this.GetRelationTargetInfoByRoleID(oArg.destRoleID);
							bool flag22 = relationTargetInfoByRoleID != null;
							if (flag22)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("ReportToTarget"), relationTargetInfoByRoleID.roleInfo.name), "fece00");
							}
							this.RefreshTaskItems();
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
						}
						break;
					}
					case MentorRelationOpType.MentorRelationOp_ReportAllTask:
					{
						bool flag23 = oRes.error == ErrorCode.ERR_SUCCESS;
						if (flag23)
						{
							this.SendMentorshipInfoReq();
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
						}
						break;
					}
					case MentorRelationOpType.MentorRelationOp_Break:
					{
						bool flag24 = oRes.error == ErrorCode.ERR_SUCCESS;
						if (flag24)
						{
							for (int m = 0; m < this._relationList.Count; m++)
							{
								bool flag25 = this._relationList[m].roleInfo.roleID == oArg.destRoleID;
								if (flag25)
								{
									this._relationList[m].status = MentorRelationStatus.MentorRelationBreak;
									this._relationList[m].statusTimeList.Add(new MentorRelationTime
									{
										status = MentorRelationStatus.MentorRelationBreak,
										time = (uint)oRes.curTime
									});
									break;
								}
							}
						}
						this.FireMentorOperationEvent(oArg, oRes);
						break;
					}
					case MentorRelationOpType.MentorRelationOp_BreakCancel:
					case MentorRelationOpType.MentorRelationOp_NormalComplete:
					case MentorRelationOpType.MentorRelationOp_ForceComplete:
					{
						bool flag26 = oRes.error == ErrorCode.ERR_SUCCESS;
						if (flag26)
						{
							for (int n = this._relationList.Count - 1; n >= 0; n--)
							{
								bool flag27 = this._relationList[n].roleInfo.roleID == oArg.destRoleID;
								if (flag27)
								{
									this._relationList[n].status = MentorRelationStatus.MentorRelationIn;
									List<MentorRelationTime> statusTimeList = this._relationList[n].statusTimeList;
									for (int num3 = statusTimeList.Count - 1; num3 >= 0; num3--)
									{
										bool flag28 = statusTimeList[num3].status == MentorRelationStatus.MentorRelationBreak;
										if (flag28)
										{
											statusTimeList.RemoveAt(num3);
										}
									}
									break;
								}
							}
						}
						this.FireMentorOperationEvent(oArg, oRes);
						break;
					}
					}
				}
			}
		}

		// Token: 0x06008FD6 RID: 36822 RVA: 0x001447AC File Offset: 0x001429AC
		public int GetCompletedTaskCount(ulong roleID)
		{
			int num = 0;
			ulong mentorShipInTime = this.GetMentorShipInTime(roleID);
			List<MentorshipTaskInfo> taskList = this.GetTaskList(roleID);
			bool flag = taskList != null;
			if (flag)
			{
				for (int i = 0; i < taskList.Count; i++)
				{
					List<MentorshipTaskStatus> taskStatusList = taskList[i].taskStatusList;
					for (int j = 0; j < taskStatusList.Count; j++)
					{
						bool flag2 = taskStatusList[j].roleID == roleID && taskStatusList[j].status != 1U && taskStatusList[j].status != 2U && taskStatusList[j].status != 3U;
						if (flag2)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06008FD7 RID: 36823 RVA: 0x00144884 File Offset: 0x00142A84
		public int GetTotalTaskNum(ulong roleID)
		{
			List<MentorshipTaskInfo> taskList = this.GetTaskList(roleID);
			return (taskList != null) ? taskList.Count : 0;
		}

		// Token: 0x06008FD8 RID: 36824 RVA: 0x001448AC File Offset: 0x00142AAC
		private List<MentorshipTaskInfo> GetTaskList(ulong roleID)
		{
			List<MentorshipTaskInfo> result = null;
			bool flag = this._myMentorship == MyMentorship.Mentorship_Master;
			if (flag)
			{
				for (int i = 0; i < this._relationList.Count; i++)
				{
					bool flag2 = this._relationList[i].roleInfo.roleID == roleID;
					if (flag2)
					{
						result = this._relationList[i].taskList;
					}
				}
			}
			else
			{
				bool flag3 = this._myMentorship == MyMentorship.Mentorship_Pupil;
				if (flag3)
				{
					result = this._myMentorshipTaskList;
				}
			}
			return result;
		}

		// Token: 0x06008FD9 RID: 36825 RVA: 0x0014493C File Offset: 0x00142B3C
		private void RefreshTaskItems()
		{
			bool flag = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XMentorshipPupilsHandler mentorshipHandler = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.MentorshipHandler;
				bool flag2 = mentorshipHandler != null && mentorshipHandler.IsVisible();
				if (flag2)
				{
					mentorshipHandler.RefreshTaskItems();
				}
			}
			this.RefreshMainUIRedPoint();
		}

		// Token: 0x06008FDA RID: 36826 RVA: 0x00144988 File Offset: 0x00142B88
		public void SendUpdateMentorshopSetting(string words, bool isChecked)
		{
			RpcC2M_UpdateMentorApplyStudentInfo rpcC2M_UpdateMentorApplyStudentInfo = new RpcC2M_UpdateMentorApplyStudentInfo();
			rpcC2M_UpdateMentorApplyStudentInfo.oArg.applyWords = words;
			rpcC2M_UpdateMentorApplyStudentInfo.oArg.isNeedStudent = !isChecked;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_UpdateMentorApplyStudentInfo);
		}

		// Token: 0x06008FDB RID: 36827 RVA: 0x001449C8 File Offset: 0x00142BC8
		public void OnGetMentorshipSetting(UpdateMentorApplyStudentInfoArg oArg, UpdateMentorApplyStudentInfoRes oRes)
		{
			this.MentorshipApplyWords = oArg.applyWords;
			this.LeaveFootprint = oArg.isNeedStudent;
			bool flag = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XMentorshipPupilsHandler mentorshipHandler = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.MentorshipHandler;
				bool flag2 = mentorshipHandler != null && mentorshipHandler.IsVisible();
				if (flag2)
				{
					mentorshipHandler.OnSettingOk();
				}
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("MentorshipSettingOk"), "fece00");
			}
		}

		// Token: 0x06008FDC RID: 36828 RVA: 0x00144A44 File Offset: 0x00142C44
		public void SendGetOtherMentorStatus(ulong roleID)
		{
			RpcC2M_GetOtherMentorStatus rpcC2M_GetOtherMentorStatus = new RpcC2M_GetOtherMentorStatus();
			rpcC2M_GetOtherMentorStatus.oArg.roleid = roleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetOtherMentorStatus);
		}

		// Token: 0x06008FDD RID: 36829 RVA: 0x00144A74 File Offset: 0x00142C74
		public void OnGetOtherMentorStatus(GetOtherMentorStatusArg oArg, GetOtherMentorStatusRes oRes)
		{
			bool flag = oArg.roleid == this.ClickedMainSceneRoleID;
			if (flag)
			{
				this.ClickedRoleMentorshipStatus = oRes.status;
				bool flag2 = DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.RefreshBtns();
				}
			}
		}

		// Token: 0x06008FDE RID: 36830 RVA: 0x00144ABC File Offset: 0x00142CBC
		public void OnGetMentorshipNotify(PtcM2C_NotifyMentorApply roPtc)
		{
			EMentorRelationPosition pos = roPtc.Data.pos;
			this._tipIconHasRedPoint = roPtc.Data.hasInheritOrReportTask;
			this._hasApplyMsg = roPtc.Data.hasMsg;
			List<MentorBreakApplyInfo> appliedBreakInfos = roPtc.Data.appliedBreakInfos;
			bool flag = appliedBreakInfos.Count > 0;
			if (flag)
			{
				MentorBreakApplyInfo mentorBreakApplyInfo = appliedBreakInfos[0];
				string arg = (mentorBreakApplyInfo.pos == EMentorRelationPosition.EMentorPosMaster) ? XSingleton<XStringTable>.singleton.GetString("Master") : XSingleton<XStringTable>.singleton.GetString("Pupil");
				string text = XSingleton<XStringTable>.singleton.GetString("Break_Tell");
				text = string.Format(text, arg, mentorBreakApplyInfo.roleName, XSingleton<UiUtility>.singleton.TimeDuarationFormatString(mentorBreakApplyInfo.breakTime, 5));
				XSingleton<UiUtility>.singleton.ShowModalDialog(text, XStringDefineProxy.GetString("COMMON_OK"));
			}
			else
			{
				bool flag2 = pos != EMentorRelationPosition.EMentorPosMax && !this._hasApplyMsg;
				if (flag2)
				{
					bool flag3 = roPtc.Data.pos == EMentorRelationPosition.EMentorPosStudent;
					string @string;
					string string2;
					if (flag3)
					{
						@string = XSingleton<XStringTable>.singleton.GetString("ToGetStudent");
						string2 = XSingleton<XStringTable>.singleton.GetString("ToGetStudentTip");
					}
					else
					{
						@string = XSingleton<XStringTable>.singleton.GetString("ToGetTeacher");
						string2 = XSingleton<XStringTable>.singleton.GetString("ToGetTeacherTip");
					}
					XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<XStringTable>.singleton.GetString("Mentorship"), string2, @string, XSingleton<XStringTable>.singleton.GetString("TempNoNeed"), new ButtonClickEventHandler(this.ToOpenNews), new ButtonClickEventHandler(this.ToNoShowing), true, XTempTipDefine.OD_START, 50);
				}
			}
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_MentorshipMsg_Tip, true);
		}

		// Token: 0x06008FDF RID: 36831 RVA: 0x00144C7C File Offset: 0x00142E7C
		private bool ToNoShowing(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.SendUpdateMentorshopSetting("", true);
			return true;
		}

		// Token: 0x06008FE0 RID: 36832 RVA: 0x00144CA8 File Offset: 0x00142EA8
		private bool ToOpenNews(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			bool flag = XMentorshipDocument.Doc.GetMyPossibleMentorship() == MyMentorship.Mentorship_Pupil;
			if (flag)
			{
				XMentorshipDocument.Doc.SetCandidatesViewVisible(CandidatesViewType.Recommend, CandidatesViewRecommendType.Master);
				XMentorshipDocument.Doc.SendToGetMyApplyMasterInfo(false);
			}
			else
			{
				XMentorshipDocument.Doc.SetCandidatesViewVisible(CandidatesViewType.Recommend, CandidatesViewRecommendType.Pupil);
				XMentorshipDocument.Doc.SendToGetMyApplyPupilsInfo(false);
			}
			return true;
		}

		// Token: 0x06008FE1 RID: 36833 RVA: 0x00144D10 File Offset: 0x00142F10
		public MyMentorship GetMyPossibleMentorship()
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
			uint sealType = specificDocument.GetSealType();
			LevelSealTypeTable.RowData levelSealType = XLevelSealDocument.GetLevelSealType(sealType);
			bool flag = levelSealType == null;
			MyMentorship result;
			if (flag)
			{
				result = MyMentorship.Mentorship_Master;
			}
			else
			{
				bool flag2 = (ulong)level >= (ulong)((long)levelSealType.ApplyStudentLevel);
				if (flag2)
				{
					result = MyMentorship.Mentorship_Master;
				}
				else
				{
					result = MyMentorship.Mentorship_Pupil;
				}
			}
			return result;
		}

		// Token: 0x06008FE2 RID: 36834 RVA: 0x00144D78 File Offset: 0x00142F78
		private void FireMentorOperationEvent(MentorRelationOpArg oArg, MentorRelationOpRes oRes)
		{
			XMentorRelationOpArgs @event = XEventPool<XMentorRelationOpArgs>.GetEvent();
			@event.oArg = oArg;
			@event.oRes = oRes;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x06008FE3 RID: 36835 RVA: 0x00144DB8 File Offset: 0x00142FB8
		private void StartCountDown()
		{
			bool flag = this._countDownTimerID > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._countDownTimerID);
			}
			this._countDownTimerID = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(1f, new XTimerMgr.AccurateElapsedEventHandler(this.TimerCD), null);
		}

		// Token: 0x06008FE4 RID: 36836 RVA: 0x00144E08 File Offset: 0x00143008
		private void TimerCD(object param, float delay)
		{
			bool flag = this._myApplyMasterRefreshTime > 0;
			if (flag)
			{
				this._myApplyMasterRefreshTime--;
			}
			bool flag2 = this._myApplyPupilRefreshTime > 0;
			if (flag2)
			{
				this._myApplyPupilRefreshTime--;
			}
			this.RefreshViewCD();
			bool flag3 = this._myApplyMasterRefreshTime <= 0 && this._myApplyPupilRefreshTime <= 0;
			if (flag3)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._countDownTimerID);
				this._countDownTimerID = 0U;
			}
			else
			{
				this.StartCountDown();
			}
		}

		// Token: 0x06008FE5 RID: 36837 RVA: 0x00144E94 File Offset: 0x00143094
		private void RefreshViewCD()
		{
			bool flag = this.CurViewType == CandidatesViewType.Recommend && DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = this.CurRecommendType == CandidatesViewRecommendType.Master;
				if (flag2)
				{
					DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshCDTimeLabel(this._myApplyMasterRefreshTime);
				}
				else
				{
					DlgBase<XMentorshipCandidatesView, XMentorshipCandidatesBehavior>.singleton.RefreshCDTimeLabel(this._myApplyPupilRefreshTime);
				}
			}
		}

		// Token: 0x04002F5E RID: 12126
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MentorshipDocument");

		// Token: 0x04002F5F RID: 12127
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002F60 RID: 12128
		private static MentorCompleteRewardTable _mentorCompleteReward = new MentorCompleteRewardTable();

		// Token: 0x04002F61 RID: 12129
		private static MentorTaskTable _mentorTaskTable = new MentorTaskTable();

		// Token: 0x04002F62 RID: 12130
		public readonly int MaxRelationCount = 2;

		// Token: 0x04002F63 RID: 12131
		private bool _gettedData = false;

		// Token: 0x04002F64 RID: 12132
		private MyMentorship _myMentorship = MyMentorship.None;

		// Token: 0x04002F65 RID: 12133
		private List<MentorRelationInfo> _relationList = new List<MentorRelationInfo>();

		// Token: 0x04002F66 RID: 12134
		private List<MentorshipTaskInfo> _myMentorshipTaskList = new List<MentorshipTaskInfo>();

		// Token: 0x04002F67 RID: 12135
		private PupilApplyInfo _pupilApplyInfo = new PupilApplyInfo();

		// Token: 0x04002F68 RID: 12136
		private List<MasterApplyInfoItem> _masterApplyInfoList = new List<MasterApplyInfoItem>();

		// Token: 0x04002F69 RID: 12137
		private List<MentorBeenApplyedInfo> _beenApplyedInfoList = new List<MentorBeenApplyedInfo>();

		// Token: 0x04002F6A RID: 12138
		private MessageShowInfoItem _tempShowInfo = new MessageShowInfoItem();

		// Token: 0x04002F6B RID: 12139
		public CandidatesViewType CurViewType = CandidatesViewType.None;

		// Token: 0x04002F6C RID: 12140
		public CandidatesViewRecommendType CurRecommendType = CandidatesViewRecommendType.None;

		// Token: 0x04002F6D RID: 12141
		private string _mentorshipApplyWords = string.Empty;

		// Token: 0x04002F6E RID: 12142
		public int ReceiveingProtocolTime = 0;

		// Token: 0x04002F6F RID: 12143
		public ulong ClickedMainSceneRoleID = 0UL;

		// Token: 0x04002F70 RID: 12144
		public MentorApplyStatus ClickedRoleMentorshipStatus;

		// Token: 0x04002F71 RID: 12145
		private bool _hasRedPointOnTasks = false;

		// Token: 0x04002F72 RID: 12146
		private bool _tipIconHasRedPoint;

		// Token: 0x04002F73 RID: 12147
		private bool _hasApplyMsg;

		// Token: 0x04002F74 RID: 12148
		private int timeForReceive;

		// Token: 0x04002F75 RID: 12149
		private int _myApplyPupilRefreshTime = 0;

		// Token: 0x04002F76 RID: 12150
		private int _myApplyMasterRefreshTime = 0;

		// Token: 0x04002F77 RID: 12151
		private uint _countDownTimerID = 0U;
	}
}
