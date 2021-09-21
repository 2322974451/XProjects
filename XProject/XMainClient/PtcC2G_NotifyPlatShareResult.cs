using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001528 RID: 5416
	internal class PtcC2G_NotifyPlatShareResult : Protocol
	{
		// Token: 0x0600E9B8 RID: 59832 RVA: 0x003431F0 File Offset: 0x003413F0
		public override uint GetProtoType()
		{
			return 8480U;
		}

		// Token: 0x0600E9B9 RID: 59833 RVA: 0x00343207 File Offset: 0x00341407
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyPlatShareResultArg>(stream, this.Data);
		}

		// Token: 0x0600E9BA RID: 59834 RVA: 0x00343217 File Offset: 0x00341417
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyPlatShareResultArg>(stream);
		}

		// Token: 0x0600E9BB RID: 59835 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400651F RID: 25887
		public NotifyPlatShareResultArg Data = new NotifyPlatShareResultArg();
	}
}
