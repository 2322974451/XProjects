using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_MSErrorNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 48740U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ErrorInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ErrorInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_MSErrorNotify.Process(this);
		}

		public ErrorInfo Data = new ErrorInfo();
	}
}
