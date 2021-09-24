using System;
using System.IO;

namespace XMainClient
{

	internal class PtcG2C_FlowerRankRewardNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 14326U;
		}

		public override void Serialize(MemoryStream stream)
		{
		}

		public override void DeSerialize(MemoryStream stream)
		{
		}

		public override void Process()
		{
			Process_PtcG2C_FlowerRankRewardNtf.Process(this);
		}
	}
}
