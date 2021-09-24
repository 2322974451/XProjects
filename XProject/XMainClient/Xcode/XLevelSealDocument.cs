using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelSealDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XLevelSealDocument.uuID;
			}
		}

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

		public static XLevelSealDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelSealDocument.uuID) as XLevelSealDocument;
			}
		}

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

		public uint Status
		{
			get
			{
				return this._status;
			}
		}

		public bool HasRedPoint
		{
			get
			{
				return this.m_HasRedPoint;
			}
		}

		public bool SelfGiftRedPoint
		{
			get
			{
				return this.m_SelfGiftRedPoint;
			}
		}

		public bool RedPoint
		{
			get
			{
				return this.m_HasRedPoint || this.m_SelfGiftRedPoint;
			}
		}

		public int SealMoeny
		{
			get
			{
				return int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("LevelSealFragmentID"));
			}
		}

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

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = this._sealLevel == 0U && XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL;
			if (flag)
			{
				this.ReqGetLevelSealInfo();
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemNumChanged));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

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

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this._sealLevel == 0U;
			if (flag)
			{
				this.ReqGetLevelSealInfo();
			}
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XLevelSealDocument.AsyncLoader.AddTask("Table/LevelSealType", XLevelSealDocument._LevelSealTypeTable, false);
			XLevelSealDocument.AsyncLoader.AddTask("Table/LevelSealNewFunction", XLevelSealDocument._LevelSealNewFunctionTable, false);
			XLevelSealDocument.AsyncLoader.Execute(callback);
		}

		public void ReqGetLevelSealInfo()
		{
			RpcC2G_GetLevelSealInfo rpc = new RpcC2G_GetLevelSealInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqLevelSealButtonClick()
		{
			RpcC2G_LevelSealButtonStatus rpc = new RpcC2G_LevelSealButtonStatus();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqBuyGift()
		{
			RpcC2G_LevelSealExchange rpc = new RpcC2G_LevelSealExchange();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqGetSelfGift()
		{
			RpcC2G_GetLevelSealSelfGift rpcC2G_GetLevelSealSelfGift = new RpcC2G_GetLevelSealSelfGift();
			rpcC2G_GetLevelSealSelfGift.oArg.count = (uint)this.CurrentSelfCollectIndex;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetLevelSealSelfGift);
		}

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

		public void ShowNextLevelSeal(bool isRemove, Vector3 pos)
		{
			DlgBase<NextLevelSealView, NextLevelSealBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			DlgBase<NextLevelSealView, NextLevelSealBehaviour>.singleton.SetNextSealLabel(this.GetNextSealTitleInfo(isRemove));
			DlgBase<NextLevelSealView, NextLevelSealBehaviour>.singleton.SetPosition(pos);
		}

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

		public void UseLevelSealInfo(PtcG2C_LevelSealNtf roPtc)
		{
			this.UseLevelSealInfo(roPtc.Data);
		}

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

		public static LevelSealTypeTable.RowData GetLevelSealType(uint type)
		{
			return XLevelSealDocument._LevelSealTypeTable.GetByType(type);
		}

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

		public string GetConditionInfo()
		{
			return XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this._endTime, XStringDefineProxy.GetString("TIME_FORMAT_MONTHDAYHOUR"), true);
		}

		public int GetLeftTime()
		{
			return (int)XSingleton<UiUtility>.singleton.TimeFormatLastTime(this._endTime, true);
		}

		public string GetNowSealTitleInfo()
		{
			return string.Format(XStringDefineProxy.GetString("SEAL_NOW_DESCRIPTION"), this._UnlockBossName);
		}

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

		public void LevelUp(uint curLevel)
		{
			bool flag = curLevel >= this._sealLevel && this._sealLevel > 0U;
			if (flag)
			{
				this._status = 1U;
				this.RefreshLevelSealTip();
			}
		}

		public void RefreshLevelSealTip()
		{
			bool flag = !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_LevelSeal_Tip, true);
			}
		}

		public bool IsShowLevelSealIcon()
		{
			return XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= this._sealLevel && this._sealLevel != 0U && this._status == 0U;
		}

		public bool IsInLevelSeal()
		{
			return XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= this._sealLevel && this._sealLevel > 0U;
		}

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

		public void DestroyFx(XFx fx)
		{
			bool flag = fx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
				fx = null;
			}
		}

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

		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.LevelUp(xplayerLevelChangedEventArgs.level);
			return true;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("LevelSealDocument");

		private XLevelSealView _view = null;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static LevelSealTypeTable _LevelSealTypeTable = new LevelSealTypeTable();

		private static LevelSealNewFunctionTable _LevelSealNewFunctionTable = new LevelSealNewFunctionTable();

		public static readonly uint REWARD_TIPS_COUNT_MAX = 4U;

		private float _expBuff;

		private uint _sealType = 0U;

		private uint _nextSealLevel;

		private uint _sealLevel = 0U;

		private uint _endTime;

		private uint _killBossCnt;

		private uint _needKillBossCnt;

		private uint _totalCollectCount;

		private uint _selfCollectCount;

		private int _currentSelfCollectIndex;

		private string _UnlockBossName;

		private uint _status;

		private XFx _FxFirework;

		private bool m_HasRedPoint = false;

		private bool m_SelfGiftRedPoint = false;
	}
}
