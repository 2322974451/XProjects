using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetWorldBossTimeLeftRes")]
	[Serializable]
	public class GetWorldBossTimeLeftRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "guildrolecount", DataFormat = DataFormat.TwosComplement)]
		public uint guildrolecount
		{
			get
			{
				return this._guildrolecount ?? 0U;
			}
			set
			{
				this._guildrolecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildrolecountSpecified
		{
			get
			{
				return this._guildrolecount != null;
			}
			set
			{
				bool flag = value == (this._guildrolecount == null);
				if (flag)
				{
					this._guildrolecount = (value ? new uint?(this.guildrolecount) : null);
				}
			}
		}

		private bool ShouldSerializeguildrolecount()
		{
			return this.guildrolecountSpecified;
		}

		private void Resetguildrolecount()
		{
			this.guildrolecountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _timeleft;

		private uint? _guildrolecount;

		private IExtension extensionObject;
	}
}
