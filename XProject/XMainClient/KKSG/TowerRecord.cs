using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005E4 RID: 1508
	[ProtoContract(Name = "TowerRecord")]
	[Serializable]
	public class TowerRecord : IExtensible
	{
		// Token: 0x17001B39 RID: 6969
		// (get) Token: 0x060057A1 RID: 22433 RVA: 0x000A6E7C File Offset: 0x000A507C
		// (set) Token: 0x060057A2 RID: 22434 RVA: 0x000A6EA8 File Offset: 0x000A50A8
		[ProtoMember(1, IsRequired = false, Name = "openHardLevel", DataFormat = DataFormat.TwosComplement)]
		public int openHardLevel
		{
			get
			{
				return this._openHardLevel ?? 0;
			}
			set
			{
				this._openHardLevel = new int?(value);
			}
		}

		// Token: 0x17001B3A RID: 6970
		// (get) Token: 0x060057A3 RID: 22435 RVA: 0x000A6EB8 File Offset: 0x000A50B8
		// (set) Token: 0x060057A4 RID: 22436 RVA: 0x000A6ED8 File Offset: 0x000A50D8
		[XmlIgnore]
		[Browsable(false)]
		public bool openHardLevelSpecified
		{
			get
			{
				return this._openHardLevel != null;
			}
			set
			{
				bool flag = value == (this._openHardLevel == null);
				if (flag)
				{
					this._openHardLevel = (value ? new int?(this.openHardLevel) : null);
				}
			}
		}

		// Token: 0x060057A5 RID: 22437 RVA: 0x000A6F1C File Offset: 0x000A511C
		private bool ShouldSerializeopenHardLevel()
		{
			return this.openHardLevelSpecified;
		}

		// Token: 0x060057A6 RID: 22438 RVA: 0x000A6F34 File Offset: 0x000A5134
		private void ResetopenHardLevel()
		{
			this.openHardLevelSpecified = false;
		}

		// Token: 0x17001B3B RID: 6971
		// (get) Token: 0x060057A7 RID: 22439 RVA: 0x000A6F40 File Offset: 0x000A5140
		// (set) Token: 0x060057A8 RID: 22440 RVA: 0x000A6F6C File Offset: 0x000A516C
		[ProtoMember(2, IsRequired = false, Name = "reachTopFloor", DataFormat = DataFormat.TwosComplement)]
		public int reachTopFloor
		{
			get
			{
				return this._reachTopFloor ?? 0;
			}
			set
			{
				this._reachTopFloor = new int?(value);
			}
		}

		// Token: 0x17001B3C RID: 6972
		// (get) Token: 0x060057A9 RID: 22441 RVA: 0x000A6F7C File Offset: 0x000A517C
		// (set) Token: 0x060057AA RID: 22442 RVA: 0x000A6F9C File Offset: 0x000A519C
		[XmlIgnore]
		[Browsable(false)]
		public bool reachTopFloorSpecified
		{
			get
			{
				return this._reachTopFloor != null;
			}
			set
			{
				bool flag = value == (this._reachTopFloor == null);
				if (flag)
				{
					this._reachTopFloor = (value ? new int?(this.reachTopFloor) : null);
				}
			}
		}

		// Token: 0x060057AB RID: 22443 RVA: 0x000A6FE0 File Offset: 0x000A51E0
		private bool ShouldSerializereachTopFloor()
		{
			return this.reachTopFloorSpecified;
		}

		// Token: 0x060057AC RID: 22444 RVA: 0x000A6FF8 File Offset: 0x000A51F8
		private void ResetreachTopFloor()
		{
			this.reachTopFloorSpecified = false;
		}

		// Token: 0x17001B3D RID: 6973
		// (get) Token: 0x060057AD RID: 22445 RVA: 0x000A7004 File Offset: 0x000A5204
		// (set) Token: 0x060057AE RID: 22446 RVA: 0x000A7030 File Offset: 0x000A5230
		[ProtoMember(3, IsRequired = false, Name = "bestTime", DataFormat = DataFormat.TwosComplement)]
		public int bestTime
		{
			get
			{
				return this._bestTime ?? 0;
			}
			set
			{
				this._bestTime = new int?(value);
			}
		}

		// Token: 0x17001B3E RID: 6974
		// (get) Token: 0x060057AF RID: 22447 RVA: 0x000A7040 File Offset: 0x000A5240
		// (set) Token: 0x060057B0 RID: 22448 RVA: 0x000A7060 File Offset: 0x000A5260
		[XmlIgnore]
		[Browsable(false)]
		public bool bestTimeSpecified
		{
			get
			{
				return this._bestTime != null;
			}
			set
			{
				bool flag = value == (this._bestTime == null);
				if (flag)
				{
					this._bestTime = (value ? new int?(this.bestTime) : null);
				}
			}
		}

		// Token: 0x060057B1 RID: 22449 RVA: 0x000A70A4 File Offset: 0x000A52A4
		private bool ShouldSerializebestTime()
		{
			return this.bestTimeSpecified;
		}

		// Token: 0x060057B2 RID: 22450 RVA: 0x000A70BC File Offset: 0x000A52BC
		private void ResetbestTime()
		{
			this.bestTimeSpecified = false;
		}

		// Token: 0x17001B3F RID: 6975
		// (get) Token: 0x060057B3 RID: 22451 RVA: 0x000A70C8 File Offset: 0x000A52C8
		// (set) Token: 0x060057B4 RID: 22452 RVA: 0x000A70F4 File Offset: 0x000A52F4
		[ProtoMember(4, IsRequired = false, Name = "sweepTime", DataFormat = DataFormat.TwosComplement)]
		public int sweepTime
		{
			get
			{
				return this._sweepTime ?? 0;
			}
			set
			{
				this._sweepTime = new int?(value);
			}
		}

		// Token: 0x17001B40 RID: 6976
		// (get) Token: 0x060057B5 RID: 22453 RVA: 0x000A7104 File Offset: 0x000A5304
		// (set) Token: 0x060057B6 RID: 22454 RVA: 0x000A7124 File Offset: 0x000A5324
		[XmlIgnore]
		[Browsable(false)]
		public bool sweepTimeSpecified
		{
			get
			{
				return this._sweepTime != null;
			}
			set
			{
				bool flag = value == (this._sweepTime == null);
				if (flag)
				{
					this._sweepTime = (value ? new int?(this.sweepTime) : null);
				}
			}
		}

		// Token: 0x060057B7 RID: 22455 RVA: 0x000A7168 File Offset: 0x000A5368
		private bool ShouldSerializesweepTime()
		{
			return this.sweepTimeSpecified;
		}

		// Token: 0x060057B8 RID: 22456 RVA: 0x000A7180 File Offset: 0x000A5380
		private void ResetsweepTime()
		{
			this.sweepTimeSpecified = false;
		}

		// Token: 0x17001B41 RID: 6977
		// (get) Token: 0x060057B9 RID: 22457 RVA: 0x000A718C File Offset: 0x000A538C
		// (set) Token: 0x060057BA RID: 22458 RVA: 0x000A71B8 File Offset: 0x000A53B8
		[ProtoMember(5, IsRequired = false, Name = "sweepFloor", DataFormat = DataFormat.TwosComplement)]
		public int sweepFloor
		{
			get
			{
				return this._sweepFloor ?? 0;
			}
			set
			{
				this._sweepFloor = new int?(value);
			}
		}

		// Token: 0x17001B42 RID: 6978
		// (get) Token: 0x060057BB RID: 22459 RVA: 0x000A71C8 File Offset: 0x000A53C8
		// (set) Token: 0x060057BC RID: 22460 RVA: 0x000A71E8 File Offset: 0x000A53E8
		[XmlIgnore]
		[Browsable(false)]
		public bool sweepFloorSpecified
		{
			get
			{
				return this._sweepFloor != null;
			}
			set
			{
				bool flag = value == (this._sweepFloor == null);
				if (flag)
				{
					this._sweepFloor = (value ? new int?(this.sweepFloor) : null);
				}
			}
		}

		// Token: 0x060057BD RID: 22461 RVA: 0x000A722C File Offset: 0x000A542C
		private bool ShouldSerializesweepFloor()
		{
			return this.sweepFloorSpecified;
		}

		// Token: 0x060057BE RID: 22462 RVA: 0x000A7244 File Offset: 0x000A5444
		private void ResetsweepFloor()
		{
			this.sweepFloorSpecified = false;
		}

		// Token: 0x17001B43 RID: 6979
		// (get) Token: 0x060057BF RID: 22463 RVA: 0x000A7250 File Offset: 0x000A5450
		// (set) Token: 0x060057C0 RID: 22464 RVA: 0x000A727C File Offset: 0x000A547C
		[ProtoMember(6, IsRequired = false, Name = "curFloor", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001B44 RID: 6980
		// (get) Token: 0x060057C1 RID: 22465 RVA: 0x000A728C File Offset: 0x000A548C
		// (set) Token: 0x060057C2 RID: 22466 RVA: 0x000A72AC File Offset: 0x000A54AC
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

		// Token: 0x060057C3 RID: 22467 RVA: 0x000A72F0 File Offset: 0x000A54F0
		private bool ShouldSerializecurFloor()
		{
			return this.curFloorSpecified;
		}

		// Token: 0x060057C4 RID: 22468 RVA: 0x000A7308 File Offset: 0x000A5508
		private void ResetcurFloor()
		{
			this.curFloorSpecified = false;
		}

		// Token: 0x17001B45 RID: 6981
		// (get) Token: 0x060057C5 RID: 22469 RVA: 0x000A7314 File Offset: 0x000A5514
		// (set) Token: 0x060057C6 RID: 22470 RVA: 0x000A7340 File Offset: 0x000A5540
		[ProtoMember(7, IsRequired = false, Name = "curCostTime", DataFormat = DataFormat.TwosComplement)]
		public int curCostTime
		{
			get
			{
				return this._curCostTime ?? 0;
			}
			set
			{
				this._curCostTime = new int?(value);
			}
		}

		// Token: 0x17001B46 RID: 6982
		// (get) Token: 0x060057C7 RID: 22471 RVA: 0x000A7350 File Offset: 0x000A5550
		// (set) Token: 0x060057C8 RID: 22472 RVA: 0x000A7370 File Offset: 0x000A5570
		[XmlIgnore]
		[Browsable(false)]
		public bool curCostTimeSpecified
		{
			get
			{
				return this._curCostTime != null;
			}
			set
			{
				bool flag = value == (this._curCostTime == null);
				if (flag)
				{
					this._curCostTime = (value ? new int?(this.curCostTime) : null);
				}
			}
		}

		// Token: 0x060057C9 RID: 22473 RVA: 0x000A73B4 File Offset: 0x000A55B4
		private bool ShouldSerializecurCostTime()
		{
			return this.curCostTimeSpecified;
		}

		// Token: 0x060057CA RID: 22474 RVA: 0x000A73CC File Offset: 0x000A55CC
		private void ResetcurCostTime()
		{
			this.curCostTimeSpecified = false;
		}

		// Token: 0x17001B47 RID: 6983
		// (get) Token: 0x060057CB RID: 22475 RVA: 0x000A73D8 File Offset: 0x000A55D8
		// (set) Token: 0x060057CC RID: 22476 RVA: 0x000A7404 File Offset: 0x000A5604
		[ProtoMember(8, IsRequired = false, Name = "refreshCount", DataFormat = DataFormat.TwosComplement)]
		public int refreshCount
		{
			get
			{
				return this._refreshCount ?? 0;
			}
			set
			{
				this._refreshCount = new int?(value);
			}
		}

		// Token: 0x17001B48 RID: 6984
		// (get) Token: 0x060057CD RID: 22477 RVA: 0x000A7414 File Offset: 0x000A5614
		// (set) Token: 0x060057CE RID: 22478 RVA: 0x000A7434 File Offset: 0x000A5634
		[XmlIgnore]
		[Browsable(false)]
		public bool refreshCountSpecified
		{
			get
			{
				return this._refreshCount != null;
			}
			set
			{
				bool flag = value == (this._refreshCount == null);
				if (flag)
				{
					this._refreshCount = (value ? new int?(this.refreshCount) : null);
				}
			}
		}

		// Token: 0x060057CF RID: 22479 RVA: 0x000A7478 File Offset: 0x000A5678
		private bool ShouldSerializerefreshCount()
		{
			return this.refreshCountSpecified;
		}

		// Token: 0x060057D0 RID: 22480 RVA: 0x000A7490 File Offset: 0x000A5690
		private void ResetrefreshCount()
		{
			this.refreshCountSpecified = false;
		}

		// Token: 0x17001B49 RID: 6985
		// (get) Token: 0x060057D1 RID: 22481 RVA: 0x000A749C File Offset: 0x000A569C
		// (set) Token: 0x060057D2 RID: 22482 RVA: 0x000A74C8 File Offset: 0x000A56C8
		[ProtoMember(9, IsRequired = false, Name = "refreshResult", DataFormat = DataFormat.TwosComplement)]
		public int refreshResult
		{
			get
			{
				return this._refreshResult ?? 0;
			}
			set
			{
				this._refreshResult = new int?(value);
			}
		}

		// Token: 0x17001B4A RID: 6986
		// (get) Token: 0x060057D3 RID: 22483 RVA: 0x000A74D8 File Offset: 0x000A56D8
		// (set) Token: 0x060057D4 RID: 22484 RVA: 0x000A74F8 File Offset: 0x000A56F8
		[XmlIgnore]
		[Browsable(false)]
		public bool refreshResultSpecified
		{
			get
			{
				return this._refreshResult != null;
			}
			set
			{
				bool flag = value == (this._refreshResult == null);
				if (flag)
				{
					this._refreshResult = (value ? new int?(this.refreshResult) : null);
				}
			}
		}

		// Token: 0x060057D5 RID: 22485 RVA: 0x000A753C File Offset: 0x000A573C
		private bool ShouldSerializerefreshResult()
		{
			return this.refreshResultSpecified;
		}

		// Token: 0x060057D6 RID: 22486 RVA: 0x000A7554 File Offset: 0x000A5754
		private void ResetrefreshResult()
		{
			this.refreshResultSpecified = false;
		}

		// Token: 0x17001B4B RID: 6987
		// (get) Token: 0x060057D7 RID: 22487 RVA: 0x000A7560 File Offset: 0x000A5760
		[ProtoMember(10, Name = "gotFloorFirstPassReward", DataFormat = DataFormat.TwosComplement)]
		public List<int> gotFloorFirstPassReward
		{
			get
			{
				return this._gotFloorFirstPassReward;
			}
		}

		// Token: 0x060057D8 RID: 22488 RVA: 0x000A7578 File Offset: 0x000A5778
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001542 RID: 5442
		private int? _openHardLevel;

		// Token: 0x04001543 RID: 5443
		private int? _reachTopFloor;

		// Token: 0x04001544 RID: 5444
		private int? _bestTime;

		// Token: 0x04001545 RID: 5445
		private int? _sweepTime;

		// Token: 0x04001546 RID: 5446
		private int? _sweepFloor;

		// Token: 0x04001547 RID: 5447
		private int? _curFloor;

		// Token: 0x04001548 RID: 5448
		private int? _curCostTime;

		// Token: 0x04001549 RID: 5449
		private int? _refreshCount;

		// Token: 0x0400154A RID: 5450
		private int? _refreshResult;

		// Token: 0x0400154B RID: 5451
		private readonly List<int> _gotFloorFirstPassReward = new List<int>();

		// Token: 0x0400154C RID: 5452
		private IExtension extensionObject;
	}
}
