using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMyMentorInfoRes")]
	[Serializable]
	public class GetMyMentorInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, Name = "mentorRelationList", DataFormat = DataFormat.Default)]
		public List<OneMentorRelationInfo2Client> mentorRelationList
		{
			get
			{
				return this._mentorRelationList;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "mentorSelfInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MentorSelfInfo mentorSelfInfo
		{
			get
			{
				return this._mentorSelfInfo;
			}
			set
			{
				this._mentorSelfInfo = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "curTime", DataFormat = DataFormat.TwosComplement)]
		public int curTime
		{
			get
			{
				return this._curTime ?? 0;
			}
			set
			{
				this._curTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curTimeSpecified
		{
			get
			{
				return this._curTime != null;
			}
			set
			{
				bool flag = value == (this._curTime == null);
				if (flag)
				{
					this._curTime = (value ? new int?(this.curTime) : null);
				}
			}
		}

		private bool ShouldSerializecurTime()
		{
			return this.curTimeSpecified;
		}

		private void ResetcurTime()
		{
			this.curTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "audioID", DataFormat = DataFormat.TwosComplement)]
		public ulong audioID
		{
			get
			{
				return this._audioID ?? 0UL;
			}
			set
			{
				this._audioID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audioIDSpecified
		{
			get
			{
				return this._audioID != null;
			}
			set
			{
				bool flag = value == (this._audioID == null);
				if (flag)
				{
					this._audioID = (value ? new ulong?(this.audioID) : null);
				}
			}
		}

		private bool ShouldSerializeaudioID()
		{
			return this.audioIDSpecified;
		}

		private void ResetaudioID()
		{
			this.audioIDSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "mentorWords", DataFormat = DataFormat.Default)]
		public string mentorWords
		{
			get
			{
				return this._mentorWords ?? "";
			}
			set
			{
				this._mentorWords = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mentorWordsSpecified
		{
			get
			{
				return this._mentorWords != null;
			}
			set
			{
				bool flag = value == (this._mentorWords == null);
				if (flag)
				{
					this._mentorWords = (value ? this.mentorWords : null);
				}
			}
		}

		private bool ShouldSerializementorWords()
		{
			return this.mentorWordsSpecified;
		}

		private void ResetmentorWords()
		{
			this.mentorWordsSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "isNeedStudent", DataFormat = DataFormat.Default)]
		public bool isNeedStudent
		{
			get
			{
				return this._isNeedStudent ?? false;
			}
			set
			{
				this._isNeedStudent = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isNeedStudentSpecified
		{
			get
			{
				return this._isNeedStudent != null;
			}
			set
			{
				bool flag = value == (this._isNeedStudent == null);
				if (flag)
				{
					this._isNeedStudent = (value ? new bool?(this.isNeedStudent) : null);
				}
			}
		}

		private bool ShouldSerializeisNeedStudent()
		{
			return this.isNeedStudentSpecified;
		}

		private void ResetisNeedStudent()
		{
			this.isNeedStudentSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private readonly List<OneMentorRelationInfo2Client> _mentorRelationList = new List<OneMentorRelationInfo2Client>();

		private MentorSelfInfo _mentorSelfInfo = null;

		private int? _curTime;

		private ulong? _audioID;

		private string _mentorWords;

		private bool? _isNeedStudent;

		private IExtension extensionObject;
	}
}
