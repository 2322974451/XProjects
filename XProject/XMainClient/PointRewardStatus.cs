using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class PointRewardStatus
	{

		public uint point;

		public uint status;

		public SeqListRef<uint> reward = default(SeqListRef<uint>);
	}
}
