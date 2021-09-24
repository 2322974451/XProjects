using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiftRecord2Db")]
	[Serializable]
	public class RiftRecord2Db : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "riftID", DataFormat = DataFormat.TwosComplement)]
		public uint riftID
		{
			get
			{
				return this._riftID ?? 0U;
			}
			set
			{
				this._riftID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool riftIDSpecified
		{
			get
			{
				return this._riftID != null;
			}
			set
			{
				bool flag = value == (this._riftID == null);
				if (flag)
				{
					this._riftID = (value ? new uint?(this.riftID) : null);
				}
			}
		}

		private bool ShouldSerializeriftID()
		{
			return this.riftIDSpecified;
		}

		private void ResetriftID()
		{
			this.riftIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public uint updateTime
		{
			get
			{
				return this._updateTime ?? 0U;
			}
			set
			{
				this._updateTime = new uint?(value);
			}
		}

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
					this._updateTime = (value ? new uint?(this.updateTime) : null);
				}
			}
		}

		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "passFloor", DataFormat = DataFormat.TwosComplement)]
		public uint passFloor
		{
			get
			{
				return this._passFloor ?? 0U;
			}
			set
			{
				this._passFloor = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool passFloorSpecified
		{
			get
			{
				return this._passFloor != null;
			}
			set
			{
				bool flag = value == (this._passFloor == null);
				if (flag)
				{
					this._passFloor = (value ? new uint?(this.passFloor) : null);
				}
			}
		}

		private bool ShouldSerializepassFloor()
		{
			return this.passFloorSpecified;
		}

		private void ResetpassFloor()
		{
			this.passFloorSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "helpSuccessCount", DataFormat = DataFormat.TwosComplement)]
		public uint helpSuccessCount
		{
			get
			{
				return this._helpSuccessCount ?? 0U;
			}
			set
			{
				this._helpSuccessCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool helpSuccessCountSpecified
		{
			get
			{
				return this._helpSuccessCount != null;
			}
			set
			{
				bool flag = value == (this._helpSuccessCount == null);
				if (flag)
				{
					this._helpSuccessCount = (value ? new uint?(this.helpSuccessCount) : null);
				}
			}
		}

		private bool ShouldSerializehelpSuccessCount()
		{
			return this.helpSuccessCountSpecified;
		}

		private void ResethelpSuccessCount()
		{
			this.helpSuccessCountSpecified = false;
		}

		[ProtoMember(5, Name = "gotWeekFirstPassReward", DataFormat = DataFormat.TwosComplement)]
		public List<uint> gotWeekFirstPassReward
		{
			get
			{
				return this._gotWeekFirstPassReward;
			}
		}

		[ProtoMember(6, Name = "gotItems", DataFormat = DataFormat.Default)]
		public List<MapIntItem> gotItems
		{
			get
			{
				return this._gotItems;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "thisWeekStartFloor", DataFormat = DataFormat.TwosComplement)]
		public uint thisWeekStartFloor
		{
			get
			{
				return this._thisWeekStartFloor ?? 0U;
			}
			set
			{
				this._thisWeekStartFloor = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool thisWeekStartFloorSpecified
		{
			get
			{
				return this._thisWeekStartFloor != null;
			}
			set
			{
				bool flag = value == (this._thisWeekStartFloor == null);
				if (flag)
				{
					this._thisWeekStartFloor = (value ? new uint?(this.thisWeekStartFloor) : null);
				}
			}
		}

		private bool ShouldSerializethisWeekStartFloor()
		{
			return this.thisWeekStartFloorSpecified;
		}

		private void ResetthisWeekStartFloor()
		{
			this.thisWeekStartFloorSpecified = false;
		}

		[ProtoMember(8, Name = "hisMaxFloor", DataFormat = DataFormat.Default)]
		public List<MapIntItem> hisMaxFloor
		{
			get
			{
				return this._hisMaxFloor;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _riftID;

		private uint? _updateTime;

		private uint? _passFloor;

		private uint? _helpSuccessCount;

		private readonly List<uint> _gotWeekFirstPassReward = new List<uint>();

		private readonly List<MapIntItem> _gotItems = new List<MapIntItem>();

		private uint? _thisWeekStartFloor;

		private readonly List<MapIntItem> _hisMaxFloor = new List<MapIntItem>();

		private IExtension extensionObject;
	}
}
