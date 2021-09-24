using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_TransNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 15935U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TransNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TransNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_TransNotify.Process(this);
		}

		public TransNotify Data = new TransNotify();
	}
}
