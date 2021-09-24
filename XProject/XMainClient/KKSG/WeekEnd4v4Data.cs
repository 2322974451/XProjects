using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeekEnd4v4Data")]
	[Serializable]
	public class WeekEnd4v4Data : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "indexWeekEnd", DataFormat = DataFormat.TwosComplement)]
		public uint indexWeekEnd
		{
			get
			{
				return this._indexWeekEnd ?? 0U;
			}
			set
			{
				this._indexWeekEnd = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool indexWeekEndSpecified
		{
			get
			{
				return this._indexWeekEnd != null;
			}
			set
			{
				bool flag = value == (this._indexWeekEnd == null);
				if (flag)
				{
					this._indexWeekEnd = (value ? new uint?(this.indexWeekEnd) : null);
				}
			}
		}

		private bool ShouldSerializeindexWeekEnd()
		{
			return this.indexWeekEndSpecified;
		}

		private void ResetindexWeekEnd()
		{
			this.indexWeekEndSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "activityID", DataFormat = DataFormat.TwosComplement)]
		public uint activityID
		{
			get
			{
				return this._activityID ?? 0U;
			}
			set
			{
				this._activityID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool activityIDSpecified
		{
			get
			{
				return this._activityID != null;
			}
			set
			{
				bool flag = value == (this._activityID == null);
				if (flag)
				{
					this._activityID = (value ? new uint?(this.activityID) : null);
				}
			}
		}

		private bool ShouldSerializeactivityID()
		{
			return this.activityIDSpecified;
		}

		private void ResetactivityID()
		{
			this.activityIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
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

		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		private void Resetcount()
		{
			this.countSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _indexWeekEnd;

		private uint? _activityID;

		private uint? _count;

		private IExtension extensionObject;
	}
}
