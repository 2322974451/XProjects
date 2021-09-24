using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_CheckinInfoNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 29332U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckinInfoNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CheckinInfoNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_CheckinInfoNotify.Process(this);
		}

		public CheckinInfoNotify Data = new CheckinInfoNotify();
	}
}
