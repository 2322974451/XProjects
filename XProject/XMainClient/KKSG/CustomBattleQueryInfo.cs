using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleQueryInfo")]
	[Serializable]
	public class CustomBattleQueryInfo : IExtensible
	{

		[ProtoMember(1, Name = "battlesystem", DataFormat = DataFormat.Default)]
		public List<CustomBattleDataRole> battlesystem
		{
			get
			{
				return this._battlesystem;
			}
		}

		[ProtoMember(2, Name = "battlerandom", DataFormat = DataFormat.Default)]
		public List<CustomBattleDataRole> battlerandom
		{
			get
			{
				return this._battlerandom;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "battleone", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleDataRole battleone
		{
			get
			{
				return this._battleone;
			}
			set
			{
				this._battleone = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<CustomBattleDataRole> _battlesystem = new List<CustomBattleDataRole>();

		private readonly List<CustomBattleDataRole> _battlerandom = new List<CustomBattleDataRole>();

		private CustomBattleDataRole _battleone = null;

		private IExtension extensionObject;
	}
}
