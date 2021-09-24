using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GmfJoinBattleM2CReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 63969U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfJoinBattleArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfJoinBattleArg>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GmfJoinBattleM2CReq.Process(this);
		}

		public GmfJoinBattleArg Data = new GmfJoinBattleArg();
	}
}
