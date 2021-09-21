using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012F8 RID: 4856
	internal class PtcC2M_OpenPrivateChatNtf : Protocol
	{
		// Token: 0x0600E0CB RID: 57547 RVA: 0x003369F4 File Offset: 0x00334BF4
		public override uint GetProtoType()
		{
			return 23206U;
		}

		// Token: 0x0600E0CC RID: 57548 RVA: 0x00336A0B File Offset: 0x00334C0B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OpenPrivateChat>(stream, this.Data);
		}

		// Token: 0x0600E0CD RID: 57549 RVA: 0x00336A1B File Offset: 0x00334C1B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OpenPrivateChat>(stream);
		}

		// Token: 0x0600E0CE RID: 57550 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400636C RID: 25452
		public OpenPrivateChat Data = new OpenPrivateChat();
	}
}
