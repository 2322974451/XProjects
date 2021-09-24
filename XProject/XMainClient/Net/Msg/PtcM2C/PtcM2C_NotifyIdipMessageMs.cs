using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NotifyIdipMessageMs : Protocol
	{

		public override uint GetProtoType()
		{
			return 48558U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IdipMessage>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IdipMessage>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NotifyIdipMessageMs.Process(this);
		}

		public IdipMessage Data = new IdipMessage();
	}
}
