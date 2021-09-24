using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NpcFlNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 18961U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NpcFlRes>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NpcFlRes>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NpcFlNtf.Process(this);
		}

		public NpcFlRes Data = new NpcFlRes();
	}
}
