using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XEntity : XObject
	{

		public bool IsVisible
		{
			get
			{
				return this._isVisible;
			}
		}

		public XMount Mount
		{
			get
			{
				return this._mount;
			}
		}

		public List<XAffiliate> Affiliates
		{
			get
			{
				return this._affiliates;
			}
		}

		public XNavigationComponent Nav
		{
			get
			{
				return this._nav;
			}
			set
			{
				this._nav = value;
			}
		}

		public virtual XAttributes Attributes
		{
			get
			{
				return this._attr;
			}
		}

		public XStateMachine Machine
		{
			get
			{
				return this._machine;
			}
		}

		public XSkillComponent Skill
		{
			get
			{
				return this._skill;
			}
		}

		public XPresentComponent Present
		{
			get
			{
				return this._present;
			}
		}

		public XBuffComponent Buffs
		{
			get
			{
				return this._buff;
			}
		}

		public XNetComponent Net
		{
			get
			{
				return this._net;
			}
		}

		public XRotationComponent Rotate
		{
			get
			{
				return this._rotate;
			}
		}

		public XSkillMgr SkillMgr
		{
			get
			{
				return (this.Skill != null) ? this.Skill.SkillMgr : null;
			}
		}

		public XBeHitComponent BeHit
		{
			get
			{
				return this._behit;
			}
		}

		public XDeathComponent Death
		{
			get
			{
				return this._death;
			}
		}

		public XEquipComponent Equipment
		{
			get
			{
				return this._equip;
			}
		}

		public XFlyComponent Fly
		{
			get
			{
				return this._fly;
			}
		}

		public XQuickTimeEventComponent QTE
		{
			get
			{
				return this._qte;
			}
		}

		public XRenderComponent Renderer
		{
			get
			{
				return this._render;
			}
			set
			{
				this._render = value;
			}
		}

		public XAudioComponent Audio
		{
			get
			{
				return this._audio;
			}
		}

		public XBillboardComponent BillBoard
		{
			get
			{
				return this._billboard;
			}
			set
			{
				this._billboard = value;
			}
		}

		public XAIComponent AI
		{
			get
			{
				return this._ai;
			}
			set
			{
				this._ai = value;
			}
		}

		public uint ServerSpecialState
		{
			get
			{
				return this._server_special_state;
			}
			set
			{
				this._server_special_state = value;
			}
		}

		public virtual bool IsFighting
		{
			get
			{
				bool flag = this._ai != null;
				return flag && this._ai.IsFighting;
			}
		}

		public virtual bool HasAI
		{
			get
			{
				return this._ai != null;
			}
		}

		public bool CanSelected { get; set; }

		public bool IsPassive
		{
			get
			{
				return this._passive;
			}
			set
			{
				this._passive = value;
			}
		}

		public bool IsClientPredicted
		{
			get
			{
				return this._client_predicted && !this._passive;
			}
		}

		public bool IsNavigating
		{
			get
			{
				return this._nav != null && this._nav.IsOnNav;
			}
		}

		public bool IsServerFighting
		{
			get
			{
				return this._server_fighting;
			}
			set
			{
				this._server_fighting = value;
			}
		}

		public bool IsDisappear
		{
			get
			{
				return this._bDisappear;
			}
			set
			{
				this._bDisappear = value;
			}
		}

		public bool IsTransform
		{
			get
			{
				return XEntity.ValideEntity(this._transformer);
			}
		}

		public XEntity Transformer
		{
			get
			{
				return this._transformer;
			}
		}

		public XEntity Transformee
		{
			get
			{
				return this._transformee;
			}
		}

		public XEntity RealEntity
		{
			get
			{
				return this.IsTransform ? this._transformer : this;
			}
		}

		public bool CachedSpecialStateFromServer
		{
			get
			{
				return this._last_special_state_from_server > 0UL;
			}
		}

		public float Height
		{
			get
			{
				return this._height;
			}
		}

		public float Radius
		{
			get
			{
				return this._radius;
			}
		}

		public Vector3 RadiusCenter
		{
			get
			{
				return this._xobject.Position + this._xobject.Rotation * (this._present.RadiusOffset * this._scale);
			}
		}

		public Vector3 HugeMonsterColliderCenter(int idx)
		{
			SeqListRef<float> hugeMonsterColliders = this.Present.PresentLib.HugeMonsterColliders;
			return this.EngineObject.Position + this.EngineObject.Rotation * (new Vector3(hugeMonsterColliders[idx, 0], 0f, hugeMonsterColliders[idx, 1]) * this._scale);
		}

		public XAnimator Ator
		{
			get
			{
				return this.IsTransform ? this._transformer.Ator : ((this._xobject != null) ? this._xobject.Ator : null);
			}
		}

		public int DefaultLayer
		{
			get
			{
				return this._layer;
			}
		}

		public bool StandOn
		{
			get
			{
				return this._bStandOn;
			}
		}

		public bool IsMounted
		{
			get
			{
				return this._mount != null;
			}
		}

		public bool IsCopilotMounted
		{
			get
			{
				return this.IsMounted && this._is_mount_copilot;
			}
		}

		public bool GravityDisabled
		{
			get
			{
				return this._gravity_disabled;
			}
		}

		public void DisableGravity()
		{
			this._gravity_disabled = true;
		}

		public int EntityType
		{
			get
			{
				return XFastEnumIntEqualityComparer<XEntity.EnitityType>.ToInt(this._eEntity_Type);
			}
		}

		public bool IsPlayer
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Player) > (XEntity.EnitityType)0;
			}
		}

		public bool IsRole
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Role) > (XEntity.EnitityType)0;
			}
		}

		public bool IsOpposer
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Opposer) > (XEntity.EnitityType)0;
			}
		}

		public bool IsEnemy
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Enemy) > (XEntity.EnitityType)0;
			}
		}

		public bool IsPuppet
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Puppet) > (XEntity.EnitityType)0;
			}
		}

		public bool IsBoss
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Boss) > (XEntity.EnitityType)0;
			}
		}

		public bool IsElite
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Elite) > (XEntity.EnitityType)0;
			}
		}

		public bool IsNpc
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Npc) > (XEntity.EnitityType)0;
			}
		}

		public bool IsDummy
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Dummy) > (XEntity.EnitityType)0;
			}
		}

		public bool IsSubstance
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Substance) > (XEntity.EnitityType)0;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Empty) > (XEntity.EnitityType)0;
			}
		}

		public bool IsAffiliate
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Affiliate) > (XEntity.EnitityType)0;
			}
		}

		public bool IsMountee
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Mount) > (XEntity.EnitityType)0;
			}
		}

		public bool IsMainViewEntity
		{
			get
			{
				return this.IsPlayer || (XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.WatchTo == this);
			}
		}

		public static bool IsSameType(XEntity lhs, XEntity rhs)
		{
			return lhs._eEntity_Type == rhs._eEntity_Type;
		}

		public bool IsDead
		{
			get
			{
				return this._attr == null || this._attr.IsDead;
			}
		}

		public float Scale
		{
			get
			{
				return this._scale;
			}
			set
			{
				this._scale = value;
				bool flag = this._present != null;
				if (flag)
				{
					this._height = this._present.PresentLib.BoundHeight;
					this._radius = this._present.PresentLib.BoundRadius;
				}
				this._height *= this._scale;
				this._radius *= this._scale;
			}
		}

		public string Name
		{
			get
			{
				return (this._attr == null) ? "NULL" : this._attr.Name;
			}
		}

		public virtual uint TypeID
		{
			get
			{
				return (this._attr == null) ? 0U : this._attr.TypeID;
			}
		}

		public virtual uint PresentID
		{
			get
			{
				return (this._attr == null) ? 0U : this._attr.PresentID;
			}
		}

		public virtual uint PowerPoint
		{
			get
			{
				return (this._attr == null) ? 0U : ((uint)this._attr.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Total));
			}
		}

		public virtual uint SkillCasterTypeID
		{
			get
			{
				return (this._attr == null) ? 0U : this._attr.TypeID;
			}
		}

		public int Wave
		{
			get
			{
				return this._wave;
			}
			set
			{
				this._wave = value;
			}
		}

		public float CreateTime
		{
			get
			{
				return this._create_time;
			}
			set
			{
				this._create_time = value;
			}
		}

		public override XGameObject EngineObject
		{
			get
			{
				return this._xobject;
			}
		}

		public XGameObject MoveObj
		{
			get
			{
				return this.IsMounted ? this._mount.EngineObject : this.EngineObject;
			}
		}

		public virtual string Prefab
		{
			get
			{
				return (this._attr == null) ? string.Empty : this._attr.Prefab;
			}
		}

		public XStateDefine CurState
		{
			get
			{
				return this._machine.Current;
			}
		}

		public long ActionToken
		{
			get
			{
				return this._machine.ActionToken;
			}
		}

		public XEntity MobbedBy { get; set; }

		public bool LifewithinMobbedSkill { get; set; }

		public bool MobShieldable { get; set; }

		public bool MobShield
		{
			get
			{
				return this.MobbedBy != null && this._mob_shield;
			}
			set
			{
				bool flag = this.MobbedBy == null;
				if (!flag)
				{
					bool flag2 = this._mob_shield != value;
					if (flag2)
					{
						this._mob_shield = value;
						this.OnHide(this._mob_shield, BillBoardHideType.Filter);
					}
				}
			}
		}

		public XEntity()
		{
			this._translationCb = new XTimerMgr.ElapsedEventHandler(this.Translation);
			this._endSlowMotionCb = new XTimerMgr.ElapsedEventHandler(this.EndSlowMotion);
			this.CanSelected = true;
		}

		public float SubDelay(float t)
		{
			bool isPlayer = this.IsPlayer;
			float result;
			if (isPlayer)
			{
				float num = (float)XSingleton<XServerTimeMgr>.singleton.GetDelay() / 1000f;
				result = ((num > 0.15f) ? (t - 0.15f) : (t - num));
			}
			else
			{
				result = t;
			}
			return result;
		}

		public float GetDelay()
		{
			return (float)XSingleton<XServerTimeMgr>.singleton.GetDelay() / 1000f;
		}

		public static bool ValideEntity(XEntity e)
		{
			return e != null && !e.IsDead && !e.Deprecated && !e.Destroying;
		}

		public override void OnCreated()
		{
			XFightGroupDocument.OnCalcFightGroup(this);
			base.OnCreated();
			XOnEntityCreatedArgs @event = XEventPool<XOnEntityCreatedArgs>.GetEvent();
			@event.entity = this;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			this._TryCreateHUDComponent();
			bool flag = this.IsRole && !this.IsPlayer;
			if (flag)
			{
				switch (this.Attributes.Outlook.state.type)
				{
				case OutLookStateType.OutLook_Sit:
					this.PlaySpecifiedAnimation(XHomeCookAndPartyDocument.Doc.GetHomeFeastAction(this.Attributes.BasicTypeID % 10U));
					break;
				case OutLookStateType.OutLook_Dance:
					this.PlaySpecifiedAnimation(XDanceDocument.Doc.GetDanceAction(this.PresentID, this.Attributes.Outlook.state.param));
					break;
				case OutLookStateType.OutLook_RidePet:
					XPetDocument.TryMount(true, this, this.Attributes.Outlook.state.param, true);
					break;
				case OutLookStateType.OutLook_Inherit:
					XGuildInheritDocument.TryInInherit(this);
					break;
				case OutLookStateType.OutLook_RidePetCopilot:
				{
					XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(this.Attributes.Outlook.state.paramother);
					bool flag2 = entity != null;
					if (flag2)
					{
						XPetDocument.TryMountCopilot(true, this, entity, true);
					}
					break;
				}
				}
			}
			bool flag3 = XSingleton<XCutScene>.singleton.IsPlaying && XSingleton<XCutScene>.singleton.IsExcludeNewBorn;
			if (flag3)
			{
				XSingleton<XEntityMgr>.singleton.Puppets(this, true, true);
			}
			else
			{
				bool flag4 = !this.IsPlayer;
				if (flag4)
				{
					bool flag5 = this._attr != null && this._attr.SoloShow;
					if (flag5)
					{
						XOthersAttributes xothersAttributes = this._attr as XOthersAttributes;
						bool flag6 = xothersAttributes == null || !xothersAttributes.GeneralCutScene;
						if (flag6)
						{
							XSingleton<XScene>.singleton.GameCamera.TrySolo();
						}
					}
					else
					{
						XSingleton<XScene>.singleton.GameCamera.TrySolo();
					}
					bool flag7 = this._present != null;
					if (flag7)
					{
						this._present.ShowUp();
					}
				}
				else
				{
					XSingleton<XEntityMgr>.singleton.Puppets(this, false, false);
				}
			}
			bool flag8 = !this.IsPlayer;
			if (flag8)
			{
				bool flag9 = this._nav != null;
				if (flag9)
				{
					this._nav.Active();
				}
				bool flag10 = this._ai != null;
				if (flag10)
				{
					this._ai.Active();
				}
			}
			bool flag11 = !this.IsNpc;
			if (flag11)
			{
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGravityComponent.uuID);
			}
			this.SetCollisionLayer(this._layer);
			bool flag12 = !this.IsPlayer;
			if (flag12)
			{
				XSecurityStatistics xsecurityStatistics = XSecurityStatistics.TryGetStatistics(this);
				bool flag13 = xsecurityStatistics != null;
				if (flag13)
				{
					xsecurityStatistics.OnStart();
				}
			}
			bool flag14 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WORLDBOSS || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GUILD_BOSS;
			if (flag14)
			{
				bool isBoss = this.IsBoss;
				if (isBoss)
				{
					this.IsServerFighting = true;
				}
			}
			this.InitChildAtor();
		}

		public override void OnDestroy()
		{
			bool flag = this._next_timer_token > 0U;
			if (flag)
			{
				this.Translation(this);
			}
			bool flag2 = this._xobject == null;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("XEntity Destory error", this.Name, null, null, null, null);
			}
			else
			{
				this._xobject.SetParent(null);
				bool flag3 = this.Nav != null;
				if (flag3)
				{
					base.DetachComponent(XNavigationComponent.uuID);
				}
				bool flag4 = this.MobbedBy != null && !this.MobbedBy.Deprecated && this.MobbedBy.Skill != null;
				if (flag4)
				{
					this.MobbedBy.Skill.RemoveSkillMob(this);
				}
				this.MobbedBy = null;
				bool isMounted = this.IsMounted;
				if (isMounted)
				{
					bool isCopilotMounted = this.IsCopilotMounted;
					if (isCopilotMounted)
					{
						this._mount.UnMountEntity(this);
					}
					else
					{
						this._mount.UnMountAll();
						this._mount.OnDestroy();
						this._mount = null;
					}
				}
				bool isTransform = this.IsTransform;
				if (isTransform)
				{
					XSingleton<XEntityMgr>.singleton.DestroyImmediate(this._transformer);
					this._transformer = null;
				}
				XFightGroupDocument.OnDecalcFightGroup(this);
				base.OnDestroy();
			}
		}

		public bool HasComeOnPresent()
		{
			return this.SkillMgr != null && this.SkillMgr.GetAppearIdentity() != 0U && (!this.IsRole || XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID).ShowUp);
		}

		public void DestroyAffiliate(XAffiliate affiliate)
		{
			for (int i = 0; i < this._affiliates.Count; i++)
			{
				bool flag = this._affiliates[i] == affiliate;
				if (flag)
				{
					affiliate.OnDestroy();
					this._affiliates.RemoveAt(i);
					break;
				}
			}
		}

		public void TriggerDeath(XEntity killer)
		{
			bool flag = this._attr != null && this._attr.IsDead;
			if (!flag)
			{
				this._attr.IsDead = true;
				XRealDeadEventArgs @event = XEventPool<XRealDeadEventArgs>.GetEvent();
				@event.Firer = this;
				@event.Killer = killer;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				@event = XEventPool<XRealDeadEventArgs>.GetEvent();
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				@event.Killer = killer;
				@event.TheDead = this;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				XSingleton<XLevelStatistics>.singleton.OnMonsterDie(this);
			}
		}

		public void UpdateSpecialStateFromServer(uint specialstate, uint mask)
		{
			this._server_special_state = specialstate;
			bool flag = ((ulong)mask & (ulong)(1L << (XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Puppet) & 31))) > 0UL;
			if (flag)
			{
				bool freezed = ((ulong)specialstate & (ulong)(1L << (XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Puppet) & 31))) > 0UL;
				bool isPlayer = this.IsPlayer;
				if (isPlayer)
				{
					bool flag2 = mask == uint.MaxValue;
					if (flag2)
					{
						XSingleton<XInput>.singleton.UnFreezed();
					}
					XSingleton<XInput>.singleton.Freezed = freezed;
				}
			}
			bool flag3 = ((ulong)mask & (ulong)(1L << (XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Invisible) & 31))) > 0UL;
			if (flag3)
			{
				bool flag4 = ((ulong)specialstate & (ulong)(1L << (XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Invisible) & 31))) > 0UL;
				this.RendererToggle(!flag4);
			}
		}

		public XQTEState GetQTESpecificPhase()
		{
			XStateDefine xstateDefine = this.Machine.Current;
			XQTEState result;
			if (xstateDefine != XStateDefine.XState_Freeze)
			{
				if (xstateDefine != XStateDefine.XState_BeHit)
				{
					result = XQTEState.QTE_None;
				}
				else
				{
					result = this._behit.GetQTESpecificPhase();
				}
			}
			else
			{
				result = XQTEState.QTE_HitFreeze;
			}
			return result;
		}

		public void ApplyMove(Vector3 movement)
		{
			this._movement += movement;
		}

		public void ApplyMove(float x, float y, float z)
		{
			this._movement.x = this._movement.x + x;
			this._movement.z = this._movement.z + z;
			this._movement.y = this._movement.y + y;
		}

		public void LookTo(Vector3 forward)
		{
			bool flag = this.MoveObj != null;
			if (flag)
			{
				this.MoveObj.Forward = forward;
			}
			bool flag2 = this.Rotate != null;
			if (flag2)
			{
				this.Rotate.Cancel();
			}
		}

		protected virtual void PositionTo(Vector3 pos)
		{
			bool flag = this.MoveObj != null;
			if (flag)
			{
				this.MoveObj.Position = pos;
			}
			bool flag2 = this.MoveObj != null;
			if (flag2)
			{
				this.MoveObj.Move(Vector3.down);
			}
			bool flag3 = this._net != null;
			if (flag3)
			{
				this._net.CorrectNet(pos);
			}
			bool flag4 = this.IsPlayer && XSingleton<XScene>.singleton.GameCamera.Wall != null;
			if (flag4)
			{
				XSingleton<XScene>.singleton.GameCamera.Wall.EndEffect();
				XSingleton<XScene>.singleton.GameCamera.Wall.TargetY = XSingleton<XScene>.singleton.GameCamera.Root_R_Y;
			}
		}

		public virtual void CorrectMe(Vector3 pos, Vector3 face, bool reconnected = false, bool fade = false)
		{
			pos.y = XSingleton<XScene>.singleton.TerrainY(pos) + ((this.MoveObj != null && this.MoveObj.EnableCC) ? 0.25f : 0.05f);
			bool flag = this._nav != null;
			if (flag)
			{
				this._nav.Interrupt();
			}
			if (reconnected)
			{
				this.LookTo(face);
				this.PositionTo(pos);
			}
			else
			{
				bool flag2 = this.IsPlayer || (XSingleton<XScene>.singleton.bSpectator && this == XSingleton<XEntityMgr>.singleton.Player.WatchTo);
				if (flag2)
				{
					bool isPlayer = this.IsPlayer;
					if (isPlayer)
					{
						XSingleton<XEntityMgr>.singleton.Idled(this);
					}
					if (fade)
					{
						this._net.Pause = true;
						this._next_pos = pos;
						this._next_face = face;
						XAutoFade.FadeOut2In(1f, 0.5f);
						bool isPlayer2 = this.IsPlayer;
						if (isPlayer2)
						{
							XSingleton<XInput>.singleton.Freezed = true;
							XSingleton<XAIGeneralMgr>.singleton.EnablePlayerAI(false);
						}
						bool flag3 = this._next_timer_token > 0U;
						if (flag3)
						{
							XSingleton<XTimerMgr>.singleton.KillTimer(this._next_timer_token);
							bool isPlayer3 = this.IsPlayer;
							if (isPlayer3)
							{
								XSingleton<XInput>.singleton.Freezed = false;
								XSingleton<XAIGeneralMgr>.singleton.EnablePlayerAI(true);
							}
						}
						this._next_timer_token = XSingleton<XTimerMgr>.singleton.SetTimer(0.47f, this._translationCb, null);
					}
					else
					{
						this.LookTo(face);
						this.PositionTo(pos);
					}
				}
				else
				{
					this.LookTo(face);
					this.PositionTo(pos);
				}
			}
		}

		public virtual void OnTransform(uint to)
		{
			bool destroying = base.Destroying;
			if (!destroying)
			{
				bool flag = this.Machine != null;
				if (flag)
				{
					this.Machine.OnAnimationOverrided();
				}
				bool flag2 = this.Skill != null && this.Skill.IsCasting();
				if (flag2)
				{
					this.Skill.EndSkill(true, true);
				}
				else
				{
					bool flag3 = this.Machine != null;
					if (flag3)
					{
						this.Machine.ForceToDefaultState(false);
					}
				}
				this.TransformFigture(to);
				this.TransformSkill(to);
			}
		}

		private void TransformFigture(uint to)
		{
			bool flag = this.IsTransform && this._transformer.TypeID == to;
			if (!flag)
			{
				bool flag2 = this._equip != null && !this._equip.IsVisible;
				if (!flag2)
				{
					bool isTransform = this.IsTransform;
					bool isDisappear;
					if (isTransform)
					{
						isDisappear = this._transformer.IsDisappear;
						XRenderComponent.OnTransform(this._transformer, this, false);
						bool isMustTransform = XSingleton<XScene>.singleton.IsMustTransform;
						if (isMustTransform)
						{
							this.EngineObject.ClearTransformPhysic();
						}
						bool flag3 = this._transformer._present != null;
						if (flag3)
						{
							this._transformer._present.OnTransform(this, false);
						}
						this._transformer.SetCollisionLayer(this._transformer.DefaultLayer);
						this._transformer.EngineObject.SetRenderLayer(this._transformer.DefaultLayer);
						XSingleton<XEntityMgr>.singleton.DestroyImmediate(this._transformer);
						this._transformer = null;
					}
					else
					{
						bool flag4 = to == 0U;
						if (flag4)
						{
							return;
						}
						isDisappear = this.IsDisappear;
					}
					bool flag5 = to > 0U;
					if (flag5)
					{
						this._transformer = XSingleton<XEntityMgr>.singleton.CreateTransform(to, this._xobject.Position, this._xobject.Rotation, false, this, (uint)XFastEnumIntEqualityComparer<FightGroupType>.ToInt(FightGroupType.FightNeutral));
						bool flag6 = this._transformer != null;
						if (flag6)
						{
							this.InnerRendererToggle(false);
							bool flag7 = this.IsMounted && !this.IsCopilotMounted;
							if (flag7)
							{
								this.Mount.RendererToggle(false);
							}
							this._transformer.RendererToggle(!isDisappear);
							this._transformer.IsDisappear = isDisappear;
							bool flag8 = this._transformer.Ator != null;
							if (flag8)
							{
								this._transformer.Ator.speed = 1f;
							}
							XRenderComponent.OnTransform(this, this._transformer, true);
							bool isMustTransform2 = XSingleton<XScene>.singleton.IsMustTransform;
							if (isMustTransform2)
							{
								this.EngineObject.TransformPhysic(this._transformer.EngineObject);
							}
							this._transformer.SetCollisionLayer(this.DefaultLayer);
							this._transformer.EngineObject.SetRenderLayer(this.DefaultLayer);
							bool flag9 = this._transformer._present != null;
							if (flag9)
							{
								this._transformer._present.OnTransform(this, true);
							}
						}
					}
					else
					{
						this.RendererToggle(!isDisappear);
						this.IsDisappear = isDisappear;
						bool flag10 = this.Ator != null;
						if (flag10)
						{
							this.Ator.speed = 1f;
						}
						bool flag11 = !this.IsDisappear && this.Ator != null;
						if (flag11)
						{
							this.Ator.SetTrigger("EndSkill");
						}
					}
				}
			}
		}

		private void TransformSkill(uint to)
		{
			bool flag = this._skill != null;
			if (flag)
			{
				XEntityPresentation.RowData template = null;
				bool flag2 = to == 0U;
				if (flag2)
				{
					template = null;
				}
				else
				{
					bool isTransform = this.IsTransform;
					if (isTransform)
					{
						template = this._transformer.Present.PresentLib;
					}
					else
					{
						XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(to);
						bool flag3 = byID != null;
						if (flag3)
						{
							template = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
						}
					}
				}
				this._skill.ReAttachSkill(template, to);
			}
		}

		public void OnTransform(XEntity transformee)
		{
			this._transformee = transformee;
		}

		private static void OnScale(XEntity entity, uint scaleParam)
		{
			float num = 1f;
			bool flag = scaleParam == 0U;
			if (flag)
			{
				entity.Scale = entity.Present.PresentLib.Scale;
				Vector3 localScale = Vector3.one * entity.Scale;
				entity.EngineObject.LocalScale = localScale;
			}
			else
			{
				num = scaleParam * 0.001f;
				entity.Scale = entity.Present.PresentLib.Scale * num;
				Vector3 localScale2 = Vector3.one * entity.Scale;
				entity.EngineObject.LocalScale = localScale2;
				num *= 1.5f;
			}
			bool isPlayer = entity.IsPlayer;
			if (isPlayer)
			{
				XSingleton<XCustomShadowMgr>.singleton.SetShadowScale(num);
			}
		}

		public void OnScale(uint scaleParam)
		{
			XEntity.OnScale(this, scaleParam);
			bool isTransform = this.IsTransform;
			if (isTransform)
			{
				XEntity.OnScale(this._transformer, scaleParam);
			}
		}

		private void Translation(object o)
		{
			this._next_timer_token = 0U;
			this._net.Pause = false;
			bool isPlayer = this.IsPlayer;
			if (isPlayer)
			{
				XSingleton<XInput>.singleton.Freezed = false;
			}
			bool flag = o == this;
			if (!flag)
			{
				bool flag2 = this.MoveObj != null;
				if (flag2)
				{
					this.LookTo(this._next_face);
					XSingleton<XScene>.singleton.GameCamera.YRotateEx(XSingleton<XCommon>.singleton.AngleToFloat(this.MoveObj.Forward));
					this.PositionTo(this._next_pos);
					bool isPlayer2 = this.IsPlayer;
					if (isPlayer2)
					{
						XSingleton<XAIGeneralMgr>.singleton.EnablePlayerAI(true);
					}
				}
			}
		}

		public void DyingCloseUp()
		{
			bool flag = !XSingleton<XCutScene>.singleton.IsPlaying && !this.Present.PresentLib.Huge;
			if (flag)
			{
				bool flag2 = XSingleton<XScene>.singleton.GameCamera.Solo != null;
				if (flag2)
				{
					XSingleton<XScene>.singleton.GameCamera.Solo.Stop();
				}
				XCameraMotionData xcameraMotionData = new XCameraMotionData();
				xcameraMotionData.AutoSync_At_Begin = true;
				xcameraMotionData.Coordinate = CameraMotionSpace.World;
				xcameraMotionData.Follow_Position = false;
				xcameraMotionData.LookAt_Target = false;
				xcameraMotionData.At = 0f;
				xcameraMotionData.Motion = ((this.Height > 2f) ? "Animation/Main_Camera/Main_Camera_die_bigguy" : "Animation/Main_Camera/Main_Camera_die");
				XCameraMotionEventArgs @event = XEventPool<XCameraMotionEventArgs>.GetEvent();
				@event.Motion = xcameraMotionData;
				@event.Target = this;
				@event.Trigger = "ToEffect";
				@event.Firer = XSingleton<XScene>.singleton.GameCamera;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				this.BeginSlowMotion(0.3f, 1f, true);
			}
		}

		public virtual void Dying()
		{
			XOthersAttributes xothersAttributes = this.Attributes as XOthersAttributes;
			bool flag = xothersAttributes != null && xothersAttributes.EndShow;
			if (flag)
			{
				this.DyingCloseUp();
			}
		}

		public virtual void Died()
		{
			XSingleton<XEntityMgr>.singleton.DestroyEntity(this);
		}

		public bool Initilize(XGameObject o, XAttributes attr, bool transform)
		{
			this._layer = o.Layer;
			base.AttachComponent(attr);
			this._attr = attr;
			this._using_cc_move = this.IsPlayer;
			this._xobject = o;
			this._xobject.UID = this.ID;
			this._xobject.Name = this.ID.ToString();
			this._client_predicted = XSingleton<XScene>.singleton.IsViewGridScene;
			int flag = transform ? XFastEnumIntEqualityComparer<XEntity.InitFlag>.ToInt(XEntity.InitFlag.Entity_Transform) : 0;
			bool result = this.Initilize(flag);
			bool isPlayer = this.IsPlayer;
			if (isPlayer)
			{
				this._xobject.EnableCC = true;
				this._xobject.EnableBC = false;
			}
			else
			{
				this._xobject.EnableCC = false;
				this._xobject.EnableBC = true;
			}
			return result;
		}

		public override void Uninitilize()
		{
			bool flag = this._skill != null;
			if (flag)
			{
				bool flag2 = this._skill.IsCasting();
				if (flag2)
				{
					this._skill.EndSkill(false, false);
				}
			}
			bool flag3 = this._machine != null;
			if (flag3)
			{
				this._machine.ForceToDefaultState(false);
			}
			string text = (this._attr != null) ? this._attr.Prefab : null;
			base.Uninitilize();
			bool flag4 = this._childAtor != null;
			if (flag4)
			{
				this._childAtor.enabled = false;
				Transform transform = this._xobject.Find("");
				bool flag5 = transform != null;
				if (flag5)
				{
					XSingleton<XCommon>.singleton.EnableParticle(transform.gameObject, false);
				}
				this._childAtor = null;
			}
			bool flag6 = this._xobject != null;
			if (flag6)
			{
				XGameObject.DestroyXGameObject(this._xobject);
				this._xobject = null;
			}
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			this._gravity_disabled = false;
			bool flag = this.IsMounted && this.IsCopilotMounted;
			if (flag)
			{
				this.EngineObject.Update();
			}
			else
			{
				this.Move();
			}
			this._movement.y = 0f;
			bool flag2 = !XSingleton<XGame>.singleton.SyncMode || this.IsSubstance;
			if (flag2)
			{
				this.SetDynamicLayer(this._movement.sqrMagnitude);
			}
			this._movement = Vector3.zero;
			this._server_movement = Vector3.zero;
			this.UpdateMoveTracker();
			this.MoveObj.Update();
		}

		public override void PostUpdate(float fDeltaT)
		{
			base.PostUpdate(fDeltaT);
			bool isTransform = this.IsTransform;
			if (isTransform)
			{
				this.Transformer.PostUpdate(fDeltaT);
			}
			bool flag = this.IsMounted && !this.IsCopilotMounted;
			if (flag)
			{
				this._mount.PostUpdate(fDeltaT);
			}
			for (int i = 0; i < this._affiliates.Count; i++)
			{
				this._affiliates[i].PostUpdate(fDeltaT);
			}
		}

		public void OverrideAnimClip(string motion, string clipname, bool shortPath, bool force = false)
		{
			this.OverrideAnimClip(motion, clipname, shortPath, null, force);
		}

		public void OverrideAnimClip(string motion, string clipname, bool shortPath, OverrideAnimCallback overrideAnim, bool force = false)
		{
			bool flag = string.IsNullOrEmpty(clipname);
			if (!flag)
			{
				bool flag2 = this.Ator != null;
				if (flag2)
				{
					if (shortPath)
					{
						XPresentComponent xpresentComponent = this.IsTransform ? this.Transformer.Present : this.Present;
						clipname = xpresentComponent.ActionPrefix + clipname;
					}
					this.Ator.OverrideAnim(motion, clipname, overrideAnim, force);
				}
			}
		}

		private static void AnimLoadCallback(XAnimationClip clip)
		{
			XEntity.m_AnimLength = ((clip != null) ? clip.length : -1f);
			XEntity.m_xclip = clip;
		}

		public float OverrideAnimClipGetLength(string motion, string clipname, bool shortPath)
		{
			XEntity.m_AnimLength = -1f;
			bool flag = string.IsNullOrEmpty(clipname);
			float animLength;
			if (flag)
			{
				animLength = XEntity.m_AnimLength;
			}
			else
			{
				bool flag2 = this.Ator != null;
				if (flag2)
				{
					if (shortPath)
					{
						XPresentComponent xpresentComponent = this.IsTransform ? this.Transformer.Present : this.Present;
						clipname = xpresentComponent.ActionPrefix + clipname;
					}
					this.Ator.OverrideAnim(motion, clipname, XEntity.m_AnimLoadCb, false);
				}
				animLength = XEntity.m_AnimLength;
			}
			return animLength;
		}

		public void OverrideAnimClipGetClip(string motion, string clipname, bool shortPath, bool forceOverride, out XAnimationClip outClip)
		{
			XEntity.m_AnimLength = -1f;
			XEntity.m_xclip = null;
			bool flag = string.IsNullOrEmpty(clipname);
			if (flag)
			{
				outClip = null;
			}
			else
			{
				bool flag2 = this.Ator != null;
				if (flag2)
				{
					if (shortPath)
					{
						XPresentComponent xpresentComponent = this.IsTransform ? this.Transformer.Present : this.Present;
						clipname = xpresentComponent.ActionPrefix + clipname;
					}
					this.Ator.OverrideAnim(motion, clipname, XEntity.m_AnimLoadCb, forceOverride);
				}
				outClip = XEntity.m_xclip;
				XEntity.m_xclip = null;
			}
		}

		public virtual void PlaySpecifiedAnimation(string anim)
		{
		}

		public void SetCollisionLayer(int layer)
		{
			bool flag = this._xobject != null && this._xobject.Layer != layer;
			if (flag)
			{
				this._xobject.Layer = layer;
				bool flag2 = this.IsMounted && !this.IsCopilotMounted;
				if (flag2)
				{
					this._mount.SetCollisionLayer(layer);
				}
			}
			bool flag3 = layer == XPlayer.PlayerLayer;
			if (flag3)
			{
				this._xobject.EnableCC = true;
				this._xobject.EnableBC = false;
			}
			else
			{
				this._xobject.EnableCC = false;
				this._xobject.EnableBC = true;
			}
		}

		public void BeginSlowMotion(float factor, float duration, bool withcameraeffect = false)
		{
			XSingleton<XShell>.singleton.TimeMagic(factor);
			bool flag = this._slow_motion_token > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._slow_motion_token);
			}
			this._slow_motion_token = XSingleton<XTimerMgr>.singleton.SetTimer(duration, this._endSlowMotionCb, withcameraeffect ? this : null);
		}

		protected void StickOnGround(float outy)
		{
			float num = 0f;
			bool flag = outy > 0f;
			if (flag)
			{
				num = outy;
			}
			else
			{
				bool flag2 = !XSingleton<XScene>.singleton.TryGetTerrainY(this.MoveObj.Position, out num);
				if (flag2)
				{
					return;
				}
			}
			bool flag3 = this.MoveObj.Position.y <= num;
			if (flag3)
			{
				Vector3 position = this.MoveObj.Position;
				position.y = num + 0.01f;
				this.MoveObj.Position = position;
				this._bStandOn = (this._fly == null || this._behit.LaidOnGround());
			}
		}

		protected virtual void Move()
		{
			bool flag = !this._machine.State.SyncPredicted;
			if (flag)
			{
				this._movement.x = this._server_movement.x;
				this._movement.z = this._server_movement.z;
			}
			bool flag2 = this._movement.x != 0f || this._movement.z != 0f || this._movement.y > 0f || !this._bStandOn;
			if (flag2)
			{
				Vector3 vector = this.MoveObj.Position + this._movement;
				float num = 0f;
				bool flag3 = XSingleton<XScene>.singleton.TryGetTerrainY(vector, out num);
				if (flag3)
				{
					bool flag4 = num < 0f;
					if (flag4)
					{
						bool syncPredicted = this._machine.State.SyncPredicted;
						if (syncPredicted)
						{
							this._bStandOn = false;
							float num2 = XSingleton<XScene>.singleton.TerrainY(this.MoveObj.Position);
							bool flag5 = vector.y < num2;
							if (flag5)
							{
								vector.y = num2;
							}
						}
						else
						{
							bool flag6 = !this.IsPlayer;
							if (flag6)
							{
								vector.y = this.MoveObj.Position.y;
								this.MoveObj.Position = vector;
								this._bStandOn = true;
							}
						}
					}
					else
					{
						bool using_cc_move = this._using_cc_move;
						if (using_cc_move)
						{
							Vector3 position = this.MoveObj.Position;
							this._bStandOn = this.ControllerMove(this.MoveObj);
							bool flag7 = !XSingleton<XScene>.singleton.TryGetTerrainY(this.MoveObj.Position, out num) || num < 0f;
							if (flag7)
							{
								this.MoveObj.Position = position;
							}
							else
							{
								bool bStandOn = this._bStandOn;
								if (bStandOn)
								{
									bool flag8 = this.MoveObj.Position.y < num && num - this.MoveObj.Position.y > 0.05f;
									if (flag8)
									{
										this._bStandOn = false;
									}
								}
								else
								{
									num = -1f;
								}
							}
						}
						else
						{
							bool flag9 = !this._machine.State.SyncPredicted || XSingleton<XScene>.singleton.CheckDynamicBlock(this.MoveObj.Position, vector);
							if (flag9)
							{
								this.MoveObj.Position = vector;
								this._bStandOn = false;
							}
						}
					}
					bool flag10 = !this._bStandOn;
					if (flag10)
					{
						vector.x = this.MoveObj.Position.x;
						vector.z = this.MoveObj.Position.z;
						this.MoveObj.Position = vector;
						this.StickOnGround(num);
					}
					bool flag11 = this.EngineObject != this.MoveObj;
					if (flag11)
					{
						this.EngineObject.SyncPos();
					}
				}
			}
		}

		protected bool ControllerMove(XGameObject moveObj)
		{
			Vector3 position = moveObj.Position;
			CollisionFlags collisionFlags = moveObj.Move(this._movement);
			bool flag = XSingleton<XScene>.singleton.CheckDynamicBlock(position, moveObj.Position);
			bool result;
			if (flag)
			{
				result = ((collisionFlags & (CollisionFlags)4) != null && (this._fly == null || this._behit.LaidOnGround()));
			}
			else
			{
				this.MoveObj.Position = position;
				result = this._bStandOn;
			}
			return result;
		}

		public void SyncServerMove(Vector3 delta)
		{
			delta.y = 0f;
			bool flag = delta.sqrMagnitude < XCommon.XEps * XCommon.XEps;
			if (flag)
			{
				this._server_movement = Vector3.zero;
			}
			else
			{
				this._server_movement = delta;
			}
		}

		private void SetDynamicLayer(float dis)
		{
			bool flag = this._skill != null && this._skill.IsCasting();
			if (flag)
			{
				bool flag2 = !XSingleton<XGame>.singleton.SyncMode;
				if (flag2)
				{
					this._skill.CurrentSkill.UpdateCollisionLayer(dis / Time.deltaTime);
				}
			}
			else
			{
				bool flag3 = this._machine != null;
				if (flag3)
				{
					this._machine.UpdateCollisionLayer();
				}
			}
		}

		private void EndSlowMotion(object o)
		{
			XSingleton<XShell>.singleton.TimeMagicBack();
			this._slow_motion_token = 0U;
			bool flag = o != null;
			if (flag)
			{
				XCameraMotionEndEventArgs @event = XEventPool<XCameraMotionEndEventArgs>.GetEvent();
				@event.Target = this;
				@event.Firer = XSingleton<XScene>.singleton.GameCamera;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		private void UpdateMoveTracker()
		{
			bool isTransform = this.IsTransform;
			if (isTransform)
			{
				this.Transformer.MoveObj.Position = this.MoveObj.Position;
				this.Transformer.MoveObj.Rotation = this.MoveObj.Rotation;
			}
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				this.UpdateWatcher();
			}
		}

		public void OnMount(XMount mount, bool copilot)
		{
			bool flag = this.IsMounted && !this.IsCopilotMounted;
			if (flag)
			{
				this._mount.OnDestroy();
			}
			this._mount = mount;
			this._is_mount_copilot = copilot;
			bool flag2 = this._xobject != null;
			if (flag2)
			{
				bool isPlayer = this.IsPlayer;
				if (isPlayer)
				{
					this._xobject.EnableBC = false;
					this._xobject.EnableCC = !this.IsMounted;
				}
				else
				{
					this._xobject.EnableBC = !this.IsMounted;
					this._xobject.EnableCC = false;
				}
			}
			bool isMounted = this.IsMounted;
			if (isMounted)
			{
				XOnMountedEventArgs @event = XEventPool<XOnMountedEventArgs>.GetEvent();
				@event.Firer = this;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				bool isPlayer2 = this.IsPlayer;
				if (isPlayer2)
				{
					XOnMountedEventArgs event2 = XEventPool<XOnMountedEventArgs>.GetEvent();
					event2.Firer = XSingleton<XGame>.singleton.Doc;
					XSingleton<XEventMgr>.singleton.FireEvent(event2);
				}
			}
			else
			{
				XOnUnMountedEventArgs event3 = XEventPool<XOnUnMountedEventArgs>.GetEvent();
				event3.Firer = this;
				XSingleton<XEventMgr>.singleton.FireEvent(event3);
				bool isPlayer3 = this.IsPlayer;
				if (isPlayer3)
				{
					XOnUnMountedEventArgs event4 = XEventPool<XOnUnMountedEventArgs>.GetEvent();
					event4.Firer = XSingleton<XGame>.singleton.Doc;
					XSingleton<XEventMgr>.singleton.FireEvent(event4);
				}
			}
			for (int i = 0; i < this.Affiliates.Count; i++)
			{
				this.Affiliates[i].OnMount();
			}
			this._bStandOn = false;
		}

		public virtual void UpdateWatcher()
		{
		}

		private void _TryCreateHUDComponent()
		{
			bool flag = base.GetXComponent(XHUDComponent.uuID) == null;
			if (flag)
			{
				bool flag2 = !this.IsNpc;
				if (flag2)
				{
					XSingleton<XComponentMgr>.singleton.CreateComponent(this, XHUDComponent.uuID);
				}
			}
		}

		public virtual bool ProcessRealTimeShadow()
		{
			bool flag = this._equip != null;
			bool result;
			if (flag)
			{
				bool flag2 = ((this._transformee != null) ? this._transformee.IsPlayer : this.IsPlayer) && XQualitySetting._CastShadow;
				this._equip.EnableRealTimeShadow(flag2);
				result = flag2;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public virtual bool CastFakeShadow()
		{
			return false;
		}

		public void RendererToggle(bool enabled)
		{
			bool isTransform = this.IsTransform;
			if (isTransform)
			{
				this.Transformer.RendererToggle(enabled);
				bool flag = this.Transformer.IsMounted && !this.Transformer.IsCopilotMounted && this.Transformer.Mount.EngineObject != null;
				if (flag)
				{
					this.Transformer.Mount.RendererToggle(enabled);
				}
				this.Transformer.IsDisappear = !enabled;
			}
			else
			{
				this.InnerRendererToggle(enabled);
				bool flag2 = this.IsMounted && !this.IsCopilotMounted && this.Mount.EngineObject != null;
				if (flag2)
				{
					this.Mount.RendererToggle(enabled);
				}
				this.IsDisappear = !enabled;
			}
		}

		private void InnerRendererToggle(bool enabled)
		{
			bool flag = this._equip != null;
			if (flag)
			{
				this._equip.EnableRender(enabled);
			}
			else
			{
				bool flag2 = this is XMount;
				if (flag2)
				{
					XMount xmount = this as XMount;
					xmount.SetActive(enabled);
				}
				else
				{
					bool flag3 = this._xobject != null;
					if (flag3)
					{
						this._xobject.SetActive(enabled, "");
					}
				}
			}
			this.ShowEntityEffect(enabled, BillBoardHideType.InnerRenderer);
		}

		private static void _InitChildAtor(XGameObject gameObject, object o, int commandID)
		{
			XEntity xentity = o as XEntity;
			bool flag = xentity != null;
			if (flag)
			{
				Transform transform = gameObject.Find("");
				bool flag2 = transform != null;
				if (flag2)
				{
					xentity._childAtor = transform.GetComponentInChildren<Animator>();
					bool flag3 = xentity._childAtor != null;
					if (flag3)
					{
						bool flag4 = xentity.Ator.IsSame(xentity._childAtor);
						if (flag4)
						{
							xentity._childAtor = null;
						}
						else
						{
							xentity._childAtor.enabled = true;
							bool flag5 = xentity._childAtor.runtimeAnimatorController != null;
							if (flag5)
							{
								xentity._childAtor.Play(xentity._childAtor.runtimeAnimatorController.name, -1, 0f);
							}
							XSingleton<XCommon>.singleton.EnableParticle(transform.gameObject, true);
						}
					}
				}
			}
		}

		public void InitChildAtor()
		{
			bool enableAtor = XStateMachine._EnableAtor;
			if (enableAtor)
			{
				this.EngineObject.CallCommand(XEntity._initChildAtorCb, this, -1, false);
			}
		}

		private void ShowEntityEffect(bool show, BillBoardHideType billboardType)
		{
			XBillboardShowCtrlEventArgs @event = XEventPool<XBillboardShowCtrlEventArgs>.GetEvent();
			@event.show = show;
			@event.type = billboardType;
			@event.Firer = ((this.Transformee == null) ? this : this.Transformee);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			XFootFxComponent xfootFxComponent = base.GetXComponent(XFootFxComponent.uuID) as XFootFxComponent;
			bool flag = xfootFxComponent != null;
			if (flag)
			{
				xfootFxComponent.SetActive(show);
			}
			XShadowComponent xshadowComponent = base.GetXComponent(XShadowComponent.uuID) as XShadowComponent;
			bool flag2 = xshadowComponent != null;
			if (flag2)
			{
				xshadowComponent.SetActive(show);
			}
		}

		public void OnFade(bool fadeIn, float time, bool isVisibleAfterFadeout, BillBoardHideType billboardType)
		{
			XEntity realEntity = this.RealEntity;
			if (fadeIn)
			{
				this._isVisible = true;
				this.ShowEntityEffect(true, billboardType);
			}
			else
			{
				this._isVisible = isVisibleAfterFadeout;
				bool flag = !this._isVisible;
				if (flag)
				{
					this.ShowEntityEffect(false, billboardType);
				}
			}
			XRenderComponent.OnFade(realEntity, fadeIn, time, isVisibleAfterFadeout);
		}

		public void OnHide(bool hide, BillBoardHideType billboardType)
		{
			this._isVisible = !hide;
			XEntity realEntity = this.RealEntity;
			realEntity.ShowEntityEffect(this._isVisible, billboardType);
			XRenderComponent.OnHide(realEntity, hide);
		}

		public static bool FilterFx(Vector3 pos, float dis)
		{
			bool filterFx = XSingleton<XScene>.singleton.FilterFx;
			if (filterFx)
			{
				Vector3 position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
				float num = (pos.x - position.x) * (pos.x - position.x) + (pos.z - position.z) * (pos.z - position.z);
				bool flag = num > dis;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public static bool FilterFx(XEntity e, float dis)
		{
			bool flag = XSingleton<XScene>.singleton.FilterFx && !e.IsPlayer && !(e is XDummy);
			if (flag)
			{
				Vector3 position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
				Vector3 position2 = e.EngineObject.Position;
				float num = (position2.x - position.x) * (position2.x - position.x) + (position2.z - position.z) * (position2.z - position.z);
				bool flag2 = num > dis;
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		protected bool _client_predicted = false;

		protected bool _passive = false;

		protected bool _using_cc_move = false;

		protected XPresentComponent _present = null;

		protected XStateMachine _machine = null;

		protected XSkillComponent _skill = null;

		protected XBuffComponent _buff = null;

		protected XNetComponent _net = null;

		protected XRotationComponent _rotate = null;

		protected XBeHitComponent _behit = null;

		protected XDeathComponent _death = null;

		protected XNavigationComponent _nav = null;

		protected XEquipComponent _equip = null;

		protected XRenderComponent _render = null;

		protected XFlyComponent _fly = null;

		protected XAIComponent _ai = null;

		protected XQuickTimeEventComponent _qte = null;

		protected XAudioComponent _audio = null;

		protected XBillboardComponent _billboard = null;

		protected float _airthreshold = 0.1f;

		protected float _height = 0f;

		protected float _radius = 0f;

		protected float _scale = 1f;

		protected bool _bStandOn = false;

		protected bool _bDisappear = false;

		protected bool _gravity_disabled = false;

		private bool _mob_shield = false;

		protected XEntity.EnitityType _eEntity_Type = XEntity.EnitityType.Entity_None;

		protected int _layer = 0;

		private int _wave = -1;

		private float _create_time = 0f;

		private uint _slow_motion_token = 0U;

		private bool _server_fighting = false;

		private Vector3 _next_pos = Vector3.zero;

		private Vector3 _next_face = Vector3.zero;

		private uint _next_timer_token = 0U;

		private uint _server_special_state = 0U;

		private ulong _last_special_state_from_server = 0UL;

		protected Vector3 _movement = Vector3.zero;

		protected Vector3 _server_movement = Vector3.zero;

		protected XGameObject _xobject = null;

		protected XEntity _transformer = null;

		protected XEntity _transformee = null;

		protected XMount _mount = null;

		protected bool _is_mount_copilot = false;

		protected Animator _childAtor = null;

		private static CommandCallback _initChildAtorCb = new CommandCallback(XEntity._InitChildAtor);

		protected bool _isVisible = true;

		private List<XAffiliate> _affiliates = new List<XAffiliate>();

		private XTimerMgr.ElapsedEventHandler _translationCb = null;

		private XTimerMgr.ElapsedEventHandler _endSlowMotionCb = null;

		private static float m_AnimLength = -1f;

		private static XAnimationClip m_xclip = null;

		private static OverrideAnimCallback m_AnimLoadCb = new OverrideAnimCallback(XEntity.AnimLoadCallback);

		protected enum EnitityType
		{

			Entity_None = 1,

			Entity_Role,

			Entity_Player = 4,

			Entity_Enemy = 8,

			Entity_Opposer = 16,

			Entity_Boss = 32,

			Entity_Puppet = 64,

			Entity_Elite = 128,

			Entity_Npc = 256,

			Entity_Dummy = 512,

			Entity_Empty = 1024,

			Entity_Substance = 2048,

			Entity_Temp = 4096,

			Entity_Affiliate = 8192,

			Entity_Mount = 16384
		}

		protected enum InitFlag
		{

			Entity_Transform = 1
		}
	}
}
