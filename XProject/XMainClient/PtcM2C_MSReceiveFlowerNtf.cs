using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_MSReceiveFlowerNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 16969U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReceiveFlowerData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReceiveFlowerData>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_MSReceiveFlowerNtf.Process(this);
		}

		public ReceiveFlowerData Data = new ReceiveFlowerData();
	}
}
