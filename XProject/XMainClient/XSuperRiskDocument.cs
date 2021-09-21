using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009E5 RID: 2533
	internal class XSuperRiskDocument : XDocComponent
	{
		// Token: 0x17002E08 RID: 11784
		// (get) Token: 0x06009A93 RID: 39571 RVA: 0x00187A94 File Offset: 0x00185C94
		public override uint ID
		{
			get
			{
				return XSuperRiskDocument.uuID;
			}
		}

		// Token: 0x17002E09 RID: 11785
		// (get) Token: 0x06009A94 RID: 39572 RVA: 0x00187AAC File Offset: 0x00185CAC
		public static XSuperRiskDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XSuperRiskDocument.uuID) as XSuperRiskDocument;
			}
		}

		// Token: 0x17002E0A RID: 11786
		// (get) Token: 0x06009A95 RID: 39573 RVA: 0x00187AD8 File Offset: 0x00185CD8
		// (set) Token: 0x06009A96 RID: 39574 RVA: 0x00187B34 File Offset: 0x00185D34
		public int CurrentMapID
		{
			get
			{
				bool flag = this.m_curMapID == 0;
				if (flag)
				{
					RiskMapFile.RowData defaultMapData = this.GetDefaultMapData();
					bool flag2 = defaultMapData != null;
					if (flag2)
					{
						this.m_curMapID = defaultMapData.MapID;
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("RiskMapFile no data!", null, null, null, null, null);
					}
				}
				return this.m_curMapID;
			}
			set
			{
				bool flag = !this.m_bIsNeedSetMapId;
				if (flag)
				{
					this.m_bIsNeedSetMapId = true;
				}
				else
				{
					this.m_curMapID = value;
				}
			}
		}

		// Token: 0x17002E0B RID: 11787
		// (get) Token: 0x06009A98 RID: 39576 RVA: 0x00187B98 File Offset: 0x00185D98
		// (set) Token: 0x06009A97 RID: 39575 RVA: 0x00187B60 File Offset: 0x00185D60
		public int LeftDiceTime
		{
			get
			{
				return this.m_leftDiceTime;
			}
			set
			{
				bool flag = value != this.m_leftDiceTime;
				if (flag)
				{
					this.m_leftDiceTime = value;
					this.DiceTimesIsFull = (value == this.MaxLeftTimes);
				}
			}
		}

		// Token: 0x17002E0C RID: 11788
		// (get) Token: 0x06009A9A RID: 39578 RVA: 0x00187BE4 File Offset: 0x00185DE4
		// (set) Token: 0x06009A99 RID: 39577 RVA: 0x00187BB0 File Offset: 0x00185DB0
		public bool DiceTimesIsFull
		{
			get
			{
				return this.m_bDiceTimesIsFull;
			}
			set
			{
				bool flag = value != this.m_bDiceTimesIsFull;
				if (flag)
				{
					this.m_bDiceTimesIsFull = value;
					XSingleton<XGameSysMgr>.singleton.UpdateRedPointOnHallUI(XSysDefine.XSys_SuperRisk);
				}
			}
		}

		// Token: 0x17002E0D RID: 11789
		// (get) Token: 0x06009A9B RID: 39579 RVA: 0x00187BFC File Offset: 0x00185DFC
		public int MaxLeftTimes
		{
			get
			{
				bool flag = this.m_maxLeftTimes == -1;
				if (flag)
				{
					int.TryParse(XSingleton<XGlobalConfig>.singleton.GetValue("RiskDiceMaxNum"), out this.m_maxLeftTimes);
				}
				return this.m_maxLeftTimes;
			}
		}

		// Token: 0x17002E0E RID: 11790
		// (get) Token: 0x06009A9C RID: 39580 RVA: 0x00187C40 File Offset: 0x00185E40
		public ItemBrief OnlineBoxCost
		{
			get
			{
				return this.m_onlineBoxCost;
			}
		}

		// Token: 0x06009A9D RID: 39581 RVA: 0x00187C58 File Offset: 0x00185E58
		private bool IsHadCanGetBox()
		{
			bool flag = this.SlotBoxInfo == null || this.SlotBoxInfo.Count == 0;
			bool result;
			if (flag)
			{
				result = this.m_bBoxIsHadOpen;
			}
			else
			{
				foreach (KeyValuePair<int, ClientBoxInfo> keyValuePair in this.SlotBoxInfo)
				{
					bool flag2 = keyValuePair.Value.state == RiskBoxState.RISK_BOX_CANGETREWARD;
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06009A9E RID: 39582 RVA: 0x00187CF0 File Offset: 0x00185EF0
		public bool IsShowMainUiTips()
		{
			return this.IsHadCanGetBox() || this.DiceTimesIsFull;
		}

		// Token: 0x17002E0F RID: 11791
		// (get) Token: 0x06009A9F RID: 39583 RVA: 0x00187D1C File Offset: 0x00185F1C
		public int DiceReplyMaxNum
		{
			get
			{
				bool flag = this.m_bDiceReplyMaxNum == 0;
				if (flag)
				{
					SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("RiskRecoverDiceNum", true);
					bool flag2 = sequenceList == null || sequenceList.Count == 0;
					if (flag2)
					{
						this.m_bDiceReplyMaxNum = 0;
					}
					else
					{
						this.m_bDiceReplyMaxNum = sequenceList[0, 0];
					}
				}
				return this.m_bDiceReplyMaxNum;
			}
		}

		// Token: 0x06009AA0 RID: 39584 RVA: 0x00187D80 File Offset: 0x00185F80
		public static void Execute(OnLoadedCallback callback = null)
		{
			XSuperRiskDocument.AsyncLoader.AddTask("Table/RiskMapFile", XSuperRiskDocument._reader, false);
			XSuperRiskDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009AA1 RID: 39585 RVA: 0x00187DA5 File Offset: 0x00185FA5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x06009AA2 RID: 39586 RVA: 0x00187DC8 File Offset: 0x00185FC8
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.m_reqMesType == SuperRiskMesType.NoticeMoveOver;
			if (flag)
			{
				this.NoticeMoveOver();
			}
			bool flag2 = this.m_reqMesType == SuperRiskMesType.RequestDicing || this.m_reqMesType == SuperRiskMesType.ReqMapDynamicInfo;
			if (flag2)
			{
				this.ReqMapDynamicInfo(this.CurrentMapID, false, false);
			}
		}

		// Token: 0x06009AA3 RID: 39587 RVA: 0x00187E18 File Offset: 0x00186018
		public void ReqMapDynamicInfo(int mapID, bool bRefresh = false, bool bOnlyCountInfo = false)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage == null || !XSingleton<XGame>.singleton.CurrentStage.IsEntered;
			if (!flag)
			{
				this.m_reqMesType = SuperRiskMesType.ReqMapDynamicInfo;
				RpcC2G_GetRiskMapInfos rpcC2G_GetRiskMapInfos = new RpcC2G_GetRiskMapInfos();
				rpcC2G_GetRiskMapInfos.oArg.mapID = mapID;
				rpcC2G_GetRiskMapInfos.oArg.isRefresh = bRefresh;
				rpcC2G_GetRiskMapInfos.oArg.onlyCountInfo = bOnlyCountInfo;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetRiskMapInfos);
			}
		}

		// Token: 0x06009AA4 RID: 39588 RVA: 0x00187E90 File Offset: 0x00186090
		public void ReqBuyOnlineBox()
		{
			this.m_reqMesType = SuperRiskMesType.ReqBuyOnlineBox;
			RpcC2G_RiskBuyRequest rpc = new RpcC2G_RiskBuyRequest();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009AA5 RID: 39589 RVA: 0x00187EB8 File Offset: 0x001860B8
		public void NoticeMoveOver()
		{
			this.m_reqMesType = SuperRiskMesType.NoticeMoveOver;
			RpcC2G_PlayDiceOver rpc = new RpcC2G_PlayDiceOver();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009AA6 RID: 39590 RVA: 0x00187EE0 File Offset: 0x001860E0
		public void ChangeBoxState(int slot, RiskBoxState newState)
		{
			this.m_reqMesType = SuperRiskMesType.ChangeBoxState;
			RpcC2G_ChangeRiskBoxState rpcC2G_ChangeRiskBoxState = new RpcC2G_ChangeRiskBoxState();
			rpcC2G_ChangeRiskBoxState.oArg.mapID = this.CurrentMapID;
			rpcC2G_ChangeRiskBoxState.oArg.slot = slot;
			rpcC2G_ChangeRiskBoxState.oArg.destState = newState;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChangeRiskBoxState);
		}

		// Token: 0x06009AA7 RID: 39591 RVA: 0x00187F34 File Offset: 0x00186134
		public void RequestDicing(int value)
		{
			this.m_reqMesType = SuperRiskMesType.RequestDicing;
			RpcC2G_PlayDiceRequest rpcC2G_PlayDiceRequest = new RpcC2G_PlayDiceRequest();
			rpcC2G_PlayDiceRequest.oArg.mapid = this.CurrentMapID;
			rpcC2G_PlayDiceRequest.oArg.randValue = value;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PlayDiceRequest);
		}

		// Token: 0x06009AA8 RID: 39592 RVA: 0x00187F7C File Offset: 0x0018617C
		public void PlayDiceNtfBack(PtcG2C_PlayDiceNtf roPtc)
		{
			this.m_bBoxIsHadOpen = false;
			bool flag = roPtc.Data.mapID != 0;
			if (flag)
			{
				this.m_bBoxIsHadOpen = true;
				bool flag2 = this.SlotBoxInfo.ContainsKey(roPtc.Data.slot);
				if (flag2)
				{
					this.SlotBoxInfo[roPtc.Data.slot].state = RiskBoxState.RISK_BOX_CANGETREWARD;
					bool flag3 = this.GameViewHandler != null && this.GameViewHandler.IsVisible();
					if (flag3)
					{
						this.GameViewHandler.UpdateSlotBox(roPtc.Data.slot);
					}
				}
			}
			bool flag4 = this.DiceTimesIsFull != roPtc.Data.isDiceFull;
			if (flag4)
			{
				this.DiceTimesIsFull = roPtc.Data.isDiceFull;
			}
			else
			{
				XSingleton<XGameSysMgr>.singleton.UpdateRedPointOnHallUI(XSysDefine.XSys_SuperRisk);
			}
		}

		// Token: 0x06009AA9 RID: 39593 RVA: 0x00188050 File Offset: 0x00186250
		public void RiskBuyNtfBack(PtcG2C_RiskBuyNtf roPtc)
		{
			this.m_onlineBoxCost = roPtc.Data.cost;
			this.m_onlineBoxItems = roPtc.Data.rewardItems;
			this.IsHadOnlineBoxCache = this.IsNeedCatchOnlineBox();
			bool isHadOnlineBoxCache = this.IsHadOnlineBoxCache;
			if (!isHadOnlineBoxCache)
			{
				bool flag = !DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.IsVisible();
				if (!flag)
				{
					bool flag2 = this.GameViewHandler != null && this.GameViewHandler.IsVisible();
					if (flag2)
					{
						this.GameViewHandler.HideDice();
						this.GameViewHandler.ShowOnlineBox();
					}
				}
			}
		}

		// Token: 0x06009AAA RID: 39594 RVA: 0x001880E0 File Offset: 0x001862E0
		public void BuyOnlineBoxBack(RiskBuyRequestRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				bool flag2 = this.GameViewHandler != null && this.GameViewHandler.IsVisible();
				if (flag2)
				{
					this.GameViewHandler.CloseOnlineBox();
				}
				bool flag3 = this.m_onlineBoxItems != null;
				if (flag3)
				{
					DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.Show(this.m_onlineBoxItems, null);
				}
			}
		}

		// Token: 0x06009AAB RID: 39595 RVA: 0x00188160 File Offset: 0x00186360
		public bool IsNeedCatchOnlineBox()
		{
			RiskGridInfo gridDynamicInfo = this.GetGridDynamicInfo(XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.PlayerCoord);
			bool flag = gridDynamicInfo == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = gridDynamicInfo.gridType == RiskGridType.RISK_GRID_NORMALREWARD || gridDynamicInfo.gridType == RiskGridType.RISK_GRID_ADVENTURE;
				result = flag2;
			}
			return result;
		}

		// Token: 0x06009AAC RID: 39596 RVA: 0x001881B4 File Offset: 0x001863B4
		public void OnGetMapDynamicInfo(GetRiskMapInfosArg oArg, GetRiskMapInfosRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				this.GameState = SuperRiskState.SuperRiskReadyToMove;
			}
			else
			{
				bool flag2 = oRes.error > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					this.GameState = SuperRiskState.SuperRiskReadyToMove;
				}
				else
				{
					bool onlyCountInfo = oArg.onlyCountInfo;
					if (onlyCountInfo)
					{
						bool flag3 = oRes.mapInfo != null;
						if (flag3)
						{
							this.LeftDiceTime = oRes.mapInfo.diceNum;
						}
						XActivityDocument.Doc.OnGetDayCount();
					}
					else
					{
						bool flag4 = oRes.mapInfo != null;
						if (flag4)
						{
							for (int i = 0; i < oRes.mapInfo.infos.Count; i++)
							{
								bool flag5 = oRes.mapInfo.infos[i].mapid == oArg.mapID;
								if (flag5)
								{
									this.OnGetMapDynamicInfo(oRes.mapInfo.infos[i], oRes.mapInfo.diceNum, oRes.mapInfo.leftDiceTime, oArg.isRefresh);
								}
							}
						}
					}
					XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
					specificDocument.RefreshRedPoint(XSysDefine.XSyS_Welfare_RewardBack, true);
				}
			}
		}

		// Token: 0x06009AAD RID: 39597 RVA: 0x0018831C File Offset: 0x0018651C
		private void OnGetMapDynamicInfo(RiskOneMapInfo mapInfo, int leftTime, int refreshDiceTime, bool bRefresh = false)
		{
			this.CurrentMapID = mapInfo.mapid;
			this.GenerateMap();
			XSingleton<XSuperRiskMapMgr>.singleton.SetPlayerPosDirection(mapInfo.curX, mapInfo.curY, mapInfo.moveDirection);
			this.CurrentDynamicInfo.Clear();
			for (int i = 0; i < mapInfo.grids.Count; i++)
			{
				this.CurrentDynamicInfo.Add(mapInfo.grids[i]);
			}
			bool flag = !bRefresh;
			if (flag)
			{
				this.GameState = SuperRiskState.SuperRiskReadyToMove;
				bool flag2 = DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					bool flag3 = this.GameViewHandler != null && this.GameViewHandler.IsVisible();
					if (flag3)
					{
						this.GameViewHandler.RefreshUi();
					}
				}
			}
			else
			{
				bool flag4 = this.GameViewHandler != null && this.GameViewHandler.IsVisible();
				if (flag4)
				{
					this.GameViewHandler.RefreshMap();
				}
				this.GameState = SuperRiskState.SuperRiskReadyToMove;
			}
			this.SetDiceLeftTime(leftTime, refreshDiceTime);
			this.SetBoxInfo(mapInfo.boxInfos);
			this.NeedUpdate = true;
		}

		// Token: 0x06009AAE RID: 39598 RVA: 0x00188438 File Offset: 0x00186638
		public void OnMoveOver(PlayDiceOverRes oRes)
		{
			this.m_reqMesType = SuperRiskMesType.None;
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				this.ReqMapDynamicInfo(this.CurrentMapID, false, false);
			}
			else
			{
				bool flag2 = this.GameViewHandler == null || !this.GameViewHandler.IsVisible();
				if (flag2)
				{
					this.GameState = SuperRiskState.SuperRiskReadyToMove;
				}
				else
				{
					RiskBoxInfo addBoxInfo = oRes.addBoxInfo;
					bool flag3 = this.GameState == SuperRiskState.SuperRiskEvent;
					if (flag3)
					{
						Coordinate playerCoord = XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.PlayerCoord;
						RiskGridInfo gridDynamicInfo = this.GetGridDynamicInfo(playerCoord);
						bool flag4 = gridDynamicInfo == null;
						if (flag4)
						{
							bool flag5 = this.GameViewHandler != null;
							if (flag5)
							{
								this.GameViewHandler.OnMapItemFetched(XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.PlayerCoord);
							}
							this.GameState = SuperRiskState.SuperRiskReadyToMove;
						}
						else
						{
							bool flag6 = gridDynamicInfo.gridType == RiskGridType.RISK_GRID_REWARDBOX;
							if (flag6)
							{
								bool flag7 = this.GameViewHandler != null;
								if (flag7)
								{
									this.GameViewHandler.OnMapItemFetched(XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.PlayerCoord);
								}
								bool flag8 = addBoxInfo == null;
								if (flag8)
								{
									this.RefreshMapIfFinish();
								}
								else
								{
									this.GameState = SuperRiskState.SuperRiskGetBoxAnimation;
									bool flag9 = this.SlotBoxInfo.ContainsKey(addBoxInfo.slot);
									if (flag9)
									{
										this.SlotBoxInfo[addBoxInfo.slot].Apply(addBoxInfo);
									}
									else
									{
										this.SlotBoxInfo.Add(addBoxInfo.slot, new ClientBoxInfo(addBoxInfo));
									}
									bool flag10 = this.GameViewHandler != null;
									if (flag10)
									{
										this.GameViewHandler.PlayGetBoxAnimation(gridDynamicInfo.rewardItem.itemID, addBoxInfo.slot);
									}
								}
							}
							else
							{
								bool flag11 = this.GameViewHandler != null;
								if (flag11)
								{
									this.GameViewHandler.OnMapItemFetched(XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.PlayerCoord);
								}
								this.GameState = SuperRiskState.SuperRiskReadyToMove;
							}
						}
					}
				}
			}
		}

		// Token: 0x06009AAF RID: 39599 RVA: 0x00188630 File Offset: 0x00186830
		public void OnBoxStateChangeSucc(ChangeRiskBoxStateArg oArg, ChangeRiskBoxStateRes oRes)
		{
			int slot = oArg.slot;
			RiskBoxState destState = oArg.destState;
			bool flag = destState == RiskBoxState.RISK_BOX_GETREWARD && oRes.openBoxRewards.Count > 0;
			if (flag)
			{
				this.m_bBoxIsHadOpen = false;
				this.GameViewHandler.HideDice();
				this.m_boxCatchItems.Clear();
				for (int i = 0; i < oRes.openBoxRewards.Count; i++)
				{
					ItemBrief item = this.GetItem(oRes.openBoxRewards[i].itemID);
					bool flag2 = item == null;
					if (flag2)
					{
						this.m_boxCatchItems.Add(oRes.openBoxRewards[i]);
					}
					else
					{
						ItemBrief itemBrief = item;
						uint itemCount = itemBrief.itemCount;
						itemBrief.itemCount = itemCount + 1U;
					}
				}
				List<ItemBrief> newItemList = this.GetNewItemList();
				DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.Show(newItemList, new Action(this.ShowBoxCatchItem));
			}
			bool flag3 = this.SlotBoxInfo.ContainsKey(slot);
			if (flag3)
			{
				this.SlotBoxInfo[slot].state = destState;
				bool flag4 = destState == RiskBoxState.RISK_BOX_GETREWARD || destState == RiskBoxState.RISK_BOX_DELETE;
				if (flag4)
				{
					this.SlotBoxInfo.Remove(slot);
				}
			}
			XSingleton<XGameSysMgr>.singleton.UpdateRedPointOnHallUI(XSysDefine.XSys_SuperRisk);
			bool flag5 = this.GameViewHandler != null;
			if (flag5)
			{
				this.GameViewHandler.UpdateSlotBox(slot);
			}
		}

		// Token: 0x06009AB0 RID: 39600 RVA: 0x00188790 File Offset: 0x00186990
		private ItemBrief GetItem(uint itemId)
		{
			for (int i = 0; i < this.m_boxCatchItems.Count; i++)
			{
				bool flag = itemId == this.m_boxCatchItems[i].itemID;
				if (flag)
				{
					return this.m_boxCatchItems[i];
				}
			}
			return null;
		}

		// Token: 0x06009AB1 RID: 39601 RVA: 0x001887E8 File Offset: 0x001869E8
		private List<ItemBrief> GetNewItemList()
		{
			List<ItemBrief> list = new List<ItemBrief>();
			int num = (this.m_boxCatchItems.Count > 10) ? 10 : this.m_boxCatchItems.Count;
			for (int i = 0; i < num; i++)
			{
				list.Add(this.m_boxCatchItems[i]);
			}
			this.m_boxCatchItems.RemoveRange(0, num);
			return list;
		}

		// Token: 0x06009AB2 RID: 39602 RVA: 0x00188858 File Offset: 0x00186A58
		public void OnGetDicingResult(PlayDiceRequestRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				this.NoticeMoveOver();
				this.GameState = SuperRiskState.SuperRiskReadyToMove;
			}
			else
			{
				XSingleton<XDebug>.singleton.AddGreenLog("Server dice: ", oRes.getValue.ToString(), null, null, null, null);
				int getValue = oRes.getValue;
				int leftDiceTime = oRes.leftDiceTime;
				this.GameState = SuperRiskState.SuperRiskDicing;
				int leftDiceTime2 = this.LeftDiceTime;
				this.LeftDiceTime = leftDiceTime2 - 1;
				this.RefreshDiceTime = (float)leftDiceTime;
				bool flag2 = this.GameViewHandler != null;
				if (flag2)
				{
					bool flag3 = this.GameViewHandler.IsVisible();
					if (flag3)
					{
						this.GameViewHandler.SetDiceLeftTime();
						this.GameViewHandler.PlayDiceAnimation(getValue);
					}
					else
					{
						this.NoticeMoveOver();
					}
				}
			}
		}

		// Token: 0x06009AB3 RID: 39603 RVA: 0x00188938 File Offset: 0x00186B38
		private void ShowBoxCatchItem()
		{
			List<ItemBrief> newItemList = this.GetNewItemList();
			bool flag = newItemList.Count == 0;
			if (flag)
			{
				this.RewdAnimCallBack();
			}
			else
			{
				DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.Show(newItemList, new Action(this.ShowBoxCatchItem));
			}
		}

		// Token: 0x06009AB4 RID: 39604 RVA: 0x0018897C File Offset: 0x00186B7C
		public void RewdAnimCallBack()
		{
			bool isHadOnlineBoxCache = this.IsHadOnlineBoxCache;
			if (isHadOnlineBoxCache)
			{
				this.IsHadOnlineBoxCache = false;
				bool flag = this.GameViewHandler != null && this.GameViewHandler.IsVisible();
				if (flag)
				{
					this.GameViewHandler.ShowOnlineBox();
				}
			}
		}

		// Token: 0x06009AB5 RID: 39605 RVA: 0x001889C8 File Offset: 0x00186BC8
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			SeqList<int> sequence4List = XSingleton<XGlobalConfig>.singleton.GetSequence4List("RiskBoxAccelerate", true);
			this.SpeedUpCost.Clear();
			for (int i = 0; i < (int)sequence4List.Count; i++)
			{
				SuperRiskSpeedCost superRiskSpeedCost = default(SuperRiskSpeedCost);
				superRiskSpeedCost.quality = sequence4List[i, 0];
				superRiskSpeedCost.time = sequence4List[i, 1];
				superRiskSpeedCost.itemID = sequence4List[i, 2];
				superRiskSpeedCost.itemCount = sequence4List[i, 3];
				this.SpeedUpCost.Add(superRiskSpeedCost.quality, superRiskSpeedCost);
			}
			this.HisMaxLevel.Replace();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RISK;
			if (flag)
			{
				this.IsNeedEnterMainGame = true;
				this.m_bIsNeedSetMapId = false;
				XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_SuperRisk, EXStage.Hall);
			}
		}

		// Token: 0x06009AB6 RID: 39606 RVA: 0x00188AA8 File Offset: 0x00186CA8
		public SuperRiskSpeedCost GetSpeedCost(int quality)
		{
			bool flag = !this.SpeedUpCost.ContainsKey(quality);
			SuperRiskSpeedCost result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("No Speed cost config for quality", quality.ToString(), null, null, null, null);
				result = default(SuperRiskSpeedCost);
			}
			else
			{
				result = this.SpeedUpCost[quality];
			}
			return result;
		}

		// Token: 0x06009AB7 RID: 39607 RVA: 0x00188B04 File Offset: 0x00186D04
		public RiskMapFile.RowData GetMapIdByIndex(int index)
		{
			bool flag = index >= XSuperRiskDocument._reader.Table.Length;
			RiskMapFile.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = XSuperRiskDocument._reader.Table[index];
			}
			return result;
		}

		// Token: 0x06009AB8 RID: 39608 RVA: 0x00188B3C File Offset: 0x00186D3C
		public RiskMapFile.RowData GetCurrentMapData()
		{
			return XSuperRiskDocument._reader.GetByMapID(this.CurrentMapID);
		}

		// Token: 0x06009AB9 RID: 39609 RVA: 0x00188B60 File Offset: 0x00186D60
		private RiskMapFile.RowData GetDefaultMapData()
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			bool flag = XSuperRiskDocument._reader.Table.Length == 0;
			RiskMapFile.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int i = 0;
				while (i < XSuperRiskDocument._reader.Table.Length)
				{
					bool flag2 = (long)XSuperRiskDocument._reader.Table[i].NeedLevel > (long)((ulong)level);
					if (flag2)
					{
						bool flag3 = i == 0;
						if (flag3)
						{
							return XSuperRiskDocument._reader.Table[0];
						}
						return XSuperRiskDocument._reader.Table[i - 1];
					}
					else
					{
						i++;
					}
				}
				result = XSuperRiskDocument._reader.Table[XSuperRiskDocument._reader.Table.Length - 1];
			}
			return result;
		}

		// Token: 0x06009ABA RID: 39610 RVA: 0x00188C1C File Offset: 0x00186E1C
		public void GenerateMap()
		{
			bool flag = this.CurrentMapID == 0;
			if (!flag)
			{
				RiskMapFile.RowData byMapID = XSuperRiskDocument._reader.GetByMapID(this.CurrentMapID);
				bool flag2 = byMapID == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("No risk map info found", null, null, null, null, null);
				}
				else
				{
					XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.Clear();
					string currentMap = byMapID.FileName.Substring(0, byMapID.FileName.Length - 4);
					XSingleton<XSuperRiskMapMgr>.singleton.SetCurrentMap(currentMap);
					XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.renderer.SetInitInfo(new Vector2((float)byMapID.StartUIX, (float)byMapID.StartUIY), (float)byMapID.StepSizeX, (float)byMapID.StepSizeY);
				}
			}
		}

		// Token: 0x06009ABB RID: 39611 RVA: 0x00188CDC File Offset: 0x00186EDC
		public void SetDiceLeftTime(int leftTime, int refreshDiceTime)
		{
			this.LeftDiceTime = leftTime;
			this.RefreshDiceTime = (float)refreshDiceTime;
			bool flag = this.GameViewHandler != null && this.GameViewHandler.IsVisible();
			if (flag)
			{
				this.GameViewHandler.SetDiceLeftTime();
			}
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnRefreshRewardBack();
		}

		// Token: 0x06009ABC RID: 39612 RVA: 0x00188D34 File Offset: 0x00186F34
		public void SetBoxInfo(List<RiskBoxInfo> Info)
		{
			this.SlotBoxInfo.Clear();
			for (int i = 0; i < Info.Count; i++)
			{
				this.SlotBoxInfo[Info[i].slot] = new ClientBoxInfo(Info[i]);
			}
			bool flag = this.GameViewHandler != null;
			if (flag)
			{
				this.GameViewHandler.SetupSlotBoxes();
			}
		}

		// Token: 0x06009ABD RID: 39613 RVA: 0x00188DA4 File Offset: 0x00186FA4
		public Vector2 GetPlayerAvatarPos()
		{
			Coordinate playerCoord = XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.PlayerCoord;
			return XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.renderer.CoordToUI(playerCoord);
		}

		// Token: 0x06009ABE RID: 39614 RVA: 0x00188DDC File Offset: 0x00186FDC
		public Vector2 GetGridPos(int x, int y)
		{
			Coordinate coord = new Coordinate(x, y);
			return XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.renderer.CoordToUI(coord);
		}

		// Token: 0x06009ABF RID: 39615 RVA: 0x00188E0C File Offset: 0x0018700C
		public bool StartRoll()
		{
			bool flag = this.GameState == SuperRiskState.SuperRiskReadyToMove;
			bool result;
			if (flag)
			{
				this.SetState(SuperRiskState.SuperRiskRolling);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06009AC0 RID: 39616 RVA: 0x00188E39 File Offset: 0x00187039
		protected void SetState(SuperRiskState state)
		{
			this.GameState = state;
		}

		// Token: 0x06009AC1 RID: 39617 RVA: 0x00188E44 File Offset: 0x00187044
		public void Go(int step)
		{
			bool flag = this.GameState != SuperRiskState.SuperRiskDicing;
			if (!flag)
			{
				this.GameState = SuperRiskState.SuperRiskMoving;
				this.StepToGo = step;
				this.GoStep();
			}
		}

		// Token: 0x06009AC2 RID: 39618 RVA: 0x00188E7C File Offset: 0x0018707C
		public void GoStep()
		{
			Coordinate invalid = Coordinate.Invalid;
			XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.StartMoveNext(ref invalid);
			bool flag = this.GameViewHandler != null && this.GameViewHandler.IsVisible();
			if (flag)
			{
				this.GameViewHandler.MoveStep(XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.renderer.CoordToUI(invalid));
			}
			else
			{
				this.NoticeMoveOver();
			}
		}

		// Token: 0x06009AC3 RID: 39619 RVA: 0x00188EE8 File Offset: 0x001870E8
		public void OnGoStepOver()
		{
			XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.MoveNext();
			char c;
			XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.GetNodeGroup(XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.PlayerCoord, out c);
			bool flag = c == 'T';
			if (flag)
			{
				this.OnGotoEnd();
			}
			else
			{
				int num = this.StepToGo - 1;
				this.StepToGo = num;
				bool flag2 = num > 0;
				if (flag2)
				{
					this.GoStep();
				}
				else
				{
					XSingleton<XDebug>.singleton.AddGreenLog("SuperRisk: Move Over", null, null, null, null, null);
					this.StartEvent();
				}
			}
		}

		// Token: 0x06009AC4 RID: 39620 RVA: 0x00188F7E File Offset: 0x0018717E
		public void StopStep()
		{
			this.StepToGo = 0;
		}

		// Token: 0x06009AC5 RID: 39621 RVA: 0x00188F88 File Offset: 0x00187188
		public RiskGridInfo GetGridDynamicInfo(Coordinate c)
		{
			for (int i = 0; i < this.CurrentDynamicInfo.Count; i++)
			{
				bool flag = c.x == this.CurrentDynamicInfo[i].x && c.y == this.CurrentDynamicInfo[i].y;
				if (flag)
				{
					return this.CurrentDynamicInfo[i];
				}
			}
			return null;
		}

		// Token: 0x06009AC6 RID: 39622 RVA: 0x00189000 File Offset: 0x00187200
		public int GetGridDynamicIndex(Coordinate c)
		{
			for (int i = 0; i < this.CurrentDynamicInfo.Count; i++)
			{
				bool flag = c.x == this.CurrentDynamicInfo[i].x && c.y == this.CurrentDynamicInfo[i].y;
				if (flag)
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x06009AC7 RID: 39623 RVA: 0x0018906D File Offset: 0x0018726D
		protected void OnGotoEnd()
		{
			this.StepToGo = 0;
			this.StartEvent();
		}

		// Token: 0x06009AC8 RID: 39624 RVA: 0x00189080 File Offset: 0x00187280
		protected void StartEvent()
		{
			this.GameState = SuperRiskState.SuperRiskEvent;
			Coordinate playerCoord = XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.PlayerCoord;
			RiskGridInfo gridDynamicInfo = this.GetGridDynamicInfo(playerCoord);
			bool flag = gridDynamicInfo == null;
			if (flag)
			{
				this.NoticeMoveOver();
			}
			else
			{
				switch (gridDynamicInfo.gridType)
				{
				case RiskGridType.RISK_GRID_EMPTY:
					this.NoticeMoveOver();
					break;
				case RiskGridType.RISK_GRID_NORMALREWARD:
					this.ProcessEventNormalEvent();
					break;
				case RiskGridType.RISK_GRID_REWARDBOX:
					this.ProcessEventBoxEvent();
					break;
				case RiskGridType.RISK_GRID_ADVENTURE:
					this.ProcessEventRiskEvent();
					break;
				default:
					this.NoticeMoveOver();
					break;
				}
			}
		}

		// Token: 0x06009AC9 RID: 39625 RVA: 0x0018910D File Offset: 0x0018730D
		protected void ProcessEventNormalEvent()
		{
			this.NoticeMoveOver();
		}

		// Token: 0x06009ACA RID: 39626 RVA: 0x00189118 File Offset: 0x00187318
		protected void ProcessEventBoxEvent()
		{
			bool flag = this.SlotBoxInfo.Count >= 3;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SuriskRiskBoxFull"), "fece00");
			}
			this.NoticeMoveOver();
		}

		// Token: 0x06009ACB RID: 39627 RVA: 0x0018915E File Offset: 0x0018735E
		public void OnGetBoxAnimationOver()
		{
			this.RefreshMapIfFinish();
		}

		// Token: 0x06009ACC RID: 39628 RVA: 0x00189168 File Offset: 0x00187368
		protected void RefreshMapIfFinish()
		{
			char c;
			XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.GetNodeGroup(XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.PlayerCoord, out c);
			bool flag = c == 'T';
			if (flag)
			{
				this.GameState = SuperRiskState.SuperRiskRefreshMap;
				bool flag2 = this.GameViewHandler != null && this.GameViewHandler.IsVisible();
				if (flag2)
				{
					this.GameViewHandler.HideDice();
					this.GameViewHandler.ResetMapAni();
				}
				XSingleton<XDebug>.singleton.AddGreenLog("this end--->T", null, null, null, null, null);
				this.ReqMapDynamicInfo(this.CurrentMapID, true, false);
			}
			else
			{
				this.GameState = SuperRiskState.SuperRiskReadyToMove;
			}
		}

		// Token: 0x06009ACD RID: 39629 RVA: 0x00189210 File Offset: 0x00187410
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool needUpdate = this.NeedUpdate;
			if (needUpdate)
			{
				bool flag = this.RefreshDiceTime > 0f;
				if (flag)
				{
					this.RefreshDiceTime -= fDeltaT;
					bool flag2 = this.RefreshDiceTime < 0f;
					if (flag2)
					{
						this.RefreshDiceTime = 0f;
					}
				}
				for (int i = 0; i < 3; i++)
				{
					bool flag3 = this.SlotBoxInfo.ContainsKey(i);
					if (flag3)
					{
						bool flag4 = this.SlotBoxInfo[i] != null && this.SlotBoxInfo[i].leftTime > 0f && this.SlotBoxInfo[i].state == RiskBoxState.RISK_BOX_UNLOCKED;
						if (flag4)
						{
							this.SlotBoxInfo[i].leftTime -= fDeltaT;
							bool flag5 = this.SlotBoxInfo[i].leftTime < 0f;
							if (flag5)
							{
								this.SlotBoxInfo[i].leftTime = 0f;
							}
						}
					}
				}
			}
		}

		// Token: 0x06009ACE RID: 39630 RVA: 0x00189338 File Offset: 0x00187538
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.HisMaxLevel.PreLevel = xplayerLevelChangedEventArgs.PreLevel;
			return true;
		}

		// Token: 0x06009ACF RID: 39631 RVA: 0x0018910D File Offset: 0x0018730D
		protected void ProcessEventRiskEvent()
		{
			this.NoticeMoveOver();
		}

		// Token: 0x04003551 RID: 13649
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SuperRiskDocument");

		// Token: 0x04003552 RID: 13650
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003553 RID: 13651
		private static RiskMapFile _reader = new RiskMapFile();

		// Token: 0x04003554 RID: 13652
		public SuperRiskGameHandler GameViewHandler;

		// Token: 0x04003555 RID: 13653
		public SuperRiskState GameState;

		// Token: 0x04003556 RID: 13654
		protected int StepToGo = 0;

		// Token: 0x04003557 RID: 13655
		private SuperRiskMesType m_reqMesType = SuperRiskMesType.None;

		// Token: 0x04003558 RID: 13656
		private bool m_bDiceTimesIsFull = false;

		// Token: 0x04003559 RID: 13657
		private int m_leftDiceTime = 0;

		// Token: 0x0400355A RID: 13658
		private int m_maxLeftTimes = -1;

		// Token: 0x0400355B RID: 13659
		private int m_curMapID = 0;

		// Token: 0x0400355C RID: 13660
		private bool m_bIsNeedSetMapId = true;

		// Token: 0x0400355D RID: 13661
		public float RefreshDiceTime = 0f;

		// Token: 0x0400355E RID: 13662
		public List<RiskGridInfo> CurrentDynamicInfo = new List<RiskGridInfo>();

		// Token: 0x0400355F RID: 13663
		public Dictionary<int, ClientBoxInfo> SlotBoxInfo = new Dictionary<int, ClientBoxInfo>();

		// Token: 0x04003560 RID: 13664
		public bool NeedUpdate = false;

		// Token: 0x04003561 RID: 13665
		public bool IsNeedEnterMainGame = false;

		// Token: 0x04003562 RID: 13666
		public Dictionary<int, SuperRiskSpeedCost> SpeedUpCost = new Dictionary<int, SuperRiskSpeedCost>();

		// Token: 0x04003563 RID: 13667
		public HistoryMaxStruct HisMaxLevel = new HistoryMaxStruct();

		// Token: 0x04003564 RID: 13668
		private ItemBrief m_onlineBoxCost = null;

		// Token: 0x04003565 RID: 13669
		private List<ItemBrief> m_onlineBoxItems = null;

		// Token: 0x04003566 RID: 13670
		private bool m_bBoxIsHadOpen = false;

		// Token: 0x04003567 RID: 13671
		private int m_bDiceReplyMaxNum = 0;

		// Token: 0x04003568 RID: 13672
		public bool IsHadOnlineBoxCache = false;

		// Token: 0x04003569 RID: 13673
		private List<ItemBrief> m_boxCatchItems = new List<ItemBrief>();
	}
}
