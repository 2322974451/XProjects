using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_RiskBuyNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 61237U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RiskBuyData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RiskBuyData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_RiskBuyNtf.Process(this);
		}

		public RiskBuyData Data = new RiskBuyData();
	}
}
