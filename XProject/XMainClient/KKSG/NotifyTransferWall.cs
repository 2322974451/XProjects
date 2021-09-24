using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NotifyTransferWall")]
	[Serializable]
	public class NotifyTransferWall : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "transfer", DataFormat = DataFormat.Default)]
		public bool transfer
		{
			get
			{
				return this._transfer ?? false;
			}
			set
			{
				this._transfer = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool transferSpecified
		{
			get
			{
				return this._transfer != null;
			}
			set
			{
				bool flag = value == (this._transfer == null);
				if (flag)
				{
					this._transfer = (value ? new bool?(this.transfer) : null);
				}
			}
		}

		private bool ShouldSerializetransfer()
		{
			return this.transferSpecified;
		}

		private void Resettransfer()
		{
			this.transferSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "wallid", DataFormat = DataFormat.TwosComplement)]
		public int wallid
		{
			get
			{
				return this._wallid ?? 0;
			}
			set
			{
				this._wallid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wallidSpecified
		{
			get
			{
				return this._wallid != null;
			}
			set
			{
				bool flag = value == (this._wallid == null);
				if (flag)
				{
					this._wallid = (value ? new int?(this.wallid) : null);
				}
			}
		}

		private bool ShouldSerializewallid()
		{
			return this.wallidSpecified;
		}

		private void Resetwallid()
		{
			this.wallidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _transfer;

		private int? _wallid;

		private IExtension extensionObject;
	}
}
