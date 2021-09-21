using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006E8 RID: 1768
	[ProtoContract(Name = "PartnerShopRecordItem")]
	[Serializable]
	public class PartnerShopRecordItem : IExtensible
	{
		// Token: 0x17002570 RID: 9584
		// (get) Token: 0x0600763D RID: 30269 RVA: 0x000E237C File Offset: 0x000E057C
		// (set) Token: 0x0600763E RID: 30270 RVA: 0x000E23A9 File Offset: 0x000E05A9
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17002571 RID: 9585
		// (get) Token: 0x0600763F RID: 30271 RVA: 0x000E23B8 File Offset: 0x000E05B8
		// (set) Token: 0x06007640 RID: 30272 RVA: 0x000E23D8 File Offset: 0x000E05D8
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06007641 RID: 30273 RVA: 0x000E241C File Offset: 0x000E061C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007642 RID: 30274 RVA: 0x000E2434 File Offset: 0x000E0634
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17002572 RID: 9586
		// (get) Token: 0x06007643 RID: 30275 RVA: 0x000E2440 File Offset: 0x000E0640
		// (set) Token: 0x06007644 RID: 30276 RVA: 0x000E246C File Offset: 0x000E066C
		[ProtoMember(2, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		// Token: 0x17002573 RID: 9587
		// (get) Token: 0x06007645 RID: 30277 RVA: 0x000E247C File Offset: 0x000E067C
		// (set) Token: 0x06007646 RID: 30278 RVA: 0x000E249C File Offset: 0x000E069C
		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		// Token: 0x06007647 RID: 30279 RVA: 0x000E24E0 File Offset: 0x000E06E0
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06007648 RID: 30280 RVA: 0x000E24F8 File Offset: 0x000E06F8
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x17002574 RID: 9588
		// (get) Token: 0x06007649 RID: 30281 RVA: 0x000E2504 File Offset: 0x000E0704
		// (set) Token: 0x0600764A RID: 30282 RVA: 0x000E2530 File Offset: 0x000E0730
		[ProtoMember(3, IsRequired = false, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public uint itemcount
		{
			get
			{
				return this._itemcount ?? 0U;
			}
			set
			{
				this._itemcount = new uint?(value);
			}
		}

		// Token: 0x17002575 RID: 9589
		// (get) Token: 0x0600764B RID: 30283 RVA: 0x000E2540 File Offset: 0x000E0740
		// (set) Token: 0x0600764C RID: 30284 RVA: 0x000E2560 File Offset: 0x000E0760
		[XmlIgnore]
		[Browsable(false)]
		public bool itemcountSpecified
		{
			get
			{
				return this._itemcount != null;
			}
			set
			{
				bool flag = value == (this._itemcount == null);
				if (flag)
				{
					this._itemcount = (value ? new uint?(this.itemcount) : null);
				}
			}
		}

		// Token: 0x0600764D RID: 30285 RVA: 0x000E25A4 File Offset: 0x000E07A4
		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		// Token: 0x0600764E RID: 30286 RVA: 0x000E25BC File Offset: 0x000E07BC
		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		// Token: 0x17002576 RID: 9590
		// (get) Token: 0x0600764F RID: 30287 RVA: 0x000E25C8 File Offset: 0x000E07C8
		// (set) Token: 0x06007650 RID: 30288 RVA: 0x000E25F4 File Offset: 0x000E07F4
		[ProtoMember(4, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002577 RID: 9591
		// (get) Token: 0x06007651 RID: 30289 RVA: 0x000E2604 File Offset: 0x000E0804
		// (set) Token: 0x06007652 RID: 30290 RVA: 0x000E2624 File Offset: 0x000E0824
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

		// Token: 0x06007653 RID: 30291 RVA: 0x000E2668 File Offset: 0x000E0868
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007654 RID: 30292 RVA: 0x000E2680 File Offset: 0x000E0880
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x17002578 RID: 9592
		// (get) Token: 0x06007655 RID: 30293 RVA: 0x000E268C File Offset: 0x000E088C
		// (set) Token: 0x06007656 RID: 30294 RVA: 0x000E26AD File Offset: 0x000E08AD
		[ProtoMember(5, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17002579 RID: 9593
		// (get) Token: 0x06007657 RID: 30295 RVA: 0x000E26B8 File Offset: 0x000E08B8
		// (set) Token: 0x06007658 RID: 30296 RVA: 0x000E26D4 File Offset: 0x000E08D4
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

		// Token: 0x06007659 RID: 30297 RVA: 0x000E2704 File Offset: 0x000E0904
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600765A RID: 30298 RVA: 0x000E271C File Offset: 0x000E091C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700257A RID: 9594
		// (get) Token: 0x0600765B RID: 30299 RVA: 0x000E2728 File Offset: 0x000E0928
		// (set) Token: 0x0600765C RID: 30300 RVA: 0x000E2754 File Offset: 0x000E0954
		[ProtoMember(6, IsRequired = false, Name = "titleid", DataFormat = DataFormat.TwosComplement)]
		public uint titleid
		{
			get
			{
				return this._titleid ?? 0U;
			}
			set
			{
				this._titleid = new uint?(value);
			}
		}

		// Token: 0x1700257B RID: 9595
		// (get) Token: 0x0600765D RID: 30301 RVA: 0x000E2764 File Offset: 0x000E0964
		// (set) Token: 0x0600765E RID: 30302 RVA: 0x000E2784 File Offset: 0x000E0984
		[XmlIgnore]
		[Browsable(false)]
		public bool titleidSpecified
		{
			get
			{
				return this._titleid != null;
			}
			set
			{
				bool flag = value == (this._titleid == null);
				if (flag)
				{
					this._titleid = (value ? new uint?(this.titleid) : null);
				}
			}
		}

		// Token: 0x0600765F RID: 30303 RVA: 0x000E27C8 File Offset: 0x000E09C8
		private bool ShouldSerializetitleid()
		{
			return this.titleidSpecified;
		}

		// Token: 0x06007660 RID: 30304 RVA: 0x000E27E0 File Offset: 0x000E09E0
		private void Resettitleid()
		{
			this.titleidSpecified = false;
		}

		// Token: 0x06007661 RID: 30305 RVA: 0x000E27EC File Offset: 0x000E09EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C07 RID: 7175
		private ulong? _roleid;

		// Token: 0x04001C08 RID: 7176
		private uint? _itemid;

		// Token: 0x04001C09 RID: 7177
		private uint? _itemcount;

		// Token: 0x04001C0A RID: 7178
		private uint? _time;

		// Token: 0x04001C0B RID: 7179
		private string _name;

		// Token: 0x04001C0C RID: 7180
		private uint? _titleid;

		// Token: 0x04001C0D RID: 7181
		private IExtension extensionObject;
	}
}
