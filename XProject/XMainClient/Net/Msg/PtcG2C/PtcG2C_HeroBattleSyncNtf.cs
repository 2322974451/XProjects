using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_HeroBattleSyncNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 33024U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HeroBattleSyncData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HeroBattleSyncData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_HeroBattleSyncNtf.Process(this);
		}

		public HeroBattleSyncData Data = new HeroBattleSyncData();
	}
}
