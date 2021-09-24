using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_GmfJoinBattleC2MRes : Protocol
	{

		public override uint GetProtoType()
		{
			return 25047U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfJoinBattleRes>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfJoinBattleRes>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public GmfJoinBattleRes Data = new GmfJoinBattleRes();
	}
}
