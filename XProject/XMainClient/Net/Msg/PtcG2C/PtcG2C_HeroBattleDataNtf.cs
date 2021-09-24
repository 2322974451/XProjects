using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HeroBattleDataNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 60769U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HeroBattleDataNtf.Process(this);
		}

		public HeroBattleData Data = new HeroBattleData();
	}
}
