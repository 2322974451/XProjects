using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChangeLiveVisibleArg")]
	[Serializable]
	public class ChangeLiveVisibleArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "visible", DataFormat = DataFormat.Default)]
		public bool visible
		{
			get
			{
				return this._visible ?? false;
			}
			set
			{
				this._visible = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool visibleSpecified
		{
			get
			{
				return this._visible != null;
			}
			set
			{
				bool flag = value == (this._visible == null);
				if (flag)
				{
					this._visible = (value ? new bool?(this.visible) : null);
				}
			}
		}

		private bool ShouldSerializevisible()
		{
			return this.visibleSpecified;
		}

		private void Resetvisible()
		{
			this.visibleSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _visible;

		private IExtension extensionObject;
	}
}
