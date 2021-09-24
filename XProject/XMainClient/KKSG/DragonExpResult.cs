using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonExpResult")]
	[Serializable]
	public class DragonExpResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "iswin", DataFormat = DataFormat.Default)]
		public bool iswin
		{
			get
			{
				return this._iswin ?? false;
			}
			set
			{
				this._iswin = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iswinSpecified
		{
			get
			{
				return this._iswin != null;
			}
			set
			{
				bool flag = value == (this._iswin == null);
				if (flag)
				{
					this._iswin = (value ? new bool?(this.iswin) : null);
				}
			}
		}

		private bool ShouldSerializeiswin()
		{
			return this.iswinSpecified;
		}

		private void Resetiswin()
		{
			this.iswinSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "bosshurthp", DataFormat = DataFormat.TwosComplement)]
		public int bosshurthp
		{
			get
			{
				return this._bosshurthp ?? 0;
			}
			set
			{
				this._bosshurthp = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bosshurthpSpecified
		{
			get
			{
				return this._bosshurthp != null;
			}
			set
			{
				bool flag = value == (this._bosshurthp == null);
				if (flag)
				{
					this._bosshurthp = (value ? new int?(this.bosshurthp) : null);
				}
			}
		}

		private bool ShouldSerializebosshurthp()
		{
			return this.bosshurthpSpecified;
		}

		private void Resetbosshurthp()
		{
			this.bosshurthpSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "bosslefthp", DataFormat = DataFormat.TwosComplement)]
		public int bosslefthp
		{
			get
			{
				return this._bosslefthp ?? 0;
			}
			set
			{
				this._bosslefthp = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bosslefthpSpecified
		{
			get
			{
				return this._bosslefthp != null;
			}
			set
			{
				bool flag = value == (this._bosslefthp == null);
				if (flag)
				{
					this._bosslefthp = (value ? new int?(this.bosslefthp) : null);
				}
			}
		}

		private bool ShouldSerializebosslefthp()
		{
			return this.bosslefthpSpecified;
		}

		private void Resetbosslefthp()
		{
			this.bosslefthpSpecified = false;
		}

		[ProtoMember(4, Name = "joinreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> joinreward
		{
			get
			{
				return this._joinreward;
			}
		}

		[ProtoMember(5, Name = "winreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> winreward
		{
			get
			{
				return this._winreward;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _iswin;

		private int? _bosshurthp;

		private int? _bosslefthp;

		private readonly List<ItemBrief> _joinreward = new List<ItemBrief>();

		private readonly List<ItemBrief> _winreward = new List<ItemBrief>();

		private uint? _sceneid;

		private IExtension extensionObject;
	}
}
