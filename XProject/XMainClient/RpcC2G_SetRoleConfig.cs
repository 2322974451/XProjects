using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010CF RID: 4303
	internal class RpcC2G_SetRoleConfig : Rpc
	{
		// Token: 0x0600D7F4 RID: 55284 RVA: 0x00328DC0 File Offset: 0x00326FC0
		public override uint GetRpcType()
		{
			return 35306U;
		}

		// Token: 0x0600D7F5 RID: 55285 RVA: 0x00328DD7 File Offset: 0x00326FD7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetRoleConfigReq>(stream, this.oArg);
		}

		// Token: 0x0600D7F6 RID: 55286 RVA: 0x00328DE7 File Offset: 0x00326FE7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SetRoleConfigRes>(stream);
		}

		// Token: 0x0600D7F7 RID: 55287 RVA: 0x00328DF6 File Offset: 0x00326FF6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SetRoleConfig.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D7F8 RID: 55288 RVA: 0x00328E12 File Offset: 0x00327012
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SetRoleConfig.OnTimeout(this.oArg);
		}

		// Token: 0x040061BC RID: 25020
		public SetRoleConfigReq oArg = new SetRoleConfigReq();

		// Token: 0x040061BD RID: 25021
		public SetRoleConfigRes oRes = new SetRoleConfigRes();
	}
}
