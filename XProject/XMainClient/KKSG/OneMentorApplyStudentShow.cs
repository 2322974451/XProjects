using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OneMentorApplyStudentShow")]
	[Serializable]
	public class OneMentorApplyStudentShow : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "oneStudent", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo oneStudent
		{
			get
			{
				return this._oneStudent;
			}
			set
			{
				this._oneStudent = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "hasApply", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RoleBriefInfo _oneStudent = null;

		private bool? _hasApply;

		private string _applyWords;

		private IExtension extensionObject;
	}
}
