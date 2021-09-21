using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000709 RID: 1801
	[ProtoContract(Name = "CustomBattleDataRole")]
	[Serializable]
	public class CustomBattleDataRole : IExtensible
	{
		// Token: 0x170026B2 RID: 9906
		// (get) Token: 0x06007A1D RID: 31261 RVA: 0x000E9714 File Offset: 0x000E7914
		// (set) Token: 0x06007A1E RID: 31262 RVA: 0x000E972C File Offset: 0x000E792C
		[ProtoMember(1, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleData data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		// Token: 0x170026B3 RID: 9907
		// (get) Token: 0x06007A1F RID: 31263 RVA: 0x000E9738 File Offset: 0x000E7938
		// (set) Token: 0x06007A20 RID: 31264 RVA: 0x000E9750 File Offset: 0x000E7950
		[ProtoMember(2, IsRequired = false, Name = "role", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleRole role
		{
			get
			{
				return this._role;
			}
			set
			{
				this._role = value;
			}
		}

		// Token: 0x06007A21 RID: 31265 RVA: 0x000E975C File Offset: 0x000E795C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CD7 RID: 7383
		private CustomBattleData _data = null;

		// Token: 0x04001CD8 RID: 7384
		private CustomBattleRole _role = null;

		// Token: 0x04001CD9 RID: 7385
		private IExtension extensionObject;
	}
}
