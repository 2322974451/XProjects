using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006F8 RID: 1784
	[ProtoContract(Name = "LBEleRoundInfo")]
	[Serializable]
	public class LBEleRoundInfo : IExtensible
	{
		// Token: 0x17002613 RID: 9747
		// (get) Token: 0x06007838 RID: 30776 RVA: 0x000E5F80 File Offset: 0x000E4180
		// (set) Token: 0x06007839 RID: 30777 RVA: 0x000E5FAC File Offset: 0x000E41AC
		[ProtoMember(1, IsRequired = false, Name = "round", DataFormat = DataFormat.TwosComplement)]
		public uint round
		{
			get
			{
				return this._round ?? 0U;
			}
			set
			{
				this._round = new uint?(value);
			}
		}

		// Token: 0x17002614 RID: 9748
		// (get) Token: 0x0600783A RID: 30778 RVA: 0x000E5FBC File Offset: 0x000E41BC
		// (set) Token: 0x0600783B RID: 30779 RVA: 0x000E5FDC File Offset: 0x000E41DC
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
					this._round = (value ? new uint?(this.round) : null);
				}
			}
		}

		// Token: 0x0600783C RID: 30780 RVA: 0x000E6020 File Offset: 0x000E4220
		private bool ShouldSerializeround()
		{
			return this.roundSpecified;
		}

		// Token: 0x0600783D RID: 30781 RVA: 0x000E6038 File Offset: 0x000E4238
		private void Resetround()
		{
			this.roundSpecified = false;
		}

		// Token: 0x17002615 RID: 9749
		// (get) Token: 0x0600783E RID: 30782 RVA: 0x000E6044 File Offset: 0x000E4244
		[ProtoMember(2, Name = "rooms", DataFormat = DataFormat.Default)]
		public List<LBEleRoomInfo> rooms
		{
			get
			{
				return this._rooms;
			}
		}

		// Token: 0x0600783F RID: 30783 RVA: 0x000E605C File Offset: 0x000E425C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C6D RID: 7277
		private uint? _round;

		// Token: 0x04001C6E RID: 7278
		private readonly List<LBEleRoomInfo> _rooms = new List<LBEleRoomInfo>();

		// Token: 0x04001C6F RID: 7279
		private IExtension extensionObject;
	}
}
