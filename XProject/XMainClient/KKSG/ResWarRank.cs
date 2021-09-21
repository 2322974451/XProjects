using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006BE RID: 1726
	[ProtoContract(Name = "ResWarRank")]
	[Serializable]
	public class ResWarRank : IExtensible
	{
		// Token: 0x170023EA RID: 9194
		// (get) Token: 0x06007174 RID: 29044 RVA: 0x000D9104 File Offset: 0x000D7304
		// (set) Token: 0x06007175 RID: 29045 RVA: 0x000D9131 File Offset: 0x000D7331
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public ulong id
		{
			get
			{
				return this._id ?? 0UL;
			}
			set
			{
				this._id = new ulong?(value);
			}
		}

		// Token: 0x170023EB RID: 9195
		// (get) Token: 0x06007176 RID: 29046 RVA: 0x000D9140 File Offset: 0x000D7340
		// (set) Token: 0x06007177 RID: 29047 RVA: 0x000D9160 File Offset: 0x000D7360
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new ulong?(this.id) : null);
				}
			}
		}

		// Token: 0x06007178 RID: 29048 RVA: 0x000D91A4 File Offset: 0x000D73A4
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06007179 RID: 29049 RVA: 0x000D91BC File Offset: 0x000D73BC
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x170023EC RID: 9196
		// (get) Token: 0x0600717A RID: 29050 RVA: 0x000D91C8 File Offset: 0x000D73C8
		// (set) Token: 0x0600717B RID: 29051 RVA: 0x000D91E9 File Offset: 0x000D73E9
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x170023ED RID: 9197
		// (get) Token: 0x0600717C RID: 29052 RVA: 0x000D91F4 File Offset: 0x000D73F4
		// (set) Token: 0x0600717D RID: 29053 RVA: 0x000D9210 File Offset: 0x000D7410
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

		// Token: 0x0600717E RID: 29054 RVA: 0x000D9240 File Offset: 0x000D7440
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600717F RID: 29055 RVA: 0x000D9258 File Offset: 0x000D7458
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170023EE RID: 9198
		// (get) Token: 0x06007180 RID: 29056 RVA: 0x000D9264 File Offset: 0x000D7464
		// (set) Token: 0x06007181 RID: 29057 RVA: 0x000D9290 File Offset: 0x000D7490
		[ProtoMember(3, IsRequired = false, Name = "value", DataFormat = DataFormat.TwosComplement)]
		public uint value
		{
			get
			{
				return this._value ?? 0U;
			}
			set
			{
				this._value = new uint?(value);
			}
		}

		// Token: 0x170023EF RID: 9199
		// (get) Token: 0x06007182 RID: 29058 RVA: 0x000D92A0 File Offset: 0x000D74A0
		// (set) Token: 0x06007183 RID: 29059 RVA: 0x000D92C0 File Offset: 0x000D74C0
		[XmlIgnore]
		[Browsable(false)]
		public bool valueSpecified
		{
			get
			{
				return this._value != null;
			}
			set
			{
				bool flag = value == (this._value == null);
				if (flag)
				{
					this._value = (value ? new uint?(this.value) : null);
				}
			}
		}

		// Token: 0x06007184 RID: 29060 RVA: 0x000D9304 File Offset: 0x000D7504
		private bool ShouldSerializevalue()
		{
			return this.valueSpecified;
		}

		// Token: 0x06007185 RID: 29061 RVA: 0x000D931C File Offset: 0x000D751C
		private void Resetvalue()
		{
			this.valueSpecified = false;
		}

		// Token: 0x170023F0 RID: 9200
		// (get) Token: 0x06007186 RID: 29062 RVA: 0x000D9328 File Offset: 0x000D7528
		// (set) Token: 0x06007187 RID: 29063 RVA: 0x000D9354 File Offset: 0x000D7554
		[ProtoMember(4, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public uint icon
		{
			get
			{
				return this._icon ?? 0U;
			}
			set
			{
				this._icon = new uint?(value);
			}
		}

		// Token: 0x170023F1 RID: 9201
		// (get) Token: 0x06007188 RID: 29064 RVA: 0x000D9364 File Offset: 0x000D7564
		// (set) Token: 0x06007189 RID: 29065 RVA: 0x000D9384 File Offset: 0x000D7584
		[XmlIgnore]
		[Browsable(false)]
		public bool iconSpecified
		{
			get
			{
				return this._icon != null;
			}
			set
			{
				bool flag = value == (this._icon == null);
				if (flag)
				{
					this._icon = (value ? new uint?(this.icon) : null);
				}
			}
		}

		// Token: 0x0600718A RID: 29066 RVA: 0x000D93C8 File Offset: 0x000D75C8
		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		// Token: 0x0600718B RID: 29067 RVA: 0x000D93E0 File Offset: 0x000D75E0
		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		// Token: 0x0600718C RID: 29068 RVA: 0x000D93EC File Offset: 0x000D75EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B11 RID: 6929
		private ulong? _id;

		// Token: 0x04001B12 RID: 6930
		private string _name;

		// Token: 0x04001B13 RID: 6931
		private uint? _value;

		// Token: 0x04001B14 RID: 6932
		private uint? _icon;

		// Token: 0x04001B15 RID: 6933
		private IExtension extensionObject;
	}
}
