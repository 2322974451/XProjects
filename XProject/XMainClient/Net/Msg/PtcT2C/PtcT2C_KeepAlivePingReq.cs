using System;
using System.IO;

namespace XMainClient
{

	internal class PtcT2C_KeepAlivePingReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 49142U;
		}

		public override void Serialize(MemoryStream stream)
		{
		}

		public override void DeSerialize(MemoryStream stream)
		{
		}

		public override void Process()
		{
			Process_PtcT2C_KeepAlivePingReq.Process(this);
		}
	}
}
