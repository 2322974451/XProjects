using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NotifySkyTeamCreate")]
	[Serializable]
	public class NotifySkyTeamCreate : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "sky_teamid", DataFormat = DataFormat.TwosComplement)]
		public ulong sky_teamid
		{
			get
			{
				return this._sky_teamid ?? 0UL;
			}
			set
			{
				this._sky_teamid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sky_teamidSpecified
		{
			get
			{
				return this._sky_teamid != null;
			}
			set
			{
				bool flag = value == (this._sky_teamid == null);
				if (flag)
				{
					this._sky_teamid = (value ? new ulong?(this.sky_teamid) : null);
				}
			}
		}

		private bool ShouldSerializesky_teamid()
		{
			return this.sky_teamidSpecified;
		}

		private void Resetsky_teamid()
		{
			this.sky_teamidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _sky_teamid;

		private string _name;

		private IExtension extensionObject;
	}
}
