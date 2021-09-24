using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_ShareReport : Protocol
	{

		public override uint GetProtoType()
		{
			return 31884U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ShareReportData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ShareReportData>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public ShareReportData Data = new ShareReportData();
	}
}
