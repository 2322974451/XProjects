using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014A2 RID: 5282
	internal class RpcC2G_ChangeSkillSet : Rpc
	{
		// Token: 0x0600E791 RID: 59281 RVA: 0x00340304 File Offset: 0x0033E504
		public override uint GetRpcType()
		{
			return 51116U;
		}

		// Token: 0x0600E792 RID: 59282 RVA: 0x0034031B File Offset: 0x0033E51B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeSkillSetArg>(stream, this.oArg);
		}

		// Token: 0x0600E793 RID: 59283 RVA: 0x0034032B File Offset: 0x0033E52B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeSkillSetRes>(stream);
		}

		// Token: 0x0600E794 RID: 59284 RVA: 0x0034033A File Offset: 0x0033E53A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeSkillSet.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E795 RID: 59285 RVA: 0x00340356 File Offset: 0x0033E556
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeSkillSet.OnTimeout(this.oArg);
		}

		// Token: 0x040064B4 RID: 25780
		public ChangeSkillSetArg oArg = new ChangeSkillSetArg();

		// Token: 0x040064B5 RID: 25781
		public ChangeSkillSetRes oRes = null;
	}
}
