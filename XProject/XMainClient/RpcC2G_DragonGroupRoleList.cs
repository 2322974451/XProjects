using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015BF RID: 5567
	internal class RpcC2G_DragonGroupRoleList : Rpc
	{
		// Token: 0x0600EC1F RID: 60447 RVA: 0x003469F4 File Offset: 0x00344BF4
		public override uint GetRpcType()
		{
			return 29660U;
		}

		// Token: 0x0600EC20 RID: 60448 RVA: 0x00346A0B File Offset: 0x00344C0B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGroupRoleListC2S>(stream, this.oArg);
		}

		// Token: 0x0600EC21 RID: 60449 RVA: 0x00346A1B File Offset: 0x00344C1B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGroupRoleListS2C>(stream);
		}

		// Token: 0x0600EC22 RID: 60450 RVA: 0x00346A2A File Offset: 0x00344C2A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DragonGroupRoleList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EC23 RID: 60451 RVA: 0x00346A46 File Offset: 0x00344C46
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DragonGroupRoleList.OnTimeout(this.oArg);
		}

		// Token: 0x0400659A RID: 26010
		public DragonGroupRoleListC2S oArg = new DragonGroupRoleListC2S();

		// Token: 0x0400659B RID: 26011
		public DragonGroupRoleListS2C oRes = null;
	}
}
