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
	// Token: 0x02000A0A RID: 2570
	internal class XWeddingDocument : XDocComponent
	{
		// Token: 0x17002E92 RID: 11922
		// (get) Token: 0x06009D5B RID: 40283 RVA: 0x00199C4C File Offset: 0x00197E4C
		public override uint ID
		{
			get
			{
				return XWeddingDocument.uuID;
			}
		}

		// Token: 0x17002E93 RID: 11923
		// (get) Token: 0x06009D5C RID: 40284 RVA: 0x00199C64 File Offset: 0x00197E64
		public static XWeddingDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XWeddingDocument.uuID) as XWeddingDocument;
			}
		}

		// Token: 0x17002E94 RID: 11924
		// (get) Token: 0x06009D5D RID: 40285 RVA: 0x00199C90 File Offset: 0x00197E90
		public static WeddingLoverLiveness LoverLivenessTable
		{
			get
			{
				return XWeddingDocument.m_partnerLivenessTab;
			}
		}

		// Token: 0x17002E95 RID: 11925
		// (get) Token: 0x06009D5E RID: 40286 RVA: 0x00199CA8 File Offset: 0x00197EA8
		public List<LoverLivenessRecord> RecordList
		{
			get
			{
				return this.m_recordList;
			}
		}

		// Token: 0x17002E96 RID: 11926
		// (get) Token: 0x06009D5F RID: 40287 RVA: 0x00199CC0 File Offset: 0x00197EC0
		public List<RoleOutLookBrief> PartnerList
		{
			get
			{
				return this.m_PartnerList;
			}
		}

		// Token: 0x17002E97 RID: 11927
		// (get) Token: 0x06009D60 RID: 40288 RVA: 0x00199CD8 File Offset: 0x00197ED8
		public MarriageLevelInfo MarriageLevel
		{
			get
			{
				return this.m_MarriageLevel;
			}
		}

		// Token: 0x17002E98 RID: 11928
		// (get) Token: 0x06009D61 RID: 40289 RVA: 0x00199CF0 File Offset: 0x00197EF0
		public int MarriageLevelUp
		{
			get
			{
				return this.m_MarriageLevelUp;
			}
		}

		// Token: 0x17002E99 RID: 11929
		// (get) Token: 0x06009D62 RID: 40290 RVA: 0x00199D08 File Offset: 0x00197F08
		// (set) Token: 0x06009D63 RID: 40291 RVA: 0x00199D20 File Offset: 0x00197F20
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

		// Token: 0x17002E9A RID: 11930
		// (get) Token: 0x06009D64 RID: 40292 RVA: 0x00199DA8 File Offset: 0x00197FA8
		// (set) Token: 0x06009D65 RID: 40293 RVA: 0x00199DC0 File Offset: 0x00197FC0
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

		// Token: 0x17002E9B RID: 11931
		// (get) Token: 0x06009D66 RID: 40294 RVA: 0x00199E48 File Offset: 0x00198048
		public bool IsHadRedDot
		{
			get
			{
				bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Wedding);
				return !flag && (this.IsHadLivenessRedPoint || this.IsHadPrivilegeLevelUpRedPoint);
			}
		}

		// Token: 0x06009D67 RID: 40295 RVA: 0x00199E88 File Offset: 0x00198088
		public void ReqPartnerDetailInfo()
		{
			RpcC2M_GetMarriageRelation rpc = new RpcC2M_GetMarriageRelation();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009D68 RID: 40296 RVA: 0x00199EA8 File Offset: 0x001980A8
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

		// Token: 0x06009D69 RID: 40297 RVA: 0x00199F1C File Offset: 0x0019811C
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

		// Token: 0x06009D6A RID: 40298 RVA: 0x00199F84 File Offset: 0x00198184
		public void ReqPartnerLivenessInfo()
		{
			RpcC2M_GetMarriageLiveness rpc = new RpcC2M_GetMarriageLiveness();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009D6B RID: 40299 RVA: 0x00199FA4 File Offset: 0x001981A4
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

		// Token: 0x06009D6C RID: 40300 RVA: 0x0019A060 File Offset: 0x00198260
		public void ReqTakePartnerChest(uint index)
		{
			RpcC2M_TakeMarriageChest rpcC2M_TakeMarriageChest = new RpcC2M_TakeMarriageChest();
			rpcC2M_TakeMarriageChest.oArg.index = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_TakeMarriageChest);
		}

		// Token: 0x06009D6D RID: 40301 RVA: 0x0019A090 File Offset: 0x00198290
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

		// Token: 0x06009D6E RID: 40302 RVA: 0x0019A0FC File Offset: 0x001982FC
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

		// Token: 0x06009D6F RID: 40303 RVA: 0x0019A15C File Offset: 0x0019835C
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

		// Token: 0x06009D70 RID: 40304 RVA: 0x0019A1C0 File Offset: 0x001983C0
		public bool IsChestOpened(int index)
		{
			uint num = 1U << index;
			return (this.m_takeChest & num) > 0U;
		}

		// Token: 0x06009D71 RID: 40305 RVA: 0x0019A1E4 File Offset: 0x001983E4
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

		// Token: 0x06009D72 RID: 40306 RVA: 0x0019A260 File Offset: 0x00198460
		public void GetMarriagePrivilege()
		{
			RpcC2M_GetMarriagePrivilege rpc = new RpcC2M_GetMarriagePrivilege();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009D73 RID: 40307 RVA: 0x0019A280 File Offset: 0x00198480
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

		// Token: 0x06009D74 RID: 40308 RVA: 0x0019A2BC File Offset: 0x001984BC
		public void OnMarriageLevelValueChangeNtf(MarriageLevelValueNtfData data)
		{
			this.m_MarriageLevel = data.info;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshMarriageLevelValue();
			}
		}

		// Token: 0x17002E9C RID: 11932
		// (get) Token: 0x06009D75 RID: 40309 RVA: 0x0019A2FC File Offset: 0x001984FC
		public uint AllAttendPlayerCount
		{
			get
			{
				return this.m_AllAttendPlayerCount;
			}
		}

		// Token: 0x17002E9D RID: 11933
		// (get) Token: 0x06009D76 RID: 40310 RVA: 0x0019A314 File Offset: 0x00198514
		public WeddingBrief CurrWeddingInfo
		{
			get
			{
				return this.m_CurrWeddingInfo;
			}
		}

		// Token: 0x17002E9E RID: 11934
		// (get) Token: 0x06009D77 RID: 40311 RVA: 0x0019A32C File Offset: 0x0019852C
		public List<WeddingBriefInfo> CanEnterWedding
		{
			get
			{
				return this.m_CanEnterWedding;
			}
		}

		// Token: 0x17002E9F RID: 11935
		// (get) Token: 0x06009D78 RID: 40312 RVA: 0x0019A344 File Offset: 0x00198544
		public List<WeddingBriefInfo> CanApplyWedding
		{
			get
			{
				return this.m_CanApplyWedding;
			}
		}

		// Token: 0x17002EA0 RID: 11936
		// (get) Token: 0x06009D79 RID: 40313 RVA: 0x0019A35C File Offset: 0x0019855C
		// (set) Token: 0x06009D7A RID: 40314 RVA: 0x0019A37B File Offset: 0x0019857B
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

		// Token: 0x17002EA1 RID: 11937
		// (get) Token: 0x06009D7B RID: 40315 RVA: 0x0019A38C File Offset: 0x0019858C
		public ulong DivorceApplyID
		{
			get
			{
				return this.m_DivorceApplyID;
			}
		}

		// Token: 0x17002EA2 RID: 11938
		// (get) Token: 0x06009D7C RID: 40316 RVA: 0x0019A3A4 File Offset: 0x001985A4
		public bool PermitStranger
		{
			get
			{
				return this.m_PermitStranger;
			}
		}

		// Token: 0x17002EA3 RID: 11939
		// (get) Token: 0x06009D7D RID: 40317 RVA: 0x0019A3BC File Offset: 0x001985BC
		public int CoupleOfflineTime
		{
			get
			{
				return this.m_CoupleOfflineTime;
			}
		}

		// Token: 0x17002EA4 RID: 11940
		// (get) Token: 0x06009D7E RID: 40318 RVA: 0x0019A3D4 File Offset: 0x001985D4
		// (set) Token: 0x06009D7F RID: 40319 RVA: 0x0019A3EC File Offset: 0x001985EC
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

		// Token: 0x17002EA5 RID: 11941
		// (get) Token: 0x06009D80 RID: 40320 RVA: 0x0019A3F8 File Offset: 0x001985F8
		// (set) Token: 0x06009D81 RID: 40321 RVA: 0x0019A410 File Offset: 0x00198610
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

		// Token: 0x06009D82 RID: 40322 RVA: 0x0019A457 File Offset: 0x00198657
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_OnEntityCreated, new XComponent.XEventHandler(this.OnEntityCreate));
			base.RegisterEvent(XEventDefine.XEvent_OnEntityDeleted, new XComponent.XEventHandler(this.OnEntityDelete));
		}

		// Token: 0x06009D83 RID: 40323 RVA: 0x0019A48C File Offset: 0x0019868C
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

		// Token: 0x06009D84 RID: 40324 RVA: 0x0019A50C File Offset: 0x0019870C
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

		// Token: 0x06009D85 RID: 40325 RVA: 0x0019A548 File Offset: 0x00198748
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

		// Token: 0x06009D86 RID: 40326 RVA: 0x0019A5FC File Offset: 0x001987FC
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

		// Token: 0x06009D87 RID: 40327 RVA: 0x0019A644 File Offset: 0x00198844
		private bool IsWeddingLover(ulong roleID)
		{
			bool flag = XWeddingDocument.Doc.CurrWeddingInfo != null && XWeddingDocument.Doc.CurrWeddingInfo.role1 != null && XWeddingDocument.Doc.CurrWeddingInfo.role2 != null;
			return flag && (roleID == XWeddingDocument.Doc.CurrWeddingInfo.role1.roleid || roleID == XWeddingDocument.Doc.CurrWeddingInfo.role2.roleid);
		}

		// Token: 0x06009D88 RID: 40328 RVA: 0x0019A6C4 File Offset: 0x001988C4
		public MarriageStatus GetMyMarriageRelation()
		{
			return this.m_MyMarriageStatus;
		}

		// Token: 0x06009D89 RID: 40329 RVA: 0x0019A6DC File Offset: 0x001988DC
		public WeddingType GetMyWeddingType()
		{
			return this.m_WeddingType;
		}

		// Token: 0x06009D8A RID: 40330 RVA: 0x0019A6F4 File Offset: 0x001988F4
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

		// Token: 0x06009D8B RID: 40331 RVA: 0x0019A748 File Offset: 0x00198948
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

		// Token: 0x06009D8C RID: 40332 RVA: 0x0019A788 File Offset: 0x00198988
		public void ReqHoldWedding()
		{
			RpcC2M_HoldWedding rpc = new RpcC2M_HoldWedding();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009D8D RID: 40333 RVA: 0x0019A7A8 File Offset: 0x001989A8
		public void OnHoldWedding(HoldWeddingRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x06009D8E RID: 40334 RVA: 0x0019A7DC File Offset: 0x001989DC
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

		// Token: 0x06009D8F RID: 40335 RVA: 0x0019A824 File Offset: 0x00198A24
		public void OnEnterWedding(EnterWeddingSceneRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x06009D90 RID: 40336 RVA: 0x0019A858 File Offset: 0x00198A58
		public void OnWeddingLoadingInfoNtf(PtcG2C_WeddingLoadInfoNtf roPtc)
		{
			bool flag = roPtc.Data.info == null;
			if (!flag)
			{
				this.m_CurrWeddingInfo = roPtc.Data.info;
			}
		}

		// Token: 0x06009D91 RID: 40337 RVA: 0x0019A88C File Offset: 0x00198A8C
		public void WeddingSceneOperator(WeddingOperType type)
		{
			RpcC2G_WeddingOperator rpcC2G_WeddingOperator = new RpcC2G_WeddingOperator();
			rpcC2G_WeddingOperator.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_WeddingOperator);
		}

		// Token: 0x06009D92 RID: 40338 RVA: 0x0019A8BC File Offset: 0x00198ABC
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

		// Token: 0x06009D93 RID: 40339 RVA: 0x0019A968 File Offset: 0x00198B68
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

		// Token: 0x06009D94 RID: 40340 RVA: 0x0019AB6C File Offset: 0x00198D6C
		public void PlayCutscene(string path)
		{
			XSingleton<XCutScene>.singleton.Start(path, true, true);
		}

		// Token: 0x06009D95 RID: 40341 RVA: 0x0019AB80 File Offset: 0x00198D80
		public void WeddingStateNtf(PtcG2C_WeddingStateNtf roPtc)
		{
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible() && DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler != null && DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.UpdateWeddingState(roPtc.Data.state, roPtc.Data.lefttime, roPtc.Data.vows);
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._WeddingHandler.UpdateHappiness(roPtc.Data.happyness);
			}
		}

		// Token: 0x06009D96 RID: 40342 RVA: 0x0019AC0C File Offset: 0x00198E0C
		public void WeddingInviteOperate(WeddingInviteOperType type, ulong roleID = 0UL, ulong weddingID = 0UL)
		{
			RpcC2M_WeddingInviteOperator rpcC2M_WeddingInviteOperator = new RpcC2M_WeddingInviteOperator();
			rpcC2M_WeddingInviteOperator.oArg.type = type;
			rpcC2M_WeddingInviteOperator.oArg.roleid = roleID;
			rpcC2M_WeddingInviteOperator.oArg.weddingid = weddingID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_WeddingInviteOperator);
		}

		// Token: 0x06009D97 RID: 40343 RVA: 0x0019AC54 File Offset: 0x00198E54
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

		// Token: 0x06009D98 RID: 40344 RVA: 0x0019B01C File Offset: 0x0019921C
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

		// Token: 0x06009D99 RID: 40345 RVA: 0x0019B2DC File Offset: 0x001994DC
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

		// Token: 0x06009D9A RID: 40346 RVA: 0x0019B320 File Offset: 0x00199520
		public void GetAllWeddingInfo()
		{
			RpcC2M_GetAllWeddingInfo rpc = new RpcC2M_GetAllWeddingInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009D9B RID: 40347 RVA: 0x0019B340 File Offset: 0x00199540
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

		// Token: 0x06009D9C RID: 40348 RVA: 0x0019B484 File Offset: 0x00199684
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

		// Token: 0x06009D9D RID: 40349 RVA: 0x0019B4E8 File Offset: 0x001996E8
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

		// Token: 0x06009D9E RID: 40350 RVA: 0x0019B544 File Offset: 0x00199744
		public void GetWeddingInviteInfo()
		{
			RpcC2M_GetWeddingInviteInfo rpc = new RpcC2M_GetWeddingInviteInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009D9F RID: 40351 RVA: 0x0019B564 File Offset: 0x00199764
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

		// Token: 0x06009DA0 RID: 40352 RVA: 0x0019B864 File Offset: 0x00199A64
		public void SendMarriageRelationInfo()
		{
			RpcC2M_GetMarriageRelation rpc = new RpcC2M_GetMarriageRelation();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009DA1 RID: 40353 RVA: 0x0019B884 File Offset: 0x00199A84
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

		// Token: 0x06009DA2 RID: 40354 RVA: 0x0019B900 File Offset: 0x00199B00
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

		// Token: 0x06009DA3 RID: 40355 RVA: 0x0019B960 File Offset: 0x00199B60
		public void SendMarriageOp(MarriageOpType op, WeddingType type = WeddingType.WeddingType_Normal, ulong roleID = 0UL)
		{
			RpcC2M_MarriageRelationOp rpcC2M_MarriageRelationOp = new RpcC2M_MarriageRelationOp();
			rpcC2M_MarriageRelationOp.oArg.opType = op;
			rpcC2M_MarriageRelationOp.oArg.type = type;
			rpcC2M_MarriageRelationOp.oArg.destRoleID = roleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_MarriageRelationOp);
		}

		// Token: 0x06009DA4 RID: 40356 RVA: 0x0019B9A8 File Offset: 0x00199BA8
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

		// Token: 0x06009DA5 RID: 40357 RVA: 0x0019BA54 File Offset: 0x00199C54
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

		// Token: 0x06009DA6 RID: 40358 RVA: 0x0019BC00 File Offset: 0x00199E00
		public bool GoToNpc(IXUIButton button)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc((uint)XSingleton<XGlobalConfig>.singleton.GetInt("LoveGoldNpcID"));
			return true;
		}

		// Token: 0x06009DA7 RID: 40359 RVA: 0x0019BC50 File Offset: 0x00199E50
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

		// Token: 0x06009DA8 RID: 40360 RVA: 0x0019BD34 File Offset: 0x00199F34
		public void SendWeddingCar()
		{
			RpcC2M_StartWeddingCar rpc = new RpcC2M_StartWeddingCar();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009DA9 RID: 40361 RVA: 0x0019BD54 File Offset: 0x00199F54
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

		// Token: 0x06009DAA RID: 40362 RVA: 0x0019BFF0 File Offset: 0x0019A1F0
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

		// Token: 0x06009DAB RID: 40363 RVA: 0x0019C02C File Offset: 0x0019A22C
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

		// Token: 0x06009DAC RID: 40364 RVA: 0x0019C070 File Offset: 0x0019A270
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

		// Token: 0x06009DAD RID: 40365 RVA: 0x0019C0B3 File Offset: 0x0019A2B3
		public static void Execute(OnLoadedCallback callback = null)
		{
			XWeddingDocument.AsyncLoader.AddTask("Table/WeddingLoverLiveness", XWeddingDocument.m_partnerLivenessTab, false);
			XWeddingDocument.AsyncLoader.AddTask("Table/MarriageLevel", XWeddingDocument.MarriageLevelTable, false);
			XWeddingDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009DAE RID: 40366 RVA: 0x0019C0F0 File Offset: 0x0019A2F0
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

		// Token: 0x06009DAF RID: 40367 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009DB0 RID: 40368 RVA: 0x0019C16C File Offset: 0x0019A36C
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

		// Token: 0x06009DB1 RID: 40369 RVA: 0x0019C27A File Offset: 0x0019A47A
		public override void OnLeaveScene()
		{
			this.StopWeddingCar(null);
		}

		// Token: 0x06009DB2 RID: 40370 RVA: 0x0019C288 File Offset: 0x0019A488
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

		// Token: 0x06009DB3 RID: 40371 RVA: 0x0019C2FC File Offset: 0x0019A4FC
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

		// Token: 0x06009DB4 RID: 40372 RVA: 0x0019C34C File Offset: 0x0019A54C
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

		// Token: 0x0400377A RID: 14202
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("WeddingDocument");

		// Token: 0x0400377B RID: 14203
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400377C RID: 14204
		public static MarriageLevel MarriageLevelTable = new MarriageLevel();

		// Token: 0x0400377D RID: 14205
		private static WeddingLoverLiveness m_partnerLivenessTab = new WeddingLoverLiveness();

		// Token: 0x0400377E RID: 14206
		private List<LoverLivenessRecord> m_recordList = new List<LoverLivenessRecord>();

		// Token: 0x0400377F RID: 14207
		public static readonly int MaxAvata = 2;

		// Token: 0x04003780 RID: 14208
		public FriendsWeddingHandler View;

		// Token: 0x04003781 RID: 14209
		private List<RoleOutLookBrief> m_PartnerList = new List<RoleOutLookBrief>();

		// Token: 0x04003782 RID: 14210
		private MarriageLevelInfo m_MarriageLevel;

		// Token: 0x04003783 RID: 14211
		private int m_MarriageLevelUp = 0;

		// Token: 0x04003784 RID: 14212
		public static int MaxMarriageLevel;

		// Token: 0x04003785 RID: 14213
		public uint CurrExp = 0U;

		// Token: 0x04003786 RID: 14214
		private uint m_takeChest = 0U;

		// Token: 0x04003787 RID: 14215
		public static uint MaxExp = 0U;

		// Token: 0x04003788 RID: 14216
		private bool m_bIsHadLivenessRedPoint = false;

		// Token: 0x04003789 RID: 14217
		private bool m_bLevelUpRedPoint = false;

		// Token: 0x0400378A RID: 14218
		private List<WeddingBriefInfo> m_CanEnterWedding = new List<WeddingBriefInfo>();

		// Token: 0x0400378B RID: 14219
		private List<WeddingBriefInfo> m_CanApplyWedding = new List<WeddingBriefInfo>();

		// Token: 0x0400378C RID: 14220
		private MarriageStatus m_MyMarriageStatus = MarriageStatus.MarriageStatus_Null;

		// Token: 0x0400378D RID: 14221
		private ulong m_NotifedWeddingID = 0UL;

		// Token: 0x0400378E RID: 14222
		private ulong m_ApplyMarriageRoleID = 0UL;

		// Token: 0x0400378F RID: 14223
		private int m_LeftDivorceTime = 0;

		// Token: 0x04003790 RID: 14224
		private ulong m_DivorceApplyID = 0UL;

		// Token: 0x04003791 RID: 14225
		private bool m_PermitStranger = false;

		// Token: 0x04003792 RID: 14226
		private ulong m_MyWeddingID;

		// Token: 0x04003793 RID: 14227
		private int m_CoupleOfflineTime = 0;

		// Token: 0x04003794 RID: 14228
		private WeddingType m_WeddingType = WeddingType.WeddingType_Normal;

		// Token: 0x04003795 RID: 14229
		private List<WeddingRoleInfo> m_FriendsWeddingRoleInfoList = new List<WeddingRoleInfo>();

		// Token: 0x04003796 RID: 14230
		private List<WeddingRoleInfo> m_GuildWeddingRoleInfoList = new List<WeddingRoleInfo>();

		// Token: 0x04003797 RID: 14231
		private List<WeddingRoleInfo> m_InvitedWeddingRoleInfoList = new List<WeddingRoleInfo>();

		// Token: 0x04003798 RID: 14232
		private List<WeddingRoleInfo> m_ApplyWeddingRoleInfoList = new List<WeddingRoleInfo>();

		// Token: 0x04003799 RID: 14233
		private List<RoleOutLookBrief> m_Marriagelist = new List<RoleOutLookBrief>();

		// Token: 0x0400379A RID: 14234
		private WeddingBrief m_CurrWeddingInfo = null;

		// Token: 0x0400379B RID: 14235
		private NotifyType m_CacheNotify = NotifyType.None;

		// Token: 0x0400379C RID: 14236
		private object m_CachedData = null;

		// Token: 0x0400379D RID: 14237
		private uint m_AllAttendPlayerCount = 0U;

		// Token: 0x0400379E RID: 14238
		private XRole _player1;

		// Token: 0x0400379F RID: 14239
		private XRole _player2;

		// Token: 0x040037A0 RID: 14240
		private XMount _mount;

		// Token: 0x040037A1 RID: 14241
		private uint _weddingCarTimer = 0U;

		// Token: 0x040037A2 RID: 14242
		private bool _hasApplyCandidate = false;

		// Token: 0x040037A3 RID: 14243
		private Dictionary<ulong, XFx> m_WeddingSceneLoverFx = new Dictionary<ulong, XFx>();
	}
}
