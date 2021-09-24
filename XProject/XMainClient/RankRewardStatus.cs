using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class RankRewardStatus
	{

		public uint rank;

		public bool isRange;

		public SeqListRef<uint> reward = default(SeqListRef<uint>);
	}
}
