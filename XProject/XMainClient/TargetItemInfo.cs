using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	public class TargetItemInfo
	{

		public List<GoalAwards.RowData> subItems = new List<GoalAwards.RowData>();

		public uint goalAwardsID;

		public uint doneIndex;

		public uint gottenAwardsIndex;

		public uint minLevel;

		public double totalvalue;
	}
}
