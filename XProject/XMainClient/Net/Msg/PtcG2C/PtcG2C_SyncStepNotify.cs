using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SyncStepNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 37999U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StepSyncInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data.StepFrame = 0U;
			this.Data.StepFrameSpecified = false;
			this.Data.DataList.Clear();
			Serializer.Merge<StepSyncInfo>(stream, this.Data);
		}

		public override void Process()
		{
			Process_PtcG2C_SyncStepNotify.Process(this);
		}

		public StepSyncInfo Data = new StepSyncInfo();
	}
}
