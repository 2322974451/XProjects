using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GprOneBattleEnd")]
	[Serializable]
	public class GprOneBattleEnd : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "winguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief winguild
		{
			get
			{
				return this._winguild;
			}
			set
			{
				this._winguild = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "loseguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief loseguild
		{
			get
			{
				return this._loseguild;
			}
			set
			{
				this._loseguild = value;
			}
		}

		[ProtoMember(3, Name = "winrolecombat", DataFormat = DataFormat.Default)]
		public List<GmfRoleCombat> winrolecombat
		{
			get
			{
				return this._winrolecombat;
			}
		}

		[ProtoMember(4, Name = "loserolecombat", DataFormat = DataFormat.Default)]
		public List<GmfRoleCombat> loserolecombat
		{
			get
			{
				return this._loserolecombat;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GmfGuildBrief _winguild = null;

		private GmfGuildBrief _loseguild = null;

		private readonly List<GmfRoleCombat> _winrolecombat = new List<GmfRoleCombat>();

		private readonly List<GmfRoleCombat> _loserolecombat = new List<GmfRoleCombat>();

		private IExtension extensionObject;
	}
}
