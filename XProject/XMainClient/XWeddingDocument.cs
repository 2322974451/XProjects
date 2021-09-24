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

	internal class XWeddingDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XWeddingDocument.uuID;
			}
		}

		public static XWeddingDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XWeddingDocument.uuID) as XWeddingDocument;
			}
		}

		public static WeddingLoverLiveness LoverLivenessTable
		{
			get
			{
				return XWeddingDocument.m_partnerLivenessTab;
			}
		}

		public List<LoverLivenessRecord> RecordList
		{
			get
			{
				return this.m_recordList;
			}
		}

		public List<RoleOutLookBrief> PartnerList
		{
			get
			{
				return this.m_PartnerList;
			}
		}

		public MarriageLevelInfo MarriageLevel
		{
			get
			{
				return this.m_MarriageLevel;
			}
		}

		public int MarriageLevelUp
		{
			get
			{
				return this.m_MarriageLevelUp;
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
					DlgBase<XFriendsView, XFriendsBehaviour>.singleton.SetRedPoint(TabIndex.Wedding, this.IsHadRedDot);
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

		public bool IsHadPrivilegeLevelUpRedPoint
		{
			get
			{
				return this.m_bLevelUpRedPoint;
			}
			set
			{
				bool flag = this.m_bLevelUpRedPoint != value;
				if (flag)
				{
					this.m_bLevelUpRedPoint = value;
					DlgBase<XFriendsView, XFriendsBehaviour>.singleton.SetRedPoint(TabIndex.Wedding, this.IsHadRedDot);
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
				bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Wedding);
				return !flag && (this.IsHadLivenessRedPoint || this.IsHadPrivilegeLevelUpRedPoint);
			}
		}

		public void ReqPartnerDetailInfo()
		{
			RpcC2M_GetMarriageRelation rpc = new RpcC2M_GetMarriageRelation();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetPartDetailInfoBack(GetMarriageRelationRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				this.m_PartnerList = oRes.infos;
				this.m_MarriageLevel = oRes.marriageLevel;
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.RefreshUi();
				}
			}
		}

		public RoleOutLookBrief GetTeamLoverRole()
		{
			for (int i = 0; i < this.m_PartnerList.Count; i++)
			{
				bool flag = this.m_PartnerList[i].roleid != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					return this.m_PartnerList[i];
				}
			}
			return null;
		}

		public void ReqPartnerLivenessInfo()
		{
			RpcC2M_GetMarriageLiveness rpc = new RpcC2M_GetMarriageLiveness();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetPartnerLivenessInfo(GetMarriageLivenessRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				this.CurrExp = oRes.liveness;
				this.m_takeChest = oRes.takedchest;
				this.m_recordList.Clear();
				for (int i = 0; i < oRes.record.Count; i++)
				{
					this.m_recordList.Add(new LoverLivenessRecord(oRes.record[i]));
				}
				this.IsHadLivenessRedPoint = this.IsHadRedPoint();
				bool flag2 = DlgBase<LoversLivenessDlg, LoversLivenessBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<LoversLivenessDlg, LoversLivenessBehaviour>.singleton.FillContent();
				}
			}
		}

		public void ReqTakePartnerChest(uint index)
		{
			RpcC2M_TakeMarriageChest rpcC2M_TakeMarriageChest = new RpcC2M_TakeMarriageChest();
			rpcC2M_TakeMarriageChest.oArg.index = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_TakeMarriageChest);
		}

		public void OnTakePartnerChestBack(int index, TakeMarriageChestRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				this.m_takeChest = oRes.takedchest;
				this.IsHadLivenessRedPoint = this.IsHadRedPoint();
				bool flag2 = DlgBase<LoversLivenessDlg, LoversLivenessBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<LoversLivenessDlg, LoversLivenessBehaviour>.singleton.ResetBoxRedDot(index - 1);
				}
			}
		}

		public int FindNeedShowReward()
		{
			bool flag = this.CurrExp >= XWeddingDocument.MaxExp;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				for (int i = 0; i < XWeddingDocument.m_partnerLivenessTab.Table.Length; i++)
				{
					bool flag2 = !this.IsChestOpened(i + 1);
					if (flag2)
					{
						return i;
					}
				}
				result = 0;
			}
			return result;
		}

		public bool IsHadRedPoint()
		{
			for (int i = 0; i < XWeddingDocument.m_partnerLivenessTab.Table.Length; i++)
			{
				bool flag = !this.IsChestOpened(i + 1) && this.CurrExp >= XWeddingDocument.m_partnerLivenessTab.Table[i].liveness;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsChestOpened(int index)
		{
			uint num = 1U << index;
			return (this.m_takeChest & num) > 0U;
		}

		public void OnMarriageNewPrivilegeNtf(int marriageLevelUp)
		{
			this.m_MarriageLevelUp = marriageLevelUp;
			MarriageLevel.RowData byLevel = XWeddingDocument.MarriageLevelTable.GetByLevel(marriageLevelUp);
			bool flag = byLevel != null;
			if (flag)
			{
				bool flag2 = byLevel.PrerogativeID != 0U || byLevel.PrivilegeBuffs[0] > 0U;
				if (flag2)
				{
					this.IsHadLivenessRedPoint = true;
				}
			}
			bool flag3 = this.View != null && this.View.IsVisible();
			if (flag3)
			{
				this.View.CheckMarriageLevelUp();
			}
		}

		public void GetMarriagePrivilege()
		{
			RpcC2M_GetMarriagePrivilege rpc = new RpcC2M_GetMarriagePrivilege();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetMarriagePrivilege(ErrorCode error)
		{
			bool flag = error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(error, "fece00");
			}
			else
			{
				this.m_MarriageLevelUp = 0;
				this.IsHadLivenessRedPoint = false;
			}
		}

		public void OnMarriageLevelValueChangeNtf(MarriageLevelValueNtfData data)
		{
			this.m_MarriageLevel = data.info;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshMarriageLevelValue();
			}
		}

		public uint AllAttendPlayerCount
		{
			get
			{
				return this.m_AllAttendPlayerCount;
			}
		}

		public WeddingBrief CurrWeddingInfo
		{
			get
			{
				return this.m_CurrWeddingInfo;
			}
		}

		public List<WeddingBriefInfo> CanEnterWedding
		{
			get
			{
				return this.m_CanEnterWedding;
			}
		}

		public List<WeddingBriefInfo> CanApplyWedding
		{
			get
			{
				return this.m_CanApplyWedding;
			}
		}

		public int LeftDivorceTime
		{
			get
			{
				return this.m_LeftDivorceTime - (int)Time.realtimeSinceStartup;
			}
			set
			{
				this.m_LeftDivorceTime = value + (int)Time.realtimeSinceStartup;
			}
		}

		public ulong DivorceApplyID
		{
			get
			{
				return this.m_DivorceApplyID;
			}
		}

		public bool PermitStranger
		{
			get
			{
				return this.m_PermitStranger;
			}
		}

		public int CoupleOfflineTime
		{
			get
			{
				return this.m_CoupleOfflineTime;
			}
		}

		public ulong MyWeddingID
		{
			get
			{
				return this.m_MyWeddingID;
			}
			set
			{
				this.m_MyWeddingID = value;
			}
		}

		public bool HasApplyCandidate
		{
			get
			{
				return this._hasApplyCandidate;
			}
			set
			{
				this._hasApplyCandidate = value;
				bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler != null && DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.IsVisible();
				if (flag)
				{
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.RefreshInviteRedPoint();
				}
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_OnEntityCreated, new XComponent.XEventHandler(this.OnEntityCreate));
			base.RegisterEvent(XEventDefine.XEvent_OnEntityDeleted, new XComponent.XEventHandler(this.OnEntityDelete));
		}

		private bool OnEntityCreate(XEventArgs args)
		{
			XOnEntityCreatedArgs xonEntityCreatedArgs = args as XOnEntityCreatedArgs;
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEDDING && xonEntityCreatedArgs.entity != null && xonEntityCreatedArgs.entity.IsRole && xonEntityCreatedArgs.entity.Attributes != null;
			if (flag)
			{
				bool flag2 = this.IsWeddingLover(xonEntityCreatedArgs.entity.Attributes.RoleID);
				if (flag2)
				{
					this.CreateLoverSceneFx(xonEntityCreatedArgs.entity);
				}
			}
			return true;
		}

		private bool OnEntityDelete(XEventArgs args)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEDDING;
			if (flag)
			{
				XOnEntityDeletedArgs xonEntityDeletedArgs = args as XOnEntityDeletedArgs;
				this.DeleteLoverSceneFx(xonEntityDeletedArgs.Id);
			}
			return true;
		}

		private void CreateLoverSceneFx(XEntity entity)
		{
			XFx xfx;
			bool flag = this.m_WeddingSceneLoverFx.TryGetValue(entity.Attributes.RoleID, out xfx) && xfx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(xfx, true);
			}
			xfx = XSingleton<XFxMgr>.singleton.CreateFx(XSingleton<XGlobalConfig>.singleton.GetValue("WeddingSceneLoverFx"), null, true);
			int renderLayer = LayerMask.NameToLayer("Role");
			xfx.SetRenderLayer(renderLayer);
			xfx.Play(entity.MoveObj, Vector3.zero, Vector3.one, 1f, true, false, "", 0f);
			this.m_WeddingSceneLoverFx[entity.Attributes.RoleID] = xfx;
		}

		private void DeleteLoverSceneFx(ulong roleID)
		{
			XFx xfx;
			bool flag = this.m_WeddingSceneLoverFx.TryGetValue(roleID, out xfx) && xfx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(xfx, true);
				this.m_WeddingSceneLoverFx[roleID] = null;
			}
		}

		private bool IsWeddingLover(ulong roleID)
		{
			bool flag = XWeddingDocument.Doc.CurrWeddingInfo != null && XWeddingDocument.Doc.CurrWeddingInfo.role1 != null && XWeddingDocument.Doc.CurrWeddingInfo.role2 != null;
			return flag && (roleID == XWeddingDocument.Doc.CurrWeddingInfo.role1.roleid || roleID == XWeddingDocument.Doc.CurrWeddingInfo.role2.roleid);
		}

		public MarriageStatus GetMyMarriageRelation()
		{
			return this.m_MyMarriageStatus;
		}

		public WeddingType GetMyWeddingType()
		{
			return this.m_WeddingType;
		}

		public List<WeddingRoleInfo> GetInviteRoleInfoList(WeddingInviteTab tab)
		{
			List<WeddingRoleInfo> result;
			switch (tab)
			{
			case WeddingInviteTab.WeddingFriends:
				result = this.m_FriendsWeddingRoleInfoList;
				break;
			case WeddingInviteTab.WeddingGuild:
				result = this.m_GuildWeddingRoleInfoList;
				break;
			case WeddingInviteTab.WeddingInvited:
				result = this.m_InvitedWeddingRoleInfoList;
				break;
			case WeddingInviteTab.WeddingApplyList:
				result = this.m_ApplyWeddingRoleInfoList;
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		public RoleOutLookBrief GetPartnerInfo()
		{
			bool flag = this.m_Marriagelist != null && this.m_Marriagelist.Count == 2;
			RoleOutLookBrief result;
			if (flag)
			{
				result = this.m_Marriagelist[1];
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void ReqHoldWedding()
		{
			RpcC2M_HoldWedding rpc = new RpcC2M_HoldWedding();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnHoldWedding(HoldWeddingRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		public void EnterWedding(ulong weddingID)
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			}
			RpcC2M_EnterWeddingScene rpcC2M_EnterWeddingScene = new RpcC2M_EnterWeddingScene();
			rpcC2M_EnterWeddingScene.oArg.weddingid = weddingID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_EnterWeddingScene);
		}

		public void OnEnterWedding(EnterWeddingSceneRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		public void OnWeddingLoadingInfoNtf(PtcG2C_WeddingLoadInfoNtf roPtc)
		{
			bool flag = roPtc.Data.info == null;
			if (!flag)
			{
				this.m_CurrWeddingInfo = roPtc.Data.info;
			}
		}

		public void WeddingSceneOperator(WeddingOperType type)
		{
			RpcC2G_WeddingOperator rpcC2G_WeddingOperator = new RpcC2G_WeddingOperator();
			rpcC2G_WeddingOperator.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_WeddingOperator);
		}

		public void OnWeddingSceneOperator(WeddingOperatorArg oArg, WeddingOperatorRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				bool flag2 = !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible() || DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler == null || !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.IsVisible();
				if (!flag2)
				{
					WeddingOperType type = oArg.type;
					if (type - WeddingOperType.WeddingOper_Flower > 1)
					{
						if (type == WeddingOperType.WeddingOper_ApplyVows)
						{
							DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.ApplyVowsSuss();
						}
					}
					else
					{
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.CoolDownBtn(oArg.type);
					}
				}
			}
		}

		public void WeddingSceneEventNtf(PtcG2C_WeddingEventNtf roPtc)
		{
			bool flag = !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible() || DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler == null || !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.IsVisible();
			if (!flag)
			{
				this.m_AllAttendPlayerCount = roPtc.Data.total_num;
				XSingleton<XDebug>.singleton.AddLog("Wedding Attend Player Count:" + this.m_AllAttendPlayerCount, null, null, null, null, null, XDebugColor.XDebug_None);
				switch (roPtc.Data.type)
				{
				case WeddingOperType.WeddingOper_Flower:
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.OnFlowerRain();
					break;
				case WeddingOperType.WeddingOper_Fireworks:
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.OnFireworks();
					break;
				case WeddingOperType.WeddingOper_ApplyVows:
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.ShowPartnerSwearNtf(roPtc.Data.rolename);
					break;
				case WeddingOperType.WeddingOper_DisAgreeVows:
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("WeddingSwearDisagree", new object[]
					{
						roPtc.Data.rolename
					}), "fece00");
					break;
				case WeddingOperType.WeddingOper_VowsPrepare:
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WeddingSwearAgree"), "fece00");
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.OnVowsPrepare();
					break;
				case WeddingOperType.WeddingOper_VowsStart:
					this.PlayCutscene(XSingleton<XGlobalConfig>.singleton.GetValue("WeddingCutscenePath"));
					break;
				case WeddingOperType.WeddingOper_FlowerRewardOverMax:
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("WeddingFlowerRewardMax"), "fece00");
					break;
				case WeddingOperType.WeddingOper_FireworksRewardOverMax:
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("WeddingFireworksRewardMax"), "fece00");
					break;
				case WeddingOperType.WeddingOper_CandyRewardOverMax:
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("WeddingCandyRewardMax"), "fece00");
					break;
				case WeddingOperType.WeddingOper_Candy:
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.OnCandyFx();
					break;
				}
			}
		}

		public void PlayCutscene(string path)
		{
			XSingleton<XCutScene>.singleton.Start(path, true, true);
		}

		public void WeddingStateNtf(PtcG2C_WeddingStateNtf roPtc)
		{
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible() && DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler != null && DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.UpdateWeddingState(roPtc.Data.state, roPtc.Data.lefttime, roPtc.Data.vows);
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.UpdateHappiness(roPtc.Data.happyness);
			}
		}

		public void WeddingInviteOperate(WeddingInviteOperType type, ulong roleID = 0UL, ulong weddingID = 0UL)
		{
			RpcC2M_WeddingInviteOperator rpcC2M_WeddingInviteOperator = new RpcC2M_WeddingInviteOperator();
			rpcC2M_WeddingInviteOperator.oArg.type = type;
			rpcC2M_WeddingInviteOperator.oArg.roleid = roleID;
			rpcC2M_WeddingInviteOperator.oArg.weddingid = weddingID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_WeddingInviteOperator);
		}

		public void OnWeddingInviteOperate(WeddingInviteOperatorArg oArg, WeddingInviteOperatorRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				bool flag2 = oArg.type == WeddingInviteOperType.Wedding_DisagreeApply || oArg.type == WeddingInviteOperType.Wedding_AgreeApply;
				if (flag2)
				{
					for (int i = this.m_ApplyWeddingRoleInfoList.Count - 1; i >= 0; i--)
					{
						bool flag3 = this.m_ApplyWeddingRoleInfoList[i].roleID == oArg.roleid;
						if (flag3)
						{
							this.m_ApplyWeddingRoleInfoList.RemoveAt(i);
							break;
						}
					}
					this.HasApplyCandidate = (this.m_ApplyWeddingRoleInfoList.Count > 0);
					bool flag4 = DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.IsVisible();
					if (flag4)
					{
						DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.RefreshUI();
					}
				}
			}
			else
			{
				bool flag5 = oArg.type == WeddingInviteOperType.Wedding_Apply;
				if (flag5)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WeddingApplySend"), "fece00");
					this.UpdateApplyWeddingState(oArg.weddingid, true);
				}
				bool flag6 = oArg.type == WeddingInviteOperType.Wedding_PermitStranger;
				if (flag6)
				{
					this.m_PermitStranger = true;
				}
				bool flag7 = oArg.type == WeddingInviteOperType.Wedding_ForbidStranger;
				if (flag7)
				{
					this.m_PermitStranger = false;
				}
				bool flag8 = oArg.type == WeddingInviteOperType.Wedding_Invite;
				if (flag8)
				{
					WeddingRoleInfo weddingRoleInfo = null;
					for (int j = this.m_FriendsWeddingRoleInfoList.Count - 1; j >= 0; j--)
					{
						bool flag9 = this.m_FriendsWeddingRoleInfoList[j].roleID == oArg.roleid;
						if (flag9)
						{
							weddingRoleInfo = this.m_FriendsWeddingRoleInfoList[j];
							this.m_FriendsWeddingRoleInfoList.RemoveAt(j);
							break;
						}
					}
					for (int k = this.m_GuildWeddingRoleInfoList.Count - 1; k >= 0; k--)
					{
						bool flag10 = this.m_GuildWeddingRoleInfoList[k].roleID == oArg.roleid;
						if (flag10)
						{
							weddingRoleInfo = this.m_GuildWeddingRoleInfoList[k];
							this.m_GuildWeddingRoleInfoList.RemoveAt(k);
							break;
						}
					}
					bool flag11 = weddingRoleInfo != null;
					if (flag11)
					{
						this.m_InvitedWeddingRoleInfoList.Add(weddingRoleInfo);
					}
					bool flag12 = DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.IsVisible();
					if (flag12)
					{
						DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.RefreshUI();
					}
				}
				bool flag13 = oArg.type == WeddingInviteOperType.Wedding_AgreeApply;
				if (flag13)
				{
					WeddingRoleInfo weddingRoleInfo2 = null;
					for (int l = this.m_ApplyWeddingRoleInfoList.Count - 1; l >= 0; l--)
					{
						bool flag14 = this.m_ApplyWeddingRoleInfoList[l].roleID == oArg.roleid;
						if (flag14)
						{
							weddingRoleInfo2 = this.m_ApplyWeddingRoleInfoList[l];
							this.m_ApplyWeddingRoleInfoList.RemoveAt(l);
							break;
						}
					}
					bool flag15 = weddingRoleInfo2 != null;
					if (flag15)
					{
						this.m_InvitedWeddingRoleInfoList.Add(weddingRoleInfo2);
					}
					this.HasApplyCandidate = (this.m_ApplyWeddingRoleInfoList.Count > 0);
					bool flag16 = DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.IsVisible();
					if (flag16)
					{
						DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.RefreshUI();
					}
				}
				bool flag17 = oArg.type == WeddingInviteOperType.Wedding_DisagreeApply;
				if (flag17)
				{
					for (int m = this.m_ApplyWeddingRoleInfoList.Count - 1; m >= 0; m--)
					{
						bool flag18 = this.m_ApplyWeddingRoleInfoList[m].roleID == oArg.roleid;
						if (flag18)
						{
							this.m_ApplyWeddingRoleInfoList.RemoveAt(m);
							break;
						}
					}
					this.HasApplyCandidate = (this.m_ApplyWeddingRoleInfoList.Count > 0);
					bool flag19 = DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.IsVisible();
					if (flag19)
					{
						DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.RefreshUI();
					}
				}
			}
		}

		public void WeddingInviteNtf(PtcM2C_WeddingInviteNtf roPtc)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				WeddingInviteOperType type = roPtc.Data.type;
				if (type <= WeddingInviteOperType.Wedding_Apply)
				{
					if (type != WeddingInviteOperType.Wedding_Invite)
					{
						if (type == WeddingInviteOperType.Wedding_Apply)
						{
							this.HasApplyCandidate = true;
						}
					}
					else
					{
						WeddingBrief weddinginfo = roPtc.Data.weddinginfo;
						this.m_NotifedWeddingID = weddinginfo.weddingid;
						XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("WeddingInviteNotifyTip"), weddinginfo.role1.name, weddinginfo.role2.name), XStringDefineProxy.GetString("WeddingInviteBtnNow"), XStringDefineProxy.GetString("WeddingInviteBtnWait"), new ButtonClickEventHandler(this.ToSendToEnterScene));
					}
				}
				else if (type != WeddingInviteOperType.Wedding_CarCutScene)
				{
					if (type == WeddingInviteOperType.Wedding_Start)
					{
						XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
						NoticeTable.RowData noticeData = specificDocument.GetNoticeData(NoticeType.NT_Wedding_INVITE_WORLD);
						bool flag2 = noticeData != null;
						if (flag2)
						{
							List<ChatParam> list = new List<ChatParam>();
							ChatParam chatParam = new ChatParam();
							chatParam.link = new ChatParamLink();
							chatParam.link.id = noticeData.linkparam;
							chatParam.link.param.Add(roPtc.Data.weddinginfo.weddingid);
							chatParam.link.content = noticeData.linkcontent;
							ChatParam chatParam2 = new ChatParam();
							chatParam2.role = new ChatParamRole();
							chatParam2.role.uniqueid = roPtc.Data.weddinginfo.role1.roleid;
							chatParam2.role.name = roPtc.Data.weddinginfo.role1.name;
							chatParam2.role.profession = roPtc.Data.weddinginfo.role1.profession;
							ChatParam chatParam3 = new ChatParam();
							chatParam3.role = new ChatParamRole();
							chatParam3.role.uniqueid = roPtc.Data.weddinginfo.role2.roleid;
							chatParam3.role.name = roPtc.Data.weddinginfo.role2.name;
							chatParam3.role.profession = roPtc.Data.weddinginfo.role2.profession;
							list.Add(chatParam2);
							list.Add(chatParam3);
							list.Add(chatParam);
							DlgBase<XChatView, XChatBehaviour>.singleton.SendChatContent(noticeData.info, (ChatChannelType)noticeData.channel, false, list, true, 0UL, 0f, false, false);
						}
					}
				}
				else
				{
					bool flag3 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
					if (flag3)
					{
					}
				}
			}
		}

		private bool ToSendToEnterScene(IXUIButton button)
		{
			bool flag = this.m_NotifedWeddingID > 0UL;
			if (flag)
			{
				this.EnterWedding(this.m_NotifedWeddingID);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.m_NotifedWeddingID = 0UL;
			return true;
		}

		public void GetAllWeddingInfo()
		{
			RpcC2M_GetAllWeddingInfo rpc = new RpcC2M_GetAllWeddingInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetAllWeddingInfo(GetAllWeddingInfoRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				this.m_CanEnterWedding.Clear();
				for (int i = 0; i < oRes.can_enter.Count; i++)
				{
					WeddingBriefInfo weddingBriefInfo = new WeddingBriefInfo();
					weddingBriefInfo.brief = oRes.can_enter[i];
					weddingBriefInfo.isApply = false;
					this.m_CanEnterWedding.Add(weddingBriefInfo);
				}
				this.m_CanApplyWedding.Clear();
				for (int j = 0; j < oRes.can_apply.Count; j++)
				{
					WeddingBriefInfo weddingBriefInfo2 = new WeddingBriefInfo();
					weddingBriefInfo2.brief = oRes.can_apply[j];
					weddingBriefInfo2.isApply = oRes.is_apply[j];
					this.m_CanApplyWedding.Add(weddingBriefInfo2);
				}
				this.m_CanEnterWedding.Sort(new Comparison<WeddingBriefInfo>(XWeddingDocument.SortWeddingInfo));
				this.m_CanApplyWedding.Sort(new Comparison<WeddingBriefInfo>(XWeddingDocument.SortWeddingInfo));
				bool flag2 = DlgBase<WeddingEnterApplyView, WeddingEnterApplyBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<WeddingEnterApplyView, WeddingEnterApplyBehaviour>.singleton.RefreshInfo();
				}
			}
		}

		private static int SortWeddingInfo(WeddingBriefInfo info1, WeddingBriefInfo info2)
		{
			bool flag = info1.brief.type != info2.brief.type;
			int result;
			if (flag)
			{
				result = info2.brief.type - info1.brief.type;
			}
			else
			{
				result = (int)(info1.brief.lefttime - info2.brief.lefttime);
			}
			return result;
		}

		private void UpdateApplyWeddingState(ulong weddingid, bool isApply)
		{
			for (int i = 0; i < this.m_CanApplyWedding.Count; i++)
			{
				bool flag = this.m_CanApplyWedding[i].brief.weddingid == weddingid;
				if (flag)
				{
					this.m_CanApplyWedding[i].isApply = true;
				}
			}
		}

		public void GetWeddingInviteInfo()
		{
			RpcC2M_GetWeddingInviteInfo rpc = new RpcC2M_GetWeddingInviteInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetWeddingInviteInfo(GetWeddingInviteInfoRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				this.m_PermitStranger = oRes.permitstranger;
				this.m_MyWeddingID = oRes.weddingid;
				this.m_FriendsWeddingRoleInfoList.Clear();
				for (int i = 0; i < oRes.friends.Count; i++)
				{
					WeddingRoleBrief weddingRoleBrief = oRes.friends[i];
					this.m_FriendsWeddingRoleInfoList.Add(new WeddingRoleInfo
					{
						roleID = weddingRoleBrief.roleid,
						name = weddingRoleBrief.name,
						profession = weddingRoleBrief.profession,
						level = weddingRoleBrief.level,
						ppt = weddingRoleBrief.ppt,
						guildName = weddingRoleBrief.guildname
					});
				}
				this.m_GuildWeddingRoleInfoList.Clear();
				for (int j = 0; j < oRes.guildmembers.Count; j++)
				{
					WeddingRoleBrief weddingRoleBrief2 = oRes.guildmembers[j];
					this.m_GuildWeddingRoleInfoList.Add(new WeddingRoleInfo
					{
						roleID = weddingRoleBrief2.roleid,
						name = weddingRoleBrief2.name,
						profession = weddingRoleBrief2.profession,
						level = weddingRoleBrief2.level,
						ppt = weddingRoleBrief2.ppt,
						guildName = weddingRoleBrief2.guildname
					});
				}
				this.m_InvitedWeddingRoleInfoList.Clear();
				for (int k = 0; k < oRes.invitelist.Count; k++)
				{
					WeddingRoleBrief weddingRoleBrief3 = oRes.invitelist[k];
					this.m_InvitedWeddingRoleInfoList.Add(new WeddingRoleInfo
					{
						roleID = weddingRoleBrief3.roleid,
						name = weddingRoleBrief3.name,
						profession = weddingRoleBrief3.profession,
						level = weddingRoleBrief3.level,
						ppt = weddingRoleBrief3.ppt,
						guildName = weddingRoleBrief3.guildname,
						entered = oRes.invite_enter[k]
					});
				}
				this.m_ApplyWeddingRoleInfoList.Clear();
				for (int l = 0; l < oRes.applylist.Count; l++)
				{
					WeddingRoleBrief weddingRoleBrief4 = oRes.applylist[l];
					this.m_ApplyWeddingRoleInfoList.Add(new WeddingRoleInfo
					{
						roleID = weddingRoleBrief4.roleid,
						name = weddingRoleBrief4.name,
						profession = weddingRoleBrief4.profession,
						level = weddingRoleBrief4.level,
						ppt = weddingRoleBrief4.ppt,
						guildName = weddingRoleBrief4.guildname
					});
				}
				this.HasApplyCandidate = (this.m_ApplyWeddingRoleInfoList.Count > 0);
				bool flag2 = DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.RefreshUI();
				}
			}
		}

		public void SendMarriageRelationInfo()
		{
			RpcC2M_GetMarriageRelation rpc = new RpcC2M_GetMarriageRelation();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetMarriageRelationInfo(GetMarriageRelationRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				this.m_Marriagelist = oRes.infos;
				this.m_MyMarriageStatus = oRes.marriageStatus;
				this.m_WeddingType = oRes.type;
				this.LeftDivorceTime = oRes.leftDivorceTime;
				this.m_DivorceApplyID = oRes.applyDivorceID;
				this.m_CoupleOfflineTime = oRes.coupleOfflineTime;
				XWeddingDramaOperate xweddingDramaOperate = this.IsNpcDialogVisible();
				bool flag2 = xweddingDramaOperate != null;
				if (flag2)
				{
					xweddingDramaOperate.RefreshOperateStatus();
				}
			}
		}

		private XWeddingDramaOperate IsNpcDialogVisible()
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XDramaDocument specificDocument = XDocuments.GetSpecificDocument<XDramaDocument>(XDramaDocument.uuID);
				XDramaOperate openedOperate = specificDocument.GetOpenedOperate(XSysDefine.XSys_Wedding);
				bool flag2 = openedOperate != null;
				if (flag2)
				{
					XWeddingDramaOperate xweddingDramaOperate = openedOperate as XWeddingDramaOperate;
					bool flag3 = xweddingDramaOperate != null;
					if (flag3)
					{
						return xweddingDramaOperate;
					}
				}
			}
			return null;
		}

		public void SendMarriageOp(MarriageOpType op, WeddingType type = WeddingType.WeddingType_Normal, ulong roleID = 0UL)
		{
			RpcC2M_MarriageRelationOp rpcC2M_MarriageRelationOp = new RpcC2M_MarriageRelationOp();
			rpcC2M_MarriageRelationOp.oArg.opType = op;
			rpcC2M_MarriageRelationOp.oArg.type = type;
			rpcC2M_MarriageRelationOp.oArg.destRoleID = roleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_MarriageRelationOp);
		}

		public void OnGetMarriageRelationOp(MarriageRelationOpArg oarg, MarriageRelationOpRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_SUCCESS && oarg.opType == MarriageOpType.MarriageOpType_MarryAgree;
			if (flag)
			{
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
				if (flag2)
				{
					DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
					XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MarriageSuccessTip")), oRes.oppoRoleName), XStringDefineProxy.GetString("PVPActivity_Go"), new ButtonClickEventHandler(XWeddingDocument.Doc.GoToNpc), 50);
					return;
				}
			}
			XWeddingDramaOperate xweddingDramaOperate = this.IsNpcDialogVisible();
			bool flag3 = xweddingDramaOperate != null;
			if (flag3)
			{
				xweddingDramaOperate.RefreshMarriageOp(oarg, oRes);
			}
		}

		public void OnGetMarriageApplyNotify(PtcM2C_NotifyMarriageApply roPtc)
		{
			MarriageApplyInfo applyInfo = roPtc.Data.applyInfo;
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null || XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
			if (flag)
			{
				bool flag2 = applyInfo != null;
				if (flag2)
				{
					this.m_CachedData = applyInfo;
					this.m_CacheNotify = NotifyType.NotifyToApprove;
				}
			}
			else
			{
				bool flag3 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
				if (flag3)
				{
					bool flag4 = applyInfo != null;
					if (flag4)
					{
						this.m_ApplyMarriageRoleID = roPtc.Data.applyInfo.applyRoleID;
						XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("WeddingApplyTip"), applyInfo.applyName), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.ToAgreeMarriage), new ButtonClickEventHandler(this.ToRefuseMarriage), false, XTempTipDefine.OD_START, 50);
					}
					bool flag5 = roPtc.Data.response != null;
					if (flag5)
					{
						bool isAgree = roPtc.Data.response.isAgree;
						bool flag6 = isAgree;
						if (flag6)
						{
							XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("MarriageSuccessTip")), roPtc.Data.response.roleName), XStringDefineProxy.GetString("PVPActivity_Go"), new ButtonClickEventHandler(this.GoToNpc), 50);
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("WeddingApplyBeenRefuse", new object[]
							{
								roPtc.Data.response.roleName
							}), new object[0]), "fece00");
						}
					}
				}
			}
		}

		public bool GoToNpc(IXUIButton button)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc((uint)XSingleton<XGlobalConfig>.singleton.GetInt("LoveGoldNpcID"));
			return true;
		}

		public void OnGetMarriageDivorceNotify(PtcM2C_NotifyMarriageDivorceApply roPtc)
		{
			bool isApplyCancel = roPtc.Data.isApplyCancel;
			if (isApplyCancel)
			{
				bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
				if (flag)
				{
					string @string = XStringDefineProxy.GetString("WeddingMaintainSuccess");
					XSingleton<UiUtility>.singleton.ShowModalDialog(@string, XStringDefineProxy.GetString("COMMON_OK"));
				}
			}
			else
			{
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
				if (flag2)
				{
					this.m_CacheNotify = NotifyType.NotifyToBreak;
					this.m_CachedData = roPtc.Data.leftTime;
				}
				else
				{
					string format = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("WeddingBreakNotifyTip"));
					XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(format, XSingleton<UiUtility>.singleton.TimeDuarationFormatString(roPtc.Data.leftTime, 5)), XStringDefineProxy.GetString("COMMON_OK"));
				}
			}
		}

		public void SendWeddingCar()
		{
			RpcC2M_StartWeddingCar rpc = new RpcC2M_StartWeddingCar();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetWeddingCarNtf(PtcG2C_WeddingCarNtf roPtc)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("WeddingCarLocalOn");
				bool flag2 = @int > 0;
				if (flag2)
				{
					this.StopWeddingCar(null);
					this._weddingCarTimer = XSingleton<XTimerMgr>.singleton.SetTimer((float)XSingleton<XGlobalConfig>.singleton.GetInt("WeddingPatrolTime"), new XTimerMgr.ElapsedEventHandler(this.StopWeddingCar), null);
					UnitAppearance role = roPtc.Data.role1;
					UnitAppearance role2 = roPtc.Data.role2;
					XAttributes attributesWithAppearance = XSingleton<XEntityMgr>.singleton.GetAttributesWithAppearance(role);
					XRoleAttributes xroleAttributes = attributesWithAppearance as XRoleAttributes;
					xroleAttributes.IsLocalFake = true;
					XAttributes attributesWithAppearance2 = XSingleton<XEntityMgr>.singleton.GetAttributesWithAppearance(role2);
					xroleAttributes = (attributesWithAppearance2 as XRoleAttributes);
					xroleAttributes.IsLocalFake = true;
					List<float> floatList = XSingleton<XGlobalConfig>.singleton.GetFloatList("WeddingcarParadeStart");
					this._player1 = XSingleton<XEntityMgr>.singleton.CreateRole(attributesWithAppearance, new Vector3(floatList[0], floatList[1], floatList[2]), Quaternion.identity, false, false);
					this._mount = XSingleton<XEntityMgr>.singleton.CreateMount((uint)XSingleton<XGlobalConfig>.singleton.GetInt("WeddingCarID"), this._player1, true);
					this._player2 = XSingleton<XEntityMgr>.singleton.CreateRole(attributesWithAppearance2, new Vector3(floatList[0], floatList[1], floatList[2]), Quaternion.identity, false, false);
					bool flag3 = this._player1.Mount.MountCopilot(this._player2);
					XSingleton<XDebug>.singleton.AddLog(flag3.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
					string value = XSingleton<XGlobalConfig>.singleton.GetValue("WeddingPatrolAITree");
					bool flag4 = this._player1.AI == null;
					if (flag4)
					{
						this._player1.AI = (XSingleton<XComponentMgr>.singleton.CreateComponent(this._player1, XAIComponent.uuID) as XAIComponent);
						this._player1.AI.InitVariables();
						this._player1.AI.SetFixVariables();
					}
					bool flag5 = this._player1.Nav == null;
					if (flag5)
					{
						this._player1.Nav = (XSingleton<XComponentMgr>.singleton.CreateComponent(this._player1, XNavigationComponent.uuID) as XNavigationComponent);
						this._player1.Nav.Active();
					}
					this._player1.AI.Patrol.InitNavPath(XSingleton<XGlobalConfig>.singleton.GetValue("WeddingPatrolPath"), XPatrol.PathType.PT_NORMAL);
					this._player1.AI.SetBehaviorTree(value);
				}
			}
		}

		private void StopWeddingCar(object param)
		{
			bool flag = this._weddingCarTimer > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._weddingCarTimer);
				this._weddingCarTimer = 0U;
				this.DestroyFakeRoles();
			}
		}

		private bool ToRefuseMarriage(IXUIButton button)
		{
			bool flag = this.m_ApplyMarriageRoleID > 0UL;
			if (flag)
			{
				this.SendMarriageOp(MarriageOpType.MarriageOpType_MarryRefuse, WeddingType.WeddingType_Luxury, this.m_ApplyMarriageRoleID);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.m_ApplyMarriageRoleID = 0UL;
			return true;
		}

		private bool ToAgreeMarriage(IXUIButton button)
		{
			bool flag = this.m_ApplyMarriageRoleID > 0UL;
			if (flag)
			{
				this.SendMarriageOp(MarriageOpType.MarriageOpType_MarryAgree, WeddingType.WeddingType_Luxury, this.m_ApplyMarriageRoleID);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.m_ApplyMarriageRoleID = 0UL;
			return true;
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XWeddingDocument.AsyncLoader.AddTask("Table/WeddingLoverLiveness", XWeddingDocument.m_partnerLivenessTab, false);
			XWeddingDocument.AsyncLoader.AddTask("Table/MarriageLevel", XWeddingDocument.MarriageLevelTable, false);
			XWeddingDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
			bool flag = XWeddingDocument.m_partnerLivenessTab.Table.Length != 0;
			if (flag)
			{
				XWeddingDocument.MaxExp = XWeddingDocument.m_partnerLivenessTab.Table[XWeddingDocument.m_partnerLivenessTab.Table.Length - 1].liveness;
			}
			bool flag2 = XWeddingDocument.MarriageLevelTable.Table.Length != 0;
			if (flag2)
			{
				XWeddingDocument.MaxMarriageLevel = XWeddingDocument.MarriageLevelTable.Table[XWeddingDocument.MarriageLevelTable.Table.Length - 1].Level;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				NotifyType cacheNotify = this.m_CacheNotify;
				if (cacheNotify != NotifyType.NotifyToBreak)
				{
					if (cacheNotify == NotifyType.NotifyToApprove)
					{
						MarriageApplyInfo marriageApplyInfo = this.m_CachedData as MarriageApplyInfo;
						bool flag2 = marriageApplyInfo != null;
						if (flag2)
						{
							this.m_ApplyMarriageRoleID = marriageApplyInfo.applyRoleID;
							XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("WeddingApplyTip"), marriageApplyInfo.applyName), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.ToAgreeMarriage), new ButtonClickEventHandler(this.ToRefuseMarriage), false, XTempTipDefine.OD_START, 50);
						}
					}
				}
				else
				{
					string format = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("WeddingBreakNotifyTip"));
					XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(format, XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this.m_CachedData, 5)), XStringDefineProxy.GetString("COMMON_OK"));
				}
				this.m_CacheNotify = NotifyType.None;
			}
		}

		public override void OnLeaveScene()
		{
			this.StopWeddingCar(null);
		}

		private void DestroyFakeRoles()
		{
			XPetDocument.TryMount(false, this._player1, (uint)XSingleton<XGlobalConfig>.singleton.GetInt("WeddingCarID"), true);
			XSingleton<XEntityMgr>.singleton.DestroyImmediate(this._player1);
			this._player1 = null;
			XSingleton<XEntityMgr>.singleton.DestroyImmediate(this._player2);
			this._player2 = null;
			XSingleton<XEntityMgr>.singleton.DestroyEntity(this._mount);
			this._mount = null;
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = this._player1 != null;
			if (flag)
			{
				this._player1.Update(fDeltaT);
			}
			bool flag2 = this._player2 != null;
			if (flag2)
			{
				this._player2.Update(fDeltaT);
			}
		}

		public override void PostUpdate(float fDeltaT)
		{
			base.PostUpdate(fDeltaT);
			bool flag = this._player1 != null;
			if (flag)
			{
				this._player1.PostUpdate(fDeltaT);
			}
			bool flag2 = this._player2 != null;
			if (flag2)
			{
				this._player2.PostUpdate(fDeltaT);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("WeddingDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static MarriageLevel MarriageLevelTable = new MarriageLevel();

		private static WeddingLoverLiveness m_partnerLivenessTab = new WeddingLoverLiveness();

		private List<LoverLivenessRecord> m_recordList = new List<LoverLivenessRecord>();

		public static readonly int MaxAvata = 2;

		public FriendsWeddingHandler View;

		private List<RoleOutLookBrief> m_PartnerList = new List<RoleOutLookBrief>();

		private MarriageLevelInfo m_MarriageLevel;

		private int m_MarriageLevelUp = 0;

		public static int MaxMarriageLevel;

		public uint CurrExp = 0U;

		private uint m_takeChest = 0U;

		public static uint MaxExp = 0U;

		private bool m_bIsHadLivenessRedPoint = false;

		private bool m_bLevelUpRedPoint = false;

		private List<WeddingBriefInfo> m_CanEnterWedding = new List<WeddingBriefInfo>();

		private List<WeddingBriefInfo> m_CanApplyWedding = new List<WeddingBriefInfo>();

		private MarriageStatus m_MyMarriageStatus = MarriageStatus.MarriageStatus_Null;

		private ulong m_NotifedWeddingID = 0UL;

		private ulong m_ApplyMarriageRoleID = 0UL;

		private int m_LeftDivorceTime = 0;

		private ulong m_DivorceApplyID = 0UL;

		private bool m_PermitStranger = false;

		private ulong m_MyWeddingID;

		private int m_CoupleOfflineTime = 0;

		private WeddingType m_WeddingType = WeddingType.WeddingType_Normal;

		private List<WeddingRoleInfo> m_FriendsWeddingRoleInfoList = new List<WeddingRoleInfo>();

		private List<WeddingRoleInfo> m_GuildWeddingRoleInfoList = new List<WeddingRoleInfo>();

		private List<WeddingRoleInfo> m_InvitedWeddingRoleInfoList = new List<WeddingRoleInfo>();

		private List<WeddingRoleInfo> m_ApplyWeddingRoleInfoList = new List<WeddingRoleInfo>();

		private List<RoleOutLookBrief> m_Marriagelist = new List<RoleOutLookBrief>();

		private WeddingBrief m_CurrWeddingInfo = null;

		private NotifyType m_CacheNotify = NotifyType.None;

		private object m_CachedData = null;

		private uint m_AllAttendPlayerCount = 0U;

		private XRole _player1;

		private XRole _player2;

		private XMount _mount;

		private uint _weddingCarTimer = 0U;

		private bool _hasApplyCandidate = false;

		private Dictionary<ulong, XFx> m_WeddingSceneLoverFx = new Dictionary<ulong, XFx>();
	}
}
