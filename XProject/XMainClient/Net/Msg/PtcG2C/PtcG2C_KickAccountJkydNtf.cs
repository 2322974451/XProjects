using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_KickAccountJkydNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 39286U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<KickAccountJkydMsg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<KickAccountJkydMsg>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_KickAccountJkydNtf.Process(this);
		}

		public KickAccountJkydMsg Data = new KickAccountJkydMsg();
	}
}
