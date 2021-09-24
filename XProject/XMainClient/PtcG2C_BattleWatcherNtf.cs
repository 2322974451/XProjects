using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BattleWatcherNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 54652U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleWatcherNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleWatcherNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BattleWatcherNtf.Process(this);
		}

		public BattleWatcherNtf Data = new BattleWatcherNtf();
	}
}
