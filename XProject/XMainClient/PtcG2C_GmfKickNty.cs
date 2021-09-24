using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GmfKickNty : Protocol
	{

		public override uint GetProtoType()
		{
			return 21295U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfKickRes>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfKickRes>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GmfKickNty.Process(this);
		}

		public GmfKickRes Data = new GmfKickRes();
	}
}
