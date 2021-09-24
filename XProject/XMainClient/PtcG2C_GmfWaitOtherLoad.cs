using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GmfWaitOtherLoad : Protocol
	{

		public override uint GetProtoType()
		{
			return 1133U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfWaitOtherArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfWaitOtherArg>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GmfWaitOtherLoad.Process(this);
		}

		public GmfWaitOtherArg Data = new GmfWaitOtherArg();
	}
}
