using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2N_UpdateStartUpTypeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 60574U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateStartUpType>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateStartUpType>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public UpdateStartUpType Data = new UpdateStartUpType();
	}
}
