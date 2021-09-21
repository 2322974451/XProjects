using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DBE RID: 3518
	internal sealed class XBoss : XOpposer
	{
		// Token: 0x0600BEA1 RID: 48801 RVA: 0x0027D5A0 File Offset: 0x0027B7A0
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

		// Token: 0x0600BEA2 RID: 48802 RVA: 0x0027D606 File Offset: 0x0027B806
		public override void Dying()
		{
			base.Dying();
		}

		// Token: 0x0600BEA3 RID: 48803 RVA: 0x0027D610 File Offset: 0x0027B810
		public override void OnDestroy()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Boss == this;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.Boss = null;
			}
			base.OnDestroy();
		}

		// Token: 0x0600BEA4 RID: 48804 RVA: 0x0027D642 File Offset: 0x0027B842
		public override void OnCreated()
		{
			base.OnCreated();
			XSingleton<XEntityMgr>.singleton.Boss = this;
		}
	}
}
