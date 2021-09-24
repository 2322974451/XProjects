using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GCFZhanLingNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 14402U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GCFZhanLingPara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GCFZhanLingPara>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GCFZhanLingNotify.Process(this);
		}

		public GCFZhanLingPara Data = new GCFZhanLingPara();
	}
}
