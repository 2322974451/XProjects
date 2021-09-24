using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_LoginGuildInfo : Protocol
	{

		public override uint GetProtoType()
		{
			return 29049U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MyGuild>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MyGuild>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_LoginGuildInfo.Process(this);
		}

		public MyGuild Data = new MyGuild();
	}
}
