using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WatchBattleInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 23415U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WatchBattleData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WatchBattleData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WatchBattleInfoNtf.Process(this);
		}

		public WatchBattleData Data = new WatchBattleData();
	}
}
