using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001354 RID: 4948
	internal class PtcG2C_ResWarBattleDataNtf : Protocol
	{
		// Token: 0x0600E243 RID: 57923 RVA: 0x00338CC4 File Offset: 0x00336EC4
		public override uint GetProtoType()
		{
			return 18834U;
		}

		// Token: 0x0600E244 RID: 57924 RVA: 0x00338CDB File Offset: 0x00336EDB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarAllInfo>(stream, this.Data);
		}

		// Token: 0x0600E245 RID: 57925 RVA: 0x00338CEB File Offset: 0x00336EEB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ResWarAllInfo>(stream);
		}

		// Token: 0x0600E246 RID: 57926 RVA: 0x00338CFA File Offset: 0x00336EFA
		public override void Process()
		{
			Process_PtcG2C_ResWarBattleDataNtf.Process(this);
		}

		// Token: 0x040063B4 RID: 25524
		public ResWarAllInfo Data = new ResWarAllInfo();
	}
}
