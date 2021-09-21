using System;

namespace XMainClient
{
	// Token: 0x02000D45 RID: 3397
	internal sealed class XElite : XOpposer
	{
		// Token: 0x0600BC1C RID: 48156 RVA: 0x0026C584 File Offset: 0x0026A784
		public override bool Initilize(int flag)
		{
			base.Initilize(flag);
			this._eEntity_Type |= XEntity.EnitityType.Entity_Elite;
			return true;
		}
	}
}
