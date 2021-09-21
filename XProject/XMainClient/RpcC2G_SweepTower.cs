using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001170 RID: 4464
	internal class RpcC2G_SweepTower : Rpc
	{
		// Token: 0x0600DA93 RID: 55955 RVA: 0x0032DD68 File Offset: 0x0032BF68
		public override uint GetRpcType()
		{
			return 39381U;
		}

		// Token: 0x0600DA94 RID: 55956 RVA: 0x0032DD7F File Offset: 0x0032BF7F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SweepTowerArg>(stream, this.oArg);
		}

		// Token: 0x0600DA95 RID: 55957 RVA: 0x0032DD8F File Offset: 0x0032BF8F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SweepTowerRes>(stream);
		}

		// Token: 0x0600DA96 RID: 55958 RVA: 0x0032DD9E File Offset: 0x0032BF9E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SweepTower.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA97 RID: 55959 RVA: 0x0032DDBA File Offset: 0x0032BFBA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SweepTower.OnTimeout(this.oArg);
		}

		// Token: 0x0400623F RID: 25151
		public SweepTowerArg oArg = new SweepTowerArg();

		// Token: 0x04006240 RID: 25152
		public SweepTowerRes oRes = new SweepTowerRes();
	}
}
