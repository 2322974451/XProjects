using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005B6 RID: 1462
	[ProtoContract(Name = "GuildZiCaiItemData")]
	[Serializable]
	public class GuildZiCaiItemData : IExtensible
	{
		// Token: 0x170018EA RID: 6378
		// (get) Token: 0x060050A9 RID: 20649 RVA: 0x000996BC File Offset: 0x000978BC
		// (set) Token: 0x060050AA RID: 20650 RVA: 0x000996E8 File Offset: 0x000978E8
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

		// Token: 0x170018EB RID: 6379
		// (get) Token: 0x060050AB RID: 20651 RVA: 0x000996F8 File Offset: 0x000978F8
		// (set) Token: 0x060050AC RID: 20652 RVA: 0x00099718 File Offset: 0x00097918
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

		// Token: 0x060050AD RID: 20653 RVA: 0x0009975C File Offset: 0x0009795C
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x060050AE RID: 20654 RVA: 0x00099774 File Offset: 0x00097974
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x170018EC RID: 6380
		// (get) Token: 0x060050AF RID: 20655 RVA: 0x00099780 File Offset: 0x00097980
		// (set) Token: 0x060050B0 RID: 20656 RVA: 0x000997AC File Offset: 0x000979AC
		[ProtoMember(2, IsRequired = false, Name = "num", DataFormat = DataFormat.TwosComplement)]
		public uint num
		{
			get
			{
				return this._num ?? 0U;
			}
			set
			{
				this._num = new uint?(value);
			}
		}

		// Token: 0x170018ED RID: 6381
		// (get) Token: 0x060050B1 RID: 20657 RVA: 0x000997BC File Offset: 0x000979BC
		// (set) Token: 0x060050B2 RID: 20658 RVA: 0x000997DC File Offset: 0x000979DC
		[XmlIgnore]
		[Browsable(false)]
		public bool numSpecified
		{
			get
			{
				return this._num != null;
			}
			set
			{
				bool flag = value == (this._num == null);
				if (flag)
				{
					this._num = (value ? new uint?(this.num) : null);
				}
			}
		}

		// Token: 0x060050B3 RID: 20659 RVA: 0x00099820 File Offset: 0x00097A20
		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		// Token: 0x060050B4 RID: 20660 RVA: 0x00099838 File Offset: 0x00097A38
		private void Resetnum()
		{
			this.numSpecified = false;
		}

		// Token: 0x170018EE RID: 6382
		// (get) Token: 0x060050B5 RID: 20661 RVA: 0x00099844 File Offset: 0x00097A44
		// (set) Token: 0x060050B6 RID: 20662 RVA: 0x00099870 File Offset: 0x00097A70
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

		// Token: 0x170018EF RID: 6383
		// (get) Token: 0x060050B7 RID: 20663 RVA: 0x00099880 File Offset: 0x00097A80
		// (set) Token: 0x060050B8 RID: 20664 RVA: 0x000998A0 File Offset: 0x00097AA0
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

		// Token: 0x060050B9 RID: 20665 RVA: 0x000998E4 File Offset: 0x00097AE4
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060050BA RID: 20666 RVA: 0x000998FC File Offset: 0x00097AFC
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x060050BB RID: 20667 RVA: 0x00099908 File Offset: 0x00097B08
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040013D2 RID: 5074
		private uint? _itemid;

		// Token: 0x040013D3 RID: 5075
		private uint? _num;

		// Token: 0x040013D4 RID: 5076
		private uint? _time;

		// Token: 0x040013D5 RID: 5077
		private IExtension extensionObject;
	}
}
