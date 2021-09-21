using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011E8 RID: 4584
	internal class PtcM2C_InviteRefuseM2CNtf : Protocol
	{
		// Token: 0x0600DC66 RID: 56422 RVA: 0x003304E0 File Offset: 0x0032E6E0
		public override uint GetProtoType()
		{
			return 33486U;
		}

		// Token: 0x0600DC67 RID: 56423 RVA: 0x003304F7 File Offset: 0x0032E6F7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InviteRufuse>(stream, this.Data);
		}

		// Token: 0x0600DC68 RID: 56424 RVA: 0x00330507 File Offset: 0x0032E707
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<InviteRufuse>(stream);
		}

		// Token: 0x0600DC69 RID: 56425 RVA: 0x00330516 File Offset: 0x0032E716
		public override void Process()
		{
			Process_PtcM2C_InviteRefuseM2CNtf.Process(this);
		}

		// Token: 0x04006290 RID: 25232
		public InviteRufuse Data = new InviteRufuse();
	}
}
