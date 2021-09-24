using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_ClickGuildCamp : Protocol
	{

		public override uint GetProtoType()
		{
			return 32895U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClickGuildCampArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ClickGuildCampArg>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public ClickGuildCampArg Data = new ClickGuildCampArg();
	}
}
