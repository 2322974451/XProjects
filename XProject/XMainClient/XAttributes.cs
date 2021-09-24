using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XAttributes : XComponent
	{

		public override uint ID
		{
			get
			{
				return XAttributes.uuID;
			}
		}

		public ulong RoleID
		{
			get
			{
				return this._id;
			}
		}

		public uint ShortId
		{
			get
			{
				return this._shortId;
			}
			set
			{
				this._shortId = value;
			}
		}

		public SeqListRef<int> InBornBuff
		{
			get
			{
				return this._inborn_buff;
			}
		}

		public string Prefab
		{
			get
			{
				return this._prefab_name;
			}
			set
			{
				this._prefab_name = value;
			}
		}

		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		public uint PayMemberID
		{
			get
			{
				return this._payMemberID;
			}
			set
			{
				this._payMemberID = value;
			}
		}

		public Vector3 AppearAt
		{
			get
			{
				return this._appear_pos;
			}
			set
			{
				this._appear_pos = value;
			}
		}

		public bool BeLocked
		{
			get
			{
				return this._be_locked;
			}
			set
			{
				this._be_locked = value;
			}
		}

		public uint FightGroup
		{
			get
			{
				return this._fight_group;
			}
			set
			{
				this.OnFightGroupChange(value);
			}
		}

		public uint TitleID
		{
			get
			{
				return this._TitleID;
			}
			set
			{
				this._TitleID = value;
			}
		}

		public bool SoloShow
		{
			get
			{
				return this._is_solo_supported;
			}
			set
			{
				this._is_solo_supported = value;
			}
		}

		public bool MidwayEnter
		{
			get
			{
				return this._midway_enter;
			}
			set
			{
				this._midway_enter = value;
			}
		}

		public ulong HostID
		{
			get
			{
				return this._HostID;
			}
			set
			{
				this._HostID = value;
				this._FinalHostID = value;
			}
		}

		public ulong FinalHostID
		{
			get
			{
				return this._FinalHostID;
			}
		}

		public virtual uint Tag
		{
			get
			{
				return 0U;
			}
		}

		public void SetHost(XEntity hostEntity)
		{
			bool flag = !XEntity.ValideEntity(hostEntity);
			if (!flag)
			{
				this._HostID = hostEntity.ID;
				this._FinalHostID = hostEntity.Attributes.FinalHostID;
				bool flag2 = this._FinalHostID == 0UL;
				if (flag2)
				{
					this._FinalHostID = this._HostID;
				}
			}
		}

		public XSecurityStatistics SecurityStatistics
		{
			get
			{
				return this._security_Statistics;
			}
		}

		public double Dps
		{
			get
			{
				return this._battle_Statistics.Dps;
			}
		}

		public double PrintDamage
		{
			get
			{
				return this._battle_Statistics.PrintDamage;
			}
		}

		public XAttributes()
		{
			this._onAttributeRegenerateCb = new XTimerMgr.ElapsedEventHandler(this.OnAttributeRegenerate);
		}

		public void OnFightGroupChange(uint group)
		{
			bool flag = this._fight_group == group;
			if (!flag)
			{
				bool flag2 = this._entity != null;
				if (flag2)
				{
					uint fight_group = this._fight_group;
					XFightGroupDocument.OnDecalcFightGroup(this._entity);
					this._fight_group = group;
					XFightGroupDocument.OnCalcFightGroup(this._entity);
					XFightGroupChangedArgs @event = XEventPool<XFightGroupChangedArgs>.GetEvent();
					@event.oldFightGroup = fight_group;
					@event.newFightGroup = this._fight_group;
					@event.targetEntity = this._entity;
					@event.Firer = this._entity;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
					XFightGroupChangedArgs event2 = XEventPool<XFightGroupChangedArgs>.GetEvent();
					event2.oldFightGroup = fight_group;
					event2.newFightGroup = this._fight_group;
					event2.targetEntity = this._entity;
					event2.Firer = XSingleton<XGame>.singleton.Doc;
					XSingleton<XEventMgr>.singleton.FireEvent(event2);
					bool flag3 = XSingleton<XEntityMgr>.singleton.IsOpponent(this._fight_group, XSingleton<XAttributeMgr>.singleton.XPlayerData.FightGroup);
					bool soloShow = this.SoloShow;
					if (soloShow)
					{
						this.SoloShow = flag3;
					}
					XCameraSoloComponent solo = XSingleton<XScene>.singleton.GameCamera.Solo;
					bool flag4 = solo == null;
					if (!flag4)
					{
						bool flag5 = solo.Target == this._entity;
						if (flag5)
						{
							bool flag6 = !flag3;
							if (flag6)
							{
								solo.Stop();
							}
						}
						else
						{
							bool isPlayer = this._entity.IsPlayer;
							if (isPlayer)
							{
								solo.Stop();
							}
							XSingleton<XScene>.singleton.GameCamera.TrySolo();
						}
					}
				}
				else
				{
					this._fight_group = group;
				}
			}
		}

		private bool OnEquipChange(XEventArgs e)
		{
			XEquipChangeEventArgs xequipChangeEventArgs = e as XEquipChangeEventArgs;
			bool flag = xequipChangeEventArgs.ItemID != null && xequipChangeEventArgs.EquipPart != null;
			if (flag)
			{
				for (int i = 0; i < xequipChangeEventArgs.ItemID.Count; i++)
				{
					int pos = (int)xequipChangeEventArgs.EquipPart[i];
					this.Outlook.SetFashion(pos, (int)xequipChangeEventArgs.ItemID[i]);
				}
			}
			this.Outlook.CalculateOutLookFashion();
			bool flag2 = this._entity.Equipment != null;
			if (flag2)
			{
				this._entity.Equipment.OnEquipChange();
			}
			XSingleton<X3DAvatarMgr>.singleton.OnFashionChanged(this._entity);
			return true;
		}

		public void InitEquipList(List<uint> equipData)
		{
		}

		public ulong EntityID
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}

		public virtual uint TypeID
		{
			get
			{
				return this._type_id;
			}
			set
			{
				this._type_id = value;
			}
		}

		public virtual uint BasicTypeID
		{
			get
			{
				return this.TypeID;
			}
		}

		public uint PresentID
		{
			get
			{
				return this._present_id;
			}
			set
			{
				this._present_id = value;
			}
		}

		public EntitySpecies Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		public static ulong GetTypePrefix(EntitySpecies type)
		{
			switch (type)
			{
			case EntitySpecies.Species_Boss:
			case EntitySpecies.Species_Opposer:
			case EntitySpecies.Species_Puppet:
			case EntitySpecies.Species_Elite:
				return (ulong)((ulong)((long)XFastEnumIntEqualityComparer<EntityCategory>.ToInt(EntityCategory.Category_Enemy)) << 60);
			case EntitySpecies.Species_Substance:
			case EntitySpecies.Species_Npc:
				return (ulong)((ulong)((long)XFastEnumIntEqualityComparer<EntityCategory>.ToInt(EntityCategory.Category_Neutral)) << 60);
			case EntitySpecies.Species_Role:
				return (ulong)((ulong)((long)XFastEnumIntEqualityComparer<EntityCategory>.ToInt(EntityCategory.Category_Role)) << 60);
			}
			return (ulong)((ulong)((long)XFastEnumIntEqualityComparer<EntityCategory>.ToInt(EntityCategory.Category_Others)) << 60);
		}

		public static bool IsPlayer(ulong uID)
		{
			return uID == XSingleton<XGame>.singleton.PlayerID;
		}

		public static EntityCategory GetCategory(ulong uID)
		{
			return (EntityCategory)(uID >> 60);
		}

		public EntityCategory GetCategory()
		{
			return (EntityCategory)(this.EntityID >> 60);
		}

		public bool IsDead
		{
			get
			{
				return this._is_dead;
			}
			set
			{
				this._is_dead = value;
			}
		}

		public uint Level
		{
			get
			{
				return this._level;
			}
			set
			{
				this._level = value;
				bool flag = XAttributes.IsPlayer(this.RoleID);
				if (flag)
				{
					XFileLog.RoleLevel = value;
				}
			}
		}

		public uint point
		{
			get
			{
				XCarnivalDocument specificDocument = XDocuments.GetSpecificDocument<XCarnivalDocument>(XCarnivalDocument.uuID);
				XBagDocument specificDocument2 = XDocuments.GetSpecificDocument<XBagDocument>(XBagDocument.uuID);
				return (uint)specificDocument2.GetItemCount(specificDocument.pointItemID);
			}
		}

		public bool CarnivalClaimed { get; set; }

		public ulong Exp { get; set; }

		public ulong MaxExp { get; set; }

		public float RunSpeed
		{
			get
			{
				return (float)this.GetAttr(XAttributeDefine.XAttr_RUN_SPEED_Total) * this._entity.Scale;
			}
		}

		public float WalkSpeed
		{
			get
			{
				return (float)this.GetAttr(XAttributeDefine.XAttr_WALK_SPEED_Total) * this._entity.Scale;
			}
		}

		public float RotateSpeed
		{
			get
			{
				return (float)this.GetAttr(XAttributeDefine.XAttr_ROTATION_SPEED_Total);
			}
		}

		public float AutoRotateSpeed
		{
			get
			{
				return (float)this.GetAttr(XAttributeDefine.XAttr_AUTOROTATION_SPEED_Total);
			}
		}

		public float AttackSpeed
		{
			get
			{
				return Mathf.Clamp((float)(this.GetAttr(XAttributeDefine.XATTR_ATTACK_SPEED_Total) / XSingleton<XGlobalConfig>.singleton.GeneralCombatParam), (float)XSingleton<XGlobalConfig>.singleton.AttackSpeedLowerBound, (float)XSingleton<XGlobalConfig>.singleton.AttackSpeedUpperBound);
			}
		}

		public double ParalyzeAttribute
		{
			get
			{
				double attr = this.GetAttr(XAttributeDefine.XAttr_Paralyze_Total);
				CombatParamTable.RowData combatParam = XSingleton<XCombat>.singleton.GetCombatParam(this.Level);
				double num = attr / (attr + (double)combatParam.ParalyzeBase);
				bool flag = num > XSingleton<XGlobalConfig>.singleton.ParalyzeLimit;
				if (flag)
				{
					num = XSingleton<XGlobalConfig>.singleton.ParalyzeLimit;
				}
				return num;
			}
		}

		public double ParalyzeDefenseAttribute
		{
			get
			{
				double attr = this.GetAttr(XAttributeDefine.XAttr_ParaResist_Total);
				CombatParamTable.RowData combatParam = XSingleton<XCombat>.singleton.GetCombatParam(this.Level);
				double num = attr / (attr + (double)combatParam.ParaResistBase);
				bool flag = num > XSingleton<XGlobalConfig>.singleton.ParaResistLimit;
				if (flag)
				{
					num = XSingleton<XGlobalConfig>.singleton.ParaResistLimit;
				}
				return num;
			}
		}

		public double HPPercent
		{
			get
			{
				double num = this.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
				double attr = this.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
				bool flag = num <= 1.0;
				if (flag)
				{
					num = 1.0;
				}
				return attr / num;
			}
		}

		public XBuffStateInfo BuffState
		{
			get
			{
				return this._buff_state;
			}
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_AttributeChange, new XComponent.XEventHandler(this.OnAttributeChange));
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this.OnRealDead));
			base.RegisterEvent(XEventDefine.XEvent_EquipChange, new XComponent.XEventHandler(this.OnEquipChange));
			base.RegisterEvent(XEventDefine.XEvent_ProjectDamage, new XComponent.XEventHandler(this.OnProjectDamage));
		}

		protected bool OnRealDead(XEventArgs e)
		{
			this._is_dead = true;
			return true;
		}

		protected bool OnProjectDamage(XEventArgs e)
		{
			XProjectDamageEventArgs xprojectDamageEventArgs = e as XProjectDamageEventArgs;
			bool flag = this._security_Statistics != null;
			if (flag)
			{
				bool flag2 = xprojectDamageEventArgs.Hurt.Target != this._entity;
				if (flag2)
				{
					this._security_Statistics.OnCastDamage(xprojectDamageEventArgs.Hurt, xprojectDamageEventArgs.Damage);
				}
				else
				{
					this._security_Statistics.OnReceiveDamage(xprojectDamageEventArgs.Hurt, xprojectDamageEventArgs.Damage);
				}
			}
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			bool result;
			if (syncMode)
			{
				result = true;
			}
			else
			{
				bool flag3 = xprojectDamageEventArgs.Hurt.Target != this._entity && xprojectDamageEventArgs.Damage.Value > 0.0;
				if (flag3)
				{
					bool flag4 = this.HostID > 0UL;
					if (flag4)
					{
						XEntity entityExcludeDeath = XSingleton<XEntityMgr>.singleton.GetEntityExcludeDeath(this._HostID);
						bool flag5 = XEntity.ValideEntity(entityExcludeDeath) && entityExcludeDeath.Attributes != null;
						if (flag5)
						{
							entityExcludeDeath.Attributes.CombatAppendDamage(xprojectDamageEventArgs.Damage.Value);
						}
					}
					else
					{
						this._battle_Statistics.AppendDamage(xprojectDamageEventArgs.Damage.Value);
					}
				}
				result = true;
			}
			return result;
		}

		public virtual void InitAttribute(KKSG.Attribute attr)
		{
			for (int i = 0; i < attr.attrID.Count; i++)
			{
				uint index = attr.attrID[i];
				this._basicAttr[index] = attr.basicAttribute[i];
				this._percentAttr[index] = attr.percentAttribute[i];
			}
		}

		public virtual void InitAttribute(XEntityStatistics.RowData data)
		{
			this.SetAttr(XAttributeDefine.XAttr_MaxHP_Basic, (double)data.MaxHP);
			this.SetAttr(XAttributeDefine.XAttr_CurrentHP_Basic, (double)data.MaxHP);
			this.SetAttr(XAttributeDefine.XAttr_PhysicalAtk_Basic, (double)data.AttackBase);
			this.SetAttr(XAttributeDefine.XAttr_PhysicalAtkMod_Basic, (double)data.AttackBase);
			this.SetAttr(XAttributeDefine.XAttr_MaxSuperArmor_Basic, (double)data.MaxSuperArmor);
			this.SetAttr(XAttributeDefine.XAttr_CurrentSuperArmor_Basic, (double)data.MaxSuperArmor);
			this.SetAttr(XAttributeDefine.XAttr_WALK_SPEED_Basic, (double)data.WalkSpeed);
			this.SetAttr(XAttributeDefine.XAttr_RUN_SPEED_Basic, (double)data.RunSpeed);
			this.SetAttr(XAttributeDefine.XAttr_ROTATION_SPEED_Basic, (double)data.RotateSpeed);
			this.SetAttr(XAttributeDefine.XAttr_AUTOROTATION_SPEED_Basic, (double)data.RotateSpeed);
			this.SetAttr(XAttributeDefine.XATTR_ATTACK_SPEED_Basic, (double)data.AttackSpeed);
			this.SetAttr(XAttributeDefine.XAttr_MagicAtk_Basic, (double)data.MagicAttackBase);
			this.SetAttr(XAttributeDefine.XAttr_MagicAtkMod_Basic, (double)data.MagicAttackBase);
			this.SetAttr(XAttributeDefine.XATTR_SKILL_CD_Basic, (double)data.SkillCD);
			this.SetAttr(XAttributeDefine.XAttr_SuperArmorRecovery_Basic, data.SuperArmorRecoveryValue * (double)data.MaxSuperArmor / 100.0);
			this.SetAttr(XAttributeDefine.XAttr_SuperArmorAtk_Basic, 1.0);
			this.SetAttr(XAttributeDefine.XAttr_SuperArmorDef_Basic, 0.0);
			this.SetAttr(XAttributeDefine.XAttr_SuperArmorReg_Basic, 0.0);
			this.SetAttr(XAttributeDefine.XATTR_ENMITY_Basic, XSingleton<XGlobalConfig>.singleton.GeneralCombatParam);
			this.SetAttr(XAttributeDefine.XAttr_XULI_Basic, XSingleton<XGlobalConfig>.singleton.GeneralCombatParam);
			this.SuperArmorRecoveryTimeLimit = data.SuperArmorRecoveryMax;
			this.HasWoozyStatus = data.WeakStatus;
		}

		public double GetAttr(XAttributeDefine attrDef)
		{
			int num = XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(attrDef);
			double num2 = 0.0;
			bool flag = XAttributeCommon.IsBasicRange(num);
			if (flag)
			{
				num -= XAttributeCommon.BasicStart;
				num2 = this._basicAttr[num];
			}
			else
			{
				bool flag2 = XAttributeCommon.IsPercentRange(num);
				if (flag2)
				{
					num -= XAttributeCommon.PercentStart;
					num2 = this._percentAttr[num];
				}
				else
				{
					bool flag3 = XAttributeCommon.IsTotalRange(num);
					if (flag3)
					{
						num -= XAttributeCommon.TotalStart;
						bool flag4 = attrDef == XAttributeDefine.XAttr_CurrentHP_Total || attrDef == XAttributeDefine.XAttr_CurrentMP_Total;
						if (flag4)
						{
							num2 = 1.0;
						}
						else
						{
							num2 = Math.Max(0.0, this._percentAttr[num] + 1.0);
						}
						num2 *= this._basicAttr[num];
					}
				}
			}
			return num2;
		}

		public void SetAttr(XAttributeDefine attrDef, double value)
		{
			double num = value;
			int num2 = XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(attrDef);
			bool flag = XAttributeCommon.IsBasicRange(num2);
			if (flag)
			{
				num = this._basicAttr[num2 - XAttributeCommon.BasicStart];
				this._basicAttr[num2 - XAttributeCommon.BasicStart] = value;
			}
			bool flag2 = XAttributeCommon.IsPercentRange(num2);
			if (flag2)
			{
				num = this._percentAttr[num2 - XAttributeCommon.PercentStart];
				this._percentAttr[num2 - XAttributeCommon.PercentStart] = value;
			}
			this.NotifyAttrChangedToDocument(attrDef, value - num);
		}

		internal void SetAttrFromServer(int attrID, double attrValue)
		{
			double num = 0.0;
			bool flag = this._security_Statistics != null && this._security_Statistics.IsUsefulAttr((XAttributeDefine)attrID);
			bool flag2 = flag;
			if (flag2)
			{
				num = this.GetAttr((XAttributeDefine)attrID);
			}
			this.SetAttr((XAttributeDefine)attrID, attrValue);
			bool flag3 = flag;
			if (flag3)
			{
				double attr = this.GetAttr((XAttributeDefine)attrID);
				this._security_Statistics.OnAttributeChange((XAttributeDefine)attrID, num, attr - num);
			}
		}

		protected void ChangeAttr(XAttributeDefine attrDef, double delta)
		{
			int num = XFastEnumIntEqualityComparer<XAttributeDefine>.ToInt(attrDef);
			bool flag = XAttributeCommon.IsBasicRange(num);
			if (flag)
			{
				ref SmallBuffer<double> ptr = ref this._basicAttr;
				int index = num - XAttributeCommon.BasicStart;
				ptr[index] += delta;
			}
			bool flag2 = XAttributeCommon.IsPercentRange(num);
			if (flag2)
			{
				ref SmallBuffer<double> ptr = ref this._percentAttr;
				int index = num - XAttributeCommon.PercentStart;
				ptr[index] += delta / 100.0;
			}
			this.NotifyAttrChangedToDocument(attrDef, delta);
		}

		private void NotifyAttrChangedToDocument(XAttributeDefine attrDef, double delta)
		{
			bool flag = this._entity != null;
			if (flag)
			{
				bool isPlayer = this._entity.IsPlayer;
				if (isPlayer)
				{
					XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
					@event.AttrKey = attrDef;
					@event.DeltaValue = this.GetAttr(attrDef);
					@event.Firer = XSingleton<XGame>.singleton.Doc;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
				else
				{
					bool flag2 = attrDef == XAttributeDefine.XAttr_CurrentEnergy_Basic;
					if (flag2)
					{
						XEntityAttrChangeEventArgs event2 = XEventPool<XEntityAttrChangeEventArgs>.GetEvent();
						event2.AttrKey = attrDef;
						event2.Value = this.GetAttr(attrDef);
						event2.Delta = delta;
						event2.Entity = this._entity;
						event2.Firer = XSingleton<XGame>.singleton.Doc;
						XSingleton<XEventMgr>.singleton.FireEvent(event2);
					}
				}
			}
		}

		private void OnHPChanged()
		{
			bool flag = !XSingleton<XGame>.singleton.SyncMode && !this.IsDead;
			if (flag)
			{
				XSingleton<XDeath>.singleton.DeathDetect(this._entity, null, false);
			}
		}

		protected bool OnAttributeChange(XEventArgs e)
		{
			XAttrChangeEventArgs xattrChangeEventArgs = e as XAttrChangeEventArgs;
			double num = 0.0;
			double num2 = 0.0;
			bool flag = xattrChangeEventArgs.bShowHUD && xattrChangeEventArgs.AttrKey == XAttributeDefine.XAttr_CurrentHP_Basic;
			bool flag2 = XAttributeCommon.GetAttrLimitAttr(xattrChangeEventArgs.AttrKey) != XAttributeDefine.XAttr_Invalid;
			bool flag3 = flag2;
			if (flag3)
			{
				num = this.GetAttr(xattrChangeEventArgs.AttrKey);
			}
			this.ChangeAttr(xattrChangeEventArgs.AttrKey, xattrChangeEventArgs.DeltaValue);
			this.ClampAttr(xattrChangeEventArgs.AttrKey);
			bool flag4 = flag2;
			if (flag4)
			{
				num2 = this.GetAttr(xattrChangeEventArgs.AttrKey);
			}
			bool flag5 = xattrChangeEventArgs.AttrKey == XAttributeDefine.XAttr_CurrentHP_Basic;
			if (flag5)
			{
				this.OnHPChanged();
			}
			bool flag6 = this._security_Statistics != null && this._security_Statistics.IsUsefulAttr(xattrChangeEventArgs.AttrKey) && num != num2;
			if (flag6)
			{
				this._security_Statistics.OnAttributeChange(xattrChangeEventArgs.AttrKey, num, xattrChangeEventArgs.DeltaValue);
			}
			bool flag7 = flag;
			if (flag7)
			{
				bool flag8 = num2 != num;
				if (flag8)
				{
					ProjectDamageResult data = XDataPool<ProjectDamageResult>.GetData();
					data.Accept = true;
					data.ElementType = DamageElement.DE_NONE;
					data.Value = num - num2;
					data.Caster = xattrChangeEventArgs.CasterID;
					XHUDAddEventArgs @event = XEventPool<XHUDAddEventArgs>.GetEvent();
					@event.damageResult = data;
					@event.Firer = base.Entity;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
					data.Recycle();
				}
			}
			return true;
		}

		protected void ClampAttr(XAttributeDefine currAttr)
		{
			XAttributeDefine attrLimitAttr = XAttributeCommon.GetAttrLimitAttr(currAttr);
			bool flag = attrLimitAttr != XAttributeDefine.XAttr_Invalid;
			if (flag)
			{
				double num = this.GetAttr(currAttr);
				double attr = this.GetAttr(attrLimitAttr);
				bool flag2 = num > attr;
				if (flag2)
				{
					num = attr;
				}
				bool flag3 = num < 0.0;
				if (flag3)
				{
					bool flag4 = currAttr == XAttributeDefine.XAttr_CurrentHP_Basic || currAttr == XAttributeDefine.XAttr_CurrentMP_Basic || currAttr == XAttributeDefine.XAttr_CurrentSuperArmor_Basic || currAttr == XAttributeDefine.XAttr_CurrentXULI_Basic;
					if (flag4)
					{
						num = 0.0;
					}
				}
				this.SetAttr(currAttr, num);
			}
		}

		private void AttrRegenerate(XAttributeDefine currAttr)
		{
			XAttributeDefine regenAttr = XAttributeCommon.GetRegenAttr(currAttr);
			bool flag = regenAttr == XAttributeDefine.XAttr_Invalid;
			if (!flag)
			{
				double attr = this.GetAttr(regenAttr);
				bool flag2 = attr == 0.0;
				if (!flag2)
				{
					XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
					@event.AttrKey = currAttr;
					@event.DeltaValue = attr;
					@event.Firer = base.Entity;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
		}

		private void OnAttributeRegenerate(object arg)
		{
			this._time_token = XSingleton<XTimerMgr>.singleton.SetTimer(1f, this._onAttributeRegenerateCb, null);
			bool flag = !this.IsDead;
			if (flag)
			{
				bool flag2 = !XSingleton<XGame>.singleton.SyncMode;
				if (flag2)
				{
					this.AttrRegenerate(XAttributeDefine.XAttr_CurrentHP_Basic);
					this.AttrRegenerate(XAttributeDefine.XAttr_CurrentMP_Basic);
					this.AttrRegenerate(XAttributeDefine.XAttr_CurrentSuperArmor_Basic);
				}
			}
		}

		public override void InitilizeBuffer()
		{
			base.InitilizeBuffer();
			XSingleton<XAttributeMgr>.singleton.GetBuffer(ref this._basicAttr, XAttributeCommon.AttrCount, XAttributeCommon.AttrCount);
			XSingleton<XAttributeMgr>.singleton.GetBuffer(ref this._percentAttr, XAttributeCommon.AttrCount, XAttributeCommon.AttrCount);
		}

		public override void UninitilizeBuffer()
		{
			base.UninitilizeBuffer();
			XSingleton<XAttributeMgr>.singleton.ReturnBuffer(ref this._basicAttr);
			XSingleton<XAttributeMgr>.singleton.ReturnBuffer(ref this._percentAttr);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._time_token = XSingleton<XTimerMgr>.singleton.SetTimer(1f, this._onAttributeRegenerateCb, null);
			bool flag = this._security_Statistics != null;
			if (flag)
			{
				this._security_Statistics.Entity = this._entity;
			}
		}

		public override void OnDetachFromHost()
		{
			bool flag = this._security_Statistics != null;
			if (flag)
			{
				this._security_Statistics.Dump();
				this._security_Statistics.Entity = null;
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this._time_token);
			base.OnDetachFromHost();
		}

		public override void OnReconnect(UnitAppearance data)
		{
			base.OnReconnect(data);
			bool isPlayer = base.Entity.IsPlayer;
			if (!isPlayer)
			{
				XOutlookHelper.SetOutLookReplace(this, base.Entity, data.outlook);
				this.OnFightGroupChange(data.fightgroup);
			}
		}

		public void SetStatistics(XSecurityStatistics ss)
		{
			bool flag = this._security_Statistics != null;
			if (flag)
			{
				this._security_Statistics = ss;
				this._security_Statistics.Entity = this._entity;
			}
		}

		public virtual bool IsBindedSkill(uint id)
		{
			return true;
		}

		public void ForceDeath()
		{
			XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
			@event.AttrKey = XAttributeDefine.XAttr_CurrentHP_Basic;
			@event.DeltaValue = -this.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
			@event.Firer = base.Entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		public void CombatReset()
		{
			this._battle_Statistics.Reset();
		}

		public void CombatAppendTime()
		{
			this._battle_Statistics.AppendTime();
		}

		public void CombatMarkTimeBaseLine()
		{
			this._battle_Statistics.MarkTimeBaseLine();
		}

		public void CombatMarkTimEndLine()
		{
			this._battle_Statistics.MarkTimEndLine();
		}

		public void CombatAppendDamage(double damage)
		{
			this._battle_Statistics.AppendDamage(damage);
		}

		public void TogglePrintDamage(bool bStart)
		{
			if (bStart)
			{
				this._battle_Statistics.StartPrintDamage(0f);
			}
			else
			{
				this._battle_Statistics.StopPrintDamage();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Attributes");

		public XSkillLevelInfoMgr SkillLevelInfo = new XSkillLevelInfoMgr();

		public uint[] skillSlot = null;

		private ulong _id;

		private uint _shortId = 0U;

		private uint _type_id;

		private uint _present_id;

		private EntitySpecies _type;

		private uint _fight_group = uint.MaxValue;

		private bool _midway_enter = false;

		private bool _is_dead = false;

		private bool _is_solo_supported = false;

		private bool _be_locked = false;

		private string _prefab_name = null;

		private string _name = null;

		private uint _payMemberID = 0U;

		private SmallBuffer<double> _basicAttr;

		private SmallBuffer<double> _percentAttr;

		protected SeqListRef<int> _inborn_buff;

		protected static int _start = XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_START);

		protected static int _end = XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_END);

		protected XBattleStatistics _battle_Statistics;

		protected XSecurityStatistics _security_Statistics;

		public XOutlookData Outlook = new XOutlookData();

		public XBodyBag EmblemBag;

		private uint _time_token = 0U;

		private uint _level = 1U;

		private Vector3 _appear_pos = Vector3.zero;

		private XTimerMgr.ElapsedEventHandler _onAttributeRegenerateCb = null;

		private ulong _HostID = 0UL;

		private ulong _FinalHostID = 0UL;

		private uint _TitleID = 1U;

		protected XBuffStateInfo _buff_state = new XBuffStateInfo();

		public double SuperArmorRecoveryTimeLimit = 0.0;

		public bool HasWoozyStatus = false;

		public bool IsSuperArmorBroken = false;
	}
}
