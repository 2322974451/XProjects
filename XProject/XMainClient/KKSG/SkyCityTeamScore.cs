using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006AE RID: 1710
	[ProtoContract(Name = "SkyCityTeamScore")]
	[Serializable]
	public class SkyCityTeamScore : IExtensible
	{
		// Token: 0x17002358 RID: 9048
		// (get) Token: 0x06006FA8 RID: 28584 RVA: 0x000D5A64 File Offset: 0x000D3C64
		// (set) Token: 0x06006FA9 RID: 28585 RVA: 0x000D5A90 File Offset: 0x000D3C90
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

		// Token: 0x17002359 RID: 9049
		// (get) Token: 0x06006FAA RID: 28586 RVA: 0x000D5AA0 File Offset: 0x000D3CA0
		// (set) Token: 0x06006FAB RID: 28587 RVA: 0x000D5AC0 File Offset: 0x000D3CC0
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

		// Token: 0x06006FAC RID: 28588 RVA: 0x000D5B04 File Offset: 0x000D3D04
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x06006FAD RID: 28589 RVA: 0x000D5B1C File Offset: 0x000D3D1C
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x1700235A RID: 9050
		// (get) Token: 0x06006FAE RID: 28590 RVA: 0x000D5B28 File Offset: 0x000D3D28
		// (set) Token: 0x06006FAF RID: 28591 RVA: 0x000D5B54 File Offset: 0x000D3D54
		[ProtoMember(2, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x1700235B RID: 9051
		// (get) Token: 0x06006FB0 RID: 28592 RVA: 0x000D5B64 File Offset: 0x000D3D64
		// (set) Token: 0x06006FB1 RID: 28593 RVA: 0x000D5B84 File Offset: 0x000D3D84
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x06006FB2 RID: 28594 RVA: 0x000D5BC8 File Offset: 0x000D3DC8
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06006FB3 RID: 28595 RVA: 0x000D5BE0 File Offset: 0x000D3DE0
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x06006FB4 RID: 28596 RVA: 0x000D5BEC File Offset: 0x000D3DEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AB4 RID: 6836
		private uint? _teamid;

		// Token: 0x04001AB5 RID: 6837
		private uint? _score;

		// Token: 0x04001AB6 RID: 6838
		private IExtension extensionObject;
	}
}
