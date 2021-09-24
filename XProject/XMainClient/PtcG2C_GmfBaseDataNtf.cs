using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GmfBaseDataNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 4338U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfRoleDatas>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfRoleDatas>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GmfBaseDataNtf.Process(this);
		}

		public GmfRoleDatas Data = new GmfRoleDatas();
	}
}
