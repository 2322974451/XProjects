using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpriteRecord")]
	[Serializable]
	public class SpriteRecord : IExtensible
	{

		[ProtoMember(1, Name = "SpriteData", DataFormat = DataFormat.Default)]
		public List<SpriteInfo> SpriteData
		{
			get
			{
				return this._SpriteData;
			}
		}

		[ProtoMember(2, Name = "InFight", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> InFight
		{
			get
			{
				return this._InFight;
			}
		}

		[ProtoMember(3, Name = "Books", DataFormat = DataFormat.Default)]
		public List<bool> Books
		{
			get
			{
				return this._Books;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "NewAwake", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SpriteInfo NewAwake
		{
			get
			{
				return this._NewAwake;
			}
			set
			{
				this._NewAwake = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "version", DataFormat = DataFormat.TwosComplement)]
		public uint version
		{
			get
			{
				return this._version ?? 0U;
			}
			set
			{
				this._version = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool versionSpecified
		{
			get
			{
				return this._version != null;
			}
			set
			{
				bool flag = value == (this._version == null);
				if (flag)
				{
					this._version = (value ? new uint?(this.version) : null);
				}
			}
		}

		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<SpriteInfo> _SpriteData = new List<SpriteInfo>();

		private readonly List<ulong> _InFight = new List<ulong>();

		private readonly List<bool> _Books = new List<bool>();

		private SpriteInfo _NewAwake = null;

		private uint? _version;

		private IExtension extensionObject;
	}
}
