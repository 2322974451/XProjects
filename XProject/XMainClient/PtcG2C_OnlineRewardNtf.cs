using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_OnlineRewardNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 1895U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OnlineRewardNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OnlineRewardNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_OnlineRewardNtf.Process(this);
		}

		public OnlineRewardNtf Data = new OnlineRewardNtf();
	}
}
