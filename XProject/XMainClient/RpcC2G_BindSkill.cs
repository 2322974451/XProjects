using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001023 RID: 4131
	internal class RpcC2G_BindSkill : Rpc
	{
		// Token: 0x0600D533 RID: 54579 RVA: 0x003237B4 File Offset: 0x003219B4
		public override uint GetRpcType()
		{
			return 48236U;
		}

		// Token: 0x0600D534 RID: 54580 RVA: 0x003237CB File Offset: 0x003219CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BingSkillArg>(stream, this.oArg);
		}

		// Token: 0x0600D535 RID: 54581 RVA: 0x003237DB File Offset: 0x003219DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BindSkillRes>(stream);
		}

		// Token: 0x0600D536 RID: 54582 RVA: 0x003237EA File Offset: 0x003219EA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BindSkill.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D537 RID: 54583 RVA: 0x00323806 File Offset: 0x00321A06
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BindSkill.OnTimeout(this.oArg);
		}

		// Token: 0x04006115 RID: 24853
		public BingSkillArg oArg = new BingSkillArg();

		// Token: 0x04006116 RID: 24854
		public BindSkillRes oRes = new BindSkillRes();
	}
}
