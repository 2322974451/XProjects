using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfGuildCombatPara")]
	[Serializable]
	public class GmfGuildCombatPara : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "guildcombat11", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildCombat guildcombat11
		{
			get
			{
				return this._guildcombat11;
			}
			set
			{
				this._guildcombat11 = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "guildcombat22", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildCombat guildcombat22
		{
			get
			{
				return this._guildcombat22;
			}
			set
			{
				this._guildcombat22 = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GmfGuildCombat _guildcombat11 = null;

		private GmfGuildCombat _guildcombat22 = null;

		private IExtension extensionObject;
	}
}
