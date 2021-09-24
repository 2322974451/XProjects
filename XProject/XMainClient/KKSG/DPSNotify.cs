using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DPSNotify")]
	[Serializable]
	public class DPSNotify : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "dps", DataFormat = DataFormat.FixedSize)]
		public float dps
		{
			get
			{
				return this._dps ?? 0f;
			}
			set
			{
				this._dps = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dpsSpecified
		{
			get
			{
				return this._dps != null;
			}
			set
			{
				bool flag = value == (this._dps == null);
				if (flag)
				{
					this._dps = (value ? new float?(this.dps) : null);
				}
			}
		}

		private bool ShouldSerializedps()
		{
			return this.dpsSpecified;
		}

		private void Resetdps()
		{
			this.dpsSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private float? _dps;

		private IExtension extensionObject;
	}
}
