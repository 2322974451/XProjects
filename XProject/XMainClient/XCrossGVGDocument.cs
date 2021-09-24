using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCrossGVGDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XCrossGVGDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public bool InterfaceState
		{
			get
			{
				return this._interfaceIconState;
			}
		}

		public bool HasDuelCombat
		{
			get
			{
				return this._hasDuelCombat;
			}
		}

		public uint RegisterationCount
		{
			get
			{
				return this.m_registrationCount;
			}
		}

		public CrossGvgTimeState TimeStep
		{
			get
			{
				return this._timeState;
			}
		}

		public CrossGvgRoomState RoomState
		{
			get
			{
				return this._SelfRoomState;
			}
		}

		public bool VisibleEnterBattle
		{
			get
			{
				return this._visibleEnterBattle;
			}
		}

		public bool HasAvailableJoin
		{
			get
			{
				return this._hasAvailableJoin;
			}
		}

		public XBetterList<XGVGGuildInfo> GVGRanks
		{
			get
			{
				return this._guildList.BufferValues;
			}
		}

		public List<GVGDuelCombatInfo> GVGDuels
		{
			get
			{
				return this._duelRecords;
			}
		}

		public void SetMainInterfaceBtnState(bool active)
		{
			this._interfaceIconState = active;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_CrossGVG, true);
			}
		}

		public string ToSupportString()
		{
			return string.Format("{0}/{1}", (this._supportGuildIDs == null) ? 0 : this._supportGuildIDs.Count, XSingleton<XGlobalConfig>.singleton.GetInt("CrossGvgSupport"));
		}

		public bool IsSupportExist(ulong guildID)
		{
			return this._supportGuildIDs != null && this._supportGuildIDs.Contains(guildID);
		}

		public bool IsSupportFull()
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("CrossGvgSupport");
			return this._supportGuildIDs == null || this._supportGuildIDs.Count >= @int;
		}

		public void SynCrossGVGTimeState(CrossGvgTimeState state)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Cross State = " + state.ToString(), null, null, null, null, null);
			this._timeState = state;
			GuildArenaTab guildArenaTab = this.SelectTabIndex;
			switch (this._timeState)
			{
			case CrossGvgTimeState.CGVG_NotOpen:
			case CrossGvgTimeState.CGVG_Select:
				guildArenaTab = GuildArenaTab.Hall;
				break;
			case CrossGvgTimeState.CGVG_PointRace:
				guildArenaTab = GuildArenaTab.Duel;
				break;
			case CrossGvgTimeState.CGVG_Guess:
			case CrossGvgTimeState.CGVG_Knockout:
			case CrossGvgTimeState.CGVG_SeasonEnd:
				guildArenaTab = GuildArenaTab.Combat;
				break;
			}
			bool flag = DlgBase<CrossGVGMainView, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = guildArenaTab == this.SelectTabIndex;
				if (flag2)
				{
					DlgBase<CrossGVGMainView, TabDlgBehaviour>.singleton.RefreshData();
				}
				else
				{
					DlgBase<CrossGVGMainView, TabDlgBehaviour>.singleton.SelectTabIndex(guildArenaTab);
				}
			}
		}

		public XGuildBasicData GetGVGGuildInfo(ulong guildID)
		{
			return (guildID > 0UL && this._guildList.ContainsKey(guildID)) ? this._guildList[guildID] : null;
		}

		public void SendCrossGVGOper(CrossGvgOperType type, ulong uid = 0UL)
		{
			RpcC2M_CrossGvgOper rpcC2M_CrossGvgOper = new RpcC2M_CrossGvgOper();
			rpcC2M_CrossGvgOper.oArg.type = type;
			if (type == CrossGvgOperType.CGOT_SupportGuild)
			{
				bool flag = uid > 0UL;
				if (flag)
				{
					rpcC2M_CrossGvgOper.oArg.support_guildid.Add(uid);
				}
			}
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CrossGvgOper);
		}

		public void NotifyCrossGVGOper(CrossGvgOperArg oArg, CrossGvgOperRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				bool flag2 = oArg.type == CrossGvgOperType.CGOT_SupportGuild;
				if (flag2)
				{
					bool flag3 = this._supportGuildIDs == null;
					if (flag3)
					{
						this._supportGuildIDs = new List<ulong>();
					}
					int i = 0;
					int count = oArg.support_guildid.Count;
					while (i < count)
					{
						bool flag4 = this._supportGuildIDs.Contains(oArg.support_guildid[i]);
						if (!flag4)
						{
							this._supportGuildIDs.Add(oArg.support_guildid[i]);
						}
						i++;
					}
					bool flag5 = DlgBase<CrossGVGMainView, TabDlgBehaviour>.singleton.IsVisible();
					if (flag5)
					{
						DlgBase<CrossGVGMainView, TabDlgBehaviour>.singleton.RefreshData();
					}
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
		}

		public void SendCrossGVGData()
		{
			RpcC2M_GetCrossGvgData rpc = new RpcC2M_GetCrossGvgData();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReceiveCrossGVGData(GetCrossGvgDataRes res)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("GetCrossGvgDataRes = " + res.rank.ToString() + " : " + res.record.ToString(), null, null, null, null, null);
			this._supportGuildIDs = res.support_guildid;
			this.m_registrationCount = res.season_num;
			this.ConvertGuildList(res.rank);
			this.ConvertDuelRecord(res.record);
			this.ConvertCombatRecord(res.rooms);
			bool flag = DlgBase<CrossGVGMainView, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<CrossGVGMainView, TabDlgBehaviour>.singleton.RefreshData();
			}
		}

		public void NotifyCrossGVGRoomState(CrossGvgRoomInfo room, CrossGvgRacePointRecord record)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("NotifyCrossGVGRoomState :room = " + (room == null).ToString() + " record =  " + (record == null).ToString(), null, null, null, null, null);
			bool flag = this.ConvertDuelRecord(record) || this.ConvertCombatRecord(room);
			if (flag)
			{
				bool flag2 = DlgBase<CrossGVGMainView, TabDlgBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<CrossGVGMainView, TabDlgBehaviour>.singleton.RefreshData();
				}
			}
		}

		public bool TryGetCombatRoom(uint roomID, out XGVGCombatGroupData combatData)
		{
			return this._combatGroups.TryGetValue(roomID, out combatData);
		}

		private void ConvertGuildList(List<CrossGvgGuildInfo> ranks)
		{
			this._guildList.Clear();
			int i = 0;
			int count = ranks.Count;
			while (i < count)
			{
				XGVGGuildInfo xgvgguildInfo = new XGVGGuildInfo();
				xgvgguildInfo.Setup(ranks[i]);
				this._guildList.Add(xgvgguildInfo.uid, xgvgguildInfo);
				i++;
			}
		}

		private void ConvertCombatRecord(List<CrossGvgRoomInfo> rooms)
		{
			this._SelfRoomState = CrossGvgRoomState.CGRS_Idle;
			this._visibleEnterBattle = false;
			this._hasAvailableJoin = false;
			int i = 0;
			int count = rooms.Count;
			while (i < count)
			{
				this.ConvertCombatRecord(rooms[i]);
				i++;
			}
		}

		private bool ConvertCombatRecord(CrossGvgRoomInfo room)
		{
			bool flag = room == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XGVGCombatGroupData xgvgcombatGroupData = null;
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				bool flag2 = !this._combatGroups.TryGetValue(room.roomid, out xgvgcombatGroupData);
				if (flag2)
				{
					xgvgcombatGroupData = new XGVGCombatGroupData();
					this._combatGroups.Add(room.roomid, xgvgcombatGroupData);
				}
				xgvgcombatGroupData.Convert(room);
				bool flag3 = xgvgcombatGroupData.InCombatGroup(specificDocument.UID);
				if (flag3)
				{
					this._hasAvailableJoin = true;
					this._SelfRoomState = xgvgcombatGroupData.RoomState;
					this._visibleEnterBattle = (xgvgcombatGroupData.WinnerID == 0UL || (xgvgcombatGroupData.WinnerID == specificDocument.UID && xgvgcombatGroupData.RoomID != 7U));
				}
				result = true;
			}
			return result;
		}

		private void ConvertDuelRecord(List<CrossGvgRacePointRecord> records)
		{
			int count = records.Count;
			this._hasDuelCombat = (count > 0);
			this._duelRecords.Clear();
			int i = 0;
			int count2 = records.Count;
			while (i < count2)
			{
				GVGDuelCombatInfo gvgduelCombatInfo = new GVGDuelCombatInfo();
				gvgduelCombatInfo.Setup(records[i]);
				this._duelRecords.Add(gvgduelCombatInfo);
				i++;
			}
		}

		private bool ConvertDuelRecord(CrossGvgRacePointRecord record)
		{
			bool flag = record == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int i = 0;
				int count = this._duelRecords.Count;
				while (i < count)
				{
					bool flag2 = this._duelRecords[i] != null && this._duelRecords[i].roomID == record.roomid;
					if (flag2)
					{
						this._duelRecords[i].Setup(record);
						return true;
					}
					i++;
				}
				result = false;
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CrossGVGDocument");

		private CrossGvgTimeState _timeState = CrossGvgTimeState.CGVG_NotOpen;

		public GuildArenaTab SelectTabIndex = GuildArenaTab.Hall;

		private List<GVGDuelCombatInfo> _duelRecords = new List<GVGDuelCombatInfo>();

		private List<ulong> _supportGuildIDs;

		private CrossGvgRoomState _SelfRoomState = CrossGvgRoomState.CGRS_Idle;

		private bool _visibleEnterBattle = false;

		private bool _hasAvailableJoin = false;

		private XBetterDictionary<ulong, XGVGGuildInfo> _guildList = new XBetterDictionary<ulong, XGVGGuildInfo>(0);

		private Dictionary<uint, XGVGCombatGroupData> _combatGroups = new Dictionary<uint, XGVGCombatGroupData>();

		private uint m_registrationCount;

		private bool _hasDuelCombat = false;

		private bool _interfaceIconState = false;
	}
}
