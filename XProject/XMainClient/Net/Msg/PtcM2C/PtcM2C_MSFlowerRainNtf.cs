using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_MSFlowerRainNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 11986U;
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
			Process_PtcM2C_MSFlowerRainNtf.Process(this);
		}

		public ReceiveFlowerData Data = new ReceiveFlowerData();
	}
}
