using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TowerRecord")]
	[Serializable]
	public class TowerRecord : IExtensible
	{

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

		private bool ShouldSerializeopenHardLevel()
		{
			return this.openHardLevelSpecified;
		}

		private void ResetopenHardLevel()
		{
			this.openHardLevelSpecified = false;
		}

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

		private bool ShouldSerializereachTopFloor()
		{
			return this.reachTopFloorSpecified;
		}

		private void ResetreachTopFloor()
		{
			this.reachTopFloorSpecified = false;
		}

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

		private bool ShouldSerializebestTime()
		{
			return this.bestTimeSpecified;
		}

		private void ResetbestTime()
		{
			this.bestTimeSpecified = false;
		}

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

		private bool ShouldSerializesweepTime()
		{
			return this.sweepTimeSpecified;
		}

		private void ResetsweepTime()
		{
			this.sweepTimeSpecified = false;
		}

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

		private bool ShouldSerializesweepFloor()
		{
			return this.sweepFloorSpecified;
		}

		private void ResetsweepFloor()
		{
			this.sweepFloorSpecified = false;
		}

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

		private bool ShouldSerializecurFloor()
		{
			return this.curFloorSpecified;
		}

		private void ResetcurFloor()
		{
			this.curFloorSpecified = false;
		}

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

		private bool ShouldSerializecurCostTime()
		{
			return this.curCostTimeSpecified;
		}

		private void ResetcurCostTime()
		{
			this.curCostTimeSpecified = false;
		}

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

		private bool ShouldSerializerefreshCount()
		{
			return this.refreshCountSpecified;
		}

		private void ResetrefreshCount()
		{
			this.refreshCountSpecified = false;
		}

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

		private bool ShouldSerializerefreshResult()
		{
			return this.refreshResultSpecified;
		}

		private void ResetrefreshResult()
		{
			this.refreshResultSpecified = false;
		}

		[ProtoMember(10, Name = "gotFloorFirstPassReward", DataFormat = DataFormat.TwosComplement)]
		public List<int> gotFloorFirstPassReward
		{
			get
			{
				return this._gotFloorFirstPassReward;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _openHardLevel;

		private int? _reachTopFloor;

		private int? _bestTime;

		private int? _sweepTime;

		private int? _sweepFloor;

		private int? _curFloor;

		private int? _curCostTime;

		private int? _refreshCount;

		private int? _refreshResult;

		private readonly List<int> _gotFloorFirstPassReward = new List<int>();

		private IExtension extensionObject;
	}
}
