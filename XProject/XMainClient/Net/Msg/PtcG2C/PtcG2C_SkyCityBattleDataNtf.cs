using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SkyCityBattleDataNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 51753U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityAllInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCityAllInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SkyCityBattleDataNtf.Process(this);
		}

		public SkyCityAllInfo Data = new SkyCityAllInfo();
	}
}
