using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Models.Enums;

namespace DreamPoeBot.Loki.Elements;

public class InventorySlotUiElement : Element
{
	public readonly int slotsize = 78;

	private readonly int halfslotSize = 41;

	private readonly double socketPos = 29.0;

	private StashType _stashType = StashType.NormalStash;

	private LokiPoe.InGameState.SentinelLockerUi.SentinelType _sentinelType;

	private static int id_offset = 776;

	private static int item_offset = 880;

	public int ItemsCount => (int)base.ChildCount - 1;

	public Dictionary<Vector2i, Item> PlacementGraph
	{
		get
		{
			if (_stashType != StashType.FragmentEldrich && _stashType != StashType.FragmentMaven)
			{
				Dictionary<Vector2i, Item> dictionary = new Dictionary<Vector2i, Item>();
				int num = 0;
				using (List<Element>.Enumerator enumerator = base.Children.GetEnumerator())
				{
					uint num4 = default(uint);
					int num6 = default(int);
					Vector2i locationTopLeft = default(Vector2i);
					int num7 = default(int);
					int num8 = default(int);
					Vector2i locationBottomRight = default(Vector2i);
					int id = default(int);
					Item item = default(Item);
					int num9 = default(int);
					Vector2i key = default(Vector2i);
					while (enumerator.MoveNext())
					{
						while (true)
						{
							IL_01e2:
							Element current = enumerator.Current;
							if (num != 0)
							{
								while (true)
								{
									IL_01dd:
									int num2 = 1;
									while (true)
									{
										IL_01d8:
										int num3 = 1;
										while (true)
										{
											IL_01cc:
											if (_stashType != StashType.ExplorationLocker)
											{
												while (true)
												{
													IL_01c0:
													if (_stashType == StashType.SentinelLocker)
													{
														while (true)
														{
															IL_01b1:
															if (current.X != 0f)
															{
																goto IL_018a;
															}
															goto IL_01ac;
															IL_01ac:
															num2 = 1;
															goto IL_019d;
															IL_019d:
															while (true)
															{
																IL_019d_2:
																if (current.Y == 0f)
																{
																	goto IL_0168;
																}
																goto IL_0175;
																IL_0175:
																num3 = (int)(current.Y / (float)slotsize) + 1;
																goto IL_016b;
																IL_016b:
																while (true)
																{
																	IL_016b_2:
																	LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = _sentinelType;
																	while (true)
																	{
																		IL_014c:
																		switch (sentinelType)
																		{
																		case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
																			goto IL_02a6;
																		case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
																			goto IL_02af;
																		case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
																		case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
																			goto end_IL_014c;
																		}
																		int num5 = (int)((num4 * 1373107623) ^ 0x25C73163);
																		while (true)
																		{
																			switch ((num4 = (uint)num5 ^ 0xAF2C706u) % 57u)
																			{
																			case 31u:
																				num5 = (int)((num4 * 1574024938) ^ 0x5C042E3C);
																				continue;
																			case 29u:
																				goto IL_014c;
																			case 33u:
																				goto IL_0168;
																			case 46u:
																				goto IL_016b_2;
																			case 39u:
																				goto IL_0175;
																			case 20u:
																				goto IL_018a;
																			case 13u:
																			case 51u:
																				goto IL_019d_2;
																			case 2u:
																				goto IL_01ac;
																			case 25u:
																				goto IL_01b1;
																			case 9u:
																				goto IL_01c0;
																			case 4u:
																				goto IL_01cc;
																			case 47u:
																				goto IL_01d8;
																			case 36u:
																				goto IL_01dd;
																			case 11u:
																			case 55u:
																				goto IL_01e2;
																			case 8u:
																				goto IL_01f2;
																			case 35u:
																				goto IL_0201;
																			case 42u:
																				goto IL_0206;
																			case 43u:
																				goto IL_0215;
																			case 32u:
																				goto IL_0222;
																			case 44u:
																				goto IL_0237;
																			case 53u:
																				goto IL_0252;
																			case 0u:
																				goto IL_0255;
																			case 34u:
																				goto IL_0262;
																			case 30u:
																				goto IL_0277;
																			case 54u:
																				goto IL_027c;
																			case 19u:
																			case 21u:
																			case 49u:
																				goto IL_027f;
																			case 37u:
																				goto IL_028c;
																			case 40u:
																				goto IL_0291;
																			case 24u:
																				goto IL_02a6;
																			case 50u:
																				goto IL_02af;
																			case 6u:
																			case 7u:
																			case 12u:
																			case 52u:
																				goto end_IL_014c;
																			case 3u:
																				goto IL_02d1;
																			case 26u:
																				goto IL_02e1;
																			case 48u:
																				goto IL_0300;
																			case 27u:
																				goto IL_031a;
																			case 16u:
																				goto IL_0340;
																			case 14u:
																				goto IL_0345;
																			case 22u:
																				goto IL_034a;
																			case 15u:
																				goto IL_0365;
																			case 45u:
																				goto IL_036f;
																			case 56u:
																				goto IL_0379;
																			case 23u:
																			case 41u:
																				goto IL_037f;
																			case 28u:
																				goto IL_038f;
																			case 1u:
																				goto IL_0395;
																			case 10u:
																				goto IL_03a5;
																			case 17u:
																				goto IL_03ab;
																			case 5u:
																			case 38u:
																				goto IL_03af;
																			case 18u:
																				break;
																			}
																			break;
																		}
																		goto end_IL_01cc;
																		IL_02af:
																		num2 -= 24;
																		break;
																		IL_02a6:
																		num2 -= 12;
																		break;
																		continue;
																		end_IL_014c:
																		break;
																	}
																	break;
																}
																break;
																IL_0168:
																num3 = 1;
																goto IL_016b;
															}
															break;
															IL_018a:
															num2 = (int)(current.X / (float)slotsize) + 1;
															goto IL_019d;
														}
														break;
													}
													goto IL_0215;
													IL_0277:
													num3 = 1;
													break;
													IL_0215:
													if (current.X != 0f)
													{
														goto IL_0222;
													}
													goto IL_0252;
													IL_0222:
													num2 = (int)(current.X / (float)slotsize) + 1;
													goto IL_0255;
													IL_0252:
													num2 = 1;
													goto IL_0255;
													IL_0255:
													if (current.Y != 0f)
													{
														goto IL_0262;
													}
													goto IL_0277;
													IL_0262:
													num3 = (int)(current.Y / (float)slotsize) + 1;
													break;
												}
												goto IL_02b6;
											}
											goto IL_01f2;
											IL_0379:
											num6++;
											goto IL_037f;
											IL_01f2:
											if (current.X == 0f)
											{
												goto IL_0201;
											}
											goto IL_0206;
											IL_0206:
											if (current.X != 312f)
											{
												goto IL_0237;
											}
											goto IL_027c;
											IL_0237:
											num2 = (int)((current.X - 312f) / (float)slotsize) + 1;
											goto IL_027f;
											IL_027c:
											num2 = 1;
											goto IL_027f;
											IL_0201:
											num2 = 1;
											goto IL_027f;
											IL_027f:
											if (current.Y == 0f)
											{
												goto IL_028c;
											}
											goto IL_0291;
											IL_028c:
											num3 = 1;
											goto IL_02b6;
											IL_0291:
											num3 = (int)(current.Y / (float)slotsize) + 1;
											goto IL_02b6;
											IL_02b6:
											locationTopLeft = new Vector2i(num2, num3);
											num7 = (int)current.Width / slotsize;
											goto IL_02d1;
											IL_02d1:
											num8 = (int)current.Height / slotsize;
											goto IL_02e1;
											IL_02e1:
											locationBottomRight = new Vector2i(locationTopLeft.X + num7 - 1, locationTopLeft.Y + num8 - 1);
											goto IL_0300;
											IL_0300:
											id = base.M.ReadInt(current.Address + id_offset);
											goto IL_031a;
											IL_031a:
											item = new Item(base.M.ReadLong(current.Address + item_offset), hasInventoryLocation: true, locationBottomRight, locationTopLeft, id);
											goto IL_0340;
											IL_0340:
											num9 = 0;
											goto IL_0395;
											IL_0395:
											if (num9 < item.Size.Y)
											{
												goto IL_0345;
											}
											goto IL_03a5;
											IL_03a5:
											num++;
											goto IL_03af;
											IL_0345:
											num6 = 0;
											goto IL_037f;
											IL_037f:
											if (num6 < item.Size.X)
											{
												goto IL_034a;
											}
											goto IL_038f;
											IL_038f:
											num9++;
											goto IL_0395;
											IL_034a:
											key = new Vector2i(locationTopLeft.X + num6, locationTopLeft.Y + num9);
											goto IL_0365;
											IL_0365:
											if (!dictionary.ContainsKey(key))
											{
												goto IL_036f;
											}
											goto IL_0379;
											IL_036f:
											dictionary.Add(key, item);
											goto IL_0379;
											continue;
											end_IL_01cc:
											break;
										}
										break;
									}
									break;
								}
								break;
							}
							goto IL_03ab;
							IL_03ab:
							num++;
							goto IL_03af;
						}
						break;
						IL_03af:;
					}
				}
				{
					foreach (Vector2i slot in Slots)
					{
						if (!dictionary.ContainsKey(slot))
						{
							dictionary.Add(slot, null);
						}
					}
					return dictionary;
				}
			}
			return EldrichMavenPlacementGraph;
		}
	}

