using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GuildBuffSimpleItemNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 63964U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBuffSimpleItem>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBuffSimpleItem>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GuildBuffSimpleItemNtf.Process(this);
		}

		public GuildBuffSimpleItem Data = new GuildBuffSimpleItem();
	}
}
