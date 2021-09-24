using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_TssSdkAntiDataNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 33482U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TssSdkAntiData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TssSdkAntiData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_TssSdkAntiDataNtf.Process(this);
		}

		public TssSdkAntiData Data = new TssSdkAntiData();
	}
}
