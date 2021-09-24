using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSubstance : XEntity
	{

		public override bool Initilize(int flag)
		{
			this._eEntity_Type |= XEntity.EnitityType.Entity_Substance;
			this._present = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPresentComponent.uuID) as XPresentComponent);
			this._machine = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XStateMachine.uuID) as XStateMachine);
			XIdleComponent defaultState = XSingleton<XComponentMgr>.singleton.CreateComponent(this, XIdleComponent.uuID) as XIdleComponent;
			this._death = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XDeathComponent.uuID) as XDeathComponent);
			this._machine.SetDefaultState(defaultState);
			bool flag2 = (flag & XFastEnumIntEqualityComparer<XEntity.InitFlag>.ToInt(XEntity.InitFlag.Entity_Transform)) == 0;
			if (flag2)
			{
				this._net = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XNetComponent.uuID) as XNetComponent);
			}
			return true;
		}

		protected override void Move()
		{
		}

		public override void Died()
		{
			bool flag = this.Attributes.TypeID == 5001U;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.DestroyEntity(this);
			}
		}
	}
}
