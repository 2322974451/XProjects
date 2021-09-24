using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GmfBattleStateNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 21747U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfBatlleStatePara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfBatlleStatePara>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GmfBattleStateNtf.Process(this);
		}

		public GmfBatlleStatePara Data = new GmfBatlleStatePara();
	}
}
