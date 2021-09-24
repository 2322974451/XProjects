using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_IBGiftTipsReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 29090U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBGiftTips>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IBGiftTips>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public IBGiftTips Data = new IBGiftTips();
	}
}
