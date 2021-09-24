using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleLoadingNtf")]
	[Serializable]
	public class CustomBattleLoadingNtf : IExtensible
	{

		[ProtoMember(1, Name = "roleinfos", DataFormat = DataFormat.Default)]
		public List<CustomBattleMatchRoleInfo> roleinfos
		{
			get
			{
				return this._roleinfos;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public CustomBattleType type
		{
			get
			{
				return this._type ?? CustomBattleType.CustomBattle_PK_Normal;
			}
			set
			{
				this._type = new CustomBattleType?(value);
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
					this._type = (value ? new CustomBattleType?(this.type) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<CustomBattleMatchRoleInfo> _roleinfos = new List<CustomBattleMatchRoleInfo>();

		private CustomBattleType? _type;

		private IExtension extensionObject;
	}
}
