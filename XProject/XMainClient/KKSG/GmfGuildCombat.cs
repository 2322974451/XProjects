using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfGuildCombat")]
	[Serializable]
	public class GmfGuildCombat : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "gmfguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief gmfguild
		{
			get
			{
				return this._gmfguild;
			}
			set
			{
				this._gmfguild = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "combat", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfCombat combat
		{
			get
			{
				return this._combat;
			}
			set
			{
				this._combat = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		[ProtoMember(4, Name = "rolecombat", DataFormat = DataFormat.Default)]
		public List<GmfRoleCombat> rolecombat
		{
			get
			{
				return this._rolecombat;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GmfGuildBrief _gmfguild = null;

		private GmfCombat _combat = null;

		private uint? _score;

		private readonly List<GmfRoleCombat> _rolecombat = new List<GmfRoleCombat>();

		private IExtension extensionObject;
	}
}