	private Dictionary<Vector2i, Item> EldrichMavenPlacementGraph
	{
		get
		{
			Dictionary<Vector2i, Item> dictionary = new Dictionary<Vector2i, Item>();
			int num = 0;
			foreach (Element child in base.Children[0].Children)
			{
				int num2 = 0;
				foreach (Element child2 in child.Children)
				{
					if (num2 != 0)
					{
						int num3 = 1;
						int y = num + 1;
						num3 = ((child2.X == 0f) ? 1 : ((num == 0) ? ((int)(child2.X / (float)slotsize) + 1) : ((int)(child2.X / (float)slotsize) - 12 * num + 1)));
						Vector2i locationTopLeft = new Vector2i(num3, y);
						int num4 = (int)child2.Width / slotsize;
						int num5 = (int)child2.Height / slotsize;
						Vector2i locationBottomRight = new Vector2i(locationTopLeft.X + num4 - 1, locationTopLeft.Y + num5 - 1);
						int id = base.M.ReadInt(child2.Address + id_offset);
						Item item = new Item(base.M.ReadLong(child2.Address + item_offset), hasInventoryLocation: true, locationBottomRight, locationTopLeft, id);
						for (int i = 0; i < item.Size.Y; i++)
						{
							for (int j = 0; j < item.Size.X; j++)
							{
								Vector2i key = new Vector2i(locationTopLeft.X + j, locationTopLeft.Y + i);
								if (!dictionary.ContainsKey(key))
								{
									dictionary.Add(key, item);
								}
							}
						}
						num2++;
					}
					else
					{
						num2++;
					}
				}
				num++;
			}
			foreach (Vector2i slot in Slots)
			{
				if (!dictionary.ContainsKey(slot))
				{
					dictionary.Add(slot, null);
				}
			}
			return dictionary;
		}
	}

