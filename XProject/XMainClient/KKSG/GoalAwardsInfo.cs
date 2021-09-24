using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GoalAwardsInfo")]
	[Serializable]
	public class GoalAwardsInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "goalAwardsID", DataFormat = DataFormat.TwosComplement)]
		public uint goalAwardsID
		{
			get
			{
				return this._goalAwardsID ?? 0U;
			}
			set
			{
				this._goalAwardsID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goalAwardsIDSpecified
		{
			get
			{
				return this._goalAwardsID != null;
			}
			set
			{
				bool flag = value == (this._goalAwardsID == null);
				if (flag)
				{
					this._goalAwardsID = (value ? new uint?(this.goalAwardsID) : null);
				}
			}
		}

		private bool ShouldSerializegoalAwardsID()
		{
			return this.goalAwardsIDSpecified;
		}

		private void ResetgoalAwardsID()
		{
			this.goalAwardsIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "doneIndex", DataFormat = DataFormat.TwosComplement)]
		public uint doneIndex
		{
			get
			{
				return this._doneIndex ?? 0U;
			}
			set
			{
				this._doneIndex = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool doneIndexSpecified
		{
			get
			{
				return this._doneIndex != null;
			}
			set
			{
				bool flag = value == (this._doneIndex == null);
				if (flag)
				{
					this._doneIndex = (value ? new uint?(this.doneIndex) : null);
				}
			}
		}

		private bool ShouldSerializedoneIndex()
		{
			return this.doneIndexSpecified;
		}

		private void ResetdoneIndex()
		{
			this.doneIndexSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "gottenAwardsIndex", DataFormat = DataFormat.TwosComplement)]
		public uint gottenAwardsIndex
		{
			get
			{
				return this._gottenAwardsIndex ?? 0U;
			}
			set
			{
				this._gottenAwardsIndex = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gottenAwardsIndexSpecified
		{
			get
			{
				return this._gottenAwardsIndex != null;
			}
			set
			{
				bool flag = value == (this._gottenAwardsIndex == null);
				if (flag)
				{
					this._gottenAwardsIndex = (value ? new uint?(this.gottenAwardsIndex) : null);
				}
			}
		}

		private bool ShouldSerializegottenAwardsIndex()
		{
			return this.gottenAwardsIndexSpecified;
		}

		private void ResetgottenAwardsIndex()
		{
			this.gottenAwardsIndexSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "totalvalue", DataFormat = DataFormat.TwosComplement)]
		public double totalvalue
		{
			get
			{
				return this._totalvalue ?? 0.0;
			}
			set
			{
				this._totalvalue = new double?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalvalueSpecified
		{
			get
			{
				return this._totalvalue != null;
			}
			set
			{
				bool flag = value == (this._totalvalue == null);
				if (flag)
				{
					this._totalvalue = (value ? new double?(this.totalvalue) : null);
				}
			}
		}

		private bool ShouldSerializetotalvalue()
		{
			return this.totalvalueSpecified;
		}

		private void Resettotalvalue()
		{
			this.totalvalueSpecified = false;
		}

		[ProtoMember(5, Name = "gkidvalue", DataFormat = DataFormat.Default)]
		public List<GoalAwardsValue> gkidvalue
		{
			get
			{
				return this._gkidvalue;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _goalAwardsID;

		private uint? _doneIndex;

		private uint? _gottenAwardsIndex;

		private double? _totalvalue;

		private readonly List<GoalAwardsValue> _gkidvalue = new List<GoalAwardsValue>();

		private IExtension extensionObject;
	}
}
