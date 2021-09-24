using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BackFlowOpenNtf")]
	[Serializable]
	public class BackFlowOpenNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isopen", DataFormat = DataFormat.Default)]
		public bool isopen
		{
			get
			{
				return this._isopen ?? false;
			}
			set
			{
				this._isopen = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isopenSpecified
		{
			get
			{
				return this._isopen != null;
			}
			set
			{
				bool flag = value == (this._isopen == null);
				if (flag)
				{
					this._isopen = (value ? new bool?(this.isopen) : null);
				}
			}
		}

		private bool ShouldSerializeisopen()
		{
			return this.isopenSpecified;
		}

		private void Resetisopen()
		{
			this.isopenSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isopen;

		private IExtension extensionObject;
	}
}
