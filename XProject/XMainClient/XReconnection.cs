using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XReconnection : XSingleton<XReconnection>
	{

		public uint SceneID
		{
			get
			{
				return this._scene_id;
			}
		}

		public DeathInfo PlayerDeathinfo
		{
			get
			{
				return this._player_death_info;
			}
		}

		public RoleAllInfo PlayerInfo
		{
			get
			{
				return this._player_info;
			}
		}

		public UnitAppearance PlayerApperance
		{
			get
			{
				return this._player_appearance;
			}
		}

		public Dictionary<ulong, UnitAppearance> UnitsAppearance
		{
			get
			{
				return this._units_appearance;
			}
		}

		public bool IsAutoFight
		{
			get
			{
				return this._is_auto_fight;
			}
		}

		public bool IsLoginReconnect
		{
			get
			{
				return this._is_login_reconnect;
			}
		}

		public void SetLoginReconnectFlag(bool flag)
		{
			this._is_login_reconnect = flag;
		}

		private bool IsValid(UnitAppearance unit)
		{
			return unit != null && unit.position.x >= XCommon.XEps && unit.position.z >= XCommon.XEps;
		}

		private bool IsPupet(uint specialstate)
		{
			return ((ulong)specialstate & (ulong)(1L << (XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Puppet) & 31))) > 0UL;
		}

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

		public void SetPlayerInfo(RoleAllInfo info)
		{
			this._player_info = info;
		}

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

		private bool OnReconnectFail(IXUIButton button)
		{
			XSingleton<XClientNetwork>.singleton.Close(NetErrCode.Net_NoError);
			XSingleton<XLoginDocument>.singleton.AuthorizationSignOut();
			return true;
		}

		private uint _scene_id;

		private DeathInfo _player_death_info = null;

		private RoleAllInfo _player_info = null;

		private UnitAppearance _player_appearance = null;

		private Dictionary<ulong, UnitAppearance> _units_appearance = new Dictionary<ulong, UnitAppearance>();

		private bool _is_auto_fight;

		private bool _is_login_reconnect;
	}
}
