using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001537 RID: 5431
	internal class PtcG2C_WeekEnd4v4RoleDataNtf : Protocol
	{
		// Token: 0x0600E9F6 RID: 59894 RVA: 0x003437BC File Offset: 0x003419BC
		public override uint GetProtoType()
		{
			return 54598U;
		}

		// Token: 0x0600E9F7 RID: 59895 RVA: 0x003437D3 File Offset: 0x003419D3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeekEnd4v4BattleAllRoleData>(stream, this.Data);
		}

		// Token: 0x0600E9F8 RID: 59896 RVA: 0x003437E3 File Offset: 0x003419E3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeekEnd4v4BattleAllRoleData>(stream);
		}

		// Token: 0x0600E9F9 RID: 59897 RVA: 0x003437F2 File Offset: 0x003419F2
		public override void Process()
		{
			Process_PtcG2C_WeekEnd4v4RoleDataNtf.Process(this);
		}

		// Token: 0x0400652B RID: 25899
		public WeekEnd4v4BattleAllRoleData Data = new WeekEnd4v4BattleAllRoleData();
	}
}
