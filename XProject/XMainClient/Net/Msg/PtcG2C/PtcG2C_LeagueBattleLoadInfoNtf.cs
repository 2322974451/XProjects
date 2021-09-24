using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_LeagueBattleLoadInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 16091U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleLoadInfoNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleLoadInfoNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_LeagueBattleLoadInfoNtf.Process(this);
		}

		public LeagueBattleLoadInfoNtf Data = new LeagueBattleLoadInfoNtf();
	}
}
