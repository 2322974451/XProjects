using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008FD RID: 2301
	internal class XCrossGVGDocument : XDocComponent
	{
		// Token: 0x17002B34 RID: 11060
		// (get) Token: 0x06008B09 RID: 35593 RVA: 0x001289A4 File Offset: 0x00126BA4
		public override uint ID
		{
			get
			{
				return XCrossGVGDocument.uuID;
			}
		}

		// Token: 0x06008B0A RID: 35594 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x17002B35 RID: 11061
		// (get) Token: 0x06008B0B RID: 35595 RVA: 0x001289BC File Offset: 0x00126BBC
		public bool InterfaceState
		{
			get
			{
				return this._interfaceIconState;
			}
		}

		// Token: 0x17002B36 RID: 11062
		// (get) Token: 0x06008B0C RID: 35596 RVA: 0x001289D4 File Offset: 0x00126BD4
		public bool HasDuelCombat
		{
			get
			{
				return this._hasDuelCombat;
			}
		}

		// Token: 0x17002B37 RID: 11063
		// (get) Token: 0x06008B0D RID: 35597 RVA: 0x001289EC File Offset: 0x00126BEC
		public uint RegisterationCount
		{
			get
			{
				return this.m_registrationCount;
			}
		}

		// Token: 0x17002B38 RID: 11064
		// (get) Token: 0x06008B0E RID: 35598 RVA: 0x00128A04 File Offset: 0x00126C04
		public CrossGvgTimeState TimeStep
		{
			get
			{
				return this._timeState;
			}
		}

		// Token: 0x17002B39 RID: 11065
		// (get) Token: 0x06008B0F RID: 35599 RVA: 0x00128A1C File Offset: 0x00126C1C
		public CrossGvgRoomState RoomState
		{
			get
			{
				return this._SelfRoomState;
			}
		}

		// Token: 0x17002B3A RID: 11066
		// (get) Token: 0x06008B10 RID: 35600 RVA: 0x00128A34 File Offset: 0x00126C34
		public bool VisibleEnterBattle
		{
			get
			{
				return this._visibleEnterBattle;
			}
		}

		// Token: 0x17002B3B RID: 11067
		// (get) Token: 0x06008B11 RID: 35601 RVA: 0x00128A4C File Offset: 0x00126C4C
		public bool HasAvailableJoin
		{
			get
			{
				return this._hasAvailableJoin;
			}
		}

		// Token: 0x17002B3C RID: 11068
		// (get) Token: 0x06008B12 RID: 35602 RVA: 0x00128A64 File Offset: 0x00126C64
		public XBetterList<XGVGGuildInfo> GVGRanks
		{
			get
			{
				return this._guildList.BufferValues;
			}
		}

		// Token: 0x17002B3D RID: 11069
		// (get) Token: 0x06008B13 RID: 35603 RVA: 0x00128A84 File Offset: 0x00126C84
		public List<GVGDuelCombatInfo> GVGDuels
		{
			get
			{
				return this._duelRecords;
			}
		}

		// Token: 0x06008B14 RID: 35604 RVA: 0x00128A9C File Offset: 0x00126C9C
		public void SetMainInterfaceBtnState(bool active)
		{
			this._interfaceIconState = active;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_CrossGVG, true);
			}
		}

		// Token: 0x06008B15 RID: 35605 RVA: 0x00128AD0 File Offset: 0x00126CD0
		public string ToSupportString()
		{
			return string.Format("{0}/{1}", (this._supportGuildIDs == null) ? 0 : this._supportGuildIDs.Count, XSingleton<XGlobalConfig>.singleton.GetInt("CrossGvgSupport"));
		}

		// Token: 0x06008B16 RID: 35606 RVA: 0x00128B1C File Offset: 0x00126D1C
		public bool IsSupportExist(ulong guildID)
		{
			return this._supportGuildIDs != null && this._supportGuildIDs.Contains(guildID);
		}

		// Token: 0x06008B17 RID: 35607 RVA: 0x00128B48 File Offset: 0x00126D48
		public bool IsSupportFull()
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("CrossGvgSupport");
			return this._supportGuildIDs == null || this._supportGuildIDs.Count >= @int;
		}

		// Token: 0x06008B18 RID: 35608 RVA: 0x00128B88 File Offset: 0x00126D88
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

		// Token: 0x06008B19 RID: 35609 RVA: 0x00128C3C File Offset: 0x00126E3C
		public XGuildBasicData GetGVGGuildInfo(ulong guildID)
		{
			return (guildID > 0UL && this._guildList.ContainsKey(guildID)) ? this._guildList[guildID] : null;
		}

		// Token: 0x06008B1A RID: 35610 RVA: 0x00128C70 File Offset: 0x00126E70
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

		// Token: 0x06008B1B RID: 35611 RVA: 0x00128CC4 File Offset: 0x00126EC4
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

		// Token: 0x06008B1C RID: 35612 RVA: 0x00128D98 File Offset: 0x00126F98
		public void SendCrossGVGData()
		{
			RpcC2M_GetCrossGvgData rpc = new RpcC2M_GetCrossGvgData();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008B1D RID: 35613 RVA: 0x00128DB8 File Offset: 0x00126FB8
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

		// Token: 0x06008B1E RID: 35614 RVA: 0x00128E54 File Offset: 0x00127054
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

		// Token: 0x06008B1F RID: 35615 RVA: 0x00128ECC File Offset: 0x001270CC
		public bool TryGetCombatRoom(uint roomID, out XGVGCombatGroupData combatData)
		{
			return this._combatGroups.TryGetValue(roomID, out combatData);
		}

		// Token: 0x06008B20 RID: 35616 RVA: 0x00128EEC File Offset: 0x001270EC
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

		// Token: 0x06008B21 RID: 35617 RVA: 0x00128F48 File Offset: 0x00127148
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

		// Token: 0x06008B22 RID: 35618 RVA: 0x00128F94 File Offset: 0x00127194
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

		// Token: 0x06008B23 RID: 35619 RVA: 0x00129058 File Offset: 0x00127258
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

		// Token: 0x06008B24 RID: 35620 RVA: 0x001290C4 File Offset: 0x001272C4
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

		// Token: 0x04002C6F RID: 11375
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CrossGVGDocument");

		// Token: 0x04002C70 RID: 11376
		private CrossGvgTimeState _timeState = CrossGvgTimeState.CGVG_NotOpen;

		// Token: 0x04002C71 RID: 11377
		public GuildArenaTab SelectTabIndex = GuildArenaTab.Hall;

		// Token: 0x04002C72 RID: 11378
		private List<GVGDuelCombatInfo> _duelRecords = new List<GVGDuelCombatInfo>();

		// Token: 0x04002C73 RID: 11379
		private List<ulong> _supportGuildIDs;

		// Token: 0x04002C74 RID: 11380
		private CrossGvgRoomState _SelfRoomState = CrossGvgRoomState.CGRS_Idle;

		// Token: 0x04002C75 RID: 11381
		private bool _visibleEnterBattle = false;

		// Token: 0x04002C76 RID: 11382
		private bool _hasAvailableJoin = false;

		// Token: 0x04002C77 RID: 11383
		private XBetterDictionary<ulong, XGVGGuildInfo> _guildList = new XBetterDictionary<ulong, XGVGGuildInfo>(0);

		// Token: 0x04002C78 RID: 11384
		private Dictionary<uint, XGVGCombatGroupData> _combatGroups = new Dictionary<uint, XGVGCombatGroupData>();

		// Token: 0x04002C79 RID: 11385
		private uint m_registrationCount;

		// Token: 0x04002C7A RID: 11386
		private bool _hasDuelCombat = false;

		// Token: 0x04002C7B RID: 11387
		private bool _interfaceIconState = false;
	}
}
