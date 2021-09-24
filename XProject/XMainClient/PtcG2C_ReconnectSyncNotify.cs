using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ReconnectSyncNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 42128U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReconectSync>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReconectSync>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ReconnectSyncNotify.Process(this);
		}

		public ReconectSync Data = new ReconectSync();
	}
}
