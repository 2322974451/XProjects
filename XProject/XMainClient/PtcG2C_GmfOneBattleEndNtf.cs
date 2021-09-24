using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GmfOneBattleEndNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 61740U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfOneBattleEnd>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfOneBattleEnd>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GmfOneBattleEndNtf.Process(this);
		}

		public GmfOneBattleEnd Data = new GmfOneBattleEnd();
	}
}
