using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GmfJoinBattleReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 19954U;
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
			Process_PtcG2C_GmfJoinBattleReq.Process(this);
		}

		public GmfJoinBattleArg Data = new GmfJoinBattleArg();
	}
}
