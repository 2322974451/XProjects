using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013C4 RID: 5060
	internal class PtcG2C_AntiAddictionRemindNtf : Protocol
	{
		// Token: 0x0600E40D RID: 58381 RVA: 0x0033B2C4 File Offset: 0x003394C4
		public override uint GetProtoType()
		{
			return 17999U;
		}

		// Token: 0x0600E40E RID: 58382 RVA: 0x0033B2DB File Offset: 0x003394DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AntiAddictionRemindInfo>(stream, this.Data);
		}

		// Token: 0x0600E40F RID: 58383 RVA: 0x0033B2EB File Offset: 0x003394EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AntiAddictionRemindInfo>(stream);
		}

		// Token: 0x0600E410 RID: 58384 RVA: 0x0033B2FA File Offset: 0x003394FA
		public override void Process()
		{
			Process_PtcG2C_AntiAddictionRemindNtf.Process(this);
		}

		// Token: 0x0400640C RID: 25612
		public AntiAddictionRemindInfo Data = new AntiAddictionRemindInfo();
	}
}
