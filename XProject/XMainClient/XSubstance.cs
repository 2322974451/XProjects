using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D47 RID: 3399
	internal class XSubstance : XEntity
	{
		// Token: 0x0600BC24 RID: 48164 RVA: 0x0026C670 File Offset: 0x0026A870
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

		// Token: 0x0600BC25 RID: 48165 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void Move()
		{
		}

		// Token: 0x0600BC26 RID: 48166 RVA: 0x0026C738 File Offset: 0x0026A938
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
