using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014EC RID: 5356
	internal class RpcC2G_ActivateFashionCharm : Rpc
	{
		// Token: 0x0600E8C2 RID: 59586 RVA: 0x00341AF4 File Offset: 0x0033FCF4
		public override uint GetRpcType()
		{
			return 58036U;
		}

		// Token: 0x0600E8C3 RID: 59587 RVA: 0x00341B0B File Offset: 0x0033FD0B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActivateFashionArg>(stream, this.oArg);
		}

		// Token: 0x0600E8C4 RID: 59588 RVA: 0x00341B1B File Offset: 0x0033FD1B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ActivateFashionRes>(stream);
		}

		// Token: 0x0600E8C5 RID: 59589 RVA: 0x00341B2A File Offset: 0x0033FD2A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ActivateFashionCharm.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E8C6 RID: 59590 RVA: 0x00341B46 File Offset: 0x0033FD46
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ActivateFashionCharm.OnTimeout(this.oArg);
		}

		// Token: 0x040064EF RID: 25839
		public ActivateFashionArg oArg = new ActivateFashionArg();

		// Token: 0x040064F0 RID: 25840
		public ActivateFashionRes oRes = null;
	}
}
