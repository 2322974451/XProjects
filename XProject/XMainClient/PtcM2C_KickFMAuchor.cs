using System;
using System.IO;

namespace XMainClient
{

	internal class PtcM2C_KickFMAuchor : Protocol
	{

		public override uint GetProtoType()
		{
			return 33806U;
		}

		public override void Serialize(MemoryStream stream)
		{
		}

		public override void DeSerialize(MemoryStream stream)
		{
		}

		public override void Process()
		{
			Process_PtcM2C_KickFMAuchor.Process(this);
		}
	}
}
