using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaBattleOneGameBrief")]
	[Serializable]
	public class MobaBattleOneGameBrief : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "tag", DataFormat = DataFormat.TwosComplement)]
		public uint tag
		{
			get
			{
				return this._tag ?? 0U;
			}
			set
			{
				this._tag = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tagSpecified
		{
			get
			{
				return this._tag != null;
			}
			set
			{
				bool flag = value == (this._tag == null);
				if (flag)
				{
					this._tag = (value ? new uint?(this.tag) : null);
				}
			}
		}

		private bool ShouldSerializetag()
		{
			return this.tagSpecified;
		}

		private void Resettag()
		{
			this.tagSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "date", DataFormat = DataFormat.TwosComplement)]
		public uint date
		{
			get
			{
				return this._date ?? 0U;
			}
			set
			{
				this._date = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dateSpecified
		{
			get
			{
				return this._date != null;
			}
			set
			{
				bool flag = value == (this._date == null);
				if (flag)
				{
					this._date = (value ? new uint?(this.date) : null);
				}
			}
		}

		private bool ShouldSerializedate()
		{
			return this.dateSpecified;
		}

		private void Resetdate()
		{
			this.dateSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "iswin", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, IsRequired = false, Name = "isescape", DataFormat = DataFormat.Default)]
		public bool isescape
		{
			get
			{
				return this._isescape ?? false;
			}
			set
			{
				this._isescape = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isescapeSpecified
		{
			get
			{
				return this._isescape != null;
			}
			set
			{
				bool flag = value == (this._isescape == null);
				if (flag)
				{
					this._isescape = (value ? new bool?(this.isescape) : null);
				}
			}
		}

		private bool ShouldSerializeisescape()
		{
			return this.isescapeSpecified;
		}

		private void Resetisescape()
		{
			this.isescapeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "ismvp", DataFormat = DataFormat.Default)]
		public bool ismvp
		{
			get
			{
				return this._ismvp ?? false;
			}
			set
			{
				this._ismvp = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ismvpSpecified
		{
			get
			{
				return this._ismvp != null;
			}
			set
			{
				bool flag = value == (this._ismvp == null);
				if (flag)
				{
					this._ismvp = (value ? new bool?(this.ismvp) : null);
				}
			}
		}

		private bool ShouldSerializeismvp()
		{
			return this.ismvpSpecified;
		}

		private void Resetismvp()
		{
			this.ismvpSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "islosemvp", DataFormat = DataFormat.Default)]
		public bool islosemvp
		{
			get
			{
				return this._islosemvp ?? false;
			}
			set
			{
				this._islosemvp = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool islosemvpSpecified
		{
			get
			{
				return this._islosemvp != null;
			}
			set
			{
				bool flag = value == (this._islosemvp == null);
				if (flag)
				{
					this._islosemvp = (value ? new bool?(this.islosemvp) : null);
				}
			}
		}

		private bool ShouldSerializeislosemvp()
		{
			return this.islosemvpSpecified;
		}

		private void Resetislosemvp()
		{
			this.islosemvpSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _tag;

		private uint? _date;

		private uint? _heroid;

		private bool? _iswin;

		private bool? _isescape;

		private bool? _ismvp;

		private bool? _islosemvp;

		private IExtension extensionObject;
	}
}
