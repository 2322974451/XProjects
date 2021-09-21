using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001172 RID: 4466
	internal class RpcC2G_ResetTower : Rpc
	{
		// Token: 0x0600DA9C RID: 55964 RVA: 0x0032DE68 File Offset: 0x0032C068
		public override uint GetRpcType()
		{
			return 8570U;
		}

		// Token: 0x0600DA9D RID: 55965 RVA: 0x0032DE7F File Offset: 0x0032C07F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResetTowerArg>(stream, this.oArg);
		}

		// Token: 0x0600DA9E RID: 55966 RVA: 0x0032DE8F File Offset: 0x0032C08F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResetTowerRes>(stream);
		}

		// Token: 0x0600DA9F RID: 55967 RVA: 0x0032DE9E File Offset: 0x0032C09E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ResetTower.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DAA0 RID: 55968 RVA: 0x0032DEBA File Offset: 0x0032C0BA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ResetTower.OnTimeout(this.oArg);
		}

		// Token: 0x04006241 RID: 25153
		public ResetTowerArg oArg = new ResetTowerArg();

		// Token: 0x04006242 RID: 25154
		public ResetTowerRes oRes = new ResetTowerRes();
	}
}
