using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SpActivityChangeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 24832U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpActivityChange>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SpActivityChange>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SpActivityChangeNtf.Process(this);
		}

		public SpActivityChange Data = new SpActivityChange();
	}
}
