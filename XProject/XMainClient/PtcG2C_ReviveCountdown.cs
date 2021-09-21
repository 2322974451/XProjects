using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001061 RID: 4193
	internal class PtcG2C_ReviveCountdown : Protocol
	{
		// Token: 0x0600D63E RID: 54846 RVA: 0x00325D64 File Offset: 0x00323F64
		public override uint GetProtoType()
		{
			return 54507U;
		}

		// Token: 0x0600D63F RID: 54847 RVA: 0x00325D7B File Offset: 0x00323F7B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReviveCountdownInfo>(stream, this.Data);
		}

		// Token: 0x0600D640 RID: 54848 RVA: 0x00325D8B File Offset: 0x00323F8B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ReviveCountdownInfo>(stream);
		}

		// Token: 0x0600D641 RID: 54849 RVA: 0x00325D9A File Offset: 0x00323F9A
		public override void Process()
		{
			Process_PtcG2C_ReviveCountdown.Process(this);
		}

		// Token: 0x0400616F RID: 24943
		public ReviveCountdownInfo Data = new ReviveCountdownInfo();
	}
}
