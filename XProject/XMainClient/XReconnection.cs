using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B3B RID: 2875
	internal class XReconnection : XSingleton<XReconnection>
	{
		// Token: 0x1700301A RID: 12314
		// (get) Token: 0x0600A811 RID: 43025 RVA: 0x001DE900 File Offset: 0x001DCB00
		public uint SceneID
		{
			get
			{
				return this._scene_id;
			}
		}

		// Token: 0x1700301B RID: 12315
		// (get) Token: 0x0600A812 RID: 43026 RVA: 0x001DE918 File Offset: 0x001DCB18
		public DeathInfo PlayerDeathinfo
		{
			get
			{
				return this._player_death_info;
			}
		}

		// Token: 0x1700301C RID: 12316
		// (get) Token: 0x0600A813 RID: 43027 RVA: 0x001DE930 File Offset: 0x001DCB30
		public RoleAllInfo PlayerInfo
		{
			get
			{
				return this._player_info;
			}
		}

		// Token: 0x1700301D RID: 12317
		// (get) Token: 0x0600A814 RID: 43028 RVA: 0x001DE948 File Offset: 0x001DCB48
		public UnitAppearance PlayerApperance
		{
			get
			{
				return this._player_appearance;
			}
		}

		// Token: 0x1700301E RID: 12318
		// (get) Token: 0x0600A815 RID: 43029 RVA: 0x001DE960 File Offset: 0x001DCB60
		public Dictionary<ulong, UnitAppearance> UnitsAppearance
		{
			get
			{
				return this._units_appearance;
			}
		}

		// Token: 0x1700301F RID: 12319
		// (get) Token: 0x0600A816 RID: 43030 RVA: 0x001DE978 File Offset: 0x001DCB78
		public bool IsAutoFight
		{
			get
			{
				return this._is_auto_fight;
			}
		}

		// Token: 0x17003020 RID: 12320
		// (get) Token: 0x0600A817 RID: 43031 RVA: 0x001DE990 File Offset: 0x001DCB90
		public bool IsLoginReconnect
		{
			get
			{
				return this._is_login_reconnect;
			}
		}

		// Token: 0x0600A818 RID: 43032 RVA: 0x001DE9A8 File Offset: 0x001DCBA8
		public void SetLoginReconnectFlag(bool flag)
		{
			this._is_login_reconnect = flag;
		}

		// Token: 0x0600A819 RID: 43033 RVA: 0x001DE9B4 File Offset: 0x001DCBB4
		private bool IsValid(UnitAppearance unit)
		{
			return unit != null && unit.position.x >= XCommon.XEps && unit.position.z >= XCommon.XEps;
		}

		// Token: 0x0600A81A RID: 43034 RVA: 0x001DE9F4 File Offset: 0x001DCBF4
		private bool IsPupet(uint specialstate)
		{
			return ((ulong)specialstate & (ulong)(1L << (XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Puppet) & 31))) > 0UL;
		}

		// Token: 0x0600A81B RID: 43035 RVA: 0x001DEA1C File Offset: 0x001DCC1C
		public void GetReconnectData(PtcG2C_ReconnectSyncNotify data)
		{
			this._scene_id = ((data.Data.scene == null) ? 1U : data.Data.scene.sceneid);
			this._player_death_info = data.Data.deathinfo;
			this._player_info = data.Data.self;
			this._player_appearance = data.Data.selfAppearance;
			this._is_auto_fight = data.Data.isautofight;
			XSingleton<XScene>.singleton.SceneStarted = (data.Data.scene == null || data.Data.scene.isready);
			this._units_appearance.Clear();
			bool flag = !XSingleton<XScene>.singleton.bSpectator;
			if (flag)
			{
				bool flag2 = this.IsValid(this._player_appearance);
				if (flag2)
				{
					this._units_appearance.Add(this._player_appearance.uID, this._player_appearance);
				}
			}
			for (int i = 0; i < data.Data.units.Count; i++)
			{
				bool flag3 = !this._units_appearance.ContainsKey(data.Data.units[i].uID);
				if (flag3)
				{
					this._units_appearance.Add(data.Data.units[i].uID, data.Data.units[i]);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Reconnect have same key ", data.Data.units[i].uID.ToString(), null, null, null, null);
				}
			}
			this.StartReconnectSync();
		}

		// Token: 0x0600A81C RID: 43036 RVA: 0x001DEBD0 File Offset: 0x001DCDD0
		private void StartReconnectSync()
		{
			bool flag = XSingleton<XScene>.singleton.SceneID != this._scene_id || !XSingleton<XScene>.singleton.SceneReady;
			if (flag)
			{
				bool bSceneLoadedRpcSend = XSingleton<XScene>.singleton.bSceneLoadedRpcSend;
				if (bSceneLoadedRpcSend)
				{
					RpcC2G_DoEnterScene rpcC2G_DoEnterScene = new RpcC2G_DoEnterScene();
					rpcC2G_DoEnterScene.oArg.sceneid = XSingleton<XScene>.singleton.SceneID;
					XSingleton<XClientNetwork>.singleton.Send(rpcC2G_DoEnterScene);
				}
			}
			else
			{
				this.SyncData();
			}
		}

		// Token: 0x0600A81D RID: 43037 RVA: 0x001DEC48 File Offset: 0x001DCE48
		private void SyncData()
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				bool flag = XSingleton<XEntityMgr>.singleton.Player != null && this._player_death_info != null;
				if (flag)
				{
					XReviveDocument specificDocument = XDocuments.GetSpecificDocument<XReviveDocument>(XReviveDocument.uuID);
					specificDocument.SetReviveData((int)this._player_death_info.revivecount, (int)this._player_death_info.costrevivecount, this._player_death_info.type);
				}
				XSingleton<XEntityMgr>.singleton.OnReconnect();
				XSingleton<XAttributeMgr>.singleton.OnReconnect();
				XSingleton<XLevelDoodadMgr>.singleton.OnReconnect();
			}
			bool flag2 = !this.IsPupet(this._player_appearance.specialstate);
			if (flag2)
			{
				XSingleton<XCutScene>.singleton.Stop(true);
			}
			bool flag3 = !XSingleton<XScene>.singleton.bSpectator;
			if (flag3)
			{
				XSingleton<XEntityMgr>.singleton.Player.UpdateSpecialStateFromServer(this._player_appearance.specialstate, uint.MaxValue);
			}
			XReconnectedEventArgs @event = XEventPool<XReconnectedEventArgs>.GetEvent();
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			@event.PlayerInfo = this._player_info;
			@event.PlayUnit = this._player_appearance;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600A81E RID: 43038 RVA: 0x001DED6C File Offset: 0x001DCF6C
		public void StartEnterSceneSync(List<UnitAppearance> units)
		{
			bool flag = units.Count == 0;
			if (!flag)
			{
				this._units_appearance.Clear();
				bool flag2 = !XSingleton<XScene>.singleton.bSpectator;
				if (flag2)
				{
					bool flag3 = this.IsValid(this._player_appearance);
					if (flag3)
					{
						this._units_appearance.Add(XSingleton<XEntityMgr>.singleton.Player.ID, this._player_appearance);
					}
				}
				for (int i = 0; i < units.Count; i++)
				{
					bool flag4 = !this._units_appearance.ContainsKey(units[i].uID);
					if (flag4)
					{
						this._units_appearance.Add(units[i].uID, units[i]);
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Reconnect have same key ", units[i].uID.ToString(), null, null, null, null);
					}
				}
				bool syncMode = XSingleton<XGame>.singleton.SyncMode;
				if (syncMode)
				{
					XSingleton<XEntityMgr>.singleton.OnReconnect();
				}
			}
		}

		// Token: 0x0600A81F RID: 43039 RVA: 0x001DEE83 File Offset: 0x001DD083
		public void SetPlayerInfo(RoleAllInfo info)
		{
			this._player_info = info;
		}

		// Token: 0x0600A820 RID: 43040 RVA: 0x001DEE90 File Offset: 0x001DD090
		public void StartLoginReconnectSync(LoginReconnectEnterSceneData data, List<UnitAppearance> units)
		{
			bool flag = data == null;
			if (!flag)
			{
				this._scene_id = XSingleton<XScene>.singleton.SceneID;
				this._player_death_info = data.deathinfo;
				this._player_appearance = data.selfAppearance;
				this._is_auto_fight = data.isautofight;
				XSingleton<XScene>.singleton.SceneStarted = true;
				bool flag2 = XSingleton<XEntityMgr>.singleton.Player != null && data.deathinfo != null;
				if (flag2)
				{
					XReviveDocument specificDocument = XDocuments.GetSpecificDocument<XReviveDocument>(XReviveDocument.uuID);
					specificDocument.SetReviveData((int)data.deathinfo.revivecount, (int)data.deathinfo.costrevivecount, data.deathinfo.type);
				}
				this._units_appearance.Clear();
				bool flag3 = !XSingleton<XScene>.singleton.bSpectator;
				if (flag3)
				{
					bool flag4 = this.IsValid(this._player_appearance);
					if (flag4)
					{
						this._units_appearance.Add(this._player_appearance.uID, this._player_appearance);
					}
				}
				for (int i = 0; i < units.Count; i++)
				{
					bool flag5 = !this._units_appearance.ContainsKey(units[i].uID);
					if (flag5)
					{
						this._units_appearance.Add(units[i].uID, units[i]);
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Reconnect have same key ", units[i].uID.ToString(), null, null, null, null);
					}
				}
				this.SyncData();
			}
		}

		// Token: 0x0600A821 RID: 43041 RVA: 0x001DF024 File Offset: 0x001DD224
		private bool OnReconnectFail(IXUIButton button)
		{
			XSingleton<XClientNetwork>.singleton.Close(NetErrCode.Net_NoError);
			XSingleton<XLoginDocument>.singleton.AuthorizationSignOut();
			return true;
		}

		// Token: 0x04003E41 RID: 15937
		private uint _scene_id;

		// Token: 0x04003E42 RID: 15938
		private DeathInfo _player_death_info = null;

		// Token: 0x04003E43 RID: 15939
		private RoleAllInfo _player_info = null;

		// Token: 0x04003E44 RID: 15940
		private UnitAppearance _player_appearance = null;

		// Token: 0x04003E45 RID: 15941
		private Dictionary<ulong, UnitAppearance> _units_appearance = new Dictionary<ulong, UnitAppearance>();

		// Token: 0x04003E46 RID: 15942
		private bool _is_auto_fight;

		// Token: 0x04003E47 RID: 15943
		private bool _is_login_reconnect;
	}
}
