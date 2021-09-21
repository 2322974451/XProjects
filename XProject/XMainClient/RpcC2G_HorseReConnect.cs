using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013F8 RID: 5112
	internal class RpcC2G_HorseReConnect : Rpc
	{
		// Token: 0x0600E4E4 RID: 58596 RVA: 0x0033C410 File Offset: 0x0033A610
		public override uint GetRpcType()
		{
			return 7786U;
		}

		// Token: 0x0600E4E5 RID: 58597 RVA: 0x0033C427 File Offset: 0x0033A627
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseReConnectArg>(stream, this.oArg);
		}

		// Token: 0x0600E4E6 RID: 58598 RVA: 0x0033C437 File Offset: 0x0033A637
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<HorseReConnectRes>(stream);
		}

		// Token: 0x0600E4E7 RID: 58599 RVA: 0x0033C446 File Offset: 0x0033A646
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_HorseReConnect.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E4E8 RID: 58600 RVA: 0x0033C462 File Offset: 0x0033A662
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_HorseReConnect.OnTimeout(this.oArg);
		}

		// Token: 0x04006436 RID: 25654
		public HorseReConnectArg oArg = new HorseReConnectArg();

		// Token: 0x04006437 RID: 25655
		public HorseReConnectRes oRes = null;
	}
}
