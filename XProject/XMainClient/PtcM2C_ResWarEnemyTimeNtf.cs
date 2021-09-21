using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200144A RID: 5194
	internal class PtcM2C_ResWarEnemyTimeNtf : Protocol
	{
		// Token: 0x0600E632 RID: 58930 RVA: 0x0033E194 File Offset: 0x0033C394
		public override uint GetProtoType()
		{
			return 48125U;
		}

		// Token: 0x0600E633 RID: 58931 RVA: 0x0033E1AB File Offset: 0x0033C3AB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarEnemyTime>(stream, this.Data);
		}

		// Token: 0x0600E634 RID: 58932 RVA: 0x0033E1BB File Offset: 0x0033C3BB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarEnemyTime>(stream);
		}

		// Token: 0x0600E635 RID: 58933 RVA: 0x0033E1CA File Offset: 0x0033C3CA
		public override void Process()
		{
			Process_PtcM2C_ResWarEnemyTimeNtf.Process(this);
		}

		// Token: 0x04006475 RID: 25717
		public ResWarEnemyTime Data = new ResWarEnemyTime();
	}
}
