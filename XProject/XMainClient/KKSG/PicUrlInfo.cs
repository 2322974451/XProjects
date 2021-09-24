using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PicUrlInfo")]
	[Serializable]
	public class PicUrlInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "url", DataFormat = DataFormat.Default)]
		public string url
		{
			get
			{
				return this._url ?? "";
			}
			set
			{
				this._url = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool urlSpecified
		{
			get
			{
				return this._url != null;
			}
			set
			{
				bool flag = value == (this._url == null);
				if (flag)
				{
					this._url = (value ? this.url : null);
				}
			}
		}

		private bool ShouldSerializeurl()
		{
			return this.urlSpecified;
		}

		private void Reseturl()
		{
			this.urlSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _url;

		private IExtension extensionObject;
	}
}
