using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DC2 RID: 3522
	internal sealed class XEntityMgr : XSingleton<XEntityMgr>
	{
		// Token: 0x0600BF68 RID: 49000 RVA: 0x00281578 File Offset: 0x0027F778
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

		// Token: 0x0600BF69 RID: 49001 RVA: 0x002816D0 File Offset: 0x0027F8D0
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

		// Token: 0x170033B9 RID: 13241
		// (get) Token: 0x0600BF6A RID: 49002 RVA: 0x0028173C File Offset: 0x0027F93C
		public SuperArmorRecoveryCoffTable SuperArmorCoffTable
		{
			get
			{
				return this._super_armor_coff_info;
			}
		}

		// Token: 0x170033BA RID: 13242
		// (get) Token: 0x0600BF6B RID: 49003 RVA: 0x00281754 File Offset: 0x0027F954
		public PlayerLevelTable LevelTable
		{
			get
			{
				return this._level_table;
			}
		}

		// Token: 0x170033BB RID: 13243
		// (get) Token: 0x0600BF6C RID: 49004 RVA: 0x0028176C File Offset: 0x0027F96C
		public XEntityPresentation EntityInfo
		{
			get
			{
				return this._entity_data_info;
			}
		}

		// Token: 0x170033BC RID: 13244
		// (get) Token: 0x0600BF6D RID: 49005 RVA: 0x00281784 File Offset: 0x0027F984
		public ProfessionTable RoleInfo
		{
			get
			{
				return this._role_data_info;
			}
		}

		// Token: 0x170033BD RID: 13245
		// (get) Token: 0x0600BF6E RID: 49006 RVA: 0x0028179C File Offset: 0x0027F99C
		public XEntityStatistics EntityStatistics
		{
			get
			{
				return this._statistics_data_info;
			}
		}

		// Token: 0x170033BE RID: 13246
		// (get) Token: 0x0600BF6F RID: 49007 RVA: 0x002817B4 File Offset: 0x0027F9B4
		public XNpcInfo NpcInfo
		{
			get
			{
				return this._npc_data_info;
			}
		}

		// Token: 0x170033BF RID: 13247
		// (get) Token: 0x0600BF70 RID: 49008 RVA: 0x002817CC File Offset: 0x0027F9CC
		// (set) Token: 0x0600BF71 RID: 49009 RVA: 0x002817D4 File Offset: 0x0027F9D4
		public XPlayer Player { get; set; }

		// Token: 0x170033C0 RID: 13248
		// (get) Token: 0x0600BF72 RID: 49010 RVA: 0x002817DD File Offset: 0x0027F9DD
		// (set) Token: 0x0600BF73 RID: 49011 RVA: 0x002817E5 File Offset: 0x0027F9E5
		public XBoss Boss { get; set; }

		// Token: 0x0600BF74 RID: 49012 RVA: 0x002817F0 File Offset: 0x0027F9F0
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

		// Token: 0x0600BF75 RID: 49013 RVA: 0x00281830 File Offset: 0x0027FA30
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

		// Token: 0x0600BF76 RID: 49014 RVA: 0x00281868 File Offset: 0x0027FA68
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

		// Token: 0x0600BF77 RID: 49015 RVA: 0x002818A0 File Offset: 0x0027FAA0
		public List<uint> GetNpcs(uint scene_id)
		{
			return this._scene_npcs.ContainsKey(scene_id) ? this._scene_npcs[scene_id] : null;
		}

		// Token: 0x0600BF78 RID: 49016 RVA: 0x002818D0 File Offset: 0x0027FAD0
		public XNpc GetNpc(uint id)
		{
			XNpc result = null;
			this._npcs.TryGetValue(id, out result);
			return result;
		}

		// Token: 0x0600BF79 RID: 49017 RVA: 0x002818F4 File Offset: 0x0027FAF4
		public XPlayer CreatePlayer(Vector3 position, Quaternion rotation, bool autoAdd, bool emptyPrefab = false)
		{
			XPlayer xplayer = this.PrepareEntity<XPlayer>(XSingleton<XAttributeMgr>.singleton.XPlayerData, position, rotation, autoAdd, false, emptyPrefab, false);
			xplayer.OnCreated();
			return xplayer;
		}

		// Token: 0x0600BF7A RID: 49018 RVA: 0x00281928 File Offset: 0x0027FB28
		public XRole CreateRole(XAttributes attr, Vector3 position, Quaternion rotation, bool autoAdd, bool emptyPrefab = false)
		{
			XRole xrole = this.PrepareEntity<XRole>(attr, position, rotation, autoAdd, false, emptyPrefab, true);
			xrole.OnCreated();
			return xrole;
		}

		// Token: 0x0600BF7B RID: 49019 RVA: 0x00281954 File Offset: 0x0027FB54
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

		// Token: 0x0600BF7C RID: 49020 RVA: 0x002819EC File Offset: 0x0027FBEC
		private void PostCreateEntity(XEntity e)
		{
			bool flag = e != null;
			if (flag)
			{
				e.OnCreated();
			}
		}

		// Token: 0x0600BF7D RID: 49021 RVA: 0x00281A0C File Offset: 0x0027FC0C
		public XEntity CreateEntityByCaller(XEntity caller, uint id, Vector3 position, Quaternion rotation, bool autoAdd, uint fightgroup = 4294967295U)
		{
			XAttributes attr = XSingleton<XAttributeMgr>.singleton.InitAttrFromClient(id, null, fightgroup);
			XEntity xentity = this.PreCreateEntity(attr, position, rotation, autoAdd, false);
			xentity.MobbedBy = caller;
			this.PostCreateEntity(xentity);
			return xentity;
		}

		// Token: 0x0600BF7E RID: 49022 RVA: 0x00281A4C File Offset: 0x0027FC4C
		public XEntity CreateEntity(XAttributes attr, Vector3 position, Quaternion rotation, bool autoAdd)
		{
			XEntity xentity = this.PreCreateEntity(attr, position, rotation, autoAdd, false);
			this.PostCreateEntity(xentity);
			return xentity;
		}

		// Token: 0x0600BF7F RID: 49023 RVA: 0x00281A74 File Offset: 0x0027FC74
		public XEntity CreateEntity(uint id, Vector3 position, Quaternion rotation, bool autoAdd, uint fightgroup = 4294967295U)
		{
			return this.CreateEntity(XSingleton<XAttributeMgr>.singleton.InitAttrFromClient(id, null, fightgroup), position, rotation, autoAdd);
		}

		// Token: 0x0600BF80 RID: 49024 RVA: 0x00281AA0 File Offset: 0x0027FCA0
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

		// Token: 0x0600BF81 RID: 49025 RVA: 0x00281AF0 File Offset: 0x0027FCF0
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

		// Token: 0x0600BF82 RID: 49026 RVA: 0x00281CF4 File Offset: 0x0027FEF4
		public XDummy CreateDummy(uint present_id, uint type_id, XOutlookData outlookData, bool autoAdd = false, bool demonstration = false, bool asyncLoad = true)
		{
			XDummy xdummy = this.PrepareDummy(present_id, type_id, outlookData, autoAdd, demonstration, asyncLoad);
			xdummy.OnCreated();
			return xdummy;
		}

		// Token: 0x0600BF83 RID: 49027 RVA: 0x00281D20 File Offset: 0x0027FF20
		public XDummy CreateDummy(uint type_id, Vector3 position, Quaternion rotation)
		{
			return this.PrepareDummy(type_id, position, rotation);
		}

		// Token: 0x0600BF84 RID: 49028 RVA: 0x00281D3C File Offset: 0x0027FF3C
		public XAffiliate CreateAffiliate(uint present_id, XEntity mainbody)
		{
			return this.PrepareAffiliate(present_id, mainbody);
		}

		// Token: 0x0600BF85 RID: 49029 RVA: 0x00281D58 File Offset: 0x0027FF58
		public XAffiliate CreateAffiliate(uint present_id, XGameObject go, XEntity mainbody)
		{
			return this.PrepareAffiliate(present_id, go, mainbody);
		}

		// Token: 0x0600BF86 RID: 49030 RVA: 0x00281D74 File Offset: 0x0027FF74
		public XMount CreateMount(uint present_id, XEntity mainbody, bool isCopilot)
		{
			return XEntity.ValideEntity(mainbody) ? this.PrepareMount(present_id, mainbody, isCopilot) : null;
		}

		// Token: 0x0600BF87 RID: 49031 RVA: 0x00281D9C File Offset: 0x0027FF9C
		public XEmpty CreateEmpty()
		{
			XEmpty xempty = this.PrepareEmpty();
			xempty.OnCreated();
			return xempty;
		}

		// Token: 0x0600BF88 RID: 49032 RVA: 0x00281DC0 File Offset: 0x0027FFC0
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

		// Token: 0x0600BF89 RID: 49033 RVA: 0x00281E48 File Offset: 0x00280048
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

		// Token: 0x0600BF8A RID: 49034 RVA: 0x00281E80 File Offset: 0x00280080
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

		// Token: 0x0600BF8B RID: 49035 RVA: 0x00281EF8 File Offset: 0x002800F8
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

		// Token: 0x0600BF8C RID: 49036 RVA: 0x00281F2E File Offset: 0x0028012E
		public void DestroyEntity(ulong id)
		{
			this.DestroyEntity(this.GetEntityConsiderDeath(id));
		}

		// Token: 0x0600BF8D RID: 49037 RVA: 0x00281F40 File Offset: 0x00280140
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

		// Token: 0x0600BF8E RID: 49038 RVA: 0x00282214 File Offset: 0x00280414
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

		// Token: 0x0600BF8F RID: 49039 RVA: 0x00282330 File Offset: 0x00280530
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

		// Token: 0x0600BF90 RID: 49040 RVA: 0x00282380 File Offset: 0x00280580
		public void Update(float fDeltaT)
		{
			this.Iterate(this._entities_itor, fDeltaT);
		}

		// Token: 0x0600BF91 RID: 49041 RVA: 0x00282391 File Offset: 0x00280591
		public void PostUpdate(float fDeltaT)
		{
			this.PostIterate(this._entities_itor, fDeltaT);
			this.InnerAdd();
			this.InnerRemove();
		}

		// Token: 0x0600BF92 RID: 49042 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void FixedUpdate()
		{
		}

		// Token: 0x0600BF93 RID: 49043 RVA: 0x002823B0 File Offset: 0x002805B0
		public bool IsNeutral(XEntity e)
		{
			return e.Attributes == null || this.IsNeutral(e.Attributes.FightGroup);
		}

		// Token: 0x0600BF94 RID: 49044 RVA: 0x002823E0 File Offset: 0x002805E0
		public bool IsNeutral(uint e)
		{
			return XFightGroupDocument.IsNeutral(e);
		}

		// Token: 0x0600BF95 RID: 49045 RVA: 0x002823F8 File Offset: 0x002805F8
		public bool IsAlly(XEntity me)
		{
			return me.Attributes != null && this.IsAlly(me.Attributes.FightGroup);
		}

		// Token: 0x0600BF96 RID: 49046 RVA: 0x00282428 File Offset: 0x00280628
		public bool IsOpponent(XEntity me)
		{
			return me.Attributes != null && this.IsOpponent(me.Attributes.FightGroup);
		}

		// Token: 0x0600BF97 RID: 49047 RVA: 0x00282458 File Offset: 0x00280658
		public bool IsAlly(XEntity me, XEntity other)
		{
			return me.Attributes != null && other.Attributes != null && (me == other || this.IsAlly(me.Attributes.FightGroup, other.Attributes.FightGroup));
		}

		// Token: 0x0600BF98 RID: 49048 RVA: 0x002824A0 File Offset: 0x002806A0
		public bool IsOpponent(XEntity me, XEntity other)
		{
			bool flag = me == null || other == null;
			return !flag && (me != other && me.Attributes != null && other.Attributes != null) && this.IsOpponent(me.Attributes.FightGroup, other.Attributes.FightGroup);
		}

		// Token: 0x0600BF99 RID: 49049 RVA: 0x002824F8 File Offset: 0x002806F8
		public bool IsAlly(uint me)
		{
			return !this.IsNeutral(me) && XSingleton<XAttributeMgr>.singleton.XPlayerData != null && this.IsAlly(me, XSingleton<XAttributeMgr>.singleton.XPlayerData.FightGroup);
		}

		// Token: 0x0600BF9A RID: 49050 RVA: 0x0028253C File Offset: 0x0028073C
		public bool IsOpponent(uint me)
		{
			return !this.IsNeutral(me) && XSingleton<XAttributeMgr>.singleton.XPlayerData != null && this.IsOpponent(me, XSingleton<XAttributeMgr>.singleton.XPlayerData.FightGroup);
		}

		// Token: 0x0600BF9B RID: 49051 RVA: 0x00282580 File Offset: 0x00280780
		public bool IsAlly(uint me, uint other)
		{
			return !this.IsNeutral(me) && !this.IsNeutral(other) && XFightGroupDocument.IsAlly(me, other);
		}

		// Token: 0x0600BF9C RID: 49052 RVA: 0x002825B0 File Offset: 0x002807B0
		public bool IsOpponent(uint me, uint other)
		{
			return !this.IsNeutral(me) && !this.IsNeutral(other) && XFightGroupDocument.IsOpponent(me, other);
		}

		// Token: 0x0600BF9D RID: 49053 RVA: 0x002825E0 File Offset: 0x002807E0
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

		// Token: 0x0600BF9E RID: 49054 RVA: 0x0028262C File Offset: 0x0028082C
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

		// Token: 0x0600BF9F RID: 49055 RVA: 0x00282678 File Offset: 0x00280878
		public List<XEntity> GetNeutral()
		{
			return XFightGroupDocument.GetNeutral();
		}

		// Token: 0x0600BFA0 RID: 49056 RVA: 0x00282690 File Offset: 0x00280890
		public List<XEntity> GetAll()
		{
			return this._entities_itor;
		}

		// Token: 0x0600BFA1 RID: 49057 RVA: 0x002826A8 File Offset: 0x002808A8
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

		// Token: 0x0600BFA2 RID: 49058 RVA: 0x00282721 File Offset: 0x00280921
		public void DummilizePlayer(bool disappear = true)
		{
			this.Puppets(this.Player, true, disappear);
		}

		// Token: 0x0600BFA3 RID: 49059 RVA: 0x00282733 File Offset: 0x00280933
		public void DedummilizePlayer()
		{
			this.Puppets(this.Player, false, false);
		}

		// Token: 0x0600BFA4 RID: 49060 RVA: 0x00282748 File Offset: 0x00280948
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

		// Token: 0x0600BFA5 RID: 49061 RVA: 0x002827D0 File Offset: 0x002809D0
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

		// Token: 0x0600BFA6 RID: 49062 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void ToggleOtherPlayers(bool hide)
		{
		}

		// Token: 0x0600BFA7 RID: 49063 RVA: 0x00282854 File Offset: 0x00280A54
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

		// Token: 0x0600BFA8 RID: 49064 RVA: 0x0028289C File Offset: 0x00280A9C
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

		// Token: 0x0600BFA9 RID: 49065 RVA: 0x00282940 File Offset: 0x00280B40
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

		// Token: 0x0600BFAA RID: 49066 RVA: 0x002829A6 File Offset: 0x00280BA6
		private void SafeAdd(XEntity x)
		{
			this._addlist.Add(x);
			this._removelist.Remove(x);
		}

		// Token: 0x0600BFAB RID: 49067 RVA: 0x002829C4 File Offset: 0x00280BC4
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

		// Token: 0x0600BFAC RID: 49068 RVA: 0x00282A0B File Offset: 0x00280C0B
		private void SafeRemove(XEntity x)
		{
			this._removelist.Add(x);
			this._addlist.Remove(x);
		}

		// Token: 0x0600BFAD RID: 49069 RVA: 0x00282A28 File Offset: 0x00280C28
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

		// Token: 0x0600BFAE RID: 49070 RVA: 0x00282A78 File Offset: 0x00280C78
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

		// Token: 0x0600BFAF RID: 49071 RVA: 0x00282AD4 File Offset: 0x00280CD4
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

		// Token: 0x0600BFB0 RID: 49072 RVA: 0x00282B94 File Offset: 0x00280D94
		private XDummy PrepareDummy(uint type_id, Vector3 position, Quaternion rotation)
		{
			XDummy xdummy = new XDummy();
			xdummy.Initilize(type_id, position, rotation);
			return xdummy;
		}

		// Token: 0x0600BFB1 RID: 49073 RVA: 0x00282BB8 File Offset: 0x00280DB8
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

		// Token: 0x0600BFB2 RID: 49074 RVA: 0x00282BF0 File Offset: 0x00280DF0
		private XAffiliate PrepareAffiliate(uint present_id, XEntity mainbody)
		{
			XAffiliate xaffiliate = new XAffiliate();
			xaffiliate.Initilize(mainbody, present_id);
			xaffiliate.OnCreated();
			return xaffiliate;
		}

		// Token: 0x0600BFB3 RID: 49075 RVA: 0x00282C1C File Offset: 0x00280E1C
		private XAffiliate PrepareAffiliate(uint present_id, XGameObject go, XEntity mainbody)
		{
			XAffiliate xaffiliate = new XAffiliate();
			xaffiliate.Initilize(mainbody, present_id, go);
			xaffiliate.OnCreated();
			return xaffiliate;
		}

		// Token: 0x0600BFB4 RID: 49076 RVA: 0x00282C48 File Offset: 0x00280E48
		private XMount PrepareMount(uint present_id, XEntity mainbody, bool isCopilot)
		{
			XMount xmount = new XMount();
			xmount.Initilize(mainbody, present_id, isCopilot);
			xmount.EngineObject.CCStepOffset = 0.1f;
			xmount.OnCreated();
			return xmount;
		}

		// Token: 0x0600BFB5 RID: 49077 RVA: 0x00282C84 File Offset: 0x00280E84
		private XEmpty PrepareEmpty()
		{
			XEmpty xempty = new XEmpty();
			XGameObject o = XGameObject.CreateXGameObject(XAIComponent.UseRunTime ? "" : "Prefabs/empty", true, true);
			xempty.Initilize(o);
			return xempty;
		}

		// Token: 0x0600BFB6 RID: 49078 RVA: 0x00282CC0 File Offset: 0x00280EC0
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

		// Token: 0x0600BFB7 RID: 49079 RVA: 0x00282D08 File Offset: 0x00280F08
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

		// Token: 0x0600BFB8 RID: 49080 RVA: 0x00282D50 File Offset: 0x00280F50
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

		// Token: 0x0600BFB9 RID: 49081 RVA: 0x00282D98 File Offset: 0x00280F98
		public XAttributes GetAttributesWithAppearance(UnitAppearance unit)
		{
			XAttributes xattributes = XSingleton<XAttributeMgr>.singleton.InitAttrFromServer(unit.uID, unit.nickid, unit.unitType, unit.unitName, unit.attributes, unit.fightgroup, unit.isServerControl, unit.skills, unit.bindskills, new XOutLookAttr(unit.outlook), unit.level, 0U);
			xattributes.MidwayEnter = !unit.isnewmob;
			xattributes.HostID = unit.hostid;
			XOutlookHelper.SetOutLook(xattributes, unit.outlook, true);
			return xattributes;
		}

		// Token: 0x0600BFBA RID: 49082 RVA: 0x00282E2C File Offset: 0x0028102C
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

		// Token: 0x0600BFBB RID: 49083 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void DelayProcess()
		{
		}

		// Token: 0x04004E46 RID: 20038
		private XTableAsyncLoader _async_loader = null;

		// Token: 0x04004E47 RID: 20039
		private List<XEntity> _empty = new List<XEntity>();

		// Token: 0x04004E48 RID: 20040
		private PlayerLevelTable _level_table = new PlayerLevelTable();

		// Token: 0x04004E49 RID: 20041
		private XEntityPresentation _entity_data_info = new XEntityPresentation();

		// Token: 0x04004E4A RID: 20042
		private ProfessionTable _role_data_info = new ProfessionTable();

		// Token: 0x04004E4B RID: 20043
		private XEntityStatistics _statistics_data_info = new XEntityStatistics();

		// Token: 0x04004E4C RID: 20044
		private XNpcInfo _npc_data_info = new XNpcInfo();

		// Token: 0x04004E4D RID: 20045
		private SuperArmorRecoveryCoffTable _super_armor_coff_info = new SuperArmorRecoveryCoffTable();

		// Token: 0x04004E4E RID: 20046
		private Dictionary<ulong, XEntity> _entities = new Dictionary<ulong, XEntity>();

		// Token: 0x04004E4F RID: 20047
		private Dictionary<uint, List<uint>> _scene_npcs = new Dictionary<uint, List<uint>>();

		// Token: 0x04004E50 RID: 20048
		private Dictionary<uint, XNpc> _npcs = new Dictionary<uint, XNpc>();

		// Token: 0x04004E51 RID: 20049
		private Dictionary<uint, float> _anim_length = new Dictionary<uint, float>();

		// Token: 0x04004E52 RID: 20050
		private List<XEntity> _entities_itor = new List<XEntity>();

		// Token: 0x04004E53 RID: 20051
		private List<XEntity> _addlist = new List<XEntity>();

		// Token: 0x04004E54 RID: 20052
		private List<XEntity> _removelist = new List<XEntity>();
	}
}
