using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SynGuildInheritNumInfo")]
	[Serializable]
	public class SynGuildInheritNumInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "reqNum", DataFormat = DataFormat.TwosComplement)]
		public uint reqNum
		{
			get
			{
				return this._reqNum ?? 0U;
			}
			set
			{
				this._reqNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reqNumSpecified
		{
			get
			{
				return this._reqNum != null;
			}
			set
			{
				bool flag = value == (this._reqNum == null);
				if (flag)
				{
					this._reqNum = (value ? new uint?(this.reqNum) : null);
				}
			}
		}

		private bool ShouldSerializereqNum()
		{
			return this.reqNumSpecified;
		}

		private void ResetreqNum()
		{
			this.reqNumSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "teacherNum", DataFormat = DataFormat.TwosComplement)]
		public uint teacherNum
		{
			get
			{
				return this._teacherNum ?? 0U;
			}
			set
			{
				this._teacherNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teacherNumSpecified
		{
			get
			{
				return this._teacherNum != null;
			}
			set
			{
				bool flag = value == (this._teacherNum == null);
				if (flag)
				{
					this._teacherNum = (value ? new uint?(this.teacherNum) : null);
				}
			}
		}

		private bool ShouldSerializeteacherNum()
		{
			return this.teacherNumSpecified;
		}

		private void ResetteacherNum()
		{
			this.teacherNumSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "studentNum", DataFormat = DataFormat.TwosComplement)]
		public uint studentNum
		{
			get
			{
				return this._studentNum ?? 0U;
			}
			set
			{
				this._studentNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool studentNumSpecified
		{
			get
			{
				return this._studentNum != null;
			}
			set
			{
				bool flag = value == (this._studentNum == null);
				if (flag)
				{
					this._studentNum = (value ? new uint?(this.studentNum) : null);
				}
			}
		}

		private bool ShouldSerializestudentNum()
		{
			return this.studentNumSpecified;
		}

		private void ResetstudentNum()
		{
			this.studentNumSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "lastTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastTime
		{
			get
			{
				return this._lastTime ?? 0U;
			}
			set
			{
				this._lastTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastTimeSpecified
		{
			get
			{
				return this._lastTime != null;
			}
			set
			{
				bool flag = value == (this._lastTime == null);
				if (flag)
				{
					this._lastTime = (value ? new uint?(this.lastTime) : null);
				}
			}
		}

		private bool ShouldSerializelastTime()
		{
			return this.lastTimeSpecified;
		}

		private void ResetlastTime()
		{
			this.lastTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _reqNum;

		private uint? _teacherNum;

		private uint? _studentNum;

		private uint? _lastTime;

		private IExtension extensionObject;
	}
}
