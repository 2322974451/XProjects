using System;
using System.IO;

namespace XMainClient
{

	internal class PtcG2C_HorseFailTipsNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 2357U;
		}

		public override void Serialize(MemoryStream stream)
		{
		}

		public override void DeSerialize(MemoryStream stream)
		{
		}

		public override void Process()
		{
			Process_PtcG2C_HorseFailTipsNtf.Process(this);
		}
	}
}
