using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200126B RID: 4715
	internal class PtcG2C_NotifyEnhanceSuit : Protocol
	{
		// Token: 0x0600DE88 RID: 56968 RVA: 0x00333658 File Offset: 0x00331858
		public override uint GetProtoType()
		{
			return 44091U;
		}

		// Token: 0x0600DE89 RID: 56969 RVA: 0x0033366F File Offset: 0x0033186F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyEnhanceSuit>(stream, this.Data);
		}

		// Token: 0x0600DE8A RID: 56970 RVA: 0x0033367F File Offset: 0x0033187F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyEnhanceSuit>(stream);
		}

		// Token: 0x0600DE8B RID: 56971 RVA: 0x0033368E File Offset: 0x0033188E
		public override void Process()
		{
			Process_PtcG2C_NotifyEnhanceSuit.Process(this);
		}

		// Token: 0x040062FC RID: 25340
		public NotifyEnhanceSuit Data = new NotifyEnhanceSuit();
	}
}
