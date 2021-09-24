using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryMayhemRankRes")]
	[Serializable]
	public class QueryMayhemRankRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "err", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode err
		{
			get
			{
				return this._err ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._err = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errSpecified
		{
			get
			{
				return this._err != null;
			}
			set
			{
				bool flag = value == (this._err == null);
				if (flag)
				{
					this._err = (value ? new ErrorCode?(this.err) : null);
				}
			}
		}

		private bool ShouldSerializeerr()
		{
			return this.errSpecified;
		}

		private void Reseterr()
		{
			this.errSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "selfrank", DataFormat = DataFormat.TwosComplement)]
		public int selfrank
		{
			get
			{
				return this._selfrank ?? 0;
			}
			set
			{
				this._selfrank = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool selfrankSpecified
		{
			get
			{
				return this._selfrank != null;
			}
			set
			{
				bool flag = value == (this._selfrank == null);
				if (flag)
				{
					this._selfrank = (value ? new int?(this.selfrank) : null);
				}
			}
		}

		private bool ShouldSerializeselfrank()
		{
			return this.selfrankSpecified;
		}

		private void Resetselfrank()
		{
			this.selfrankSpecified = false;
		}

		[ProtoMember(3, Name = "rank", DataFormat = DataFormat.Default)]
		public List<MayhemRankInfo> rank
		{
			get
			{
				return this._rank;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "infight", DataFormat = DataFormat.Default)]
		public bool infight
		{
			get
			{
				return this._infight ?? false;
			}
			set
			{
				this._infight = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool infightSpecified
		{
			get
			{
				return this._infight != null;
			}
			set
			{
				bool flag = value == (this._infight == null);
				if (flag)
				{
					this._infight = (value ? new bool?(this.infight) : null);
				}
			}
		}

		private bool ShouldSerializeinfight()
		{
			return this.infightSpecified;
		}

		private void Resetinfight()
		{
			this.infightSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "selfinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MayhemRankInfo selfinfo
		{
			get
			{
				return this._selfinfo;
			}
			set
			{
				this._selfinfo = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "gamezoneid", DataFormat = DataFormat.TwosComplement)]
		public uint gamezoneid
		{
			get
			{
				return this._gamezoneid ?? 0U;
			}
			set
			{
				this._gamezoneid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gamezoneidSpecified
		{
			get
			{
				return this._gamezoneid != null;
			}
			set
			{
				bool flag = value == (this._gamezoneid == null);
				if (flag)
				{
					this._gamezoneid = (value ? new uint?(this.gamezoneid) : null);
				}
			}
		}

		private bool ShouldSerializegamezoneid()
		{
			return this.gamezoneidSpecified;
		}

		private void Resetgamezoneid()
		{
			this.gamezoneidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _err;

		private int? _selfrank;

		private readonly List<MayhemRankInfo> _rank = new List<MayhemRankInfo>();

		private bool? _infight;

		private MayhemRankInfo _selfinfo = null;

		private uint? _gamezoneid;

		private IExtension extensionObject;
	}
}
