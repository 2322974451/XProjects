using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GprAllFightEnd")]
	[Serializable]
	public class GprAllFightEnd : IExtensible
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

		[ProtoMember(3, IsRequired = false, Name = "winscore", DataFormat = DataFormat.TwosComplement)]
		public uint winscore
		{
			get
			{
				return this._winscore ?? 0U;
			}
			set
			{
				this._winscore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winscoreSpecified
		{
			get
			{
				return this._winscore != null;
			}
			set
			{
				bool flag = value == (this._winscore == null);
				if (flag)
				{
					this._winscore = (value ? new uint?(this.winscore) : null);
				}
			}
		}

		private bool ShouldSerializewinscore()
		{
			return this.winscoreSpecified;
		}

		private void Resetwinscore()
		{
			this.winscoreSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "losescore", DataFormat = DataFormat.TwosComplement)]
		public uint losescore
		{
			get
			{
				return this._losescore ?? 0U;
			}
			set
			{
				this._losescore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool losescoreSpecified
		{
			get
			{
				return this._losescore != null;
			}
			set
			{
				bool flag = value == (this._losescore == null);
				if (flag)
				{
					this._losescore = (value ? new uint?(this.losescore) : null);
				}
			}
		}

		private bool ShouldSerializelosescore()
		{
			return this.losescoreSpecified;
		}

		private void Resetlosescore()
		{
			this.losescoreSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GmfGuildBrief _winguild = null;

		private GmfGuildBrief _loseguild = null;

		private uint? _winscore;

		private uint? _losescore;

		private IExtension extensionObject;
	}
}
