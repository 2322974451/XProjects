using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001400 RID: 5120
	internal class PtcG2C_GCFZhanLingNotify : Protocol
	{
		// Token: 0x0600E504 RID: 58628 RVA: 0x0033C684 File Offset: 0x0033A884
		public override uint GetProtoType()
		{
			return 14402U;
		}

		// Token: 0x0600E505 RID: 58629 RVA: 0x0033C69B File Offset: 0x0033A89B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GCFZhanLingPara>(stream, this.Data);
		}

		// Token: 0x0600E506 RID: 58630 RVA: 0x0033C6AB File Offset: 0x0033A8AB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GCFZhanLingPara>(stream);
		}

		// Token: 0x0600E507 RID: 58631 RVA: 0x0033C6BA File Offset: 0x0033A8BA
		public override void Process()
		{
			Process_PtcG2C_GCFZhanLingNotify.Process(this);
		}

		// Token: 0x0400643C RID: 25660
		public GCFZhanLingPara Data = new GCFZhanLingPara();
	}
}
