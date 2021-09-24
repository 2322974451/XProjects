using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_LeagueBattleStartMatchNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 61870U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleStartMatchNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleStartMatchNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_LeagueBattleStartMatchNtf.Process(this);
		}

		public LeagueBattleStartMatchNtf Data = new LeagueBattleStartMatchNtf();
	}
}
