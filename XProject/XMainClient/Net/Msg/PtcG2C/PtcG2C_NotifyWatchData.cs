using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NotifyWatchData : Protocol
	{

		public override uint GetProtoType()
		{
			return 16154U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OneLiveRecordInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OneLiveRecordInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NotifyWatchData.Process(this);
		}

		public OneLiveRecordInfo Data = new OneLiveRecordInfo();
	}
}
