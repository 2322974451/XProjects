using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_RemoveIBShopIcon : Protocol
	{

		public override uint GetProtoType()
		{
			return 33988U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RemoveIBShopIcon>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RemoveIBShopIcon>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public RemoveIBShopIcon Data = new RemoveIBShopIcon();
	}
}
