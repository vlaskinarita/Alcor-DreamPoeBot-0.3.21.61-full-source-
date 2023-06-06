using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

internal class RegionInventory : Element
{
	internal LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum Region
	{
		get
		{
			if (!string.IsNullOrEmpty(base.Children[3]?.Children[0]?.Children[0]?.Text))
			{
				return GetRegionEnum(base.Children[3].Children[0].Children[0].Text);
			}
			return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Unknown;
		}
	}

	internal bool IsOccupied => base.Children[0].IsVisibleLocal;

	internal LokiPoe.InstanceInfo.Atlas.Conqueror Conqueror => GetConqueror();

	internal int RequiredWatchstone => GetRequiredWatchstone();

	internal int RequiredMaps => GetRequiredMaps();

	internal Element Red => base.Children[4];

	internal Element Green => base.Children[5];

	internal Element Blue => base.Children[6];

	internal Element Yellow => base.Children[7];

	private LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum GetRegionEnum(string region)
	{
		return region switch
		{
			"Tirn's End" => LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Tirns_End, 
			"Valdo's Rest" => LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Valdos_Rest, 
			"Lex Ejoris" => LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Lex_Ejoris, 
			"Glennach Cairns" => LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Glennach_Cairns, 
			"Haewark Hamlet" => LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Haewark_Hamlet, 
			"New Vastir" => LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.New_Vastir, 
			"Lira Arthain" => LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Lira_Arthain, 
			"Lex Proxima" => LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Lex_Proxima, 
			_ => LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Unknown, 
		};
	}

	private LokiPoe.InstanceInfo.Atlas.Conqueror GetConqueror()
	{
		if (!IsOccupied)
		{
			return LokiPoe.InstanceInfo.Atlas.Conqueror.None;
		}
		string text = base.Children[0].Children[1].Children[0].Tooltip.Text;
		if (!text.Contains("Crusader"))
		{
			if (text.Contains("Hunter"))
			{
				return LokiPoe.InstanceInfo.Atlas.Conqueror.Hunter;
			}
			if (!text.Contains("Warlord"))
			{
				if (!text.Contains("Redeemer"))
				{
					if (!text.Contains("Awakener"))
					{
						return LokiPoe.InstanceInfo.Atlas.Conqueror.None;
					}
					return LokiPoe.InstanceInfo.Atlas.Conqueror.Awakener;
				}
				return LokiPoe.InstanceInfo.Atlas.Conqueror.Redeemer;
			}
			return LokiPoe.InstanceInfo.Atlas.Conqueror.Warlord;
		}
		return LokiPoe.InstanceInfo.Atlas.Conqueror.Crusader;
	}

	private int GetRequiredWatchstone()
	{
		if (!IsOccupied)
		{
			return 0;
		}
		string text = base.Children[0].Children[1].Children[0].Tooltip.Text;
		if (text.Contains("Region with 0 Watchstones socketed"))
		{
			return 0;
		}
		if (!text.Contains("Region with 1 Watchstones socketed"))
		{
			if (text.Contains("Region with 2 Watchstones socketed"))
			{
				return 2;
			}
			if (!text.Contains("Region with 3 Watchstones socketed"))
			{
				if (!text.Contains("Region with 4 Watchstones socketed"))
				{
					return 0;
				}
				return 4;
			}
			return 3;
		}
		return 1;
	}

	private int GetRequiredMaps()
	{
		if (!IsOccupied)
		{
			return -1;
		}
		string text = base.Children[0].Children[1].Children[0].Tooltip.Text;
		if (!text.Contains("Completing 1 more Maps"))
		{
			if (!text.Contains("Completing 2 more Maps"))
			{
				if (text.Contains("Completing 3 more Maps"))
				{
					return 3;
				}
				if (!text.Contains("Completing 4 more Maps"))
				{
					if (!text.Contains("Completing 5 more Maps"))
					{
						if (!text.Contains("Completing 6 more Maps"))
						{
							if (!text.Contains("Completing 7 more Maps"))
							{
								if (!text.Contains("Completing 8 more Maps"))
								{
									if (!text.Contains("Completing 9 more Maps"))
									{
										if (text.Contains("Completing 10 more Maps"))
										{
											return 10;
										}
										if (!text.Contains("Completing 11 more Maps"))
										{
											if (!text.Contains("Completing 12 more Maps"))
											{
												return 0;
											}
											return 12;
										}
										return 11;
									}
									return 9;
								}
								return 8;
							}
							return 7;
						}
						return 6;
					}
					return 5;
				}
				return 4;
			}
			return 2;
		}
		return 1;
	}
}
