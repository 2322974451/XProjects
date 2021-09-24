using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NoticeGuildTerrWar")]
	[Serializable]
	public class NoticeGuildTerrWar : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isbegin", DataFormat = DataFormat.Default)]
		public bool isbegin
		{
			get
			{
				return this._isbegin ?? false;
			}
			set
			{
				this._isbegin = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isbeginSpecified
		{
			get
			{
				return this._isbegin != null;
			}
			set
			{
				bool flag = value == (this._isbegin == null);
				if (flag)
				{
					this._isbegin = (value ? new bool?(this.isbegin) : null);
				}
			}
		}

		private bool ShouldSerializeisbegin()
		{
			return this.isbeginSpecified;
		}

		private void Resetisbegin()
		{
			this.isbeginSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isbegin;

		private IExtension extensionObject;
	}
}
