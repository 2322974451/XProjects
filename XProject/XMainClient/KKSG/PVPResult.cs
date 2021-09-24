using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PVPResult")]
	[Serializable]
	public class PVPResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "mygroup", DataFormat = DataFormat.TwosComplement)]
		public int mygroup
		{
			get
			{
				return this._mygroup ?? 0;
			}
			set
			{
				this._mygroup = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mygroupSpecified
		{
			get
			{
				return this._mygroup != null;
			}
			set
			{
				bool flag = value == (this._mygroup == null);
				if (flag)
				{
					this._mygroup = (value ? new int?(this.mygroup) : null);
				}
			}
		}

		private bool ShouldSerializemygroup()
		{
			return this.mygroupSpecified;
		}

		private void Resetmygroup()
		{
			this.mygroupSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "wingroup", DataFormat = DataFormat.TwosComplement)]
		public int wingroup
		{
			get
			{
				return this._wingroup ?? 0;
			}
			set
			{
				this._wingroup = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wingroupSpecified
		{
			get
			{
				return this._wingroup != null;
			}
			set
			{
				bool flag = value == (this._wingroup == null);
				if (flag)
				{
					this._wingroup = (value ? new int?(this.wingroup) : null);
				}
			}
		}

		private bool ShouldSerializewingroup()
		{
			return this.wingroupSpecified;
		}

		private void Resetwingroup()
		{
			this.wingroupSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "killleadercount", DataFormat = DataFormat.TwosComplement)]
		public int killleadercount
		{
			get
			{
				return this._killleadercount ?? 0;
			}
			set
			{
				this._killleadercount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killleadercountSpecified
		{
			get
			{
				return this._killleadercount != null;
			}
			set
			{
				bool flag = value == (this._killleadercount == null);
				if (flag)
				{
					this._killleadercount = (value ? new int?(this.killleadercount) : null);
				}
			}
		}

		private bool ShouldSerializekillleadercount()
		{
			return this.killleadercountSpecified;
		}

		private void Resetkillleadercount()
		{
			this.killleadercountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "ismvp", DataFormat = DataFormat.Default)]
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

		[ProtoMember(5, Name = "dayjoinreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> dayjoinreward
		{
			get
			{
				return this._dayjoinreward;
			}
		}

		[ProtoMember(6, Name = "winreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> winreward
		{
			get
			{
				return this._winreward;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _mygroup;

		private int? _wingroup;

		private int? _killleadercount;

		private bool? _ismvp;

		private readonly List<ItemBrief> _dayjoinreward = new List<ItemBrief>();

		private readonly List<ItemBrief> _winreward = new List<ItemBrief>();

		private IExtension extensionObject;
	}
}
