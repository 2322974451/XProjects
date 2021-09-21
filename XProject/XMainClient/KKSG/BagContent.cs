using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005EA RID: 1514
	[ProtoContract(Name = "BagContent")]
	[Serializable]
	public class BagContent : IExtensible
	{
		// Token: 0x17001BCE RID: 7118
		// (get) Token: 0x0600592C RID: 22828 RVA: 0x000A9A84 File Offset: 0x000A7C84
		[ProtoMember(1, Name = "Equips", DataFormat = DataFormat.Default)]
		public List<Item> Equips
		{
			get
			{
				return this._Equips;
			}
		}

		// Token: 0x17001BCF RID: 7119
		// (get) Token: 0x0600592D RID: 22829 RVA: 0x000A9A9C File Offset: 0x000A7C9C
		[ProtoMember(2, Name = "Emblems", DataFormat = DataFormat.Default)]
		public List<Item> Emblems
		{
			get
			{
				return this._Emblems;
			}
		}

		// Token: 0x17001BD0 RID: 7120
		// (get) Token: 0x0600592E RID: 22830 RVA: 0x000A9AB4 File Offset: 0x000A7CB4
		[ProtoMember(3, Name = "Items", DataFormat = DataFormat.Default)]
		public List<Item> Items
		{
			get
			{
				return this._Items;
			}
		}

		// Token: 0x17001BD1 RID: 7121
		// (get) Token: 0x0600592F RID: 22831 RVA: 0x000A9ACC File Offset: 0x000A7CCC
		// (set) Token: 0x06005930 RID: 22832 RVA: 0x000A9AF8 File Offset: 0x000A7CF8
		[ProtoMember(4, IsRequired = false, Name = "enhanceSuit", DataFormat = DataFormat.TwosComplement)]
		public uint enhanceSuit
		{
			get
			{
				return this._enhanceSuit ?? 0U;
			}
			set
			{
				this._enhanceSuit = new uint?(value);
			}
		}

		// Token: 0x17001BD2 RID: 7122
		// (get) Token: 0x06005931 RID: 22833 RVA: 0x000A9B08 File Offset: 0x000A7D08
		// (set) Token: 0x06005932 RID: 22834 RVA: 0x000A9B28 File Offset: 0x000A7D28
		[XmlIgnore]
		[Browsable(false)]
		public bool enhanceSuitSpecified
		{
			get
			{
				return this._enhanceSuit != null;
			}
			set
			{
				bool flag = value == (this._enhanceSuit == null);
				if (flag)
				{
					this._enhanceSuit = (value ? new uint?(this.enhanceSuit) : null);
				}
			}
		}

		// Token: 0x06005933 RID: 22835 RVA: 0x000A9B6C File Offset: 0x000A7D6C
		private bool ShouldSerializeenhanceSuit()
		{
			return this.enhanceSuitSpecified;
		}

		// Token: 0x06005934 RID: 22836 RVA: 0x000A9B84 File Offset: 0x000A7D84
		private void ResetenhanceSuit()
		{
			this.enhanceSuitSpecified = false;
		}

		// Token: 0x17001BD3 RID: 7123
		// (get) Token: 0x06005935 RID: 22837 RVA: 0x000A9B90 File Offset: 0x000A7D90
		[ProtoMember(5, Name = "virtualitems", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> virtualitems
		{
			get
			{
				return this._virtualitems;
			}
		}

		// Token: 0x17001BD4 RID: 7124
		// (get) Token: 0x06005936 RID: 22838 RVA: 0x000A9BA8 File Offset: 0x000A7DA8
		[ProtoMember(6, Name = "Artifacts", DataFormat = DataFormat.Default)]
		public List<Item> Artifacts
		{
			get
			{
				return this._Artifacts;
			}
		}

		// Token: 0x17001BD5 RID: 7125
		// (get) Token: 0x06005937 RID: 22839 RVA: 0x000A9BC0 File Offset: 0x000A7DC0
		// (set) Token: 0x06005938 RID: 22840 RVA: 0x000A9BEC File Offset: 0x000A7DEC
		[ProtoMember(7, IsRequired = false, Name = "extraSkillEbSlotNum", DataFormat = DataFormat.TwosComplement)]
		public uint extraSkillEbSlotNum
		{
			get
			{
				return this._extraSkillEbSlotNum ?? 0U;
			}
			set
			{
				this._extraSkillEbSlotNum = new uint?(value);
			}
		}

		// Token: 0x17001BD6 RID: 7126
		// (get) Token: 0x06005939 RID: 22841 RVA: 0x000A9BFC File Offset: 0x000A7DFC
		// (set) Token: 0x0600593A RID: 22842 RVA: 0x000A9C1C File Offset: 0x000A7E1C
		[XmlIgnore]
		[Browsable(false)]
		public bool extraSkillEbSlotNumSpecified
		{
			get
			{
				return this._extraSkillEbSlotNum != null;
			}
			set
			{
				bool flag = value == (this._extraSkillEbSlotNum == null);
				if (flag)
				{
					this._extraSkillEbSlotNum = (value ? new uint?(this.extraSkillEbSlotNum) : null);
				}
			}
		}

		// Token: 0x0600593B RID: 22843 RVA: 0x000A9C60 File Offset: 0x000A7E60
		private bool ShouldSerializeextraSkillEbSlotNum()
		{
			return this.extraSkillEbSlotNumSpecified;
		}

		// Token: 0x0600593C RID: 22844 RVA: 0x000A9C78 File Offset: 0x000A7E78
		private void ResetextraSkillEbSlotNum()
		{
			this.extraSkillEbSlotNumSpecified = false;
		}

		// Token: 0x17001BD7 RID: 7127
		// (get) Token: 0x0600593D RID: 22845 RVA: 0x000A9C84 File Offset: 0x000A7E84
		[ProtoMember(8, Name = "expand", DataFormat = DataFormat.Default)]
		public List<BagExpandData> expand
		{
			get
			{
				return this._expand;
			}
		}

		// Token: 0x17001BD8 RID: 7128
		// (get) Token: 0x0600593E RID: 22846 RVA: 0x000A9C9C File Offset: 0x000A7E9C
		// (set) Token: 0x0600593F RID: 22847 RVA: 0x000A9CC8 File Offset: 0x000A7EC8
		[ProtoMember(9, IsRequired = false, Name = "FuseCompensation", DataFormat = DataFormat.Default)]
		public bool FuseCompensation
		{
			get
			{
				return this._FuseCompensation ?? false;
			}
			set
			{
				this._FuseCompensation = new bool?(value);
			}
		}

		// Token: 0x17001BD9 RID: 7129
		// (get) Token: 0x06005940 RID: 22848 RVA: 0x000A9CD8 File Offset: 0x000A7ED8
		// (set) Token: 0x06005941 RID: 22849 RVA: 0x000A9CF8 File Offset: 0x000A7EF8
		[XmlIgnore]
		[Browsable(false)]
		public bool FuseCompensationSpecified
		{
			get
			{
				return this._FuseCompensation != null;
			}
			set
			{
				bool flag = value == (this._FuseCompensation == null);
				if (flag)
				{
					this._FuseCompensation = (value ? new bool?(this.FuseCompensation) : null);
				}
			}
		}

		// Token: 0x06005942 RID: 22850 RVA: 0x000A9D3C File Offset: 0x000A7F3C
		private bool ShouldSerializeFuseCompensation()
		{
			return this.FuseCompensationSpecified;
		}

		// Token: 0x06005943 RID: 22851 RVA: 0x000A9D54 File Offset: 0x000A7F54
		private void ResetFuseCompensation()
		{
			this.FuseCompensationSpecified = false;
		}

		// Token: 0x17001BDA RID: 7130
		// (get) Token: 0x06005944 RID: 22852 RVA: 0x000A9D60 File Offset: 0x000A7F60
		// (set) Token: 0x06005945 RID: 22853 RVA: 0x000A9D8C File Offset: 0x000A7F8C
		[ProtoMember(10, IsRequired = false, Name = "ForgeCompensation", DataFormat = DataFormat.Default)]
		public bool ForgeCompensation
		{
			get
			{
				return this._ForgeCompensation ?? false;
			}
			set
			{
				this._ForgeCompensation = new bool?(value);
			}
		}

		// Token: 0x17001BDB RID: 7131
		// (get) Token: 0x06005946 RID: 22854 RVA: 0x000A9D9C File Offset: 0x000A7F9C
		// (set) Token: 0x06005947 RID: 22855 RVA: 0x000A9DBC File Offset: 0x000A7FBC
		[XmlIgnore]
		[Browsable(false)]
		public bool ForgeCompensationSpecified
		{
			get
			{
				return this._ForgeCompensation != null;
			}
			set
			{
				bool flag = value == (this._ForgeCompensation == null);
				if (flag)
				{
					this._ForgeCompensation = (value ? new bool?(this.ForgeCompensation) : null);
				}
			}
		}

		// Token: 0x06005948 RID: 22856 RVA: 0x000A9E00 File Offset: 0x000A8000
		private bool ShouldSerializeForgeCompensation()
		{
			return this.ForgeCompensationSpecified;
		}

		// Token: 0x06005949 RID: 22857 RVA: 0x000A9E18 File Offset: 0x000A8018
		private void ResetForgeCompensation()
		{
			this.ForgeCompensationSpecified = false;
		}

		// Token: 0x0600594A RID: 22858 RVA: 0x000A9E24 File Offset: 0x000A8024
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040015B2 RID: 5554
		private readonly List<Item> _Equips = new List<Item>();

		// Token: 0x040015B3 RID: 5555
		private readonly List<Item> _Emblems = new List<Item>();

		// Token: 0x040015B4 RID: 5556
		private readonly List<Item> _Items = new List<Item>();

		// Token: 0x040015B5 RID: 5557
		private uint? _enhanceSuit;

		// Token: 0x040015B6 RID: 5558
		private readonly List<ulong> _virtualitems = new List<ulong>();

		// Token: 0x040015B7 RID: 5559
		private readonly List<Item> _Artifacts = new List<Item>();

		// Token: 0x040015B8 RID: 5560
		private uint? _extraSkillEbSlotNum;

		// Token: 0x040015B9 RID: 5561
		private readonly List<BagExpandData> _expand = new List<BagExpandData>();

		// Token: 0x040015BA RID: 5562
		private bool? _FuseCompensation;

		// Token: 0x040015BB RID: 5563
		private bool? _ForgeCompensation;

		// Token: 0x040015BC RID: 5564
		private IExtension extensionObject;
	}
}
