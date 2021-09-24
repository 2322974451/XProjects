using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeekReportData")]
	[Serializable]
	public class WeekReportData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeekReportDataType type
		{
			get
			{
				return this._type ?? WeekReportDataType.WeekReportData_GuildSign;
			}
			set
			{
				this._type = new WeekReportDataType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new WeekReportDataType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "joincount", DataFormat = DataFormat.TwosComplement)]
		public int joincount
		{
			get
			{
				return this._joincount ?? 0;
			}
			set
			{
				this._joincount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool joincountSpecified
		{
			get
			{
				return this._joincount != null;
			}
			set
			{
				bool flag = value == (this._joincount == null);
				if (flag)
				{
					this._joincount = (value ? new int?(this.joincount) : null);
				}
			}
		}

		private bool ShouldSerializejoincount()
		{
			return this.joincountSpecified;
		}

		private void Resetjoincount()
		{
			this.joincountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lastjointime", DataFormat = DataFormat.TwosComplement)]
		public uint lastjointime
		{
			get
			{
				return this._lastjointime ?? 0U;
			}
			set
			{
				this._lastjointime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastjointimeSpecified
		{
			get
			{
				return this._lastjointime != null;
			}
			set
			{
				bool flag = value == (this._lastjointime == null);
				if (flag)
				{
					this._lastjointime = (value ? new uint?(this.lastjointime) : null);
				}
			}
		}

		private bool ShouldSerializelastjointime()
		{
			return this.lastjointimeSpecified;
		}

		private void Resetlastjointime()
		{
			this.lastjointimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private WeekReportDataType? _type;

		private int? _joincount;

		private uint? _lastjointime;

		private IExtension extensionObject;
	}
}
