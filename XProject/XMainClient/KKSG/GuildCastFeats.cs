using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCastFeats")]
	[Serializable]
	public class GuildCastFeats : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "feats", DataFormat = DataFormat.TwosComplement)]
		public uint feats
		{
			get
			{
				return this._feats ?? 0U;
			}
			set
			{
				this._feats = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool featsSpecified
		{
			get
			{
				return this._feats != null;
			}
			set
			{
				bool flag = value == (this._feats == null);
				if (flag)
				{
					this._feats = (value ? new uint?(this.feats) : null);
				}
			}
		}

		private bool ShouldSerializefeats()
		{
			return this.featsSpecified;
		}

		private void Resetfeats()
		{
			this.featsSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private uint? _feats;

		private IExtension extensionObject;
	}
}