	private List<Vector2i> Slots
	{
		get
		{
			if (_stashType != StashType.FragmentEldrich && _stashType != StashType.FragmentMaven)
			{
				List<Vector2i> list = new List<Vector2i>();
				int num = 1;
				for (int i = 0; (float)i < base.Height; i += slotsize)
				{
					int num2 = 1;
					for (int j = 0; (float)j < base.Width; j += slotsize)
					{
						list.Add(new Vector2i(num2, num));
						num2++;
					}
					num++;
				}
				return list;
			}
			return EldrichMavenSlots;
		}
	}

	private List<Vector2i> EldrichMavenSlots
	{
		get
		{
			List<Vector2i> list = new List<Vector2i>();
			int num = 1;
			for (int i = 0; i < 6; i++)
			{
				int num2 = 1;
				for (int j = 0; j < 12; j++)
				{
					list.Add(new Vector2i(num2, num));
					num2++;
				}
				num++;
			}
			return list;
		}
	}

	public Dictionary<Vector2i, Dictionary<int, Vector2i>> SocketDictionary
	{
		get
		{
			Dictionary<Vector2i, Dictionary<int, Vector2i>> dictionary = new Dictionary<Vector2i, Dictionary<int, Vector2i>>();
			int num = 0;
			foreach (Element child in base.Children)
			{
				if (num != 0)
				{
					if (child.ChildCount != 0L)
					{
						if (child.Children[0].ChildCount != 0L)
						{
							int num2 = 0;
							int num3 = 0;
							num2 = ((child.X == 0f) ? 1 : ((int)(child.X / (float)slotsize) + 1));
							num3 = ((child.Y == 0f) ? 1 : ((int)(child.Y / (float)slotsize) + 1));
							Vector2i key = new Vector2i(num2, num3);
							int num4 = 0;
							foreach (Element child2 in child.Children[0].Children)
							{
								if (!dictionary.ContainsKey(key))
								{
									dictionary.Add(key, new Dictionary<int, Vector2i>());
								}
								double num5 = (socketPos + (double)(int)child2.X + (double)(int)child.X + (double)child.Children[0].X) * (double)base.Scale + (double)LocationTopLeft.X;
								double num6 = (socketPos + (double)(int)child2.Y + (double)(int)child.Y + (double)child.Children[0].Y) * (double)base.Scale + (double)LocationTopLeft.Y;
								dictionary[key].Add(num4, new Vector2i((int)num5, (int)num6));
								num4++;
							}
							num++;
						}
						else
						{
							num++;
						}
					}
					else
					{
						num++;
					}
				}
				else
				{
					num++;
				}
			}
			return dictionary;
		}
	}

