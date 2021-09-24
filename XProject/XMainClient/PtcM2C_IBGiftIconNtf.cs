using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_IBGiftIconNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 44659U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBGiftIcon>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IBGiftIcon>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_IBGiftIconNtf.Process(this);
		}

		public IBGiftIcon Data = new IBGiftIcon();
	}
}
