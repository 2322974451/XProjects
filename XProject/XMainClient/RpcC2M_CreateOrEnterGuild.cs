using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200122B RID: 4651
	internal class RpcC2M_CreateOrEnterGuild : Rpc
	{
		// Token: 0x0600DD77 RID: 56695 RVA: 0x00331E4C File Offset: 0x0033004C
		public override uint GetRpcType()
		{
			return 13871U;
		}

		// Token: 0x0600DD78 RID: 56696 RVA: 0x00331E63 File Offset: 0x00330063
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CreateOrJoinGuild>(stream, this.oArg);
		}

		// Token: 0x0600DD79 RID: 56697 RVA: 0x00331E73 File Offset: 0x00330073
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CreateOrJoinGuildRes>(stream);
		}

		// Token: 0x0600DD7A RID: 56698 RVA: 0x00331E82 File Offset: 0x00330082
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CreateOrEnterGuild.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD7B RID: 56699 RVA: 0x00331E9E File Offset: 0x0033009E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CreateOrEnterGuild.OnTimeout(this.oArg);
		}

		// Token: 0x040062C4 RID: 25284
		public CreateOrJoinGuild oArg = new CreateOrJoinGuild();

		// Token: 0x040062C5 RID: 25285
		public CreateOrJoinGuildRes oRes = null;
	}
}
