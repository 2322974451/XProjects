using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MulActivityRes")]
	[Serializable]
	public class MulActivityRes : IExtensible
	{

		[ProtoMember(1, Name = "actinfo", DataFormat = DataFormat.Default)]
		public List<MulActivitInfo> actinfo
		{
			get
			{
				return this._actinfo;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "myguildlevel", DataFormat = DataFormat.TwosComplement)]
		public int myguildlevel
		{
			get
			{
				return this._myguildlevel ?? 0;
			}
			set
			{
				this._myguildlevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool myguildlevelSpecified
		{
			get
			{
				return this._myguildlevel != null;
			}
			set
			{
				bool flag = value == (this._myguildlevel == null);
				if (flag)
				{
					this._myguildlevel = (value ? new int?(this.myguildlevel) : null);
				}
			}
		}

		private bool ShouldSerializemyguildlevel()
		{
			return this.myguildlevelSpecified;
		}

		private void Resetmyguildlevel()
		{
			this.myguildlevelSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<MulActivitInfo> _actinfo = new List<MulActivitInfo>();

		private int? _myguildlevel;

		private ErrorCode? _errcode;

		private IExtension extensionObject;
	}
}
