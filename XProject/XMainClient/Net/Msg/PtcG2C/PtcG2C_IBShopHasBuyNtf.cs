using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_IBShopHasBuyNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 12835U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBShopHasBuy>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IBShopHasBuy>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_IBShopHasBuyNtf.Process(this);
		}

		public IBShopHasBuy Data = new IBShopHasBuy();
	}
}
