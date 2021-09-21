using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014B9 RID: 5305
	internal class RpcC2G_PayFriendItem : Rpc
	{
		// Token: 0x0600E7ED RID: 59373 RVA: 0x00340ADC File Offset: 0x0033ECDC
		public override uint GetRpcType()
		{
			return 29289U;
		}

		// Token: 0x0600E7EE RID: 59374 RVA: 0x00340AF3 File Offset: 0x0033ECF3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayFriendItemArg>(stream, this.oArg);
		}

		// Token: 0x0600E7EF RID: 59375 RVA: 0x00340B03 File Offset: 0x0033ED03
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PayFriendItemRes>(stream);
		}

		// Token: 0x0600E7F0 RID: 59376 RVA: 0x00340B12 File Offset: 0x0033ED12
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PayFriendItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E7F1 RID: 59377 RVA: 0x00340B2E File Offset: 0x0033ED2E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PayFriendItem.OnTimeout(this.oArg);
		}

		// Token: 0x040064C5 RID: 25797
		public PayFriendItemArg oArg = new PayFriendItemArg();

		// Token: 0x040064C6 RID: 25798
		public PayFriendItemRes oRes = null;
	}
}
