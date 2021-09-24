using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildTerrAllianceInfoRes")]
	[Serializable]
	public class ReqGuildTerrAllianceInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "allianceid", DataFormat = DataFormat.TwosComplement)]
		public ulong allianceid
		{
			get
			{
				return this._allianceid ?? 0UL;
			}
			set
			{
				this._allianceid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool allianceidSpecified
		{
			get
			{
				return this._allianceid != null;
			}
			set
			{
				bool flag = value == (this._allianceid == null);
				if (flag)
				{
					this._allianceid = (value ? new ulong?(this.allianceid) : null);
				}
			}
		}

		private bool ShouldSerializeallianceid()
		{
			return this.allianceidSpecified;
		}

		private void Resetallianceid()
		{
			this.allianceidSpecified = false;
		}

		[ProtoMember(2, Name = "allianceinfo", DataFormat = DataFormat.Default)]
		public List<GuildTerrAllianceInfo> allianceinfo
		{
			get
			{
				return this._allianceinfo;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _allianceid;

		private readonly List<GuildTerrAllianceInfo> _allianceinfo = new List<GuildTerrAllianceInfo>();

		private IExtension extensionObject;
	}
}
