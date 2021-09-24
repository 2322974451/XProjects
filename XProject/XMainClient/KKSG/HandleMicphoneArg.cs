using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HandleMicphoneArg")]
	[Serializable]
	public class HandleMicphoneArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "param", DataFormat = DataFormat.Default)]
		public bool param
		{
			get
			{
				return this._param ?? false;
			}
			set
			{
				this._param = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new bool?(this.param) : null);
				}
			}
		}

		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _param;

		private IExtension extensionObject;
	}
}
