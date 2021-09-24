using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OneMentorApplyMasterShow")]
	[Serializable]
	public class OneMentorApplyMasterShow : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "oneMaster", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo oneMaster
		{
			get
			{
				return this._oneMaster;
			}
			set
			{
				this._oneMaster = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "audioID", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "applyWords", DataFormat = DataFormat.Default)]
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

		[ProtoMember(4, IsRequired = false, Name = "hasApply", DataFormat = DataFormat.Default)]
		public bool hasApply
		{
			get
			{
				return this._hasApply ?? false;
			}
			set
			{
				this._hasApply = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasApplySpecified
		{
			get
			{
				return this._hasApply != null;
			}
			set
			{
				bool flag = value == (this._hasApply == null);
				if (flag)
				{
					this._hasApply = (value ? new bool?(this.hasApply) : null);
				}
			}
		}

		private bool ShouldSerializehasApply()
		{
			return this.hasApplySpecified;
		}

		private void ResethasApply()
		{
			this.hasApplySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RoleBriefInfo _oneMaster = null;

		private ulong? _audioID;

		private string _applyWords;

		private bool? _hasApply;

		private IExtension extensionObject;
	}
}
