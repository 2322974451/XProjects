using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_FightGroupChangeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 2142U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FightGroupChangeNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FightGroupChangeNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_FightGroupChangeNtf.Process(this);
		}

		public FightGroupChangeNtf Data = new FightGroupChangeNtf();
	}
}
