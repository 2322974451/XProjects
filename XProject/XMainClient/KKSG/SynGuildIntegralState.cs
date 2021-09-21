using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002C1 RID: 705
	[ProtoContract(Name = "SynGuildIntegralState")]
	[Serializable]
	public class SynGuildIntegralState : IExtensible
	{
		// Token: 0x17000C23 RID: 3107
		// (get) Token: 0x0600270A RID: 9994 RVA: 0x0004BECC File Offset: 0x0004A0CC
		// (set) Token: 0x0600270B RID: 9995 RVA: 0x0004BEF8 File Offset: 0x0004A0F8
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public IntegralState state
		{
			get
			{
				return this._state ?? IntegralState.integralready;
			}
			set
			{
				this._state = new IntegralState?(value);
			}
		}

		// Token: 0x17000C24 RID: 3108
		// (get) Token: 0x0600270C RID: 9996 RVA: 0x0004BF08 File Offset: 0x0004A108
		// (set) Token: 0x0600270D RID: 9997 RVA: 0x0004BF28 File Offset: 0x0004A128
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
					this._state = (value ? new IntegralState?(this.state) : null);
				}
			}
		}

		// Token: 0x0600270E RID: 9998 RVA: 0x0004BF6C File Offset: 0x0004A16C
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x0600270F RID: 9999 RVA: 0x0004BF84 File Offset: 0x0004A184
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06002710 RID: 10000 RVA: 0x0004BF90 File Offset: 0x0004A190
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009B3 RID: 2483
		private IntegralState? _state;

		// Token: 0x040009B4 RID: 2484
		private IExtension extensionObject;
	}
}
