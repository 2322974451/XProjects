using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonRecord2DB")]
	[Serializable]
	public class DragonRecord2DB : IExtensible
	{

		[ProtoMember(1, Name = "record", DataFormat = DataFormat.Default)]
		public List<DragonRecord> record
		{
			get
			{
				return this._record;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "updateDay", DataFormat = DataFormat.TwosComplement)]
		public int updateDay
		{
			get
			{
				return this._updateDay ?? 0;
			}
			set
			{
				this._updateDay = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updateDaySpecified
		{
			get
			{
				return this._updateDay != null;
			}
			set
			{
				bool flag = value == (this._updateDay == null);
				if (flag)
				{
					this._updateDay = (value ? new int?(this.updateDay) : null);
				}
			}
		}

		private bool ShouldSerializeupdateDay()
		{
			return this.updateDaySpecified;
		}

		private void ResetupdateDay()
		{
			this.updateDaySpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "updateHardDragonDay", DataFormat = DataFormat.TwosComplement)]
		public int updateHardDragonDay
		{
			get
			{
				return this._updateHardDragonDay ?? 0;
			}
			set
			{
				this._updateHardDragonDay = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updateHardDragonDaySpecified
		{
			get
			{
				return this._updateHardDragonDay != null;
			}
			set
			{
				bool flag = value == (this._updateHardDragonDay == null);
				if (flag)
				{
					this._updateHardDragonDay = (value ? new int?(this.updateHardDragonDay) : null);
				}
			}
		}

		private bool ShouldSerializeupdateHardDragonDay()
		{
			return this.updateHardDragonDaySpecified;
		}

		private void ResetupdateHardDragonDay()
		{
			this.updateHardDragonDaySpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "updateSmallDragonDay", DataFormat = DataFormat.TwosComplement)]
		public int updateSmallDragonDay
		{
			get
			{
				return this._updateSmallDragonDay ?? 0;
			}
			set
			{
				this._updateSmallDragonDay = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updateSmallDragonDaySpecified
		{
			get
			{
				return this._updateSmallDragonDay != null;
			}
			set
			{
				bool flag = value == (this._updateSmallDragonDay == null);
				if (flag)
				{
					this._updateSmallDragonDay = (value ? new int?(this.updateSmallDragonDay) : null);
				}
			}
		}

		private bool ShouldSerializeupdateSmallDragonDay()
		{
			return this.updateSmallDragonDaySpecified;
		}

		private void ResetupdateSmallDragonDay()
		{
			this.updateSmallDragonDaySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<DragonRecord> _record = new List<DragonRecord>();

		private int? _updateDay;

		private int? _updateHardDragonDay;

		private int? _updateSmallDragonDay;

		private IExtension extensionObject;
	}
}
