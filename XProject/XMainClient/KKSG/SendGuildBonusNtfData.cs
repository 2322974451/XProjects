using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SendGuildBonusNtfData")]
	[Serializable]
	public class SendGuildBonusNtfData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "hasLeftSend", DataFormat = DataFormat.Default)]
		public bool hasLeftSend
		{
			get
			{
				return this._hasLeftSend ?? false;
			}
			set
			{
				this._hasLeftSend = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hasLeftSendSpecified
		{
			get
			{
				return this._hasLeftSend != null;
			}
			set
			{
				bool flag = value == (this._hasLeftSend == null);
				if (flag)
				{
					this._hasLeftSend = (value ? new bool?(this.hasLeftSend) : null);
				}
			}
		}

		private bool ShouldSerializehasLeftSend()
		{
			return this.hasLeftSendSpecified;
		}

		private void ResethasLeftSend()
		{
			this.hasLeftSendSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _hasLeftSend;

		private IExtension extensionObject;
	}
}
