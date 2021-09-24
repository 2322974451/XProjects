using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ShareRandomGiftNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 18823U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ShareRandomGiftData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ShareRandomGiftData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ShareRandomGiftNtf.Process(this);
		}

		public ShareRandomGiftData Data = new ShareRandomGiftData();
	}
}
