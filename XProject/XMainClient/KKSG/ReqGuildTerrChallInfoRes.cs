using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildTerrChallInfoRes")]
	[Serializable]
	public class ReqGuildTerrChallInfoRes : IExtensible
	{

		[ProtoMember(1, Name = "challinfo", DataFormat = DataFormat.Default)]
		public List<GuildTerrChallInfo> challinfo
		{
			get
			{
				return this._challinfo;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "cdtime", DataFormat = DataFormat.TwosComplement)]
		public uint cdtime
		{
			get
			{
				return this._cdtime ?? 0U;
			}
			set
			{
				this._cdtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cdtimeSpecified
		{
			get
			{
				return this._cdtime != null;
			}
			set
			{
				bool flag = value == (this._cdtime == null);
				if (flag)
				{
					this._cdtime = (value ? new uint?(this.cdtime) : null);
				}
			}
		}

		private bool ShouldSerializecdtime()
		{
			return this.cdtimeSpecified;
		}

		private void Resetcdtime()
		{
			this.cdtimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<GuildTerrChallInfo> _challinfo = new List<GuildTerrChallInfo>();

		private uint? _cdtime;

		private IExtension extensionObject;
	}
}
