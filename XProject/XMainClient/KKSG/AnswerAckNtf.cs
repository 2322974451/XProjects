using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AnswerAckNtf")]
	[Serializable]
	public class AnswerAckNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleId", DataFormat = DataFormat.TwosComplement)]
		public ulong roleId
		{
			get
			{
				return this._roleId ?? 0UL;
			}
			set
			{
				this._roleId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIdSpecified
		{
			get
			{
				return this._roleId != null;
			}
			set
			{
				bool flag = value == (this._roleId == null);
				if (flag)
				{
					this._roleId = (value ? new ulong?(this.roleId) : null);
				}
			}
		}

		private bool ShouldSerializeroleId()
		{
			return this.roleIdSpecified;
		}

		private void ResetroleId()
		{
			this.roleIdSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "answer", DataFormat = DataFormat.Default)]
		public string answer
		{
			get
			{
				return this._answer ?? "";
			}
			set
			{
				this._answer = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool answerSpecified
		{
			get
			{
				return this._answer != null;
			}
			set
			{
				bool flag = value == (this._answer == null);
				if (flag)
				{
					this._answer = (value ? this.answer : null);
				}
			}
		}

		private bool ShouldSerializeanswer()
		{
			return this.answerSpecified;
		}

		private void Resetanswer()
		{
			this.answerSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "correct", DataFormat = DataFormat.Default)]
		public bool correct
		{
			get
			{
				return this._correct ?? false;
			}
			set
			{
				this._correct = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool correctSpecified
		{
			get
			{
				return this._correct != null;
			}
			set
			{
				bool flag = value == (this._correct == null);
				if (flag)
				{
					this._correct = (value ? new bool?(this.correct) : null);
				}
			}
		}

		private bool ShouldSerializecorrect()
		{
			return this.correctSpecified;
		}

		private void Resetcorrect()
		{
			this.correctSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "times", DataFormat = DataFormat.TwosComplement)]
		public uint times
		{
			get
			{
				return this._times ?? 0U;
			}
			set
			{
				this._times = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timesSpecified
		{
			get
			{
				return this._times != null;
			}
			set
			{
				bool flag = value == (this._times == null);
				if (flag)
				{
					this._times = (value ? new uint?(this.times) : null);
				}
			}
		}

		private bool ShouldSerializetimes()
		{
			return this.timesSpecified;
		}

		private void Resettimes()
		{
			this.timesSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "audioUid", DataFormat = DataFormat.TwosComplement)]
		public ulong audioUid
		{
			get
			{
				return this._audioUid ?? 0UL;
			}
			set
			{
				this._audioUid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audioUidSpecified
		{
			get
			{
				return this._audioUid != null;
			}
			set
			{
				bool flag = value == (this._audioUid == null);
				if (flag)
				{
					this._audioUid = (value ? new ulong?(this.audioUid) : null);
				}
			}
		}

		private bool ShouldSerializeaudioUid()
		{
			return this.audioUidSpecified;
		}

		private void ResetaudioUid()
		{
			this.audioUidSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "answertime", DataFormat = DataFormat.TwosComplement)]
		public uint answertime
		{
			get
			{
				return this._answertime ?? 0U;
			}
			set
			{
				this._answertime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool answertimeSpecified
		{
			get
			{
				return this._answertime != null;
			}
			set
			{
				bool flag = value == (this._answertime == null);
				if (flag)
				{
					this._answertime = (value ? new uint?(this.answertime) : null);
				}
			}
		}

		private bool ShouldSerializeanswertime()
		{
			return this.answertimeSpecified;
		}

		private void Resetanswertime()
		{
			this.answertimeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "userName", DataFormat = DataFormat.Default)]
		public string userName
		{
			get
			{
				return this._userName ?? "";
			}
			set
			{
				this._userName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool userNameSpecified
		{
			get
			{
				return this._userName != null;
			}
			set
			{
				bool flag = value == (this._userName == null);
				if (flag)
				{
					this._userName = (value ? this.userName : null);
				}
			}
		}

		private bool ShouldSerializeuserName()
		{
			return this.userNameSpecified;
		}

		private void ResetuserName()
		{
			this.userNameSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "coverDesignationId", DataFormat = DataFormat.TwosComplement)]
		public uint coverDesignationId
		{
			get
			{
				return this._coverDesignationId ?? 0U;
			}
			set
			{
				this._coverDesignationId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool coverDesignationIdSpecified
		{
			get
			{
				return this._coverDesignationId != null;
			}
			set
			{
				bool flag = value == (this._coverDesignationId == null);
				if (flag)
				{
					this._coverDesignationId = (value ? new uint?(this.coverDesignationId) : null);
				}
			}
		}

		private bool ShouldSerializecoverDesignationId()
		{
			return this.coverDesignationIdSpecified;
		}

		private void ResetcoverDesignationId()
		{
			this.coverDesignationIdSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "audioTime", DataFormat = DataFormat.TwosComplement)]
		public uint audioTime
		{
			get
			{
				return this._audioTime ?? 0U;
			}
			set
			{
				this._audioTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool audioTimeSpecified
		{
			get
			{
				return this._audioTime != null;
			}
			set
			{
				bool flag = value == (this._audioTime == null);
				if (flag)
				{
					this._audioTime = (value ? new uint?(this.audioTime) : null);
				}
			}
		}

		private bool ShouldSerializeaudioTime()
		{
			return this.audioTimeSpecified;
		}

		private void ResetaudioTime()
		{
			this.audioTimeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleId;

		private string _answer;

		private bool? _correct;

		private uint? _times;

		private uint? _rank;

		private ulong? _audioUid;

		private uint? _answertime;

		private string _userName;

		private uint? _coverDesignationId;

		private uint? _audioTime;

		private uint? _profession;

		private IExtension extensionObject;
	}
}
