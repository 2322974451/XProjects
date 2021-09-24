using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamCountInfo")]
	[Serializable]
	public class TeamCountInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "teamType", DataFormat = DataFormat.TwosComplement)]
		public int teamType
		{
			get
			{
				return this._teamType ?? 0;
			}
			set
			{
				this._teamType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamTypeSpecified
		{
			get
			{
				return this._teamType != null;
			}
			set
			{
				bool flag = value == (this._teamType == null);
				if (flag)
				{
					this._teamType = (value ? new int?(this.teamType) : null);
				}
			}
		}

		private bool ShouldSerializeteamType()
		{
			return this.teamTypeSpecified;
		}

		private void ResetteamType()
		{
			this.teamTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "finishCountToday", DataFormat = DataFormat.TwosComplement)]
		public int finishCountToday
		{
			get
			{
				return this._finishCountToday ?? 0;
			}
			set
			{
				this._finishCountToday = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool finishCountTodaySpecified
		{
			get
			{
				return this._finishCountToday != null;
			}
			set
			{
				bool flag = value == (this._finishCountToday == null);
				if (flag)
				{
					this._finishCountToday = (value ? new int?(this.finishCountToday) : null);
				}
			}
		}

		private bool ShouldSerializefinishCountToday()
		{
			return this.finishCountTodaySpecified;
		}

		private void ResetfinishCountToday()
		{
			this.finishCountTodaySpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "buyCountToday", DataFormat = DataFormat.TwosComplement)]
		public int buyCountToday
		{
			get
			{
				return this._buyCountToday ?? 0;
			}
			set
			{
				this._buyCountToday = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buyCountTodaySpecified
		{
			get
			{
				return this._buyCountToday != null;
			}
			set
			{
				bool flag = value == (this._buyCountToday == null);
				if (flag)
				{
					this._buyCountToday = (value ? new int?(this.buyCountToday) : null);
				}
			}
		}

		private bool ShouldSerializebuyCountToday()
		{
			return this.buyCountTodaySpecified;
		}

		private void ResetbuyCountToday()
		{
			this.buyCountTodaySpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "extraAddCount", DataFormat = DataFormat.TwosComplement)]
		public int extraAddCount
		{
			get
			{
				return this._extraAddCount ?? 0;
			}
			set
			{
				this._extraAddCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool extraAddCountSpecified
		{
			get
			{
				return this._extraAddCount != null;
			}
			set
			{
				bool flag = value == (this._extraAddCount == null);
				if (flag)
				{
					this._extraAddCount = (value ? new int?(this.extraAddCount) : null);
				}
			}
		}

		private bool ShouldSerializeextraAddCount()
		{
			return this.extraAddCountSpecified;
		}

		private void ResetextraAddCount()
		{
			this.extraAddCountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "helpcount", DataFormat = DataFormat.TwosComplement)]
		public uint helpcount
		{
			get
			{
				return this._helpcount ?? 0U;
			}
			set
			{
				this._helpcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool helpcountSpecified
		{
			get
			{
				return this._helpcount != null;
			}
			set
			{
				bool flag = value == (this._helpcount == null);
				if (flag)
				{
					this._helpcount = (value ? new uint?(this.helpcount) : null);
				}
			}
		}

		private bool ShouldSerializehelpcount()
		{
			return this.helpcountSpecified;
		}

		private void Resethelpcount()
		{
			this.helpcountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _teamType;

		private int? _finishCountToday;

		private int? _buyCountToday;

		private int? _extraAddCount;

		private uint? _helpcount;

		private IExtension extensionObject;
	}
}
