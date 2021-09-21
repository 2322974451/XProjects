using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001251 RID: 4689
	internal class RpcC2G_DEProgressReq : Rpc
	{
		// Token: 0x0600DE16 RID: 56854 RVA: 0x00332D0C File Offset: 0x00330F0C
		public override uint GetRpcType()
		{
			return 5238U;
		}

		// Token: 0x0600DE17 RID: 56855 RVA: 0x00332D23 File Offset: 0x00330F23
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DEProgressArg>(stream, this.oArg);
		}

		// Token: 0x0600DE18 RID: 56856 RVA: 0x00332D33 File Offset: 0x00330F33
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DEProgressRes>(stream);
		}

		// Token: 0x0600DE19 RID: 56857 RVA: 0x00332D42 File Offset: 0x00330F42
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DEProgressReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE1A RID: 56858 RVA: 0x00332D5E File Offset: 0x00330F5E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DEProgressReq.OnTimeout(this.oArg);
		}

		// Token: 0x040062E4 RID: 25316
		public DEProgressArg oArg = new DEProgressArg();

		// Token: 0x040062E5 RID: 25317
		public DEProgressRes oRes = new DEProgressRes();
	}
}
