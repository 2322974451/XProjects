using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_GuildCardMatchReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 21904U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCardMatchReq>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCardMatchReq>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public GuildCardMatchReq Data = new GuildCardMatchReq();
	}
}
