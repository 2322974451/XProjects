using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_DeathNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 2319U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DeathInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DeathInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_DeathNotify.Process(this);
		}

		public DeathInfo Data = new DeathInfo();
	}
}
