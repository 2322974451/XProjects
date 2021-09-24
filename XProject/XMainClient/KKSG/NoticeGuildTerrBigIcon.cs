using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NoticeGuildTerrBigIcon")]
	[Serializable]
	public class NoticeGuildTerrBigIcon : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isnow", DataFormat = DataFormat.Default)]
		public bool isnow
		{
			get
			{
				return this._isnow ?? false;
			}
			set
			{
				this._isnow = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isnowSpecified
		{
			get
			{
				return this._isnow != null;
			}
			set
			{
				bool flag = value == (this._isnow == null);
				if (flag)
				{
					this._isnow = (value ? new bool?(this.isnow) : null);
				}
			}
		}

		private bool ShouldSerializeisnow()
		{
			return this.isnowSpecified;
		}

		private void Resetisnow()
		{
			this.isnowSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isnow;

		private IExtension extensionObject;
	}
}
