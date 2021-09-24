using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NotifyIdipMessageGs : Protocol
	{

		public override uint GetProtoType()
		{
			return 59353U;
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
			Process_PtcG2C_NotifyIdipMessageGs.Process(this);
		}

		public IdipMessage Data = new IdipMessage();
	}
}
