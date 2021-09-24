using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NotifyMarriageApply : Protocol
	{

		public override uint GetProtoType()
		{
			return 42923U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyMarriageApplyData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyMarriageApplyData>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NotifyMarriageApply.Process(this);
		}

		public NotifyMarriageApplyData Data = new NotifyMarriageApplyData();
	}
}
