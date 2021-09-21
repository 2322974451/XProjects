using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200100C RID: 4108
	internal class RpcC2G_SkillLevelup : Rpc
	{
		// Token: 0x0600D4D7 RID: 54487 RVA: 0x00322318 File Offset: 0x00320518
		public override uint GetRpcType()
		{
			return 63698U;
		}

		// Token: 0x0600D4D8 RID: 54488 RVA: 0x0032232F File Offset: 0x0032052F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillLevelupArg>(stream, this.oArg);
		}

		// Token: 0x0600D4D9 RID: 54489 RVA: 0x0032233F File Offset: 0x0032053F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SkillLevelupRes>(stream);
		}

		// Token: 0x0600D4DA RID: 54490 RVA: 0x0032234E File Offset: 0x0032054E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SkillLevelup.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D4DB RID: 54491 RVA: 0x0032236A File Offset: 0x0032056A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SkillLevelup.OnTimeout(this.oArg);
		}

		// Token: 0x04006104 RID: 24836
		public SkillLevelupArg oArg = new SkillLevelupArg();

		// Token: 0x04006105 RID: 24837
		public SkillLevelupRes oRes = null;
	}
}
