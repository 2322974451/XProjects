using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BMRoleSceneSync")]
	[Serializable]
	public class BMRoleSceneSync : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "games", DataFormat = DataFormat.TwosComplement)]
		public uint games
		{
			get
			{
				return this._games ?? 0U;
			}
			set
			{
				this._games = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gamesSpecified
		{
			get
			{
				return this._games != null;
			}
			set
			{
				bool flag = value == (this._games == null);
				if (flag)
				{
					this._games = (value ? new uint?(this.games) : null);
				}
			}
		}

		private bool ShouldSerializegames()
		{
			return this.gamesSpecified;
		}

		private void Resetgames()
		{
			this.gamesSpecified = false;
		}

		[ProtoMember(2, Name = "roles", DataFormat = DataFormat.Default)]
		public List<BMRoleEnter> roles
		{
			get
			{
				return this._roles;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _games;

		private readonly List<BMRoleEnter> _roles = new List<BMRoleEnter>();

		private IExtension extensionObject;
	}
}
