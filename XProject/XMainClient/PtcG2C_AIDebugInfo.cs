using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_AIDebugInfo : Protocol
	{

		public override uint GetProtoType()
		{
			return 60081U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AIDebugMsg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AIDebugMsg>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_AIDebugInfo.Process(this);
		}

		public AIDebugMsg Data = new AIDebugMsg();
	}
}
