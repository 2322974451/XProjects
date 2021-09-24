using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FetchTeamListRes")]
	[Serializable]
	public class FetchTeamListRes : IExtensible
	{

		[ProtoMember(1, Name = "teams", DataFormat = DataFormat.Default)]
		public List<TeamBrief> teams
		{
			get
			{
				return this._teams;
			}
		}

		[ProtoMember(2, Name = "TheTeams", DataFormat = DataFormat.Default)]
		public List<TeamFullDataNtf> TheTeams
		{
			get
			{
				return this._TheTeams;
			}
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

		private readonly List<TeamBrief> _teams = new List<TeamBrief>();

		private readonly List<TeamFullDataNtf> _TheTeams = new List<TeamFullDataNtf>();

		private ErrorCode? _errcode;

		private IExtension extensionObject;
	}
}
