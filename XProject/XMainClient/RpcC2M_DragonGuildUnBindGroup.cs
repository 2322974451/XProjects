using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200164C RID: 5708
	internal class RpcC2M_DragonGuildUnBindGroup : Rpc
	{
		// Token: 0x0600EE7A RID: 61050 RVA: 0x00349D4C File Offset: 0x00347F4C
		public override uint GetRpcType()
		{
			return 56553U;
		}

		// Token: 0x0600EE7B RID: 61051 RVA: 0x00349D63 File Offset: 0x00347F63
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildUnBindGroupArg>(stream, this.oArg);
		}

		// Token: 0x0600EE7C RID: 61052 RVA: 0x00349D73 File Offset: 0x00347F73
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGuildUnBindGroupRes>(stream);
		}

		// Token: 0x0600EE7D RID: 61053 RVA: 0x00349D82 File Offset: 0x00347F82
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DragonGuildUnBindGroup.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE7E RID: 61054 RVA: 0x00349D9E File Offset: 0x00347F9E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DragonGuildUnBindGroup.OnTimeout(this.oArg);
		}

		// Token: 0x04006616 RID: 26134
		public DragonGuildUnBindGroupArg oArg = new DragonGuildUnBindGroupArg();

		// Token: 0x04006617 RID: 26135
		public DragonGuildUnBindGroupRes oRes = null;
	}
}
