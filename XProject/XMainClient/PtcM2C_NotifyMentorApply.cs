using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NotifyMentorApply : Protocol
	{

		public override uint GetProtoType()
		{
			return 61023U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyMentorApplyData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyMentorApplyData>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NotifyMentorApply.Process(this);
		}

		public NotifyMentorApplyData Data = new NotifyMentorApplyData();
	}
}
