using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_UpdateBuyGoldAndFatigueInfo : Protocol
	{

		public override uint GetProtoType()
		{
			return 2587U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyGoldFatInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BuyGoldFatInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_UpdateBuyGoldAndFatigueInfo.Process(this);
		}

		public BuyGoldFatInfo Data = new BuyGoldFatInfo();
	}
}
