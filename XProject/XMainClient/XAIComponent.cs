using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F35 RID: 3893
	internal class XAIComponent : XComponent
	{
		// Token: 0x17003600 RID: 13824
		// (get) Token: 0x0600CE78 RID: 52856 RVA: 0x002FD8C8 File Offset: 0x002FBAC8
		public override uint ID
		{
			get
			{
				return XAIComponent.uuID;
			}
		}

		// Token: 0x17003601 RID: 13825
		// (get) Token: 0x0600CE79 RID: 52857 RVA: 0x002FD8E0 File Offset: 0x002FBAE0
		// (set) Token: 0x0600CE7A RID: 52858 RVA: 0x002FD8F8 File Offset: 0x002FBAF8
		public bool IsFighting
		{
			get
			{
				return this._is_fighting;
			}
			set
			{
				this._is_fighting = value;
			}
		}

		// Token: 0x17003602 RID: 13826
		// (get) Token: 0x0600CE7B RID: 52859 RVA: 0x002FD904 File Offset: 0x002FBB04
		// (set) Token: 0x0600CE7C RID: 52860 RVA: 0x002FD91C File Offset: 0x002FBB1C
		public XRole Opponent
		{
			get
			{
				return this._opponent;
			}
			set
			{
				this._opponent = value;
			}
		}

		// Token: 0x17003603 RID: 13827
		// (get) Token: 0x0600CE7D RID: 52861 RVA: 0x002FD928 File Offset: 0x002FBB28
		public float MoveSpeed
		{
			get
			{
				return this._entity.Attributes.RunSpeed;
			}
		}

		// Token: 0x17003604 RID: 13828
		// (get) Token: 0x0600CE7E RID: 52862 RVA: 0x002FD94C File Offset: 0x002FBB4C
		public Vector3 BornPos
		{
			get
			{
				return this._born_pos;
			}
		}

		// Token: 0x17003605 RID: 13829
		// (get) Token: 0x0600CE7F RID: 52863 RVA: 0x002FD964 File Offset: 0x002FBB64
		public float AttackRange
		{
			get
			{
				return this._attack_range;
			}
		}

		// Token: 0x17003606 RID: 13830
		// (get) Token: 0x0600CE80 RID: 52864 RVA: 0x002FD97C File Offset: 0x002FBB7C
		public float MinKeepRange
		{
			get
			{
				return this._min_keep_range;
			}
		}

		// Token: 0x17003607 RID: 13831
		// (get) Token: 0x0600CE81 RID: 52865 RVA: 0x002FD994 File Offset: 0x002FBB94
		// (set) Token: 0x0600CE82 RID: 52866 RVA: 0x002FD9AC File Offset: 0x002FBBAC
		public int HuanraoIndex
		{
			get
			{
				return this._huanraoindex;
			}
			set
			{
				this._huanraoindex = value;
			}
		}

		// Token: 0x17003608 RID: 13832
		// (get) Token: 0x0600CE83 RID: 52867 RVA: 0x002FD9B8 File Offset: 0x002FBBB8
		public float AttackProb
		{
			get
			{
				return this._normal_attack_prob;
			}
		}

		// Token: 0x17003609 RID: 13833
		// (get) Token: 0x0600CE84 RID: 52868 RVA: 0x002FD9D0 File Offset: 0x002FBBD0
		public float EnterFightRange
		{
			get
			{
				return this._enter_fight_range;
			}
		}

		// Token: 0x1700360A RID: 13834
		// (get) Token: 0x0600CE85 RID: 52869 RVA: 0x002FD9E8 File Offset: 0x002FBBE8
		public float FightTogetherDis
		{
			get
			{
				return this._fight_together_dis;
			}
		}

		// Token: 0x1700360B RID: 13835
		// (get) Token: 0x0600CE86 RID: 52870 RVA: 0x002FDA00 File Offset: 0x002FBC00
		public bool IsCastingSkill
		{
			get
			{
				return this._is_casting_skill;
			}
		}

		// Token: 0x1700360C RID: 13836
		// (get) Token: 0x0600CE87 RID: 52871 RVA: 0x002FDA18 File Offset: 0x002FBC18
		public bool IsOppoCastingSkill
		{
			get
			{
				return this._is_oppo_casting_skill;
			}
		}

		// Token: 0x1700360D RID: 13837
		// (get) Token: 0x0600CE88 RID: 52872 RVA: 0x002FDA30 File Offset: 0x002FBC30
		public bool IsFixedInCd
		{
			get
			{
				return this._is_fixed_in_cd;
			}
		}

		// Token: 0x1700360E RID: 13838
		// (get) Token: 0x0600CE89 RID: 52873 RVA: 0x002FDA48 File Offset: 0x002FBC48
		public bool IsWander
		{
			get
			{
				return this._is_wander;
			}
		}

		// Token: 0x1700360F RID: 13839
		// (get) Token: 0x0600CE8A RID: 52874 RVA: 0x002FDA60 File Offset: 0x002FBC60
		// (set) Token: 0x0600CE8B RID: 52875 RVA: 0x002FDA78 File Offset: 0x002FBC78
		public bool IsHurtOppo
		{
			get
			{
				return this._is_hurt_oppo;
			}
			set
			{
				this._is_hurt_oppo = value;
			}
		}

		// Token: 0x17003610 RID: 13840
		// (get) Token: 0x0600CE8C RID: 52876 RVA: 0x002FDA84 File Offset: 0x002FBC84
		// (set) Token: 0x0600CE8D RID: 52877 RVA: 0x002FDA9C File Offset: 0x002FBC9C
		public uint CastingSkillId
		{
			get
			{
				return this._cast_skillid;
			}
			set
			{
				this._cast_skillid = value;
			}
		}

		// Token: 0x17003611 RID: 13841
		// (get) Token: 0x0600CE8E RID: 52878 RVA: 0x002FDAA8 File Offset: 0x002FBCA8
		public XEnmityList EnmityList
		{
			get
			{
				return this._enmity_list;
			}
		}

		// Token: 0x17003612 RID: 13842
		// (get) Token: 0x0600CE8F RID: 52879 RVA: 0x002FDAC0 File Offset: 0x002FBCC0
		// (set) Token: 0x0600CE90 RID: 52880 RVA: 0x002FDAD8 File Offset: 0x002FBCD8
		public XAIEventArgs AIEvent
		{
			get
			{
				return this._ai_event;
			}
			set
			{
				this._ai_event = value;
			}
		}

		// Token: 0x17003613 RID: 13843
		// (get) Token: 0x0600CE91 RID: 52881 RVA: 0x002FDAE4 File Offset: 0x002FBCE4
		public XPatrol Patrol
		{
			get
			{
				return this._Patrol;
			}
		}

		// Token: 0x17003614 RID: 13844
		// (get) Token: 0x0600CE92 RID: 52882 RVA: 0x002FDAFC File Offset: 0x002FBCFC
		private List<XSkillCore> CanCastSkill
		{
			get
			{
				bool flag = this._can_cast_skill == null;
				if (flag)
				{
					this._can_cast_skill = ListPool<XSkillCore>.Get();
				}
				return this._can_cast_skill;
			}
		}

		// Token: 0x17003615 RID: 13845
		// (get) Token: 0x0600CE93 RID: 52883 RVA: 0x002FDB30 File Offset: 0x002FBD30
		public int CanCastSkillCount
		{
			get
			{
				return (this._can_cast_skill == null) ? 0 : this._can_cast_skill.Count;
			}
		}

		// Token: 0x0600CE94 RID: 52884 RVA: 0x002FDB58 File Offset: 0x002FBD58
		public void Copy2CanCastSkill(List<XSkillCore> lst)
		{
			this.CanCastSkill.Clear();
			this.CanCastSkill.AddRange(lst);
		}

		// Token: 0x0600CE95 RID: 52885 RVA: 0x002FDB74 File Offset: 0x002FBD74
		public void ClearCanCastSkill()
		{
			bool flag = this._can_cast_skill != null;
			if (flag)
			{
				this._can_cast_skill.Clear();
			}
		}

		// Token: 0x0600CE96 RID: 52886 RVA: 0x002FDB9B File Offset: 0x002FBD9B
		public void AddCanCastSkill(XSkillCore skill)
		{
			this.CanCastSkill.Add(skill);
		}

		// Token: 0x0600CE97 RID: 52887 RVA: 0x002FDBAC File Offset: 0x002FBDAC
		public XSkillCore GetCanCastSkill(int index)
		{
			return this.CanCastSkill[index];
		}

		// Token: 0x0600CE98 RID: 52888 RVA: 0x002FDBCC File Offset: 0x002FBDCC
		public void RemoveCanCastSkillAt(int index)
		{
			bool flag = this._can_cast_skill != null;
			if (flag)
			{
				this._can_cast_skill.RemoveAt(index);
			}
		}

		// Token: 0x0600CE99 RID: 52889 RVA: 0x002FDBF4 File Offset: 0x002FBDF4
		public void RemoveCanCastSkillRange(int index, int count)
		{
			bool flag = this._can_cast_skill != null;
			if (flag)
			{
				this._can_cast_skill.RemoveRange(index, count);
			}
		}

		// Token: 0x17003616 RID: 13846
		// (get) Token: 0x0600CE9A RID: 52890 RVA: 0x002FDC20 File Offset: 0x002FBE20
		public int RangeSkillCount
		{
			get
			{
				return (this._range_skill == null) ? 0 : this._range_skill.Count;
			}
		}

		// Token: 0x17003617 RID: 13847
		// (get) Token: 0x0600CE9B RID: 52891 RVA: 0x002FDC48 File Offset: 0x002FBE48
		private List<XSkillCore> RangeSkill
		{
			get
			{
				bool flag = this._range_skill == null;
				if (flag)
				{
					this._range_skill = ListPool<XSkillCore>.Get();
				}
				return this._range_skill;
			}
		}

		// Token: 0x0600CE9C RID: 52892 RVA: 0x002FDC7A File Offset: 0x002FBE7A
		public void AddRangeSkill(XSkillCore skill)
		{
			this.RangeSkill.Add(skill);
		}

		// Token: 0x0600CE9D RID: 52893 RVA: 0x002FDC8C File Offset: 0x002FBE8C
		public void CopyRange2CanCast()
		{
			this.CanCastSkill.Clear();
			bool flag = this._range_skill != null;
			if (flag)
			{
				this.CanCastSkill.AddRange(this._range_skill);
			}
		}

		// Token: 0x17003618 RID: 13848
		// (get) Token: 0x0600CE9E RID: 52894 RVA: 0x002FDCC8 File Offset: 0x002FBEC8
		private List<XEntity> targets
		{
			get
			{
				bool flag = this._targets == null;
				if (flag)
				{
					this._targets = ListPool<XEntity>.Get();
				}
				return this._targets;
			}
		}

		// Token: 0x17003619 RID: 13849
		// (get) Token: 0x0600CE9F RID: 52895 RVA: 0x002FDCFC File Offset: 0x002FBEFC
		public int TargetsCount
		{
			get
			{
				return (this._targets == null) ? 0 : this._targets.Count;
			}
		}

		// Token: 0x0600CEA0 RID: 52896 RVA: 0x002FDD24 File Offset: 0x002FBF24
		public void ClearTargets()
		{
			bool flag = this._targets != null;
			if (flag)
			{
				this._targets.Clear();
			}
		}

		// Token: 0x0600CEA1 RID: 52897 RVA: 0x002FDD4B File Offset: 0x002FBF4B
		public void AddTarget(XEntity target)
		{
			this.targets.Add(target);
		}

		// Token: 0x0600CEA2 RID: 52898 RVA: 0x002FDD5C File Offset: 0x002FBF5C
		public void SortTarget(Comparison<XEntity> comparison)
		{
			bool flag = this._targets != null;
			if (flag)
			{
				this._targets.Sort(comparison);
			}
		}

		// Token: 0x0600CEA3 RID: 52899 RVA: 0x002FDD84 File Offset: 0x002FBF84
		public XEntity GetTarget(int index)
		{
			return this.targets[index];
		}

		// Token: 0x0600CEA4 RID: 52900 RVA: 0x002FDDA2 File Offset: 0x002FBFA2
		public void Copy2Target(List<XEntity> lst)
		{
			this.targets.Clear();
			this.targets.AddRange(lst);
		}

		// Token: 0x1700361A RID: 13850
		// (get) Token: 0x0600CEA5 RID: 52901 RVA: 0x002FDDC0 File Offset: 0x002FBFC0
		// (set) Token: 0x0600CEA6 RID: 52902 RVA: 0x002FDDD8 File Offset: 0x002FBFD8
		public string ComboSkill
		{
			get
			{
				return this._combo_skill_name;
			}
			set
			{
				this._combo_skill_name = value;
			}
		}

		// Token: 0x1700361B RID: 13851
		// (get) Token: 0x0600CEA7 RID: 52903 RVA: 0x002FDDE4 File Offset: 0x002FBFE4
		public SharedData AIData
		{
			get
			{
				return (this._behavior_tree as AIRunTimeBehaviorTree).Data;
			}
		}

		// Token: 0x1700361C RID: 13852
		// (get) Token: 0x0600CEA8 RID: 52904 RVA: 0x002FDE08 File Offset: 0x002FC008
		public List<uint> TimerToken
		{
			get
			{
				bool flag = this._timer_token_list == null;
				if (flag)
				{
					this._timer_token_list = ListPool<uint>.Get();
				}
				return this._timer_token_list;
			}
		}

		// Token: 0x1700361D RID: 13853
		// (get) Token: 0x0600CEA9 RID: 52905 RVA: 0x002FDE38 File Offset: 0x002FC038
		// (set) Token: 0x0600CEAA RID: 52906 RVA: 0x002FDE40 File Offset: 0x002FC040
		public bool IgnoreSkillCD { get; set; }

		// Token: 0x1700361E RID: 13854
		// (get) Token: 0x0600CEAB RID: 52907 RVA: 0x002FDE4C File Offset: 0x002FC04C
		public XEntity Target
		{
			get
			{
				return this._target;
			}
		}

		// Token: 0x1700361F RID: 13855
		// (get) Token: 0x0600CEAC RID: 52908 RVA: 0x002FDE64 File Offset: 0x002FC064
		// (set) Token: 0x0600CEAD RID: 52909 RVA: 0x002FDE6C File Offset: 0x002FC06C
		public float LastCallMonsterTime { get; set; }

		// Token: 0x0600CEAE RID: 52910 RVA: 0x002FDE78 File Offset: 0x002FC078
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_AIAutoFight, new XComponent.XEventHandler(this.OnTickAI));
			base.RegisterEvent(XEventDefine.XEvent_AIStartSkill, new XComponent.XEventHandler(this.OnStartSkill));
			base.RegisterEvent(XEventDefine.XEvent_AIEndSkill, new XComponent.XEventHandler(this.OnEndSkill));
			base.RegisterEvent(XEventDefine.XEvent_AISkillHurt, new XComponent.XEventHandler(this.OnSkillHurt));
			base.RegisterEvent(XEventDefine.XEvent_AIEnterFight, new XComponent.XEventHandler(this.OnAIEnterFight));
			base.RegisterEvent(XEventDefine.XEvent_Enmity, new XComponent.XEventHandler(this.OnEnmity));
			base.RegisterEvent(XEventDefine.XEvent_OnEntityTransfer, new XComponent.XEventHandler(this.OnEntityTranser));
			base.RegisterEvent(XEventDefine.XEvent_ArmorBroken, new XComponent.XEventHandler(this.OnArmorBroken));
			base.RegisterEvent(XEventDefine.XEvent_WoozyOff, new XComponent.XEventHandler(this.OnWoozyArmorRecover));
			base.RegisterEvent(XEventDefine.XEvent_AIEvent, new XComponent.XEventHandler(this.OnProcessEvent));
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this.OnDeathEvent));
			base.RegisterEvent(XEventDefine.XEvent_EnableAI, new XComponent.XEventHandler(this.OnEnableAI));
		}

		// Token: 0x0600CEAF RID: 52911 RVA: 0x002FDF94 File Offset: 0x002FC194
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			bool flag = this._entity.Attributes == null;
			if (flag)
			{
				this._speed = 0f;
			}
			else
			{
				bool flag2 = this._entity.Attributes is XOthersAttributes;
				if (flag2)
				{
					XOthersAttributes xothersAttributes = this._entity.Attributes as XOthersAttributes;
					this._speed = xothersAttributes.RunSpeed;
				}
				else
				{
					XRoleAttributes xroleAttributes = this._entity.Attributes as XRoleAttributes;
					bool flag3 = xroleAttributes == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("_entity.Attributes Error!", null, null, null, null, null);
					}
					this._speed = xroleAttributes.RunSpeed;
				}
			}
			this.IgnoreSkillCD = false;
			this._spawn_time = Time.time;
			this.LastCallMonsterTime = 0f;
			this._enable_runtime_tree = XAIComponent.UseRunTime;
		}

		// Token: 0x0600CEB0 RID: 52912 RVA: 0x002FE070 File Offset: 0x002FC270
		public override void Attached()
		{
			this.InitNavPath();
			this.InitVariables();
			this.EnableBehaviorTree(this._enable_runtime_tree);
			bool is_inited = this._is_inited;
			if (is_inited)
			{
				this.SetFixVariables();
				this.InitOpponetEnmity();
			}
		}

		// Token: 0x0600CEB1 RID: 52913 RVA: 0x002FE0B4 File Offset: 0x002FC2B4
		public bool Active()
		{
			bool isPlayer = this._entity.IsPlayer;
			if (isPlayer)
			{
				bool flag = this._timer_token == 0U;
				if (flag)
				{
					bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_ARENA || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GODDESS;
					if (flag2)
					{
						(this._entity.Attributes as XPlayerAttributes).AutoPlayOn = true;
					}
					bool autoPlayOn = (this._entity.Attributes as XPlayerAttributes).AutoPlayOn;
					bool flag3 = autoPlayOn;
					if (flag3)
					{
						this.SetEnable(true, true);
					}
				}
			}
			else
			{
				this.SetEnable(true, true);
			}
			bool flag4 = XSingleton<XLevelSpawnMgr>.singleton.AIGlobal != null;
			if (flag4)
			{
				XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.SendAIMsg("ReadyFight", 0f, 0, 0);
			}
			return true;
		}

		// Token: 0x0600CEB2 RID: 52914 RVA: 0x002FE184 File Offset: 0x002FC384
		public void EnableBehaviorTree(bool isRunTime)
		{
			if (isRunTime)
			{
				this._behavior_tree = new AIRunTimeBehaviorTree();
				(this._behavior_tree as AIRunTimeBehaviorTree).Host = this._entity;
			}
			else
			{
				this._behavior_tree = (this._entity.EngineObject.AddComponent(EComponentType.EXBehaviorTree) as IXBehaviorTree);
			}
			bool isPlayer = this._entity.IsPlayer;
			if (isPlayer)
			{
				SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
				if (sceneType != SceneType.SCENE_PK)
				{
					if (sceneType != SceneType.SCENE_TOWER)
					{
						this.InitSubBehaviorTree(isRunTime, XSingleton<XGlobalConfig>.singleton.GetValue("PlayerAutoFight"));
					}
					else
					{
						this._behavior_tree.SetBehaviorTree("AutoFight_TeamTower");
					}
				}
				else
				{
					this.InitSubBehaviorTree(isRunTime, XSingleton<XGlobalConfig>.singleton.GetValue("ArenaPlayerServerAI"));
				}
				this._is_inited = true;
			}
			else
			{
				bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_ARENA;
				if (flag)
				{
					this.InitSubBehaviorTree(isRunTime, XSingleton<XGlobalConfig>.singleton.GetValue("ArenaClientAI"));
					this._is_inited = true;
				}
				else
				{
					XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
					bool flag2 = byID != null;
					if (flag2)
					{
						bool flag3 = string.IsNullOrEmpty(byID.AiBehavior);
						if (flag3)
						{
							this.InitSubBehaviorTree(isRunTime, "Monster_Empty");
							this._is_inited = false;
						}
						else
						{
							this.InitSubBehaviorTree(isRunTime, byID.AiBehavior);
							this._is_inited = true;
						}
					}
					else
					{
						this.InitSubBehaviorTree(isRunTime, "default");
					}
				}
			}
			bool flag4 = this._behavior_tree == null;
			if (!flag4)
			{
				this._behavior_tree.EnableBehaviorTree(true);
				this._behavior_tree.SetManual(true);
			}
		}

		// Token: 0x0600CEB3 RID: 52915 RVA: 0x002FE334 File Offset: 0x002FC534
		private void InitSubBehaviorTree(bool isRunTime, string treename)
		{
			string[] array = treename.Split(new char[]
			{
				':'
			});
			this._behavior_tree.SetBehaviorTree(array[0]);
			bool flag = this._child_trees == null;
			if (flag)
			{
				this._child_trees = DictionaryPool<uint, IXBehaviorTree>.Get();
			}
			for (int i = 1; i < array.Length; i++)
			{
				uint key = XSingleton<XCommon>.singleton.XHash(array[i]);
				IXBehaviorTree ixbehaviorTree;
				if (isRunTime)
				{
					AIRunTimeBehaviorTree airunTimeBehaviorTree = new AIRunTimeBehaviorTree();
					airunTimeBehaviorTree.Host = this._entity;
					this._child_trees[key] = airunTimeBehaviorTree;
					ixbehaviorTree = airunTimeBehaviorTree;
				}
				else
				{
					ixbehaviorTree = (this._entity.EngineObject.AddComponent(EComponentType.EXBehaviorTree) as IXBehaviorTree);
					this._child_trees[key] = ixbehaviorTree;
				}
				ixbehaviorTree.SetBehaviorTree(array[i]);
				ixbehaviorTree.EnableBehaviorTree(true);
				ixbehaviorTree.SetManual(true);
			}
		}

		// Token: 0x0600CEB4 RID: 52916 RVA: 0x002FE420 File Offset: 0x002FC620
		public void SetBehaviorTree(string tree)
		{
			bool flag = !string.IsNullOrEmpty(tree);
			if (flag)
			{
				this._is_inited = true;
			}
			bool enable_runtime_tree = this._enable_runtime_tree;
			if (enable_runtime_tree)
			{
				this._behavior_tree = new AIRunTimeBehaviorTree();
				(this._behavior_tree as AIRunTimeBehaviorTree).Host = this._entity;
			}
			else
			{
				this._behavior_tree = (this._entity.EngineObject.AddComponent(EComponentType.EXBehaviorTree) as IXBehaviorTree);
			}
			bool flag2 = this._behavior_tree != null;
			if (flag2)
			{
				this._behavior_tree.SetBehaviorTree(tree);
				this._behavior_tree.EnableBehaviorTree(true);
				this._behavior_tree.SetManual(true);
				this.AIFire(this._action_gap * this._action_gap_factor);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Add behavior error: ", tree, null, null, null, null);
			}
		}

		// Token: 0x0600CEB5 RID: 52917 RVA: 0x002FE4F4 File Offset: 0x002FC6F4
		public override void OnDetachFromHost()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timer_token);
			bool flag = this._can_cast_skill != null;
			if (flag)
			{
				ListPool<XSkillCore>.Release(this._can_cast_skill);
				this._can_cast_skill = null;
			}
			bool flag2 = this._range_skill != null;
			if (flag2)
			{
				ListPool<XSkillCore>.Release(this._range_skill);
				this._range_skill = null;
			}
			bool flag3 = this._timer_token_list != null;
			if (flag3)
			{
				ListPool<uint>.Release(this._timer_token_list);
				this._timer_token_list = null;
			}
			bool flag4 = this._link_skill_info != null;
			if (flag4)
			{
				DictionaryPool<uint, bool>.Release(this._link_skill_info);
				this._link_skill_info = null;
			}
			bool flag5 = this._child_trees != null;
			if (flag5)
			{
				DictionaryPool<uint, IXBehaviorTree>.Release(this._child_trees);
				this._child_trees = null;
			}
			bool flag6 = this._targets != null;
			if (flag6)
			{
				ListPool<XEntity>.Release(this._targets);
				this._targets = null;
			}
			this._Patrol.Destroy();
			base.OnDetachFromHost();
			this.ClearAllTimer();
		}

		// Token: 0x0600CEB6 RID: 52918 RVA: 0x002FE600 File Offset: 0x002FC800
		public void ClearAllTimer()
		{
			bool flag = this._timer_token_list != null;
			if (flag)
			{
				for (int i = 0; i < this._timer_token_list.Count; i++)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._timer_token_list[i]);
				}
				this._timer_token_list.Clear();
			}
		}

		// Token: 0x0600CEB7 RID: 52919 RVA: 0x002FE65C File Offset: 0x002FC85C
		protected virtual bool OnTickAI(XEventArgs e)
		{
			bool flag = !this._is_inited;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.CheckManualInput();
				if (flag2)
				{
					this.AIFire(this._action_gap * this._action_gap_factor);
					result = true;
				}
				else
				{
					bool flag3 = this._behavior_tree != null && e != null && (XEntity.ValideEntity(this._entity) || this._entity.Attributes == null);
					if (flag3)
					{
						this.UpdateVariable();
						this.SetTreeVariable(this._behavior_tree);
						this._behavior_tree.TickBehaviorTree();
						this._action_gap_factor = this._behavior_tree.OnGetHeartRate();
						bool flag4 = this._action_gap_factor == 0f;
						if (flag4)
						{
							this._action_gap_factor = 1f;
						}
						this.AIFire(this._action_gap * this._action_gap_factor);
					}
					else
					{
						this._action_gap_factor = 1f;
						this.AIFire(0.05f);
					}
					this._ai_event = null;
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600CEB8 RID: 52920 RVA: 0x002FE760 File Offset: 0x002FC960
		public void OnTickSubTree(string treeName)
		{
			IXBehaviorTree ixbehaviorTree = null;
			bool flag = this._child_trees != null && this._child_trees.TryGetValue(XSingleton<XCommon>.singleton.XHash(treeName), out ixbehaviorTree);
			if (flag)
			{
				this.SetTreeVariable(ixbehaviorTree);
				ixbehaviorTree.TickBehaviorTree();
			}
		}

		// Token: 0x0600CEB9 RID: 52921 RVA: 0x002FE7A8 File Offset: 0x002FC9A8
		public bool OnAIEnterFight(XEventArgs e)
		{
			bool is_fighting = this._is_fighting;
			bool result;
			if (is_fighting)
			{
				result = true;
			}
			else
			{
				XAIEnterFightEventArgs xaienterFightEventArgs = e as XAIEnterFightEventArgs;
				this._target = xaienterFightEventArgs.Target;
				this._is_fighting = true;
				this.SendEnterFightEvent();
				this.InitLinkSkill();
				this._enmity_list.AddInitHateValue(this._target);
				this._enmity_list.SetActive(true);
				this.NotifyAllyIntoFight(xaienterFightEventArgs.Target);
				XAIEventArgs @event = XEventPool<XAIEventArgs>.GetEvent();
				@event.DepracatedPass = true;
				@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
				@event.EventType = 1;
				@event.EventArg = "SpawnMonster";
				XSingleton<XEventMgr>.singleton.FireEvent(@event, 0.05f);
				bool is_fighting2 = this._is_fighting;
				if (is_fighting2)
				{
					XSingleton<XLevelStatistics>.singleton.OnAIinFight(this._entity);
				}
				bool flag = this._behavior_tree != null && XAIComponent.UseRunTime;
				if (flag)
				{
					this._behavior_tree.SetVariable("target", (this._target == null) ? null : this._target.EngineObject.Find(""));
					this._behavior_tree.SetVariable("target_distance", (this._entity.EngineObject.Position - this._target.EngineObject.Position).magnitude);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600CEBA RID: 52922 RVA: 0x002FE910 File Offset: 0x002FCB10
		private bool CheckManualInput()
		{
			return XSingleton<XVirtualTab>.singleton.Feeding && this._entity.IsPlayer;
		}

		// Token: 0x0600CEBB RID: 52923 RVA: 0x002FE93C File Offset: 0x002FCB3C
		private void UpdateVariable()
		{
			bool flag = this._target != null && XEntity.ValideEntity(this._target);
			if (flag)
			{
				this._target_distance = ((this._host as XEntity).EngineObject.Position - this._target.EngineObject.Position).magnitude;
				this._target_distance -= this._target.Radius;
				bool flag2 = this._target_distance < 0f;
				if (flag2)
				{
					this._target_distance = 0f;
				}
				Vector3 from = (this._host as XEntity).EngineObject.Position - this._target.EngineObject.Position;
				this._target_rotation = Mathf.Abs(XSingleton<XCommon>.singleton.AngleWithSign(from, this._target.EngineObject.Forward));
			}
			else
			{
				this._target_distance = 9999999f;
				this._target_rotation = 0f;
				this.targets.Clear();
				List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(this._entity);
				for (int i = 0; i < opponent.Count; i++)
				{
					bool flag3 = XEntity.ValideEntity(opponent[i]);
					if (flag3)
					{
						this.targets.Add(opponent[i]);
					}
				}
			}
			bool flag4 = XEntity.ValideEntity(XSingleton<XEntityMgr>.singleton.Player);
			if (flag4)
			{
				this._master_distance = ((this._host as XEntity).EngineObject.Position - XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position).magnitude;
			}
			bool flag5 = this._entity.Attributes != null;
			if (flag5)
			{
				this._max_hp = (float)this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
				this._current_hp = (float)this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Total);
				this._max_super_armor = (float)this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxSuperArmor_Total);
				this._current_super_armor = (float)this._entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentSuperArmor_Total);
			}
		}

		// Token: 0x0600CEBC RID: 52924 RVA: 0x002FEB80 File Offset: 0x002FCD80
		private void SetTreeVariable(IXBehaviorTree tree)
		{
			tree.SetXGameObjectByName("target", (this._target == null) ? null : this._target.EngineObject);
			tree.SetXGameObjectByName("master", (XSingleton<XEntityMgr>.singleton.Player == null) ? null : XSingleton<XEntityMgr>.singleton.Player.EngineObject);
			tree.SetTransformByName("navtarget", this._navtarget);
			tree.SetBoolByName("is_oppo_casting_skill", this._is_oppo_casting_skill);
			tree.SetBoolByName("is_hurt_oppo", this._is_hurt_oppo);
			tree.SetFloatByName("target_distance", this._target_distance);
			tree.SetFloatByName("master_distance", this._master_distance);
			tree.SetBoolByName("is_fixed_in_cd", this._is_fixed_in_cd);
			tree.SetFloatByName("normal_attack_prob", this._normal_attack_prob);
			tree.SetFloatByName("enter_fight_range", this._enter_fight_range);
			tree.SetFloatByName("fight_together_dis", this._fight_together_dis);
			tree.SetBoolByName("is_wander", this._is_wander);
			tree.SetFloatByName("max_hp", this._max_hp);
			tree.SetFloatByName("current_hp", this._current_hp);
			tree.SetFloatByName("max_super_armor", this._max_super_armor);
			tree.SetFloatByName("current_super_armor", this._current_super_armor);
			tree.SetIntByName("type", this._type);
			tree.SetFloatByName("target_rotation", this._target_rotation);
			tree.SetFloatByName("attack_range", this._attack_range);
			tree.SetFloatByName("min_keep_range", this._min_keep_range);
			tree.SetBoolByName("is_casting_skill", this._is_casting_skill);
			tree.SetBoolByName("is_fighting", this._is_fighting);
			tree.SetBoolByName("is_qte_state", this._is_qte_state);
			tree.SetVector3ByName("movedir", Vector3.zero);
			tree.SetVector3ByName("movedest", Vector3.zero);
			tree.SetFloatByName("movespeed", 1f);
			tree.SetVector3ByName("bornpos", this._born_pos);
		}

		// Token: 0x0600CEBD RID: 52925 RVA: 0x002FED9C File Offset: 0x002FCF9C
		public bool IsAtWoozyState()
		{
			return this._entity.Attributes.HasWoozyStatus && this._is_woozy_state;
		}

		// Token: 0x0600CEBE RID: 52926 RVA: 0x002FEDD4 File Offset: 0x002FCFD4
		public void SetTarget(XEntity entity)
		{
			bool flag = entity == null;
			if (flag)
			{
				this._target = null;
			}
			else
			{
				this._target = entity;
				bool flag2 = this._target != null && XEntity.ValideEntity(this._target);
				if (flag2)
				{
					this._target_distance = ((this._host as XEntity).EngineObject.Position - this._target.EngineObject.Position).magnitude;
					this._behavior_tree.SetFloatByName("target_distance", this._target_distance);
					this._behavior_tree.SetXGameObjectByName("target", this._target.EngineObject);
				}
			}
		}

		// Token: 0x0600CEBF RID: 52927 RVA: 0x002FEE88 File Offset: 0x002FD088
		private void InitNavPath()
		{
			XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
			this._Patrol.InitNavPath(byID);
		}

		// Token: 0x0600CEC0 RID: 52928 RVA: 0x002FEEBE File Offset: 0x002FD0BE
		public void SetNavTarget(int index)
		{
			this._navtarget = this._Patrol.GetFromNavPath(index);
			this._behavior_tree.SetTransformByName("navtarget", this._navtarget);
		}

		// Token: 0x0600CEC1 RID: 52929 RVA: 0x002FEEEC File Offset: 0x002FD0EC
		public bool RefreshNavTarget()
		{
			this.SetNavTarget(this._Patrol.PathIndex);
			return this._navtarget != null;
		}

		// Token: 0x0600CEC2 RID: 52930 RVA: 0x002FEF1C File Offset: 0x002FD11C
		private void InitLinkSkill()
		{
			bool flag = this._link_skill_info == null;
			if (flag)
			{
				this._link_skill_info = DictionaryPool<uint, bool>.Get();
			}
			this._link_skill_info.Clear();
			bool flag2 = this._entity.MobbedBy != null;
			if (flag2)
			{
				for (int i = 0; i < this._entity.SkillMgr.SkillOrder.Count; i++)
				{
					XSkillCore xskillCore = this._entity.SkillMgr.SkillOrder[i] as XSkillCore;
					bool flag3 = XSingleton<XSkillEffectMgr>.singleton.AICantCast(xskillCore.ID, xskillCore.Level, this._entity.SkillCasterTypeID);
					if (flag3)
					{
						this._link_skill_info[xskillCore.ID] = false;
					}
				}
			}
		}

		// Token: 0x0600CEC3 RID: 52931 RVA: 0x002FEFE8 File Offset: 0x002FD1E8
		public bool IsLinkSkillCannotCast(uint skillid)
		{
			return this._link_skill_info != null && this._link_skill_info.ContainsKey(skillid);
		}

		// Token: 0x0600CEC4 RID: 52932 RVA: 0x002FF014 File Offset: 0x002FD214
		public void InitVariables()
		{
			bool flag = this._entity.Attributes == null;
			if (!flag)
			{
				this._born_pos = this._entity.EngineObject.Position;
				bool flag2 = this._entity.Attributes is XOthersAttributes;
				if (flag2)
				{
					XOthersAttributes xothersAttributes = this._entity.Attributes as XOthersAttributes;
					XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
					this._speed = xothersAttributes.RunSpeed;
					this._normal_attack_prob = xothersAttributes.NormalAttackProb;
					this._enter_fight_range = xothersAttributes.EnterFightRange;
					this._is_wander = xothersAttributes.IsWander;
					this._action_gap = xothersAttributes.AIActionGap;
					this._ai_start_time = xothersAttributes.AIStartTime;
					this._is_fixed_in_cd = xothersAttributes.IsFixedInCD;
					bool flag3 = byID != null;
					if (flag3)
					{
						this._fight_together_dis = byID.FightTogetherDis;
					}
					this._type = (int)xothersAttributes.Type;
				}
				else
				{
					XRoleAttributes xroleAttributes = this._entity.Attributes as XRoleAttributes;
					bool flag4 = xroleAttributes == null;
					if (flag4)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("_entity.Attributes Error!", null, null, null, null, null);
					}
					this._speed = xroleAttributes.RunSpeed;
					this._normal_attack_prob = 1f;
					this._enter_fight_range = 20f;
					this._is_wander = false;
					this._action_gap = 1.5f;
					this._ai_start_time = 1.5f;
					this._is_fixed_in_cd = false;
					this._type = (int)xroleAttributes.Type;
				}
				XSkillCore xskillCore = (this._entity.SkillMgr == null) ? null : this._entity.SkillMgr.GetPhysicalSkill();
				bool flag5 = xskillCore != null;
				if (flag5)
				{
					this._attack_range = xskillCore.CastRangeUpper;
					this._min_keep_range = xskillCore.CastRangeLower;
				}
				else
				{
					this._attack_range = 0f;
					this._min_keep_range = 0f;
				}
				bool isPlayer = this._entity.IsPlayer;
				if (isPlayer)
				{
					List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(this._entity);
					for (int i = 0; i < opponent.Count; i++)
					{
						bool flag6 = opponent[i].AI != null;
						if (flag6)
						{
							opponent[i].IsServerFighting = true;
						}
					}
				}
			}
		}

		// Token: 0x0600CEC5 RID: 52933 RVA: 0x002FF268 File Offset: 0x002FD468
		public void SetFixVariables()
		{
			bool flag = this._behavior_tree == null;
			if (!flag)
			{
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
				bool flag2 = byID != null;
				if (flag2)
				{
					this._behavior_tree.SetFloatByName("ratioleft", byID.ratioleft);
					this._behavior_tree.SetFloatByName("ratioright", byID.ratioright);
					this._behavior_tree.SetFloatByName("ratioidle", byID.ratioidle);
					this._behavior_tree.SetFloatByName("ratiodistance", byID.ratiodistance);
					this._behavior_tree.SetFloatByName("ratioskill", byID.ratioskill);
					this._behavior_tree.SetFloatByName("ratioexp", byID.ratioexp);
				}
			}
		}

		// Token: 0x0600CEC6 RID: 52934 RVA: 0x002FF33C File Offset: 0x002FD53C
		public void NotifyAllyIntoFight(XEntity target)
		{
			List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly(this._entity);
			for (int i = 0; i < ally.Count; i++)
			{
				bool flag = !XEntity.ValideEntity(ally[i]);
				if (!flag)
				{
					bool flag2 = XSingleton<XCommon>.singleton.IsGreater((ally[i].EngineObject.Position - this._entity.EngineObject.Position).magnitude, this.FightTogetherDis);
					if (!flag2)
					{
						XAIEnterFightEventArgs @event = XEventPool<XAIEnterFightEventArgs>.GetEvent();
						@event.Firer = ally[i];
						@event.Target = target;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
				}
			}
		}

		// Token: 0x0600CEC7 RID: 52935 RVA: 0x002FF400 File Offset: 0x002FD600
		protected void AIFire(float time)
		{
			bool flag = this._timer_token > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer_token);
				this._timer_token = 0U;
			}
			XAIAutoFightEventArgs @event = XEventPool<XAIAutoFightEventArgs>.GetEvent();
			@event.Firer = this._host;
			this._timer_token = XSingleton<XEventMgr>.singleton.FireEvent(@event, time);
		}

		// Token: 0x0600CEC8 RID: 52936 RVA: 0x002FF45C File Offset: 0x002FD65C
		public bool OnWoozyArmorRecover(XEventArgs e)
		{
			this.AIFire(this._action_gap * this._action_gap_factor);
			this._is_woozy_state = false;
			return true;
		}

		// Token: 0x0600CEC9 RID: 52937 RVA: 0x002FF48C File Offset: 0x002FD68C
		public bool OnArmorBroken(XEventArgs e)
		{
			bool hasWoozyStatus = this._entity.Attributes.HasWoozyStatus;
			if (hasWoozyStatus)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer_token);
				this._timer_token = 0U;
				this._is_woozy_state = true;
				XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.SendAIMsg("ArmorBroken", 0f, 0, 0);
			}
			return true;
		}

		// Token: 0x0600CECA RID: 52938 RVA: 0x002FF4F0 File Offset: 0x002FD6F0
		private bool OnProcessEvent(XEventArgs e)
		{
			XAIEventArgs ai_event = e as XAIEventArgs;
			this._ai_event = ai_event;
			bool flag = this._timer_token > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer_token);
				this._timer_token = 0U;
				XAIAutoFightEventArgs @event = XEventPool<XAIAutoFightEventArgs>.GetEvent();
				@event.Firer = base.Host;
				this.OnTickAI(@event);
				@event.Recycle();
			}
			return true;
		}

		// Token: 0x0600CECB RID: 52939 RVA: 0x002FF55C File Offset: 0x002FD75C
		private bool OnEnableAI(XEventArgs e)
		{
			XAIEnableAI xaienableAI = e as XAIEnableAI;
			bool flag = !xaienableAI.Enable;
			if (flag)
			{
				this._disable_count++;
				this.SetEnable(false, xaienableAI.Puppet);
			}
			else
			{
				this._disable_count--;
				bool flag2 = this._disable_count <= 0;
				if (flag2)
				{
					bool flag3 = this._entity.IsPlayer && (this._entity.Attributes as XPlayerAttributes).AutoPlayOn;
					if (flag3)
					{
						this.SetEnable(true, true);
					}
					bool flag4 = !this._entity.IsPlayer;
					if (flag4)
					{
						this.SetEnable(true, true);
					}
				}
				bool flag5 = this._disable_count < 0;
				if (flag5)
				{
					this._disable_count = 0;
				}
			}
			return true;
		}

		// Token: 0x0600CECC RID: 52940 RVA: 0x002FF630 File Offset: 0x002FD830
		private bool OnDeathEvent(XEventArgs e)
		{
			XSecurityAIInfo xsecurityAIInfo = XSecurityAIInfo.TryGetStatistics(this._entity);
			bool flag = xsecurityAIInfo != null;
			if (flag)
			{
				bool flag2 = !this._entity.IsPlayer && !this._entity.IsRole;
				if (flag2)
				{
					xsecurityAIInfo.SetLifeTime(Time.time - this._spawn_time);
				}
			}
			bool flag3 = XSingleton<XLevelSpawnMgr>.singleton.AIGlobal != null;
			if (flag3)
			{
				XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.SendAIMsg("Dead", 0.1f, (int)this._entity.TypeID, 0);
			}
			return true;
		}

		// Token: 0x0600CECD RID: 52941 RVA: 0x002FF6CC File Offset: 0x002FD8CC
		private XSkillCore GetDashSkill()
		{
			XEntity xentity = this._host as XEntity;
			bool flag = xentity == null;
			XSkillCore result;
			if (flag)
			{
				result = null;
			}
			else
			{
				uint dashIdentity = xentity.SkillMgr.GetDashIdentity();
				bool flag2 = dashIdentity == 0U;
				if (flag2)
				{
					result = null;
				}
				else
				{
					XSkillCore skill = xentity.SkillMgr.GetSkill(dashIdentity);
					bool flag3 = skill != null;
					if (flag3)
					{
						result = skill;
					}
					else
					{
						result = null;
					}
				}
			}
			return result;
		}

		// Token: 0x0600CECE RID: 52942 RVA: 0x002FF734 File Offset: 0x002FD934
		private bool OnStartSkill(XEventArgs e)
		{
			XAIStartSkillEventArgs xaistartSkillEventArgs = e as XAIStartSkillEventArgs;
			bool isCaster = xaistartSkillEventArgs.IsCaster;
			if (isCaster)
			{
				bool flag = this.GetDashSkill() == null || this.GetDashSkill().ID != xaistartSkillEventArgs.SkillId;
				if (flag)
				{
					this._is_hurt_oppo = false;
					this._is_casting_skill = true;
					this._cast_skillid = xaistartSkillEventArgs.SkillId;
					bool flag2 = this._behavior_tree != null;
					if (flag2)
					{
						this._behavior_tree.SetIntByName("skillid", (int)this._cast_skillid);
					}
				}
			}
			else
			{
				this._is_oppo_casting_skill = true;
			}
			return true;
		}

		// Token: 0x0600CECF RID: 52943 RVA: 0x002FF7D4 File Offset: 0x002FD9D4
		private bool OnEndSkill(XEventArgs e)
		{
			XAIEndSkillEventArgs xaiendSkillEventArgs = e as XAIEndSkillEventArgs;
			bool isCaster = xaiendSkillEventArgs.IsCaster;
			if (isCaster)
			{
				bool flag = this.GetDashSkill() == null || this.GetDashSkill().ID != xaiendSkillEventArgs.SkillId;
				if (flag)
				{
					this._is_casting_skill = false;
					this._cast_skillid = 0U;
					this._is_hurt_oppo = false;
				}
			}
			else
			{
				this._is_oppo_casting_skill = false;
			}
			return true;
		}

		// Token: 0x0600CED0 RID: 52944 RVA: 0x002FF848 File Offset: 0x002FDA48
		private bool OnSkillHurt(XEventArgs e)
		{
			XAISkillHurtEventArgs xaiskillHurtEventArgs = e as XAISkillHurtEventArgs;
			bool isCaster = xaiskillHurtEventArgs.IsCaster;
			if (isCaster)
			{
				this._is_hurt_oppo = true;
			}
			return true;
		}

		// Token: 0x0600CED1 RID: 52945 RVA: 0x002FF874 File Offset: 0x002FDA74
		private bool OnEnmity(XEventArgs e)
		{
			XEnmityEventArgs xenmityEventArgs = e as XEnmityEventArgs;
			bool flag = xenmityEventArgs == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !this._enmity_list.IsActive;
				if (flag2)
				{
					this._enmity_list.SetActive(true);
				}
				XEntity xentity = xenmityEventArgs.Starter as XEntity;
				bool flag3 = xentity != null;
				if (flag3)
				{
					uint skillLevel = xentity.Attributes.SkillLevelInfo.GetSkillLevel(xenmityEventArgs.SkillId);
					SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(xenmityEventArgs.SkillId, skillLevel);
					bool flag4 = skillConfig != null;
					if (flag4)
					{
						this._enmity_list.AddHateValue(xentity, (float)(xenmityEventArgs.DeltaValue * (double)skillConfig.EnmityRatio + (double)skillConfig.EnmityExtValue));
					}
					else
					{
						this._enmity_list.AddHateValue(xentity, (float)xenmityEventArgs.DeltaValue);
					}
					bool flag5 = !this._is_fighting;
					if (flag5)
					{
						this._is_fighting = true;
						this.SendEnterFightEvent();
						this.NotifyAllyIntoFight(xentity);
					}
				}
				result = true;
			}
			return result;
		}

		public bool OnEntityTranser(XEventArgs e)
		{
			XOnEntityTransferEventArgs transferEventArgs = e as XOnEntityTransferEventArgs;
			if (!this._entity.IsPlayer)
				this._entity.EngineObject.Position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position + new Vector3(0.5f, 0.0f, 0.0f);
			++this._Patrol.PathIndex;
			return true;
		}

		// Token: 0x0600CED3 RID: 52947 RVA: 0x002FF9FC File Offset: 0x002FDBFC
		private void SetEnable(bool enable, bool puppet = true)
		{
			this.SendAutoFightMsg(enable);
			this.ResetAIData();
			if (enable)
			{
				bool flag = this._timer_token > 0U;
				if (flag)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._timer_token);
					this._timer_token = 0U;
				}
				this.OnTickAI(null);
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer_token);
				this._timer_token = 0U;
				if (puppet)
				{
					XSingleton<XEntityMgr>.singleton.Idled(this._entity);
					bool flag2 = this._entity.Nav != null;
					if (flag2)
					{
						this._entity.Nav.Interrupt();
					}
				}
				else
				{
					bool flag3 = this._entity.Skill != null && this._entity.Skill.IsCasting();
					if (!flag3)
					{
						bool flag4 = this._entity.Machine != null && this._entity.Machine.Current == XStateDefine.XState_Move;
						if (flag4)
						{
							this._entity.Net.ReportMoveAction(Vector3.zero, 0.0);
						}
					}
				}
			}
		}

		// Token: 0x0600CED4 RID: 52948 RVA: 0x002FFB20 File Offset: 0x002FDD20
		private void ResetAIData()
		{
			this._target = null;
			bool flag = this._behavior_tree != null && this._is_inited;
			if (flag)
			{
				this._behavior_tree.SetXGameObjectByName("target", null);
				this._behavior_tree.SetTransformByName("BuffTarget", null);
				this._behavior_tree.SetTransformByName("ItemTarget", null);
				this._behavior_tree.SetFloatByName("target_distance", 99999f);
			}
		}

		// Token: 0x0600CED5 RID: 52949 RVA: 0x002FFB98 File Offset: 0x002FDD98
		private void SendEnterFightEvent()
		{
			XAIEventArgs @event = XEventPool<XAIEventArgs>.GetEvent();
			@event.DepracatedPass = false;
			@event.Firer = this._host;
			@event.EventType = 1;
			@event.EventArg = "enterfight";
			float delay = 1f;
			XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
			bool flag = byID != null;
			if (flag)
			{
				delay = byID.AIStartTime;
			}
			XSingleton<XEventMgr>.singleton.FireEvent(@event, delay);
		}

		// Token: 0x0600CED6 RID: 52950 RVA: 0x002FFC10 File Offset: 0x002FDE10
		private void InitOpponetEnmity()
		{
			List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(this._entity);
			for (int i = 0; i < opponent.Count; i++)
			{
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(opponent[i].Attributes.TypeID);
				bool flag = byID != null && byID.InitEnmity > 0;
				if (flag)
				{
					this._enmity_list.AddHateValue(opponent[i], (float)byID.InitEnmity);
				}
			}
		}

		// Token: 0x0600CED7 RID: 52951 RVA: 0x002FFC98 File Offset: 0x002FDE98
		private void SendAutoFightMsg(bool enable)
		{
			bool flag = !this._entity.IsPlayer;
			if (!flag)
			{
				PtcC2G_AutoFightNTF ptcC2G_AutoFightNTF = new PtcC2G_AutoFightNTF();
				ptcC2G_AutoFightNTF.Data.autof = enable;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_AutoFightNTF);
			}
		}

		// Token: 0x0600CED8 RID: 52952 RVA: 0x002FFCD9 File Offset: 0x002FDED9
		public override void OnReconnect(UnitAppearance data)
		{
			base.OnReconnect(data);
			this.SetEnable(XSingleton<XReconnection>.singleton.IsAutoFight, true);
		}

		// Token: 0x04005C1D RID: 23581
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XAIComponent");

		// Token: 0x04005C1E RID: 23582
		public static bool UseRunTime = true;

		// Token: 0x04005C1F RID: 23583
		private XRole _opponent = null;

		// Token: 0x04005C20 RID: 23584
		private uint _timer_token = 0U;

		// Token: 0x04005C21 RID: 23585
		private float _speed = 0f;

		// Token: 0x04005C22 RID: 23586
		private uint _cast_skillid = 0U;

		// Token: 0x04005C23 RID: 23587
		private float _action_gap = 1f;

		// Token: 0x04005C24 RID: 23588
		private float _action_gap_factor = 0.5f;

		// Token: 0x04005C25 RID: 23589
		private float _ai_start_time = 0.1f;

		// Token: 0x04005C26 RID: 23590
		private Vector3 _born_pos = Vector3.zero;

		// Token: 0x04005C27 RID: 23591
		private int _huanraoindex = 0;

		// Token: 0x04005C28 RID: 23592
		private bool _is_woozy_state = false;

		// Token: 0x04005C29 RID: 23593
		private XAIEventArgs _ai_event = null;

		// Token: 0x04005C2A RID: 23594
		private bool _is_inited = false;

		// Token: 0x04005C2B RID: 23595
		private int _disable_count = 0;

		// Token: 0x04005C2C RID: 23596
		private List<XSkillCore> _range_skill = null;

		// Token: 0x04005C2D RID: 23597
		private XEnmityList _enmity_list = new XEnmityList();

		// Token: 0x04005C2E RID: 23598
		private string _combo_skill_name;

		// Token: 0x04005C2F RID: 23599
		private List<uint> _timer_token_list = null;

		// Token: 0x04005C30 RID: 23600
		private float _spawn_time = 0f;

		// Token: 0x04005C31 RID: 23601
		private List<XSkillCore> _can_cast_skill = null;

		// Token: 0x04005C32 RID: 23602
		private List<XEntity> _targets = null;

		// Token: 0x04005C33 RID: 23603
		private Dictionary<uint, IXBehaviorTree> _child_trees = null;

		// Token: 0x04005C34 RID: 23604
		private XEntity _target = null;

		// Token: 0x04005C35 RID: 23605
		private Transform _navtarget = null;

		// Token: 0x04005C36 RID: 23606
		private bool _is_oppo_casting_skill = false;

		// Token: 0x04005C37 RID: 23607
		private bool _is_hurt_oppo = false;

		// Token: 0x04005C38 RID: 23608
		private float _target_distance = 0f;

		// Token: 0x04005C39 RID: 23609
		private float _master_distance = 9999f;

		// Token: 0x04005C3A RID: 23610
		private bool _is_fixed_in_cd = false;

		// Token: 0x04005C3B RID: 23611
		private float _normal_attack_prob = 0.5f;

		// Token: 0x04005C3C RID: 23612
		private float _enter_fight_range = 10f;

		// Token: 0x04005C3D RID: 23613
		private float _fight_together_dis = 10f;

		// Token: 0x04005C3E RID: 23614
		private bool _is_wander = false;

		// Token: 0x04005C3F RID: 23615
		private float _max_hp = 1000f;

		// Token: 0x04005C40 RID: 23616
		private float _current_hp = 0f;

		// Token: 0x04005C41 RID: 23617
		private float _max_super_armor = 100f;

		// Token: 0x04005C42 RID: 23618
		private float _current_super_armor = 50f;

		// Token: 0x04005C43 RID: 23619
		private int _type = 1;

		// Token: 0x04005C44 RID: 23620
		private float _target_rotation = 0f;

		// Token: 0x04005C45 RID: 23621
		private float _attack_range = 1f;

		// Token: 0x04005C46 RID: 23622
		private float _min_keep_range = 1f;

		// Token: 0x04005C47 RID: 23623
		private bool _is_casting_skill = false;

		// Token: 0x04005C48 RID: 23624
		private bool _is_fighting = false;

		// Token: 0x04005C49 RID: 23625
		private bool _is_qte_state = false;

		// Token: 0x04005C4A RID: 23626
		private Dictionary<uint, bool> _link_skill_info = null;

		// Token: 0x04005C4B RID: 23627
		private XPatrol _Patrol = new XPatrol();

		// Token: 0x04005C4C RID: 23628
		private IXBehaviorTree _behavior_tree = null;

		// Token: 0x04005C4D RID: 23629
		private bool _enable_runtime_tree = true;
	}
}
