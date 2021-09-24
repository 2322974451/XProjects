using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FriendGift")]
	[Serializable]
	public class FriendGift : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "SendLeft", DataFormat = DataFormat.TwosComplement)]
		public uint SendLeft
		{
			get
			{
				return this._SendLeft ?? 0U;
			}
			set
			{
				this._SendLeft = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool SendLeftSpecified
		{
			get
			{
				return this._SendLeft != null;
			}
			set
			{
				bool flag = value == (this._SendLeft == null);
				if (flag)
				{
					this._SendLeft = (value ? new uint?(this.SendLeft) : null);
				}
			}
		}

		private bool ShouldSerializeSendLeft()
		{
			return this.SendLeftSpecified;
		}

		private void ResetSendLeft()
		{
			this.SendLeftSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "ReceiveLeft", DataFormat = DataFormat.TwosComplement)]
		public uint ReceiveLeft
		{
			get
			{
				return this._ReceiveLeft ?? 0U;
			}
			set
			{
				this._ReceiveLeft = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ReceiveLeftSpecified
		{
			get
			{
				return this._ReceiveLeft != null;
			}
			set
			{
				bool flag = value == (this._ReceiveLeft == null);
				if (flag)
				{
					this._ReceiveLeft = (value ? new uint?(this.ReceiveLeft) : null);
				}
			}
		}

		private bool ShouldSerializeReceiveLeft()
		{
			return this.ReceiveLeftSpecified;
		}

		private void ResetReceiveLeft()
		{
			this.ReceiveLeftSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _SendLeft;

		private uint? _ReceiveLeft;

		private IExtension extensionObject;
	}
}
