using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleStarData")]
	[Serializable]
	public class BattleStarData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "star", DataFormat = DataFormat.TwosComplement)]
		public uint star
		{
			get
			{
				return this._star ?? 0U;
			}
			set
			{
				this._star = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool starSpecified
		{
			get
			{
				return this._star != null;
			}
			set
			{
				bool flag = value == (this._star == null);
				if (flag)
				{
					this._star = (value ? new uint?(this.star) : null);
				}
			}
		}

		private bool ShouldSerializestar()
		{
			return this.starSpecified;
		}

		private void Resetstar()
		{
			this.starSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private uint? _star;

		private IExtension extensionObject;
	}
}
