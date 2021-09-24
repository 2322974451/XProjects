using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GmfWaitFightBegin : Protocol
	{

		public override uint GetProtoType()
		{
			return 59721U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfWaitFightArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfWaitFightArg>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GmfWaitFightBegin.Process(this);
		}

		public GmfWaitFightArg Data = new GmfWaitFightArg();
	}
}
