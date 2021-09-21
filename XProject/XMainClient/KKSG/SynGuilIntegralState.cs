using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002BF RID: 703
	[ProtoContract(Name = "SynGuilIntegralState")]
	[Serializable]
	public class SynGuilIntegralState : IExtensible
	{
		// Token: 0x17000C1F RID: 3103
		// (get) Token: 0x060026FA RID: 9978 RVA: 0x0004BD04 File Offset: 0x00049F04
		// (set) Token: 0x060026FB RID: 9979 RVA: 0x0004BD30 File Offset: 0x00049F30
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

		// Token: 0x17000C20 RID: 3104
		// (get) Token: 0x060026FC RID: 9980 RVA: 0x0004BD40 File Offset: 0x00049F40
		// (set) Token: 0x060026FD RID: 9981 RVA: 0x0004BD60 File Offset: 0x00049F60
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

		// Token: 0x060026FE RID: 9982 RVA: 0x0004BDA4 File Offset: 0x00049FA4
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060026FF RID: 9983 RVA: 0x0004BDBC File Offset: 0x00049FBC
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06002700 RID: 9984 RVA: 0x0004BDC8 File Offset: 0x00049FC8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009AF RID: 2479
		private IntegralState? _state;

		// Token: 0x040009B0 RID: 2480
		private IExtension extensionObject;
	}
}
