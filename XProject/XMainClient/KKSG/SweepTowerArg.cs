using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000195 RID: 405
	[ProtoContract(Name = "SweepTowerArg")]
	[Serializable]
	public class SweepTowerArg : IExtensible
	{
		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x06001862 RID: 6242 RVA: 0x00030988 File Offset: 0x0002EB88
		// (set) Token: 0x06001863 RID: 6243 RVA: 0x000309B4 File Offset: 0x0002EBB4
		[ProtoMember(1, IsRequired = false, Name = "hardLevel", DataFormat = DataFormat.TwosComplement)]
		public int hardLevel
		{
			get
			{
				return this._hardLevel ?? 0;
			}
			set
			{
				this._hardLevel = new int?(value);
			}
		}

		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x06001864 RID: 6244 RVA: 0x000309C4 File Offset: 0x0002EBC4
		// (set) Token: 0x06001865 RID: 6245 RVA: 0x000309E4 File Offset: 0x0002EBE4
		[XmlIgnore]
		[Browsable(false)]
		public bool hardLevelSpecified
		{
			get
			{
				return this._hardLevel != null;
			}
			set
			{
				bool flag = value == (this._hardLevel == null);
				if (flag)
				{
					this._hardLevel = (value ? new int?(this.hardLevel) : null);
				}
			}
		}

		// Token: 0x06001866 RID: 6246 RVA: 0x00030A28 File Offset: 0x0002EC28
		private bool ShouldSerializehardLevel()
		{
			return this.hardLevelSpecified;
		}

		// Token: 0x06001867 RID: 6247 RVA: 0x00030A40 File Offset: 0x0002EC40
		private void ResethardLevel()
		{
			this.hardLevelSpecified = false;
		}

		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x06001868 RID: 6248 RVA: 0x00030A4C File Offset: 0x0002EC4C
		// (set) Token: 0x06001869 RID: 6249 RVA: 0x00030A64 File Offset: 0x0002EC64
		[ProtoMember(2, IsRequired = false, Name = "cost", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief cost
		{
			get
			{
				return this._cost;
			}
			set
			{
				this._cost = value;
			}
		}

		// Token: 0x0600186A RID: 6250 RVA: 0x00030A70 File Offset: 0x0002EC70
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000606 RID: 1542
		private int? _hardLevel;

		// Token: 0x04000607 RID: 1543
		private ItemBrief _cost = null;

		// Token: 0x04000608 RID: 1544
		private IExtension extensionObject;
	}
}
