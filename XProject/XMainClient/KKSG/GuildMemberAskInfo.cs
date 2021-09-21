using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006CC RID: 1740
	[ProtoContract(Name = "GuildMemberAskInfo")]
	[Serializable]
	public class GuildMemberAskInfo : IExtensible
	{
		// Token: 0x17002466 RID: 9318
		// (get) Token: 0x060072FC RID: 29436 RVA: 0x000DBFBC File Offset: 0x000DA1BC
		// (set) Token: 0x060072FD RID: 29437 RVA: 0x000DBFD4 File Offset: 0x000DA1D4
		[ProtoMember(1, IsRequired = false, Name = "item", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GuildMemberAskItem item
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

		// Token: 0x17002467 RID: 9319
		// (get) Token: 0x060072FE RID: 29438 RVA: 0x000DBFE0 File Offset: 0x000DA1E0
		// (set) Token: 0x060072FF RID: 29439 RVA: 0x000DC001 File Offset: 0x000DA201
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

		// Token: 0x17002468 RID: 9320
		// (get) Token: 0x06007300 RID: 29440 RVA: 0x000DC00C File Offset: 0x000DA20C
		// (set) Token: 0x06007301 RID: 29441 RVA: 0x000DC028 File Offset: 0x000DA228
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

		// Token: 0x06007302 RID: 29442 RVA: 0x000DC058 File Offset: 0x000DA258
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007303 RID: 29443 RVA: 0x000DC070 File Offset: 0x000DA270
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002469 RID: 9321
		// (get) Token: 0x06007304 RID: 29444 RVA: 0x000DC07C File Offset: 0x000DA27C
		// (set) Token: 0x06007305 RID: 29445 RVA: 0x000DC0A8 File Offset: 0x000DA2A8
		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x1700246A RID: 9322
		// (get) Token: 0x06007306 RID: 29446 RVA: 0x000DC0B8 File Offset: 0x000DA2B8
		// (set) Token: 0x06007307 RID: 29447 RVA: 0x000DC0D8 File Offset: 0x000DA2D8
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x06007308 RID: 29448 RVA: 0x000DC11C File Offset: 0x000DA31C
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06007309 RID: 29449 RVA: 0x000DC134 File Offset: 0x000DA334
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x0600730A RID: 29450 RVA: 0x000DC140 File Offset: 0x000DA340
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B5F RID: 7007
		private GuildMemberAskItem _item = null;

		// Token: 0x04001B60 RID: 7008
		private string _name;

		// Token: 0x04001B61 RID: 7009
		private uint? _profession;

		// Token: 0x04001B62 RID: 7010
		private IExtension extensionObject;
	}
}
