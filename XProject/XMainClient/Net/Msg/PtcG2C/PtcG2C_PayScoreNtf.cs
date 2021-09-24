using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PayScoreNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 61859U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayScoreData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PayScoreData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PayScoreNtf.Process(this);
		}

		public PayScoreData Data = new PayScoreData();
	}
}
