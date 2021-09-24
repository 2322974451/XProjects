using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_GuildCardRankReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 50768U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCardRankReq>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCardRankReq>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public GuildCardRankReq Data = new GuildCardRankReq();
	}
}
