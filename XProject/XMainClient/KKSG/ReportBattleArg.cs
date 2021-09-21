using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000C3 RID: 195
	[ProtoContract(Name = "ReportBattleArg")]
	[Serializable]
	public class ReportBattleArg : IExtensible
	{
		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06000D05 RID: 3333 RVA: 0x0001B528 File Offset: 0x00019728
		// (set) Token: 0x06000D06 RID: 3334 RVA: 0x0001B540 File Offset: 0x00019740
		[ProtoMember(1, IsRequired = false, Name = "battledata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BattleData battledata
		{
			get
			{
				return this._battledata;
			}
			set
			{
				this._battledata = value;
			}
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x0001B54C File Offset: 0x0001974C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000341 RID: 833
		private BattleData _battledata = null;

		// Token: 0x04000342 RID: 834
		private IExtension extensionObject;
	}
}
