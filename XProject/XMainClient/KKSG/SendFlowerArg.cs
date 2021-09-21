using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000080 RID: 128
	[ProtoContract(Name = "SendFlowerArg")]
	[Serializable]
	public class SendFlowerArg : IExtensible
	{
		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x000123CC File Offset: 0x000105CC
		// (set) Token: 0x06000838 RID: 2104 RVA: 0x000123F9 File Offset: 0x000105F9
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

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x00012408 File Offset: 0x00010608
		// (set) Token: 0x0600083A RID: 2106 RVA: 0x00012428 File Offset: 0x00010628
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

		// Token: 0x0600083B RID: 2107 RVA: 0x0001246C File Offset: 0x0001066C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00012484 File Offset: 0x00010684
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x0600083D RID: 2109 RVA: 0x00012490 File Offset: 0x00010690
		// (set) Token: 0x0600083E RID: 2110 RVA: 0x000124BC File Offset: 0x000106BC
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x000124CC File Offset: 0x000106CC
		// (set) Token: 0x06000840 RID: 2112 RVA: 0x000124EC File Offset: 0x000106EC
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00012530 File Offset: 0x00010730
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00012548 File Offset: 0x00010748
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x00012554 File Offset: 0x00010754
		// (set) Token: 0x06000844 RID: 2116 RVA: 0x00012580 File Offset: 0x00010780
		[ProtoMember(3, IsRequired = false, Name = "sendItemID", DataFormat = DataFormat.TwosComplement)]
		public uint sendItemID
		{
			get
			{
				return this._sendItemID ?? 0U;
			}
			set
			{
				this._sendItemID = new uint?(value);
			}
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x00012590 File Offset: 0x00010790
		// (set) Token: 0x06000846 RID: 2118 RVA: 0x000125B0 File Offset: 0x000107B0
		[XmlIgnore]
		[Browsable(false)]
		public bool sendItemIDSpecified
		{
			get
			{
				return this._sendItemID != null;
			}
			set
			{
				bool flag = value == (this._sendItemID == null);
				if (flag)
				{
					this._sendItemID = (value ? new uint?(this.sendItemID) : null);
				}
			}
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x000125F4 File Offset: 0x000107F4
		private bool ShouldSerializesendItemID()
		{
			return this.sendItemIDSpecified;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x0001260C File Offset: 0x0001080C
		private void ResetsendItemID()
		{
			this.sendItemIDSpecified = false;
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x00012618 File Offset: 0x00010818
		// (set) Token: 0x0600084A RID: 2122 RVA: 0x00012644 File Offset: 0x00010844
		[ProtoMember(4, IsRequired = false, Name = "costItemID", DataFormat = DataFormat.TwosComplement)]
		public uint costItemID
		{
			get
			{
				return this._costItemID ?? 0U;
			}
			set
			{
				this._costItemID = new uint?(value);
			}
		}

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x00012654 File Offset: 0x00010854
		// (set) Token: 0x0600084C RID: 2124 RVA: 0x00012674 File Offset: 0x00010874
		[XmlIgnore]
		[Browsable(false)]
		public bool costItemIDSpecified
		{
			get
			{
				return this._costItemID != null;
			}
			set
			{
				bool flag = value == (this._costItemID == null);
				if (flag)
				{
					this._costItemID = (value ? new uint?(this.costItemID) : null);
				}
			}
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x000126B8 File Offset: 0x000108B8
		private bool ShouldSerializecostItemID()
		{
			return this.costItemIDSpecified;
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x000126D0 File Offset: 0x000108D0
		private void ResetcostItemID()
		{
			this.costItemIDSpecified = false;
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x000126DC File Offset: 0x000108DC
		// (set) Token: 0x06000850 RID: 2128 RVA: 0x00012708 File Offset: 0x00010908
		[ProtoMember(5, IsRequired = false, Name = "costItemNum", DataFormat = DataFormat.TwosComplement)]
		public uint costItemNum
		{
			get
			{
				return this._costItemNum ?? 0U;
			}
			set
			{
				this._costItemNum = new uint?(value);
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x00012718 File Offset: 0x00010918
		// (set) Token: 0x06000852 RID: 2130 RVA: 0x00012738 File Offset: 0x00010938
		[XmlIgnore]
		[Browsable(false)]
		public bool costItemNumSpecified
		{
			get
			{
				return this._costItemNum != null;
			}
			set
			{
				bool flag = value == (this._costItemNum == null);
				if (flag)
				{
					this._costItemNum = (value ? new uint?(this.costItemNum) : null);
				}
			}
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0001277C File Offset: 0x0001097C
		private bool ShouldSerializecostItemNum()
		{
			return this.costItemNumSpecified;
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00012794 File Offset: 0x00010994
		private void ResetcostItemNum()
		{
			this.costItemNumSpecified = false;
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x000127A0 File Offset: 0x000109A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400021D RID: 541
		private ulong? _roleid;

		// Token: 0x0400021E RID: 542
		private uint? _count;

		// Token: 0x0400021F RID: 543
		private uint? _sendItemID;

		// Token: 0x04000220 RID: 544
		private uint? _costItemID;

		// Token: 0x04000221 RID: 545
		private uint? _costItemNum;

		// Token: 0x04000222 RID: 546
		private IExtension extensionObject;
	}
}
