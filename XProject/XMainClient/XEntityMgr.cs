using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XEntityMgr : XSingleton<XEntityMgr>
	{

		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/PlayerLevel", this._level_table, false);
				this._async_loader.AddTask("Table/XEntityPresentation", this._entity_data_info, false);
				this._async_loader.AddTask("Table/Profession", this._role_data_info, false);
				this._async_loader.AddTask("Table/XEntityStatistics", this._statistics_data_info, false);
				this._async_loader.AddTask("Table/XNpcList", this._npc_data_info, false);
				this._async_loader.AddTask("Table/SuperArmorRecoveryCoffTable", this._super_armor_coff_info, false);
				this._async_loader.Execute(null);
			}
			bool flag2 = !this._async_loader.IsDone;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				foreach (XNpcInfo.RowData rowData in this._npc_data_info.Table)
				{
					List<uint> list = null;
					bool flag3 = !this._scene_npcs.TryGetValue(rowData.SceneID, out list);
					if (flag3)
					{
						list = new List<uint>();
						this._scene_npcs.Add(rowData.SceneID, list);
					}
					list.Add(rowData.ID);
				}
				result = true;
			}
			return result;
		}

		public override void Uninit()
		{
			this._async_loader = null;
			this._empty.Clear();
			this._entities.Clear();
			this._scene_npcs.Clear();
			this._npcs.Clear();
			this._entities_itor.Clear();
			this._addlist.Clear();
			this._removelist.Clear();
		}

		public SuperArmorRecoveryCoffTable SuperArmorCoffTable
		{
			get
			{
				return this._super_armor_coff_info;
			}
		}

		public PlayerLevelTable LevelTable
		{
			get
			{
				return this._level_table;
			}
		}

		public XEntityPresentation EntityInfo
		{
			get
			{
				return this._entity_data_info;
			}
		}

		public ProfessionTable RoleInfo
		{
			get
			{
				return this._role_data_info;
			}
		}

		public XEntityStatistics EntityStatistics
		{
			get
			{
				return this._statistics_data_info;
			}
		}

		public XNpcInfo NpcInfo
		{
			get
			{
				return this._npc_data_info;
			}
		}

		public XPlayer Player { get; set; }

		public XBoss Boss { get; set; }

		public XEntity GetEntity(ulong id)
		{
			XEntity xentity = null;
			bool flag = this._entities.TryGetValue(id, out xentity);
			XEntity result;
			if (flag)
			{
				result = ((xentity.IsDead && !xentity.IsPlayer) ? null : xentity);
			}
			else
			{
				result = null;
			}
			return result;
		}

		public XEntity GetEntityExcludeDeath(ulong id)
		{
			XEntity xentity = null;
			bool flag = this._entities.TryGetValue(id, out xentity);
			XEntity result;
			if (flag)
			{
				result = (xentity.IsDead ? null : xentity);
			}
			else
			{
				result = null;
			}
			return result;
		}

		public XEntity GetEntityConsiderDeath(ulong id)
		{
			XEntity xentity = null;
			bool flag = this._entities.TryGetValue(id, out xentity);
			XEntity result;
			if (flag)
			{
				result = (xentity.Deprecated ? null : xentity);
			}
			else
			{
				result = null;
			}
			return result;
		}

		public List<uint> GetNpcs(uint scene_id)
		{
			return this._scene_npcs.ContainsKey(scene_id) ? this._scene_npcs[scene_id] : null;
		}

		public XNpc GetNpc(uint id)
		{
			XNpc result = null;
			this._npcs.TryGetValue(id, out result);
			return result;
		}

		public XPlayer CreatePlayer(Vector3 position, Quaternion rotation, bool autoAdd, bool emptyPrefab = false)
		{
			XPlayer xplayer = this.PrepareEntity<XPlayer>(XSingleton<XAttributeMgr>.singleton.XPlayerData, position, rotation, autoAdd, false, emptyPrefab, false);
			xplayer.OnCreated();
			return xplayer;
		}

		public XRole CreateRole(XAttributes attr, Vector3 position, Quaternion rotation, bool autoAdd, bool emptyPrefab = false)
		{
			XRole xrole = this.PrepareEntity<XRole>(attr, position, rotation, autoAdd, false, emptyPrefab, true);
			xrole.OnCreated();
			return xrole;
		}

		private XEntity PreCreateEntity(XAttributes attr, Vector3 position, Quaternion rotation, bool autoAdd, bool transform = false)
		{
			XEntity result = null;
			switch (attr.Type)
			{
			case EntitySpecies.Species_Boss:
				result = this.PrepareEntity<XBoss>(attr, position, rotation, autoAdd, transform, false, true);
				break;
			case EntitySpecies.Species_Opposer:
				result = this.PrepareEntity<XOpposer>(attr, position, rotation, autoAdd, transform, false, true);
				break;
			case EntitySpecies.Species_Puppet:
				result = this.PrepareEntity<XPuppet>(attr, position, rotation, autoAdd, transform, false, true);
				break;
			case EntitySpecies.Species_Substance:
				result = this.PrepareEntity<XSubstance>(attr, position, rotation, autoAdd, transform, false, true);
				break;
			case EntitySpecies.Species_Elite:
				result = this.PrepareEntity<XElite>(attr, position, rotation, autoAdd, transform, false, true);
				break;
			}
			return result;
		}

		private void PostCreateEntity(XEntity e)
		{
			bool flag = e != null;
			if (flag)
			{
				e.OnCreated();
			}
		}

		public XEntity CreateEntityByCaller(XEntity caller, uint id, Vector3 position, Quaternion rotation, bool autoAdd, uint fightgroup = 4294967295U)
		{
			XAttributes attr = XSingleton<XAttributeMgr>.singleton.InitAttrFromClient(id, null, fightgroup);
			XEntity xentity = this.PreCreateEntity(attr, position, rotation, autoAdd, false);
			xentity.MobbedBy = caller;
			this.PostCreateEntity(xentity);
			return xentity;
		}

		public XEntity CreateEntity(XAttributes attr, Vector3 position, Quaternion rotation, bool autoAdd)
		{
			XEntity xentity = this.PreCreateEntity(attr, position, rotation, autoAdd, false);
			this.PostCreateEntity(xentity);
			return xentity;
		}

		public XEntity CreateEntity(uint id, Vector3 position, Quaternion rotation, bool autoAdd, uint fightgroup = 4294967295U)
		{
			return this.CreateEntity(XSingleton<XAttributeMgr>.singleton.InitAttrFromClient(id, null, fightgroup), position, rotation, autoAdd);
		}

		public XEntity CreateTransform(uint id, Vector3 position, Quaternion rotation, bool autoAdd, XEntity transformee, uint fightgroup = 4294967295U)
		{
			XAttributes xattributes = XSingleton<XAttributeMgr>.singleton.InitAttrFromClient(id, null, fightgroup);
			bool flag = xattributes != null;
			XEntity result;
			if (flag)
			{
				XEntity xentity = this.PreCreateEntity(xattributes, position, rotation, autoAdd, true);
				xentity.OnTransform(transformee);
				this.PostCreateEntity(xentity);
				result = xentity;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void PreloadTemp(uint present_id, uint type_id, EntitySpecies spe)
		{
			XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(present_id);
			string skillprefix = "SkillPackage/" + byPresentID.SkillLocation;
			bool force = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA;
			bool flag = !string.IsNullOrEmpty(byPresentID.A);
			if (flag)
			{
				XSkillData.PreLoadSkillForTemp(skillprefix, byPresentID.A, force);
			}
			bool flag2 = !string.IsNullOrEmpty(byPresentID.AA);
			if (flag2)
			{
				XSkillData.PreLoadSkillForTemp(skillprefix, byPresentID.AA, force);
			}
			bool flag3 = !string.IsNullOrEmpty(byPresentID.AAA);
			if (flag3)
			{
				XSkillData.PreLoadSkillForTemp(skillprefix, byPresentID.AAA, force);
			}
			bool flag4 = !string.IsNullOrEmpty(byPresentID.AAAA);
			if (flag4)
			{
				XSkillData.PreLoadSkillForTemp(skillprefix, byPresentID.AAAA, force);
			}
			bool flag5 = !string.IsNullOrEmpty(byPresentID.AAAAA);
			if (flag5)
			{
				XSkillData.PreLoadSkillForTemp(skillprefix, byPresentID.AAAAA, force);
			}
			bool flag6 = !string.IsNullOrEmpty(byPresentID.Appear);
			if (flag6)
			{
				XSkillData.PreLoadSkillForTemp(skillprefix, byPresentID.Appear, force);
			}
			bool flag7 = !string.IsNullOrEmpty(byPresentID.Disappear);
			if (flag7)
			{
				XSkillData.PreLoadSkillForTemp(skillprefix, byPresentID.Disappear, force);
			}
			bool flag8 = !string.IsNullOrEmpty(byPresentID.Dash);
			if (flag8)
			{
				XSkillData.PreLoadSkillForTemp(skillprefix, byPresentID.Dash, force);
			}
			bool flag9 = !string.IsNullOrEmpty(byPresentID.SuperArmorRecoverySkill);
			if (flag9)
			{
				XSkillData.PreLoadSkillForTemp(skillprefix, byPresentID.SuperArmorRecoverySkill, force);
			}
			bool flag10 = !string.IsNullOrEmpty(byPresentID.ArmorBroken);
			if (flag10)
			{
				XSkillData.PreLoadSkillForTemp(skillprefix, byPresentID.ArmorBroken, force);
			}
			bool flag11 = byPresentID.OtherSkills != null;
			if (flag11)
			{
				int i = 0;
				int num = byPresentID.OtherSkills.Length;
				while (i < num)
				{
					bool flag12 = !string.IsNullOrEmpty(byPresentID.OtherSkills[i]) && byPresentID.OtherSkills[i] != "E";
					if (flag12)
					{
						XSkillData.PreLoadSkillForTemp(skillprefix, byPresentID.OtherSkills[i], force);
					}
					i++;
				}
			}
		}

		public XDummy CreateDummy(uint present_id, uint type_id, XOutlookData outlookData, bool autoAdd = false, bool demonstration = false, bool asyncLoad = true)
		{
			XDummy xdummy = this.PrepareDummy(present_id, type_id, outlookData, autoAdd, demonstration, asyncLoad);
			xdummy.OnCreated();
			return xdummy;
		}

		public XDummy CreateDummy(uint type_id, Vector3 position, Quaternion rotation)
		{
			return this.PrepareDummy(type_id, position, rotation);
		}

		public XAffiliate CreateAffiliate(uint present_id, XEntity mainbody)
		{
			return this.PrepareAffiliate(present_id, mainbody);
		}

		public XAffiliate CreateAffiliate(uint present_id, XGameObject go, XEntity mainbody)
		{
			return this.PrepareAffiliate(present_id, go, mainbody);
		}

		public XMount CreateMount(uint present_id, XEntity mainbody, bool isCopilot)
		{
			return XEntity.ValideEntity(mainbody) ? this.PrepareMount(present_id, mainbody, isCopilot) : null;
		}

		public XEmpty CreateEmpty()
		{
			XEmpty xempty = this.PrepareEmpty();
			xempty.OnCreated();
			return xempty;
		}

		public XNpc CreateNpc(uint id, bool autoAdd)
		{
			bool flag = this._npcs.ContainsKey(id);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("npc has already exist: ", id.ToString(), null, null, null, null);
				this.DestroyNpc(id);
			}
			XNpcAttributes xnpcAttributes = XSingleton<XAttributeMgr>.singleton.InitNpcAttr(id);
			XNpc xnpc = this.PrepareEntity<XNpc>(xnpcAttributes, xnpcAttributes.Position, Quaternion.Euler(xnpcAttributes.Rotation), autoAdd, false, false, true);
			xnpc.OnCreated();
			this._npcs.Add(id, xnpc);
			return xnpc;
		}

		public void DestroyNpc(uint id)
		{
			XNpc x;
			bool flag = this._npcs.TryGetValue(id, out x);
			if (flag)
			{
				this._npcs.Remove(id);
				this.DestroyEntity(x);
			}
		}

		public void DestroyEntity(XEntity x)
		{
			bool flag = x == null || x.Deprecated;
			if (!flag)
			{
				bool flag2 = !this._entities.ContainsKey(x.ID);
				if (flag2)
				{
					this.DestroyImmediate(x);
					this._addlist.Remove(x);
					this._removelist.Remove(x);
				}
				else
				{
					x.Destroying = true;
					x.OnDestroy();
					this.SafeRemove(x);
				}
			}
		}

		public void DestroyImmediate(XEntity x)
		{
			bool flag = x == null || x.Deprecated;
			if (!flag)
			{
				x.Destroying = true;
				x.OnDestroy();
				x.Uninitilize();
			}
		}

		public void DestroyEntity(ulong id)
		{
			this.DestroyEntity(this.GetEntityConsiderDeath(id));
		}

		public void OnReconnect()
		{
			foreach (KeyValuePair<ulong, XEntity> keyValuePair in this._entities)
			{
				UnitAppearance unitAppearance;
				bool flag = XSingleton<XReconnection>.singleton.UnitsAppearance.TryGetValue(keyValuePair.Key, out unitAppearance);
				if (flag)
				{
					bool flag2 = !keyValuePair.Value.IsPuppet && !keyValuePair.Value.IsSubstance;
					if (flag2)
					{
						keyValuePair.Value.CorrectMe(new Vector3(unitAppearance.position.x, unitAppearance.position.y, unitAppearance.position.z), XSingleton<XCommon>.singleton.FloatToAngle(unitAppearance.direction), true, false);
						bool flag3 = keyValuePair.Value.IsDead ^ unitAppearance.IsDead;
						if (flag3)
						{
							bool isDead = unitAppearance.IsDead;
							if (isDead)
							{
								XSingleton<XDeath>.singleton.DeathDetect(keyValuePair.Value, null, true);
							}
							else
							{
								bool isPlayer = keyValuePair.Value.IsPlayer;
								if (isPlayer)
								{
									XPlayer xplayer = keyValuePair.Value as XPlayer;
									bool flag4 = xplayer != null;
									if (flag4)
									{
										xplayer.Revive();
									}
								}
								else
								{
									XRole xrole = keyValuePair.Value as XRole;
									bool flag5 = xrole != null;
									if (flag5)
									{
										xrole.Revive();
									}
								}
							}
						}
						keyValuePair.Value.Attributes.InitAttribute(unitAppearance.attributes);
						bool flag6 = keyValuePair.Value.Buffs != null;
						if (flag6)
						{
							keyValuePair.Value.Buffs.InitFromServer(unitAppearance.buffs, unitAppearance.allbuffsinfo);
						}
						bool flag7 = !XSingleton<XCutScene>.singleton.IsPlaying;
						if (flag7)
						{
							this.Puppets(keyValuePair.Value, false, false);
						}
						keyValuePair.Value.OnReconnect(unitAppearance);
					}
				}
				else
				{
					bool flag8 = !keyValuePair.Value.IsNpc && !keyValuePair.Value.IsPlayer && !keyValuePair.Value.IsDummy;
					if (flag8)
					{
						this.DestroyEntity(keyValuePair.Value);
					}
				}
			}
			foreach (KeyValuePair<ulong, UnitAppearance> keyValuePair2 in XSingleton<XReconnection>.singleton.UnitsAppearance)
			{
				bool flag9 = !this._entities.ContainsKey(keyValuePair2.Key);
				if (flag9)
				{
					this.CreateEntityByUnitAppearance(keyValuePair2.Value);
				}
			}
		}

		public void OnLeaveScene()
		{
			XLeaveSceneArgs @event = XEventPool<XLeaveSceneArgs>.GetEvent();
			@event.Firer = this.Player;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			foreach (KeyValuePair<ulong, XEntity> keyValuePair in this._entities)
			{
				this.DestroyImmediate(keyValuePair.Value);
			}
			for (int i = 0; i < this._addlist.Count; i++)
			{
				this.DestroyImmediate(this._addlist[i]);
			}
			for (int j = 0; j < this._removelist.Count; j++)
			{
				this._removelist[j].Uninitilize();
			}
			this._addlist.Clear();
			this._removelist.Clear();
			this._entities.Clear();
			this._npcs.Clear();
			this._entities_itor.Clear();
		}

		public void KillAlly(XEntity me)
		{
			List<XEntity> ally = this.GetAlly(me);
			for (int i = 0; i < ally.Count; i++)
			{
				bool flag = ally[i] != me;
				if (flag)
				{
					ally[i].Attributes.ForceDeath();
				}
			}
		}

		public void Update(float fDeltaT)
		{
			this.Iterate(this._entities_itor, fDeltaT);
		}

		public void PostUpdate(float fDeltaT)
		{
			this.PostIterate(this._entities_itor, fDeltaT);
			this.InnerAdd();
			this.InnerRemove();
		}

		public void FixedUpdate()
		{
		}

		public bool IsNeutral(XEntity e)
		{
			return e.Attributes == null || this.IsNeutral(e.Attributes.FightGroup);
		}

		public bool IsNeutral(uint e)
		{
			return XFightGroupDocument.IsNeutral(e);
		}

		public bool IsAlly(XEntity me)
		{
			return me.Attributes != null && this.IsAlly(me.Attributes.FightGroup);
		}

		public bool IsOpponent(XEntity me)
		{
			return me.Attributes != null && this.IsOpponent(me.Attributes.FightGroup);
		}

		public bool IsAlly(XEntity me, XEntity other)
		{
			return me.Attributes != null && other.Attributes != null && (me == other || this.IsAlly(me.Attributes.FightGroup, other.Attributes.FightGroup));
		}

		public bool IsOpponent(XEntity me, XEntity other)
		{
			bool flag = me == null || other == null;
			return !flag && (me != other && me.Attributes != null && other.Attributes != null) && this.IsOpponent(me.Attributes.FightGroup, other.Attributes.FightGroup);
		}

		public bool IsAlly(uint me)
		{
			return !this.IsNeutral(me) && XSingleton<XAttributeMgr>.singleton.XPlayerData != null && this.IsAlly(me, XSingleton<XAttributeMgr>.singleton.XPlayerData.FightGroup);
		}

		public bool IsOpponent(uint me)
		{
			return !this.IsNeutral(me) && XSingleton<XAttributeMgr>.singleton.XPlayerData != null && this.IsOpponent(me, XSingleton<XAttributeMgr>.singleton.XPlayerData.FightGroup);
		}

		public bool IsAlly(uint me, uint other)
		{
			return !this.IsNeutral(me) && !this.IsNeutral(other) && XFightGroupDocument.IsAlly(me, other);
		}

		public bool IsOpponent(uint me, uint other)
		{
			return !this.IsNeutral(me) && !this.IsNeutral(other) && XFightGroupDocument.IsOpponent(me, other);
		}

		public List<XEntity> GetOpponent(XEntity me)
		{
			bool flag = me == null;
			List<XEntity> result;
			if (flag)
			{
				result = this._empty;
			}
			else
			{
				bool flag2 = !this.IsNeutral(me);
				if (flag2)
				{
					result = XFightGroupDocument.GetOpponent(me.Attributes.FightGroup);
				}
				else
				{
					result = this._empty;
				}
			}
			return result;
		}

		public List<XEntity> GetAlly(XEntity me)
		{
			bool flag = me == null;
			List<XEntity> result;
			if (flag)
			{
				result = this._empty;
			}
			else
			{
				bool flag2 = !this.IsNeutral(me);
				if (flag2)
				{
					result = XFightGroupDocument.GetAlly(me.Attributes.FightGroup);
				}
				else
				{
					result = this._empty;
				}
			}
			return result;
		}

		public List<XEntity> GetNeutral()
		{
			return XFightGroupDocument.GetNeutral();
		}

		public List<XEntity> GetAll()
		{
			return this._entities_itor;
		}

		public XEntity Add(XEntity x)
		{
			ulong id = x.ID;
			bool flag = !this.DuplicationCheck(id);
			if (flag)
			{
				throw new ArgumentException(string.Concat(new object[]
				{
					"Duplicated ID ",
					id,
					" Name ",
					x.Name
				}));
			}
			this._entities.Add(id, x);
			this._entities_itor.Add(x);
			return x;
		}

		public void DummilizePlayer(bool disappear = true)
		{
			this.Puppets(this.Player, true, disappear);
		}

		public void DedummilizePlayer()
		{
			this.Puppets(this.Player, false, false);
		}

		public void Dummilize(int mask)
		{
			foreach (XEntity xentity in this._entities.Values)
			{
				bool flag = xentity.Attributes == null;
				if (!flag)
				{
					int num = XFastEnumIntEqualityComparer<EntitySpecies>.ToInt(xentity.Attributes.Type);
					this.Puppets(xentity, true, (num & mask) != 0);
				}
			}
		}

		public void Dedummilize()
		{
			foreach (XEntity xentity in this._entities.Values)
			{
				bool destroying = xentity.Destroying;
				if (!destroying)
				{
					this.Puppets(xentity, false, ((ulong)xentity.ServerSpecialState & (ulong)(1L << (XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Invisible) & 31))) > 0UL);
				}
			}
		}

		public void ToggleOtherPlayers(bool hide)
		{
		}

		public void Idled(XEntity x)
		{
			bool flag = x.Skill != null;
			if (flag)
			{
				x.Skill.EndSkill(true, x.Destroying);
			}
			bool flag2 = x.Machine != null;
			if (flag2)
			{
				x.Machine.ForceToDefaultState(false);
			}
		}

		public void Puppets(XEntity x, bool bPuppet, bool bDisappear)
		{
			bool flag = XSingleton<XScene>.singleton.bSpectator && x.IsPlayer && (!bPuppet || !bDisappear);
			if (!flag)
			{
				if (bPuppet)
				{
					this.Idled(x);
				}
				bool flag2 = x.Skill != null;
				if (flag2)
				{
					x.Skill.Enabled = !bPuppet;
				}
				bool flag3 = x.Machine != null;
				if (flag3)
				{
					x.Machine.Enabled = !bPuppet;
					if (bPuppet)
					{
						x.Machine.PostUpdate(0f);
					}
				}
				x.RendererToggle(!bDisappear);
			}
		}

		private bool DuplicationCheck(ulong hash)
		{
			bool flag = !this._entities.ContainsKey(hash);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this._removelist.Contains(this._entities[hash]);
				if (flag2)
				{
					XEntity xentity = this._entities[hash];
					this.Remove(hash);
					xentity.Uninitilize();
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		private void SafeAdd(XEntity x)
		{
			this._addlist.Add(x);
			this._removelist.Remove(x);
		}

		private void Remove(ulong hash)
		{
			bool flag = this._entities.ContainsKey(hash);
			if (flag)
			{
				XEntity item = this._entities[hash];
				this._entities.Remove(hash);
				this._entities_itor.Remove(item);
			}
		}

		private void SafeRemove(XEntity x)
		{
			this._removelist.Add(x);
			this._addlist.Remove(x);
		}

		private void InnerAdd()
		{
			int i = 0;
			int count = this._addlist.Count;
			while (i < count)
			{
				XEntity x = this._addlist[i];
				this.Add(x);
				i++;
			}
			this._addlist.Clear();
		}

		private void InnerRemove()
		{
			int i = 0;
			int count = this._removelist.Count;
			while (i < count)
			{
				XEntity xentity = this._removelist[i];
				this.Remove(xentity.ID);
				xentity.Uninitilize();
				i++;
			}
			this._removelist.Clear();
		}

		private T PrepareEntity<T>(XAttributes attr, Vector3 position, Quaternion rotation, bool autoAdd, bool transform, bool emptyPrefab = false, bool asyncLoad = true) where T : XEntity
		{
			attr.AppearAt = position;
			T t = Activator.CreateInstance<T>();
			XGameObject xgameObject;
			if (emptyPrefab)
			{
				xgameObject = XGameObject.CreateXGameObject("", position, rotation, asyncLoad, true);
			}
			else
			{
				string value = XSingleton<XGlobalConfig>.singleton.PreFilterPrefab(attr.Prefab);
				bool flag = string.IsNullOrEmpty(value);
				if (flag)
				{
					xgameObject = XGameObject.CreateXGameObject("", position, rotation, asyncLoad, true);
				}
				else
				{
					xgameObject = XGameObject.CreateXGameObject("Prefabs/" + attr.Prefab, position, rotation, asyncLoad, true);
				}
			}
			xgameObject.CCStepOffset = 0.1f;
			t.Initilize(xgameObject, attr, transform);
			if (autoAdd)
			{
				this.SafeAdd(t);
			}
			return t;
		}

		private XDummy PrepareDummy(uint type_id, Vector3 position, Quaternion rotation)
		{
			XDummy xdummy = new XDummy();
			xdummy.Initilize(type_id, position, rotation);
			return xdummy;
		}

		private XDummy PrepareDummy(uint present_id, uint type_id, XOutlookData outlookData, bool autoAdd, bool demonstration, bool asyncLoad)
		{
			XDummy xdummy = new XDummy();
			xdummy.Initilize(present_id, type_id, outlookData, autoAdd, demonstration, asyncLoad);
			if (autoAdd)
			{
				this.SafeAdd(xdummy);
			}
			return xdummy;
		}

		private XAffiliate PrepareAffiliate(uint present_id, XEntity mainbody)
		{
			XAffiliate xaffiliate = new XAffiliate();
			xaffiliate.Initilize(mainbody, present_id);
			xaffiliate.OnCreated();
			return xaffiliate;
		}

		private XAffiliate PrepareAffiliate(uint present_id, XGameObject go, XEntity mainbody)
		{
			XAffiliate xaffiliate = new XAffiliate();
			xaffiliate.Initilize(mainbody, present_id, go);
			xaffiliate.OnCreated();
			return xaffiliate;
		}

		private XMount PrepareMount(uint present_id, XEntity mainbody, bool isCopilot)
		{
			XMount xmount = new XMount();
			xmount.Initilize(mainbody, present_id, isCopilot);
			xmount.EngineObject.CCStepOffset = 0.1f;
			xmount.OnCreated();
			return xmount;
		}

		private XEmpty PrepareEmpty()
		{
			XEmpty xempty = new XEmpty();
			XGameObject o = XGameObject.CreateXGameObject(XAIComponent.UseRunTime ? "" : "Prefabs/empty", true, true);
			xempty.Initilize(o);
			return xempty;
		}

		private void Iterate(List<XEntity> iterator, float fDeltaT)
		{
			int count = iterator.Count;
			for (int i = 0; i < count; i++)
			{
				XEntity xentity = iterator[i];
				bool flag = !xentity.Deprecated;
				if (flag)
				{
					xentity.Update(fDeltaT);
				}
			}
		}

		private void PostIterate(List<XEntity> iterator, float fDeltaT)
		{
			int count = iterator.Count;
			for (int i = 0; i < count; i++)
			{
				XEntity xentity = iterator[i];
				bool flag = !xentity.Deprecated;
				if (flag)
				{
					xentity.PostUpdate(fDeltaT);
				}
			}
		}

		private void FixedIterate(List<XEntity> iterator)
		{
			int count = iterator.Count;
			for (int i = 0; i < count; i++)
			{
				XEntity xentity = iterator[i];
				bool flag = !xentity.Deprecated;
				if (flag)
				{
					xentity.FixedUpdate();
				}
			}
		}

		public XAttributes GetAttributesWithAppearance(UnitAppearance unit)
		{
			XAttributes xattributes = XSingleton<XAttributeMgr>.singleton.InitAttrFromServer(unit.uID, unit.nickid, unit.unitType, unit.unitName, unit.attributes, unit.fightgroup, unit.isServerControl, unit.skills, unit.bindskills, new XOutLookAttr(unit.outlook), unit.level, 0U);
			xattributes.MidwayEnter = !unit.isnewmob;
			xattributes.HostID = unit.hostid;
			XOutlookHelper.SetOutLook(xattributes, unit.outlook, true);
			return xattributes;
		}

		public XEntity CreateEntityByUnitAppearance(UnitAppearance unit)
		{
			XAttributes attributesWithAppearance = this.GetAttributesWithAppearance(unit);
			bool flag = attributesWithAppearance.Type == EntitySpecies.Species_Role;
			XEntity xentity;
			if (flag)
			{
				xentity = XSingleton<XEntityMgr>.singleton.Add(XSingleton<XEntityMgr>.singleton.CreateRole(attributesWithAppearance, new Vector3(unit.position.x, unit.position.y, unit.position.z), Quaternion.Euler(0f, unit.direction, 0f), false, XSingleton<XScene>.singleton.IsMustTransform));
			}
			else
			{
				xentity = XSingleton<XEntityMgr>.singleton.Add(XSingleton<XEntityMgr>.singleton.CreateEntity(attributesWithAppearance, new Vector3(unit.position.x, unit.position.y, unit.position.z), Quaternion.Euler(0f, unit.direction, 0f), false));
			}
			bool flag2 = xentity.Buffs != null;
			if (flag2)
			{
				xentity.Buffs.InitFromServer(unit.buffs, unit.allbuffsinfo);
			}
			xentity.ServerSpecialState = unit.specialstate;
			bool hostidSpecified = unit.hostidSpecified;
			if (hostidSpecified)
			{
				XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(unit.hostid);
				bool flag3 = entityConsiderDeath != null && !entityConsiderDeath.Deprecated && entityConsiderDeath.Skill != null;
				if (flag3)
				{
					xentity.MobbedBy = entityConsiderDeath;
					entityConsiderDeath.Skill.AddSkillMob(xentity);
					xentity.MobShieldable = (unit.mobshieldableSpecified && unit.mobshieldable);
					xentity.MobShield = XSingleton<XInput>.singleton.MobShield(xentity);
				}
			}
			bool flag4 = !XSingleton<XCutScene>.singleton.IsPlaying || !XSingleton<XCutScene>.singleton.IsExcludeNewBorn;
			if (flag4)
			{
				xentity.UpdateSpecialStateFromServer(unit.specialstate, uint.MaxValue);
			}
			bool isDead = unit.IsDead;
			if (isDead)
			{
				XSingleton<XDeath>.singleton.DeathDetect(xentity, null, true);
			}
			return xentity;
		}

		public void DelayProcess()
		{
		}

		private XTableAsyncLoader _async_loader = null;

		private List<XEntity> _empty = new List<XEntity>();

		private PlayerLevelTable _level_table = new PlayerLevelTable();

		private XEntityPresentation _entity_data_info = new XEntityPresentation();

		private ProfessionTable _role_data_info = new ProfessionTable();

		private XEntityStatistics _statistics_data_info = new XEntityStatistics();

		private XNpcInfo _npc_data_info = new XNpcInfo();

		private SuperArmorRecoveryCoffTable _super_armor_coff_info = new SuperArmorRecoveryCoffTable();

		private Dictionary<ulong, XEntity> _entities = new Dictionary<ulong, XEntity>();

		private Dictionary<uint, List<uint>> _scene_npcs = new Dictionary<uint, List<uint>>();

		private Dictionary<uint, XNpc> _npcs = new Dictionary<uint, XNpc>();

		private Dictionary<uint, float> _anim_length = new Dictionary<uint, float>();

		private List<XEntity> _entities_itor = new List<XEntity>();

		private List<XEntity> _addlist = new List<XEntity>();

		private List<XEntity> _removelist = new List<XEntity>();
	}
}
