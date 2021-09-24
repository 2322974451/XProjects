using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NpcFlRes")]
	[Serializable]
	public class NpcFlRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, Name = "npclist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingOneNpc> npclist
		{
			get
			{
				return this._npclist;
			}
		}

		[ProtoMember(3, Name = "unitelist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingUnite> unitelist
		{
			get
			{
				return this._unitelist;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "giveleftcount", DataFormat = DataFormat.TwosComplement)]
		public uint giveleftcount
		{
			get
			{
				return this._giveleftcount ?? 0U;
			}
			set
			{
				this._giveleftcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool giveleftcountSpecified
		{
			get
			{
				return this._giveleftcount != null;
			}
			set
			{
				bool flag = value == (this._giveleftcount == null);
				if (flag)
				{
					this._giveleftcount = (value ? new uint?(this.giveleftcount) : null);
				}
			}
		}

		private bool ShouldSerializegiveleftcount()
		{
			return this.giveleftcountSpecified;
		}

		private void Resetgiveleftcount()
		{
			this.giveleftcountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "buyleftcount", DataFormat = DataFormat.TwosComplement)]
		public uint buyleftcount
		{
			get
			{
				return this._buyleftcount ?? 0U;
			}
			set
			{
				this._buyleftcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buyleftcountSpecified
		{
			get
			{
				return this._buyleftcount != null;
			}
			set
			{
				bool flag = value == (this._buyleftcount == null);
				if (flag)
				{
					this._buyleftcount = (value ? new uint?(this.buyleftcount) : null);
				}
			}
		}

		private bool ShouldSerializebuyleftcount()
		{
			return this.buyleftcountSpecified;
		}

		private void Resetbuyleftcount()
		{
			this.buyleftcountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "buycost", DataFormat = DataFormat.TwosComplement)]
		public uint buycost
		{
			get
			{
				return this._buycost ?? 0U;
			}
			set
			{
				this._buycost = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buycostSpecified
		{
			get
			{
				return this._buycost != null;
			}
			set
			{
				bool flag = value == (this._buycost == null);
				if (flag)
				{
					this._buycost = (value ? new uint?(this.buycost) : null);
				}
			}
		}

		private bool ShouldSerializebuycost()
		{
			return this.buycostSpecified;
		}

		private void Resetbuycost()
		{
			this.buycostSpecified = false;
		}

		[ProtoMember(7, Name = "npcfavorrole", DataFormat = DataFormat.Default)]
		public List<NpcFlNpc2Role> npcfavorrole
		{
			get
			{
				return this._npcfavorrole;
			}
		}

		[ProtoMember(8, Name = "changenpclist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingOneNpc> changenpclist
		{
			get
			{
				return this._changenpclist;
			}
		}

		[ProtoMember(9, Name = "changeunitelist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingUnite> changeunitelist
		{
			get
			{
				return this._changeunitelist;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "role2npc", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief role2npc
		{
			get
			{
				return this._role2npc;
			}
			set
			{
				this._role2npc = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "npc2role", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief npc2role
		{
			get
			{
				return this._npc2role;
			}
			set
			{
				this._npc2role = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "npcflleveltop", DataFormat = DataFormat.TwosComplement)]
		public uint npcflleveltop
		{
			get
			{
				return this._npcflleveltop ?? 0U;
			}
			set
			{
				this._npcflleveltop = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool npcflleveltopSpecified
		{
			get
			{
				return this._npcflleveltop != null;
			}
			set
			{
				bool flag = value == (this._npcflleveltop == null);
				if (flag)
				{
					this._npcflleveltop = (value ? new uint?(this.npcflleveltop) : null);
				}
			}
		}

		private bool ShouldSerializenpcflleveltop()
		{
			return this.npcflleveltopSpecified;
		}

		private void Resetnpcflleveltop()
		{
			this.npcflleveltopSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<NpcFeelingOneNpc> _npclist = new List<NpcFeelingOneNpc>();

		private readonly List<NpcFeelingUnite> _unitelist = new List<NpcFeelingUnite>();

		private uint? _giveleftcount;

		private uint? _buyleftcount;

		private uint? _buycost;

		private readonly List<NpcFlNpc2Role> _npcfavorrole = new List<NpcFlNpc2Role>();

		private readonly List<NpcFeelingOneNpc> _changenpclist = new List<NpcFeelingOneNpc>();

		private readonly List<NpcFeelingUnite> _changeunitelist = new List<NpcFeelingUnite>();

		private ItemBrief _role2npc = null;

		private ItemBrief _npc2role = null;

		private uint? _npcflleveltop;

		private IExtension extensionObject;
	}
}
