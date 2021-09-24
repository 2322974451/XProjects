using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ItemUseMgr
	{

		public static uint GetItemUseValue(ItemUse type)
		{
			return (uint)XFastEnumIntEqualityComparer<ItemUse>.ToInt(type);
		}
	}
}
