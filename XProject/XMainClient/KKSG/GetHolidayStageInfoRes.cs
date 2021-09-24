using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetHolidayStageInfoRes")]
	[Serializable]
	public class GetHolidayStageInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "holidayid", DataFormat = DataFormat.TwosComplement)]
		public uint holidayid
		{
			get
			{
				return this._holidayid ?? 0U;
			}
			set
			{
				this._holidayid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool holidayidSpecified
		{
			get
			{
				return this._holidayid != null;
			}
			set
			{
				bool flag = value == (this._holidayid == null);
				if (flag)
				{
					this._holidayid = (value ? new uint?(this.holidayid) : null);
				}
			}
		}

		private bool ShouldSerializeholidayid()
		{
			return this.holidayidSpecified;
		}

		private void Resetholidayid()
		{
			this.holidayidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lasttime", DataFormat = DataFormat.TwosComplement)]
		public uint lasttime
		{
			get
			{
				return this._lasttime ?? 0U;
			}
			set
			{
				this._lasttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lasttimeSpecified
		{
			get
			{
				return this._lasttime != null;
			}
			set
			{
				bool flag = value == (this._lasttime == null);
				if (flag)
				{
					this._lasttime = (value ? new uint?(this.lasttime) : null);
				}
			}
		}

		private bool ShouldSerializelasttime()
		{
			return this.lasttimeSpecified;
		}

		private void Resetlasttime()
		{
			this.lasttimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "havetimes", DataFormat = DataFormat.TwosComplement)]
		public uint havetimes
		{
			get
			{
				return this._havetimes ?? 0U;
			}
			set
			{
				this._havetimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool havetimesSpecified
		{
			get
			{
				return this._havetimes != null;
			}
			set
			{
				bool flag = value == (this._havetimes == null);
				if (flag)
				{
					this._havetimes = (value ? new uint?(this.havetimes) : null);
				}
			}
		}

		private bool ShouldSerializehavetimes()
		{
			return this.havetimesSpecified;
		}

		private void Resethavetimes()
		{
			this.havetimesSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _holidayid;

		private uint? _sceneid;

		private uint? _lasttime;

		private uint? _havetimes;

		private IExtension extensionObject;
	}
}
