using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_DPSNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 36800U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DPSNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DPSNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_DPSNotify.Process(this);
		}

		public DPSNotify Data = new DPSNotify();
	}
}
