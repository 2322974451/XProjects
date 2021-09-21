using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200129F RID: 4767
	internal class PtcM2C_NotifyIdipMessageMs : Protocol
	{
		// Token: 0x0600DF5D RID: 57181 RVA: 0x00334814 File Offset: 0x00332A14
		public override uint GetProtoType()
		{
			return 48558U;
		}

		// Token: 0x0600DF5E RID: 57182 RVA: 0x0033482B File Offset: 0x00332A2B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IdipMessage>(stream, this.Data);
		}

		// Token: 0x0600DF5F RID: 57183 RVA: 0x0033483B File Offset: 0x00332A3B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IdipMessage>(stream);
		}

		// Token: 0x0600DF60 RID: 57184 RVA: 0x0033484A File Offset: 0x00332A4A
		public override void Process()
		{
			Process_PtcM2C_NotifyIdipMessageMs.Process(this);
		}

		// Token: 0x04006325 RID: 25381
		public IdipMessage Data = new IdipMessage();
	}
}
