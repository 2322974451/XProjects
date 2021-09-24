using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PvpBattleBeginNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 53763U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PvpBattleBeginData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PvpBattleBeginData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PvpBattleBeginNtf.Process(this);
		}

		public PvpBattleBeginData Data = new PvpBattleBeginData();
	}
}
