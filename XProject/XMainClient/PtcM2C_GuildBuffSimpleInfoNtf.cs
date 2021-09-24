using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GuildBuffSimpleInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 57161U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBuffSimpleAllInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBuffSimpleAllInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GuildBuffSimpleInfoNtf.Process(this);
		}

		public GuildBuffSimpleAllInfo Data = new GuildBuffSimpleAllInfo();
	}
}
