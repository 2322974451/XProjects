using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NpcFeelingOneNpc")]
	[Serializable]
	public class NpcFeelingOneNpc : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "npcid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		private void Resetexp()
		{
			this.expSpecified = false;
		}

		[ProtoMember(4, Name = "likeitem", DataFormat = DataFormat.Default)]
		public List<NpcLikeItem> likeitem
		{
			get
			{
				return this._likeitem;
			}
		}

		[ProtoMember(5, Name = "exchange", DataFormat = DataFormat.Default)]
		public List<ItemBrief> exchange
		{
			get
			{
				return this._exchange;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "isnew", DataFormat = DataFormat.Default)]
		public bool isnew
		{
			get
			{
				return this._isnew ?? false;
			}
			set
			{
				this._isnew = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isnewSpecified
		{
			get
			{
				return this._isnew != null;
			}
			set
			{
				bool flag = value == (this._isnew == null);
				if (flag)
				{
					this._isnew = (value ? new bool?(this.isnew) : null);
				}
			}
		}

		private bool ShouldSerializeisnew()
		{
			return this.isnewSpecified;
		}

		private void Resetisnew()
		{
			this.isnewSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _npcid;

		private uint? _level;

		private uint? _exp;

		private readonly List<NpcLikeItem> _likeitem = new List<NpcLikeItem>();

		private readonly List<ItemBrief> _exchange = new List<ItemBrief>();

		private bool? _isnew;

		private IExtension extensionObject;
	}
}
