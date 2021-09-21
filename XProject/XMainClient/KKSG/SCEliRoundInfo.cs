using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000711 RID: 1809
	[ProtoContract(Name = "SCEliRoundInfo")]
	[Serializable]
	public class SCEliRoundInfo : IExtensible
	{
		// Token: 0x170026F2 RID: 9970
		// (get) Token: 0x06007AE3 RID: 31459 RVA: 0x000EAE80 File Offset: 0x000E9080
		// (set) Token: 0x06007AE4 RID: 31460 RVA: 0x000EAEAC File Offset: 0x000E90AC
		[ProtoMember(1, IsRequired = false, Name = "round", DataFormat = DataFormat.TwosComplement)]
		public SCEliRoundType round
		{
			get
			{
				return this._round ?? SCEliRoundType.SCEliRound_None;
			}
			set
			{
				this._round = new SCEliRoundType?(value);
			}
		}

		// Token: 0x170026F3 RID: 9971
		// (get) Token: 0x06007AE5 RID: 31461 RVA: 0x000EAEBC File Offset: 0x000E90BC
		// (set) Token: 0x06007AE6 RID: 31462 RVA: 0x000EAEDC File Offset: 0x000E90DC
		[XmlIgnore]
		[Browsable(false)]
		public bool roundSpecified
		{
			get
			{
				return this._round != null;
			}
			set
			{
				bool flag = value == (this._round == null);
				if (flag)
				{
					this._round = (value ? new SCEliRoundType?(this.round) : null);
				}
			}
		}

		// Token: 0x06007AE7 RID: 31463 RVA: 0x000EAF20 File Offset: 0x000E9120
		private bool ShouldSerializeround()
		{
			return this.roundSpecified;
		}

		// Token: 0x06007AE8 RID: 31464 RVA: 0x000EAF38 File Offset: 0x000E9138
		private void Resetround()
		{
			this.roundSpecified = false;
		}

		// Token: 0x170026F4 RID: 9972
		// (get) Token: 0x06007AE9 RID: 31465 RVA: 0x000EAF44 File Offset: 0x000E9144
		[ProtoMember(2, Name = "rooms", DataFormat = DataFormat.Default)]
		public List<SCEliRoomInfo> rooms
		{
			get
			{
				return this._rooms;
			}
		}

		// Token: 0x06007AEA RID: 31466 RVA: 0x000EAF5C File Offset: 0x000E915C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D03 RID: 7427
		private SCEliRoundType? _round;

		// Token: 0x04001D04 RID: 7428
		private readonly List<SCEliRoomInfo> _rooms = new List<SCEliRoomInfo>();

		// Token: 0x04001D05 RID: 7429
		private IExtension extensionObject;
	}
}
