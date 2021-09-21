using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001366 RID: 4966
	internal class RpcC2M_applyguildarena : Rpc
	{
		// Token: 0x0600E28B RID: 57995 RVA: 0x00339360 File Offset: 0x00337560
		public override uint GetRpcType()
		{
			return 50879U;
		}

		// Token: 0x0600E28C RID: 57996 RVA: 0x00339377 File Offset: 0x00337577
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<applyguildarenaarg>(stream, this.oArg);
		}

		// Token: 0x0600E28D RID: 57997 RVA: 0x00339387 File Offset: 0x00337587
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<applyguildarenares>(stream);
		}

		// Token: 0x0600E28E RID: 57998 RVA: 0x00339396 File Offset: 0x00337596
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_applyguildarena.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E28F RID: 57999 RVA: 0x003393B2 File Offset: 0x003375B2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_applyguildarena.OnTimeout(this.oArg);
		}

		// Token: 0x040063C2 RID: 25538
		public applyguildarenaarg oArg = new applyguildarenaarg();

		// Token: 0x040063C3 RID: 25539
		public applyguildarenares oRes = null;
	}
}
