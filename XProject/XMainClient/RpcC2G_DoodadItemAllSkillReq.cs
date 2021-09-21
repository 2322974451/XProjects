using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001650 RID: 5712
	internal class RpcC2G_DoodadItemAllSkillReq : Rpc
	{
		// Token: 0x0600EE8A RID: 61066 RVA: 0x00349EBC File Offset: 0x003480BC
		public override uint GetRpcType()
		{
			return 21002U;
		}

		// Token: 0x0600EE8B RID: 61067 RVA: 0x00349ED3 File Offset: 0x003480D3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EmptyData>(stream, this.oArg);
		}

		// Token: 0x0600EE8C RID: 61068 RVA: 0x00349EE3 File Offset: 0x003480E3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DoodadItemAllSkill>(stream);
		}

		// Token: 0x0600EE8D RID: 61069 RVA: 0x00349EF2 File Offset: 0x003480F2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DoodadItemAllSkillReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE8E RID: 61070 RVA: 0x00349F0E File Offset: 0x0034810E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DoodadItemAllSkillReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006619 RID: 26137
		public EmptyData oArg = new EmptyData();

		// Token: 0x0400661A RID: 26138
		public DoodadItemAllSkill oRes = null;
	}
}
