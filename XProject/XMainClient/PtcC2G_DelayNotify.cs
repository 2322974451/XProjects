using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010B0 RID: 4272
	internal class PtcC2G_DelayNotify : Protocol
	{
		// Token: 0x0600D77B RID: 55163 RVA: 0x0032815C File Offset: 0x0032635C
		public override uint GetProtoType()
		{
			return 46829U;
		}

		// Token: 0x0600D77C RID: 55164 RVA: 0x00328173 File Offset: 0x00326373
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DelayInfo>(stream, this.Data);
		}

		// Token: 0x0600D77D RID: 55165 RVA: 0x00328183 File Offset: 0x00326383
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DelayInfo>(stream);
		}

		// Token: 0x0600D77E RID: 55166 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040061A9 RID: 25001
		public DelayInfo Data = new DelayInfo();
	}
}
