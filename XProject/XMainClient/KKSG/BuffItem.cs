using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000655 RID: 1621
	[ProtoContract(Name = "BuffItem")]
	[Serializable]
	public class BuffItem : IExtensible
	{
		// Token: 0x17001FD7 RID: 8151
		// (get) Token: 0x060064EB RID: 25835 RVA: 0x000C0A18 File Offset: 0x000BEC18
		// (set) Token: 0x060064EC RID: 25836 RVA: 0x000C0A44 File Offset: 0x000BEC44
		[ProtoMember(1, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001FD8 RID: 8152
		// (get) Token: 0x060064ED RID: 25837 RVA: 0x000C0A54 File Offset: 0x000BEC54
		// (set) Token: 0x060064EE RID: 25838 RVA: 0x000C0A74 File Offset: 0x000BEC74
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

		// Token: 0x060064EF RID: 25839 RVA: 0x000C0AB8 File Offset: 0x000BECB8
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x060064F0 RID: 25840 RVA: 0x000C0AD0 File Offset: 0x000BECD0
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x17001FD9 RID: 8153
		// (get) Token: 0x060064F1 RID: 25841 RVA: 0x000C0ADC File Offset: 0x000BECDC
		// (set) Token: 0x060064F2 RID: 25842 RVA: 0x000C0B08 File Offset: 0x000BED08
		[ProtoMember(2, IsRequired = false, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001FDA RID: 8154
		// (get) Token: 0x060064F3 RID: 25843 RVA: 0x000C0B18 File Offset: 0x000BED18
		// (set) Token: 0x060064F4 RID: 25844 RVA: 0x000C0B38 File Offset: 0x000BED38
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

		// Token: 0x060064F5 RID: 25845 RVA: 0x000C0B7C File Offset: 0x000BED7C
		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		// Token: 0x060064F6 RID: 25846 RVA: 0x000C0B94 File Offset: 0x000BED94
		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		// Token: 0x17001FDB RID: 8155
		// (get) Token: 0x060064F7 RID: 25847 RVA: 0x000C0BA0 File Offset: 0x000BEDA0
		// (set) Token: 0x060064F8 RID: 25848 RVA: 0x000C0BCC File Offset: 0x000BEDCC
		[ProtoMember(3, IsRequired = false, Name = "expiretime", DataFormat = DataFormat.TwosComplement)]
		public uint expiretime
		{
			get
			{
				return this._expiretime ?? 0U;
			}
			set
			{
				this._expiretime = new uint?(value);
			}
		}

		// Token: 0x17001FDC RID: 8156
		// (get) Token: 0x060064F9 RID: 25849 RVA: 0x000C0BDC File Offset: 0x000BEDDC
		// (set) Token: 0x060064FA RID: 25850 RVA: 0x000C0BFC File Offset: 0x000BEDFC
		[XmlIgnore]
		[Browsable(false)]
		public bool expiretimeSpecified
		{
			get
			{
				return this._expiretime != null;
			}
			set
			{
				bool flag = value == (this._expiretime == null);
				if (flag)
				{
					this._expiretime = (value ? new uint?(this.expiretime) : null);
				}
			}
		}

		// Token: 0x060064FB RID: 25851 RVA: 0x000C0C40 File Offset: 0x000BEE40
		private bool ShouldSerializeexpiretime()
		{
			return this.expiretimeSpecified;
		}

		// Token: 0x060064FC RID: 25852 RVA: 0x000C0C58 File Offset: 0x000BEE58
		private void Resetexpiretime()
		{
			this.expiretimeSpecified = false;
		}

		// Token: 0x060064FD RID: 25853 RVA: 0x000C0C64 File Offset: 0x000BEE64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001878 RID: 6264
		private uint? _itemid;

		// Token: 0x04001879 RID: 6265
		private uint? _itemcount;

		// Token: 0x0400187A RID: 6266
		private uint? _expiretime;

		// Token: 0x0400187B RID: 6267
		private IExtension extensionObject;
	}
}
