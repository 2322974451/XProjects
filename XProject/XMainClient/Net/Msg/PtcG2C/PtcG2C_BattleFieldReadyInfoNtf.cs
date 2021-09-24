using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BattleFieldReadyInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 40392U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldReadyInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleFieldReadyInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BattleFieldReadyInfoNtf.Process(this);
		}

		public BattleFieldReadyInfo Data = new BattleFieldReadyInfo();
	}
}
