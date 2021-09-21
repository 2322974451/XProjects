using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001013 RID: 4115
	internal class PtcG2C_OpenSystemNtf : Protocol
	{
		// Token: 0x0600D4F3 RID: 54515 RVA: 0x00322998 File Offset: 0x00320B98
		public override uint GetProtoType()
		{
			return 41168U;
		}

		// Token: 0x0600D4F4 RID: 54516 RVA: 0x003229AF File Offset: 0x00320BAF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<Systems>(stream, this.Data);
		}

		// Token: 0x0600D4F5 RID: 54517 RVA: 0x003229BF File Offset: 0x00320BBF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<Systems>(stream);
		}

		// Token: 0x0600D4F6 RID: 54518 RVA: 0x003229CE File Offset: 0x00320BCE
		public override void Process()
		{
			Process_PtcG2C_OpenSystemNtf.Process(this);
		}

		// Token: 0x04006109 RID: 24841
		public Systems Data = new Systems();
	}
}
