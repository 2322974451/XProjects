using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000619 RID: 1561
	[ProtoContract(Name = "DragonRecord")]
	[Serializable]
	public class DragonRecord : IExtensible
	{
		// Token: 0x17001DC5 RID: 7621
		// (get) Token: 0x06005ED7 RID: 24279 RVA: 0x000B4D8C File Offset: 0x000B2F8C
		// (set) Token: 0x06005ED8 RID: 24280 RVA: 0x000B4DB8 File Offset: 0x000B2FB8
		[ProtoMember(1, IsRequired = false, Name = "dragonType", DataFormat = DataFormat.TwosComplement)]
		public int dragonType
		{
			get
			{
				return this._dragonType ?? 0;
			}
			set
			{
				this._dragonType = new int?(value);
			}
		}

		// Token: 0x17001DC6 RID: 7622
		// (get) Token: 0x06005ED9 RID: 24281 RVA: 0x000B4DC8 File Offset: 0x000B2FC8
		// (set) Token: 0x06005EDA RID: 24282 RVA: 0x000B4DE8 File Offset: 0x000B2FE8
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonTypeSpecified
		{
			get
			{
				return this._dragonType != null;
			}
			set
			{
				bool flag = value == (this._dragonType == null);
				if (flag)
				{
					this._dragonType = (value ? new int?(this.dragonType) : null);
				}
			}
		}

		// Token: 0x06005EDB RID: 24283 RVA: 0x000B4E2C File Offset: 0x000B302C
		private bool ShouldSerializedragonType()
		{
			return this.dragonTypeSpecified;
		}

		// Token: 0x06005EDC RID: 24284 RVA: 0x000B4E44 File Offset: 0x000B3044
		private void ResetdragonType()
		{
			this.dragonTypeSpecified = false;
		}

		// Token: 0x17001DC7 RID: 7623
		// (get) Token: 0x06005EDD RID: 24285 RVA: 0x000B4E50 File Offset: 0x000B3050
		// (set) Token: 0x06005EDE RID: 24286 RVA: 0x000B4E7C File Offset: 0x000B307C
		[ProtoMember(2, IsRequired = false, Name = "hardLevel", DataFormat = DataFormat.TwosComplement)]
		public int hardLevel
		{
			get
			{
				return this._hardLevel ?? 0;
			}
			set
			{
				this._hardLevel = new int?(value);
			}
		}

		// Token: 0x17001DC8 RID: 7624
		// (get) Token: 0x06005EDF RID: 24287 RVA: 0x000B4E8C File Offset: 0x000B308C
		// (set) Token: 0x06005EE0 RID: 24288 RVA: 0x000B4EAC File Offset: 0x000B30AC
		[XmlIgnore]
		[Browsable(false)]
		public bool hardLevelSpecified
		{
			get
			{
				return this._hardLevel != null;
			}
			set
			{
				bool flag = value == (this._hardLevel == null);
				if (flag)
				{
					this._hardLevel = (value ? new int?(this.hardLevel) : null);
				}
			}
		}

		// Token: 0x06005EE1 RID: 24289 RVA: 0x000B4EF0 File Offset: 0x000B30F0
		private bool ShouldSerializehardLevel()
		{
			return this.hardLevelSpecified;
		}

		// Token: 0x06005EE2 RID: 24290 RVA: 0x000B4F08 File Offset: 0x000B3108
		private void ResethardLevel()
		{
			this.hardLevelSpecified = false;
		}

		// Token: 0x17001DC9 RID: 7625
		// (get) Token: 0x06005EE3 RID: 24291 RVA: 0x000B4F14 File Offset: 0x000B3114
		// (set) Token: 0x06005EE4 RID: 24292 RVA: 0x000B4F40 File Offset: 0x000B3140
		[ProtoMember(3, IsRequired = false, Name = "curFloor", DataFormat = DataFormat.TwosComplement)]
		public int curFloor
		{
			get
			{
				return this._curFloor ?? 0;
			}
			set
			{
				this._curFloor = new int?(value);
			}
		}

		// Token: 0x17001DCA RID: 7626
		// (get) Token: 0x06005EE5 RID: 24293 RVA: 0x000B4F50 File Offset: 0x000B3150
		// (set) Token: 0x06005EE6 RID: 24294 RVA: 0x000B4F70 File Offset: 0x000B3170
		[XmlIgnore]
		[Browsable(false)]
		public bool curFloorSpecified
		{
			get
			{
				return this._curFloor != null;
			}
			set
			{
				bool flag = value == (this._curFloor == null);
				if (flag)
				{
					this._curFloor = (value ? new int?(this.curFloor) : null);
				}
			}
		}

		// Token: 0x06005EE7 RID: 24295 RVA: 0x000B4FB4 File Offset: 0x000B31B4
		private bool ShouldSerializecurFloor()
		{
			return this.curFloorSpecified;
		}

		// Token: 0x06005EE8 RID: 24296 RVA: 0x000B4FCC File Offset: 0x000B31CC
		private void ResetcurFloor()
		{
			this.curFloorSpecified = false;
		}

		// Token: 0x17001DCB RID: 7627
		// (get) Token: 0x06005EE9 RID: 24297 RVA: 0x000B4FD8 File Offset: 0x000B31D8
		// (set) Token: 0x06005EEA RID: 24298 RVA: 0x000B5004 File Offset: 0x000B3204
		[ProtoMember(4, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public int updateTime
		{
			get
			{
				return this._updateTime ?? 0;
			}
			set
			{
				this._updateTime = new int?(value);
			}
		}

		// Token: 0x17001DCC RID: 7628
		// (get) Token: 0x06005EEB RID: 24299 RVA: 0x000B5014 File Offset: 0x000B3214
		// (set) Token: 0x06005EEC RID: 24300 RVA: 0x000B5034 File Offset: 0x000B3234
		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new int?(this.updateTime) : null);
				}
			}
		}

		// Token: 0x06005EED RID: 24301 RVA: 0x000B5078 File Offset: 0x000B3278
		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		// Token: 0x06005EEE RID: 24302 RVA: 0x000B5090 File Offset: 0x000B3290
		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		// Token: 0x17001DCD RID: 7629
		// (get) Token: 0x06005EEF RID: 24303 RVA: 0x000B509C File Offset: 0x000B329C
		// (set) Token: 0x06005EF0 RID: 24304 RVA: 0x000B50C8 File Offset: 0x000B32C8
		[ProtoMember(5, IsRequired = false, Name = "dragonDiamondBoxTimes", DataFormat = DataFormat.TwosComplement)]
		public int dragonDiamondBoxTimes
		{
			get
			{
				return this._dragonDiamondBoxTimes ?? 0;
			}
			set
			{
				this._dragonDiamondBoxTimes = new int?(value);
			}
		}

		// Token: 0x17001DCE RID: 7630
		// (get) Token: 0x06005EF1 RID: 24305 RVA: 0x000B50D8 File Offset: 0x000B32D8
		// (set) Token: 0x06005EF2 RID: 24306 RVA: 0x000B50F8 File Offset: 0x000B32F8
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonDiamondBoxTimesSpecified
		{
			get
			{
				return this._dragonDiamondBoxTimes != null;
			}
			set
			{
				bool flag = value == (this._dragonDiamondBoxTimes == null);
				if (flag)
				{
					this._dragonDiamondBoxTimes = (value ? new int?(this.dragonDiamondBoxTimes) : null);
				}
			}
		}

		// Token: 0x06005EF3 RID: 24307 RVA: 0x000B513C File Offset: 0x000B333C
		private bool ShouldSerializedragonDiamondBoxTimes()
		{
			return this.dragonDiamondBoxTimesSpecified;
		}

		// Token: 0x06005EF4 RID: 24308 RVA: 0x000B5154 File Offset: 0x000B3354
		private void ResetdragonDiamondBoxTimes()
		{
			this.dragonDiamondBoxTimesSpecified = false;
		}

		// Token: 0x06005EF5 RID: 24309 RVA: 0x000B5160 File Offset: 0x000B3360
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001705 RID: 5893
		private int? _dragonType;

		// Token: 0x04001706 RID: 5894
		private int? _hardLevel;

		// Token: 0x04001707 RID: 5895
		private int? _curFloor;

		// Token: 0x04001708 RID: 5896
		private int? _updateTime;

		// Token: 0x04001709 RID: 5897
		private int? _dragonDiamondBoxTimes;

		// Token: 0x0400170A RID: 5898
		private IExtension extensionObject;
	}
}
