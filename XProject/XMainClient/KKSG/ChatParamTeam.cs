using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005A7 RID: 1447
	[ProtoContract(Name = "ChatParamTeam")]
	[Serializable]
	public class ChatParamTeam : IExtensible
	{
		// Token: 0x1700182D RID: 6189
		// (get) Token: 0x06004E5C RID: 20060 RVA: 0x000950C8 File Offset: 0x000932C8
		// (set) Token: 0x06004E5D RID: 20061 RVA: 0x000950F4 File Offset: 0x000932F4
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

		// Token: 0x1700182E RID: 6190
		// (get) Token: 0x06004E5E RID: 20062 RVA: 0x00095104 File Offset: 0x00093304
		// (set) Token: 0x06004E5F RID: 20063 RVA: 0x00095124 File Offset: 0x00093324
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

		// Token: 0x06004E60 RID: 20064 RVA: 0x00095168 File Offset: 0x00093368
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x06004E61 RID: 20065 RVA: 0x00095180 File Offset: 0x00093380
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x1700182F RID: 6191
		// (get) Token: 0x06004E62 RID: 20066 RVA: 0x0009518C File Offset: 0x0009338C
		// (set) Token: 0x06004E63 RID: 20067 RVA: 0x000951B8 File Offset: 0x000933B8
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

		// Token: 0x17001830 RID: 6192
		// (get) Token: 0x06004E64 RID: 20068 RVA: 0x000951C8 File Offset: 0x000933C8
		// (set) Token: 0x06004E65 RID: 20069 RVA: 0x000951E8 File Offset: 0x000933E8
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

		// Token: 0x06004E66 RID: 20070 RVA: 0x0009522C File Offset: 0x0009342C
		private bool ShouldSerializeexpeditionid()
		{
			return this.expeditionidSpecified;
		}

		// Token: 0x06004E67 RID: 20071 RVA: 0x00095244 File Offset: 0x00093444
		private void Resetexpeditionid()
		{
			this.expeditionidSpecified = false;
		}

		// Token: 0x17001831 RID: 6193
		// (get) Token: 0x06004E68 RID: 20072 RVA: 0x00095250 File Offset: 0x00093450
		// (set) Token: 0x06004E69 RID: 20073 RVA: 0x00095271 File Offset: 0x00093471
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

		// Token: 0x17001832 RID: 6194
		// (get) Token: 0x06004E6A RID: 20074 RVA: 0x0009527C File Offset: 0x0009347C
		// (set) Token: 0x06004E6B RID: 20075 RVA: 0x00095298 File Offset: 0x00093498
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

		// Token: 0x06004E6C RID: 20076 RVA: 0x000952C8 File Offset: 0x000934C8
		private bool ShouldSerializeteamname()
		{
			return this.teamnameSpecified;
		}

		// Token: 0x06004E6D RID: 20077 RVA: 0x000952E0 File Offset: 0x000934E0
		private void Resetteamname()
		{
			this.teamnameSpecified = false;
		}

		// Token: 0x06004E6E RID: 20078 RVA: 0x000952EC File Offset: 0x000934EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001362 RID: 4962
		private uint? _teamid;

		// Token: 0x04001363 RID: 4963
		private uint? _expeditionid;

		// Token: 0x04001364 RID: 4964
		private string _teamname;

		// Token: 0x04001365 RID: 4965
		private IExtension extensionObject;
	}
}
