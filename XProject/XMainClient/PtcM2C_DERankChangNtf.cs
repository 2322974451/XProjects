using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012B3 RID: 4787
	internal class PtcM2C_DERankChangNtf : Protocol
	{
		// Token: 0x0600DFAB RID: 57259 RVA: 0x00334F14 File Offset: 0x00333114
		public override uint GetProtoType()
		{
			return 11404U;
		}

		// Token: 0x0600DFAC RID: 57260 RVA: 0x00334F2B File Offset: 0x0033312B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DERankChangePara>(stream, this.Data);
		}

		// Token: 0x0600DFAD RID: 57261 RVA: 0x00334F3B File Offset: 0x0033313B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DERankChangePara>(stream);
		}

		// Token: 0x0600DFAE RID: 57262 RVA: 0x00334F4A File Offset: 0x0033314A
		public override void Process()
		{
			Process_PtcM2C_DERankChangNtf.Process(this);
		}

		// Token: 0x04006333 RID: 25395
		public DERankChangePara Data = new DERankChangePara();
	}
}
