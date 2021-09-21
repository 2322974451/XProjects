using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001493 RID: 5267
	internal class RpcC2G_EnchantTransfer : Rpc
	{
		// Token: 0x0600E753 RID: 59219 RVA: 0x0033FDAC File Offset: 0x0033DFAC
		public override uint GetRpcType()
		{
			return 54906U;
		}

		// Token: 0x0600E754 RID: 59220 RVA: 0x0033FDC3 File Offset: 0x0033DFC3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnchantTransferArg>(stream, this.oArg);
		}

		// Token: 0x0600E755 RID: 59221 RVA: 0x0033FDD3 File Offset: 0x0033DFD3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnchantTransferRes>(stream);
		}

		// Token: 0x0600E756 RID: 59222 RVA: 0x0033FDE2 File Offset: 0x0033DFE2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnchantTransfer.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E757 RID: 59223 RVA: 0x0033FDFE File Offset: 0x0033DFFE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnchantTransfer.OnTimeout(this.oArg);
		}

		// Token: 0x040064A9 RID: 25769
		public EnchantTransferArg oArg = new EnchantTransferArg();

		// Token: 0x040064AA RID: 25770
		public EnchantTransferRes oRes = null;
	}
}
