using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarExploreArg")]
	[Serializable]
	public class ResWarExploreArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "iscancel", DataFormat = DataFormat.Default)]
		public bool iscancel
		{
			get
			{
				return this._iscancel ?? false;
			}
			set
			{
				this._iscancel = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iscancelSpecified
		{
			get
			{
				return this._iscancel != null;
			}
			set
			{
				bool flag = value == (this._iscancel == null);
				if (flag)
				{
					this._iscancel = (value ? new bool?(this.iscancel) : null);
				}
			}
		}

		private bool ShouldSerializeiscancel()
		{
			return this.iscancelSpecified;
		}

		private void Resetiscancel()
		{
			this.iscancelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _iscancel;

		private IExtension extensionObject;
	}
}
