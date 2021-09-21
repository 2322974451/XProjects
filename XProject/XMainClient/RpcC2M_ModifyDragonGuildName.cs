using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001632 RID: 5682
	internal class RpcC2M_ModifyDragonGuildName : Rpc
	{
		// Token: 0x0600EE07 RID: 60935 RVA: 0x00349398 File Offset: 0x00347598
		public override uint GetRpcType()
		{
			return 10624U;
		}

		// Token: 0x0600EE08 RID: 60936 RVA: 0x003493AF File Offset: 0x003475AF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ModifyDragonGuildNameArg>(stream, this.oArg);
		}

		// Token: 0x0600EE09 RID: 60937 RVA: 0x003493BF File Offset: 0x003475BF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ModifyDragonGuildNameRes>(stream);
		}

		// Token: 0x0600EE0A RID: 60938 RVA: 0x003493CE File Offset: 0x003475CE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ModifyDragonGuildName.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE0B RID: 60939 RVA: 0x003493EA File Offset: 0x003475EA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ModifyDragonGuildName.OnTimeout(this.oArg);
		}

		// Token: 0x040065FD RID: 26109
		public ModifyDragonGuildNameArg oArg = new ModifyDragonGuildNameArg();

		// Token: 0x040065FE RID: 26110
		public ModifyDragonGuildNameRes oRes = null;
	}
}
