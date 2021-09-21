using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001331 RID: 4913
	internal class RpcC2M_GardenBanquetAward : Rpc
	{
		// Token: 0x0600E1B1 RID: 57777 RVA: 0x00337F2C File Offset: 0x0033612C
		public override uint GetRpcType()
		{
			return 1091U;
		}

		// Token: 0x0600E1B2 RID: 57778 RVA: 0x00337F43 File Offset: 0x00336143
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BanquetAwardArg>(stream, this.oArg);
		}

		// Token: 0x0600E1B3 RID: 57779 RVA: 0x00337F53 File Offset: 0x00336153
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BanquetAwardRes>(stream);
		}

		// Token: 0x0600E1B4 RID: 57780 RVA: 0x00337F62 File Offset: 0x00336162
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenBanquetAward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E1B5 RID: 57781 RVA: 0x00337F7E File Offset: 0x0033617E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenBanquetAward.OnTimeout(this.oArg);
		}

		// Token: 0x04006397 RID: 25495
		public BanquetAwardArg oArg = new BanquetAwardArg();

		// Token: 0x04006398 RID: 25496
		public BanquetAwardRes oRes = null;
	}
}
