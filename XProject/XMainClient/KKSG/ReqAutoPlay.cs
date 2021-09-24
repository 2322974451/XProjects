using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqAutoPlay")]
	[Serializable]
	public class ReqAutoPlay : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isautoplay", DataFormat = DataFormat.Default)]
		public bool isautoplay
		{
			get
			{
				return this._isautoplay ?? false;
			}
			set
			{
				this._isautoplay = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isautoplaySpecified
		{
			get
			{
				return this._isautoplay != null;
			}
			set
			{
				bool flag = value == (this._isautoplay == null);
				if (flag)
				{
					this._isautoplay = (value ? new bool?(this.isautoplay) : null);
				}
			}
		}

		private bool ShouldSerializeisautoplay()
		{
			return this.isautoplaySpecified;
		}

		private void Resetisautoplay()
		{
			this.isautoplaySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isautoplay;

		private IExtension extensionObject;
	}
}
