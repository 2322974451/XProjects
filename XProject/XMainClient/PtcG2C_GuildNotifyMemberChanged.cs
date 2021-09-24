using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GuildNotifyMemberChanged : Protocol
	{

		public override uint GetProtoType()
		{
			return 5957U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildMemberInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildMemberInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GuildNotifyMemberChanged.Process(this);
		}

		public GuildMemberInfo Data = new GuildMemberInfo();
	}
}
