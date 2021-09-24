using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfAllFightEnd")]
	[Serializable]
	public class GmfAllFightEnd : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "winguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief winguild
		{
			get
			{
				return this._winguild;
			}
			set
			{
				this._winguild = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "loseguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief loseguild
		{
			get
			{
				return this._loseguild;
			}
			set
			{
				this._loseguild = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "wintype", DataFormat = DataFormat.TwosComplement)]
		public GMF_FINAL_WIN_TYPE wintype
		{
			get
			{
				return this._wintype ?? GMF_FINAL_WIN_TYPE.GMF_FWY_NORMAL;
			}
			set
			{
				this._wintype = new GMF_FINAL_WIN_TYPE?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wintypeSpecified
		{
			get
			{
				return this._wintype != null;
			}
			set
			{
				bool flag = value == (this._wintype == null);
				if (flag)
				{
					this._wintype = (value ? new GMF_FINAL_WIN_TYPE?(this.wintype) : null);
				}
			}
		}

		private bool ShouldSerializewintype()
		{
			return this.wintypeSpecified;
		}

		private void Resetwintype()
		{
			this.wintypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GmfGuildBrief _winguild = null;

		private GmfGuildBrief _loseguild = null;

		private GMF_FINAL_WIN_TYPE? _wintype;

		private IExtension extensionObject;
	}
}
