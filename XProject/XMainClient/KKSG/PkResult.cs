using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkResult")]
	[Serializable]
	public class PkResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public PkResultType result
		{
			get
			{
				return this._result ?? PkResultType.PkResult_Win;
			}
			set
			{
				this._result = new PkResultType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new PkResultType?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "winpoint", DataFormat = DataFormat.TwosComplement)]
		public int winpoint
		{
			get
			{
				return this._winpoint ?? 0;
			}
			set
			{
				this._winpoint = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winpointSpecified
		{
			get
			{
				return this._winpoint != null;
			}
			set
			{
				bool flag = value == (this._winpoint == null);
				if (flag)
				{
					this._winpoint = (value ? new int?(this.winpoint) : null);
				}
			}
		}

		private bool ShouldSerializewinpoint()
		{
			return this.winpointSpecified;
		}

		private void Resetwinpoint()
		{
			this.winpointSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "honorpoint", DataFormat = DataFormat.TwosComplement)]
		public uint honorpoint
		{
			get
			{
				return this._honorpoint ?? 0U;
			}
			set
			{
				this._honorpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool honorpointSpecified
		{
			get
			{
				return this._honorpoint != null;
			}
			set
			{
				bool flag = value == (this._honorpoint == null);
				if (flag)
				{
					this._honorpoint = (value ? new uint?(this.honorpoint) : null);
				}
			}
		}

		private bool ShouldSerializehonorpoint()
		{
			return this.honorpointSpecified;
		}

		private void Resethonorpoint()
		{
			this.honorpointSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public int rank
		{
			get
			{
				return this._rank ?? 0;
			}
			set
			{
				this._rank = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new int?(this.rank) : null);
				}
			}
		}

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		[ProtoMember(5, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "firstrank", DataFormat = DataFormat.TwosComplement)]
		public int firstrank
		{
			get
			{
				return this._firstrank ?? 0;
			}
			set
			{
				this._firstrank = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool firstrankSpecified
		{
			get
			{
				return this._firstrank != null;
			}
			set
			{
				bool flag = value == (this._firstrank == null);
				if (flag)
				{
					this._firstrank = (value ? new int?(this.firstrank) : null);
				}
			}
		}

		private bool ShouldSerializefirstrank()
		{
			return this.firstrankSpecified;
		}

		private void Resetfirstrank()
		{
			this.firstrankSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "dragoncount", DataFormat = DataFormat.TwosComplement)]
		public uint dragoncount
		{
			get
			{
				return this._dragoncount ?? 0U;
			}
			set
			{
				this._dragoncount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragoncountSpecified
		{
			get
			{
				return this._dragoncount != null;
			}
			set
			{
				bool flag = value == (this._dragoncount == null);
				if (flag)
				{
					this._dragoncount = (value ? new uint?(this.dragoncount) : null);
				}
			}
		}

		private bool ShouldSerializedragoncount()
		{
			return this.dragoncountSpecified;
		}

		private void Resetdragoncount()
		{
			this.dragoncountSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "mystate", DataFormat = DataFormat.TwosComplement)]
		public KKVsRoleState mystate
		{
			get
			{
				return this._mystate ?? KKVsRoleState.KK_VS_ROLE_UNLOAD;
			}
			set
			{
				this._mystate = new KKVsRoleState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mystateSpecified
		{
			get
			{
				return this._mystate != null;
			}
			set
			{
				bool flag = value == (this._mystate == null);
				if (flag)
				{
					this._mystate = (value ? new KKVsRoleState?(this.mystate) : null);
				}
			}
		}

		private bool ShouldSerializemystate()
		{
			return this.mystateSpecified;
		}

		private void Resetmystate()
		{
			this.mystateSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "opstate", DataFormat = DataFormat.TwosComplement)]
		public KKVsRoleState opstate
		{
			get
			{
				return this._opstate ?? KKVsRoleState.KK_VS_ROLE_UNLOAD;
			}
			set
			{
				this._opstate = new KKVsRoleState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opstateSpecified
		{
			get
			{
				return this._opstate != null;
			}
			set
			{
				bool flag = value == (this._opstate == null);
				if (flag)
				{
					this._opstate = (value ? new KKVsRoleState?(this.opstate) : null);
				}
			}
		}

		private bool ShouldSerializeopstate()
		{
			return this.opstateSpecified;
		}

		private void Resetopstate()
		{
			this.opstateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PkResultType? _result;

		private int? _winpoint;

		private uint? _honorpoint;

		private int? _rank;

		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		private int? _firstrank;

		private uint? _dragoncount;

		private KKVsRoleState? _mystate;

		private KKVsRoleState? _opstate;

		private IExtension extensionObject;
	}
}
