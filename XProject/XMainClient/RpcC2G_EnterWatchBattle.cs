using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200115C RID: 4444
	internal class RpcC2G_EnterWatchBattle : Rpc
	{
		// Token: 0x0600DA3D RID: 55869 RVA: 0x0032CE70 File Offset: 0x0032B070
		public override uint GetRpcType()
		{
			return 47590U;
		}

		// Token: 0x0600DA3E RID: 55870 RVA: 0x0032CE87 File Offset: 0x0032B087
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterWatchBattleArg>(stream, this.oArg);
		}

		// Token: 0x0600DA3F RID: 55871 RVA: 0x0032CE97 File Offset: 0x0032B097
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnterWatchBattleRes>(stream);
		}

		// Token: 0x0600DA40 RID: 55872 RVA: 0x0032CEA6 File Offset: 0x0032B0A6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnterWatchBattle.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA41 RID: 55873 RVA: 0x0032CEC2 File Offset: 0x0032B0C2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnterWatchBattle.OnTimeout(this.oArg);
		}

		// Token: 0x0400622D RID: 25133
		public EnterWatchBattleArg oArg = new EnterWatchBattleArg();

		// Token: 0x0400622E RID: 25134
		public EnterWatchBattleRes oRes = new EnterWatchBattleRes();
	}
}
