using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010D8 RID: 4312
	internal class PtcG2C_AllyMatchRoleIDNotify : Protocol
	{
		// Token: 0x0600D819 RID: 55321 RVA: 0x003290AC File Offset: 0x003272AC
		public override uint GetProtoType()
		{
			return 41598U;
		}

		// Token: 0x0600D81A RID: 55322 RVA: 0x003290C3 File Offset: 0x003272C3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AllyMatchRoleID>(stream, this.Data);
		}

		// Token: 0x0600D81B RID: 55323 RVA: 0x003290D3 File Offset: 0x003272D3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AllyMatchRoleID>(stream);
		}

		// Token: 0x0600D81C RID: 55324 RVA: 0x003290E2 File Offset: 0x003272E2
		public override void Process()
		{
			Process_PtcG2C_AllyMatchRoleIDNotify.Process(this);
		}

		// Token: 0x040061C3 RID: 25027
		public AllyMatchRoleID Data = new AllyMatchRoleID();
	}
}
