using System;
using System.Collections.Generic;

namespace XMainClient
{

	public class EquipSuitMenuData : IComparable<EquipSuitMenuData>
	{

		public int CompareTo(EquipSuitMenuData _other)
		{
			return _other.quality - this.quality;
		}

		public bool show;

		public bool redpoint;

		public int quality;

		public List<EquipSuitMenuDataItem> list;
	}
}
