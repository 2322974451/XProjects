using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_AllGiftIBItemNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 2916U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AllGiftIBItem>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AllGiftIBItem>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_AllGiftIBItemNtf.Process(this);
		}

		public AllGiftIBItem Data = new AllGiftIBItem();
	}
}
