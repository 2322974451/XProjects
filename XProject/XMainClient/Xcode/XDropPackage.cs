using System;

namespace XMainClient
{

	internal class XDropPackage
	{

		public void Reset()
		{
			this.money = 0U;
			this.weapon_count = 0U;
			this.armor_count = 0U;
		}

		public uint money;

		public uint weapon_count;

		public uint armor_count;
	}
}
