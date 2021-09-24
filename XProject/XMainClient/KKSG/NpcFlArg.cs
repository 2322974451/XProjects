using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NpcFlArg")]
	[Serializable]
	public class NpcFlArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public NpcFlReqType reqtype
		{
			get
			{
				return this._reqtype ?? NpcFlReqType.NPCFL_GIVE_GIFT;
			}
			set
			{
				this._reqtype = new NpcFlReqType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reqtypeSpecified
		{
			get
			{
				return this._reqtype != null;
			}
			set
			{
				bool flag = value == (this._reqtype == null);
				if (flag)
				{
					this._reqtype = (value ? new NpcFlReqType?(this.reqtype) : null);
				}
			}
		}

		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "likeitem", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public NpcLikeItem likeitem
		{
			get
			{
				return this._likeitem;
			}
			set
			{
				this._likeitem = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "npcid", DataFormat = DataFormat.TwosComplement)]
		public uint npcid
		{
			get
			{
				return this._npcid ?? 0U;
			}
			set
			{
				this._npcid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool npcidSpecified
		{
			get
			{
				return this._npcid != null;
			}
			set
			{
				bool flag = value == (this._npcid == null);
				if (flag)
				{
					this._npcid = (value ? new uint?(this.npcid) : null);
				}
			}
		}

		private bool ShouldSerializenpcid()
		{
			return this.npcidSpecified;
		}

		private void Resetnpcid()
		{
			this.npcidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "role2npc", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = false, Name = "npc2role", DataFormat = DataFormat.Default)]
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

		[ProtoMember(6, IsRequired = false, Name = "uniteid", DataFormat = DataFormat.TwosComplement)]
		public uint uniteid
		{
			get
			{
				return this._uniteid ?? 0U;
			}
			set
			{
				this._uniteid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uniteidSpecified
		{
			get
			{
				return this._uniteid != null;
			}
			set
			{
				bool flag = value == (this._uniteid == null);
				if (flag)
				{
					this._uniteid = (value ? new uint?(this.uniteid) : null);
				}
			}
		}

		private bool ShouldSerializeuniteid()
		{
			return this.uniteidSpecified;
		}

		private void Resetuniteid()
		{
			this.uniteidSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private NpcFlReqType? _reqtype;

		private NpcLikeItem _likeitem = null;

		private uint? _npcid;

		private ItemBrief _role2npc = null;

		private ItemBrief _npc2role = null;

		private uint? _uniteid;

		private uint? _level;

		private IExtension extensionObject;
	}
}
