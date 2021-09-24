using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FMBRes")]
	[Serializable]
	public class FMBRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "refuse", DataFormat = DataFormat.Default)]
		public bool refuse
		{
			get
			{
				return this._refuse ?? false;
			}
			set
			{
				this._refuse = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool refuseSpecified
		{
			get
			{
				return this._refuse != null;
			}
			set
			{
				bool flag = value == (this._refuse == null);
				if (flag)
				{
					this._refuse = (value ? new bool?(this.refuse) : null);
				}
			}
		}

		private bool ShouldSerializerefuse()
		{
			return this.refuseSpecified;
		}

		private void Resetrefuse()
		{
			this.refuseSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _refuse;

		private IExtension extensionObject;
	}
}
