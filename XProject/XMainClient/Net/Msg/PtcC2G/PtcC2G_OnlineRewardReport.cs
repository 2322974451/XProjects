using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_OnlineRewardReport : Protocol
	{

		public override uint GetProtoType()
		{
			return 36178U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OnlineRewardReport>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OnlineRewardReport>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public OnlineRewardReport Data = new OnlineRewardReport();
	}
}
