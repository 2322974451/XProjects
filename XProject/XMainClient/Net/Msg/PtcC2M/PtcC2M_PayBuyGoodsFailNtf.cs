using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_PayBuyGoodsFailNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 23670U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayBuyGoodsFail>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PayBuyGoodsFail>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public PayBuyGoodsFail Data = new PayBuyGoodsFail();
	}
}
