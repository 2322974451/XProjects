using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FirstPassRewardNtfData")]
	[Serializable]
	public class FirstPassRewardNtfData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "hasFirstPassReward", DataFormat = DataFormat.Default)]
		public bool hasFirstPassReward
		{
			get
			{
				return this._hasFirstPassReward ?? false;
			}
			set
			{
				this._hasFirstPassReward = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasFirstPassRewardSpecified
		{
			get
			{
				return this._hasFirstPassReward != null;
			}
			set
			{
				bool flag = value == (this._hasFirstPassReward == null);
				if (flag)
				{
					this._hasFirstPassReward = (value ? new bool?(this.hasFirstPassReward) : null);
				}
			}
		}

		private bool ShouldSerializehasFirstPassReward()
		{
			return this.hasFirstPassRewardSpecified;
		}

		private void ResethasFirstPassReward()
		{
			this.hasFirstPassRewardSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "hasCommendReward", DataFormat = DataFormat.Default)]
		public bool hasCommendReward
		{
			get
			{
				return this._hasCommendReward ?? false;
			}
			set
			{
				this._hasCommendReward = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasCommendRewardSpecified
		{
			get
			{
				return this._hasCommendReward != null;
			}
			set
			{
				bool flag = value == (this._hasCommendReward == null);
				if (flag)
				{
					this._hasCommendReward = (value ? new bool?(this.hasCommendReward) : null);
				}
			}
		}

		private bool ShouldSerializehasCommendReward()
		{
			return this.hasCommendRewardSpecified;
		}

		private void ResethasCommendReward()
		{
			this.hasCommendRewardSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _hasFirstPassReward;

		private bool? _hasCommendReward;

		private IExtension extensionObject;
	}
}
