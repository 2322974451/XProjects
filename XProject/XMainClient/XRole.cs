using System;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRole : XEntity
	{

		public override bool Initilize(int flag)
		{
			this._eEntity_Type |= XEntity.EnitityType.Entity_Role;
			this._layer = LayerMask.NameToLayer("Role");
			this._using_cc_move = false;
			this._present = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPresentComponent.uuID) as XPresentComponent);
			this._machine = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XStateMachine.uuID) as XStateMachine);
			bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World;
			if (flag2)
			{
				this._skill = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSkillComponent.uuID) as XSkillComponent);
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XEndureComponent.uuID);
			}
			this._net = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XNetComponent.uuID) as XNetComponent);
			this.AddMoveComponents();
			this._machine.SetDefaultState(base.GetXComponent(XIdleComponent.uuID) as XIdleComponent);
			this._buff = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBuffComponent.uuID) as XBuffComponent);
			bool flag3 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World;
			if (flag3)
			{
				this._death = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDeathComponent.uuID) as XDeathComponent);
			}
			bool flag4 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA;
			if (flag4)
			{
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMobaBillboardComponent.uuID);
			}
			else
			{
				this._billboard = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBillboardComponent.uuID) as XBillboardComponent);
			}
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XCharacterShowChatComponent.uuID);
			bool flag5 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_FIGHT || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_WAIT;
			if (flag5)
			{
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XTerritoryComponent.uuID);
			}
			this._audio = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAudioComponent.uuID) as XAudioComponent);
			bool flag6 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_ARENA;
			if (flag6)
			{
				this._ai = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAIComponent.uuID) as XAIComponent);
			}
			bool flag7 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World;
			if (flag7)
			{
				this._qte = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XQuickTimeEventComponent.uuID) as XQuickTimeEventComponent);
			}
			bool flag8 = !XSingleton<XGame>.singleton.SyncMode;
			if (flag8)
			{
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XManipulationComponent.uuID);
			}
			bool isNotEmptyObject = this._xobject.IsNotEmptyObject;
			if (isNotEmptyObject)
			{
				this._equip = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XEquipComponent.uuID) as XEquipComponent);
				bool flag9 = this._equip != null;
				if (flag9)
				{
					this._equip.IsUIAvatar = false;
				}
				bool flag10 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && this.CastFakeShadow();
				if (flag10)
				{
					XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFootFxComponent.uuID);
				}
			}
			return true;
		}

		public override void OnCreated()
		{
			XRoleAttributes xroleAttributes = this._attr as XRoleAttributes;
			bool flag = this._xobject.IsNotEmptyObject && xroleAttributes != null && !xroleAttributes.IsLocalFake;
			if (flag)
			{
				this._render = XRenderComponent.AddRenderComponent(this);
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XShadowComponent.uuID);
			}
			bool flag2 = DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.CanRenderOtherPalyers();
			bool flag3 = this._render != null;
			if (flag3)
			{
				int entityLayer = flag2 ? this._layer : XQualitySetting.InVisiblityLayer;
				this._render.SetEntityLayer(entityLayer);
				this._render.PostCreateComponent();
			}
			base.OnCreated();
			bool flag4 = !flag2;
			if (flag4)
			{
				XBillboardShowCtrlEventArgs @event = XEventPool<XBillboardShowCtrlEventArgs>.GetEvent();
				@event.show = false;
				@event.Firer = this;
				@event.type = BillBoardHideType.Photo;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		public override void Died()
		{
		}

		public virtual void Revive()
		{
			this.Attributes.IsDead = false;
			XOnRevivedArgs @event = XEventPool<XOnRevivedArgs>.GetEvent();
			@event.entity = this;
			@event.Firer = this;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			XOnRevivedArgs event2 = XEventPool<XOnRevivedArgs>.GetEvent();
			event2.entity = this;
			event2.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(event2);
		}

		public override void PlaySpecifiedAnimation(string anim)
		{
			XSingleton<XEntityMgr>.singleton.Idled(this);
			base.OverrideAnimClip("Idle", anim, true, null, false);
			base.Ator.CrossFade("Stand", 0.05f, 0, 0f);
		}

		public float PlaySpecifiedAnimationGetLength(string anim)
		{
			XSingleton<XEntityMgr>.singleton.Idled(this);
			float result = base.OverrideAnimClipGetLength("Idle", anim, true);
			base.Ator.CrossFade("Stand", 0.05f, 0, 0f);
			return result;
		}

		public void PlayStateBack()
		{
			XSingleton<XEntityMgr>.singleton.Idled(this);
			XPresentComponent xpresentComponent = base.IsTransform ? base.Transformer.Present : base.Present;
			bool flag = xpresentComponent != null;
			if (flag)
			{
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && !string.IsNullOrEmpty(xpresentComponent.PresentLib.AttackIdle);
				if (flag2)
				{
					base.OverrideAnimClip("Idle", xpresentComponent.PresentLib.AttackIdle, true, false);
				}
				else
				{
					base.OverrideAnimClip("Idle", xpresentComponent.PresentLib.Idle, true, false);
				}
			}
		}

		private void AddMoveComponents()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			bool flag2 = !flag;
			if (flag2)
			{
				this._behit = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBeHitComponent.uuID) as XBeHitComponent);
			}
			bool flag3 = !flag;
			if (flag3)
			{
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFreezeComponent.uuID);
			}
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XIdleComponent.uuID);
			this._rotate = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XRotationComponent.uuID) as XRotationComponent);
			XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMoveComponent.uuID);
			bool flag4 = !flag;
			if (flag4)
			{
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XChargeComponent.uuID);
			}
		}

		public uint BasicTypeID
		{
			get
			{
				return this._attr.BasicTypeID;
			}
		}

		public override uint SkillCasterTypeID
		{
			get
			{
				return base.IsTransform ? this._transformer.TypeID : ((base.Skill != null && base.Skill.IsSkillReplaced) ? base.Skill.ReplacedByTypeID : 0U);
			}
		}

		public override bool CastFakeShadow()
		{
			return XQualitySetting.GetQuality(EFun.ERoleShadow);
		}

		private Vector3 _capsule1 = Vector3.zero;

		private Vector3 _capsule2 = Vector3.zero;

		public static int RoleLayer = LayerMask.NameToLayer("Role");
	}
}
