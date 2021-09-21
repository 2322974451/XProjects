using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011F5 RID: 4597
	internal class PtcM2C_RoleMatchStateM2CNotify : Protocol
	{
		// Token: 0x0600DC9B RID: 56475 RVA: 0x003309CC File Offset: 0x0032EBCC
		public override uint GetProtoType()
		{
			return 11521U;
		}

		// Token: 0x0600DC9C RID: 56476 RVA: 0x003309E3 File Offset: 0x0032EBE3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RoleStateMatch>(stream, this.Data);
		}

		// Token: 0x0600DC9D RID: 56477 RVA: 0x003309F3 File Offset: 0x0032EBF3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RoleStateMatch>(stream);
		}

		// Token: 0x0600DC9E RID: 56478 RVA: 0x00330A02 File Offset: 0x0032EC02
		public override void Process()
		{
			Process_PtcM2C_RoleMatchStateM2CNotify.Process(this);
		}

		// Token: 0x0400629A RID: 25242
		public RoleStateMatch Data = new RoleStateMatch();
	}
}
