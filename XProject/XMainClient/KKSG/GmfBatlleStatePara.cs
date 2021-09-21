using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000267 RID: 615
	[ProtoContract(Name = "GmfBatlleStatePara")]
	[Serializable]
	public class GmfBatlleStatePara : IExtensible
	{
		// Token: 0x17000AB0 RID: 2736
		// (get) Token: 0x06002259 RID: 8793 RVA: 0x000431F0 File Offset: 0x000413F0
		// (set) Token: 0x0600225A RID: 8794 RVA: 0x0004321C File Offset: 0x0004141C
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public GmfBattleState state
		{
			get
			{
				return this._state ?? GmfBattleState.GMF_BS_NONE;
			}
			set
			{
				this._state = new GmfBattleState?(value);
			}
		}

		// Token: 0x17000AB1 RID: 2737
		// (get) Token: 0x0600225B RID: 8795 RVA: 0x0004322C File Offset: 0x0004142C
		// (set) Token: 0x0600225C RID: 8796 RVA: 0x0004324C File Offset: 0x0004144C
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
					this._state = (value ? new GmfBattleState?(this.state) : null);
				}
			}
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x00043290 File Offset: 0x00041490
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x000432A8 File Offset: 0x000414A8
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17000AB2 RID: 2738
		// (get) Token: 0x0600225F RID: 8799 RVA: 0x000432B4 File Offset: 0x000414B4
		// (set) Token: 0x06002260 RID: 8800 RVA: 0x000432E0 File Offset: 0x000414E0
		[ProtoMember(2, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x17000AB3 RID: 2739
		// (get) Token: 0x06002261 RID: 8801 RVA: 0x000432F0 File Offset: 0x000414F0
		// (set) Token: 0x06002262 RID: 8802 RVA: 0x00043310 File Offset: 0x00041510
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x00043354 File Offset: 0x00041554
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x0004336C File Offset: 0x0004156C
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x00043378 File Offset: 0x00041578
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000885 RID: 2181
		private GmfBattleState? _state;

		// Token: 0x04000886 RID: 2182
		private uint? _lefttime;

		// Token: 0x04000887 RID: 2183
		private IExtension extensionObject;
	}
}
