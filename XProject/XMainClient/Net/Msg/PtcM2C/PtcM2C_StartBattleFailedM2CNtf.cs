using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_StartBattleFailedM2CNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 20444U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StartBattleFailedRes>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<StartBattleFailedRes>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_StartBattleFailedM2CNtf.Process(this);
		}

		public StartBattleFailedRes Data = new StartBattleFailedRes();
	}
}
