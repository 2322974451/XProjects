using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_RiskRecoverDiceNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 45917U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RiskRecoverDiceData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RiskRecoverDiceData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_RiskRecoverDiceNtf.Process(this);
		}

		public RiskRecoverDiceData Data = new RiskRecoverDiceData();
	}
}
