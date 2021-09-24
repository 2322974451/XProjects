using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_QANotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 37337U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QANotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QANotify>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_QANotify.Process(this);
		}

		public QANotify Data = new QANotify();
	}
}
