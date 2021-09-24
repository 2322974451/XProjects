using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NotifyMarriageDivorceApply : Protocol
	{

		public override uint GetProtoType()
		{
			return 32886U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyMarriageDivorceApplyData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyMarriageDivorceApplyData>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NotifyMarriageDivorceApply.Process(this);
		}

		public NotifyMarriageDivorceApplyData Data = new NotifyMarriageDivorceApplyData();
	}
}
