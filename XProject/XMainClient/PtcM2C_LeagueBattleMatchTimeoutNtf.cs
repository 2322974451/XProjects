using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_LeagueBattleMatchTimeoutNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 31012U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleMatchTimeoutNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleMatchTimeoutNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_LeagueBattleMatchTimeoutNtf.Process(this);
		}

		public LeagueBattleMatchTimeoutNtf Data = new LeagueBattleMatchTimeoutNtf();
	}
}
