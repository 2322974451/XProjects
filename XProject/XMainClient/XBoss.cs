using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XBoss : XOpposer
	{

		public override bool Initilize(int flag)
		{
			base.Initilize(flag);
			this._eEntity_Type |= XEntity.EnitityType.Entity_Boss;
			this._layer = LayerMask.NameToLayer("BigGuy");
			bool flag2 = (flag & XFastEnumIntEqualityComparer<XEntity.InitFlag>.ToInt(XEntity.InitFlag.Entity_Transform)) == 0;
			if (flag2)
			{
				this._qte = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XQuickTimeEventComponent.uuID) as XQuickTimeEventComponent);
			}
			return true;
		}

		public override void Dying()
		{
			base.Dying();
		}

		public override void OnDestroy()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Boss == this;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.Boss = null;
			}
			base.OnDestroy();
		}

		public override void OnCreated()
		{
			base.OnCreated();
			XSingleton<XEntityMgr>.singleton.Boss = this;
		}
	}
}
