using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HeroKillNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 58962U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroKillNotifyData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroKillNotifyData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HeroKillNotify.Process(this);
		}

		public HeroKillNotifyData Data = new HeroKillNotifyData();
	}
}
