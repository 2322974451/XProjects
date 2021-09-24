using System;

namespace UILib
{

	public interface IXUIBillBoardCompRef
	{

		IXUISpecLabelSymbol NameSpecLabelSymbol { get; }

		IXUISpecLabelSymbol GuildSpecLabelSymbol { get; }

		IXUISpecLabelSymbol DesiSpecLabelSymbol { get; }

		IXUIProgress BloodBar { get; }

		IXUIProgress IndureBar { get; }
	}
}
