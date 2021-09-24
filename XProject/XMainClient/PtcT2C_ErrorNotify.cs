using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcT2C_ErrorNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 21940U;
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
			Process_PtcT2C_ErrorNotify.Process(this);
		}

		public ErrorInfo Data = new ErrorInfo();
	}
}
