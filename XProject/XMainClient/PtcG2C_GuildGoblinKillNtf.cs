using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GuildGoblinKillNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 9436U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildGoblinSceneInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildGoblinSceneInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GuildGoblinKillNtf.Process(this);
		}

		public GuildGoblinSceneInfo Data = new GuildGoblinSceneInfo();
	}
}
