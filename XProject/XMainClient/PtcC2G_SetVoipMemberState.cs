using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001281 RID: 4737
	internal class PtcC2G_SetVoipMemberState : Protocol
	{
		// Token: 0x0600DEDD RID: 57053 RVA: 0x00333C54 File Offset: 0x00331E54
		public override uint GetProtoType()
		{
			return 3881U;
		}

		// Token: 0x0600DEDE RID: 57054 RVA: 0x00333C6B File Offset: 0x00331E6B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetVoipMemberState>(stream, this.Data);
		}

		// Token: 0x0600DEDF RID: 57055 RVA: 0x00333C7B File Offset: 0x00331E7B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SetVoipMemberState>(stream);
		}

		// Token: 0x0600DEE0 RID: 57056 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400630B RID: 25355
		public SetVoipMemberState Data = new SetVoipMemberState();
	}
}
