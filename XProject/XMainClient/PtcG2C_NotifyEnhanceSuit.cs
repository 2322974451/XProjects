using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NotifyEnhanceSuit : Protocol
	{

		public override uint GetProtoType()
		{
			return 44091U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyEnhanceSuit>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyEnhanceSuit>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NotifyEnhanceSuit.Process(this);
		}

		public NotifyEnhanceSuit Data = new NotifyEnhanceSuit();
	}
}
