using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002C0 RID: 704
	[ProtoContract(Name = "ResWarStateInfo")]
	[Serializable]
	public class ResWarStateInfo : IExtensible
	{
		// Token: 0x17000C21 RID: 3105
		// (get) Token: 0x06002702 RID: 9986 RVA: 0x0004BDE8 File Offset: 0x00049FE8
		// (set) Token: 0x06002703 RID: 9987 RVA: 0x0004BE14 File Offset: 0x0004A014
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public ResWarState state
		{
			get
			{
				return this._state ?? ResWarState.ResWarExploreState;
			}
			set
			{
				this._state = new ResWarState?(value);
			}
		}

		// Token: 0x17000C22 RID: 3106
		// (get) Token: 0x06002704 RID: 9988 RVA: 0x0004BE24 File Offset: 0x0004A024
		// (set) Token: 0x06002705 RID: 9989 RVA: 0x0004BE44 File Offset: 0x0004A044
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
					this._state = (value ? new ResWarState?(this.state) : null);
				}
			}
		}

		// Token: 0x06002706 RID: 9990 RVA: 0x0004BE88 File Offset: 0x0004A088
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06002707 RID: 9991 RVA: 0x0004BEA0 File Offset: 0x0004A0A0
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06002708 RID: 9992 RVA: 0x0004BEAC File Offset: 0x0004A0AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009B1 RID: 2481
		private ResWarState? _state;

		// Token: 0x040009B2 RID: 2482
		private IExtension extensionObject;
	}
}
