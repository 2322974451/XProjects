using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WorldBossGuildAddAttrSyncClientNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 65314U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldBossGuildAddAttrSyncClient>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WorldBossGuildAddAttrSyncClient>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WorldBossGuildAddAttrSyncClientNtf.Process(this);
		}

		public WorldBossGuildAddAttrSyncClient Data = new WorldBossGuildAddAttrSyncClient();
	}
}
