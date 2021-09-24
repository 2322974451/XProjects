using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OneMentorBeAppliedMsg")]
	[Serializable]
	public class OneMentorBeAppliedMsg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public MentorMsgApplyType type
		{
			get
			{
				return this._type ?? MentorMsgApplyType.MentorMsgApplyMaster;
			}
			set
			{
				this._type = new MentorMsgApplyType?(value);
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
					this._type = (value ? new MentorMsgApplyType?(this.type) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public int time
		{
			get
			{
				return this._time ?? 0;
			}
			set
			{
				this._time = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new int?(this.time) : null);
				}
			}
		}

		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		private void Resettime()
		{
			this.timeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "roleBrief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo roleBrief
		{
			get
			{
				return this._roleBrief;
			}
			set
			{
				this._roleBrief = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "reportTaskID", DataFormat = DataFormat.TwosComplement)]
		public int reportTaskID
		{
			get
			{
				return this._reportTaskID ?? 0;
			}
			set
			{
				this._reportTaskID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reportTaskIDSpecified
		{
			get
			{
				return this._reportTaskID != null;
			}
			set
			{
				bool flag = value == (this._reportTaskID == null);
				if (flag)
				{
					this._reportTaskID = (value ? new int?(this.reportTaskID) : null);
				}
			}
		}

		private bool ShouldSerializereportTaskID()
		{
			return this.reportTaskIDSpecified;
		}

		private void ResetreportTaskID()
		{
			this.reportTaskIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private MentorMsgApplyType? _type;

		private int? _time;

		private RoleBriefInfo _roleBrief = null;

		private int? _reportTaskID;

		private IExtension extensionObject;
	}
}
