using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200060F RID: 1551
	[ProtoContract(Name = "ItemFindBackInfo")]
	[Serializable]
	public class ItemFindBackInfo : IExtensible
	{
		// Token: 0x17001D5D RID: 7517
		// (get) Token: 0x06005D9F RID: 23967 RVA: 0x000B26E4 File Offset: 0x000B08E4
		// (set) Token: 0x06005DA0 RID: 23968 RVA: 0x000B2710 File Offset: 0x000B0910
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public ItemFindBackType id
		{
			get
			{
				return this._id ?? ItemFindBackType.TOWER;
			}
			set
			{
				this._id = new ItemFindBackType?(value);
			}
		}

		// Token: 0x17001D5E RID: 7518
		// (get) Token: 0x06005DA1 RID: 23969 RVA: 0x000B2720 File Offset: 0x000B0920
		// (set) Token: 0x06005DA2 RID: 23970 RVA: 0x000B2740 File Offset: 0x000B0940
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
					this._id = (value ? new ItemFindBackType?(this.id) : null);
				}
			}
		}

		// Token: 0x06005DA3 RID: 23971 RVA: 0x000B2784 File Offset: 0x000B0984
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06005DA4 RID: 23972 RVA: 0x000B279C File Offset: 0x000B099C
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17001D5F RID: 7519
		// (get) Token: 0x06005DA5 RID: 23973 RVA: 0x000B27A8 File Offset: 0x000B09A8
		// (set) Token: 0x06005DA6 RID: 23974 RVA: 0x000B27D4 File Offset: 0x000B09D4
		[ProtoMember(2, IsRequired = false, Name = "subtype", DataFormat = DataFormat.TwosComplement)]
		public int subtype
		{
			get
			{
				return this._subtype ?? 0;
			}
			set
			{
				this._subtype = new int?(value);
			}
		}

		// Token: 0x17001D60 RID: 7520
		// (get) Token: 0x06005DA7 RID: 23975 RVA: 0x000B27E4 File Offset: 0x000B09E4
		// (set) Token: 0x06005DA8 RID: 23976 RVA: 0x000B2804 File Offset: 0x000B0A04
		[XmlIgnore]
		[Browsable(false)]
		public bool subtypeSpecified
		{
			get
			{
				return this._subtype != null;
			}
			set
			{
				bool flag = value == (this._subtype == null);
				if (flag)
				{
					this._subtype = (value ? new int?(this.subtype) : null);
				}
			}
		}

		// Token: 0x06005DA9 RID: 23977 RVA: 0x000B2848 File Offset: 0x000B0A48
		private bool ShouldSerializesubtype()
		{
			return this.subtypeSpecified;
		}

		// Token: 0x06005DAA RID: 23978 RVA: 0x000B2860 File Offset: 0x000B0A60
		private void Resetsubtype()
		{
			this.subtypeSpecified = false;
		}

		// Token: 0x17001D61 RID: 7521
		// (get) Token: 0x06005DAB RID: 23979 RVA: 0x000B286C File Offset: 0x000B0A6C
		// (set) Token: 0x06005DAC RID: 23980 RVA: 0x000B2898 File Offset: 0x000B0A98
		[ProtoMember(3, IsRequired = false, Name = "useCount", DataFormat = DataFormat.TwosComplement)]
		public int useCount
		{
			get
			{
				return this._useCount ?? 0;
			}
			set
			{
				this._useCount = new int?(value);
			}
		}

		// Token: 0x17001D62 RID: 7522
		// (get) Token: 0x06005DAD RID: 23981 RVA: 0x000B28A8 File Offset: 0x000B0AA8
		// (set) Token: 0x06005DAE RID: 23982 RVA: 0x000B28C8 File Offset: 0x000B0AC8
		[XmlIgnore]
		[Browsable(false)]
		public bool useCountSpecified
		{
			get
			{
				return this._useCount != null;
			}
			set
			{
				bool flag = value == (this._useCount == null);
				if (flag)
				{
					this._useCount = (value ? new int?(this.useCount) : null);
				}
			}
		}

		// Token: 0x06005DAF RID: 23983 RVA: 0x000B290C File Offset: 0x000B0B0C
		private bool ShouldSerializeuseCount()
		{
			return this.useCountSpecified;
		}

		// Token: 0x06005DB0 RID: 23984 RVA: 0x000B2924 File Offset: 0x000B0B24
		private void ResetuseCount()
		{
			this.useCountSpecified = false;
		}

		// Token: 0x17001D63 RID: 7523
		// (get) Token: 0x06005DB1 RID: 23985 RVA: 0x000B2930 File Offset: 0x000B0B30
		// (set) Token: 0x06005DB2 RID: 23986 RVA: 0x000B295C File Offset: 0x000B0B5C
		[ProtoMember(4, IsRequired = false, Name = "towerLevel", DataFormat = DataFormat.TwosComplement)]
		public int towerLevel
		{
			get
			{
				return this._towerLevel ?? 0;
			}
			set
			{
				this._towerLevel = new int?(value);
			}
		}

		// Token: 0x17001D64 RID: 7524
		// (get) Token: 0x06005DB3 RID: 23987 RVA: 0x000B296C File Offset: 0x000B0B6C
		// (set) Token: 0x06005DB4 RID: 23988 RVA: 0x000B298C File Offset: 0x000B0B8C
		[XmlIgnore]
		[Browsable(false)]
		public bool towerLevelSpecified
		{
			get
			{
				return this._towerLevel != null;
			}
			set
			{
				bool flag = value == (this._towerLevel == null);
				if (flag)
				{
					this._towerLevel = (value ? new int?(this.towerLevel) : null);
				}
			}
		}

		// Token: 0x06005DB5 RID: 23989 RVA: 0x000B29D0 File Offset: 0x000B0BD0
		private bool ShouldSerializetowerLevel()
		{
			return this.towerLevelSpecified;
		}

		// Token: 0x06005DB6 RID: 23990 RVA: 0x000B29E8 File Offset: 0x000B0BE8
		private void ResettowerLevel()
		{
			this.towerLevelSpecified = false;
		}

		// Token: 0x17001D65 RID: 7525
		// (get) Token: 0x06005DB7 RID: 23991 RVA: 0x000B29F4 File Offset: 0x000B0BF4
		// (set) Token: 0x06005DB8 RID: 23992 RVA: 0x000B2A20 File Offset: 0x000B0C20
		[ProtoMember(5, IsRequired = false, Name = "dayTime", DataFormat = DataFormat.TwosComplement)]
		public int dayTime
		{
			get
			{
				return this._dayTime ?? 0;
			}
			set
			{
				this._dayTime = new int?(value);
			}
		}

		// Token: 0x17001D66 RID: 7526
		// (get) Token: 0x06005DB9 RID: 23993 RVA: 0x000B2A30 File Offset: 0x000B0C30
		// (set) Token: 0x06005DBA RID: 23994 RVA: 0x000B2A50 File Offset: 0x000B0C50
		[XmlIgnore]
		[Browsable(false)]
		public bool dayTimeSpecified
		{
			get
			{
				return this._dayTime != null;
			}
			set
			{
				bool flag = value == (this._dayTime == null);
				if (flag)
				{
					this._dayTime = (value ? new int?(this.dayTime) : null);
				}
			}
		}

		// Token: 0x06005DBB RID: 23995 RVA: 0x000B2A94 File Offset: 0x000B0C94
		private bool ShouldSerializedayTime()
		{
			return this.dayTimeSpecified;
		}

		// Token: 0x06005DBC RID: 23996 RVA: 0x000B2AAC File Offset: 0x000B0CAC
		private void ResetdayTime()
		{
			this.dayTimeSpecified = false;
		}

		// Token: 0x17001D67 RID: 7527
		// (get) Token: 0x06005DBD RID: 23997 RVA: 0x000B2AB8 File Offset: 0x000B0CB8
		// (set) Token: 0x06005DBE RID: 23998 RVA: 0x000B2AE4 File Offset: 0x000B0CE4
		[ProtoMember(6, IsRequired = false, Name = "findBackCount", DataFormat = DataFormat.TwosComplement)]
		public int findBackCount
		{
			get
			{
				return this._findBackCount ?? 0;
			}
			set
			{
				this._findBackCount = new int?(value);
			}
		}

		// Token: 0x17001D68 RID: 7528
		// (get) Token: 0x06005DBF RID: 23999 RVA: 0x000B2AF4 File Offset: 0x000B0CF4
		// (set) Token: 0x06005DC0 RID: 24000 RVA: 0x000B2B14 File Offset: 0x000B0D14
		[XmlIgnore]
		[Browsable(false)]
		public bool findBackCountSpecified
		{
			get
			{
				return this._findBackCount != null;
			}
			set
			{
				bool flag = value == (this._findBackCount == null);
				if (flag)
				{
					this._findBackCount = (value ? new int?(this.findBackCount) : null);
				}
			}
		}

		// Token: 0x06005DC1 RID: 24001 RVA: 0x000B2B58 File Offset: 0x000B0D58
		private bool ShouldSerializefindBackCount()
		{
			return this.findBackCountSpecified;
		}

		// Token: 0x06005DC2 RID: 24002 RVA: 0x000B2B70 File Offset: 0x000B0D70
		private void ResetfindBackCount()
		{
			this.findBackCountSpecified = false;
		}

		// Token: 0x17001D69 RID: 7529
		// (get) Token: 0x06005DC3 RID: 24003 RVA: 0x000B2B7C File Offset: 0x000B0D7C
		// (set) Token: 0x06005DC4 RID: 24004 RVA: 0x000B2BA8 File Offset: 0x000B0DA8
		[ProtoMember(7, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		// Token: 0x17001D6A RID: 7530
		// (get) Token: 0x06005DC5 RID: 24005 RVA: 0x000B2BB8 File Offset: 0x000B0DB8
		// (set) Token: 0x06005DC6 RID: 24006 RVA: 0x000B2BD8 File Offset: 0x000B0DD8
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		// Token: 0x06005DC7 RID: 24007 RVA: 0x000B2C1C File Offset: 0x000B0E1C
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06005DC8 RID: 24008 RVA: 0x000B2C34 File Offset: 0x000B0E34
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17001D6B RID: 7531
		// (get) Token: 0x06005DC9 RID: 24009 RVA: 0x000B2C40 File Offset: 0x000B0E40
		[ProtoMember(8, Name = "onceBackExp", DataFormat = DataFormat.Default)]
		public List<MapIntItem> onceBackExp
		{
			get
			{
				return this._onceBackExp;
			}
		}

		// Token: 0x06005DCA RID: 24010 RVA: 0x000B2C58 File Offset: 0x000B0E58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016C2 RID: 5826
		private ItemFindBackType? _id;

		// Token: 0x040016C3 RID: 5827
		private int? _subtype;

		// Token: 0x040016C4 RID: 5828
		private int? _useCount;

		// Token: 0x040016C5 RID: 5829
		private int? _towerLevel;

		// Token: 0x040016C6 RID: 5830
		private int? _dayTime;

		// Token: 0x040016C7 RID: 5831
		private int? _findBackCount;

		// Token: 0x040016C8 RID: 5832
		private int? _level;

		// Token: 0x040016C9 RID: 5833
		private readonly List<MapIntItem> _onceBackExp = new List<MapIntItem>();

		// Token: 0x040016CA RID: 5834
		private IExtension extensionObject;
	}
}
