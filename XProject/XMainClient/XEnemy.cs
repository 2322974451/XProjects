using System;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XEnemy : XEntity
	{

		public override bool Initilize(int flag)
		{
			this._eEntity_Type |= XEntity.EnitityType.Entity_Enemy;
			this._using_cc_move = false;
			this._present = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPresentComponent.uuID) as XPresentComponent);
			this._machine = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XStateMachine.uuID) as XStateMachine);
			this._other_attr = (this.Attributes as XOthersAttributes);
			this._layer = (this._other_attr.Blocked ? LayerMask.NameToLayer("BigGuy") : LayerMask.NameToLayer("Enemy"));
			XIdleComponent defaultState = XSingleton<XComponentMgr>.singleton.CreateComponent(this, XIdleComponent.uuID) as XIdleComponent;
			this._death = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDeathComponent.uuID) as XDeathComponent);
			this._machine.SetDefaultState(defaultState);
			this._behit = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBeHitComponent.uuID) as XBeHitComponent);
			bool flag2 = this._other_attr.FashionTemplate > 0U;
			if (flag2)
			{
				this._equip = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XEquipComponent.uuID) as XEquipComponent);
			}
			bool flag3 = this._equip != null;
			if (flag3)
			{
				this._equip.IsUIAvatar = false;
			}
			bool flag4 = (flag & XFastEnumIntEqualityComparer<XEntity.InitFlag>.ToInt(XEntity.InitFlag.Entity_Transform)) == 0;
			if (flag4)
			{
				bool flag5 = this._present != null && this._present.PresentLib.Shadow;
				if (flag5)
				{
					XSingleton<XComponentMgr>.singleton.CreateComponent(this, XShadowComponent.uuID);
				}
				this._skill = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSkillComponent.uuID) as XSkillComponent);
				this._net = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XNetComponent.uuID) as XNetComponent);
				bool flag6 = this._other_attr.FloatingMax > 0f;
				if (flag6)
				{
					this._fly = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFlyComponent.uuID) as XFlyComponent);
				}
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XFreezeComponent.uuID);
				bool flag7 = this.Attributes.GetAttr(XAttributeDefine.XAttr_MaxSuperArmor_Basic) > 0.0 && this.Attributes.SuperArmorRecoveryTimeLimit > 0.0;
				if (flag7)
				{
					XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSuperArmorComponent.uuID);
				}
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XWoozyComponent.uuID);
			}
			return true;
		}

		public override void Uninitilize()
		{
			base.Uninitilize();
		}

		public override void OnCreated()
		{
			this._render = XRenderComponent.AddRenderComponent(this);
			bool flag = this._render != null;
			if (flag)
			{
				this._render.SetEntityLayer(this._layer);
				this._render.PostCreateComponent();
			}
			bool flag2 = this.Attributes.Type != EntitySpecies.Species_Puppet && this._transformee == null;
			if (flag2)
			{
				bool flag3 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA && this._other_attr.SameBillBoardByMaster;
				if (flag3)
				{
					XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMobaBillboardComponent.uuID);
				}
				else
				{
					this._billboard = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBillboardComponent.uuID) as XBillboardComponent);
				}
			}
			base.OnCreated();
		}

		public override bool IsFighting
		{
			get
			{
				bool flag = this._ai == null;
				return !flag && this._ai.IsFighting;
			}
		}

		public override bool HasAI
		{
			get
			{
				return this._ai != null;
			}
		}

		public override bool CastFakeShadow()
		{
			return XQualitySetting.GetQuality(EFun.EEnemyShadow);
		}

		private Ray _rayVer = new Ray(Vector3.zero, Vector3.down);

		private Vector3 _lastSrc = Vector3.zero;

		private Vector3 _lastRes = Vector3.zero;

		protected XOthersAttributes _other_attr = null;
	}
}
