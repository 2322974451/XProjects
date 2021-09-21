using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005FF RID: 1535
	[ProtoContract(Name = "RoleGuildBonusData")]
	[Serializable]
	public class RoleGuildBonusData : IExtensible
	{
		// Token: 0x17001CC3 RID: 7363
		// (get) Token: 0x06005BDF RID: 23519 RVA: 0x000AF020 File Offset: 0x000AD220
		[ProtoMember(1, Name = "sentGuildBonus", DataFormat = DataFormat.Default)]
		public List<OnlyOnceGuildBonusData> sentGuildBonus
		{
			get
			{
				return this._sentGuildBonus;
			}
		}

		// Token: 0x17001CC4 RID: 7364
		// (get) Token: 0x06005BE0 RID: 23520 RVA: 0x000AF038 File Offset: 0x000AD238
		[ProtoMember(2, Name = "gotGuildBonusDayNum", DataFormat = DataFormat.Default)]
		public List<MapKeyValue> gotGuildBonusDayNum
		{
			get
			{
				return this._gotGuildBonusDayNum;
			}
		}

		// Token: 0x17001CC5 RID: 7365
		// (get) Token: 0x06005BE1 RID: 23521 RVA: 0x000AF050 File Offset: 0x000AD250
		[ProtoMember(3, Name = "gotGuildBonusTotalNum", DataFormat = DataFormat.Default)]
		public List<MapKeyValue> gotGuildBonusTotalNum
		{
			get
			{
				return this._gotGuildBonusTotalNum;
			}
		}

		// Token: 0x06005BE2 RID: 23522 RVA: 0x000AF068 File Offset: 0x000AD268
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001658 RID: 5720
		private readonly List<OnlyOnceGuildBonusData> _sentGuildBonus = new List<OnlyOnceGuildBonusData>();

		// Token: 0x04001659 RID: 5721
		private readonly List<MapKeyValue> _gotGuildBonusDayNum = new List<MapKeyValue>();

		// Token: 0x0400165A RID: 5722
		private readonly List<MapKeyValue> _gotGuildBonusTotalNum = new List<MapKeyValue>();

		// Token: 0x0400165B RID: 5723
		private IExtension extensionObject;
	}
}
