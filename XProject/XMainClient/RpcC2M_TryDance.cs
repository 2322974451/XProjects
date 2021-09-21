using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200168A RID: 5770
	internal class RpcC2M_TryDance : Rpc
	{
		// Token: 0x0600EF7A RID: 61306 RVA: 0x0034B5DC File Offset: 0x003497DC
		public override uint GetRpcType()
		{
			return 54323U;
		}

		// Token: 0x0600EF7B RID: 61307 RVA: 0x0034B5F3 File Offset: 0x003497F3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TryDanceArg>(stream, this.oArg);
		}

		// Token: 0x0600EF7C RID: 61308 RVA: 0x0034B603 File Offset: 0x00349803
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TryDanceRes>(stream);
		}

		// Token: 0x0600EF7D RID: 61309 RVA: 0x0034B612 File Offset: 0x00349812
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_TryDance.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF7E RID: 61310 RVA: 0x0034B62E File Offset: 0x0034982E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_TryDance.OnTimeout(this.oArg);
		}

		// Token: 0x0400664F RID: 26191
		public TryDanceArg oArg = new TryDanceArg();

		// Token: 0x04006650 RID: 26192
		public TryDanceRes oRes = null;
	}
}
