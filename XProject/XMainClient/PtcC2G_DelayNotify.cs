using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_DelayNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 46829U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DelayInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DelayInfo>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public DelayInfo Data = new DelayInfo();
	}
}
