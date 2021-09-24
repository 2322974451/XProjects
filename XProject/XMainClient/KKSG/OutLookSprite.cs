using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OutLookSprite")]
	[Serializable]
	public class OutLookSprite : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "leaderid", DataFormat = DataFormat.TwosComplement)]
		public uint leaderid
		{
			get
			{
				return this._leaderid ?? 0U;
			}
			set
			{
				this._leaderid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderidSpecified
		{
			get
			{
				return this._leaderid != null;
			}
			set
			{
				bool flag = value == (this._leaderid == null);
				if (flag)
				{
					this._leaderid = (value ? new uint?(this.leaderid) : null);
				}
			}
		}

		private bool ShouldSerializeleaderid()
		{
			return this.leaderidSpecified;
		}

		private void Resetleaderid()
		{
			this.leaderidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _leaderid;

		private IExtension extensionObject;
	}
}
