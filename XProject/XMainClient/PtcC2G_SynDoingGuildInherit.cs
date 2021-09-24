using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_SynDoingGuildInherit : Protocol
	{

		public override uint GetProtoType()
		{
			return 51759U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynDoingGuildInherit>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SynDoingGuildInherit>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public SynDoingGuildInherit Data = new SynDoingGuildInherit();
	}
}
