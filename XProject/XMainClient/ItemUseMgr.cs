using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CD5 RID: 3285
	internal class ItemUseMgr
	{
		// Token: 0x0600B843 RID: 47171 RVA: 0x00250668 File Offset: 0x0024E868
		public static uint GetItemUseValue(ItemUse type)
		{
			return (uint)XFastEnumIntEqualityComparer<ItemUse>.ToInt(type);
		}
	}
}
