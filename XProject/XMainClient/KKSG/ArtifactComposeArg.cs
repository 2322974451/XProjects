using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArtifactComposeArg")]
	[Serializable]
	public class ArtifactComposeArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ArtifactComposeType type
		{
			get
			{
				return this._type ?? ArtifactComposeType.ArtifactCompose_Single;
			}
			set
			{
				this._type = new ArtifactComposeType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new ArtifactComposeType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, Name = "uids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> uids
		{
			get
			{
				return this._uids;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(4, Name = "qualitys", DataFormat = DataFormat.TwosComplement)]
		public List<uint> qualitys
		{
			get
			{
				return this._qualitys;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ArtifactComposeType? _type;

		private readonly List<ulong> _uids = new List<ulong>();

		private uint? _level;

		private readonly List<uint> _qualitys = new List<uint>();

		private IExtension extensionObject;
	}
}
