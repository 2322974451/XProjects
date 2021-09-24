using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_BattleLogReport : Protocol
	{

		public override uint GetProtoType()
		{
			return 10382U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleLogReport>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleLogReport>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public BattleLogReport Data = new BattleLogReport();
	}
}
