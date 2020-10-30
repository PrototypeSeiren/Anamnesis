﻿// Concept Matrix 3.
// Licensed under the MIT license.

namespace Anamnesis.Services
{
	using System.Threading.Tasks;
	using Anamnesis.Character;
	using Anamnesis.GameData;
	using Anamnesis.GameData.Sheets;
	using Anamnesis.GameData.ViewModels;
	using Anamnesis.Memory;
	using Lumina.Excel;
	using Lumina.Excel.GeneratedSheets;

	using LuminaData = Lumina.Lumina;

	public class GameDataService : ServiceBase<GameDataService>
	{
		private LuminaData? lumina;

		#pragma warning disable CS8618
		public static ISheet<IRace> Races { get; protected set; }
		public static ISheet<ITribe> Tribes { get; protected set; }
		public static ISheet<IItem> Items { get; protected set; }
		public static ISheet<IDye> Dyes { get; protected set; }
		public static ISheet<INpcBase> BaseNPCs { get; protected set; }
		public static ISheet<ITerritoryType> Territories { get; protected set; }
		public static ISheet<IWeather> Weathers { get; protected set; }
		public static ICharaMakeCustomizeData CharacterMakeCustomize { get; protected set; }
		public static ISheet<ICharaMakeType> CharacterMakeTypes { get; protected set; }
		public static ISheet<INpcResident> ResidentNPCs { get; protected set; }
		public static ExcelSheet<WeatherRate> WeatherRates { get; protected set; }
		public static ISheet<ModelType> ModelTypes { get; private set; }
		public static ISheet<Prop> Props { get; private set; }
		public static ISheet<Animation> Animations { get; private set; }
		#pragma warning restore CS8618

		public override Task Initialize()
		{
			this.lumina = new LuminaData(MemoryService.GamePath + "\\game\\sqpack\\");

			Races = new LuminaSheet<IRace, Race, RaceViewModel>(this.lumina);
			Tribes = new LuminaSheet<ITribe, Tribe, TribeViewModel>(this.lumina);
			Items = new LuminaSheet<IItem, Lumina.Excel.GeneratedSheets.Item, GameData.ViewModels.ItemViewModel>(this.lumina);
			Dyes = new LuminaSheet<IDye, Stain, DyeViewModel>(this.lumina);
			BaseNPCs = new LuminaSheet<INpcBase, ENpcBase, NpcBaseViewModel>(this.lumina);
			Territories = new LuminaSheet<ITerritoryType, TerritoryType, TerritoryTypeViewModel>(this.lumina);
			Weathers = new LuminaSheet<IWeather, Weather, WeatherViewModel>(this.lumina);
			CharacterMakeCustomize = new CustomizeSheet(this.lumina);
			CharacterMakeTypes = new LuminaSheet<ICharaMakeType, GameData.Sheets.CharaMakeType, CharaMakeTypeViewModel>(this.lumina);
			ResidentNPCs = new LuminaSheet<INpcResident, ENpcResident, NpcResidentViewModel>(this.lumina);

			// no view models for these
			WeatherRates = this.lumina.GetExcelSheet<WeatherRate>();

			// these are json files that we write by hand
			ModelTypes = new JsonSheet<ModelType>("ModelTypes.json");
			Props = new JsonSheet<Prop>("Props.json");
			Animations = new JsonSheet<Animation>("Animations.json");

			return base.Initialize();
		}
	}
}
