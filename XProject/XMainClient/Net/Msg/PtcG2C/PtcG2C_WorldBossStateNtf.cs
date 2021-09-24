using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WorldBossStateNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 5473U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldBossStateNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WorldBossStateNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WorldBossStateNtf.Process(this);
		}

		public WorldBossStateNtf Data = new WorldBossStateNtf();
	}
}
