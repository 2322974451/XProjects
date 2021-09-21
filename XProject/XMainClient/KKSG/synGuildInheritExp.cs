using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002DC RID: 732
	[ProtoContract(Name = "synGuildInheritExp")]
	[Serializable]
	public class synGuildInheritExp : IExtensible
	{
		// Token: 0x17000C86 RID: 3206
		// (get) Token: 0x0600284B RID: 10315 RVA: 0x0004E4BC File Offset: 0x0004C6BC
		// (set) Token: 0x0600284C RID: 10316 RVA: 0x0004E4E9 File Offset: 0x0004C6E9
		[ProtoMember(1, IsRequired = false, Name = "roleOne", DataFormat = DataFormat.TwosComplement)]
		public ulong roleOne
		{
			get
			{
				return this._roleOne ?? 0UL;
			}
			set
			{
				this._roleOne = new ulong?(value);
			}
		}

		// Token: 0x17000C87 RID: 3207
		// (get) Token: 0x0600284D RID: 10317 RVA: 0x0004E4F8 File Offset: 0x0004C6F8
		// (set) Token: 0x0600284E RID: 10318 RVA: 0x0004E518 File Offset: 0x0004C718
		[XmlIgnore]
		[Browsable(false)]
		public bool roleOneSpecified
		{
			get
			{
				return this._roleOne != null;
			}
			set
			{
				bool flag = value == (this._roleOne == null);
				if (flag)
				{
					this._roleOne = (value ? new ulong?(this.roleOne) : null);
				}
			}
		}

		// Token: 0x0600284F RID: 10319 RVA: 0x0004E55C File Offset: 0x0004C75C
		private bool ShouldSerializeroleOne()
		{
			return this.roleOneSpecified;
		}

		// Token: 0x06002850 RID: 10320 RVA: 0x0004E574 File Offset: 0x0004C774
		private void ResetroleOne()
		{
			this.roleOneSpecified = false;
		}

		// Token: 0x17000C88 RID: 3208
		// (get) Token: 0x06002851 RID: 10321 RVA: 0x0004E580 File Offset: 0x0004C780
		// (set) Token: 0x06002852 RID: 10322 RVA: 0x0004E5AC File Offset: 0x0004C7AC
		[ProtoMember(2, IsRequired = false, Name = "expOne", DataFormat = DataFormat.TwosComplement)]
		public uint expOne
		{
			get
			{
				return this._expOne ?? 0U;
			}
			set
			{
				this._expOne = new uint?(value);
			}
		}

		// Token: 0x17000C89 RID: 3209
		// (get) Token: 0x06002853 RID: 10323 RVA: 0x0004E5BC File Offset: 0x0004C7BC
		// (set) Token: 0x06002854 RID: 10324 RVA: 0x0004E5DC File Offset: 0x0004C7DC
		[XmlIgnore]
		[Browsable(false)]
		public bool expOneSpecified
		{
			get
			{
				return this._expOne != null;
			}
			set
			{
				bool flag = value == (this._expOne == null);
				if (flag)
				{
					this._expOne = (value ? new uint?(this.expOne) : null);
				}
			}
		}

		// Token: 0x06002855 RID: 10325 RVA: 0x0004E620 File Offset: 0x0004C820
		private bool ShouldSerializeexpOne()
		{
			return this.expOneSpecified;
		}

		// Token: 0x06002856 RID: 10326 RVA: 0x0004E638 File Offset: 0x0004C838
		private void ResetexpOne()
		{
			this.expOneSpecified = false;
		}

		// Token: 0x17000C8A RID: 3210
		// (get) Token: 0x06002857 RID: 10327 RVA: 0x0004E644 File Offset: 0x0004C844
		// (set) Token: 0x06002858 RID: 10328 RVA: 0x0004E671 File Offset: 0x0004C871
		[ProtoMember(3, IsRequired = false, Name = "roleTwo", DataFormat = DataFormat.TwosComplement)]
		public ulong roleTwo
		{
			get
			{
				return this._roleTwo ?? 0UL;
			}
			set
			{
				this._roleTwo = new ulong?(value);
			}
		}

		// Token: 0x17000C8B RID: 3211
		// (get) Token: 0x06002859 RID: 10329 RVA: 0x0004E680 File Offset: 0x0004C880
		// (set) Token: 0x0600285A RID: 10330 RVA: 0x0004E6A0 File Offset: 0x0004C8A0
		[XmlIgnore]
		[Browsable(false)]
		public bool roleTwoSpecified
		{
			get
			{
				return this._roleTwo != null;
			}
			set
			{
				bool flag = value == (this._roleTwo == null);
				if (flag)
				{
					this._roleTwo = (value ? new ulong?(this.roleTwo) : null);
				}
			}
		}

		// Token: 0x0600285B RID: 10331 RVA: 0x0004E6E4 File Offset: 0x0004C8E4
		private bool ShouldSerializeroleTwo()
		{
			return this.roleTwoSpecified;
		}

		// Token: 0x0600285C RID: 10332 RVA: 0x0004E6FC File Offset: 0x0004C8FC
		private void ResetroleTwo()
		{
			this.roleTwoSpecified = false;
		}

		// Token: 0x17000C8C RID: 3212
		// (get) Token: 0x0600285D RID: 10333 RVA: 0x0004E708 File Offset: 0x0004C908
		// (set) Token: 0x0600285E RID: 10334 RVA: 0x0004E734 File Offset: 0x0004C934
		[ProtoMember(4, IsRequired = false, Name = "expTwo", DataFormat = DataFormat.TwosComplement)]
		public uint expTwo
		{
			get
			{
				return this._expTwo ?? 0U;
			}
			set
			{
				this._expTwo = new uint?(value);
			}
		}

		// Token: 0x17000C8D RID: 3213
		// (get) Token: 0x0600285F RID: 10335 RVA: 0x0004E744 File Offset: 0x0004C944
		// (set) Token: 0x06002860 RID: 10336 RVA: 0x0004E764 File Offset: 0x0004C964
		[XmlIgnore]
		[Browsable(false)]
		public bool expTwoSpecified
		{
			get
			{
				return this._expTwo != null;
			}
			set
			{
				bool flag = value == (this._expTwo == null);
				if (flag)
				{
					this._expTwo = (value ? new uint?(this.expTwo) : null);
				}
			}
		}

		// Token: 0x06002861 RID: 10337 RVA: 0x0004E7A8 File Offset: 0x0004C9A8
		private bool ShouldSerializeexpTwo()
		{
			return this.expTwoSpecified;
		}

		// Token: 0x06002862 RID: 10338 RVA: 0x0004E7C0 File Offset: 0x0004C9C0
		private void ResetexpTwo()
		{
			this.expTwoSpecified = false;
		}

		// Token: 0x17000C8E RID: 3214
		// (get) Token: 0x06002863 RID: 10339 RVA: 0x0004E7CC File Offset: 0x0004C9CC
		// (set) Token: 0x06002864 RID: 10340 RVA: 0x0004E7F8 File Offset: 0x0004C9F8
		[ProtoMember(5, IsRequired = false, Name = "turn", DataFormat = DataFormat.TwosComplement)]
		public uint turn
		{
			get
			{
				return this._turn ?? 0U;
			}
			set
			{
				this._turn = new uint?(value);
			}
		}

		// Token: 0x17000C8F RID: 3215
		// (get) Token: 0x06002865 RID: 10341 RVA: 0x0004E808 File Offset: 0x0004CA08
		// (set) Token: 0x06002866 RID: 10342 RVA: 0x0004E828 File Offset: 0x0004CA28
		[XmlIgnore]
		[Browsable(false)]
		public bool turnSpecified
		{
			get
			{
				return this._turn != null;
			}
			set
			{
				bool flag = value == (this._turn == null);
				if (flag)
				{
					this._turn = (value ? new uint?(this.turn) : null);
				}
			}
		}

		// Token: 0x06002867 RID: 10343 RVA: 0x0004E86C File Offset: 0x0004CA6C
		private bool ShouldSerializeturn()
		{
			return this.turnSpecified;
		}

		// Token: 0x06002868 RID: 10344 RVA: 0x0004E884 File Offset: 0x0004CA84
		private void Resetturn()
		{
			this.turnSpecified = false;
		}

		// Token: 0x17000C90 RID: 3216
		// (get) Token: 0x06002869 RID: 10345 RVA: 0x0004E890 File Offset: 0x0004CA90
		// (set) Token: 0x0600286A RID: 10346 RVA: 0x0004E8BC File Offset: 0x0004CABC
		[ProtoMember(6, IsRequired = false, Name = "islast", DataFormat = DataFormat.Default)]
		public bool islast
		{
			get
			{
				return this._islast ?? false;
			}
			set
			{
				this._islast = new bool?(value);
			}
		}

		// Token: 0x17000C91 RID: 3217
		// (get) Token: 0x0600286B RID: 10347 RVA: 0x0004E8CC File Offset: 0x0004CACC
		// (set) Token: 0x0600286C RID: 10348 RVA: 0x0004E8EC File Offset: 0x0004CAEC
		[XmlIgnore]
		[Browsable(false)]
		public bool islastSpecified
		{
			get
			{
				return this._islast != null;
			}
			set
			{
				bool flag = value == (this._islast == null);
				if (flag)
				{
					this._islast = (value ? new bool?(this.islast) : null);
				}
			}
		}

		// Token: 0x0600286D RID: 10349 RVA: 0x0004E930 File Offset: 0x0004CB30
		private bool ShouldSerializeislast()
		{
			return this.islastSpecified;
		}

		// Token: 0x0600286E RID: 10350 RVA: 0x0004E948 File Offset: 0x0004CB48
		private void Resetislast()
		{
			this.islastSpecified = false;
		}

		// Token: 0x17000C92 RID: 3218
		// (get) Token: 0x0600286F RID: 10351 RVA: 0x0004E954 File Offset: 0x0004CB54
		// (set) Token: 0x06002870 RID: 10352 RVA: 0x0004E981 File Offset: 0x0004CB81
		[ProtoMember(7, IsRequired = false, Name = "teacherId", DataFormat = DataFormat.TwosComplement)]
		public ulong teacherId
		{
			get
			{
				return this._teacherId ?? 0UL;
			}
			set
			{
				this._teacherId = new ulong?(value);
			}
		}

		// Token: 0x17000C93 RID: 3219
		// (get) Token: 0x06002871 RID: 10353 RVA: 0x0004E990 File Offset: 0x0004CB90
		// (set) Token: 0x06002872 RID: 10354 RVA: 0x0004E9B0 File Offset: 0x0004CBB0
		[XmlIgnore]
		[Browsable(false)]
		public bool teacherIdSpecified
		{
			get
			{
				return this._teacherId != null;
			}
			set
			{
				bool flag = value == (this._teacherId == null);
				if (flag)
				{
					this._teacherId = (value ? new ulong?(this.teacherId) : null);
				}
			}
		}

		// Token: 0x06002873 RID: 10355 RVA: 0x0004E9F4 File Offset: 0x0004CBF4
		private bool ShouldSerializeteacherId()
		{
			return this.teacherIdSpecified;
		}

		// Token: 0x06002874 RID: 10356 RVA: 0x0004EA0C File Offset: 0x0004CC0C
		private void ResetteacherId()
		{
			this.teacherIdSpecified = false;
		}

		// Token: 0x06002875 RID: 10357 RVA: 0x0004EA18 File Offset: 0x0004CC18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A07 RID: 2567
		private ulong? _roleOne;

		// Token: 0x04000A08 RID: 2568
		private uint? _expOne;

		// Token: 0x04000A09 RID: 2569
		private ulong? _roleTwo;

		// Token: 0x04000A0A RID: 2570
		private uint? _expTwo;

		// Token: 0x04000A0B RID: 2571
		private uint? _turn;

		// Token: 0x04000A0C RID: 2572
		private bool? _islast;

		// Token: 0x04000A0D RID: 2573
		private ulong? _teacherId;

		// Token: 0x04000A0E RID: 2574
		private IExtension extensionObject;
	}
}
