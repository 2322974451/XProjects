using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000EC1 RID: 3777
	internal class PtcG2C_ActivityRoleNotify : Protocol
	{
		// Token: 0x0600C899 RID: 51353 RVA: 0x002CED3C File Offset: 0x002CCF3C
		public override uint GetProtoType()
		{
			return 2548U;
		}

		// Token: 0x0600C89A RID: 51354 RVA: 0x002CED53 File Offset: 0x002CCF53
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActivityRoleNotify>(stream, this.Data);
		}

		// Token: 0x0600C89B RID: 51355 RVA: 0x002CED63 File Offset: 0x002CCF63
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ActivityRoleNotify>(stream);
		}

		// Token: 0x0600C89C RID: 51356 RVA: 0x002CED72 File Offset: 0x002CCF72
		public override void Process()
		{
			Process_PtcG2C_ActivityRoleNotify.Process(this);
		}

		// Token: 0x040058BA RID: 22714
		public ActivityRoleNotify Data = new ActivityRoleNotify();
	}
}
