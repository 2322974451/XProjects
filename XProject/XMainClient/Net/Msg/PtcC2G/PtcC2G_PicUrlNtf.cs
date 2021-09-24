using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_PicUrlNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 30863U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PicUrlInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PicUrlInfo>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public PicUrlInfo Data = new PicUrlInfo();
	}
}
