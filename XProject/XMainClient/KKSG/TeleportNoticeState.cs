using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeleportNoticeState")]
	[Serializable]
	public class TeleportNoticeState : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "onnotice", DataFormat = DataFormat.Default)]
		public bool onnotice
		{
			get
			{
				return this._onnotice ?? false;
			}
			set
			{
				this._onnotice = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool onnoticeSpecified
		{
			get
			{
				return this._onnotice != null;
			}
			set
			{
				bool flag = value == (this._onnotice == null);
				if (flag)
				{
					this._onnotice = (value ? new bool?(this.onnotice) : null);
				}
			}
		}

		private bool ShouldSerializeonnotice()
		{
			return this.onnoticeSpecified;
		}

		private void Resetonnotice()
		{
			this.onnoticeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _onnotice;

		private IExtension extensionObject;
	}
}
