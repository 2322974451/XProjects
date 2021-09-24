using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_CdCall : Protocol
	{

		public override uint GetProtoType()
		{
			return 34744U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CallData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CallData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_CdCall.Process(this);
		}

		public CallData Data = new CallData();
	}
}
