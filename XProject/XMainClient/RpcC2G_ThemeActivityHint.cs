using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015D1 RID: 5585
	internal class RpcC2G_ThemeActivityHint : Rpc
	{
		// Token: 0x0600EC6D RID: 60525 RVA: 0x0034714C File Offset: 0x0034534C
		public override uint GetRpcType()
		{
			return 39987U;
		}

		// Token: 0x0600EC6E RID: 60526 RVA: 0x00347163 File Offset: 0x00345363
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ThemeActivityHintArg>(stream, this.oArg);
		}

		// Token: 0x0600EC6F RID: 60527 RVA: 0x00347173 File Offset: 0x00345373
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ThemeActivityHintRes>(stream);
		}

		// Token: 0x0600EC70 RID: 60528 RVA: 0x00347182 File Offset: 0x00345382
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ThemeActivityHint.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EC71 RID: 60529 RVA: 0x0034719E File Offset: 0x0034539E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ThemeActivityHint.OnTimeout(this.oArg);
		}

		// Token: 0x040065AA RID: 26026
		public ThemeActivityHintArg oArg = new ThemeActivityHintArg();

		// Token: 0x040065AB RID: 26027
		public ThemeActivityHintRes oRes = null;
	}
}
