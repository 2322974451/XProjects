using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001622 RID: 5666
	internal class RpcC2M_CreateOrJoinDragonGuild : Rpc
	{
		// Token: 0x0600EDC3 RID: 60867 RVA: 0x00348CC4 File Offset: 0x00346EC4
		public override uint GetRpcType()
		{
			return 8623U;
		}

		// Token: 0x0600EDC4 RID: 60868 RVA: 0x00348CDB File Offset: 0x00346EDB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CreateOrJoinDragonGuildArg>(stream, this.oArg);
		}

		// Token: 0x0600EDC5 RID: 60869 RVA: 0x00348CEB File Offset: 0x00346EEB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CreateOrJoinDragonGuildRes>(stream);
		}

		// Token: 0x0600EDC6 RID: 60870 RVA: 0x00348CFA File Offset: 0x00346EFA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CreateOrJoinDragonGuild.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EDC7 RID: 60871 RVA: 0x00348D16 File Offset: 0x00346F16
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CreateOrJoinDragonGuild.OnTimeout(this.oArg);
		}

		// Token: 0x040065EF RID: 26095
		public CreateOrJoinDragonGuildArg oArg = new CreateOrJoinDragonGuildArg();

		// Token: 0x040065F0 RID: 26096
		public CreateOrJoinDragonGuildRes oRes = null;
	}
}
