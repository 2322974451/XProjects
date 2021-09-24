using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NewGuildBonusNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 33515U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NewGuildBonusData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NewGuildBonusData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NewGuildBonusNtf.Process(this);
		}

		public NewGuildBonusData Data = new NewGuildBonusData();
	}
}
