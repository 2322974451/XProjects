using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HeroBattleTipsNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 15389U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleTipsData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleTipsData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HeroBattleTipsNtf.Process(this);
		}

		public HeroBattleTipsData Data = new HeroBattleTipsData();
	}
}
