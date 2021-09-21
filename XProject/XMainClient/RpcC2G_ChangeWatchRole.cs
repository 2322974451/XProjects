using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200115E RID: 4446
	internal class RpcC2G_ChangeWatchRole : Rpc
	{
		// Token: 0x0600DA46 RID: 55878 RVA: 0x0032CFC0 File Offset: 0x0032B1C0
		public override uint GetRpcType()
		{
			return 35369U;
		}

		// Token: 0x0600DA47 RID: 55879 RVA: 0x0032CFD7 File Offset: 0x0032B1D7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeWatchRoleArg>(stream, this.oArg);
		}

		// Token: 0x0600DA48 RID: 55880 RVA: 0x0032CFE7 File Offset: 0x0032B1E7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeWatchRoleRes>(stream);
		}

		// Token: 0x0600DA49 RID: 55881 RVA: 0x0032CFF6 File Offset: 0x0032B1F6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeWatchRole.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA4A RID: 55882 RVA: 0x0032D012 File Offset: 0x0032B212
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeWatchRole.OnTimeout(this.oArg);
		}

		// Token: 0x0400622F RID: 25135
		public ChangeWatchRoleArg oArg = new ChangeWatchRoleArg();

		// Token: 0x04006230 RID: 25136
		public ChangeWatchRoleRes oRes = new ChangeWatchRoleRes();
	}
}
