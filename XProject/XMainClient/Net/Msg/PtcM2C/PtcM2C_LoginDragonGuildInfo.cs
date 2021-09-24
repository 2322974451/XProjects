using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_LoginDragonGuildInfo : Protocol
	{

		public override uint GetProtoType()
		{
			return 21856U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MyDragonGuild>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MyDragonGuild>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_LoginDragonGuildInfo.Process(this);
		}

		public MyDragonGuild Data = new MyDragonGuild();
	}
}
