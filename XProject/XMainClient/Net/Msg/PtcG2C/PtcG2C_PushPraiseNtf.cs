using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PushPraiseNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 5686U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PushPraise>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PushPraise>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PushPraiseNtf.Process(this);
		}

		public PushPraise Data = new PushPraise();
	}
}