	public Vector2i LocationTopLeft
	{
		get
		{
			float num = 0f;
			float num2 = 0f;
			if (_stashType == StashType.MapDevice)
			{
				num = (base.X + base.DeltaX) * base.Scale;
				num2 = (base.Y + base.DeltaY) * base.Scale;
				Element element = base.Parent;
				if (_stashType == StashType.FragmentEldrich || _stashType == StashType.FragmentMaven)
				{
					element = base.Children[0];
				}
				while (element.Address != 0L && element.IdLabel != "root")
				{
					num += (element.X + element.DeltaX) * element.Scale;
					num2 += (element.Y + element.DeltaY) * element.Scale;
					element = element.Parent;
				}
			}
			else
			{
				num = base.X * base.Scale;
				num2 = base.Y * base.Scale;
				Element element2 = base.Parent;
				if (_stashType == StashType.FragmentEldrich || _stashType == StashType.FragmentMaven)
				{
					element2 = base.Children[0];
				}
				while (element2.Address != 0L && element2.IdLabel != "root")
				{
					num += element2.X * element2.Scale;
					num2 += element2.Y * element2.Scale;
					element2 = element2.Parent;
				}
			}
			return new Vector2i((int)num, (int)num2);
		}
	}

	public Vector2i Size => new Vector2i((int)(base.Width * base.Scale), (int)(base.Height * base.Scale));

