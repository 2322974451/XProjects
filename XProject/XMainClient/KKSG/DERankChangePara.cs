using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DERankChangePara")]
	[Serializable]
	public class DERankChangePara : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "oldrank", DataFormat = DataFormat.TwosComplement)]
		public int oldrank
		{
			get
			{
				return this._oldrank ?? 0;
			}
			set
			{
				this._oldrank = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool oldrankSpecified
		{
			get
			{
				return this._oldrank != null;
			}
			set
			{
				bool flag = value == (this._oldrank == null);
				if (flag)
				{
					this._oldrank = (value ? new int?(this.oldrank) : null);
				}
			}
		}

		private bool ShouldSerializeoldrank()
		{
			return this.oldrankSpecified;
		}

		private void Resetoldrank()
		{
			this.oldrankSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "newrank", DataFormat = DataFormat.TwosComplement)]
		public int newrank
		{
			get
			{
				return this._newrank ?? 0;
			}
			set
			{
				this._newrank = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool newrankSpecified
		{
			get
			{
				return this._newrank != null;
			}
			set
			{
				bool flag = value == (this._newrank == null);
				if (flag)
				{
					this._newrank = (value ? new int?(this.newrank) : null);
				}
			}
		}

		private bool ShouldSerializenewrank()
		{
			return this.newrankSpecified;
		}

		private void Resetnewrank()
		{
			this.newrankSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _oldrank;

		private int? _newrank;

		private IExtension extensionObject;
	}
}
