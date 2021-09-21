using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013EA RID: 5098
	internal class PtcM2C_UpdatePartnerToClient : Protocol
	{
		// Token: 0x0600E4AB RID: 58539 RVA: 0x0033BFCC File Offset: 0x0033A1CC
		public override uint GetProtoType()
		{
			return 63692U;
		}

		// Token: 0x0600E4AC RID: 58540 RVA: 0x0033BFE3 File Offset: 0x0033A1E3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdatePartnerToClient>(stream, this.Data);
		}

		// Token: 0x0600E4AD RID: 58541 RVA: 0x0033BFF3 File Offset: 0x0033A1F3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdatePartnerToClient>(stream);
		}

		// Token: 0x0600E4AE RID: 58542 RVA: 0x0033C002 File Offset: 0x0033A202
		public override void Process()
		{
			Process_PtcM2C_UpdatePartnerToClient.Process(this);
		}

		// Token: 0x0400642B RID: 25643
		public UpdatePartnerToClient Data = new UpdatePartnerToClient();
	}
}
