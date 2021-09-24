using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SkyCityEstimateRes : Protocol
	{

		public override uint GetProtoType()
		{
			return 36139U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityEstimateInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCityEstimateInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SkyCityEstimateRes.Process(this);
		}

		public SkyCityEstimateInfo Data = new SkyCityEstimateInfo();
	}
}
