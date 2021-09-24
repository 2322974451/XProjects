using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FetchMailRes")]
	[Serializable]
	public class FetchMailRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "page", DataFormat = DataFormat.TwosComplement)]
		public uint page
		{
			get
			{
				return this._page ?? 0U;
			}
			set
			{
				this._page = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pageSpecified
		{
			get
			{
				return this._page != null;
			}
			set
			{
				bool flag = value == (this._page == null);
				if (flag)
				{
					this._page = (value ? new uint?(this.page) : null);
				}
			}
		}

		private bool ShouldSerializepage()
		{
			return this.pageSpecified;
		}

		private void Resetpage()
		{
			this.pageSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "pagecount", DataFormat = DataFormat.TwosComplement)]
		public uint pagecount
		{
			get
			{
				return this._pagecount ?? 0U;
			}
			set
			{
				this._pagecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pagecountSpecified
		{
			get
			{
				return this._pagecount != null;
			}
			set
			{
				bool flag = value == (this._pagecount == null);
				if (flag)
				{
					this._pagecount = (value ? new uint?(this.pagecount) : null);
				}
			}
		}

		private bool ShouldSerializepagecount()
		{
			return this.pagecountSpecified;
		}

		private void Resetpagecount()
		{
			this.pagecountSpecified = false;
		}

		[ProtoMember(3, Name = "mails", DataFormat = DataFormat.Default)]
		public List<SMail> mails
		{
			get
			{
				return this._mails;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _page;

		private uint? _pagecount;

		private readonly List<SMail> _mails = new List<SMail>();

		private IExtension extensionObject;
	}
}
