using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAIComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XAIComponent.uuID;
			}
		}

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

		public float MoveSpeed
		{
			get
			{
				return this._entity.Attributes.RunSpeed;
			}
		}

		public Vector3 BornPos
		{
			get
			{
				return this._born_pos;
			}
		}

		public float AttackRange
		{
			get
			{
				return this._attack_range;
			}
		}

		public float MinKeepRange
		{
			get
			{
				return this._min_keep_range;
			}
		}

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

		public float AttackProb
		{
			get
			{
				return this._normal_attack_prob;
			}
		}

		public float EnterFightRange
		{
			get
			{
				return this._enter_fight_range;
			}
		}

		public float FightTogetherDis
		{
			get
			{
				return this._fight_together_dis;
			}
		}

		public bool IsCastingSkill
		{
			get
			{
				return this._is_casting_skill;
			}
		}

		public bool IsOppoCastingSkill
		{
			get
			{
				return this._is_oppo_casting_skill;
			}
		}

		public bool IsFixedInCd
		{
			get
			{
				return this._is_fixed_in_cd;
			}
		}

		public bool IsWander
		{
			get
			{
				return this._is_wander;
			}
		}

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

		public XEnmityList EnmityList
		{
			get
			{
				return this._enmity_list;
			}
		}

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

		public XPatrol Patrol
		{
			get
			{
				return this._Patrol;
			}
		}

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

		public int CanCastSkillCount
		{
			get
			{
				return (this._can_cast_skill == null) ? 0 : this._can_cast_skill.Count;
			}
		}

		public void Copy2CanCastSkill(List<XSkillCore> lst)
		{
			this.CanCastSkill.Clear();
			this.CanCastSkill.AddRange(lst);
		}

		public void ClearCanCastSkill()
		{
			bool flag = this._can_cast_skill != null;
			if (flag)
			{
				this._can_cast_skill.Clear();
			}
		}

		public void AddCanCastSkill(XSkillCore skill)
		{
			this.CanCastSkill.Add(skill);
		}

		public XSkillCore GetCanCastSkill(int index)
		{
			return this.CanCastSkill[index];
		}

		public void RemoveCanCastSkillAt(int index)
		{
			bool flag = this._can_cast_skill != null;
			if (flag)
			{
				this._can_cast_skill.RemoveAt(index);
			}
		}

		public void RemoveCanCastSkillRange(int index, int count)
		{
			bool flag = this._can_cast_skill != null;
			if (flag)
			{
				this._can_cast_skill.RemoveRange(index, count);
			}
		}

		public int RangeSkillCount
		{
			get
			{
				return (this._range_skill == null) ? 0 : this._range_skill.Count;
			}
		}

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

		public void AddRangeSkill(XSkillCore skill)
		{
			this.RangeSkill.Add(skill);
		}

		public void CopyRange2CanCast()
		{
			this.CanCastSkill.Clear();
			bool flag = this._range_skill != null;
			if (flag)
			{
				this.CanCastSkill.AddRange(this._range_skill);
			}
		}

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

		public int TargetsCount
		{
			get
			{
				return (this._targets == null) ? 0 : this._targets.Count;
			}
		}

		public void ClearTargets()
		{
			bool flag = this._targets != null;
			if (flag)
			{
				this._targets.Clear();
			}
		}

		public void AddTarget(XEntity target)
		{
			this.targets.Add(target);
		}

		public void SortTarget(Comparison<XEntity> comparison)
		{
			bool flag = this._targets != null;
			if (flag)
			{
				this._targets.Sort(comparison);
			}
		}

		public XEntity GetTarget(int index)
		{
			return this.targets[index];
		}

		public void Copy2Target(List<XEntity> lst)
		{
			this.targets.Clear();
			this.targets.AddRange(lst);
		}

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

		public SharedData AIData
		{
			get
			{
				return (this._behavior_tree as AIRunTimeBehaviorTree).Data;
			}
		}

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

		public bool IgnoreSkillCD { get; set; }

		public XEntity Target
		{
			get
			{
				return this._target;
			}
		}

		public float LastCallMonsterTime { get; set; }

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

		private bool CheckManualInput()
		{
			return XSingleton<XVirtualTab>.singleton.Feeding && this._entity.IsPlayer;
		}

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

		public bool IsAtWoozyState()
		{
			return this._entity.Attributes.HasWoozyStatus && this._is_woozy_state;
		}

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

		private void InitNavPath()
		{
			XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._entity.TypeID);
			this._Patrol.InitNavPath(byID);
		}

		public void SetNavTarget(int index)
		{
			this._navtarget = this._Patrol.GetFromNavPath(index);
			this._behavior_tree.SetTransformByName("navtarget", this._navtarget);
		}

		public bool RefreshNavTarget()
		{
			this.SetNavTarget(this._Patrol.PathIndex);
			return this._navtarget != null;
		}

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

		public bool IsLinkSkillCannotCast(uint skillid)
		{
			return this._link_skill_info != null && this._link_skill_info.ContainsKey(skillid);
		}

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

		public bool OnWoozyArmorRecover(XEventArgs e)
		{
			this.AIFire(this._action_gap * this._action_gap_factor);
			this._is_woozy_state = false;
			return true;
		}

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

		public override void OnReconnect(UnitAppearance data)
		{
			base.OnReconnect(data);
			this.SetEnable(XSingleton<XReconnection>.singleton.IsAutoFight, true);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XAIComponent");

		public static bool UseRunTime = true;

		private XRole _opponent = null;

		private uint _timer_token = 0U;

		private float _speed = 0f;

		private uint _cast_skillid = 0U;

		private float _action_gap = 1f;

		private float _action_gap_factor = 0.5f;

		private float _ai_start_time = 0.1f;

		private Vector3 _born_pos = Vector3.zero;

		private int _huanraoindex = 0;

		private bool _is_woozy_state = false;

		private XAIEventArgs _ai_event = null;

		private bool _is_inited = false;

		private int _disable_count = 0;

		private List<XSkillCore> _range_skill = null;

		private XEnmityList _enmity_list = new XEnmityList();

		private string _combo_skill_name;

		private List<uint> _timer_token_list = null;

		private float _spawn_time = 0f;

		private List<XSkillCore> _can_cast_skill = null;

		private List<XEntity> _targets = null;

		private Dictionary<uint, IXBehaviorTree> _child_trees = null;

		private XEntity _target = null;

		private Transform _navtarget = null;

		private bool _is_oppo_casting_skill = false;

		private bool _is_hurt_oppo = false;

		private float _target_distance = 0f;

		private float _master_distance = 9999f;

		private bool _is_fixed_in_cd = false;

		private float _normal_attack_prob = 0.5f;

		private float _enter_fight_range = 10f;

		private float _fight_together_dis = 10f;

		private bool _is_wander = false;

		private float _max_hp = 1000f;

		private float _current_hp = 0f;

		private float _max_super_armor = 100f;

		private float _current_super_armor = 50f;

		private int _type = 1;

		private float _target_rotation = 0f;

		private float _attack_range = 1f;

		private float _min_keep_range = 1f;

		private bool _is_casting_skill = false;

		private bool _is_fighting = false;

		private bool _is_qte_state = false;

		private Dictionary<uint, bool> _link_skill_info = null;

		private XPatrol _Patrol = new XPatrol();

		private IXBehaviorTree _behavior_tree = null;

		private bool _enable_runtime_tree = true;
	}
}
