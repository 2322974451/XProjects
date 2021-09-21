using System;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000833 RID: 2099
	[ProtoContract(Name = "CrossGvgTimeState")]
	public enum CrossGvgTimeState
	{
		// Token: 0x04002816 RID: 10262
		[ProtoEnum(Name = "CGVG_NotOpen", Value = 1)]
		CGVG_NotOpen = 1,
		// Token: 0x04002817 RID: 10263
		[ProtoEnum(Name = "CGVG_Select", Value = 2)]
		CGVG_Select,
		// Token: 0x04002818 RID: 10264
		[ProtoEnum(Name = "CGVG_PointRace", Value = 3)]
		CGVG_PointRace,
		// Token: 0x04002819 RID: 10265
		[ProtoEnum(Name = "CGVG_Guess", Value = 4)]
		CGVG_Guess,
		// Token: 0x0400281A RID: 10266
		[ProtoEnum(Name = "CGVG_Knockout", Value = 5)]
		CGVG_Knockout,
		// Token: 0x0400281B RID: 10267
		[ProtoEnum(Name = "CGVG_SeasonEnd", Value = 6)]
		CGVG_SeasonEnd
	}
}
