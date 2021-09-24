using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SyncMoveNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 32838U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StepMoveData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<StepMoveData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SyncMoveNotify.Process(this);
		}

		public StepMoveData Data = new StepMoveData();
	}
}
