using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000702 RID: 1794
	[ProtoContract(Name = "IBGiftHistItem")]
	[Serializable]
	public class IBGiftHistItem : IExtensible
	{
		// Token: 0x1700266D RID: 9837
		// (get) Token: 0x0600794F RID: 31055 RVA: 0x000E7F00 File Offset: 0x000E6100
		// (set) Token: 0x06007950 RID: 31056 RVA: 0x000E7F21 File Offset: 0x000E6121
		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x1700266E RID: 9838
		// (get) Token: 0x06007951 RID: 31057 RVA: 0x000E7F2C File Offset: 0x000E612C
		// (set) Token: 0x06007952 RID: 31058 RVA: 0x000E7F48 File Offset: 0x000E6148
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06007953 RID: 31059 RVA: 0x000E7F78 File Offset: 0x000E6178
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007954 RID: 31060 RVA: 0x000E7F90 File Offset: 0x000E6190
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700266F RID: 9839
		// (get) Token: 0x06007955 RID: 31061 RVA: 0x000E7F9C File Offset: 0x000E619C
		// (set) Token: 0x06007956 RID: 31062 RVA: 0x000E7FB4 File Offset: 0x000E61B4
		[ProtoMember(2, IsRequired = false, Name = "item", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item = value;
			}
		}

		// Token: 0x17002670 RID: 9840
		// (get) Token: 0x06007957 RID: 31063 RVA: 0x000E7FC0 File Offset: 0x000E61C0
		// (set) Token: 0x06007958 RID: 31064 RVA: 0x000E7FEC File Offset: 0x000E61EC
		[ProtoMember(3, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x17002671 RID: 9841
		// (get) Token: 0x06007959 RID: 31065 RVA: 0x000E7FFC File Offset: 0x000E61FC
		// (set) Token: 0x0600795A RID: 31066 RVA: 0x000E801C File Offset: 0x000E621C
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x0600795B RID: 31067 RVA: 0x000E8060 File Offset: 0x000E6260
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x0600795C RID: 31068 RVA: 0x000E8078 File Offset: 0x000E6278
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x0600795D RID: 31069 RVA: 0x000E8084 File Offset: 0x000E6284
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CA8 RID: 7336
		private string _name;

		// Token: 0x04001CA9 RID: 7337
		private ItemBrief _item = null;

		// Token: 0x04001CAA RID: 7338
		private uint? _time;

		// Token: 0x04001CAB RID: 7339
		private IExtension extensionObject;
	}
}
