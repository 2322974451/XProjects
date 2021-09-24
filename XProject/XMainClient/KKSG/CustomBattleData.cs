using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleData")]
	[Serializable]
	public class CustomBattleData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "config", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleConfig config
		{
			get
			{
				return this._config;
			}
			set
			{
				this._config = value;
			}
		}

		[ProtoMember(3, Name = "rank", DataFormat = DataFormat.Default)]
		public List<CustomBattleRank> rank
		{
			get
			{
				return this._rank;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private CustomBattleConfig _config = null;

		private readonly List<CustomBattleRank> _rank = new List<CustomBattleRank>();

		private IExtension extensionObject;
	}
}
