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

	internal class XSuperRiskDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSuperRiskDocument.uuID;
			}
		}

		public static XSuperRiskDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XSuperRiskDocument.uuID) as XSuperRiskDocument;
			}
		}

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

		public ItemBrief OnlineBoxCost
		{
			get
			{
				return this.m_onlineBoxCost;
			}
		}

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

		public bool IsShowMainUiTips()
		{
			return this.IsHadCanGetBox() || this.DiceTimesIsFull;
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XSuperRiskDocument.AsyncLoader.AddTask("Table/RiskMapFile", XSuperRiskDocument._reader, false);
			XSuperRiskDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

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

		public void ReqBuyOnlineBox()
		{
			this.m_reqMesType = SuperRiskMesType.ReqBuyOnlineBox;
			RpcC2G_RiskBuyRequest rpc = new RpcC2G_RiskBuyRequest();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void NoticeMoveOver()
		{
			this.m_reqMesType = SuperRiskMesType.NoticeMoveOver;
			RpcC2G_PlayDiceOver rpc = new RpcC2G_PlayDiceOver();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ChangeBoxState(int slot, RiskBoxState newState)
		{
			this.m_reqMesType = SuperRiskMesType.ChangeBoxState;
			RpcC2G_ChangeRiskBoxState rpcC2G_ChangeRiskBoxState = new RpcC2G_ChangeRiskBoxState();
			rpcC2G_ChangeRiskBoxState.oArg.mapID = this.CurrentMapID;
			rpcC2G_ChangeRiskBoxState.oArg.slot = slot;
			rpcC2G_ChangeRiskBoxState.oArg.destState = newState;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChangeRiskBoxState);
		}

		public void RequestDicing(int value)
		{
			this.m_reqMesType = SuperRiskMesType.RequestDicing;
			RpcC2G_PlayDiceRequest rpcC2G_PlayDiceRequest = new RpcC2G_PlayDiceRequest();
			rpcC2G_PlayDiceRequest.oArg.mapid = this.CurrentMapID;
			rpcC2G_PlayDiceRequest.oArg.randValue = value;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PlayDiceRequest);
		}

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

		public RiskMapFile.RowData GetCurrentMapData()
		{
			return XSuperRiskDocument._reader.GetByMapID(this.CurrentMapID);
		}

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

		public Vector2 GetPlayerAvatarPos()
		{
			Coordinate playerCoord = XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.PlayerCoord;
			return XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.renderer.CoordToUI(playerCoord);
		}

		public Vector2 GetGridPos(int x, int y)
		{
			Coordinate coord = new Coordinate(x, y);
			return XSingleton<XSuperRiskMapMgr>.singleton.CurrentMap.renderer.CoordToUI(coord);
		}

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

		protected void SetState(SuperRiskState state)
		{
			this.GameState = state;
		}

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

		public void StopStep()
		{
			this.StepToGo = 0;
		}

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

		protected void OnGotoEnd()
		{
			this.StepToGo = 0;
			this.StartEvent();
		}

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

		protected void ProcessEventNormalEvent()
		{
			this.NoticeMoveOver();
		}

		protected void ProcessEventBoxEvent()
		{
			bool flag = this.SlotBoxInfo.Count >= 3;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SuriskRiskBoxFull"), "fece00");
			}
			this.NoticeMoveOver();
		}

		public void OnGetBoxAnimationOver()
		{
			this.RefreshMapIfFinish();
		}

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

		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.HisMaxLevel.PreLevel = xplayerLevelChangedEventArgs.PreLevel;
			return true;
		}

		protected void ProcessEventRiskEvent()
		{
			this.NoticeMoveOver();
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SuperRiskDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static RiskMapFile _reader = new RiskMapFile();

		public SuperRiskGameHandler GameViewHandler;

		public SuperRiskState GameState;

		protected int StepToGo = 0;

		private SuperRiskMesType m_reqMesType = SuperRiskMesType.None;

		private bool m_bDiceTimesIsFull = false;

		private int m_leftDiceTime = 0;

		private int m_maxLeftTimes = -1;

		private int m_curMapID = 0;

		private bool m_bIsNeedSetMapId = true;

		public float RefreshDiceTime = 0f;

		public List<RiskGridInfo> CurrentDynamicInfo = new List<RiskGridInfo>();

		public Dictionary<int, ClientBoxInfo> SlotBoxInfo = new Dictionary<int, ClientBoxInfo>();

		public bool NeedUpdate = false;

		public bool IsNeedEnterMainGame = false;

		public Dictionary<int, SuperRiskSpeedCost> SpeedUpCost = new Dictionary<int, SuperRiskSpeedCost>();

		public HistoryMaxStruct HisMaxLevel = new HistoryMaxStruct();

		private ItemBrief m_onlineBoxCost = null;

		private List<ItemBrief> m_onlineBoxItems = null;

		private bool m_bBoxIsHadOpen = false;

		private int m_bDiceReplyMaxNum = 0;

		public bool IsHadOnlineBoxCache = false;

		private List<ItemBrief> m_boxCatchItems = new List<ItemBrief>();
	}
}
