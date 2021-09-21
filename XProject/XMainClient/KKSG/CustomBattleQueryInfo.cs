using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000708 RID: 1800
	[ProtoContract(Name = "CustomBattleQueryInfo")]
	[Serializable]
	public class CustomBattleQueryInfo : IExtensible
	{
		// Token: 0x170026AF RID: 9903
		// (get) Token: 0x06007A17 RID: 31255 RVA: 0x000E9688 File Offset: 0x000E7888
		[ProtoMember(1, Name = "battlesystem", DataFormat = DataFormat.Default)]
		public List<CustomBattleDataRole> battlesystem
		{
			get
			{
				return this._battlesystem;
			}
		}

		// Token: 0x170026B0 RID: 9904
		// (get) Token: 0x06007A18 RID: 31256 RVA: 0x000E96A0 File Offset: 0x000E78A0
		[ProtoMember(2, Name = "battlerandom", DataFormat = DataFormat.Default)]
		public List<CustomBattleDataRole> battlerandom
		{
			get
			{
				return this._battlerandom;
			}
		}

		// Token: 0x170026B1 RID: 9905
		// (get) Token: 0x06007A19 RID: 31257 RVA: 0x000E96B8 File Offset: 0x000E78B8
		// (set) Token: 0x06007A1A RID: 31258 RVA: 0x000E96D0 File Offset: 0x000E78D0
		[ProtoMember(3, IsRequired = false, Name = "battleone", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleDataRole battleone
		{
			get
			{
				return this._battleone;
			}
			set
			{
				this._battleone = value;
			}
		}

		// Token: 0x06007A1B RID: 31259 RVA: 0x000E96DC File Offset: 0x000E78DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CD3 RID: 7379
		private readonly List<CustomBattleDataRole> _battlesystem = new List<CustomBattleDataRole>();

		// Token: 0x04001CD4 RID: 7380
		private readonly List<CustomBattleDataRole> _battlerandom = new List<CustomBattleDataRole>();

		// Token: 0x04001CD5 RID: 7381
		private CustomBattleDataRole _battleone = null;

		// Token: 0x04001CD6 RID: 7382
		private IExtension extensionObject;
	}
}
