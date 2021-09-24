using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AncientTimesRes")]
	[Serializable]
	public class AncientTimesRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "reward", DataFormat = DataFormat.TwosComplement)]
		public uint reward
		{
			get
			{
				return this._reward ?? 0U;
			}
			set
			{
				this._reward = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardSpecified
		{
			get
			{
				return this._reward != null;
			}
			set
			{
				bool flag = value == (this._reward == null);
				if (flag)
				{
					this._reward = (value ? new uint?(this.reward) : null);
				}
			}
		}

		private bool ShouldSerializereward()
		{
			return this.rewardSpecified;
		}

		private void Resetreward()
		{
			this.rewardSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private uint? _reward;

		private IExtension extensionObject;
	}
}
