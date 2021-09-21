using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000059 RID: 89
	[ProtoContract(Name = "QueryShopItemArg")]
	[Serializable]
	public class QueryShopItemArg : IExtensible
	{
		// Token: 0x170001EA RID: 490
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x0000DF70 File Offset: 0x0000C170
		// (set) Token: 0x060005E7 RID: 1511 RVA: 0x0000DF9C File Offset: 0x0000C19C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x0000DFAC File Offset: 0x0000C1AC
		// (set) Token: 0x060005E9 RID: 1513 RVA: 0x0000DFCC File Offset: 0x0000C1CC
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0000E010 File Offset: 0x0000C210
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0000E028 File Offset: 0x0000C228
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x0000E034 File Offset: 0x0000C234
		// (set) Token: 0x060005ED RID: 1517 RVA: 0x0000E060 File Offset: 0x0000C260
		[ProtoMember(2, IsRequired = false, Name = "isrefresh", DataFormat = DataFormat.Default)]
		public bool isrefresh
		{
			get
			{
				return this._isrefresh ?? false;
			}
			set
			{
				this._isrefresh = new bool?(value);
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x0000E070 File Offset: 0x0000C270
		// (set) Token: 0x060005EF RID: 1519 RVA: 0x0000E090 File Offset: 0x0000C290
		[XmlIgnore]
		[Browsable(false)]
		public bool isrefreshSpecified
		{
			get
			{
				return this._isrefresh != null;
			}
			set
			{
				bool flag = value == (this._isrefresh == null);
				if (flag)
				{
					this._isrefresh = (value ? new bool?(this.isrefresh) : null);
				}
			}
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0000E0D4 File Offset: 0x0000C2D4
		private bool ShouldSerializeisrefresh()
		{
			return this.isrefreshSpecified;
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0000E0EC File Offset: 0x0000C2EC
		private void Resetisrefresh()
		{
			this.isrefreshSpecified = false;
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0000E0F8 File Offset: 0x0000C2F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000181 RID: 385
		private uint? _type;

		// Token: 0x04000182 RID: 386
		private bool? _isrefresh;

		// Token: 0x04000183 RID: 387
		private IExtension extensionObject;
	}
}
