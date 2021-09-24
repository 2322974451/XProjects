using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "UpdateMentorApplyStudentInfoArg")]
	[Serializable]
	public class UpdateMentorApplyStudentInfoArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "audioID", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "applyWords", DataFormat = DataFormat.Default)]
		public string applyWords
		{
			get
			{
				return this._applyWords ?? "";
			}
			set
			{
				this._applyWords = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool applyWordsSpecified
		{
			get
			{
				return this._applyWords != null;
			}
			set
			{
				bool flag = value == (this._applyWords == null);
				if (flag)
				{
					this._applyWords = (value ? this.applyWords : null);
				}
			}
		}

		private bool ShouldSerializeapplyWords()
		{
			return this.applyWordsSpecified;
		}

		private void ResetapplyWords()
		{
			this.applyWordsSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "isNeedStudent", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = false, Name = "onlineNotify", DataFormat = DataFormat.Default)]
		public bool onlineNotify
		{
			get
			{
				return this._onlineNotify ?? false;
			}
			set
			{
				this._onlineNotify = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool onlineNotifySpecified
		{
			get
			{
				return this._onlineNotify != null;
			}
			set
			{
				bool flag = value == (this._onlineNotify == null);
				if (flag)
				{
					this._onlineNotify = (value ? new bool?(this.onlineNotify) : null);
				}
			}
		}

		private bool ShouldSerializeonlineNotify()
		{
			return this.onlineNotifySpecified;
		}

		private void ResetonlineNotify()
		{
			this.onlineNotifySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _audioID;

		private string _applyWords;

		private bool? _isNeedStudent;

		private bool? _onlineNotify;

		private IExtension extensionObject;
	}
}
