using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F3B RID: 3899
	internal abstract class XAttributes : XComponent
	{
		// Token: 0x17003625 RID: 13861
		// (get) Token: 0x0600CF0C RID: 53004 RVA: 0x0030171C File Offset: 0x002FF91C
		public override uint ID
		{
			get
			{
				return XAttributes.uuID;
			}
		}

		// Token: 0x17003626 RID: 13862
		// (get) Token: 0x0600CF0D RID: 53005 RVA: 0x00301734 File Offset: 0x002FF934
		public ulong RoleID
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x17003627 RID: 13863
		// (get) Token: 0x0600CF0E RID: 53006 RVA: 0x0030174C File Offset: 0x002FF94C
		// (set) Token: 0x0600CF0F RID: 53007 RVA: 0x00301764 File Offset: 0x002FF964
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

		// Token: 0x17003628 RID: 13864
		// (get) Token: 0x0600CF10 RID: 53008 RVA: 0x00301770 File Offset: 0x002FF970
		public SeqListRef<int> InBornBuff
		{
			get
			{
				return this._inborn_buff;
			}
		}

		// Token: 0x17003629 RID: 13865
		// (get) Token: 0x0600CF11 RID: 53009 RVA: 0x00301788 File Offset: 0x002FF988
		// (set) Token: 0x0600CF12 RID: 53010 RVA: 0x003017A0 File Offset: 0x002FF9A0
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

		// Token: 0x1700362A RID: 13866
		// (get) Token: 0x0600CF13 RID: 53011 RVA: 0x003017AC File Offset: 0x002FF9AC
		// (set) Token: 0x0600CF14 RID: 53012 RVA: 0x003017C4 File Offset: 0x002FF9C4
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

		// Token: 0x1700362B RID: 13867
		// (get) Token: 0x0600CF15 RID: 53013 RVA: 0x003017D0 File Offset: 0x002FF9D0
		// (set) Token: 0x0600CF16 RID: 53014 RVA: 0x003017E8 File Offset: 0x002FF9E8
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

		// Token: 0x1700362C RID: 13868
		// (get) Token: 0x0600CF17 RID: 53015 RVA: 0x003017F4 File Offset: 0x002FF9F4
		// (set) Token: 0x0600CF18 RID: 53016 RVA: 0x0030180C File Offset: 0x002FFA0C
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

		// Token: 0x1700362D RID: 13869
		// (get) Token: 0x0600CF19 RID: 53017 RVA: 0x00301818 File Offset: 0x002FFA18
		// (set) Token: 0x0600CF1A RID: 53018 RVA: 0x00301830 File Offset: 0x002FFA30
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

		// Token: 0x1700362E RID: 13870
		// (get) Token: 0x0600CF1B RID: 53019 RVA: 0x0030183C File Offset: 0x002FFA3C
		// (set) Token: 0x0600CF1C RID: 53020 RVA: 0x00301854 File Offset: 0x002FFA54
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

		// Token: 0x1700362F RID: 13871
		// (get) Token: 0x0600CF1D RID: 53021 RVA: 0x00301860 File Offset: 0x002FFA60
		// (set) Token: 0x0600CF1E RID: 53022 RVA: 0x00301878 File Offset: 0x002FFA78
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

		// Token: 0x17003630 RID: 13872
		// (get) Token: 0x0600CF1F RID: 53023 RVA: 0x00301884 File Offset: 0x002FFA84
		// (set) Token: 0x0600CF20 RID: 53024 RVA: 0x0030189C File Offset: 0x002FFA9C
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

		// Token: 0x17003631 RID: 13873
		// (get) Token: 0x0600CF21 RID: 53025 RVA: 0x003018A8 File Offset: 0x002FFAA8
		// (set) Token: 0x0600CF22 RID: 53026 RVA: 0x003018C0 File Offset: 0x002FFAC0
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

		// Token: 0x17003632 RID: 13874
		// (get) Token: 0x0600CF23 RID: 53027 RVA: 0x003018CC File Offset: 0x002FFACC
		// (set) Token: 0x0600CF24 RID: 53028 RVA: 0x003018E4 File Offset: 0x002FFAE4
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

		// Token: 0x17003633 RID: 13875
		// (get) Token: 0x0600CF25 RID: 53029 RVA: 0x003018F8 File Offset: 0x002FFAF8
		public ulong FinalHostID
		{
			get
			{
				return this._FinalHostID;
			}
		}

		// Token: 0x17003634 RID: 13876
		// (get) Token: 0x0600CF26 RID: 53030 RVA: 0x00301910 File Offset: 0x002FFB10
		public virtual uint Tag
		{
			get
			{
				return 0U;
			}
		}

		// Token: 0x0600CF27 RID: 53031 RVA: 0x00301924 File Offset: 0x002FFB24
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

		// Token: 0x17003635 RID: 13877
		// (get) Token: 0x0600CF28 RID: 53032 RVA: 0x00301978 File Offset: 0x002FFB78
		public XSecurityStatistics SecurityStatistics
		{
			get
			{
				return this._security_Statistics;
			}
		}

		// Token: 0x17003636 RID: 13878
		// (get) Token: 0x0600CF29 RID: 53033 RVA: 0x00301990 File Offset: 0x002FFB90
		public double Dps
		{
			get
			{
				return this._battle_Statistics.Dps;
			}
		}

		// Token: 0x17003637 RID: 13879
		// (get) Token: 0x0600CF2A RID: 53034 RVA: 0x003019B0 File Offset: 0x002FFBB0
		public double PrintDamage
		{
			get
			{
				return this._battle_Statistics.PrintDamage;
			}
		}

		// Token: 0x0600CF2B RID: 53035 RVA: 0x003019D0 File Offset: 0x002FFBD0
		public XAttributes()
		{
			this._onAttributeRegenerateCb = new XTimerMgr.ElapsedEventHandler(this.OnAttributeRegenerate);
		}

		// Token: 0x0600CF2C RID: 53036 RVA: 0x00301AB4 File Offset: 0x002FFCB4
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

		// Token: 0x0600CF2D RID: 53037 RVA: 0x00301C4C File Offset: 0x002FFE4C
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

		// Token: 0x0600CF2E RID: 53038 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void InitEquipList(List<uint> equipData)
		{
		}

		// Token: 0x17003638 RID: 13880
		// (get) Token: 0x0600CF2F RID: 53039 RVA: 0x00301D08 File Offset: 0x002FFF08
		// (set) Token: 0x0600CF30 RID: 53040 RVA: 0x00301D20 File Offset: 0x002FFF20
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

		// Token: 0x17003639 RID: 13881
		// (get) Token: 0x0600CF31 RID: 53041 RVA: 0x00301D2C File Offset: 0x002FFF2C
		// (set) Token: 0x0600CF32 RID: 53042 RVA: 0x00301D44 File Offset: 0x002FFF44
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

		// Token: 0x1700363A RID: 13882
		// (get) Token: 0x0600CF33 RID: 53043 RVA: 0x00301D50 File Offset: 0x002FFF50
		public virtual uint BasicTypeID
		{
			get
			{
				return this.TypeID;
			}
		}

		// Token: 0x1700363B RID: 13883
		// (get) Token: 0x0600CF34 RID: 53044 RVA: 0x00301D68 File Offset: 0x002FFF68
		// (set) Token: 0x0600CF35 RID: 53045 RVA: 0x00301D80 File Offset: 0x002FFF80
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

		// Token: 0x1700363C RID: 13884
		// (get) Token: 0x0600CF36 RID: 53046 RVA: 0x00301D8C File Offset: 0x002FFF8C
		// (set) Token: 0x0600CF37 RID: 53047 RVA: 0x00301DA4 File Offset: 0x002FFFA4
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

		// Token: 0x0600CF38 RID: 53048 RVA: 0x00301DB0 File Offset: 0x002FFFB0
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

		// Token: 0x0600CF39 RID: 53049 RVA: 0x00301E28 File Offset: 0x00300028
		public static bool IsPlayer(ulong uID)
		{
			return uID == XSingleton<XGame>.singleton.PlayerID;
		}

		// Token: 0x0600CF3A RID: 53050 RVA: 0x00301E48 File Offset: 0x00300048
		public static EntityCategory GetCategory(ulong uID)
		{
			return (EntityCategory)(uID >> 60);
		}

		// Token: 0x0600CF3B RID: 53051 RVA: 0x00301E60 File Offset: 0x00300060
		public EntityCategory GetCategory()
		{
			return (EntityCategory)(this.EntityID >> 60);
		}

		// Token: 0x1700363D RID: 13885
		// (get) Token: 0x0600CF3C RID: 53052 RVA: 0x00301E7C File Offset: 0x0030007C
		// (set) Token: 0x0600CF3D RID: 53053 RVA: 0x00301E94 File Offset: 0x00300094
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

		// Token: 0x1700363E RID: 13886
		// (get) Token: 0x0600CF3E RID: 53054 RVA: 0x00301EA0 File Offset: 0x003000A0
		// (set) Token: 0x0600CF3F RID: 53055 RVA: 0x00301EB8 File Offset: 0x003000B8
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

		// Token: 0x1700363F RID: 13887
		// (get) Token: 0x0600CF40 RID: 53056 RVA: 0x00301EE4 File Offset: 0x003000E4
		public uint point
		{
			get
			{
				XCarnivalDocument specificDocument = XDocuments.GetSpecificDocument<XCarnivalDocument>(XCarnivalDocument.uuID);
				XBagDocument specificDocument2 = XDocuments.GetSpecificDocument<XBagDocument>(XBagDocument.uuID);
				return (uint)specificDocument2.GetItemCount(specificDocument.pointItemID);
			}
		}

		// Token: 0x17003640 RID: 13888
		// (get) Token: 0x0600CF41 RID: 53057 RVA: 0x00301F19 File Offset: 0x00300119
		// (set) Token: 0x0600CF42 RID: 53058 RVA: 0x00301F21 File Offset: 0x00300121
		public bool CarnivalClaimed { get; set; }

		// Token: 0x17003641 RID: 13889
		// (get) Token: 0x0600CF43 RID: 53059 RVA: 0x00301F2A File Offset: 0x0030012A
		// (set) Token: 0x0600CF44 RID: 53060 RVA: 0x00301F32 File Offset: 0x00300132
		public ulong Exp { get; set; }

		// Token: 0x17003642 RID: 13890
		// (get) Token: 0x0600CF45 RID: 53061 RVA: 0x00301F3B File Offset: 0x0030013B
		// (set) Token: 0x0600CF46 RID: 53062 RVA: 0x00301F43 File Offset: 0x00300143
		public ulong MaxExp { get; set; }

		// Token: 0x17003643 RID: 13891
		// (get) Token: 0x0600CF47 RID: 53063 RVA: 0x00301F4C File Offset: 0x0030014C
		public float RunSpeed
		{
			get
			{
				return (float)this.GetAttr(XAttributeDefine.XAttr_RUN_SPEED_Total) * this._entity.Scale;
			}
		}

		// Token: 0x17003644 RID: 13892
		// (get) Token: 0x0600CF48 RID: 53064 RVA: 0x00301F78 File Offset: 0x00300178
		public float WalkSpeed
		{
			get
			{
				return (float)this.GetAttr(XAttributeDefine.XAttr_WALK_SPEED_Total) * this._entity.Scale;
			}
		}

		// Token: 0x17003645 RID: 13893
		// (get) Token: 0x0600CF49 RID: 53065 RVA: 0x00301FA4 File Offset: 0x003001A4
		public float RotateSpeed
		{
			get
			{
				return (float)this.GetAttr(XAttributeDefine.XAttr_ROTATION_SPEED_Total);
			}
		}

		// Token: 0x17003646 RID: 13894
		// (get) Token: 0x0600CF4A RID: 53066 RVA: 0x00301FC4 File Offset: 0x003001C4
		public float AutoRotateSpeed
		{
			get
			{
				return (float)this.GetAttr(XAttributeDefine.XAttr_AUTOROTATION_SPEED_Total);
			}
		}

		// Token: 0x17003647 RID: 13895
		// (get) Token: 0x0600CF4B RID: 53067 RVA: 0x00301FE4 File Offset: 0x003001E4
		public float AttackSpeed
		{
			get
			{
				return Mathf.Clamp((float)(this.GetAttr(XAttributeDefine.XATTR_ATTACK_SPEED_Total) / XSingleton<XGlobalConfig>.singleton.GeneralCombatParam), (float)XSingleton<XGlobalConfig>.singleton.AttackSpeedLowerBound, (float)XSingleton<XGlobalConfig>.singleton.AttackSpeedUpperBound);
			}
		}

		// Token: 0x17003648 RID: 13896
		// (get) Token: 0x0600CF4C RID: 53068 RVA: 0x00302028 File Offset: 0x00300228
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

		// Token: 0x17003649 RID: 13897
		// (get) Token: 0x0600CF4D RID: 53069 RVA: 0x00302084 File Offset: 0x00300284
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

		// Token: 0x1700364A RID: 13898
		// (get) Token: 0x0600CF4E RID: 53070 RVA: 0x003020E0 File Offset: 0x003002E0
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

		// Token: 0x1700364B RID: 13899
		// (get) Token: 0x0600CF4F RID: 53071 RVA: 0x00302128 File Offset: 0x00300328
		public XBuffStateInfo BuffState
		{
			get
			{
				return this._buff_state;
			}
		}

		// Token: 0x0600CF50 RID: 53072 RVA: 0x00302140 File Offset: 0x00300340
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_AttributeChange, new XComponent.XEventHandler(this.OnAttributeChange));
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this.OnRealDead));
			base.RegisterEvent(XEventDefine.XEvent_EquipChange, new XComponent.XEventHandler(this.OnEquipChange));
			base.RegisterEvent(XEventDefine.XEvent_ProjectDamage, new XComponent.XEventHandler(this.OnProjectDamage));
		}

		// Token: 0x0600CF51 RID: 53073 RVA: 0x003021A8 File Offset: 0x003003A8
		protected bool OnRealDead(XEventArgs e)
		{
			this._is_dead = true;
			return true;
		}

		// Token: 0x0600CF52 RID: 53074 RVA: 0x003021C4 File Offset: 0x003003C4
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

		// Token: 0x0600CF53 RID: 53075 RVA: 0x003022F8 File Offset: 0x003004F8
		public virtual void InitAttribute(KKSG.Attribute attr)
		{
			for (int i = 0; i < attr.attrID.Count; i++)
			{
				uint index = attr.attrID[i];
				this._basicAttr[index] = attr.basicAttribute[i];
				this._percentAttr[index] = attr.percentAttribute[i];
			}
		}

		// Token: 0x0600CF54 RID: 53076 RVA: 0x00302364 File Offset: 0x00300564
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

		// Token: 0x0600CF55 RID: 53077 RVA: 0x003024FC File Offset: 0x003006FC
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

		// Token: 0x0600CF56 RID: 53078 RVA: 0x003025DC File Offset: 0x003007DC
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

		// Token: 0x0600CF57 RID: 53079 RVA: 0x00302664 File Offset: 0x00300864
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

		// Token: 0x0600CF58 RID: 53080 RVA: 0x003026DC File Offset: 0x003008DC
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

		// Token: 0x0600CF59 RID: 53081 RVA: 0x00302760 File Offset: 0x00300960
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

		// Token: 0x0600CF5A RID: 53082 RVA: 0x0030282C File Offset: 0x00300A2C
		private void OnHPChanged()
		{
			bool flag = !XSingleton<XGame>.singleton.SyncMode && !this.IsDead;
			if (flag)
			{
				XSingleton<XDeath>.singleton.DeathDetect(this._entity, null, false);
			}
		}

		// Token: 0x0600CF5B RID: 53083 RVA: 0x0030286C File Offset: 0x00300A6C
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

		// Token: 0x0600CF5C RID: 53084 RVA: 0x003029F0 File Offset: 0x00300BF0
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

		// Token: 0x0600CF5D RID: 53085 RVA: 0x00302A78 File Offset: 0x00300C78
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

		// Token: 0x0600CF5E RID: 53086 RVA: 0x00302AE4 File Offset: 0x00300CE4
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

		// Token: 0x0600CF5F RID: 53087 RVA: 0x00302B4B File Offset: 0x00300D4B
		public override void InitilizeBuffer()
		{
			base.InitilizeBuffer();
			XSingleton<XAttributeMgr>.singleton.GetBuffer(ref this._basicAttr, XAttributeCommon.AttrCount, XAttributeCommon.AttrCount);
			XSingleton<XAttributeMgr>.singleton.GetBuffer(ref this._percentAttr, XAttributeCommon.AttrCount, XAttributeCommon.AttrCount);
		}

		// Token: 0x0600CF60 RID: 53088 RVA: 0x00302B8B File Offset: 0x00300D8B
		public override void UninitilizeBuffer()
		{
			base.UninitilizeBuffer();
			XSingleton<XAttributeMgr>.singleton.ReturnBuffer(ref this._basicAttr);
			XSingleton<XAttributeMgr>.singleton.ReturnBuffer(ref this._percentAttr);
		}

		// Token: 0x0600CF61 RID: 53089 RVA: 0x00302BB8 File Offset: 0x00300DB8
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

		// Token: 0x0600CF62 RID: 53090 RVA: 0x00302C0C File Offset: 0x00300E0C
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

		// Token: 0x0600CF63 RID: 53091 RVA: 0x00302C5C File Offset: 0x00300E5C
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

		// Token: 0x0600CF64 RID: 53092 RVA: 0x00302CA4 File Offset: 0x00300EA4
		public void SetStatistics(XSecurityStatistics ss)
		{
			bool flag = this._security_Statistics != null;
			if (flag)
			{
				this._security_Statistics = ss;
				this._security_Statistics.Entity = this._entity;
			}
		}

		// Token: 0x0600CF65 RID: 53093 RVA: 0x00302CDC File Offset: 0x00300EDC
		public virtual bool IsBindedSkill(uint id)
		{
			return true;
		}

		// Token: 0x0600CF66 RID: 53094 RVA: 0x00302CF0 File Offset: 0x00300EF0
		public void ForceDeath()
		{
			XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
			@event.AttrKey = XAttributeDefine.XAttr_CurrentHP_Basic;
			@event.DeltaValue = -this.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
			@event.Firer = base.Entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600CF67 RID: 53095 RVA: 0x00302D36 File Offset: 0x00300F36
		public void CombatReset()
		{
			this._battle_Statistics.Reset();
		}

		// Token: 0x0600CF68 RID: 53096 RVA: 0x00302D45 File Offset: 0x00300F45
		public void CombatAppendTime()
		{
			this._battle_Statistics.AppendTime();
		}

		// Token: 0x0600CF69 RID: 53097 RVA: 0x00302D54 File Offset: 0x00300F54
		public void CombatMarkTimeBaseLine()
		{
			this._battle_Statistics.MarkTimeBaseLine();
		}

		// Token: 0x0600CF6A RID: 53098 RVA: 0x00302D63 File Offset: 0x00300F63
		public void CombatMarkTimEndLine()
		{
			this._battle_Statistics.MarkTimEndLine();
		}

		// Token: 0x0600CF6B RID: 53099 RVA: 0x00302D72 File Offset: 0x00300F72
		public void CombatAppendDamage(double damage)
		{
			this._battle_Statistics.AppendDamage(damage);
		}

		// Token: 0x0600CF6C RID: 53100 RVA: 0x00302D84 File Offset: 0x00300F84
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

		// Token: 0x04005D14 RID: 23828
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Attributes");

		// Token: 0x04005D15 RID: 23829
		public XSkillLevelInfoMgr SkillLevelInfo = new XSkillLevelInfoMgr();

		// Token: 0x04005D16 RID: 23830
		public uint[] skillSlot = null;

		// Token: 0x04005D17 RID: 23831
		private ulong _id;

		// Token: 0x04005D18 RID: 23832
		private uint _shortId = 0U;

		// Token: 0x04005D19 RID: 23833
		private uint _type_id;

		// Token: 0x04005D1A RID: 23834
		private uint _present_id;

		// Token: 0x04005D1B RID: 23835
		private EntitySpecies _type;

		// Token: 0x04005D1C RID: 23836
		private uint _fight_group = uint.MaxValue;

		// Token: 0x04005D1D RID: 23837
		private bool _midway_enter = false;

		// Token: 0x04005D1E RID: 23838
		private bool _is_dead = false;

		// Token: 0x04005D1F RID: 23839
		private bool _is_solo_supported = false;

		// Token: 0x04005D20 RID: 23840
		private bool _be_locked = false;

		// Token: 0x04005D21 RID: 23841
		private string _prefab_name = null;

		// Token: 0x04005D22 RID: 23842
		private string _name = null;

		// Token: 0x04005D23 RID: 23843
		private uint _payMemberID = 0U;

		// Token: 0x04005D24 RID: 23844
		private SmallBuffer<double> _basicAttr;

		// Token: 0x04005D25 RID: 23845
		private SmallBuffer<double> _percentAttr;

		// Token: 0x04005D26 RID: 23846
		protected SeqListRef<int> _inborn_buff;

		// Token: 0x04005D27 RID: 23847
		protected static int _start = XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_START);

		// Token: 0x04005D28 RID: 23848
		protected static int _end = XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_END);

		// Token: 0x04005D29 RID: 23849
		protected XBattleStatistics _battle_Statistics;

		// Token: 0x04005D2A RID: 23850
		protected XSecurityStatistics _security_Statistics;

		// Token: 0x04005D2B RID: 23851
		public XOutlookData Outlook = new XOutlookData();

		// Token: 0x04005D2C RID: 23852
		public XBodyBag EmblemBag;

		// Token: 0x04005D2D RID: 23853
		private uint _time_token = 0U;

		// Token: 0x04005D2E RID: 23854
		private uint _level = 1U;

		// Token: 0x04005D2F RID: 23855
		private Vector3 _appear_pos = Vector3.zero;

		// Token: 0x04005D30 RID: 23856
		private XTimerMgr.ElapsedEventHandler _onAttributeRegenerateCb = null;

		// Token: 0x04005D31 RID: 23857
		private ulong _HostID = 0UL;

		// Token: 0x04005D32 RID: 23858
		private ulong _FinalHostID = 0UL;

		// Token: 0x04005D33 RID: 23859
		private uint _TitleID = 1U;

		// Token: 0x04005D37 RID: 23863
		protected XBuffStateInfo _buff_state = new XBuffStateInfo();

		// Token: 0x04005D38 RID: 23864
		public double SuperArmorRecoveryTimeLimit = 0.0;

		// Token: 0x04005D39 RID: 23865
		public bool HasWoozyStatus = false;

		// Token: 0x04005D3A RID: 23866
		public bool IsSuperArmorBroken = false;
	}
}
