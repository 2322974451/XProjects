using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TryDanceArg")]
	[Serializable]
	public class TryDanceArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "danceid", DataFormat = DataFormat.TwosComplement)]
		public uint danceid
		{
			get
			{
				return this._danceid ?? 0U;
			}
			set
			{
				this._danceid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool danceidSpecified
		{
			get
			{
				return this._danceid != null;
			}
			set
			{
				bool flag = value == (this._danceid == null);
				if (flag)
				{
					this._danceid = (value ? new uint?(this.danceid) : null);
				}
			}
		}

		private bool ShouldSerializedanceid()
		{
			return this.danceidSpecified;
		}

		private void Resetdanceid()
		{
			this.danceidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _danceid;

		private IExtension extensionObject;
	}
}
