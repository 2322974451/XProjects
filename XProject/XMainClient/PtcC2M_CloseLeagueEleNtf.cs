using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_CloseLeagueEleNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 8195U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CloseLeagueEleNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CloseLeagueEleNtf>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public CloseLeagueEleNtf Data = new CloseLeagueEleNtf();
	}
}