	public Dictionary<int, Element> DictionaryIdElements
	{
		get
		{
			if (_stashType != StashType.FragmentEldrich && _stashType != StashType.FragmentMaven)
			{
				Dictionary<int, Element> dictionary = new Dictionary<int, Element>();
				int num = 0;
				{
					foreach (Element child in base.Children)
					{
						if (num == 0)
						{
							num++;
							continue;
						}
						int num2 = base.M.ReadInt(child.Address + id_offset);
						if (num2 != 0 && !dictionary.ContainsKey(num2))
						{
							dictionary.Add(num2, child);
						}
						num++;
					}
					return dictionary;
				}
			}
			return EldrichMavenDictionaryIdElements;
		}
	}

	private Dictionary<int, Element> EldrichMavenDictionaryIdElements
	{
		get
		{
			Dictionary<int, Element> dictionary = new Dictionary<int, Element>();
			int num = 0;
			foreach (Element child in base.Children[0].Children)
			{
				int num2 = 0;
				foreach (Element child2 in child.Children)
				{
					if (num2 == 0)
					{
						num2++;
						continue;
					}
					int num3 = base.M.ReadInt(child2.Address + id_offset);
					if (num3 != 0 && !dictionary.ContainsKey(num3))
					{
						dictionary.Add(num3, child2);
					}
					num2++;
				}
				num++;
			}
			return dictionary;
		}
	}

	public Vector2i RewardLocationTopLeft => new Vector2i((int)((base.X + base.Parent.X + base.Parent.Parent.X + base.Parent.Parent.Parent.X + base.Parent.Parent.Parent.Parent.X + base.Parent.Parent.Parent.Parent.Parent.X) * base.Scale), (int)((base.Y + base.Parent.Y + base.Parent.Parent.Y + base.Parent.Parent.Parent.Y + base.Parent.Parent.Parent.Parent.Y + base.Parent.Parent.Parent.Parent.Parent.Y) * base.Scale));

	public InventorySlotUiElement()
	{
	}

	public InventorySlotUiElement(long address, StashType stashType, LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown)
	{
		base.Address = address;
		_stashType = stashType;
		if (stashType == StashType.QuadStash)
		{
			slotsize = 39;
			halfslotSize = 21;
			socketPos = 14.5;
		}
		if (stashType == StashType.MapStash)
		{
			slotsize = 71;
			halfslotSize = 36;
			socketPos = 21.0;
		}
		if (stashType == StashType.SentinelLocker)
		{
			_sentinelType = sentinelType;
			slotsize = 65;
			halfslotSize = 33;
			socketPos = 18.0;
		}
		if (stashType == StashType.FragmentEldrich || stashType == StashType.FragmentMaven)
		{
			slotsize = 66;
			halfslotSize = 34;
			socketPos = 18.0;
		}
	}

	public void SetStashType(StashType stashType)
	{
		_stashType = stashType;
	}

	public Vector2i ElementLocationTopLeft(Element element)
	{
		float num = element.X;
		float num2 = element.Y;
		Element parent = element.Parent;
		while (parent.Address != 0L && parent.IdLabel != "root")
		{
			num += parent.X;
			num2 += parent.Y;
			parent = parent.Parent;
		}
		return new Vector2i((int)(num * element.Scale), (int)(num2 * element.Scale));
	}

	public Vector2i SlotClickLocation(Vector2i slot)
	{
		int num = (int)((float)(slot.X * slotsize) * base.Scale - (float)halfslotSize * base.Scale);
		int num2 = (int)((float)(slot.Y * slotsize) * base.Scale - (float)halfslotSize * base.Scale);
		return new Vector2i(LocationTopLeft.X + num, LocationTopLeft.Y + num2);
	}

	public Vector2i RewardSlotClickLocation(Vector2i slot)
	{
		int num = (int)((float)slotsize * base.Scale - (float)halfslotSize * base.Scale);
		int num2 = (int)((float)slotsize * base.Scale - (float)halfslotSize * base.Scale);
		return new Vector2i(RewardLocationTopLeft.X + num, RewardLocationTopLeft.Y + num2);
	}
}
