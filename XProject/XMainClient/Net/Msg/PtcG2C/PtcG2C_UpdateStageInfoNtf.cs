using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_UpdateStageInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 21189U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateStageInfoNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateStageInfoNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_UpdateStageInfoNtf.Process(this);
		}

		public UpdateStageInfoNtf Data = new UpdateStageInfoNtf();
	}
}
