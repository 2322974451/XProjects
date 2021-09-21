using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200070C RID: 1804
	[ProtoContract(Name = "CustomBattleRole")]
	[Serializable]
	public class CustomBattleRole : IExtensible
	{
		// Token: 0x170026C4 RID: 9924
		// (get) Token: 0x06007A54 RID: 31316 RVA: 0x000E9D5C File Offset: 0x000E7F5C
		// (set) Token: 0x06007A55 RID: 31317 RVA: 0x000E9D89 File Offset: 0x000E7F89
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x170026C5 RID: 9925
		// (get) Token: 0x06007A56 RID: 31318 RVA: 0x000E9D98 File Offset: 0x000E7F98
		// (set) Token: 0x06007A57 RID: 31319 RVA: 0x000E9DB8 File Offset: 0x000E7FB8
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06007A58 RID: 31320 RVA: 0x000E9DFC File Offset: 0x000E7FFC
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06007A59 RID: 31321 RVA: 0x000E9E14 File Offset: 0x000E8014
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x170026C6 RID: 9926
		// (get) Token: 0x06007A5A RID: 31322 RVA: 0x000E9E20 File Offset: 0x000E8020
		// (set) Token: 0x06007A5B RID: 31323 RVA: 0x000E9E4C File Offset: 0x000E804C
		[ProtoMember(2, IsRequired = false, Name = "configid", DataFormat = DataFormat.TwosComplement)]
		public uint configid
		{
			get
			{
				return this._configid ?? 0U;
			}
			set
			{
				this._configid = new uint?(value);
			}
		}

		// Token: 0x170026C7 RID: 9927
		// (get) Token: 0x06007A5C RID: 31324 RVA: 0x000E9E5C File Offset: 0x000E805C
		// (set) Token: 0x06007A5D RID: 31325 RVA: 0x000E9E7C File Offset: 0x000E807C
		[XmlIgnore]
		[Browsable(false)]
		public bool configidSpecified
		{
			get
			{
				return this._configid != null;
			}
			set
			{
				bool flag = value == (this._configid == null);
				if (flag)
				{
					this._configid = (value ? new uint?(this.configid) : null);
				}
			}
		}

		// Token: 0x06007A5E RID: 31326 RVA: 0x000E9EC0 File Offset: 0x000E80C0
		private bool ShouldSerializeconfigid()
		{
			return this.configidSpecified;
		}

		// Token: 0x06007A5F RID: 31327 RVA: 0x000E9ED8 File Offset: 0x000E80D8
		private void Resetconfigid()
		{
			this.configidSpecified = false;
		}

		// Token: 0x170026C8 RID: 9928
		// (get) Token: 0x06007A60 RID: 31328 RVA: 0x000E9EE4 File Offset: 0x000E80E4
		// (set) Token: 0x06007A61 RID: 31329 RVA: 0x000E9F10 File Offset: 0x000E8110
		[ProtoMember(3, IsRequired = false, Name = "lose", DataFormat = DataFormat.TwosComplement)]
		public uint lose
		{
			get
			{
				return this._lose ?? 0U;
			}
			set
			{
				this._lose = new uint?(value);
			}
		}

		// Token: 0x170026C9 RID: 9929
		// (get) Token: 0x06007A62 RID: 31330 RVA: 0x000E9F20 File Offset: 0x000E8120
		// (set) Token: 0x06007A63 RID: 31331 RVA: 0x000E9F40 File Offset: 0x000E8140
		[XmlIgnore]
		[Browsable(false)]
		public bool loseSpecified
		{
			get
			{
				return this._lose != null;
			}
			set
			{
				bool flag = value == (this._lose == null);
				if (flag)
				{
					this._lose = (value ? new uint?(this.lose) : null);
				}
			}
		}

		// Token: 0x06007A64 RID: 31332 RVA: 0x000E9F84 File Offset: 0x000E8184
		private bool ShouldSerializelose()
		{
			return this.loseSpecified;
		}

		// Token: 0x06007A65 RID: 31333 RVA: 0x000E9F9C File Offset: 0x000E819C
		private void Resetlose()
		{
			this.loseSpecified = false;
		}

		// Token: 0x170026CA RID: 9930
		// (get) Token: 0x06007A66 RID: 31334 RVA: 0x000E9FA8 File Offset: 0x000E81A8
		// (set) Token: 0x06007A67 RID: 31335 RVA: 0x000E9FD4 File Offset: 0x000E81D4
		[ProtoMember(4, IsRequired = false, Name = "win", DataFormat = DataFormat.TwosComplement)]
		public uint win
		{
			get
			{
				return this._win ?? 0U;
			}
			set
			{
				this._win = new uint?(value);
			}
		}

		// Token: 0x170026CB RID: 9931
		// (get) Token: 0x06007A68 RID: 31336 RVA: 0x000E9FE4 File Offset: 0x000E81E4
		// (set) Token: 0x06007A69 RID: 31337 RVA: 0x000EA004 File Offset: 0x000E8204
		[XmlIgnore]
		[Browsable(false)]
		public bool winSpecified
		{
			get
			{
				return this._win != null;
			}
			set
			{
				bool flag = value == (this._win == null);
				if (flag)
				{
					this._win = (value ? new uint?(this.win) : null);
				}
			}
		}

		// Token: 0x06007A6A RID: 31338 RVA: 0x000EA048 File Offset: 0x000E8248
		private bool ShouldSerializewin()
		{
			return this.winSpecified;
		}

		// Token: 0x06007A6B RID: 31339 RVA: 0x000EA060 File Offset: 0x000E8260
		private void Resetwin()
		{
			this.winSpecified = false;
		}

		// Token: 0x170026CC RID: 9932
		// (get) Token: 0x06007A6C RID: 31340 RVA: 0x000EA06C File Offset: 0x000E826C
		// (set) Token: 0x06007A6D RID: 31341 RVA: 0x000EA098 File Offset: 0x000E8298
		[ProtoMember(5, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x170026CD RID: 9933
		// (get) Token: 0x06007A6E RID: 31342 RVA: 0x000EA0A8 File Offset: 0x000E82A8
		// (set) Token: 0x06007A6F RID: 31343 RVA: 0x000EA0C8 File Offset: 0x000E82C8
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06007A70 RID: 31344 RVA: 0x000EA10C File Offset: 0x000E830C
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06007A71 RID: 31345 RVA: 0x000EA124 File Offset: 0x000E8324
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x170026CE RID: 9934
		// (get) Token: 0x06007A72 RID: 31346 RVA: 0x000EA130 File Offset: 0x000E8330
		// (set) Token: 0x06007A73 RID: 31347 RVA: 0x000EA15C File Offset: 0x000E835C
		[ProtoMember(6, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x170026CF RID: 9935
		// (get) Token: 0x06007A74 RID: 31348 RVA: 0x000EA16C File Offset: 0x000E836C
		// (set) Token: 0x06007A75 RID: 31349 RVA: 0x000EA18C File Offset: 0x000E838C
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x06007A76 RID: 31350 RVA: 0x000EA1D0 File Offset: 0x000E83D0
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06007A77 RID: 31351 RVA: 0x000EA1E8 File Offset: 0x000E83E8
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x170026D0 RID: 9936
		// (get) Token: 0x06007A78 RID: 31352 RVA: 0x000EA1F4 File Offset: 0x000E83F4
		// (set) Token: 0x06007A79 RID: 31353 RVA: 0x000EA220 File Offset: 0x000E8420
		[ProtoMember(7, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public CustomBattleRoleState state
		{
			get
			{
				return this._state ?? CustomBattleRoleState.CustomBattle_RoleState_Ready;
			}
			set
			{
				this._state = new CustomBattleRoleState?(value);
			}
		}

		// Token: 0x170026D1 RID: 9937
		// (get) Token: 0x06007A7A RID: 31354 RVA: 0x000EA230 File Offset: 0x000E8430
		// (set) Token: 0x06007A7B RID: 31355 RVA: 0x000EA250 File Offset: 0x000E8450
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new CustomBattleRoleState?(this.state) : null);
				}
			}
		}

		// Token: 0x06007A7C RID: 31356 RVA: 0x000EA294 File Offset: 0x000E8494
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06007A7D RID: 31357 RVA: 0x000EA2AC File Offset: 0x000E84AC
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170026D2 RID: 9938
		// (get) Token: 0x06007A7E RID: 31358 RVA: 0x000EA2B8 File Offset: 0x000E84B8
		// (set) Token: 0x06007A7F RID: 31359 RVA: 0x000EA2E4 File Offset: 0x000E84E4
		[ProtoMember(8, IsRequired = false, Name = "rewardcd", DataFormat = DataFormat.TwosComplement)]
		public uint rewardcd
		{
			get
			{
				return this._rewardcd ?? 0U;
			}
			set
			{
				this._rewardcd = new uint?(value);
			}
		}

		// Token: 0x170026D3 RID: 9939
		// (get) Token: 0x06007A80 RID: 31360 RVA: 0x000EA2F4 File Offset: 0x000E84F4
		// (set) Token: 0x06007A81 RID: 31361 RVA: 0x000EA314 File Offset: 0x000E8514
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardcdSpecified
		{
			get
			{
				return this._rewardcd != null;
			}
			set
			{
				bool flag = value == (this._rewardcd == null);
				if (flag)
				{
					this._rewardcd = (value ? new uint?(this.rewardcd) : null);
				}
			}
		}

		// Token: 0x06007A82 RID: 31362 RVA: 0x000EA358 File Offset: 0x000E8558
		private bool ShouldSerializerewardcd()
		{
			return this.rewardcdSpecified;
		}

		// Token: 0x06007A83 RID: 31363 RVA: 0x000EA370 File Offset: 0x000E8570
		private void Resetrewardcd()
		{
			this.rewardcdSpecified = false;
		}

		// Token: 0x170026D4 RID: 9940
		// (get) Token: 0x06007A84 RID: 31364 RVA: 0x000EA37C File Offset: 0x000E857C
		[ProtoMember(9, Name = "records", DataFormat = DataFormat.TwosComplement)]
		public List<uint> records
		{
			get
			{
				return this._records;
			}
		}

		// Token: 0x170026D5 RID: 9941
		// (get) Token: 0x06007A85 RID: 31365 RVA: 0x000EA394 File Offset: 0x000E8594
		// (set) Token: 0x06007A86 RID: 31366 RVA: 0x000EA3C0 File Offset: 0x000E85C0
		[ProtoMember(10, IsRequired = false, Name = "draw", DataFormat = DataFormat.TwosComplement)]
		public uint draw
		{
			get
			{
				return this._draw ?? 0U;
			}
			set
			{
				this._draw = new uint?(value);
			}
		}

		// Token: 0x170026D6 RID: 9942
		// (get) Token: 0x06007A87 RID: 31367 RVA: 0x000EA3D0 File Offset: 0x000E85D0
		// (set) Token: 0x06007A88 RID: 31368 RVA: 0x000EA3F0 File Offset: 0x000E85F0
		[XmlIgnore]
		[Browsable(false)]
		public bool drawSpecified
		{
			get
			{
				return this._draw != null;
			}
			set
			{
				bool flag = value == (this._draw == null);
				if (flag)
				{
					this._draw = (value ? new uint?(this.draw) : null);
				}
			}
		}

		// Token: 0x06007A89 RID: 31369 RVA: 0x000EA434 File Offset: 0x000E8634
		private bool ShouldSerializedraw()
		{
			return this.drawSpecified;
		}

		// Token: 0x06007A8A RID: 31370 RVA: 0x000EA44C File Offset: 0x000E864C
		private void Resetdraw()
		{
			this.drawSpecified = false;
		}

		// Token: 0x06007A8B RID: 31371 RVA: 0x000EA458 File Offset: 0x000E8658
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CE5 RID: 7397
		private ulong? _uid;

		// Token: 0x04001CE6 RID: 7398
		private uint? _configid;

		// Token: 0x04001CE7 RID: 7399
		private uint? _lose;

		// Token: 0x04001CE8 RID: 7400
		private uint? _win;

		// Token: 0x04001CE9 RID: 7401
		private uint? _point;

		// Token: 0x04001CEA RID: 7402
		private uint? _rank;

		// Token: 0x04001CEB RID: 7403
		private CustomBattleRoleState? _state;

		// Token: 0x04001CEC RID: 7404
		private uint? _rewardcd;

		// Token: 0x04001CED RID: 7405
		private readonly List<uint> _records = new List<uint>();

		// Token: 0x04001CEE RID: 7406
		private uint? _draw;

		// Token: 0x04001CEF RID: 7407
		private IExtension extensionObject;
	}
}
