using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000991 RID: 2449
	internal class XLevelSealDocument : XDocComponent
	{
		// Token: 0x17002CBA RID: 11450
		// (get) Token: 0x0600933F RID: 37695 RVA: 0x00158028 File Offset: 0x00156228
		public override uint ID
		{
			get
			{
				return XLevelSealDocument.uuID;
			}
		}

		// Token: 0x17002CBB RID: 11451
		// (get) Token: 0x06009340 RID: 37696 RVA: 0x00158040 File Offset: 0x00156240
		// (set) Token: 0x06009341 RID: 37697 RVA: 0x00158058 File Offset: 0x00156258
		public XLevelSealView View
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		// Token: 0x17002CBC RID: 11452
		// (get) Token: 0x06009342 RID: 37698 RVA: 0x00158064 File Offset: 0x00156264
		public static XLevelSealDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelSealDocument.uuID) as XLevelSealDocument;
			}
		}

		// Token: 0x17002CBD RID: 11453
		// (get) Token: 0x06009343 RID: 37699 RVA: 0x00158090 File Offset: 0x00156290
		// (set) Token: 0x06009344 RID: 37700 RVA: 0x001580A8 File Offset: 0x001562A8
		public float ExpBuff
		{
			get
			{
				return this._expBuff;
			}
			set
			{
				this._expBuff = value;
			}
		}

		// Token: 0x17002CBE RID: 11454
		// (get) Token: 0x06009345 RID: 37701 RVA: 0x001580B4 File Offset: 0x001562B4
		// (set) Token: 0x06009346 RID: 37702 RVA: 0x001580CC File Offset: 0x001562CC
		public uint SealType
		{
			get
			{
				return this._sealType;
			}
			set
			{
				this._sealType = value;
			}
		}

		// Token: 0x17002CBF RID: 11455
		// (get) Token: 0x06009347 RID: 37703 RVA: 0x001580D8 File Offset: 0x001562D8
		// (set) Token: 0x06009348 RID: 37704 RVA: 0x001580F0 File Offset: 0x001562F0
		public uint SealLevel
		{
			get
			{
				return this._sealLevel;
			}
			set
			{
				this._sealLevel = value;
			}
		}

		// Token: 0x17002CC0 RID: 11456
		// (get) Token: 0x06009349 RID: 37705 RVA: 0x001580FC File Offset: 0x001562FC
		// (set) Token: 0x0600934A RID: 37706 RVA: 0x00158114 File Offset: 0x00156314
		public int CurrentSelfCollectIndex
		{
			get
			{
				return this._currentSelfCollectIndex;
			}
			set
			{
				this._currentSelfCollectIndex = value;
			}
		}

		// Token: 0x17002CC1 RID: 11457
		// (get) Token: 0x0600934B RID: 37707 RVA: 0x00158120 File Offset: 0x00156320
		public uint Status
		{
			get
			{
				return this._status;
			}
		}

		// Token: 0x17002CC2 RID: 11458
		// (get) Token: 0x0600934C RID: 37708 RVA: 0x00158138 File Offset: 0x00156338
		public bool HasRedPoint
		{
			get
			{
				return this.m_HasRedPoint;
			}
		}

		// Token: 0x17002CC3 RID: 11459
		// (get) Token: 0x0600934D RID: 37709 RVA: 0x00158150 File Offset: 0x00156350
		public bool SelfGiftRedPoint
		{
			get
			{
				return this.m_SelfGiftRedPoint;
			}
		}

		// Token: 0x17002CC4 RID: 11460
		// (get) Token: 0x0600934E RID: 37710 RVA: 0x00158168 File Offset: 0x00156368
		public bool RedPoint
		{
			get
			{
				return this.m_HasRedPoint || this.m_SelfGiftRedPoint;
			}
		}

		// Token: 0x17002CC5 RID: 11461
		// (get) Token: 0x0600934F RID: 37711 RVA: 0x0015818C File Offset: 0x0015638C
		public int SealMoeny
		{
			get
			{
				return int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("LevelSealFragmentID"));
			}
		}

		// Token: 0x06009350 RID: 37712 RVA: 0x001581B4 File Offset: 0x001563B4
		public static void GetSealLevelRange(int curLevel, out int min, out int max)
		{
			min = 0;
			max = curLevel;
			int i = 0;
			int num = XLevelSealDocument._LevelSealTypeTable.Table.Length;
			while (i < num)
			{
				bool flag = (long)curLevel <= (long)((ulong)XLevelSealDocument._LevelSealTypeTable.Table[i].Level);
				if (flag)
				{
					max = (int)XLevelSealDocument._LevelSealTypeTable.Table[i].Level;
					bool flag2 = XLevelSealDocument._LevelSealTypeTable.Table[i].Type > 2U;
					if (flag2)
					{
						uint key = XLevelSealDocument._LevelSealTypeTable.Table[i].Type - 2U;
						LevelSealTypeTable.RowData byType = XLevelSealDocument._LevelSealTypeTable.GetByType(key);
						min = (int)byType.Level;
					}
					else
					{
						min = 0;
					}
					break;
				}
				i++;
			}
		}

		// Token: 0x06009351 RID: 37713 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06009352 RID: 37714 RVA: 0x00158270 File Offset: 0x00156470
		public override void OnEnterSceneFinally()
		{
			bool flag = this._sealLevel == 0U && XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL;
			if (flag)
			{
				this.ReqGetLevelSealInfo();
			}
		}

		// Token: 0x06009353 RID: 37715 RVA: 0x001582A4 File Offset: 0x001564A4
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemNumChanged));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x06009354 RID: 37716 RVA: 0x00158310 File Offset: 0x00156510
		public bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			for (int i = 0; i < xaddItemEventArgs.items.Count; i++)
			{
				bool flag = xaddItemEventArgs.items[i].itemID == this.SealMoeny;
				if (flag)
				{
					this.RefreshRedPoint(xaddItemEventArgs.items[i].itemCount);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06009355 RID: 37717 RVA: 0x00158384 File Offset: 0x00156584
		public bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			for (int i = 0; i < xremoveItemEventArgs.types.Count; i++)
			{
				bool flag = xremoveItemEventArgs.ids[i] == this.SealMoeny;
				if (flag)
				{
					this.RefreshRedPoint(0);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06009356 RID: 37718 RVA: 0x001583E4 File Offset: 0x001565E4
		public bool OnItemNumChanged(XEventArgs args)
		{
			XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
			bool flag = xitemNumChangedEventArgs.item.itemID == this.SealMoeny;
			bool result;
			if (flag)
			{
				this.RefreshRedPoint(xitemNumChangedEventArgs.item.itemCount);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06009357 RID: 37719 RVA: 0x0013A712 File Offset: 0x00138912
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		// Token: 0x06009358 RID: 37720 RVA: 0x0015842C File Offset: 0x0015662C
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this._sealLevel == 0U;
			if (flag)
			{
				this.ReqGetLevelSealInfo();
			}
		}

		// Token: 0x06009359 RID: 37721 RVA: 0x00158450 File Offset: 0x00156650
		public int GetSealLevel(uint type)
		{
			bool flag = type < 1U;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				LevelSealTypeTable.RowData byType = XLevelSealDocument._LevelSealTypeTable.GetByType(type);
				result = (int)((byType == null) ? uint.MaxValue : byType.Level);
			}
			return result;
		}

		// Token: 0x0600935A RID: 37722 RVA: 0x0015848E File Offset: 0x0015668E
		public static void Execute(OnLoadedCallback callback = null)
		{
			XLevelSealDocument.AsyncLoader.AddTask("Table/LevelSealType", XLevelSealDocument._LevelSealTypeTable, false);
			XLevelSealDocument.AsyncLoader.AddTask("Table/LevelSealNewFunction", XLevelSealDocument._LevelSealNewFunctionTable, false);
			XLevelSealDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600935B RID: 37723 RVA: 0x001584CC File Offset: 0x001566CC
		public void ReqGetLevelSealInfo()
		{
			RpcC2G_GetLevelSealInfo rpc = new RpcC2G_GetLevelSealInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600935C RID: 37724 RVA: 0x001584EC File Offset: 0x001566EC
		public void ReqLevelSealButtonClick()
		{
			RpcC2G_LevelSealButtonStatus rpc = new RpcC2G_LevelSealButtonStatus();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600935D RID: 37725 RVA: 0x0015850C File Offset: 0x0015670C
		public void ReqBuyGift()
		{
			RpcC2G_LevelSealExchange rpc = new RpcC2G_LevelSealExchange();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600935E RID: 37726 RVA: 0x0015852C File Offset: 0x0015672C
		public void ReqGetSelfGift()
		{
			RpcC2G_GetLevelSealSelfGift rpcC2G_GetLevelSealSelfGift = new RpcC2G_GetLevelSealSelfGift();
			rpcC2G_GetLevelSealSelfGift.oArg.count = (uint)this.CurrentSelfCollectIndex;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetLevelSealSelfGift);
		}

		// Token: 0x0600935F RID: 37727 RVA: 0x00158560 File Offset: 0x00156760
		public void LevelSealButtonClick(LevelSealOverExpArg oArg, LevelSealOverExpRes oRes)
		{
			uint status = this._status;
			this._status = oRes.m_uStatus;
			bool flag = this._status == 0U;
			if (flag)
			{
				bool flag2 = status == 1U;
				if (flag2)
				{
					this.CreateAndPlayFxFxFirework();
					DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.Show(XSysDefine.XSys_LevelSeal, false);
				}
				else
				{
					bool flag3 = status == 2U;
					if (flag3)
					{
						this.ShowNextLevelSeal(true, Vector3.zero);
						this.CreateAndPlayFxFxFirework();
					}
				}
			}
			bool flag4 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag4)
			{
				this.RefreshLevelSealTip();
			}
		}

		// Token: 0x06009360 RID: 37728 RVA: 0x001585F0 File Offset: 0x001567F0
		public void ShowNextLevelSeal(bool isRemove, Vector3 pos)
		{
			DlgBase<NextLevelSealView, NextLevelSealBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			DlgBase<NextLevelSealView, NextLevelSealBehaviour>.singleton.SetNextSealLabel(this.GetNextSealTitleInfo(isRemove));
			DlgBase<NextLevelSealView, NextLevelSealBehaviour>.singleton.SetPosition(pos);
		}

		// Token: 0x06009361 RID: 37729 RVA: 0x00158620 File Offset: 0x00156820
		public void SetShowInfo(GetLevelSealInfoArg oArg, GetLevelSealInfoRes oRes)
		{
			this._killBossCnt = oRes.levelSealData.unLockBossCount;
			this._totalCollectCount = oRes.levelSealData.totalCollectCount;
			this._selfCollectCount = oRes.levelSealData.selfCollectCount;
			this._currentSelfCollectIndex = oRes.levelSealData.selfAwardCountIndex + 1;
			bool flag = this._sealLevel == 0U;
			if (flag)
			{
				this.UseLevelSealInfo(oRes.levelSealData);
			}
			bool flag2 = this.View == null || !this.View.IsVisible();
			if (flag2)
			{
			}
		}

		// Token: 0x06009362 RID: 37730 RVA: 0x001586B0 File Offset: 0x001568B0
		public void RefreshSelfGift()
		{
			LevelSealTypeTable.RowData levelSealType = XLevelSealDocument.GetLevelSealType(this._sealType);
			string text = XSingleton<XStringTable>.singleton.GetString("RunOutLevelSealSelfCollect");
			bool flag = this._currentSelfCollectIndex < levelSealType.PlayerAward.Count;
			if (flag)
			{
				uint num = levelSealType.PlayerAward[this._currentSelfCollectIndex, 0];
				text = string.Format("{0}/{1}", this._selfCollectCount, num);
			}
			this.RefreshRedPoint(-1);
		}

		// Token: 0x06009363 RID: 37731 RVA: 0x00158730 File Offset: 0x00156930
		public void UseLevelSealInfo(PtcG2C_LevelSealNtf roPtc)
		{
			this.UseLevelSealInfo(roPtc.Data);
		}

		// Token: 0x06009364 RID: 37732 RVA: 0x00158740 File Offset: 0x00156940
		public void UseLevelSealInfo(LevelSealInfo data)
		{
			this._status = data.status;
			this._sealType = data.type;
			this._endTime = data.endTime;
			this._totalCollectCount = data.totalCollectCount;
			this._selfCollectCount = data.selfCollectCount;
			this._currentSelfCollectIndex = data.selfAwardCountIndex + 1;
			this._sealLevel = 0U;
			for (int i = 0; i < XLevelSealDocument._LevelSealTypeTable.Table.Length; i++)
			{
				LevelSealTypeTable.RowData rowData = XLevelSealDocument._LevelSealTypeTable.Table[i];
				bool flag = this._sealType == rowData.Type;
				if (flag)
				{
					this._sealLevel = rowData.Level;
					this._needKillBossCnt = rowData.UnlockBossCount;
					this._UnlockBossName = rowData.UnlockBossName;
					bool flag2 = i < XLevelSealDocument._LevelSealTypeTable.Table.Length - 1;
					if (flag2)
					{
						i++;
					}
					this._nextSealLevel = XLevelSealDocument._LevelSealTypeTable.Table[i].Level;
					break;
				}
			}
			bool flag3 = this._sealLevel == 0U && XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL;
			if (flag3)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Table LevelSealType Error: Type = ", this._sealType.ToString(), " No Find!", null, null, null);
			}
			bool flag4 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag4)
			{
				this.RefreshLevelSealTip();
			}
			this.RefreshRedPoint(-1);
		}

		// Token: 0x06009365 RID: 37733 RVA: 0x001588A4 File Offset: 0x00156AA4
		public void RefreshRedPoint(int money = -1)
		{
			LevelSealTypeTable.RowData levelSealType = XLevelSealDocument.GetLevelSealType(this._sealType);
			bool flag = levelSealType == null;
			if (!flag)
			{
				uint num = levelSealType.ExchangeInfo[0];
				bool flag2 = money == -1;
				if (flag2)
				{
					money = (int)XBagDocument.BagDoc.GetItemCount(this.SealMoeny);
				}
				this.m_HasRedPoint = ((long)money >= (long)((ulong)num));
				this.m_SelfGiftRedPoint = this.GetSelfGiftRedPoint();
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_LevelSeal, true);
			}
		}

		// Token: 0x06009366 RID: 37734 RVA: 0x0015891C File Offset: 0x00156B1C
		private bool GetSelfGiftRedPoint()
		{
			LevelSealTypeTable.RowData levelSealType = XLevelSealDocument.GetLevelSealType(this._sealType);
			bool flag = levelSealType == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int count = levelSealType.CollectAward.Count;
				bool flag2 = this._currentSelfCollectIndex < levelSealType.PlayerAward.Count;
				if (flag2)
				{
					uint num = levelSealType.PlayerAward[this._currentSelfCollectIndex, 0];
					result = (num <= this._selfCollectCount);
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06009367 RID: 37735 RVA: 0x00158994 File Offset: 0x00156B94
		public static LevelSealTypeTable.RowData GetLevelSealType(uint type)
		{
			return XLevelSealDocument._LevelSealTypeTable.GetByType(type);
		}

		// Token: 0x06009368 RID: 37736 RVA: 0x001589B4 File Offset: 0x00156BB4
		public Queue<LevelSealNewFunctionTable.RowData> GetLevelSealNewFunction(uint type)
		{
			Queue<LevelSealNewFunctionTable.RowData> queue = new Queue<LevelSealNewFunctionTable.RowData>();
			for (int i = 0; i < XLevelSealDocument._LevelSealNewFunctionTable.Table.Length; i++)
			{
				LevelSealNewFunctionTable.RowData rowData = XLevelSealDocument._LevelSealNewFunctionTable.Table[i];
				bool flag = (ulong)type == (ulong)((long)rowData.Type);
				if (flag)
				{
					queue.Enqueue(rowData);
				}
			}
			return queue;
		}

		// Token: 0x06009369 RID: 37737 RVA: 0x00158A14 File Offset: 0x00156C14
		public string GetConditionInfo()
		{
			return XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this._endTime, XStringDefineProxy.GetString("TIME_FORMAT_MONTHDAYHOUR"), true);
		}

		// Token: 0x0600936A RID: 37738 RVA: 0x00158A44 File Offset: 0x00156C44
		public int GetLeftTime()
		{
			return (int)XSingleton<UiUtility>.singleton.TimeFormatLastTime(this._endTime, true);
		}

		// Token: 0x0600936B RID: 37739 RVA: 0x00158A6C File Offset: 0x00156C6C
		public string GetNowSealTitleInfo()
		{
			return string.Format(XStringDefineProxy.GetString("SEAL_NOW_DESCRIPTION"), this._UnlockBossName);
		}

		// Token: 0x0600936C RID: 37740 RVA: 0x00158A94 File Offset: 0x00156C94
		public string GetNextSealTitleInfo(bool isRemove)
		{
			string result;
			if (isRemove)
			{
				result = string.Format(XStringDefineProxy.GetString("SEAL_REMOVE_DESCRIPTION"), this._sealLevel);
			}
			else
			{
				result = string.Format(XStringDefineProxy.GetString("SEAL_NEXT_DESCRIPTION"), this._nextSealLevel);
			}
			return result;
		}

		// Token: 0x0600936D RID: 37741 RVA: 0x00158AE4 File Offset: 0x00156CE4
		public void LevelUp(uint curLevel)
		{
			bool flag = curLevel >= this._sealLevel && this._sealLevel > 0U;
			if (flag)
			{
				this._status = 1U;
				this.RefreshLevelSealTip();
			}
		}

		// Token: 0x0600936E RID: 37742 RVA: 0x00158B1C File Offset: 0x00156D1C
		public void RefreshLevelSealTip()
		{
			bool flag = !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_LevelSeal_Tip, true);
			}
		}

		// Token: 0x0600936F RID: 37743 RVA: 0x00158B50 File Offset: 0x00156D50
		public bool IsShowLevelSealIcon()
		{
			return XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= this._sealLevel && this._sealLevel != 0U && this._status == 0U;
		}

		// Token: 0x06009370 RID: 37744 RVA: 0x00158B98 File Offset: 0x00156D98
		public bool IsInLevelSeal()
		{
			return XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= this._sealLevel && this._sealLevel > 0U;
		}

		// Token: 0x06009371 RID: 37745 RVA: 0x00158BD8 File Offset: 0x00156DD8
		public void CreateAndPlayFxFxFirework()
		{
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.uiBehaviour == null || DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.uiBehaviour.m_FxFirework == null;
			if (!flag)
			{
				XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/zhuanzhi", true, AudioChannel.Action);
				this.DestroyFx(this._FxFirework);
				this._FxFirework = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_yh", null, true);
				this._FxFirework.Play(DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.uiBehaviour.m_FxFirework.transform, Vector3.zero, Vector3.one, 1f, true, false);
			}
		}

		// Token: 0x06009372 RID: 37746 RVA: 0x00158C80 File Offset: 0x00156E80
		public void DestroyFx(XFx fx)
		{
			bool flag = fx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
				fx = null;
			}
		}

		// Token: 0x06009373 RID: 37747 RVA: 0x00158CA8 File Offset: 0x00156EA8
		public uint GetSealType()
		{
			uint result = 1U;
			for (int i = 0; i < XLevelSealDocument._LevelSealTypeTable.Table.Length; i++)
			{
				bool flag = this.SealLevel <= XLevelSealDocument._LevelSealTypeTable.Table[i].Level;
				if (flag)
				{
					result = XLevelSealDocument._LevelSealTypeTable.Table[i].Type;
					break;
				}
			}
			return result;
		}

		// Token: 0x06009374 RID: 37748 RVA: 0x00158D14 File Offset: 0x00156F14
		public uint GetRemoveSealType(uint curlevel)
		{
			uint result = 0U;
			for (int i = 0; i < XLevelSealDocument._LevelSealTypeTable.Table.Length; i++)
			{
				bool flag = curlevel >= XLevelSealDocument._LevelSealTypeTable.Table[i].Level;
				if (!flag)
				{
					break;
				}
				result = XLevelSealDocument._LevelSealTypeTable.Table[i].Type;
			}
			return result;
		}

		// Token: 0x06009375 RID: 37749 RVA: 0x00158D7C File Offset: 0x00156F7C
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.LevelUp(xplayerLevelChangedEventArgs.level);
			return true;
		}

		// Token: 0x0400317D RID: 12669
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("LevelSealDocument");

		// Token: 0x0400317E RID: 12670
		private XLevelSealView _view = null;

		// Token: 0x0400317F RID: 12671
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003180 RID: 12672
		private static LevelSealTypeTable _LevelSealTypeTable = new LevelSealTypeTable();

		// Token: 0x04003181 RID: 12673
		private static LevelSealNewFunctionTable _LevelSealNewFunctionTable = new LevelSealNewFunctionTable();

		// Token: 0x04003182 RID: 12674
		public static readonly uint REWARD_TIPS_COUNT_MAX = 4U;

		// Token: 0x04003183 RID: 12675
		private float _expBuff;

		// Token: 0x04003184 RID: 12676
		private uint _sealType = 0U;

		// Token: 0x04003185 RID: 12677
		private uint _nextSealLevel;

		// Token: 0x04003186 RID: 12678
		private uint _sealLevel = 0U;

		// Token: 0x04003187 RID: 12679
		private uint _endTime;

		// Token: 0x04003188 RID: 12680
		private uint _killBossCnt;

		// Token: 0x04003189 RID: 12681
		private uint _needKillBossCnt;

		// Token: 0x0400318A RID: 12682
		private uint _totalCollectCount;

		// Token: 0x0400318B RID: 12683
		private uint _selfCollectCount;

		// Token: 0x0400318C RID: 12684
		private int _currentSelfCollectIndex;

		// Token: 0x0400318D RID: 12685
		private string _UnlockBossName;

		// Token: 0x0400318E RID: 12686
		private uint _status;

		// Token: 0x0400318F RID: 12687
		private XFx _FxFirework;

		// Token: 0x04003190 RID: 12688
		private bool m_HasRedPoint = false;

		// Token: 0x04003191 RID: 12689
		private bool m_SelfGiftRedPoint = false;
	}
}
