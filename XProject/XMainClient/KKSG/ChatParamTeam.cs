using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChatParamTeam")]
	[Serializable]
	public class ChatParamTeam : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public uint teamid
		{
			get
			{
				return this._teamid ?? 0U;
			}
			set
			{
				this._teamid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new uint?(this.teamid) : null);
				}
			}
		}

		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "expeditionid", DataFormat = DataFormat.TwosComplement)]
		public uint expeditionid
		{
			get
			{
				return this._expeditionid ?? 0U;
			}
			set
			{
				this._expeditionid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expeditionidSpecified
		{
			get
			{
				return this._expeditionid != null;
			}
			set
			{
				bool flag = value == (this._expeditionid == null);
				if (flag)
				{
					this._expeditionid = (value ? new uint?(this.expeditionid) : null);
				}
			}
		}

		private bool ShouldSerializeexpeditionid()
		{
			return this.expeditionidSpecified;
		}

		private void Resetexpeditionid()
		{
			this.expeditionidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "teamname", DataFormat = DataFormat.Default)]
		public string teamname
		{
			get
			{
				return this._teamname ?? "";
			}
			set
			{
				this._teamname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamnameSpecified
		{
			get
			{
				return this._teamname != null;
			}
			set
			{
				bool flag = value == (this._teamname == null);
				if (flag)
				{
					this._teamname = (value ? this.teamname : null);
				}
			}
		}

		private bool ShouldSerializeteamname()
		{
			return this.teamnameSpecified;
		}

		private void Resetteamname()
		{
			this.teamnameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _teamid;

		private uint? _expeditionid;

		private string _teamname;

		private IExtension extensionObject;
	}
}
