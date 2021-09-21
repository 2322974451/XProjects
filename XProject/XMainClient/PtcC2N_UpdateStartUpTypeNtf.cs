using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200143D RID: 5181
	internal class PtcC2N_UpdateStartUpTypeNtf : Protocol
	{
		// Token: 0x0600E5FD RID: 58877 RVA: 0x0033DB84 File Offset: 0x0033BD84
		public override uint GetProtoType()
		{
			return 60574U;
		}

		// Token: 0x0600E5FE RID: 58878 RVA: 0x0033DB9B File Offset: 0x0033BD9B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateStartUpType>(stream, this.Data);
		}

		// Token: 0x0600E5FF RID: 58879 RVA: 0x0033DBAB File Offset: 0x0033BDAB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateStartUpType>(stream);
		}

		// Token: 0x0600E600 RID: 58880 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400646B RID: 25707
		public UpdateStartUpType Data = new UpdateStartUpType();
	}
}
