using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_VsPayReviveNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 8168U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<VsPayRevivePara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<VsPayRevivePara>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_VsPayReviveNtf.Process(this);
		}

		public VsPayRevivePara Data = new VsPayRevivePara();
	}
}
