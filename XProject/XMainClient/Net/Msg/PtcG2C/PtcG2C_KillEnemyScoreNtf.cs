using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_KillEnemyScoreNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 50119U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<KillEnemyScoreData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<KillEnemyScoreData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_KillEnemyScoreNtf.Process(this);
		}

		public KillEnemyScoreData Data = new KillEnemyScoreData();
	}
}
