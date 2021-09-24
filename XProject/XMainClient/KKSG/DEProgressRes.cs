using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DEProgressRes")]
	[Serializable]
	public class DEProgressRes : IExtensible
	{

		[ProtoMember(1, Name = "allpro", DataFormat = DataFormat.Default)]
		public List<DEProgress> allpro
		{
			get
			{
				return this._allpro;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
		public int allcount
		{
			get
			{
				return this._allcount ?? 0;
			}
			set
			{
				this._allcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool allcountSpecified
		{
			get
			{
				return this._allcount != null;
			}
			set
			{
				bool flag = value == (this._allcount == null);
				if (flag)
				{
					this._allcount = (value ? new int?(this.allcount) : null);
				}
			}
		}

		private bool ShouldSerializeallcount()
		{
			return this.allcountSpecified;
		}

		private void Resetallcount()
		{
			this.allcountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "leftcount", DataFormat = DataFormat.TwosComplement)]
		public int leftcount
		{
			get
			{
				return this._leftcount ?? 0;
			}
			set
			{
				this._leftcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftcountSpecified
		{
			get
			{
				return this._leftcount != null;
			}
			set
			{
				bool flag = value == (this._leftcount == null);
				if (flag)
				{
					this._leftcount = (value ? new int?(this.leftcount) : null);
				}
			}
		}

		private bool ShouldSerializeleftcount()
		{
			return this.leftcountSpecified;
		}

		private void Resetleftcount()
		{
			this.leftcountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "serverseallevel", DataFormat = DataFormat.TwosComplement)]
		public uint serverseallevel
		{
			get
			{
				return this._serverseallevel ?? 0U;
			}
			set
			{
				this._serverseallevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool serverseallevelSpecified
		{
			get
			{
				return this._serverseallevel != null;
			}
			set
			{
				bool flag = value == (this._serverseallevel == null);
				if (flag)
				{
					this._serverseallevel = (value ? new uint?(this.serverseallevel) : null);
				}
			}
		}

		private bool ShouldSerializeserverseallevel()
		{
			return this.serverseallevelSpecified;
		}

		private void Resetserverseallevel()
		{
			this.serverseallevelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<DEProgress> _allpro = new List<DEProgress>();

		private int? _allcount;

		private int? _leftcount;

		private ErrorCode? _errcode;

		private uint? _serverseallevel;

		private IExtension extensionObject;
	}
}
