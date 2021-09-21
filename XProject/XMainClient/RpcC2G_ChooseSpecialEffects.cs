using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001667 RID: 5735
	internal class RpcC2G_ChooseSpecialEffects : Rpc
	{
		// Token: 0x0600EEE6 RID: 61158 RVA: 0x0034A6C4 File Offset: 0x003488C4
		public override uint GetRpcType()
		{
			return 55040U;
		}

		// Token: 0x0600EEE7 RID: 61159 RVA: 0x0034A6DB File Offset: 0x003488DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChooseSpecialEffectsArg>(stream, this.oArg);
		}

		// Token: 0x0600EEE8 RID: 61160 RVA: 0x0034A6EB File Offset: 0x003488EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChooseSpecialEffectsRes>(stream);
		}

		// Token: 0x0600EEE9 RID: 61161 RVA: 0x0034A6FA File Offset: 0x003488FA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChooseSpecialEffects.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EEEA RID: 61162 RVA: 0x0034A716 File Offset: 0x00348916
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChooseSpecialEffects.OnTimeout(this.oArg);
		}

		// Token: 0x0400662A RID: 26154
		public ChooseSpecialEffectsArg oArg = new ChooseSpecialEffectsArg();

		// Token: 0x0400662B RID: 26155
		public ChooseSpecialEffectsRes oRes = null;
	}
}
