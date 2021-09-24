using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GSErrorNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 2031U;
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
			Process_PtcG2C_GSErrorNotify.Process(this);
		}

		public ErrorInfo Data = new ErrorInfo();
	}
}
