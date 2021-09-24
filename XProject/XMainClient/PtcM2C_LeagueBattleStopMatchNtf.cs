using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_LeagueBattleStopMatchNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 53912U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleStopMatchNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleStopMatchNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_LeagueBattleStopMatchNtf.Process(this);
		}

		public LeagueBattleStopMatchNtf Data = new LeagueBattleStopMatchNtf();
	}
}
