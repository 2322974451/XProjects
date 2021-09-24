using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BattleResultNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 29609U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NewBattleResult>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NewBattleResult>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BattleResultNtf.Process(this);
		}

		public NewBattleResult Data = new NewBattleResult();
	}
}
