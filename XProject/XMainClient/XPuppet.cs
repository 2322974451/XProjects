using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D49 RID: 3401
	internal sealed class XPuppet : XEnemy
	{
		// Token: 0x0600BC2A RID: 48170 RVA: 0x0026C8D4 File Offset: 0x0026AAD4
		public override bool Initilize(int flag)
		{
			base.Initilize(flag);
			this._eEntity_Type |= XEntity.EnitityType.Entity_Puppet;
			bool flag2 = (flag & XFastEnumIntEqualityComparer<XEntity.InitFlag>.ToInt(XEntity.InitFlag.Entity_Transform)) == 0;
			if (flag2)
			{
				this._audio = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAudioComponent.uuID) as XAudioComponent);
			}
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				base.IsServerFighting = true;
			}
			return true;
		}

		// Token: 0x0600BC2B RID: 48171 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void Move()
		{
		}
	}
}
