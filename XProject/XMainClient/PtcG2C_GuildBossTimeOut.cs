using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GuildBossTimeOut : Protocol
	{

		public override uint GetProtoType()
		{
			return 56816U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBossTimeOut>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBossTimeOut>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GuildBossTimeOut.Process(this);
		}

		public GuildBossTimeOut Data = new GuildBossTimeOut();
	}
}
