using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SceneDamageRankNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 26864U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneDamageRankNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SceneDamageRankNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SceneDamageRankNtf.Process(this);
		}

		public SceneDamageRankNtf Data = new SceneDamageRankNtf();
	}
}
