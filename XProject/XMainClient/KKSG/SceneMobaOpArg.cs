using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000420 RID: 1056
	[ProtoContract(Name = "SceneMobaOpArg")]
	[Serializable]
	public class SceneMobaOpArg : IExtensible
	{
		// Token: 0x17001133 RID: 4403
		// (get) Token: 0x06003802 RID: 14338 RVA: 0x0006B380 File Offset: 0x00069580
		// (set) Token: 0x06003803 RID: 14339 RVA: 0x0006B3AC File Offset: 0x000695AC
		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public MobaOp op
		{
			get
			{
				return this._op ?? MobaOp.MobaOp_LevelSkill;
			}
			set
			{
				this._op = new MobaOp?(value);
			}
		}

		// Token: 0x17001134 RID: 4404
		// (get) Token: 0x06003804 RID: 14340 RVA: 0x0006B3BC File Offset: 0x000695BC
		// (set) Token: 0x06003805 RID: 14341 RVA: 0x0006B3DC File Offset: 0x000695DC
		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new MobaOp?(this.op) : null);
				}
			}
		}

		// Token: 0x06003806 RID: 14342 RVA: 0x0006B420 File Offset: 0x00069620
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x06003807 RID: 14343 RVA: 0x0006B438 File Offset: 0x00069638
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x17001135 RID: 4405
		// (get) Token: 0x06003808 RID: 14344 RVA: 0x0006B444 File Offset: 0x00069644
		// (set) Token: 0x06003809 RID: 14345 RVA: 0x0006B470 File Offset: 0x00069670
		[ProtoMember(2, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public uint param
		{
			get
			{
				return this._param ?? 0U;
			}
			set
			{
				this._param = new uint?(value);
			}
		}

		// Token: 0x17001136 RID: 4406
		// (get) Token: 0x0600380A RID: 14346 RVA: 0x0006B480 File Offset: 0x00069680
		// (set) Token: 0x0600380B RID: 14347 RVA: 0x0006B4A0 File Offset: 0x000696A0
		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new uint?(this.param) : null);
				}
			}
		}

		// Token: 0x0600380C RID: 14348 RVA: 0x0006B4E4 File Offset: 0x000696E4
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x0600380D RID: 14349 RVA: 0x0006B4FC File Offset: 0x000696FC
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x0600380E RID: 14350 RVA: 0x0006B508 File Offset: 0x00069708
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DE1 RID: 3553
		private MobaOp? _op;

		// Token: 0x04000DE2 RID: 3554
		private uint? _param;

		// Token: 0x04000DE3 RID: 3555
		private IExtension extensionObject;
	}
}
