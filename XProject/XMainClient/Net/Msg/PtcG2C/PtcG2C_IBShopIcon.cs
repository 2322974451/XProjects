using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_IBShopIcon : Protocol
	{

		public override uint GetProtoType()
		{
			return 56800U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBShopIcon>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IBShopIcon>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_IBShopIcon.Process(this);
		}

		public IBShopIcon Data = new IBShopIcon();
	}
}
