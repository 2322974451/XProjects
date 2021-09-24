using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_NextDayRewardReport : Protocol
	{

		public override uint GetProtoType()
		{
			return 1059U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NextDayRewardReport>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NextDayRewardReport>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public NextDayRewardReport Data = new NextDayRewardReport();
	}
}
