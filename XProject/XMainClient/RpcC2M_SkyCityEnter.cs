using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012E6 RID: 4838
	internal class RpcC2M_SkyCityEnter : Rpc
	{
		// Token: 0x0600E081 RID: 57473 RVA: 0x003362D4 File Offset: 0x003344D4
		public override uint GetRpcType()
		{
			return 49485U;
		}

		// Token: 0x0600E082 RID: 57474 RVA: 0x003362EB File Offset: 0x003344EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityEnterArg>(stream, this.oArg);
		}

		// Token: 0x0600E083 RID: 57475 RVA: 0x003362FB File Offset: 0x003344FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SkyCityEnterRes>(stream);
		}

		// Token: 0x0600E084 RID: 57476 RVA: 0x0033630A File Offset: 0x0033450A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_SkyCityEnter.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E085 RID: 57477 RVA: 0x00336326 File Offset: 0x00334526
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_SkyCityEnter.OnTimeout(this.oArg);
		}

		// Token: 0x0400635E RID: 25438
		public SkyCityEnterArg oArg = new SkyCityEnterArg();

		// Token: 0x0400635F RID: 25439
		public SkyCityEnterRes oRes = null;
	}
}
